#region using
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Essentials;
using PenghuSpace.Activity;
#endregion using

namespace PenghuSpace.Net
{
    internal static class Network
    {

        #region 屬性

        private static IPEndPoint _serverIP { get; set; }

        private static Socket _socket { get; set; }

        private static byte[] _message { get; set; }

        public static bool internet { get; private set; }

        #endregion 屬性

        #region Setter

        #region serverIP

        public static void SetserverIP(IPAddress iP)
        {
            _serverIP = new IPEndPoint(iP, 51420);
        }

        #endregion serverIP

        #region socket

        public static void Setsocket(ref Socket sk)
        {
            _socket = sk;
        }

        #endregion socket

        #endregion Setter

        public static void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            CheckInternet();
            TitleActivity.ChangedNetwork();
        }

        public static void CheckInternet()
        {
            if (Connectivity.NetworkAccess == Xamarin.Essentials.NetworkAccess.Internet)
            {
                internet = true;

            }

            else
            {
                internet = false;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Send(byte type, ref string msg)
        {
            byte[] data = new byte[Encoding.UTF8.GetBytes(msg).Length + 1];
            data[0] = type;
            Encoding.UTF8.GetBytes(msg, 0, msg.Length, data, 1);
            _socket.SendTo(data, _serverIP);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Send(byte type, ref byte[] msg)
        {
            byte[] data = new byte[msg.Length + 1];
            data[0] = type;
            msg.CopyTo(data, 1);
            _socket.SendTo(data, _serverIP);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void Listen()
        {
            /*while (true)
            {
                try
                {
                    message = new byte[4096]; //存放接收的資料
                    int recv = _socket.ReceiveFrom(message, ref Remote); //(收到的資料,來自哪個IP放進Remote) 不能放IPEndPoint 好像是它唯獨的關係 這時候sender已經變成跟remoteIP一樣
                    switch (message[0])
                    {
                        case 0:

                            break;
                        case 1:

                            break;
                        case 2:
                            if (myID == message[1])
                            {

                            }
                            else
                            {
                                imageViewhero2.SetX(widthment * (herox + message[3] - ncols));
                                imageViewhero2.SetY(heightment * (heroy - 1) + (heightment / 2f + message[4] - nrows));
                            }
                            break;
                        case 3:
                            myID = message[1];
                            break;
                        default:

                            break;
                    }
                    //Debug.WriteLine("伺服器來自 " + "[" + Remote.ToString() + "] : " + Encoding.UTF8.GetString(message, 0, recv)); //顯示資料前也要編碼一次 轉換回string資料格式
                }
                catch
                {

                }
            }*/
        }
    }
}