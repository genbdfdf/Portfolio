#region using
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace PenghuSpace.lib
{
    public static class ExtensionMethods
    {

        #region 屬性

        public static int width { get; set; }

        #endregion 屬性

        #region Button

        public static void Visible(this Button target, float x)
        {
            target.SetX(x);
        }

        public static void Invisible(this Button target)
        {
            target.SetX(width + 2);
        }

        #endregion Button

        #region RelativeLayout

        public static void Visible(this RelativeLayout target, float x)
        {
            target.SetX(x);
        }

        public static void Invisible(this RelativeLayout target)
        {
            target.SetX(width + 2);
        }

        #endregion RelativeLayout

        #region TextView

        public static void Visible(this TextView target, float x)
        {
            target.SetX(x);
        }

        public static void Invisible(this TextView target)
        {
            target.SetX(width + 2);
        }

        #endregion TextView

        #region AutoCompleteTextView

        public static void Visible(this AutoCompleteTextView target, float x)
        {
            target.SetX(x);
        }

        public static void Invisible(this AutoCompleteTextView target)
        {
            target.SetX(width + 2);
        }

        public static bool IsVisible(this AutoCompleteTextView target)
        {
            if (target.GetX() == width + 2)
                return false;
            else
                return true;
        }

        #endregion AutoCompleteTextView

        #region ushort

        public static void Clear(this ushort[] target)
        {
            for (ushort i = (ushort)target.Length; i != 0; i--)
                target[i] = 0;
        }

        public static void Clear(this ushort[,] target)
        {
            for (ushort i = (ushort)(target.GetLength(0)-1); i != 0; i--)
                for (ushort j = (ushort)(target.GetLength(1) - 1); j != 0; j--)
                    target[i, j] = 0;
        }

        #endregion ushort

    }
}