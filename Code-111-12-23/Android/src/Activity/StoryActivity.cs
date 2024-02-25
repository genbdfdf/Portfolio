#region using
using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Util;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using static Android.Views.ViewGroup;
using 函式庫.資料表;
using AndroidX.RecyclerView.Widget;
using Android.Renderscripts;
using PenghuSpace.lib;
using Android.Content;

#endregion using

namespace PenghuSpace.Activity
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", ScreenOrientation = Android.Content.PM.ScreenOrientation.Landscape)]

    public class StoryActivity : StoryBase
    {
        private Intent intent { get; set; }
        #region 開始
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
          
        }
        #endregion
    }
}