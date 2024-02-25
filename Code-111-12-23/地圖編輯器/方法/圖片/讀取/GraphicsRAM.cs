#region using
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SharpDX;
using SharpDX.Direct2D1;
using SharpDX.DXGI;
using Rectangle = System.Drawing.Rectangle;
using PixelFormat = SharpDX.Direct2D1.PixelFormat;
using AlphaMode = SharpDX.Direct2D1.AlphaMode;
namespace 地圖編輯器.方法.圖片.讀取
{
    internal class GraphicsRAM
    {
    }
}
#endregion using
namespace mapMaker
{
    partial class Form1
    {
        /// <summary>
        /// 讀取圖片至視訊記憶體的方法。
        /// </summary>
        /// <param name="renderTarget">顯示於哪裡</param>
        /// <param name="file">圖片來源</param>
        /// <returns>圖片</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        private Bitmap LoadFromFile(RenderTarget renderTarget, System.Drawing.Bitmap file)
        {
            // Loads from file using System.Drawing.Image
            using (System.Drawing.Bitmap bitmap = file)
            {
                int x, y, rgba, offset;
                byte A, B, G, R;
                Rectangle sourceArea = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
                BitmapProperties bitmapProperties = new BitmapProperties(new PixelFormat(Format.R8G8B8A8_UNorm, AlphaMode.Premultiplied));
                Size2 size = new Size2(bitmap.Width, bitmap.Height);

                // Transform pixels from BGRA to RGBA
                int stride = bitmap.Width * sizeof(int);
                using (DataStream tempStream = new DataStream(bitmap.Height * stride, true, true))
                {
                    // Lock System.Drawing.Bitmap
                    BitmapData bitmapData = bitmap.LockBits(sourceArea, ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);

                    // Convert all pixels 
                    for (y = 0; y < bitmap.Height; y++)
                    {
                        offset = bitmapData.Stride * y;
                        for (x = 0; x < bitmap.Width; x++)
                        {
                            // Not optimized 
                            B = Marshal.ReadByte(bitmapData.Scan0, offset++);
                            G = Marshal.ReadByte(bitmapData.Scan0, offset++);
                            R = Marshal.ReadByte(bitmapData.Scan0, offset++);
                            A = Marshal.ReadByte(bitmapData.Scan0, offset++);
                            rgba = R | (G << 8) | (B << 16) | (A << 24);
                            tempStream.Write(rgba);
                        }

                    }
                    bitmap.UnlockBits(bitmapData);
                    tempStream.Position = 0;

                    return new Bitmap(renderTarget, size, tempStream, stride, bitmapProperties);
                }
            }
        }
    }
}