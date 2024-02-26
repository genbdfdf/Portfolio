#region using

using 函式庫.事件;

namespace 地圖編輯器.變數
{
    internal class KeyboardHook
    {
    }
}
#endregion using
namespace mapMaker
{
    partial class Form1
    {
        private KeyboardHook k_hook = new KeyboardHook();
    }
}