#region using
using Dapper;
using Microsoft.Data.Sqlite;
using SharpDX.Direct2D1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using 函式庫.資料表;

namespace 地圖編輯器.方法.圖片.讀取
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
        /// <summary>
        /// 讀取圖片。
        /// </summary>
        private void read_Image()
        {
            #region 啟動進度列
            short[] nowDoing = new short[4];
            ProgressBarVaultStartCount();
            Task.Run(() =>
            {
                while (toolStripProgressBar1.Visible)
                {
                    toolStripProgressBar1.Value = nowDoing[0] + nowDoing[1] + nowDoing[2] + nowDoing[3];
                    try
                    {
                        toolStripLb_per.Text = Convert.ToInt16(toolStripProgressBar1.Value * 100.0 / toolStripProgressBar1.Maximum) + "%";
                    }
                    catch
                    {

                    }
                    Thread.Sleep(10);
                }
            });
            #endregion 啟動進度列

            #region 讀取圖片到顯示記憶體上
            Task sk = Task.Run(() =>
            {
                using (var cn = new SqliteConnection(cnStr))
                {
                    string querystr = "SELECT [name],[binData] FROM Picture";
                    List<Picture> dbImage = cn.Query<Picture>(querystr).ToList();
                    pic = new Bitmap[dbImage.Count];
                    toolStripProgressBar1.Maximum = dbImage.Count * 2;
                    Task skk = Task.Run(() =>
                    {
                        Read(0, (ushort)(dbImage.Count / 3), 0);
                    });
                    Task skk2 = Task.Run(() =>
                    {
                        Read((ushort)(dbImage.Count / 3), (ushort)(dbImage.Count / 3 * 2), 1);
                    });
                    Read((ushort)(dbImage.Count / 3 * 2), (ushort)dbImage.Count, 2);
                    skk.Wait();
                    skk2.Wait();

                    void Read(ushort start, ushort end, ushort id)
                    {
                        MemoryStream stream;
                        for (ushort k = start; k < end; k++)
                        {
                            stream = new MemoryStream(dbImage[k].GetbinData());
                            pic[k] = LoadFromFile(views, (System.Drawing.Bitmap)System.Drawing.Image.FromStream(stream));
                            nowDoing[id]++;
                        }
                    }
                }
            });
            #endregion 讀取圖片到顯示記憶體上

            #region 進入讀取模式
            drawBack = false;
            drawFore = false;
            drawWalk = false;
            drawTeleport = false;
            drawRectangle = false;
            drawMapBorder = false;
            tb_mapArea.Visible = true;
            tb_lv_imageloading.Visible = true;
            iml_png.Images.Clear();
            iml_png.ColorDepth = ColorDepth.Depth32Bit;

            lv_image.Items.Clear();
            lv_image.View = View.LargeIcon;
            lv_image.LargeImageList = iml_bmp;
            lv_image.BeginUpdate();
            #endregion 進入讀取模式

            #region 讀取圖片到 lv_image
            Task sk2 = Task.Run(() =>
            {
                if (false)
                using (var cn = new SqliteConnection(cnStr))
                {
                    string querystr = "SELECT [pId],[name],[binData] FROM Picture";
                    List<Picture> dbImage = cn.Query<Picture>(querystr).ToList();
                    System.Drawing.Image image;
                    foreach (var item in dbImage)
                    {
                        MemoryStream stream = new MemoryStream(item.GetbinData());
                        image = System.Drawing.Image.FromStream(stream);
                        iml_png.Images.Add(image);
                        ListViewItem lvi = new ListViewItem
                        {
                            ImageIndex = item.GetpId() - 1,
                            Text = item.Getname()
                        };
                        lv_image.Items.Add(lvi);
                        nowDoing[3]++;
                    }
                    lv_image.LargeImageList = iml_png;
                }
            });
            #endregion 讀取圖片到 lv_image

            // 等待前二者皆讀取完成在往下執行。
            sk.Wait();

            #region 計算圖片色彩平均值，影像辨識用
            _task = Task.Run(() =>
            {
                using (var cn = new SqliteConnection(cnStr))
                {
                    string querystr = "SELECT [pId],[name],[binData] FROM Picture";
                    List<Picture> dbImage = cn.Query<Picture>(querystr).ToList();
                    MemoryStream stream;
                    bitPixelAvg = new StringBuilder[dbImage.Count];
                    for (short l = 0; l < dbImage.Count; l++)
                    {
                        stream = new MemoryStream(dbImage[l].GetbinData());
                        System.Drawing.Bitmap bitmap = (System.Drawing.Bitmap)System.Drawing.Image.FromStream(stream);
                        ushort wx, hx;
                        System.Drawing.Size size = bitmap.Size;
                        bitPixelAvg[l] = new StringBuilder();
                        for (short i = 0; i < size.Width; i += 4)
                        {
                            wx = 4;
                            if (i + 3 > size.Width)
                            {
                                wx = (ushort)(size.Width - i);
                            }
                            for (short j = 0; j < size.Height; j += 4)
                            {
                                hx = 4;
                                if (j + 3 > size.Height)
                                {
                                    hx = (ushort)(size.Height - j);
                                }
                                int r = 0;
                                for (short ii = 0; ii < wx; ii++)
                                {
                                    for (short jj = 0; jj < hx; jj++)
                                    {
                                        r += bitmap.GetPixel(i + ii, j + jj).ToArgb();
                                    }
                                }
                                bitPixelAvg[l].Append(r / wx / hx + "|");
                            }
                        }
                    }
                }
            });
            #endregion 計算圖片色彩平均值，影像辨識用

            sk2.Wait();
            
            #region 嘗試把圖片檔名的座標直接映射到地圖上
            if(true)
            _task2 = Task.Run(() =>
            {
                short row, col;

                void asdgd(ushort len)
                {
                    for (ushort i = 0; i < len; i++)
                    {
                        try
                        {
                            mapBackPic[sameImgRow_t1[i], sameImgCol_t1[i]] = sameImgpId_t1[i];
                            mapBackPic[sameImgRow_t2[i], sameImgCol_t2[i]] = sameImgpId_t2[i];
                            mapBackPic[sameImgRow_t3[i], sameImgCol_t3[i]] = sameImgpId_t3[i];
                        }
                        catch
                        {

                        }
                    }
                }
                void asdgd2(ushort len)
                {
                    for (ushort i = 0; i < len; i++)
                    {
                        try
                        {
                            mapBackPic[sameImgRow1t1[i], sameImgCol1t1[i]] = mapBackPic[sameImgRow2t1[i], sameImgCol2t1[i]];
                            mapBackPic[sameImgRow1t2[i], sameImgCol1t2[i]] = mapBackPic[sameImgRow2t2[i], sameImgCol2t2[i]];
                            mapBackPic[sameImgRow1t3[i], sameImgCol1t3[i]] = mapBackPic[sameImgRow2t3[i], sameImgCol2t3[i]];
                        }
                        catch
                        {

                        }
                    }
                }
                for (short i = 0; i < 3; i++)
                {
                    asdgd(sameImgLen[i]);
                }
                for (short i = 3; i < 6; i++)
                {
                    asdgd2(sameImgLen[i]);
                }
                sameImgRow_t1 = null;
                sameImgCol_t1 = null;
                sameImgpId_t1 = null;
                sameImgRow_t2 = null;
                sameImgCol_t2 = null;
                sameImgpId_t2 = null;
                sameImgRow_t3 = null;
                sameImgCol_t3 = null;
                sameImgpId_t3 = null;
                sameImgRow1t1 = null;
                sameImgCol1t1 = null;
                sameImgRow2t1 = null;
                sameImgCol2t1 = null;
                sameImgRow1t2 = null;
                sameImgCol1t2 = null;
                sameImgRow2t2 = null;
                sameImgCol2t2 = null;
                sameImgRow1t3 = null;
                sameImgCol1t3 = null;
                sameImgRow2t3 = null;
                sameImgCol2t3 = null;/*
                for (short i = 0; i < lv_image.Items.Count; i++)
                {
                    try
                    {
                        if(lv_image.Items[i].Text.Split('_')[0].Equals(nowEditMapName))
                        {
                            string location = lv_image.Items[i].Text.Split('_')[1];
                            string[] lo2 = location.Split('Z');
                            row = Convert.ToInt16(lo2[0]);
                            col = Convert.ToInt16(lo2[1]);
                            mapBackPic[col, row] = (ushort)i;
                        }
                    }
                    catch
                    {

                    }
                }*/
            });
            #endregion 嘗試把圖片檔名的座標直接映射到地圖上
            
            #region 讀取的收尾
            try
            {
                //lv_image.Items[0].Selected = true;
                //lv_image.Items[0].Focused = true;

                _task.Wait();
                _task2.Wait();

                tb_map.Text = nowEditMapName;

                ShowSuccessMSG("目前沒有任何消息與問題");

                //ReadMap(false);
            }
            catch
            {
                ShowWarningMSG("資料庫中沒有圖片");
            }

            if (背景ToolStripMenuItem.Checked)
            {
                drawBack = true;
            }
            if (前景ToolStripMenuItem.Checked)
            {
                drawFore = true;
            }
            if (能否行走ToolStripMenuItem.Checked)
            {
                drawWalk = true;
            }
            if (傳送點ToolStripMenuItem.Checked)
            {
                drawTeleport = true;
            }
            if (框線ToolStripMenuItem.Checked)
            {
                drawRectangle = true;
            }
            if (地圖邊界ToolStripMenuItem.Checked)
            {
                drawMapBorder = true;
            }
            if (!initted)
            {
                initted = true;
                container.Paint += new PaintEventHandler(container_Paint);
            }
            lv_image.EndUpdate();
            tb_lv_imageloading.Visible = false;
            tb_mapArea.Visible = false;

            ProgressBarVaultEndCount();
            #endregion 讀取的收尾
        }
    }
}