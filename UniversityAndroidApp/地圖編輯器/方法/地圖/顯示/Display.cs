#region using
using System;
using System.Collections;
using SharpDX;
using SharpDX.Direct2D1;
using SharpDX.Mathematics.Interop;
using SharpDX.DirectWrite;
using Factory = SharpDX.DirectWrite.Factory;
using System.Windows.Forms;

namespace 地圖編輯器.方法.地圖.顯示
{
    internal class Display
    {
    }
}
#endregion using
namespace mapMaker
{
    partial class Form1
    {
        private void container_Paint(object sender, PaintEventArgs e)
        {
            views.BeginDraw();
            views.Clear(Color.Black);

            #region 定義字型、顏色、欄、行等參數。
            ushort walk;
            ushort picIndex;

            float size = this.size / 100.0f;
            float fontSize = 12 * size;
            float modeFontSize = 30 * size;
            float shadow = 0.9f * size;
            float p_x, p_x2, p_y, p_y2;

            RawRectangleF picSize;
            RawRectangleF shadowLoc;
            Factory FY = new Factory();
            SolidColorBrush penShadow = new SolidColorBrush(views, new RawColor4(0, 0, 0, 0.35f));
            SolidColorBrush pen = new SolidColorBrush(views, new RawColor4(1, 1, 1, 1));
            SolidColorBrush modePen = new SolidColorBrush(views, new RawColor4(1, 1, 0.6f, 1));
            SolidColorBrush editPen = new SolidColorBrush(views, new RawColor4(1, 0, 0, 1));
            TextFormat textFormat = new TextFormat(FY, "Microsoft JhengHei UI", fontSize);
            TextFormat modeTextFormat = new TextFormat(FY, "Microsoft JhengHei UI", modeFontSize);

            m_col = 1;
            m_row = 1;
            p_col = (short)col;
            p_row = (short)row;

            #endregion 定義字型、顏色、欄、行等參數。

            #region 計算最大與最小欄、行。

            // 當格數大於能顯示時，不要顯示超出可視範圍的格子。
            if (col * width * size > container.Width / size)
            {
                m_col = Convert.ToInt16(Math.Floor((1 - mouseLocArgs.X * dpiF.X) * dpi / width / size));
                if (m_col < 1)
                {
                    m_col = 1;
                }
                p_col = Convert.ToInt16(Math.Floor((container.Width - mouseLocArgs.X * dpiF.Y) * dpi / width / size));
                if (p_col > col)
                {
                    p_col = (short)col;
                }
            }
            if (row * height * size > container.Height / size)
            {
                m_row = Convert.ToInt16(Math.Floor((1 - mouseLocArgs.Y / dpi) * dpi / height / size));
                if (m_row < 1)
                {
                    m_row = 1;
                }
                p_row = Convert.ToInt16(Math.Floor((Height+100 - mouseLocArgs.Y / dpiF.Y) * dpi / height / size));
                if (p_row > row)
                {
                    p_row = (short)row;
                }
            }
            /*
            short coreProcessUnit = (p_col - m_col) / CPUCoreCount;
            short count = 0;
            short[] coreProcessRange = new short[CPUCoreCount * 2];
            for (short i = 1; i < coreProcessRange.Length - 1; i += 2)
            {
                coreProcessRange[i] += coreProcessRange[i - 1] + coreProcessUnit;
                coreProcessRange[i + 1] = coreProcessRange[i] + 1;
            }
            coreProcessRange[0] = 1;
            coreProcessRange[coreProcessRange.Length - 1] = p_col;*/
            #endregion

            #region 顯示。
            for (short x = m_col; x <= p_col; x++)
            {
                p_x = mouseLocArgs.X + x * width * size;
                p_x2 = mouseLocArgs.X + (x + 1) * width * size;

                for (short y = m_row; y <= p_row; y++)
                {
                    p_y = mouseLocArgs.Y + y * height * size;
                    p_y2 = mouseLocArgs.Y + (y + 1) * height * size;
                    picSize = new RawRectangleF(p_x, p_y, p_x2 + 1, p_y2 + 1);

                    #region 背景
                    try
                    {
                        // 背景圖片。
                        if (drawBack)
                        {
                            picIndex = mapBackPic[x - 1, y - 1];
                            views.DrawBitmap(pic[picIndex], picSize, 1.0f, BitmapInterpolationMode.Linear);
                        }
                    }
                    catch
                    {

                    }
                    #endregion 背景

                    #region 前景
                    try
                    {
                        // 前景圖片。
                        if (drawFore)
                        {
                            picIndex = mapForePic[x - 1, y - 1];
                            views.DrawBitmap(pic[picIndex], picSize, 1.0f, BitmapInterpolationMode.Linear);
                        }
                    }
                    catch
                    {

                    }
                    #endregion 前景

                    #region 框線
                    // 框線。
                    shadowLoc = new RawRectangleF(p_x + shadow, p_y + shadow, p_x2 + shadow, p_y2 + shadow);
                    picSize = new RawRectangleF(p_x, p_y, p_x2, p_y2);
                    if (drawRectangle)
                    {
                        views.DrawRectangle(shadowLoc, penShadow, 1);
                        views.DrawRectangle(picSize, pen, 1);
                    }
                    #endregion 框線

                    #region 能否行走
                    try
                    {
                        // 不能行走。
                        if (drawWalk)
                        {
                            walk = 1;
                            if (mapBackWalk[x - 1, y - 1])
                            {
                                walk = 0;
                            }
                            views.DrawBitmap(cannotWalk, picSize, walk - 0.8f, BitmapInterpolationMode.Linear);
                        }
                    }
                    catch
                    {

                    }
                    #endregion 能否行走

                    #region 行號
                    if (x == p_col)
                    {
                        // 行號陰影。
                        RawRectangleF rowShadowLoc = new RawRectangleF(1 + shadow, p_y + shadow, fontSize * 2 + shadow, p_y + fontSize * 2 + shadow);
                        views.DrawText("" + y, textFormat, rowShadowLoc, penShadow);

                        // 行號。
                        RawRectangleF rowLoc = new RawRectangleF(1, p_y, fontSize * 2, p_y + fontSize * 2);
                        views.DrawText("" + y, textFormat, rowLoc, pen);
                    }
                    #endregion 行號
                }

                #region 欄號
                //  欄號陰影。
                RawRectangleF colShadowLoc = new RawRectangleF(p_x + 1 + shadow, shadow, p_x + fontSize * 2 + shadow, fontSize * 2 + shadow);
                views.DrawText("" + x, textFormat, colShadowLoc, penShadow);

                //  欄號。
                RawRectangleF colLoc = new RawRectangleF(p_x + 1, 0, p_x + fontSize * 2, fontSize * 2);
                views.DrawText("" + x, textFormat, colLoc, pen);
                #endregion 欄號
            }

            #region 顯示地圖邊界
            if (drawMapBorder)
            {

            }
            #endregion 顯示地圖邊界

            #region 編輯格特效
            if (editMode)
            {
                float x = editGrid.X1;
                float y = editGrid.Y1;
                float x2 = editGrid.X2;
                float y2 = editGrid.Y2;
                if (x > x2)
                {
                    p_x = mouseLocArgs.X + (x + 1) * width * size;
                    p_x2 = mouseLocArgs.X + x2 * width * size;
                }
                else
                {
                    p_x = mouseLocArgs.X + x * width * size;
                    p_x2 = mouseLocArgs.X + (x2 + 1) * width * size;
                }
                if (y > y2)
                {
                    p_y = mouseLocArgs.Y + (y + 1) * height * size;
                    p_y2 = mouseLocArgs.Y + y2 * height * size;
                }
                else
                {
                    p_y = mouseLocArgs.Y + y * height * size;
                    p_y2 = mouseLocArgs.Y + (y2 + 1) * height * size;
                }
                shadowLoc = new RawRectangleF(p_x + shadow, p_y + shadow, p_x2 + shadow, p_y2 + shadow);
                picSize = new RawRectangleF(p_x, p_y, p_x2, p_y2);
                views.DrawRectangle(shadowLoc, penShadow, 2);
                views.DrawRectangle(picSize, editPen, 2);
            }
            #endregion 編輯格特效

            #region 顯示傳送點
            if (drawTeleport && teleports.Count > 0)
            {
                foreach (var item in teleports)
                {
                    if (item.teleport == 0) continue;

                    ushort x = (ushort)(item.col + 1);
                    ushort y = (ushort)(item.row + 1);
                    p_x = mouseLocArgs.X + x * width * size;
                    p_x2 = mouseLocArgs.X + (x + 1) * width * size;
                    p_y = mouseLocArgs.Y + y * height * size;
                    p_y2 = mouseLocArgs.Y + (y + 1) * height * size;
                    picSize = new RawRectangleF(p_x, p_y, p_x2 + 1, p_y2 + 1);
                    if (x == editGrid.X1 && y == editGrid.Y1 && mode.Equals("編輯傳送點") && editMode)
                        views.DrawBitmap(teleportPic[1], picSize, 1.0f, BitmapInterpolationMode.Linear);
                    else
                        views.DrawBitmap(teleportPic[0], picSize, 1.0f, BitmapInterpolationMode.Linear);
                }
            }
            #endregion 顯示傳送點

            #region 複製的地圖
            if (copyMode)
            {
                short p_col = (short)copyRange.X;
                short p_row = (short)copyRange.Y;
                RawRectangleF pic_Size;
                for (short x = 0; x <= p_col; x++)
                {
                    p_x = copyPicLocRealTime.X * width * size + x * width * size + mouseLocArgs.X % width * size;
                    p_x2 = copyPicLocRealTime.X * width * size + (x + 1) * width * size + mouseLocArgs.X % width * size;

                    for (short y = 0; y <= p_row; y++)
                    {
                        p_y = copyPicLocRealTime.Y * height * size + y * height * size + mouseLocArgs.Y % height * size;
                        p_y2 = copyPicLocRealTime.Y * height * size + (y + 1) * height * size + mouseLocArgs.Y % height * size;
                        pic_Size = new RawRectangleF(p_x, p_y, p_x2 + 1, p_y2 + 1);

                        if (rb_useBack.Checked)
                        {
                            #region 背景
                            try
                            {
                                // 背景圖片。
                                picIndex = mapBackPicCopy[x, y];
                                views.DrawBitmap(pic[picIndex], pic_Size, 0.7f, BitmapInterpolationMode.Linear);
                            }
                            catch
                            {

                            }
                            #endregion 背景
                        }
                        else
                        {
                            #region 前景
                            try
                            {
                                // 前景圖片。
                                picIndex = mapForePicCopy[x, y];
                                views.DrawBitmap(pic[picIndex], pic_Size, 0.7f, BitmapInterpolationMode.Linear);
                            }
                            catch
                            {

                            }
                            #endregion 前景
                        }
                    }
                }
            }
            #endregion 複製的地圖

            #region 模式
            //  模式陰影。
            RawRectangleF modeShadowLoc = new RawRectangleF(10 + shadow, 10 + shadow, 200 + modeFontSize * 2 + shadow, 200 + modeFontSize * 2 + shadow);
            views.DrawText(mode + "模式", modeTextFormat, modeShadowLoc, penShadow);

            //  模式。
            RawRectangleF modeLoc = new RawRectangleF(10, 10, 200 + modeFontSize * 2, 200 + modeFontSize * 2);
            views.DrawText(mode + "模式", modeTextFormat, modeLoc, modePen);
            #endregion 模式

            #endregion 顯示。

            /* 偵錯用。
            RawRectangleF colLoc2 = new RawRectangleF(10, 300, 1000, 1000);
            views.DrawText("m_col: " + m_col + " | p_col: " + p_col + " | m_row: " + m_row + " | p_row: " + p_row + "\nmouseLocArgs.X: " + mouseLocArgs.X + " | mouseLocArgs.Y: " + mouseLocArgs.Y + " | mouseLocMove.X: " + mouseLocMove.X + " | mouseLocMove.Y: " + mouseLocMove.Y, textFormat, colLoc2, pen);
            */
            views.EndDraw();
        }
    }
}