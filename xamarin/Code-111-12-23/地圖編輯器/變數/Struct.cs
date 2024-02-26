#region using

using System.Drawing;

namespace 地圖編輯器.變數
{
    internal class Struct
    {
    }
}
#endregion using
namespace mapMaker
{
    partial class Form1
    {
        public struct cutImageStruct
        {
            public string name { get; set; }
            public Bitmap image { get; set; }
            public cutImageStruct(string name, Bitmap bitmap)
            {
                this.name = name;
                this.image = bitmap;
            }
        }
    }
}