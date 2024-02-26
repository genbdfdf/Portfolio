using Android.Graphics.Drawables;

namespace PenghuSpace.lib
{
    public struct RollBackBigMap
    {
        public int x;
        public int y;
        public Drawable image;

        public RollBackBigMap(int x, int y, Drawable bitmap)
        {
            this.x = x;
            this.y = y;
            image = bitmap;
        }
    }
}