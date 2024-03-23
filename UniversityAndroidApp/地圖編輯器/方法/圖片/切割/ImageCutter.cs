#region using
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 地圖編輯器.方法.圖片.切割
{
    internal class ImageCutter
    {
    }
}
#endregion
namespace mapMaker
{
    partial class Form1
    {
        class ImageCutterConfig
        {   /// <summary>
            /// MIME型別，如果用“image/jpeg”切割後的圖片會模糊，目前還不知道為啥
            /// </summary>
            public const string mimeType = @"image/png"; //@"image/jpeg";//
        }
        /// <summary>
        /// 圖形切割配置
        /// </summary>
        public class GridData
        {
            /// <summary>
            /// 原始圖片的檔案
            /// </summary>
            public string SrcFileName = @"C:\Users\student\Downloads\a\fb05.png";
            /// <summary>
            /// 切割後的圖片輸出目錄
            /// </summary>
            public string OutDirectory = @"C:\Users\student\Downloads\a\";
            /// <summary>
            /// 圖片寬度
            /// </summary>
            public int ImageWidth = 400;
            /// <summary>
            /// 圖片高度
            /// </summary>
            public int ImageHeight = 400;
            /// <summary>
            /// 格子寬度
            /// </summary>
            public int GridWidth = 32;
            /// <summary>
            /// 格子高度
            /// </summary>
            public int GridHeight = 32;
            /// <summary>
            /// 切片檔案字首
            /// </summary>
            public string titlePrefixName = "fb05";
            /// <summary>
            /// 切片副檔名
            /// </summary>
            public string expandedName = @".png";
        }
        /// <summary>
        /// 圖片切割工具引數
        /// </summary>
        class ToolParam
        {
            public Image srcImage;
            public GridData imageData;
            public ImageCodecInfo codecInfo;
            public EncoderParameters encoderParams;
            public int columnNum;
            public int rowNum;

            public int columnIndex;
            public int rowIndex;

            public ToolParam(Image srcImage, GridData imageData, ImageCodecInfo codecInfo, EncoderParameters encoderParams, int columnNum, int rowNum)
            {
                this.srcImage = srcImage;
                this.imageData = imageData;
                this.codecInfo = codecInfo;
                this.encoderParams = encoderParams;
                this.columnNum = columnNum;
                this.rowNum = rowNum;
                RefreshIndex(0, 0);
            }
            public void RefreshIndex(int columnIndex, int rowIndex)
            {
                this.columnIndex = columnIndex;
                this.rowIndex = rowIndex;
            }
        }
        class ImageCutterTool
        {
            /// <summary>
            /// 切割圖片並儲存
            /// </summary>
            /// <param name="data"></param>
            public static cutImageStruct SaveSlice(ToolParam data)
            {
                int index = data.rowIndex * data.columnNum + data.columnIndex + 1;
                int w = data.imageData.GridWidth;
                int h = data.imageData.GridHeight;
                int x = data.columnIndex * data.imageData.GridWidth;
                int y = data.rowIndex * data.imageData.GridHeight;
                if ((data.columnIndex + 1) * data.imageData.GridWidth > data.srcImage.Width)
                {
                    w = data.srcImage.Width - data.columnIndex * data.imageData.GridWidth;
                }
                if ((data.rowIndex + 1) * data.imageData.GridHeight > data.srcImage.Height)
                {
                    h = data.srcImage.Height - data.rowIndex * data.imageData.GridHeight;
                }
                Bitmap destBitMap = new Bitmap(w, h, PixelFormat.Format24bppRgb);
                string name = data.imageData.titlePrefixName + "_" + (data.rowIndex + 1) + "Z" + (data.columnIndex + 1) + data.imageData.expandedName;
                using (Graphics g = Graphics.FromImage(destBitMap))
                {
                    g.Clear(Color.Transparent);
                    g.DrawImage(data.srcImage, new Rectangle(0, 0, w, h), x, y, w, h, GraphicsUnit.Pixel);
                    //destBitMap.Save(name, data.codecInfo, data.encoderParams);
                }
                return new cutImageStruct(name, destBitMap);
            }
            /// <summary>
            /// 獲取影象編解碼器
            /// </summary>
            /// <param name="mimeType">MIME型別</param>
            /// <returns></returns>
            public static ImageCodecInfo GetEncodeInfo(string mimeType)
            {
                ImageCodecInfo[] infos = ImageCodecInfo.GetImageEncoders();
                for (int i = 0, iMax = infos.Length; i < iMax; ++i)
                {
                    ImageCodecInfo info = infos[i];
                    if (mimeType == info.MimeType)
                    {
                        return info;
                    }
                }
                return null;
            }
        }
    }
}