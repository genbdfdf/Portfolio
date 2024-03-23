using SharpDX.Direct2D1;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using RD = SharpDX;
using RD2 = SharpDX.Direct2D1;
using RDM = SharpDX.Mathematics.Interop;
using RDW = SharpDX.DirectWrite;
using RDX = SharpDX.DXGI;

namespace Rwork2
{
    public partial class FormStart : Form
    {
        RD2.WindowRenderTarget View;
        int FPS = 13;

        int VC_Width;
        int VC_Height;

        bool isLoadingFinished;

        float dpi;
        float WelcomeText1Color = 0f;

        string font = "Lolita";
        RDM.RawVector2 start;
        RDM.RawVector2 end;
        RD2.Bitmap title;

        public FormStart()
        {
            InitializeComponent();
           
        }

        private void FormStart_Load(object sender, EventArgs e)
        {
            int x = (SystemInformation.WorkingArea.Width - this.Size.Width) / 2;
            int y = (SystemInformation.WorkingArea.Height - this.Size.Height) / 2;
            StartPosition = FormStartPosition.Manual; //窗體的位置由Location屬性決定
            Location = (Point)new Size(x, y);
            Program.formLogin.Hide();
         
            string myself = Assembly.GetExecutingAssembly().Location;
            string date = File.GetLastWriteTime(myself).ToString("yyyy/MM/dd");
            Text = $"二君股份有限公司高雄區紅豆餅販賣中心 - {date}";
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
            start = new RDM.RawVector2(VC_Width / 4, VC_Height / 1.1f);
            end = new RDM.RawVector2(VC_Width / 4, VC_Height / 1.1f);
            title = LoadFromFile(View, Properties.Resources.a);
            //啟動畫面彩現，使畫面輸出。
            Thread th_render = new Thread(refresh);
            th_render.IsBackground = true;
            th_render.Start();
        }

        #region ========== 視窗 ==========
        private void container_Paint(object sender, PaintEventArgs e)
        {
            display();
        }

        private void FormStart_Resize(object sender, EventArgs e)
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

        #region ========== 顯示 ==========

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
            View.BeginDraw();
            View.Clear(RD.Color.Transparent);
            // 顯示畫面。
            displayLoading(FY);
            View.EndDraw();
        }

        private void displayLoading(RDW.Factory FY)
        {
            if (isLoadingFinished)
            {
                if (WelcomeText1Color > 0)
                {
                    WelcomeText1Color -= 0.010f;
                }
                if (WelcomeText1Color < 0)
                {
                    Close();
                    Program.formLogin.Show();
                }
            }
            else
            {
                if (WelcomeText1Color < 1.0f)
                {
                    WelcomeText1Color += 0.010f;
                    end.X += VC_Width/(1/0.010f)/2;
                }
                if (WelcomeText1Color > 1.0)
                {
                    isLoadingFinished = true;
                }
            }
            RDM.RawRectangleF RDwall = new RDM.RawRectangleF(VC_Width / 4, VC_Height / 5, VC_Width  - VC_Width / 4, VC_Height / 1.6f);
            View.DrawBitmap(title, RDwall, WelcomeText1Color, RD2.BitmapInterpolationMode.Linear);

            RDW.TextFormat TF = new RDW.TextFormat(FY, font, VC_Width / 10f);
            RDM.RawRectangleF Loc = new RDM.RawRectangleF(VC_Width / 4, VC_Height / 1.5f, VC_Width, VC_Height);
            RDM.RawColor4 PenColor = new RDM.RawColor4(1, 1, 1, WelcomeText1Color);
            RD2.SolidColorBrush Pen = new RD2.SolidColorBrush(View, PenColor);
            View.DrawText("程式讀取中", TF, Loc, Pen);

            RD2.SolidColorBrush ToTitlePen = new RD2.SolidColorBrush(View, new RDM.RawColor4(255, 255, 255, WelcomeText1Color));
            View.DrawLine(start, end, ToTitlePen,30);


        }
        #endregion

        private RD2.Bitmap LoadFromFile(RD2.RenderTarget renderTarget, System.Drawing.Bitmap file)
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
                    var bitmapData = bitmap.LockBits(sourceArea, ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);

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
    }
}
