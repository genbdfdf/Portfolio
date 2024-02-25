#region using
using System;
using System.Threading.Tasks;

namespace 地圖編輯器.方法.地圖.產生
{
    internal class Make
    {
    }
}
#endregion using
namespace mapMaker
{
    partial class Form1
    {
        private void tb_col_TextChanged(object sender, EventArgs e)
        {
            tryparse();
        }

        private void tb_row_TextChanged(object sender, EventArgs e)
        {
            tryparse();
        }

        private void tb_pdh_TextChanged(object sender, EventArgs e)
        {
            tryparse();
        }

        private void tb_pdw_TextChanged(object sender, EventArgs e)
        {
            tryparse();
        }

        /// <summary>
        /// 產生地圖陣列。
        /// </summary>
        private void mapCreate()
        {
            ushort row = 300;
            ushort col = 300;
            o_row = row;
            o_col = col;

            Task.Run(() => teleport = new ushort[col, row]);
            Task.Run(() => mapForePic = new ushort[col, row]);
            Task.Run(() =>
            {
                mapBackWalk = new bool[col, row];
                for (int i = 0; i < col; i++)
                    for (int j = 0; j < row; j++)
                        mapBackWalk[i, j] = true;
            });/*
            Task.Run(() => mapBorderCol = new Point[300]);
            Task.Run(() => mapBorderRow = new Point[300]);*/
            mapBackPic = new ushort[col, row];
        }



        /// <summary>
        /// 產生新的陣列並複製內容。
        /// </summary>
        private void mapReCreate()
        {
            if (row > o_row || col > o_col)
            {
                row = Math.Max(row, o_row);
                col = Math.Max(col, o_col);
                ushort[,] tempFore = new ushort[col, row];

                #region 複製新的顯示用之判斷背景是否能行走

                Task.Run(() =>
                {
                    bool[,] temp = new bool[col, row];

                    // 複製到暫存陣列。
                    for (short i = 0; i < col; i++)
                    {
                        for (short j = 0; j < row; j++)
                        {
                            try
                            {
                                temp[i, j] = mapBackWalk[i, j];
                            }
                            catch
                            {

                            }
                        }
                    }

                    mapBackWalk = new bool[col, row];

                    // 複製回來。
                    for (short i = 0; i < col; i++)
                    {
                        for (short j = 0; j < row; j++)
                        {
                            try
                            {
                                mapBackWalk[i, j] = temp[i, j];
                            }
                            catch
                            {

                            }
                        }
                    }
                });

                #endregion 複製新的顯示用之判斷背景是否能行走

                #region 複製新的背景圖

                Task.Run(() =>
                {
                    ushort[,] tempBack = new ushort[col, row];

                    // 複製背景到暫存陣列。
                    for (short i = 0; i < col; i++)
                    {
                        for (short j = 0; j < row; j++)
                        {
                            try
                            {
                                tempBack[i, j] = mapBackPic[i, j];
                            }
                            catch
                            {

                            }
                        }
                    }

                    mapBackPic = new ushort[col, row];

                    // 複製回來。
                    for (short i = 0; i < col; i++)
                    {
                        for (short j = 0; j < row; j++)
                        {
                            try
                            {
                                mapBackPic[i, j] = tempBack[i, j];
                            }
                            catch
                            {

                            }
                        }
                    }
                });

                #endregion 複製新的背景圖

                #region 複製新的前景圖

                // 複製前景到暫存陣列。
                for (short i = 0; i < col; i++)
                {
                    for (short j = 0; j < row; j++)
                    {
                        try
                        {
                            tempFore[i, j] = mapForePic[i, j];
                        }
                        catch
                        {

                        }
                    }
                }

                mapForePic = new ushort[col, row];

                // 複製回來。
                for (short i = 0; i < col; i++)
                {
                    for (short j = 0; j < row; j++)
                    {
                        try
                        {
                            mapForePic[i, j] = tempFore[i, j];
                        }
                        catch
                        {

                        }
                    }
                }
                #endregion 複製新的前景圖

                o_row = row;
                o_col = col;
            }

            container.Refresh();
        }
    }
}