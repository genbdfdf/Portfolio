#region using
using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using 函式庫.資料表;

namespace 地圖編輯器.方法.地圖.儲存.傳送點
{
    internal class Teleport
    {
    }
}
#endregion using
namespace mapMaker
{
    partial class Form1
    {
        /// <summary>
        /// 儲存地圖傳送點資料。
        /// </summary>
        /// <param name="cn">資料庫連線</param>
        /// <param name="gId">格子資料編號</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        private void SaveMapTeleportData(SqliteConnection cn, ushort gId, ushort mId)
        {
            string teleportqueryx = "SELECT * FROM Teleport WHERE [mId] = :mId";
            List<Teleport> teleportlist = cn.Query<Teleport>(teleportqueryx, new
            {
                mId = mId
            }).ToList();
            foreach (var item in teleports)
            {
                teleportqueryx = "Insert INTO Teleport ([col], [row], [gId], [teleport], [tId], [mId]) VALUES (:col, :row, :gId, :teleport, :tId, :mId)";
                foreach (var areaItem in teleportlist)
                {
                    if (item.Equals(areaItem))
                    {
                        teleportqueryx = "UPDATE Teleport SET teleport = :teleport WHERE [tId] = :tId";
                        break;
                    }
                }
                cn.Query(teleportqueryx, new
                {
                    col = item.col,
                    row = item.row,
                    gId = gId,
                    teleport = item.teleport,
                    tId = item.tId,
                    mId = mId
                });
            }
        }
    }
}