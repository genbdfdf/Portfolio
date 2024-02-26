using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Threading;
using NAudio.Wave;
using NAudio.Vorbis;
using RD = SharpDX;
using RD2 = SharpDX.Direct2D1;
using RDM = SharpDX.Mathematics.Interop;
using RDW = SharpDX.DirectWrite;
using RDX = SharpDX.DXGI;
using RD2E = SharpDX.Direct2D1.Effects;
using SharpDX.Direct3D;
using SharpDX.Direct3D12;
using System.Collections;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Security.Policy;
using System.Xml.Linq;
using NAudio.SoundFont;
using SharpDX.Mathematics.Interop;
using Microsoft.VisualBasic;
using SharpDX.D3DCompiler;

namespace gametest
{
    public partial class gametest : Form
    {

        #region ////////// 全域變數區 //////////

        #region 音樂變數
        VorbisWaveReader music_fail;
        VorbisWaveReader music_background;
        VorbisWaveReader music_get;
        AudioFileReader music_3_2_1;
        Mp3FileReader music_boss;
        WaveOut waveOut_fail = new WaveOut();
        WaveOut waveOut_background = new WaveOut();
        WaveOut waveOut_get = new WaveOut();
        WaveOut waveOut_boss = new WaveOut();
        WaveOut waveOut_3_2_1 = new WaveOut();
        TimeSpan timeSpan = new TimeSpan(0, 0, 0);
        #endregion

        #region 列表變數
        List<List<int>> heroLocs = new List<List<int>>();//角色面向的位置 1上 2下 3左 4右
        List<int> heroLocTF = new List<int>();//角色面向的位置 1上 2下 3左 4右
        List<List<int>> chestLoc = new List<List<int>>();
        RD2.Bitmap[] BG = new RD2.Bitmap[3];
        RD2.Bitmap[] hero = new RD2.Bitmap[5000];
        RD2.Bitmap[] heroShadow = new RD2.Bitmap[5000];
        RD2.Bitmap[] chest = new RD2.Bitmap[10000];
        RD2.Bitmap[] wall = new RD2.Bitmap[100];
        RD2.Bitmap[] land = new RD2.Bitmap[100];
        #endregion

        #region 變數
        RD2.WindowRenderTarget View;
        Random random = new Random();
        int nowView = -1;
        int mainView = -1; // -4 轉換畫面 -2  開始遊戲畫面載入畫面。　-1 遊戲載入畫面　0 標題畫面　1 遊戲畫面
        int windowView = -1; // -1　不顯示　0 遊戲設定　1 通知視窗
        int targetView = 0;
        int FPS = 13;
        int speed = 10;
        int fruitRequiredCount = 3;
        int getfruitCount = 0;
      
        int x = 0;
        int y = 0;

        int TFX = 0;
        int TFY = 0;

        short difficulty = 0;
        short difficulty2 = 0;

        int VC_Width;
        int VC_Height;

        bool isLoadingFinished;

        float dpi;
        float WelcomeText1Color = 0f;
        float WelcomeText2Color = 0f;


        string font = "Lolita";
        private static readonly object locker = new object();
        #endregion

        #endregion ////////// 全域變數區 //////////

        #region ////////// 建構式區 //////////
        public gametest()
        {
            InitializeComponent();
            string myself = Assembly.GetExecutingAssembly().Location;
            string date = File.GetLastWriteTime(myself).ToString("yyyy/MM/dd");
            Text = $"Snake - {date}";
            //初始化遊戲。
            container.Dock = DockStyle.Fill;
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
                PixelSize = new RD.Size2(container.ClientSize.Width, container.ClientSize.Height),
                PresentOptions = RD2.PresentOptions.None
            };
            View = new RD2.WindowRenderTarget(FY, renderProps, hwndProps)
            {
                AntialiasMode = RD2.AntialiasMode.PerPrimitive
            };

            //初始化遊戲大小。
            Graphics graphics = CreateGraphics();
            switch (graphics.DpiX)
            {
                case 120:
                    dpi = 100.0f / 125.0f;
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
                    break;
            }

            VC_Height = Convert.ToInt32(container.ClientSize.Height * dpi);
            VC_Width = Convert.ToInt32(container.ClientSize.Width * dpi);
            //取消跨執行緒調動資源的檢查。
            CheckForIllegalCrossThreadCalls = false;
            //背景載入資源。
            Task.Run(() => InitRes());
            //啟動遊戲迴圈，使遊戲啟動。
            /*Thread th_gameloop = new Thread(GameLoop);
            th_gameloop.IsBackground = true;
            th_gameloop.Start();*/
            //啟動畫面彩現，使畫面輸出。
            Thread th_render = new Thread(refresh);
            th_render.IsBackground = true;
            th_render.Start();
            Task.Run(() =>
            {
                Thread.Sleep(1000);
                heroLocs.Add(new List<int> { VC_Width / 40 / 2 * 40, VC_Height / 40 / 2 * 40, 1 });
                FruitUpdate();
            });
        }
        #endregion ////////// 建構式區 //////////

        #region ////////// 事件區 //////////

        #region ========== 視窗類 ==========
        private void container_Paint(object sender, PaintEventArgs e)
        {
            display();
        }
        private void gametest_Resize(object sender, EventArgs e)
        {
            VC_Height = Convert.ToInt32(container.ClientSize.Height * dpi);
            VC_Width = Convert.ToInt32(container.ClientSize.Width * dpi);
            RD.Size2 size = new RD.Size2(container.ClientSize.Width, container.ClientSize.Height);
            if (container.Focused)
            {
                View.Resize(size);
            }
        }
        #endregion

        #region ========== 滑鼠按鍵類 ==========

        private void container_MouseClick(object sender, MouseEventArgs e)
        {
            //735,300//1130,485
            //735,565//1130,750
            //735,805//1130,995
            //1936//1056
            // MessageBox.Show("" + e.X + " | " + e.Y);
            if (mainView == 0 &&
                     e.X < Width / 1.71f && e.X > Width / 2.63f &&
                     e.Y < Height / 2.18f && e.Y > Height / 3.52f)
            {
                //MessageBox.Show("請選擇難度"); 
                string s = Interaction.InputBox(
                    "請輸入難度\n" +
                    "1.勇者的女兒\n" +
                    "2.女高中生\n" +
                    "3.魔女\n" +
                    "4.精靈王\n" +
                    "5.陰蜂", "輸入難度", "1", -1, -1);
                if (Int16.TryParse(s, out difficulty2) && difficulty2 > 0 && difficulty2 < 6)
                {
                    switch (difficulty2)
                    {
                        case 1:
                            speed = 5;
                            tmr_music.Interval = (int)(music_background.TotalTime.TotalSeconds * 1000 + 100);
                            break;
                        case 2:
                            speed = 10;
                            tmr_music.Interval = (int)(music_background.TotalTime.TotalSeconds * 1000 + 100);
                            break;
                        case 3:
                            speed = 20;
                            tmr_music.Interval = (int)(music_background.TotalTime.TotalSeconds * 1000 + 100);
                            break;
                        case 4:
                            speed = 50;
                            tmr_music.Interval = (int)(music_background.TotalTime.TotalSeconds * 1000 + 100);
                            break;
                        case 5:
                            speed = 100;
                            tmr_music.Interval = (int)(music_boss.TotalTime.TotalSeconds * 1000);
                            break;
                    }
                    if (difficulty2 < 5)
                    {
                        Task.Run(() => {
                            Thread.Sleep(3500);
                            music_background.CurrentTime = timeSpan;
                            waveOut_background.Play();
                            //啟動遊戲迴圈，使遊戲啟動。
                            Thread th_gameloop = new Thread(GameLoop);
                            th_gameloop.IsBackground = true;
                            th_gameloop.Start();
                        });

                    }
                    else
                    {
                        Task.Run(() => {
                            Thread.Sleep(1576);
                            music_3_2_1.CurrentTime = timeSpan;
                            music_boss.CurrentTime = timeSpan;
                            waveOut_3_2_1.Play();
                            Thread.Sleep(1924);
                            music_boss.CurrentTime = new TimeSpan(0, 0, 0, 1, 100);
                            waveOut_boss.Play();
                            //啟動遊戲迴圈，使遊戲啟動。
                            Thread th_gameloop = new Thread(GameLoop);
                            th_gameloop.IsBackground = true;
                            th_gameloop.Start();
                        });
                    }
                    mainView = -2;
                    targetView = 1;
                    difficulty = difficulty2;
                    difficulty2 = 0;
                    tmr_music.Enabled = true;
                }
            }
            if (mainView == 0 &&
                e.X < Width / 1.71f && e.X > Width / 2.63f &&
                e.Y < Height / 1.41f && e.Y > Height / 1.87f)
            {
                MessageBox.Show("沒這東西");
            }
            if (mainView == 0 &&
                e.X < Width / 1.71f && e.X > Width / 2.63f &&
                e.Y < Height / 1.06f && e.Y > Height / 1.31f)
            {
                Environment.Exit(0);
            }
        }

        private void container_MouseMove(object sender, MouseEventArgs e)
        {
            
        }
        private void container_KeyDown(object sender, KeyEventArgs e)
        {
            //角色面向的位置 1上 2下 3左 4右
            switch (e.KeyCode)
            {
                case Keys.W:
                    if (heroLocs[0][2] != 2)
                    {
                        heroLocs[0][2] = 1;
                    }
                    break;
                case Keys.S:
                    if (heroLocs[0][2] != 1)
                    {
                        heroLocs[0][2] = 2;
                    }
                    break;
                case Keys.A:
                    if (heroLocs[0][2] != 4)
                    {
                        heroLocs[0][2] = 3;
                    }
                    break;
                case Keys.D:
                    if (heroLocs[0][2] != 3)
                    {
                        heroLocs[0][2] = 4;
                    }
                    break;
            }
        }
        #endregion ========== 滑鼠按鍵類 ==========

        #region ========== 計時器類 ==========

        private void tmr_music_Tick(object sender, EventArgs e)
        {
            music_background.CurrentTime = timeSpan;
            music_boss.CurrentTime = timeSpan;
            if (difficulty < 5)
                waveOut_background.Play();
            else if (difficulty == 5)
                waveOut_boss.Play();
        }
        private void update_Tick(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            MaximizedBounds = Screen.PrimaryScreen.WorkingArea;
        }
        private void fruitUpdate_Tick(object sender, EventArgs e)
        {
            fruitUpdate.Interval =random.Next(100,1000);
            FruitUpdate();
        }
        #endregion ========== 計時器類 ==========

        #endregion ////////// 事件區 //////////

        #region ////////// 自訂函數區 //////////

        #region ---------- 影像類 ----------
        /// <summary>
        /// 產生影像的陰影。
        /// </summary>
        /// <param name="pBmp">圖片</param>
        /// <returns>陰影</returns>
        private Bitmap imageShadow(Bitmap pBmp)
        {
            try
            {
                Bitmap tmpBmp = new Bitmap(pBmp.Width, pBmp.Height);
                Graphics tmpG = Graphics.FromImage(tmpBmp);
                float[][] colorMatrixElements ={
                    new float[]{0,0,0,0,0},
                    new float[]{0,0,0,0,0},
                    new float[]{0,0,0,0,0},
                    new float[]{0,0,0,1,0},
                    new float[]{0,0,0,0,-1}
                    };
                ColorMatrix cm = new ColorMatrix(colorMatrixElements);
                ImageAttributes ia = new ImageAttributes();
                ia.SetColorMatrix(cm);
                tmpG.DrawImage(pBmp,
                    new Rectangle(0, 0, pBmp.Width, pBmp.Height), 0, 0,
                    pBmp.Width, pBmp.Height,
                    GraphicsUnit.Pixel, ia);
                tmpG.Dispose();
                return tmpBmp;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 讀取圖片。
        /// </summary>
        /// <param name="renderTarget">顯示於哪裡</param>
        /// <param name="file">圖片來源</param>
        /// <returns>圖片</returns>
        private RD2.Bitmap LoadFromFile(RD2.RenderTarget renderTarget, Bitmap file)
        {
            // Loads from file using System.Drawing.Image
            using (var bitmap = file)
            {
                var sourceArea = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
                var bitmapProperties = new RD2.BitmapProperties(new RD2.PixelFormat(RDX.Format.R8G8B8A8_UNorm, RD2.AlphaMode.Premultiplied));
                var size = new RD.Size2(bitmap.Width, bitmap.Height);

                // Transform pixels from BGRA to RGBA
                int stride = bitmap.Width * sizeof(int);
                using (var tempStream = new RD.DataStream(bitmap.Height * stride, true, true))
                {
                    // Lock System.Drawing.Bitmap
                    var bitmapData = bitmap.LockBits(sourceArea, ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);

                    // Convert all pixels 
                    for (int y = 0; y < bitmap.Height; y++)
                    {
                        int offset = bitmapData.Stride * y;
                        for (int x = 0; x < bitmap.Width; x++)
                        {
                            // Not optimized 
                            byte B = Marshal.ReadByte(bitmapData.Scan0, offset++);
                            byte G = Marshal.ReadByte(bitmapData.Scan0, offset++);
                            byte R = Marshal.ReadByte(bitmapData.Scan0, offset++);
                            byte A = Marshal.ReadByte(bitmapData.Scan0, offset++);
                            int rgba = R | (G << 8) | (B << 16) | (A << 24);
                            tempStream.Write(rgba);
                        }

                    }
                    bitmap.UnlockBits(bitmapData);
                    tempStream.Position = 0;

                    return new RD2.Bitmap(renderTarget, size, tempStream, stride, bitmapProperties);
                }
            }
        }

        #endregion

        #region ========== 顯示類 ==========
        /// <summary>
        /// 產生連續畫面的程式碼。
        /// </summary>
        private void refresh()
        {
            while (true)
            {
                Thread.Sleep(FPS);
                container.Refresh();
            }
        }

        /// <summary>
        /// 顯示畫面的程式碼。
        /// </summary>
        private void display()
        {
            RDW.Factory FY = new RDW.Factory();
            RD2.SolidColorBrush PenShadow = new RD2.SolidColorBrush(View, new RDM.RawColor4(0, 0, 0, 0.35f));
            View.BeginDraw();
            View.Clear(RD.Color.Transparent);
            // 顯示畫面。
            switch (mainView)
            {
                // 轉換畫面。
                case -4:
                    displaySwitchView(FY, PenShadow);
                    break;

                // 開始遊戲畫面載入畫面。
                case -2:
                    displayTitle(FY, PenShadow);
                    displayLoading2(FY);
                    break;

                // 遊戲載入畫面。
                case -1:
                    displayLoading(FY);
                    break;

                // 標題畫面。
                case 0:
                    displayTitle(FY, PenShadow);
                    break;

                // 遊戲畫面。
                case 1:
                    displayGame(FY, PenShadow);
                    break;
            }

            // 顯示視窗。
            switch (windowView)
            {
                // 遊戲設定。
                case 0:
                    displaySetting(FY, PenShadow);
                    break;

                // 通知視窗。
                case 1:
                    displayNotice(FY, PenShadow);
                    break;
            }
            View.EndDraw();
        }
        private void displaySwitchView(RDW.Factory FY, RD2.SolidColorBrush PenShadow)
        {
            if (nowView == targetView)
            {
                switch (targetView)
                {
                    // 開始遊戲畫面載入畫面。
                    case -2:
                        displayTitle(FY, PenShadow);
                        displayLoading(FY);
                        break;

                    // 遊戲載入畫面。
                    case -1:
                        displayLoading(FY);
                        break;

                    // 標題畫面。
                    case 0:
                        displayTitle(FY, PenShadow);
                        break;

                    // 遊戲畫面。
                    case 1:
                        displayGame(FY, PenShadow);
                        break;
                }
                RDM.RawRectangleF ToTitle = new RDM.RawRectangleF(50, 50, 50, 50);
                RD2.SolidColorBrush ToTitlePen = new RD2.SolidColorBrush(View, new RDM.RawColor4(0, 0, 0, WelcomeText1Color));
                View.DrawRectangle(ToTitle, ToTitlePen, 10000);
                if (WelcomeText1Color > 0)
                {
                    WelcomeText1Color -= 0.02f;
                }
                else
                {
                    mainView = targetView;
                }
            }
            else
            {
                switch (nowView)
                {
                    // 開始遊戲畫面載入畫面。
                    case -2:
                        displayTitle(FY, PenShadow);
                        displayLoading(FY);
                        break;

                    // 遊戲載入畫面。
                    case -1:
                        displayLoading(FY);
                        break;

                    // 標題畫面。
                    case 0:
                        displayTitle(FY, PenShadow);
                        break;

                    // 遊戲畫面。
                    case 1:
                        displayGame(FY, PenShadow);
                        break;
                }
                RDM.RawRectangleF ToTitle = new RDM.RawRectangleF(50, 50, 50, 50);
                RD2.SolidColorBrush ToTitlePen = new RD2.SolidColorBrush(View, new RDM.RawColor4(0, 0, 0, WelcomeText1Color));
                View.DrawRectangle(ToTitle, ToTitlePen, 10000);
                if (WelcomeText1Color < 1.0f)
                {
                    WelcomeText1Color += 0.02f;
                }
                else
                {
                    nowView = targetView;
                }
            }
        }
        private void displayLoading(RDW.Factory FY)
        {
            if (isLoadingFinished)
            {
                if (WelcomeText1Color > 0)
                {
                    WelcomeText1Color -= 0.015f;
                }
                if (WelcomeText2Color > 0)
                {
                    WelcomeText2Color -= 0.015f;
                }
                if (WelcomeText1Color < 0 && WelcomeText2Color < 0)
                {
                    mainView = -4;
                    nowView = -3;
                }
            }
            else
            {
                if (WelcomeText1Color < 1.0f)
                {
                    WelcomeText1Color += 0.015f;
                }
                if (WelcomeText1Color > 1.0f && WelcomeText2Color < 1.0f)
                {
                    WelcomeText2Color += 0.015f;
                }
            }
            RDW.TextFormat TF = new RDW.TextFormat(FY, font, VC_Width / 10f);
            RDM.RawRectangleF Loc = new RDM.RawRectangleF(VC_Width / 4, VC_Height / 2.8f, VC_Width, VC_Height);
            RDM.RawColor4 PenColor = new RDM.RawColor4(1, 1, 1, WelcomeText1Color);
            RD2.SolidColorBrush Pen = new RD2.SolidColorBrush(View, PenColor);
            View.DrawText("遊戲讀取中", TF, Loc, Pen);
        }
        private void displayLoading2(RDW.Factory FY)
        {
            if (isLoadingFinished)
            {
                if (WelcomeText1Color < 1.0f)
                {
                    WelcomeText1Color += 0.015f;
                }
                if (WelcomeText2Color < 1.0f)
                {
                    WelcomeText2Color += 0.015f;
                }
                if (WelcomeText1Color > 1.0f && WelcomeText2Color > 1.0f)
                {
                    mainView = -1;
                }
            }
            else
            {
                if (WelcomeText1Color < 1.0f)
                {
                    WelcomeText1Color += 0.015f;
                }
                if (WelcomeText1Color > 1.0f && WelcomeText2Color < 1.0f)
                {
                    WelcomeText2Color += 0.015f;
                }
            }
            RDM.RawRectangleF ToTitle = new RDM.RawRectangleF(50, 50, 50, 50);
            RD2.SolidColorBrush ToTitlePen = new RD2.SolidColorBrush(View, new RDM.RawColor4(0, 0, 0, WelcomeText1Color));
            View.DrawRectangle(ToTitle, ToTitlePen, 10000);
            RDW.TextFormat TF = new RDW.TextFormat(FY, font, VC_Width / 10f);
            RDM.RawRectangleF Loc = new RDM.RawRectangleF(VC_Width / 4, VC_Height / 2.8f, VC_Width, VC_Height);
            RDM.RawColor4 PenColor = new RDM.RawColor4(1, 1, 1, WelcomeText1Color);
            RD2.SolidColorBrush Pen = new RD2.SolidColorBrush(View, PenColor);
            View.DrawText("遊戲讀取中", TF, Loc, Pen);
        }
        private void displayTitle(RDW.Factory FY, RD2.SolidColorBrush PenShadow)
        {
            //背景畫面。
            RDM.RawRectangleF mapsize = new RDM.RawRectangleF(0, 0, VC_Width, VC_Height);
            View.DrawBitmap(BG[1], mapsize, 1.0f, RD2.BitmapInterpolationMode.Linear);

            RDW.TextFormat TF = new RDW.TextFormat(FY, font, VC_Width / 8f);
            RDM.RawRectangleF Loc = new RDM.RawRectangleF(VC_Width / 5.2f, VC_Height / 100.0f, VC_Width, VC_Height);
            RDM.RawColor4 PenColor = new RDM.RawColor4(255, 0, 255, 1);
            RD2.SolidColorBrush Pen = new RD2.SolidColorBrush(View, PenColor);
            View.DrawText("very snake", TF, Loc, Pen);

            RD2.SolidColorBrush RectangleStrokePen = new RD2.SolidColorBrush(View, new RDM.RawColor4(0, 0, 0, 1));
            var roundedRectangle = new RD2.RoundedRectangle();
            roundedRectangle.Rect = new RDM.RawRectangleF(VC_Width / 2.6f, VC_Height / 3.4f, VC_Width / 1.7f, VC_Height / 2.1f);
            roundedRectangle.RadiusX = 10;
            roundedRectangle.RadiusY = 10;
            View.FillRoundedRectangle(roundedRectangle, RectangleStrokePen);//圓角

            PenColor = new RDM.RawColor4(0, 255, 255, 1);
            Pen = new RD2.SolidColorBrush(View, PenColor);
            TF = new RDW.TextFormat(FY, font, VC_Width / 10f);
            Loc = new RDM.RawRectangleF(VC_Width / 2.6f, VC_Height / 3.8f, VC_Width, VC_Height);
            View.DrawText("開始", TF, Loc, Pen);

            roundedRectangle.Rect = new RDM.RawRectangleF(VC_Width / 2.6f, VC_Height / 1.80f, VC_Width / 1.7f, VC_Height / 1.35f);
            roundedRectangle.RadiusX = 10;
            roundedRectangle.RadiusY = 10;
            View.FillRoundedRectangle(roundedRectangle, RectangleStrokePen);//圓角
            Loc = new RDM.RawRectangleF(VC_Width / 2.6f, VC_Height / 1.9f, VC_Width, VC_Height);
            View.DrawText("設定", TF, Loc, Pen);

            roundedRectangle.Rect = new RDM.RawRectangleF(VC_Width / 2.6f, VC_Height / 1.26f, VC_Width / 1.7f, VC_Height / 1.02f);
            roundedRectangle.RadiusX = 10;
            roundedRectangle.RadiusY = 10;
            View.FillRoundedRectangle(roundedRectangle, RectangleStrokePen);//圓角
            Loc = new RDM.RawRectangleF(VC_Width / 2.6f, VC_Height / 1.3f, VC_Width, VC_Height);
            View.DrawText("離開", TF, Loc, Pen);

        }
        private void displayGame(RDW.Factory FY, RD2.SolidColorBrush PenShadow)
        {
            for (int i = 0; i < VC_Width / 40 - 1; i++)
            {
                for (int j = 0; j < VC_Height / 40 - 1; j++)
                {
                    RDM.RawRectangleF RDland = new RDM.RawRectangleF(40 + 40 * i, 40 + 40 * j, 40 + 40 * (i + 1), 40 + 40 * (j + 1));
                    View.DrawBitmap(land[1], RDland, 1.0f, RD2.BitmapInterpolationMode.Linear);
                }
            }
            for (int i = 0; i < VC_Width / 40 + 1; i++)
            {
                RDM.RawRectangleF RDwall = new RDM.RawRectangleF(40 * i, 0, 40 * (i + 1), 40);
                View.DrawBitmap(wall[0], RDwall, 1.0f, RD2.BitmapInterpolationMode.Linear);
                RDwall = new RDM.RawRectangleF(40 * i, VC_Height - 40, 40 * (i + 1), VC_Height);
                View.DrawBitmap(wall[0], RDwall, 1.0f, RD2.BitmapInterpolationMode.Linear);
            }
            for (int i = 0; i < VC_Height / 40 + 1; i++)
            {
                RDM.RawRectangleF RDwall = new RDM.RawRectangleF(0, 40 * i, 40, 40 * (i + 1));
                View.DrawBitmap(wall[0], RDwall, 1.0f, RD2.BitmapInterpolationMode.Linear);
                RDwall = new RDM.RawRectangleF(VC_Width - 40, 40 * i, VC_Width, 40 * (i + 1));
                View.DrawBitmap(wall[0], RDwall, 1.0f, RD2.BitmapInterpolationMode.Linear);
            }
            for (int i = 0; i < heroLocs.Count; i++)
            {
                RDM.RawRectangleF RDhero = new RDM.RawRectangleF(heroLocs[i][0], heroLocs[i][1], heroLocs[i][0] + 40, heroLocs[i][1] + 40);
                View.DrawBitmap(hero[heroLocs[i][2]], RDhero, 1.0f, RD2.BitmapInterpolationMode.Linear);
                RDM.RawRectangleF RDheroShadow = new RDM.RawRectangleF(heroLocs[i][0], heroLocs[i][1] + 2, heroLocs[i][0] + 40 + 2, heroLocs[i][1] + 40 + 2);
                View.DrawBitmap(hero[heroLocs[i][2] + 4], RDheroShadow, 0.15f, RD2.BitmapInterpolationMode.Linear);
            }
            for (int i = 0; i < chestLoc.Count; i++)
            {
                RDM.RawRectangleF RDhero = new RDM.RawRectangleF(chestLoc[i][0], chestLoc[i][1], chestLoc[i][0] + 40, chestLoc[i][1]+ 40);
                View.DrawBitmap(chest[0], RDhero, 1.0f, RD2.BitmapInterpolationMode.Linear);
            }

            RDW.TextFormat TF = new RDW.TextFormat(FY, font, 50);
            RDM.RawRectangleF Loc = new RDM.RawRectangleF(VC_Width-200, 20, VC_Width, VC_Height);
            RDM.RawColor4 PenColor = new RDM.RawColor4(255, 0, 255, 1);
            RD2.SolidColorBrush Pen = new RD2.SolidColorBrush(View, PenColor);
            View.DrawText(getfruitCount*100+"分", TF, Loc, Pen);

            /*   RDW.TextFormat TF = new RDW.TextFormat(FY, font, VC_Width / 10f);
               RDM.RawRectangleF Loc = new RDM.RawRectangleF(VC_Width / 4, VC_Height / 2.8f, VC_Width, VC_Height);
               RDM.RawColor4 PenColor = new RDM.RawColor4(1, 1, 1, 1);
               RD2.SolidColorBrush Pen = new RD2.SolidColorBrush(View, PenColor);
               View.DrawText("fasgfs中", TF, Loc, Pen);*/
            /*      //背景畫面。
                    RDM.RawRectangleF mapsize = new RDM.RawRectangleF(0, 0, VC_Width, VC_Height);
                    View.DrawBitmap(BG[1], mapsize, 1.0f, RD2.BitmapInterpolationMode.Linear);
                    for (int i = 0; i < userFish[0]; i += 2)
                    {
                        //尼莫陰影。
                        RDM.RawRectangleF nemoShadow = new RDM.RawRectangleF(fishLoc[i], fishLoc[i + 1] + 2, fishLoc[i] + 100 + 2, fishLoc[i + 1] + 50 + 2);
                        View.DrawBitmap(fishShadow[0 + Math.Max(fishSwimargss[i] * fishnum, 0)], nemoShadow, 0.15f, RD2.BitmapInterpolationMode.Linear);

                        //尼莫。
                        RDM.RawRectangleF nemo = new RDM.RawRectangleF(fishLoc[i], fishLoc[i + 1], fishLoc[i] + 100, fishLoc[i + 1] + 50);
                        View.DrawBitmap(fish[0 + Math.Max(fishSwimargss[i] * fishnum, 0)], nemo, 1.0f, RD2.BitmapInterpolationMode.Linear);
                    }
                    for (int i = userFish[0]; i < userFish[1]; i += 2)
                    {
                        //朵陰影。
                        RDM.RawRectangleF doryShadow = new RDM.RawRectangleF(fishLoc[i] + 2, fishLoc[i + 1] + 2, fishLoc[i] + 100 + 2, fishLoc[i + 1] + 50 + 2);
                        View.DrawBitmap(fishShadow[1 + Math.Max(fishSwimargss[i] * fishnum, 0)], doryShadow, 0.15f, RD2.BitmapInterpolationMode.Linear);

                        //朵。
                        RDM.RawRectangleF dory = new RDM.RawRectangleF(fishLoc[i], fishLoc[i + 1], fishLoc[i] + 100, fishLoc[i + 1] + 50);
                        View.DrawBitmap(fish[1 + Math.Max(fishSwimargss[i] * fishnum, 0)], dory, 1.0f, RD2.BitmapInterpolationMode.Linear);
                    }
                    RDM.RawRectangleF shopiconsize = new RDM.RawRectangleF(VC_Width / 10.8f, VC_Height / 1.05f, VC_Width / 35.8f, VC_Height / 1.2f);
                    View.DrawBitmap(icon[0], shopiconsize, 1.0f, RD2.BitmapInterpolationMode.Linear);
                    /* 偵錯用
                    RDW.TextFormat TF = new RDW.TextFormat(FY, font, VC_Width / 20f);
                    RDM.RawColor4 PenColor = new RDM.RawColor4(1, 1, 1, 1);
                    RD2.SolidColorBrush Pen = new RD2.SolidColorBrush(View, PenColor);
                    RDM.RawRectangleF Loc = new RDM.RawRectangleF(0, 0, VC_Width, VC_Height);
                    RDM.RawRectangleF Loc2 = new RDM.RawRectangleF(0, 50, VC_Width, VC_Height);
                    RDM.RawRectangleF Loc3 = new RDM.RawRectangleF(0, 100, VC_Width, VC_Height);
                    RDM.RawRectangleF Loc4 = new RDM.RawRectangleF(0, 150, VC_Width, VC_Height);
                    RDM.RawRectangleF Loc5 = new RDM.RawRectangleF(0, 200, VC_Width, VC_Height);
                    RDM.RawRectangleF Loc6 = new RDM.RawRectangleF(0, 250, VC_Width, VC_Height);
                    //View.DrawText(fishSwimargss[0].ToString(), TF, Loc2, Pen);
                    View.DrawText(fishLoc[0].ToString(), TF, Loc, Pen);
                    View.DrawText(fishLoc[1].ToString(), TF, Loc2, Pen);
                    View.DrawText(fishLoc[2].ToString(), TF, Loc3, Pen);
                    View.DrawText(fishLoc[3].ToString(), TF, Loc4, Pen);
                    View.DrawText(fishLoc[4].ToString(), TF, Loc5, Pen);
                    View.DrawText(fishLoc[5].ToString(), TF, Loc6, Pen);*/

        }
        private void displaySetting(RDW.Factory FY, RD2.SolidColorBrush PenShadow)
        {

        }
        private void displayNotice(RDW.Factory FY, RD2.SolidColorBrush PenShadow)
        {
        }

        #endregion

        #region ---------- 載入資源類 ----------

        /// <summary>
        /// 初始化資源。
        /// </summary>
        private void InitRes()
        {
            //將角色加入陣列，好讓程式方便控制。
            Task.Run(() =>
            {
                hero[1] = LoadFromFile(View, Properties.Resources.hero上);
                hero[2] = LoadFromFile(View, Properties.Resources.hero下);
                hero[3] = LoadFromFile(View, Properties.Resources.hero左);
                hero[4] = LoadFromFile(View, Properties.Resources.hero右);
            });
            Task.Run(() =>
            {
                hero[5] = LoadFromFile(View, Properties.Resources.hero2上);
                hero[6] = LoadFromFile(View, Properties.Resources.hero2下);
                hero[7] = LoadFromFile(View, Properties.Resources.hero2左);
                hero[8] = LoadFromFile(View, Properties.Resources.hero2右);
            });
            Task.Run(() =>
            {
                heroShadow[1] = LoadFromFile(View, imageShadow(Properties.Resources.hero上));
                heroShadow[2] = LoadFromFile(View, imageShadow(Properties.Resources.hero下));
                heroShadow[3] = LoadFromFile(View, imageShadow(Properties.Resources.hero左));
                heroShadow[4] = LoadFromFile(View, imageShadow(Properties.Resources.hero右));
            });
            Task.Run(() =>
            {
                heroShadow[5] = LoadFromFile(View, imageShadow(Properties.Resources.hero2上));
                heroShadow[6] = LoadFromFile(View, imageShadow(Properties.Resources.hero2下));
                heroShadow[7] = LoadFromFile(View, imageShadow(Properties.Resources.hero2左));
                heroShadow[8] = LoadFromFile(View, imageShadow(Properties.Resources.hero2右));
            });
            Task.Run(() => {
                music_get = new VorbisWaveReader("audio\\get.ogg");
                music_fail = new VorbisWaveReader("audio\\fail.ogg");
                music_background = new VorbisWaveReader("audio\\background.ogg");
                music_3_2_1 = new AudioFileReader("audio\\3_2_1.wav");
                music_boss = new Mp3FileReader("audio\\boss.mp3");
                waveOut_get.Init(music_get);
                waveOut_fail.Init(music_fail);
                waveOut_background.Init(music_background);
                waveOut_boss.Init(music_boss);
                waveOut_3_2_1.Init(music_3_2_1);
                waveOut_get.Volume = 1;
                waveOut_fail.Volume = 1;
                waveOut_3_2_1.Volume = 1;
                waveOut_background.Volume = 0.5f;
                waveOut_boss.Volume = 0.5f;
            });
            //將背景加入陣列，好讓程式方便控制。
            chest[0] = LoadFromFile(View, Properties.Resources.箱1);
            wall[0] = LoadFromFile(View, Properties.Resources.牆1);
            land[0] = LoadFromFile(View, Properties.Resources.地0);
            land[1] = LoadFromFile(View, Properties.Resources.地1);
            BG[1] = LoadFromFile(View, Properties.Resources.aquarium);

            // 告知遊戲已載入完畢。
            isLoadingFinished = true;
        }
        #endregion

        #region ---------- 遊戲邏輯類 ----------
        private void FruitUpdate()
        {
            if (chestLoc.Count < fruitRequiredCount)
            {
                x = random.Next(40, VC_Width - 80);
                y = random.Next(40, VC_Height - 80);
                for (int i = 0; i < heroLocs.Count; i++)
                {
                    if (x > heroLocs[i][0] - 30 && x < heroLocs[i][0] + 30 && y > heroLocs[i][1] - 30 && x > heroLocs[i][1] - 30)
                    {
                        break;
                    }
                    else if (chestLoc.Count >= fruitRequiredCount)
                    {
                        break;
                    }
                    else if (heroLocs[i][0] == x && heroLocs[i][1] == y)
                    {
                        break;
                    }
                    else
                    {
                        chestLoc.Add(new List<int> { x, y });
                    }
                }
            }
        }

        /// <summary>
        /// 遊戲判斷的主程式。
        /// </summary>
        private void GameLoop()
        {
            while (true)
            {
                Thread.Sleep(10);
                if (mainView == 1)
                {
                    lock (locker)
                    {
                        heroLocTF.Add(heroLocs[0][2]);
                    }
                    switch (heroLocs[0][2])
                    {
                        //heroLoc[0] = 寬
                        //heroLoc[1] = 高
                        // 1上 2下 3左 4右
                        case 1:
                            heroLocs[0][1] = heroLocs[0][1] - speed;
                            if (heroLocs[0][1] < 40)
                                fail();
                            break;
                        case 2:
                            heroLocs[0][1] = heroLocs[0][1] + speed;
                            if (heroLocs[0][1] > VC_Height - 80)
                                fail();
                            break;
                        case 3:
                            heroLocs[0][0] = heroLocs[0][0] - speed;
                            if (heroLocs[0][0] < 40)
                                fail();
                            break;
                        case 4:
                            heroLocs[0][0] = heroLocs[0][0] + speed;
                            if (heroLocs[0][0] > VC_Width - 80)
                                fail();
                            break;
                    }
                    if (heroLocTF.Count<=4)
                    {
                        continue;
                    }
                    for (int i = 1; i < heroLocs.Count; i++)
                    {
                        TFX = 0;
                        TFY = 0;
                        for (int j = 1; j <= 4; j++)
                        {
                            switch (heroLocTF[(heroLocTF.Count - j * i) - 1])
                            {
                                case 1:
                                    TFY += 10;
                                    break; 
                                case 2:
                                    TFY -= 10;
                                    break;
                                case 3:
                                    TFX += 10;
                                    break;
                                case 4:
                                    TFX -= 10;
                                    break;
                            }
                        }
                        heroLocs[i][0] = heroLocs[i-1][0]+ TFX;
                        heroLocs[i][1] = heroLocs[i - 1][1] + TFY;
                        heroLocs[i][2] = heroLocTF[(heroLocTF.Count - 4 * i) - 1];
                        switch (heroLocs[i][2])
                        {
                            case 1:
                                if (heroLocs[i][1] < 40)
                                    fail();
                                break;
                            case 2:
                                if (heroLocs[i][1] > VC_Height - 80)
                                    fail();
                                break;
                            case 3:
                                if (heroLocs[i][0] < 40)
                                    fail();
                                break;
                            case 4:
                                if (heroLocs[i][0] > VC_Width - 80)
                                    fail();
                                break;
                        }
                    }
                    if (heroLocTF.Count>100000)
                    {
                        heroLocTF.RemoveAt(0);
                    }
                    for (int i = 0; i < chestLoc.Count; i++)
                    {
                        if (heroLocs[0][0] < chestLoc[i][0] + 40 && heroLocs[0][1] < chestLoc[i][1] + 40
                            && heroLocs[0][0] + 40 > chestLoc[i][0] && heroLocs[0][1] + 40 > chestLoc[i][1])
                        {
                            getfruit(i);
                        }
                    }
                }
            }
        }
        private void getfruit(int getFruitNumber)
        {
            //heroLoc[0] = 寬
            //heroLoc[1] = 高
            // 1上 2下 3左 4右
            switch (heroLocs[0][2])
            {
                case 1:
                    heroLocs.Add(new List<int>() { heroLocs[heroLocs.Count - 1][0], heroLocs[heroLocs.Count - 1][1] + 40 ,1});
                    break;
                case 2:
                    heroLocs.Add(new List<int>() { heroLocs[heroLocs.Count - 1][0], heroLocs[heroLocs.Count - 1][1] - 40  ,2});
                    break;
                case 3:
                    heroLocs.Add(new List<int>() { heroLocs[heroLocs.Count - 1][0] + 40, heroLocs[heroLocs.Count - 1][1] ,3 });
                    break;
                case 4:
                    heroLocs.Add(new List<int>() { heroLocs[heroLocs.Count - 1][0] - 40, heroLocs[heroLocs.Count - 1][1]  ,4});
                    break;
            }
            getfruitCount++;
            chestLoc.RemoveAt(getFruitNumber);
        }
        private void fail()
        {
            /*    difficultylist.Clear();
             *    difficulty_Add("勇者的女兒", 0.5f, 5, "你贏了", "菜");
             *    difficulty_Add("女高中生", 0.1f, 10, "你贏了", "你輸了");
             *    difficulty_Add("魔女", 0.05f, 20, "你贏了", "你輸了");
             *    difficulty_Add("精靈王", 0.035f, 30, "厲害竟然贏過了精靈王", "你輸了");
             *    difficulty_Add("陰蜂", 0.001f, 100, "原來人類是有辦法贏過陰蜂的嗎", "果然人類是無法戰勝陰蜂的");*/
            switch (difficulty)
            {
                case 1:
                    MessageBox.Show("菜");
                    break;
                case 2:
                    MessageBox.Show("你輸了");
                    break;
                case 3:
                    MessageBox.Show("你輸了");
                    break;
                case 4:
                    MessageBox.Show("你輸了");
                    break;
                case 5:
                    MessageBox.Show("果然人類是無法戰勝陰蜂的");
                    break;
            }
           
            Environment.Exit(0);
        }


        #endregion ---------- 遊戲邏輯類 ----------

        #endregion ////////// 自訂函數區 //////////
    }
}
