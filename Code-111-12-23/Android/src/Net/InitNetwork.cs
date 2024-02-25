using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using Xamarin.Essentials;

namespace PenghuSpace.Net
{
    internal class InitNetwork
    {
		public InitNetwork()
        {
			if (Connectivity.NetworkAccess == Xamarin.Essentials.NetworkAccess.Internet)
				Init();
			else
				Connectivity.ConnectivityChanged += NetworkChanged;
		}
		private void NetworkChanged(object sender, ConnectivityChangedEventArgs e)
		{
			if (Connectivity.NetworkAccess == Xamarin.Essentials.NetworkAccess.Internet)
			{
				Connectivity.ConnectivityChanged -= NetworkChanged;
				Init();
			}
			else
            {

            }
		}
		private void Init()
        {
			IPHostEntry hostInfo = Dns.GetHostEntry("chmc.ml");
			if(CheckIPv6())
            {
                foreach (IPAddress item in hostInfo.AddressList)
                {
					if(item.AddressFamily == AddressFamily.InterNetworkV6)
                    {
						Network.SetserverIP(item);
						break;
                    }
                }
            }
			else
            {
				foreach (IPAddress item in hostInfo.AddressList)
				{
					if (item.AddressFamily == AddressFamily.InterNetwork)
					{
						Network.SetserverIP(item);
						break;
					}
				}
			}
		}
		public bool CheckIPv6()
        {
			bool isIPv6 = false;
			IPHostEntry oClient = Dns.GetHostEntry(Dns.GetHostName());
			foreach (IPAddress oItem in oClient.AddressList)
			{
				if (IsPrivate(oItem)) continue;
				if (IsLocal(oItem)) continue;
				if (oItem.AddressFamily == AddressFamily.InterNetworkV6)
				{
					isIPv6 = true;
					break;
				}
			}
			return isIPv6;
		}
		private bool IsPrivate(IPAddress oIPAddress)
		{
			//如果不是IPv4就踢出去
			if (oIPAddress.AddressFamily != AddressFamily.InterNetwork) { return false; }
			int[] iIP;
			try
			{ //分割並利用LINQ驗證IP正確性
				iIP = oIPAddress.ToString().Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s)).ToArray();
			}
			catch
			{ //如果有出錯一律回傳false
				return false;
			}
			//判斷是否為私有IP
			if
			(
				(iIP[0] == 10) ||
				(iIP[0] == 192 && iIP[1] == 168) ||
				(iIP[0] == 172 && (iIP[1] >= 16 && iIP[1] <= 31))
			)
			{ return true; }
			else
			{ return false; }
		}

		private bool IsLocal(IPAddress oIPAddress)
		{
			if (oIPAddress.AddressFamily == AddressFamily.InterNetwork)
			{
				if (oIPAddress.ToString().IndexOf("127.0.0.1, ::1") != -1)
				{ return true; }
				else
				{ return false; }
			}
			else
			{
				if (oIPAddress.IsIPv6LinkLocal || oIPAddress.IsIPv6SiteLocal || oIPAddress.IsIPv6Multicast)
				{ return true; }
				else
				{ return false; }
			}
		}
	}
}