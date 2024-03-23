#region using
using SharpDX.Direct2D1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 地圖編輯器.變數
{
    internal class DirectVar
    {
    }
}
#endregion using
namespace mapMaker
{
    partial class Form1
    {
        #region WindowRenderTarget
        private WindowRenderTarget views;
        #endregion WindowRenderTarget

        #region Bitmap
        private Bitmap cannotWalk;
        #endregion Bitmap

        #region Bitmap[]
        private Bitmap[] pic;
        private Bitmap[] teleportPic = new Bitmap[2];
        #endregion Bitmap[]
    }
}