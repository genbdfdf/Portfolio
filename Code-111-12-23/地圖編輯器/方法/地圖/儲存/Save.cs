#region using
using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 函式庫.資料表;

namespace 地圖編輯器.方法.地圖.儲存
{
    internal class Save
    {
    }
}
#endregion using
namespace mapMaker
{
    partial class Form1
    {
        private void save_Click(object sender, EventArgs e)
        {
            if (tb_map.Text.Length == 0)
                MessageBox.Show("地圖名稱沒打");
            else
                Task.Run(() => SaveMap());
        }
        private void SaveMap()
        {
            try
            {
                using (var cn = new SqliteConnection(cnStr))
                {
                    bool canSave = true;
                    bool samegId = false;
                    bool sameSave = false;
                    ushort samegIdNum = 0;
                    ushort walk = 0;
                    ushort mId = 0;
                    ushort gId = 0;
                    uint sum = 0;
                    uint[] sumT = new uint[2];
                    string map = @"INSERT INTO Map ([mId],[title]) 
                                   VALUES (:mId, :title)";

                    string gridFore = @"INSERT INTO Grid ([col],[row],[background],[gId],[pId]) 
                                            VALUES (:col,:row,:background,:gId,:pId)";

                    string gridBack = @"INSERT INTO Grid ([col],[row],[background],[walk],[gId],[pId]) 
                                            VALUES (:col,:row,:background,:walk,:gId,:pId)";
                    
                    string mapToGrid = @"INSERT INTO MapToGrid ([mId],[gId],[sum]) 
                                            VALUES (:mId,:gId,:sum)";
                    
                    // 檢查格子總和值來判斷資料庫中有沒有一模一樣的，若有就不必重複儲存。
                    Task sk = Task.Run(() =>
                    {
                        for (int x = 0; x < col; x++)
                        {
                            for (int y = 0; y < row; y++)
                            {
                                sumT[0] += mapBackPic[x, y];
                            }
                        }
                    });
                    Task sk2 = Task.Run(() =>
                    {
                        for (int x = 0; x < col; x++)
                        {
                            for (int y = 0; y < row; y++)
                            {
                                sumT[1] += mapForePic[x, y];
                            }
                        }
                    });

                    // 確定地圖編號。
                    string mIdquery = "SELECT MAX([mId]) as mId FROM [Map]";
                    List<Map> maps = cn.Query<Map>(mIdquery).ToList();
                    foreach (var item in maps)
                    {
                        mId = (ushort)(item.mId + 1);
                    }

                    // 檢查是否有同名的地圖。
                    string titlequery = "SELECT [mId] FROM [Map] WHERE title = :title";
                    List<Map> title = cn.Query<Map>(titlequery, new { title = tb_map.Text }).ToList();
                    if (title.Count > 0)
                    {
                        if (donotAlertOverrideMap) 
                            Run();
                        else
                        {
                            if (MessageBox.Show("已有同樣名稱之地圖，是否要覆蓋？", "發現同名地圖", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                Run();
                            else
                                canSave = false;
                        }
                        void Run()
                        {
                            sameSave = true;
                            foreach (var item in title)
                            {
                                mId = item.mId;
                            }
                            map = @"UPDATE Map SET [title] = :title 
                                      WHERE [mId] = :mId";
                            mapToGrid = @"UPDATE MapToGrid SET [gId] = :gId, [sum] = :sum 
                                            WHERE [mId] = :mId";
                            gridFore = @"UPDATE Grid SET [pId] = :pId 
                                                WHERE [gId] = :gId AND [background] = :background AND [col] = :col AND [row] = :row";

                            gridBack = @"UPDATE Grid SET [pId] = :pId, [walk] = :walk 
                                                WHERE [gId] = :gId AND [background] = :background AND [col] = :col AND [row] = :row";
                        }
                    }
                    if(canSave)
                    {
                        sk.Wait();
                        sk2.Wait();
                        sum += sumT[0] + sumT[1];

                        // 取得格子總和值來判斷有沒有重複。
                        string sumquery = "SELECT [mId], [gId], [sum] FROM [MapToGrid]";
                        List<MapToGrid> gridsum = cn.Query<MapToGrid>(sumquery).ToList();
                        foreach (var item in gridsum)
                        {
                            if (sum == item.Getsum())
                            {
                                samegId = true;
                                gId = item.GetgId();
                            }
                        }
                        if (!samegId)
                        {
                            string gIdquery = "SELECT [gId] FROM [MapToGrid] WHERE [mId] = :mId";
                            List<MapToGrid> gIdsum = cn.Query<MapToGrid>(gIdquery, new { mId = mId }).ToList();
                            foreach (var item in gIdsum)
                            {
                                gId = item.GetgId();
                            }
                            foreach (var item in gridsum)
                            {
                                if (item.GetgId() == gId)
                                {
                                    samegIdNum++;
                                }
                            }
                            if (samegIdNum > 1 && !allSave)
                            {
                                sameSave = false;
                                gridFore = @"INSERT INTO Grid ([col],[row],[background],[gId],[pId]) 
                                            VALUES (:col,:row,:background,:gId,:pId)";

                                gridBack = @"INSERT INTO Grid ([col],[row],[background],[walk],[gId],[pId]) 
                                            VALUES (:col,:row,:background,:walk,:gId,:pId)";
                            }
                            if (!sameSave)
                            {
                                string maxgIdquery = "SELECT MAX([gId]) as maxgId FROM [MapToGrid]";
                                List<MapToGrid> maxgIdsum = cn.Query<MapToGrid>(maxgIdquery).ToList();
                                foreach (var item in maxgIdsum)
                                {
                                    gId = (ushort)(item.GetmaxgId() + 1);
                                }
                            }
                        }
                        ShowMSG("儲存中．．．");

                        // 啟動SQL交易。
                        cn.Open();
                        var transaction = cn.BeginTransaction();

                        #region 刪除多餘的資料
                        /*
                        string delgrid = "DELETE FROM Grid WHERE col > :col AND row > :row";
                        cn.Query(delgrid, new
                        {
                            col = col,
                            row = row,
                        });*/
                        #endregion 刪除多餘的資料


                            SaveMapForeData(cn, gridFore, gId);

                            SaveMapBackData(cn, gridBack, gId, walk);
                        if (!samegId)
                        {

                        }

                        SaveMapMetaData(cn, map, mId);

                        SaveMapTeleportData(cn, gId, mId);

                        SaveMapToGridMetaData(cn, mapToGrid, mId, gId, sum);

                        // 結束SQL交易。
                        transaction.Commit();
                        ShowSuccessMSG("儲存成功！", true);
                        lb_mapName.Text = $"地圖編輯區　({tb_map.Text})";
                    }
                }
            }
            catch (Exception se)
            {
                MessageBox.Show(se + "");
                ShowErrorMSG(se.Message);
            }
        }
    }
}