#region using
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using 函式庫.資料表;

namespace 地圖編輯器.方法.地圖.修改
{
    internal class Edit
    {
    }
}
#endregion using
namespace mapMaker
{
    partial class Form1
    {
        private void container_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLoc = e.Location;
            mouseLocMove = e.Location;
            switch (e.Button)
            {
                #region 左鍵
                case MouseButtons.Left:
                    isFill = true;
                    break;
                #endregion 左鍵

                #region 右鍵
                case MouseButtons.Right:
                    Task.Run(() =>
                    {
                        try
                        {
                            // 計算是按在哪一格上。
                            ushort col = Convert.ToUInt16(Math.Floor((e.X / (Width / x) - mouseLocArgs.X / dpi) * dpi / width / (size / 100.0f)));
                            ushort row = Convert.ToUInt16(Math.Floor((e.Y / (Height / y) - mouseLocArgs.Y / dpi) * dpi / height / (size / 100.0f)));
                            if (m_col - 1 < col && col <= p_col && m_row - 1 < row && row <= p_row)
                            {
                                if (mode.Equals("編輯傳送點"))
                                {
                                    // 放開才做事。
                                }
                                else
                                {
                                    editGrid.X1 = col;
                                    editGrid.Y1 = row;
                                    editGrid.X2 = col;
                                    editGrid.Y2 = row;
                                    editMode = true;
                                }
                                container.Refresh();
                            }
                        }
                        catch (Exception se)
                        {
#if DEBUG
                            Debug.WriteLine(se);
#endif
                        }
                    });
                    break;
                    #endregion 右鍵
            }
        }



        /// <summary>
        /// 填充方塊。
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        private void map_Fill(MouseEventArgs e)
        {
            if (isFill)
            {
                try
                {
                    ushort col;
                    ushort row;
                    ushort col2;
                    ushort row2;
                    if (editMode && pressAltKey && !copyMode)
                    {
                        col = (ushort)(editGrid.X1 - 1);
                        row = (ushort)(editGrid.Y1 - 1);
                        col2 = editGrid.X2;
                        row2 = editGrid.Y2;
                    }
                    else if (copyMode)
                    {
                        col = (ushort)(copyPicLocRealTime.X - 1 - (mouseLocArgs.X / dpi / width * dpi));
                        row = (ushort)(copyPicLocRealTime.Y - 1 - (mouseLocArgs.Y / dpi / height * dpi));
                        col2 = (ushort)(copyPicLocRealTime.X + copyRange.X - 1 - (mouseLocArgs.X / dpi / width * dpi));
                        row2 = (ushort)(copyPicLocRealTime.Y + copyRange.Y - 1 - (mouseLocArgs.Y / dpi / height * dpi));
                    }
                    else
                    {
                        // 計算是按在哪一格上。
                        col = (ushort)((ushort)Math.Floor((e.X / (Width / x) - mouseLocArgs.X / dpi) * dpi / width / (size / 100.0f)) - 1);
                        row = (ushort)((ushort)Math.Floor((e.Y / (Height / y) - mouseLocArgs.Y / dpi) * dpi / height / (size / 100.0f)) - 1);
                        col2 = (ushort)(col + 1);
                        row2 = (ushort)(row + 1);
                    }

                    if (copyMode)
                    {
                        short a, b;
                        // 如果目標是前景。
                        if (rb_useFore.Checked)
                        {
                            // 按的位置要在格子內才繪製。
                            if (m_col - 2 < col && col < p_col && m_row - 2 < row && row < p_row)
                            {
                                a = 0;
                                bool refresh = false;
                                for (ushort x = col; x < col2; x++)
                                {
                                    b = 0;
                                    for (ushort y = row; y < row2; y++)
                                    {
                                        if (mapForePic[x, y] != mapForePicCopy[a, b])
                                        {
                                            mapForePic[x, y] = mapForePicCopy[a, b];
                                            refresh = true;
                                        }
                                        b++;
                                    }
                                    a++;
                                }
                                if (refresh)
                                {
                                    Task.Run(() => container.Refresh());
                                }
                            }
                        }
                        // 否則就是背景。
                        else
                        {
                            // 按的位置要在格子內才繪製。
                            if (m_col - 2 < col && col < p_col && m_row - 2 < row && row < p_row)
                            {
                                a = 0;
                                bool refresh = false;
                                for (ushort x = col; x < col2; x++)
                                {
                                    b = 0;
                                    for (ushort y = row; y < row2; y++)
                                    {
                                        refresh = mapBackWalk[x, y];
                                        if (mapBackPic[x, y] != mapBackPicCopy[a, b])
                                        {
                                            mapBackPic[x, y] = mapBackPicCopy[a, b];
                                            refresh = true;
                                        }
                                        b++;
                                    }
                                    a++;
                                }
                                if (refresh)
                                {
                                    Task.Run(() => container.Refresh());
                                }
                            }
                        }
                    }
                    else
                    {
                        // 如果目標是前景。
                        if (rb_useFore.Checked)
                        {
                            // 按的位置要在格子內才繪製。
                            if (m_col - 2 < col && col < p_col && m_row - 2 < row && row < p_row)
                            {
                                bool refresh = false;
                                for (ushort x = col; x < col2; x++)
                                {
                                    for (ushort y = row; y < row2; y++)
                                    {
                                        if (mapForePic[x, y] != (ushort)lv_image.SelectedItems[0].Index)
                                        {
                                            mapForePic[x, y] = (ushort)lv_image.SelectedItems[0].Index;
                                            refresh = true;
                                        }
                                    }
                                }
                                if (refresh)
                                {
                                    Task.Run(() => container.Refresh());
                                }
                            }
                        }
                        // 否則就是背景。
                        else
                        {
                            // 按的位置要在格子內才繪製。
                            if (m_col - 2 < col && col < p_col && m_row - 2 < row && row < p_row)
                            {
                                bool refresh = false;
                                for (ushort x = col; x < col2; x++)
                                {
                                    for (ushort y = row; y < row2; y++)
                                    {
                                        if (mode.Equals("編輯牆壁"))
                                        {
                                            if (mapBackWalk[x, y])
                                                mapBackWalk[x, y] = false;
                                            else
                                                mapBackWalk[x, y] = true;
                                            refresh = true;
                                        }
                                        else if (mode.Equals("編輯傳送點"))
                                        {
                                            if (teleport[x, y] > 0)
                                            {
                                                //teleport[x, y] = 0;
                                            }
                                            else
                                            {
                                                editGrid.X1 = (ushort)(x + 1);
                                                editGrid.Y1 = (ushort)(y + 1);
                                                editGrid.X2 = (ushort)(x + 1);
                                                editGrid.Y2 = (ushort)(y + 1);
                                                editMode = true; 
                                                ShowTeleportList();
                                                BeginInvoke(new Action(() =>
                                                {
                                                    bt_gridSetting.Text = "︾";
                                                    pl_gridSetting.Visible = true;
                                                    lb_gridSetting.Visible = true;
                                                    comboBox_newtpLoction.DroppedDown = true;
                                                }));
                                                refresh = true;
                                            }
                                        }
                                        else if (mode.Equals("編輯地圖") && mapBackPic[x, y] != (ushort)lv_image.SelectedItems[0].Index)
                                        {
                                            mapBackPic[x, y] = (ushort)lv_image.SelectedItems[0].Index;
                                            refresh = true;
                                        }
                                    }
                                }
                                if (refresh)
                                {
                                    Task.Run(() => container.Refresh());
                                }
                            }
                        }
                    }
                }
                catch (Exception se)
                {
#if DEBUG
                    Debug.WriteLine(se);
#endif
                }
            }
        }
        private void container_MouseUp(object sender, MouseEventArgs e)
        {
            container.Cursor = Cursors.Default;
            switch (e.Button)
            {
                #region 左鍵

                case MouseButtons.Left:
                    if (editMode && isFill && !pressAltKey && !copyMode)
                    {
                        editMode = false;
                    }
                    else
                    {
                        map_Fill(e);
                    }
                    break;

                #endregion 左鍵

                #region 滾輪鍵

                case MouseButtons.Middle:
                    mouseLocArgs = Point.Empty;
                    break;

                #endregion 滾輪鍵

                #region 右鍵

                case MouseButtons.Right:
                    Task.Run(() =>
                    {
                        try
                        {
                            // 計算是按在哪一格上。
                            ushort col = Convert.ToUInt16(Math.Floor((e.X / (Width / x) - mouseLocArgs.X / dpi) * dpi / width / (size / 100.0f)));
                            ushort row = Convert.ToUInt16(Math.Floor((e.Y / (Height / y) - mouseLocArgs.Y / dpi) * dpi / height / (size / 100.0f)));
                            if (m_col - 1 < col && col <= p_col && m_row - 1 < row && row <= p_row)
                            {
                                if (mode.Equals("編輯傳送點"))
                                {
                                    editGrid.X1 = col;
                                    editGrid.Y1 = row;
                                    editGrid.X2 = col;
                                    editGrid.Y2 = row;
                                    editMode = true;
                                    ShowTeleportList();
                                    BeginInvoke(new Action(() =>
                                    {
                                        bt_gridSetting.Text = "︾";
                                        pl_gridSetting.Visible = true;
                                        lb_gridSetting.Visible = true;
                                        comboBox_newtpLoction.DroppedDown = true;
                                    }));
                                }
                                container.Refresh();
                            }
                        }
                        catch (Exception se)
                        {
#if DEBUG
                            Debug.WriteLine(se);
#endif
                        }
                    });
                    break;

                    #endregion 右鍵
            }
            isFill = false;
            container.Refresh();
        }
        private void container_MouseMove(object sender, MouseEventArgs e)
        {
            if (copyMode)
            {
                Point Point = copyPicLocRealTime;
                copyPicLocRealTime.X = Convert.ToInt16(Math.Floor(mouseLocRealTime.X * dpi)) / (short)width;
                copyPicLocRealTime.Y = Convert.ToInt16(Math.Floor(mouseLocRealTime.Y * dpi)) / (short)height;
                if (Point != copyPicLocRealTime)
                    container.Refresh();
            }
            mouseLocRealTime = e.Location;
            switch (e.Button)
            {
                #region 左鍵
                case MouseButtons.Left:
                    if (pressAltKey)
                    {
                        Task.Run(() => map_Fill(e));
                    }
                    else
                    {
                        mouseLocArgs.X -= Convert.ToInt16((mouseLoc.X - e.Location.X) / dpi);
                        mouseLocArgs.Y -= Convert.ToInt16((mouseLoc.Y - e.Location.Y) / dpi);
                        mouseLoc = e.Location;

                        float size = this.size / 100.0f;
                        int min_width = -Convert.ToInt32(col * width * size);
                        int max_width = Convert.ToInt32(container.Width * dpi - width * 2 * size);
                        int min_height = -Convert.ToInt32(row * height * size);
                        int max_height = Convert.ToInt32(container.Height * dpi - height * 2 * size);

                        if (mouseLocArgs.X > max_width)
                        {
                            mouseLocArgs.X = max_width;
                        }
                        else if (mouseLocArgs.X < min_width)
                        {
                            mouseLocArgs.X = min_width;
                        }

                        if (mouseLocArgs.Y > max_height)
                        {
                            mouseLocArgs.Y = max_height;
                        }
                        else if (mouseLocArgs.Y < min_height)
                        {
                            mouseLocArgs.Y = min_height;
                        }
                        if (Math.Abs((e.Location.X - mouseLocMove.X) / dpi) > container.Width * size / 40)
                        {
                            isFill = false;
                            container.Cursor = Cursors.Hand;
                        }
                        else if (Math.Abs((e.Location.Y - mouseLocMove.Y) / dpi) > container.Height * size / 40)
                        {
                            isFill = false;
                            container.Cursor = Cursors.Hand;
                        }
                        container.Refresh();
                    }
                    break;
                #endregion 左鍵

                #region 右鍵
                case MouseButtons.Right:
                    try
                    {
                        // 計算是按在哪一格上。
                        short col = Convert.ToInt16(Math.Floor((e.X / (Width / x) - mouseLocArgs.X / dpi) * dpi / width / (size / 100.0f)));
                        short row = Convert.ToInt16(Math.Floor((e.Y / (Height / y) - mouseLocArgs.Y / dpi) * dpi / height / (size / 100.0f)));

                        #region 判斷有沒有超出邊界
                        if (1 > col)
                        {
                            col = 1;
                        }
                        else if (col > p_col)
                        {
                            col = (short)this.col;
                        }
                        if (1 > row)
                        {
                            row = 1;
                        }
                        else if (row > p_row)
                        {
                            row = (short)this.row;
                        }
                        #endregion 判斷有沒有超出邊界

                        if (mode.Equals("編輯傳送點"))
                        {

                        }
                        else
                        {
                            Points points = new Points
                            {
                                X2 = (ushort)col,
                                Y2 = (ushort)row
                            };
                            if (points.X2 != editGrid.X2 || points.Y2 != editGrid.Y2)
                            {
                                editGrid.X2 = points.X2;
                                editGrid.Y2 = points.Y2;
                                container.Refresh();
                            }
                        }
                    }
                    catch
                    {

                    }
                    break;
                    #endregion 右鍵
            }
        }
    }
}