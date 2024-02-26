#region using
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace 地圖編輯器.方法.判斷.型別.數字
{
    internal class Number
    {
    }
}
#endregion using
namespace mapMaker
{
    partial class Form1
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        /// <summary>
        /// 偵測是否輸入為數字
        /// </summary>
        private bool tryparse()
        {
            bool heightbool = ushort.TryParse(tb_height.Text, out height);
            bool widthbool = ushort.TryParse(tb_width.Text, out width);
            bool colbool = ushort.TryParse(tb_col.Text, out col);
            bool rowbool = ushort.TryParse(tb_row.Text, out row);
            if (heightbool && widthbool && colbool && rowbool)
            {
                Task.Run(mapReCreate);
                return true;
            }
            else
            {
                container.Refresh();
                return false;
            }
        }
    }
}