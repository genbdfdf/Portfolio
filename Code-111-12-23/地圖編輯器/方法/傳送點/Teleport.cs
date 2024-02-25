#region using
using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 函式庫.資料表;

namespace 地圖編輯器.方法.傳送點
{
    internal class Teleport
    {
    }
}
#endregion
namespace mapMaker
{
    partial class Form1
    {
        private void ShowTeleportList()
        {
            var tempMaps = new List<Map>();
            Task sk = Task.Run(() =>
            {
                using (var cn = new SqliteConnection(cnStr))
                {
                    string querystr = "SELECT * FROM Teleport/* WHERE mId <> :mId*/";
                    dataBaseTeleports = cn.Query<Teleport>(querystr, new
                    {
                        mId = mId
                    }).ToList();
                }
                dataBaseTeleports.Sort();
            });
            Task sk2 = Task.Run(() =>
            {
                using (var cn = new SqliteConnection(cnStr))
                {
                    string querystr = "SELECT * FROM Map";
                    tempMaps = cn.Query<Map>(querystr).ToList();
                }
                tempMaps.Sort();
            });
            comboBox_newtpLoction.Text = "";
            comboBox_tpLoction.Text = "";
            comboBox_tpLoction.Items.Clear();
            comboBox_newtpLoction.Items.Clear();
            sk.Wait();
            sk2.Wait();
            var vs = new List<string>();
            foreach (var item in dataBaseTeleports)
            {
                if (item.teleport > 0 && item.mId != mId)
                {
                    Map targetMap = tempMaps[item.mId - 1];
                    bool same = false;
                    string text = targetMap.title + " X:" + (item.col + 1) + " Y:" + (item.row + 1);
                    foreach (var itemx in vs)
                    {
                        if (text.Equals(itemx.ToString()))
                        {
                            same = true;
                            continue;
                        }
                    }
                    if (same) continue;
                    vs.Add(text);
                    comboBox_newtpLoction.Items.Add(text);
                }
            }
            foreach (var item in teleports)
            {
                if (item.col == editGrid.X1 - 1 && item.row == editGrid.Y1 - 1 && item.teleport > 0)
                {
                    Teleport targetTeleport = dataBaseTeleports[item.teleport - 1];
                    if (targetTeleport.tId == item.teleport) { }
                    else
                        foreach (var itemX in dataBaseTeleports)
                            if (itemX.tId == item.teleport) targetTeleport = item;
                    Map targetMap = tempMaps[targetTeleport.mId - 1];
                    string text = targetMap.title + " X:" + (targetTeleport.col + 1) + " Y:" + (targetTeleport.row + 1);
                    comboBox_tpLoction.Items.Add(text);
                }
            }
            foreach (var item in comboBox_tpLoction.Items)
            {
                if(comboBox_newtpLoction.Items.Contains(item))
                {
                    comboBox_newtpLoction.Items.Remove(item);
                }
            }
            container.Refresh();
        }

        private ushort[] GetTeleportListContent(string target, bool isDelete)
        {
            string mapName = target.Split(' ')[0];
            ushort mId = 0;
            var col = Convert.ToInt16(target.Split(' ')[1].Substring(2)) - 1;
            var row = Convert.ToInt16(target.Split(' ')[2].Substring(2)) - 1;
            var result = new List<ushort>();
            var tempMaps = new List<Map>();
            var tempTeleports = new List<Teleport>();
            using (var cn = new SqliteConnection(cnStr))
            {
                string querystr = "SELECT [mId] FROM Map WHERE [title] = :title";
                tempMaps = cn.Query<Map>(querystr, new
                {
                    title = mapName
                }).ToList();
            }
            foreach (var item in tempMaps)
            {
                mId = item.mId;
            }
            using (var cn = new SqliteConnection(cnStr))
            {
                string teleportquery = "SELECT [tId] FROM [Teleport] WHERE [mId] = :mId AND [col] = :col AND [row] = :row";
                tempTeleports = cn.Query<Teleport>(teleportquery, new
                {
                    mId = mId,
                    col = col,
                    row = row
                }).ToList();
            }
            foreach (var itemx in tempTeleports)
            {
                ushort tId = itemx.tId;
                result.Add(tId);
            }
            if (isDelete)
            {
                result.Clear();
                foreach (var itemx in tempTeleports)
                {
                    ushort tId = itemx.tId;
                    foreach (var item in teleports)
                    {
                        if (item.col == editGrid.X1 - 1 & item.row == editGrid.Y1 - 1 && item.teleport == tId)
                        {
                            tId = item.tId;
                            result.Add(tId);
                            break;
                        }
                    }
                }
                
            }
            
            
            return result.ToArray();
        }
    }
}