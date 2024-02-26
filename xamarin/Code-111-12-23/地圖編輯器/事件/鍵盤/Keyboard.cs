#region using
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace 地圖編輯器.事件.鍵盤
{
    internal class Keyboard
    {
    }
}
#endregion using
namespace mapMaker
{
    partial class Form1
    {
        #region 按下
        private void hook_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                #region Alt 鍵
                case Keys.LMenu:
                    pressAltKey = true;
                    break;
                case Keys.RMenu:
                    pressAltKey = true;
                    break;
                #endregion Alt 鍵

                #region Ctrl 鍵
                case Keys.LControlKey:
                    pressCtrlKey = true;
                    break;
                case Keys.RControlKey:
                    pressCtrlKey = true;
                    break;
                #endregion Ctrl 鍵

                #region Shift 鍵
                case Keys.LShiftKey:
                    pressShiftKey = true;
                    switch (mode)
                    {
                        case "編輯地圖":
                            mode = "編輯牆壁";
                            break;
                        case "編輯牆壁":
                            mode = "編輯傳送點";
                            break;
                        case "編輯傳送點":
                            mode = "編輯地圖";
                            break;
                    }
                    editMode = false;
                    container.Refresh();
                    break;
                case Keys.RShiftKey:
                    pressShiftKey = true;
                    switch(mode)
                    {
                        case "編輯地圖":
                            mode = "編輯牆壁";
                            break;
                        case "編輯牆壁":
                            mode = "編輯傳送點";
                            break;
                        case "編輯傳送點":
                            mode = "編輯地圖";
                            break;
                    }
                    editMode = false;
                    container.Refresh();
                    break;
                #endregion Shift 鍵

                #region Delete 鍵
                case Keys.Delete:
                    if (editMode)
                    {
                        Task.Run(() =>
                        {
                            for (short x = (short)(editGrid.X1 - 1); x < editGrid.X2; x++)
                            {
                                for (short y = (short)(editGrid.Y1 - 1); y < editGrid.Y2; y++)
                                {
                                    mapBackPic[x, y] = 0;
                                    mapForePic[x, y] = 0;
                                }
                            }
                            container.Refresh();
                        });
                    }
                    break;
                #endregion Delete 鍵

                #region ESC 鍵
                case Keys.Escape:
                    if (copyMode)
                    {
                        copyMode = false;
                        Task.Run(() => container.Refresh());
                    }
                    break;
                #endregion ESC 鍵

                #region C 鍵
                case Keys.C:
                    CopyMap(false);
                    break;
                #endregion C 鍵

                #region S 鍵
                case Keys.S:
                    if (pressCtrlKey)
                    {
                        Task.Run(() => SaveMap());
                    }
                    break;
                #endregion S 鍵

                #region X 鍵
                case Keys.X:
                    CopyMap(true);
                    break;
                #endregion X 鍵

                #region Z 鍵
                case Keys.Z:
                    if (pressCtrlKey)
                    {

                    }
                    break;
                    #endregion Z 鍵
            }
        }
        #endregion 按下

        #region 放開
        private void hook_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                #region Alt 鍵
                case Keys.LMenu:
                    pressAltKey = false;
                    break;
                case Keys.RMenu:
                    pressAltKey = false;
                    break;
                #endregion Alt 鍵

                #region Ctrl 鍵
                case Keys.LControlKey:
                    pressCtrlKey = false;
                    break;
                case Keys.RControlKey:
                    pressCtrlKey = false;
                    break;
                #endregion Ctrl 鍵

                #region Shift 鍵
                case Keys.LShiftKey:
                    pressShiftKey = false;
                    break;
                case Keys.RShiftKey:
                    pressShiftKey = false;
                    break;
                    #endregion Shift 鍵

            }
        }
        #endregion 放開

        #region 啟動監聽
        private void startListen()
        {
            myKeyDownEventHandeler = new KeyEventHandler(hook_KeyDown);
            myKeyUpEventHandeler = new KeyEventHandler(hook_KeyUp);
            k_hook.KeyDownEvent += myKeyDownEventHandeler;//鉤住鍵按下
            k_hook.KeyUpEvent += myKeyUpEventHandeler;//鉤住鍵按下
            k_hook.Start();//安裝鍵盤鉤子
        }
        #endregion 啟動監聽

        #region 關閉視窗停止監聽
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (myKeyDownEventHandeler != null || myKeyUpEventHandeler != null)
            {
                k_hook.KeyDownEvent -= myKeyDownEventHandeler;//取消按鍵事件
                k_hook.KeyUpEvent -= myKeyUpEventHandeler;//取消按鍵事件
                myKeyDownEventHandeler = null;
                myKeyUpEventHandeler = null;
                k_hook.Stop();//關閉鍵盤鉤子
            }
            using (StreamWriter sw = new StreamWriter("status"))
            {
                if (importing)
                    sw.WriteLine("1");
                else if(importFin)
                    sw.WriteLine("2");
                else
                {
                    sw.WriteLine("0");
                    File.Delete("list");
                }
            }
        }
        #endregion 關閉視窗停止監聽
    }
}