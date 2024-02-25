#region using
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 地圖編輯器.方法.地圖.複製
{
    internal class Copy
    {
    }
}
#endregion using
namespace mapMaker
{
    partial class Form1
    {
        private void CopyMap(bool Iscut)
        {
            if (pressCtrlKey && editMode)
            {
                copyMode = true;
                Task.Run(() =>
                {
                    ushort col = (ushort)(Math.Abs(editGrid.X1 - editGrid.X2) + 1);
                    ushort row = (ushort)(Math.Abs(editGrid.Y1 - editGrid.Y2) + 1);
                    copyRange = new Point((short)col, (short)row);
                    ushort x, y, x2, y2;
                    if (editGrid.X1 > editGrid.X2)
                    {
                        x = (ushort)(editGrid.X2 - 1);
                        x2 = editGrid.X1;
                    }
                    else
                    {
                        x = (ushort)(editGrid.X1 - 1);
                        x2 = editGrid.X2;
                    }
                    if (editGrid.Y1 > editGrid.Y2)
                    {
                        y = (ushort)(editGrid.Y2 - 1);
                        y2 = editGrid.Y1;
                    }
                    else
                    {
                        y = (ushort)(editGrid.Y1 - 1);
                        y2 = editGrid.Y2;
                    }
                    if (rb_useFore.Checked)
                    {
                        mapForePicCopy = new ushort[col, row];
                        ushort a = 0;
                        ushort b = 0;
                        for (ushort i = x; i < x2; i++)
                        {
                            b = 0;
                            for (ushort j = y; j < y2; j++)
                            {
                                mapForePicCopy[a, b++] = mapForePic[i, j];
                            }
                            a++;
                        }
                    }
                    else
                    {
                        mapBackPicCopy = new ushort[col, row];
                        ushort a = 0;
                        ushort b = 0;
                        for (ushort i = x; i < x2; i++)
                        {
                            b = 0;
                            for (ushort j = y; j < y2; j++)
                            {
                                mapBackPicCopy[a, b++] = mapBackPic[i, j];
                            }
                            a++;
                        }
                    }
                    copyPicLocRealTime.X = Convert.ToInt16(Math.Floor(mouseLocRealTime.X * dpi)) / (short)width;
                    copyPicLocRealTime.Y = Convert.ToInt16(Math.Floor(mouseLocRealTime.Y * dpi)) / (short)height;
                    if(Iscut)
                    {
                        if (rb_useFore.Checked)
                        {
                            for (; x < x2; x++)
                            {
                                for (; y < y2; y++)
                                {
                                    mapForePic[x, y] = 0;
                                }
                            }
                        }
                        else
                        {
                            for (; x < x2; x++)
                            {
                                for (; y < y2; y++)
                                {
                                    mapBackPic[x, y] = 0;
                                }
                            }
                        }
                    }
                    container.Refresh();
                });
            }
        }
    }
}