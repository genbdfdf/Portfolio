#region using
using RD = SharpDX;
using RD2 = SharpDX.Direct2D1;
using RDM = SharpDX.Mathematics.Interop;
using RDW = SharpDX.DirectWrite;
using RDX = SharpDX.DXGI;
using RD2E = SharpDX.Direct2D1.Effects;
using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Threading;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Collections;
using Microsoft.Data.Sqlite;
using 函式庫.事件;
using 函式庫.資料表;
#endregion using

namespace mapMaker
{
    public partial class Form1 : Form
    {
        #region 建構式
        public Form1()
        {
            InitDB();
            InitializeComponent();

            startListen();
            lv_image.AllowDrop = true;
            //control.BackColor = Color.FromArgb(255, 255 - control.ForeColor.R, 255 - control.ForeColor.G, 255 - control.ForeColor.B);
            
            #region 初始化地圖編輯區。
            RD2.PixelFormat D2PF = new RD2.PixelFormat();
            RD2.Factory FY = new RD2.Factory(RD2.FactoryType.MultiThreaded);
            RD2.RenderTargetProperties renderProps = new RD2.RenderTargetProperties
            {
                PixelFormat = D2PF,
                Usage = RD2.RenderTargetUsage.None,
                Type = RD2.RenderTargetType.Default
            };
            RD2.HwndRenderTargetProperties hwndProps = new RD2.HwndRenderTargetProperties()
            {
                Hwnd = container.Handle,
                PixelSize = new RD.Size2(container.Width, tb_mapArea.Height),
                PresentOptions = RD2.PresentOptions.None
            };
            views = new RD2.WindowRenderTarget(FY, renderProps, hwndProps)
            {
                AntialiasMode = RD2.AntialiasMode.PerPrimitive
            };
            #endregion 初始化地圖編輯區。

            #region 讀取不能行走與傳送點的標示。
            Task.Run(() =>
            {
                cannotWalk = LoadFromFile(views, Properties.Resources.cannotwalk);
                lb_gridSetting.Visible = false;
                lb_mapSetting.Visible = false;
                teleportPic[0] = LoadFromFile(views, Properties.Resources.teleport);
                teleportPic[1] = LoadFromFile(views, Properties.Resources.selectedteleport);
            });
            #endregion 讀取不能行走與傳送點的標示。

            Task.Run(() =>
            {
                CheckForIllegalCrossThreadCalls = false;

                #region 多執行緒註冊事件

                this.選擇檔案ToolStripMenuItem.Click += new System.EventHandler(this.bt_importimagefile_Click);

                this.選擇資料夾ToolStripMenuItem.Click += new System.EventHandler(this.bt_importimage_Click);

                this.bt_readMap.Click += new System.EventHandler(this.bt_importMapInfo_Click);

                this.bt_saveMap.Click += new System.EventHandler(this.save_Click);

                this.框線ToolStripMenuItem.CheckedChanged += new System.EventHandler(this.框線ToolStripMenuItem_CheckedChanged);

                this.前景ToolStripMenuItem.CheckedChanged += new System.EventHandler(this.前景ToolStripMenuItem_CheckedChanged);

                this.背景ToolStripMenuItem.CheckedChanged += new System.EventHandler(this.背景ToolStripMenuItem_CheckedChanged);

                this.傳送點ToolStripMenuItem.CheckedChanged += new System.EventHandler(this.傳送點ToolStripMenuItem_CheckedChanged);

                this.能否行走ToolStripMenuItem.CheckedChanged += new System.EventHandler(this.能否行走ToolStripMenuItem_CheckedChanged);

                this.地圖邊界ToolStripMenuItem.CheckedChanged += new System.EventHandler(this.地圖邊界ToolStripMenuItem_CheckedChanged);

                this.tb_size.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tb_size_MouseDown);
                this.tb_size.TextChanged += new System.EventHandler(this.tb_size_TextChanged);

                this.bt_sizeUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bt_change_size_Click);

                this.bt_sizeDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bt_change_size_Click);

                this.rb_useBack.CheckedChanged += new System.EventHandler(this.rb_useBack_CheckedChanged);

                this.rb_useFore.CheckedChanged += new System.EventHandler(this.rb_useFore_CheckedChanged);

                this.lv_map.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lv_map_KeyDown);
                this.lv_map.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lv_map_MouseClick);

                this.bt_colUp.Click += new System.EventHandler(this.bt_colUp_Click);

                this.bt_colDown.Click += new System.EventHandler(this.bt_colDown_Click);

                this.bt_rowUp.Click += new System.EventHandler(this.bt_rowUp_Click);

                this.bt_rowDown.Click += new System.EventHandler(this.bt_rowDown_Click);

                this.bt_widthUp.Click += new System.EventHandler(this.bt_widthUp_Click);

                this.bt_widthDown.Click += new System.EventHandler(this.bt_widthDown_Click);

                this.bt_heightUp.Click += new System.EventHandler(this.bt_heightUp_Click);

                this.bt_heightDown.Click += new System.EventHandler(this.bt_heightDown_Click);

                this.tb_col.TextChanged += new System.EventHandler(this.tb_col_TextChanged);

                this.tb_row.TextChanged += new System.EventHandler(this.tb_row_TextChanged);

                this.tb_height.TextChanged += new System.EventHandler(this.tb_pdh_TextChanged);

                this.tb_width.TextChanged += new System.EventHandler(this.tb_pdw_TextChanged);

                this.bt_gridSetting.Click += new System.EventHandler(this.bt_gridSetting_Click);

                this.bt_mapSetting.Click += new System.EventHandler(this.bt_mapSetting_Click);

                this.lv_image.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lv_image_AfterLabelEdit);
                this.lv_image.BeforeLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lv_image_BeforeLabelEdit);
                this.lv_image.DragDrop += new System.Windows.Forms.DragEventHandler(this.lv_image_DragDrop);
                this.lv_image.DragEnter += new System.Windows.Forms.DragEventHandler(this.lv_image_DragEnter);

                this.container.MouseDown += new System.Windows.Forms.MouseEventHandler(this.container_MouseDown);
                this.container.MouseMove += new System.Windows.Forms.MouseEventHandler(this.container_MouseMove);
                this.container.MouseUp += new System.Windows.Forms.MouseEventHandler(this.container_MouseUp);

                container.MouseWheel += new MouseEventHandler(tb_size_MouseWheel);
                bt_sizeDown.MouseWheel += new MouseEventHandler(tb_size_MouseWheel);
                bt_sizeUp.MouseWheel += new MouseEventHandler(tb_size_MouseWheel);

                tb_col.MouseWheel += new MouseEventHandler(bt_col_MouseWheel);
                bt_colUp.MouseWheel += new MouseEventHandler(bt_col_MouseWheel);
                bt_colDown.MouseWheel += new MouseEventHandler(bt_col_MouseWheel);

                tb_row.MouseWheel += new MouseEventHandler(bt_row_MouseWheel);
                bt_rowUp.MouseWheel += new MouseEventHandler(bt_row_MouseWheel);
                bt_rowDown.MouseWheel += new MouseEventHandler(bt_row_MouseWheel);

                tb_width.MouseWheel += new MouseEventHandler(bt_width_MouseWheel);
                bt_widthUp.MouseWheel += new MouseEventHandler(bt_width_MouseWheel);
                bt_widthDown.MouseWheel += new MouseEventHandler(bt_width_MouseWheel);

                tb_height.MouseWheel += new MouseEventHandler(bt_height_MouseWheel);
                bt_heightUp.MouseWheel += new MouseEventHandler(bt_height_MouseWheel);
                bt_heightDown.MouseWheel += new MouseEventHandler(bt_height_MouseWheel);

                #endregion 多執行緒註冊事件

                #region 初始化 欄、寬、列、高與地圖陣列。
                col = Convert.ToUInt16(tb_col.Text);
                row = Convert.ToUInt16(tb_row.Text);
                width = Convert.ToUInt16(tb_width.Text);
                height = Convert.ToUInt16(tb_height.Text);

                Task.Run(mapCreate);

                p_col = m_col = (short)col;
                p_row = m_row = (short)row;
                #endregion 初始化 欄、寬、列、高與地圖陣列。

                #region 初始化地圖編輯區大小。
                Graphics graphics = CreateGraphics();
                switch (graphics.DpiX)
                {
                    case 120:
                        dpi = 100.0f / 125.0f;
                        dpiF.X = 1.1f;
                        dpiF.Y = 1.3f;
                        break;
                    case 144:
                        dpi = 100.0f / 150.0f;
                        break;
                    case 168:
                        dpi = 100.0f / 175.0f;
                        break;
                    case 192:
                        dpi = 100.0f / 200.0f;
                        break;
                    default:
                        dpi = 1;
                        dpiF.X = 1;
                        dpiF.Y = 1;
                        break;
                }
                container.Size = tb_mapArea.Size;
                container.Location = tb_mapArea.Location;
                #endregion 初始化地圖編輯區大小。

                #region 初始化表單縮放。
                x = Width;
                y = Height;
                setTag(this);
                #endregion 初始化表單縮放。

                #region 初始化標題、版本號、修改日期。
                string myself = Assembly.GetExecutingAssembly().Location;
                string date = File.GetLastWriteTime(myself).ToString("yyyy/MM/dd");
                /*string nowPath = Directory.GetCurrentDirectory();
                string rootPath = Path.GetFullPath(nowPath + "/../../../../..");
                string version = "";
                try
                {
                    short len = (short)(rootPath.Length - 1);
                    version = rootPath.Substring(len, 1);
                }
                catch
                {
                    version = FileVersionInfo.GetVersionInfo(myself).FileVersion.Substring(0, 1);
                }
                Text = $"地圖編輯器 v{version} - {date}";*/
                Text = $"地圖編輯器 v2 - {date}";
                #endregion 初始化標題、版本號、修改日期。


                //開程式自動載入圖片素材與第一張地圖。
                read_Image();
                try
                {
                    List<string> path = new List<string>();
                    using (StreamReader sr = new StreamReader("status"))
                    {
                        if (Convert.ToInt32(sr.ReadLine()) == 1)
                        {
                            using (StreamReader sr2 = new StreamReader("list"))
                            {
                                while (!sr2.EndOfStream)
                                    path.Add(sr2.ReadLine());
                            }
                            Task.Run(() => InitImport(path.ToArray()));

                        }
                    }
                }
                catch { }
            });
        }
        #endregion 建構式

        #region 繪製地圖
        /// <summary>
        /// 繪製地圖(合成用)
        /// </summary>
        private void update2()
        {
            /*try
            {

                for (short j = 0; j < allcount; j++)
                {
                    if (((Label)pllist[2].Controls.Find("lb_" + j, true)[0]).Text == "_|1" || ((Label)pllist[2].Controls.Find("lb_" + j, true)[0]).Text == "")
                    {
                    }
                    else
                    {
                        if (((Label)pllist[2].Controls.Find("lb_" + j, true)[0]).Text.Contains("-1"))
                        {
                            //ddm1 | -1 > l | m000
                            //ddz1|-1>l[m0000、m0002]>h[m0001、m0003]
                            if (folderDirPath != null)
                            {
                                short position2 = ((Label)pllist[2].Controls.Find("lb_" + j, true)[0]).Text.IndexOf("|");
                                string x = ((Label)pllist[2].Controls.Find("lb_" + j, true)[0]).Text.Substring(0, position2);
                                if (x.Contains("m"))
                                {
                                    short position = ((Label)pllist[2].Controls.Find("lb_" + j, true)[0]).Text.IndexOf("m");
                                    Image newImage = Image.FromFile(folderDirPath + "\\" + ((Label)pllist[2].Controls.Find("lb_" + j, true)[0]).Text.Substring(0, position) + ".png");
                                    ((PictureBox)pllist[2].Controls.Find("pic_" + j, true)[0]).Image = newImage;
                                }
                                else if (x.Contains("z"))
                                {
                                    short position = ((Label)pllist[2].Controls.Find("lb_" + j, true)[0]).Text.IndexOf("z");
                                    Image newImage = Image.FromFile(folderDirPath + "\\" + ((Label)pllist[2].Controls.Find("lb_" + j, true)[0]).Text.Substring(0, position) + ".png");
                                    ((PictureBox)pllist[2].Controls.Find("pic_" + j, true)[0]).Image = newImage;
                                }
                            }
                        }
                        else
                        {
                            if (folderDirPath != null)
                            {
                                short position = ((Label)pllist[2].Controls.Find("lb_" + j, true)[0]).Text.IndexOf("|");
                                Image newImage = Image.FromFile(folderDirPath + "\\" + ((Label)pllist[2].Controls.Find("lb_" + j, true)[0]).Text.Substring(0, position) + ".png");
                                ((PictureBox)pllist[2].Controls.Find("pic_" + j, true)[0]).Image = newImage;
                            }
                        }
                    }
                    if (((Label)pllist[2].Controls.Find("lb_" + j, true)[1]).Text == "_|1" || ((Label)pllist[2].Controls.Find("lb_" + j, true)[1]).Text == "")
                    {
                    }
                    else
                    {
                        if (((Label)pllist[2].Controls.Find("lb_" + j, true)[1]).Text.Contains("-1"))
                        {
                            if (folderDirPath != null)
                            {
                                short position2 = ((Label)pllist[2].Controls.Find("lb_" + j, true)[1]).Text.IndexOf("|");
                                string x = ((Label)pllist[2].Controls.Find("lb_" + j, true)[1]).Text.Substring(0, position2);
                                if (x.Contains("m"))
                                {
                                    short position = ((Label)pllist[2].Controls.Find("lb_" + j, true)[1]).Text.IndexOf("m");
                                    Image newImage = Image.FromFile(folderDirPath + "\\" + ((Label)pllist[2].Controls.Find("lb_" + j, true)[1]).Text.Substring(0, position) + ".png");
                                    ((PictureBox)pllist[2].Controls.Find("pic_" + j, true)[0]).Image = newImage;
                                }
                                else if (x.Contains("z"))
                                {
                                    short position = ((Label)pllist[2].Controls.Find("lb_" + j, true)[1]).Text.IndexOf("z");
                                    Image newImage = Image.FromFile(folderDirPath + "\\" + ((Label)pllist[2].Controls.Find("lb_" + j, true)[1]).Text.Substring(0, position) + ".png");
                                    ((PictureBox)pllist[2].Controls.Find("pic_" + j, true)[0]).Image = newImage;
                                }
                            }
                        }
                        else
                        {
                            if (folderDirPath != null)
                            {
                                short position = ((Label)pllist[2].Controls.Find("lb_" + j, true)[1]).Text.IndexOf("|");
                                Image newImage = Image.FromFile(folderDirPath + "\\" + ((Label)pllist[2].Controls.Find("lb_" + j, true)[1]).Text.Substring(0, position) + ".png");
                                ((PictureBox)pllist[2].Controls.Find("pic_" + j, true)[1]).Image = newImage;
                            }
                        }
                    }
                }
                for (short j = 0; j < allcount; j++)
                {
                    ((PictureBox)pllist[2].Controls.Find("pic_" + j, true)[1]).Parent = ((PictureBox)pllist[2].Controls.Find("pic_" + j, true)[0]);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("圖片錯誤");
            }*/
        }
        #endregion

        #region 訊息回復初始狀態

        /// <summary>
        /// 訊息顯示完後回復初始狀態的整合程式碼。
        /// </summary>
        private void CallMSGbackactive()
        {
            try
            {
                /*if (th_MSGBackActive.IsCompleted)
                {
                    Task.WhenAny(th_MSGBackActive);
                }*/
            }
            catch
            {

            }
            th_MSGBackActive = Task.Run(MSGbackactive);
        }



        /// <summary>
        /// 訊息顯示完後回復到初始狀態。
        /// </summary>
        private void MSGbackactive()
        {
            Thread.Sleep(600);
            pl_MSG.BackColor = Color.FromArgb(255, 90, 90, 90);
            Thread.Sleep(600);
            pl_MSG.BackColor = Color.Black;
            Thread.Sleep(600);
            pl_MSG.BackColor = Color.FromArgb(255, 90, 90, 90);
            Thread.Sleep(600);
            lb_MSG.Text = lb_MSGText;
            lb_MSG.ForeColor = Color.Green;
            pl_MSG.BackColor = Color.Transparent;
        }

        #endregion 訊息回復初始狀態 

        #region 顯示/隱藏傳送點與行走設定

        /// <summary>
        /// 操作目標為前景。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rb_useFore_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_useFore.Checked)
            {
                // 傳送點區域。
                //lb_teleportNo.Visible = false;
            }
        }



        /// <summary>
        /// 操作目標為背景。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rb_useBack_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_useBack.Checked)
            {

            }
        }



        #endregion
        
        #region 控制元件大小隨視窗大小等比例縮放

        private float x;//定義目前視窗的寬度
        private float y;//定義目前視窗的高度
        private void setTag(Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ";" + con.Height + ";" + con.Left + ";" + con.Top + ";" + con.Font.Size;
                if (con.Controls.Count > 0)
                {
                    setTag(con);
                }
            }
        }
        private void setControls(float newx, float newy, Control cons)
        {
            //遍歷視窗中的控制元件，重新設定控制元件的值
            foreach (Control con in cons.Controls)
            {
                //獲取控制元件的Tag屬性值，並分割後儲存字串陣列
                if (con.Tag != null)
                {
                    string[] mytag = con.Tag.ToString().Split(new char[] { ';' });
                    //根據視窗縮放的比例確定控制元件的值
                    con.Width = Convert.ToInt16(Convert.ToSingle(mytag[0]) * newx);//寬度
                    con.Height = Convert.ToInt16(Convert.ToSingle(mytag[1]) * newy);//高度
                    con.Left = Convert.ToInt16(Convert.ToSingle(mytag[2]) * newx);//左邊距
                    con.Top = Convert.ToInt16(Convert.ToSingle(mytag[3]) * newy);//頂邊距
                    float currentSize = Convert.ToSingle(mytag[4]) * newy;//字型大小
                    con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                    if (con.Controls.Count > 0)
                    {
                        setControls(newx, newy, con);
                    }
                }
            }
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            float newx = (Width) / x;
            float newy = (Height) / y;
            RD.Size2 size = new RD.Size2(container.Width, container.Height);
            if (Focused)
                views.Resize(size);
            setControls(newx, newy, this);
        }

        #endregion

        #region 進度條
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        private void ProgressBarVaultStartCount()
        {
            toolStripLb_per.Text = "0%";
            toolStripProgressBar1.Value = 0;
            toolStripLb_per.Visible = true;
            toolStripProgressBar1.Visible = true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        private void ProgressBarVaultEndCount()
        {
            Task.Run(() =>
            {
                toolStripLb_per.Visible = false;
                toolStripProgressBar1.Visible = false;
            });
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        private void ProgressBarVaultAdd()
        {
            toolStripProgressBar1.Value++;
            toolStripLb_per.Text = Convert.ToInt16(toolStripProgressBar1.Value * 100.0 / toolStripProgressBar1.Maximum) + "%";
        }
        #endregion 進度條

        #region 改變顯示

        private void 框線ToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (框線ToolStripMenuItem.Checked)
            {
                drawRectangle = true;
            }
            else
            {
                drawRectangle = false;
            }
            container.Refresh();
        }

        private void 前景ToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (前景ToolStripMenuItem.Checked)
            {
                drawFore = true;
            }
            else
            {
                drawFore = false;
            }
            container.Refresh();
        }

        private void 背景ToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (背景ToolStripMenuItem.Checked)
            {
                drawBack = true;
            }
            else
            {
                drawBack = false;
            }
            container.Refresh();
        }

        private void 傳送點ToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (傳送點ToolStripMenuItem.Checked)
            {
                drawTeleport = true;
            }
            else
            {
                drawTeleport = false;
            }
            container.Refresh();
        }

        private void 能否行走ToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (能否行走ToolStripMenuItem.Checked)
            {
                drawWalk = true;
            }
            else
            {
                drawWalk = false;
            }
            container.Refresh();
        }

        private void 地圖邊界ToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (地圖邊界ToolStripMenuItem.Checked)
            {
                drawMapBorder = true;
            }
            else
            {
                drawMapBorder = false;
            }
            container.Refresh();

        }
        #endregion 改變顯示

        #region 調整 欄 行 寬 高 顯示比例

        private void tb_size_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                changeSize(10);
            }
            else if (e.Delta < 0)
            {
                changeSize(-10);
            }
            tb_size.Text = size + "%";
            container.Refresh();
        }




        private void bt_change_size_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                tb_size.Text = "100%";
            }
            else
            {
                switch (sender.ToString().Split(' ')[2])
                {
                    case "▲":
                        changeSize(10);
                        break;
                    case "▼":
                        changeSize(-10);
                        break;
                }
                tb_size.Text = size + "%";
            }
            container.Refresh();
        }




        private void tb_size_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                tb_size.Text = "100%";
            }
        }



        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        /// <summary>
        /// 調整顯示比例。
        /// </summary>
        /// <param name="num">大小</param>
        private void changeSize(short num)
        {
            size += (ushort)num;
            if (size < 10)
            {
                size = 10;
            }
        }



        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        /// <summary>
        /// 調整數字。
        /// </summary>
        /// <param name="num">數值大小</param>
        /// <param name="target">目標變數</param>
        /// <returns>最終結果</returns>
        private ushort changeNum(short num, ushort target)
        {
            target += (ushort)num;
            if (target < 1)
            {
                target = 1;
            }
            return target;
        }




        private void tb_size_TextChanged(object sender, EventArgs e)
        {
            string Num = tb_size.Text;
            ushort nullPerLen = (ushort)Num.Length;
            ushort num;

            // 檢查有沒有打百分比符號。
            if (Num.IndexOf('%') > 0)
            {
                nullPerLen = (ushort)Num.IndexOf('%');
            }

            Num = Num.Substring(0, nullPerLen);

            // 檢查打的是否為數字。
            try
            {
                num = Convert.ToUInt16(Num);
                if (num > 0)
                {
                    size = (ushort)Math.Max(num, -num);
                }
            }
            catch
            {

            }

            //tb_size.Text = $"{size}%";
            container.Refresh();
        }




        private void bt_colUp_Click(object sender, EventArgs e)
        {
            tb_col.Text = "" + changeNum(1, col);
        }




        private void bt_colDown_Click(object sender, EventArgs e)
        {
            tb_col.Text = "" + changeNum(-1, col);
        }




        private void bt_col_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                tb_col.Text = "" + changeNum(1, col);
            }
            else if (e.Delta < 0)
            {
                tb_col.Text = "" + changeNum(-1, col);
            }
        }




        private void bt_rowUp_Click(object sender, EventArgs e)
        {
            tb_row.Text = "" + changeNum(1, row);
        }




        private void bt_rowDown_Click(object sender, EventArgs e)
        {
            tb_row.Text = "" + changeNum(-1, row);
        }




        private void bt_row_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                tb_row.Text = "" + changeNum(1, row);
            }
            else if (e.Delta < 0)
            {
                tb_row.Text = "" + changeNum(-1, row);
            }
        }




        private void bt_widthUp_Click(object sender, EventArgs e)
        {
            tb_width.Text = "" + changeNum(1, width);
        }




        private void bt_widthDown_Click(object sender, EventArgs e)
        {
            tb_width.Text = "" + changeNum(-1, width);
        }




        private void bt_width_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                tb_width.Text = "" + changeNum(1, width);
            }
            else if (e.Delta < 0)
            {
                tb_width.Text = "" + changeNum(-1, width);
            }
        }




        private void bt_heightUp_Click(object sender, EventArgs e)
        {
            tb_height.Text = "" + changeNum(1, height);
        }




        private void bt_heightDown_Click(object sender, EventArgs e)
        {
            tb_height.Text = "" + changeNum(-1, height);
        }




        private void bt_height_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                tb_height.Text = "" + changeNum(1, height);
            }
            else if (e.Delta < 0)
            {
                tb_height.Text = "" + changeNum(-1, height);
            }
        }

        #endregion 調整 欄 行 寬 高 顯示比例

        #region 顯示地圖 & 格子設定
        private void bt_gridSetting_Click(object sender, EventArgs e)
        {
            switch (sender.ToString().Split(' ')[2])
            {
                case "︽":
                    bt_gridSetting.Text = "︾";
                    pl_gridSetting.Visible = true;
                    lb_gridSetting.Visible = true;
                    //bt_gridSetting.Top = Convert.ToInt16(477 * Width / x);
                    break;
                case "︾":
                    bt_gridSetting.Text = "︽";
                    pl_gridSetting.Visible = false;
                    lb_gridSetting.Visible = false;
                    //bt_gridSetting.Top = Convert.ToInt16(699 * Width / x);
                    break;
            }
        }

        private void bt_mapSetting_Click(object sender, EventArgs e)
        {
            switch (sender.ToString().Split(' ')[2])
            {
                case "︽":
                    bt_mapSetting.Text = "︾";
                    pl_mapSetting.Visible = true;
                    lb_mapSetting.Visible = true;
                    //bt_mapSetting.Top = Convert.ToInt16(477 * Width / x);
                    break;
                case "︾":
                    bt_mapSetting.Text = "︽";
                    pl_mapSetting.Visible = false;
                    lb_mapSetting.Visible = false;
                    //bt_mapSetting.Top = Convert.ToInt16(699 * Width / x);
                    break;
            }
        }
        #endregion 顯示地圖 & 格子設定

        private void cb_forceSave_CheckedChanged(object sender, EventArgs e)
        {
            if(cb_allSave.Checked)
            {
                allSave = true;
            }
            else
            {
                allSave = false;
            }
        }

        private void cb_donotAlertOverrideMap_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_donotAlertOverrideMap.Checked)
            {
                donotAlertOverrideMap = true;
            }
            else
            {
                donotAlertOverrideMap = false;
            }
        }

        private void button_deleteTeleport_Click(object sender, EventArgs e)
        {
            try
            {
                var tIds = GetTeleportListContent(comboBox_tpLoction.Text, true);
                foreach (var item in tIds)
                {
                    ushort tIdArray = teleport[editGrid.X1 - 1, editGrid.Y1 - 1];
                    if (item == tIdArray) teleport[editGrid.X1 - 1, editGrid.Y1 - 1] = 0;
                    foreach (var itemx in teleports)
                    {
                        if (itemx.tId == item)
                        {
                            itemx.teleport = 0;
                            break;
                        }
                    }
                }
                ShowTeleportList();
            }
            catch (Exception se)
            {
                ShowErrorMSG(se.Message);
                MessageBox.Show(se.Message);
            }
        }

        private void button_createTeleport_Click(object sender, EventArgs e)
        {
            try
            {
                ushort tId = GetTeleportListContent(comboBox_newtpLoction.Text, false)[0];
                teleport[editGrid.X1 - 1, editGrid.Y1 - 1] = ++maxtId;
                Teleport teleportss = new Teleport((ushort)(editGrid.X1 - 1), (ushort)(editGrid.Y1 - 1), maxtId, this.mId, gId, tId);
                teleports.Add(teleportss);
                ShowTeleportList();
            }
            catch (Exception se)
            {
                ShowErrorMSG(se.Message);
                MessageBox.Show(se.Message);
            }
        }
    }
}
