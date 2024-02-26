#region using
using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 地圖編輯器.方法.資料庫.初始化
{
    internal class Init
    {
    }
}
#endregion using
namespace mapMaker
{
    partial class Form1
    {
        /// <summary>
        /// 檢查是否有地圖檔，沒有就新增。
        /// </summary>
        private void InitDB()
        {
            // 檢查檔案是否存在。
            if (File.Exists(dbPath))
            {

            }

            // 不存在就建立一個。
            else
            {
                #region 啟動另一個執行緒以平行方式準備透明圖片
                byte[] byData = new byte[0];
                Task sk = Task.Run(() =>
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        Properties.Resources.透明.Save(ms, ImageFormat.Png);
                        byData = ms.ToArray();
                    }
                });
                #endregion 啟動另一個執行緒以平行方式準備透明圖片

                using (var cn = new SqliteConnection(cnStr))
                {

                    #region 建立新的空白資料庫
                    cn.Execute(@"

                        CREATE TABLE Picture 
                        (
                            pId                 INTEGER   PRIMARY KEY AUTOINCREMENT,
                            name                TEXT      UNIQUE      DEFAULT '',
                            binData             BLOB
                        );

                        CREATE TABLE Map 
                        (
                            mId                 INTEGER   PRIMARY KEY AUTOINCREMENT,
                            title               TEXT      UNIQUE      DEFAULT '',
                            Latitude1           REAL                  DEFAULT 0,
                            Latitude2           REAL                  DEFAULT 0,
                            Longitude1          REAL                  DEFAULT 0,
                            Longitude2          REAL                  DEFAULT 0,
                            Elevation           REAL                  DEFAULT 0,
                            thumbnail           BLOB
                        );

                        CREATE TABLE Grid 
                        (
                            col                 INTEGER,
                            row                 INTEGER,
                            background          INTEGER,
                            walk                INTEGER    DEFAULT 0,
                            gId                 INTEGER,
                            pId                 INTEGER,

                            PRIMARY KEY (col,row,background,gId),
                            FOREIGN KEY (pId) REFERENCES Picture(pId) ON DELETE CASCADE ON UPDATE CASCADE
                        );

                        CREATE TABLE MapToGrid 
                        (
                            mId                 INTEGER,
                            gId                 INTEGER,
                            sum                 INTEGER    DEFAULT 0,

                            PRIMARY KEY (mId,gId),
                            FOREIGN KEY (mId) REFERENCES Map(mId)     ON DELETE CASCADE ON UPDATE CASCADE/*,
                            FOREIGN KEY (gId) REFERENCES Grid(gId)    ON DELETE CASCADE ON UPDATE CASCADE*/
                        );

                        CREATE TABLE Teleport 
                        (
                            col                 INTEGER,
                            row                 INTEGER,
                            background          INTEGER    DEFAULT 1,
                            gId                 INTEGER,
                            teleport            INTEGER,
                            tId                 INTEGER,
                            mId                 INTEGER,

                            PRIMARY KEY (col,row,background,gId,teleport,tId,mId),/*
                            FOREIGN KEY (teleport) REFERENCES Teleport(tId),*/
                            FOREIGN KEY (mId) REFERENCES Map(mId)     ON DELETE CASCADE ON UPDATE CASCADE,
                            FOREIGN KEY (col,row,background,gId) REFERENCES Grid(col,row,background,gId) ON DELETE CASCADE ON UPDATE CASCADE
                        );

                        CREATE INDEX gId ON Grid (gId);
                        CREATE INDEX mId ON MapToGrid (mId);
                        CREATE INDEX tId ON Teleport (tId);");
                    #endregion 建立新的空白資料庫

                    /* walk 0 -> 不可行走
                     * walk 1 -> 可行走
                     * background 0 -> 前景
                     * background 1 -> 背景
                    */
                    #region 在資料庫新增一張透明的圖片
                    sk.Wait();
                    cn.Query("INSERT INTO Picture ([name],[binData]) VALUES (:name,:data)",
                                new { name = "透明", data = byData });
                    #endregion 在資料庫新增一張透明的圖片
                }
            }

        }
    }
}