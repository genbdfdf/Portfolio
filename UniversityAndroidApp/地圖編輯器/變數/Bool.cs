#region using

namespace 地圖編輯器.變數
{
    internal class Bool
    {
    }
}
#endregion using
namespace mapMaker
{
    partial class Form1
    {
        /// <summary>
        /// 是否繪製框線。
        /// </summary>
        private bool drawRectangle;
        /// <summary>
        /// 是否繪製前景。
        /// </summary>
        private bool drawFore;
        /// <summary>
        /// 是否繪製背景。
        /// </summary>
        private bool drawBack;
        /// <summary>
        /// 是否繪製可否行走的辨別狀態。
        /// </summary>
        private bool drawWalk;
        /// <summary>
        /// 是否繪製傳送點。
        /// </summary>
        private bool drawTeleport;
        /// <summary>
        /// 是否繪製地圖邊界。
        /// </summary>
        private bool drawMapBorder;
        /// <summary>
        /// 是否為填充模式。
        /// </summary>
        private bool isFill;
        /// <summary>
        /// 是否處於初始化狀態。
        /// </summary>
        private bool initted;
        /// <summary>
        /// 是否為編輯模式。
        /// </summary>
        private bool editMode;
        /// <summary>
        /// 是否為複製模式。
        /// </summary>
        private bool copyMode;
        /// <summary>
        /// 是否有按下Alt按鍵。
        /// </summary>
        private bool pressAltKey;
        /// <summary>
        /// 是否有按下Ctrl按鍵。
        /// </summary>
        private bool pressCtrlKey;
        /// <summary>
        /// 是否有按下Shift按鍵。
        /// </summary>
        private bool pressShiftKey;

        /// <summary>
        /// 是否將所有的相同地圖皆一併儲存。
        /// </summary>
        private bool allSave;


        private bool importing;


        private bool importFin;


        private bool donotAlertOverrideMap = true;
    }
}