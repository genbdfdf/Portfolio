#region using
using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 函式庫.資料表;

namespace 地圖編輯器.方法.地圖.讀取
{
    internal class Read
    {
    }
}
#endregion using
namespace mapMaker
{
    partial class Form1
    {
        private void bt_importMapInfo_Click(object sender, EventArgs e)
        {
            if (lv_map.Visible)
            {
                lv_map.Visible = false;
                lb_imageorMap.Text = "圖片素材";
            }
            else
            {
                ShowMapToListView();
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        private void ShowMapToListView()
        {
            using (var cn = new SqliteConnection(cnStr))
            {
                string mapquery = "SELECT [mId],[title] FROM [Map]";
                List<Map> map = cn.Query<Map>(mapquery).ToList();
                tb_lv_imageloading.Visible = true;
                iml_map.Images.Clear();
                iml_map.ColorDepth = ColorDepth.Depth32Bit;

                lv_map.Items.Clear();
                lv_map.SmallImageList = iml_map;
                lv_map.View = View.SmallIcon;

                ListViewItem lviBack = new ListViewItem();
                lviBack.ImageIndex = 0;
                lviBack.Text = "返回";
                iml_map.Images.Add(Properties.Resources.icons8_reply_arrow_100);
                lv_map.Items.Add(lviBack);
                Map[] map1 = new Map[map.Count];
                foreach (var item in map)
                {
                    map1[item.mId - 1] = item;
                }
                foreach (var item in map1)
                {
                    //MemoryStream stream = new MemoryStream(item.GetbinData());
                    //Image image = Image.FromStream(stream);
                    //iml_map.Images.Add(image);
                    ListViewItem lvi = new ListViewItem();
                    lvi.ImageIndex = item.mId;
                    lvi.Text = item.title;
                    lv_map.Items.Add(lvi);
                }
                lv_map.Visible = true;
                tb_lv_imageloading.Visible = false;
                lb_imageorMap.Text = "選擇地圖";
            }
        }
        private void ReadMap(bool show)
        {
            if (show)
            {
                tb_lv_imageloading.Visible = true;
            }
            Task.Run(() =>
            {
                ushort mId;
                if (show)
                {
                    mId = (ushort)lv_map.SelectedItems[0].Index;
                }
                else
                {
                    mId = 1;
                }
                if (mId > 0)
                {
                    this.mId = mId;
                    for (int i = 0; i < 300; i++)
                        for (int j = 0; j < 300; j++)
                        {
                            mapForePic[i, j] = 0;
                            mapBackPic[i, j] = 0;
                        }

                    using (var cn = new SqliteConnection(cnStr))
                    {
                        #region 讀取地圖資料

                        string mapquery = "SELECT [title],[thumbnail] FROM [Map] WHERE mId = :mId";
                        List<Map> map = cn.Query<Map>(mapquery, new
                        {
                            mId = mId
                        }).ToList();

                        foreach (var item in map)
                        {
                            tb_map.Text = item.title;
                            lb_mapName.Text = $"地圖編輯區　({item.title})";
                            nowEditMapName = item.title;
                        }
                        #endregion 讀取地圖資料

                        #region 讀取地圖對應格子的資料
                        string maptogridquery = "SELECT [gId] FROM [MapToGrid] WHERE mId = :mId";
                        List<MapToGrid> mapToGrids = cn.Query<MapToGrid>(maptogridquery, new
                        {
                            mId = mId
                        }).ToList();
                        foreach (MapToGrid item in mapToGrids)
                        {
                            gId = item.gId;
                        }
                        #endregion 讀取地圖對應格子的資料

                        #region 讀取地圖最大格數

                        string gridMaxNumquery = "SELECT MAX([col]) AS col, MAX([row]) AS row FROM [Grid] WHERE gId = :gId";
                        List<Grid> gridMaxNum = cn.Query<Grid>(gridMaxNumquery, new
                        {
                            gId = gId
                        }).ToList();
                        foreach (var item in gridMaxNum)
                        {
                            tb_col.Text = "" + (item.col + 1);
                            tb_row.Text = "" + (item.row + 1);
                        }
                        tryparse();
                        #endregion 讀取地圖最大格數

                        #region 讀取格子資料
                        string gridquery = "SELECT [col],[row],[background],[walk],[pId] FROM [Grid] WHERE gId = :gId";
                        List<Grid> grid = cn.Query<Grid>(gridquery, new
                        {
                            gId = gId
                        }).ToList();

                        foreach (var item in grid)
                        {
                            ushort col = item.col;
                            ushort row = item.row;
                            ushort pId = (ushort)(item.pId - 1);

                            // 前景。
                            if (item.background == 0)
                            {
                                mapForePic[col, row] = pId;
                            }

                            // 背景。
                            else
                            {
                                mapBackPic[col, row] = pId;
                                mapBackWalk[col, row] = item.walk;
                            }
                        }
                        #endregion 讀取格子資料

                        #region 讀取傳送點資料
                        // 先清空。
                        teleports.Clear();

                        string teleportquery = "SELECT * FROM [Teleport] WHERE [mId] = :mId";
                        teleports = cn.Query<Teleport>(teleportquery, new
                        {
                            mId = mId
                        }).ToList();
                        teleports.Sort();
                        string maxtIdquery = "SELECT MAX([tId]) AS tId FROM [Teleport]";
                        var teleport = cn.Query<Teleport>(maxtIdquery).ToList();
                        foreach (var item in teleport)
                        {
                            maxtId = item.tId;
                        }
                        ShowTeleportList();
                        #endregion 讀取傳送點資料
                    }
                    #region 重設一些設定

                    editMode = false;

                    #endregion 重設一些設定
                }
                if (show)
                {
                    tb_lv_imageloading.Visible = false;
                }
                container.Refresh();
            });

            lv_map.Visible = false;
            lb_imageorMap.Text = "圖片素材";
        }
        private void lv_map_MouseClick(object sender, MouseEventArgs e)
        {
            ReadMap(true);
        }

        private void lv_map_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && lv_map.SelectedItems[0].Index > -1)
                {
                    ReadMap(true);
                }
            }
            catch
            {

            }
        }
    }
}