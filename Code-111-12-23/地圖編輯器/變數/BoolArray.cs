#region using

namespace 地圖編輯器.變數
{
    internal class BoolArray
    {
    }
}
#endregion using
namespace mapMaker
{
    partial class Form1
    {
        /// <summary>
        /// 儲存地圖每格能不能走的陣列。
        /// </summary>
        private bool[,] mapBackWalk { get; set; }
    }
}