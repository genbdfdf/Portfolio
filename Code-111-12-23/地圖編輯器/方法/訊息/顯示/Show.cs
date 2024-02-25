#region using
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace 地圖編輯器.方法.訊息.顯示
{
    internal class Show
    {
    }
}
#endregion using
namespace mapMaker
{
    partial class Form1
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        private void ShowMSG(string MSG)
        {
            lb_MSG.ForeColor = Color.LightGreen;
            pl_MSG.BackColor = Color.Black;
            lb_MSG.Text = MSG;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        private void ShowSuccessMSG(string MSG)
        {
            lb_MSG.ForeColor = Color.Green;
            pl_MSG.BackColor = Color.Transparent;
            lb_MSG.Text = "✅" + MSG;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        private void ShowSuccessMSG(string MSG, bool needBack)
        {
            lb_MSG.ForeColor = Color.LightGreen;
            pl_MSG.BackColor = Color.Black;
            lb_MSG.Text = "✅" + MSG;
            CallMSGbackactive();
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        private void ShowErrorMSG(string MSG)
        {
            lb_MSG.ForeColor = Color.Red;
            pl_MSG.BackColor = Color.Black;
            lb_MSG.Text = "❌" + MSG;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        private void ShowWarningMSG(string MSG)
        {
            lb_MSG.ForeColor = Color.Yellow;
            pl_MSG.BackColor = Color.Black;
            lb_MSG.Text = "⚠️" + MSG;
        }
    }
}