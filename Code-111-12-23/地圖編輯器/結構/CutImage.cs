#region using
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 地圖編輯器.結構
{
    internal class CutImage
    {
    }
}
#endregion

namespace mapMaker
{
    partial class Form1
    {
        struct CutImage
        {
            public Bitmap image { get; set; }
            public string name { get; set; }
        }
    }
}