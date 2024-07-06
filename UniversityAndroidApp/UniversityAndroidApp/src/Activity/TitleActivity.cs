#region using
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using static Android.Views.ViewGroup;
using PenghuSpace.lib;
using Android.Views.InputMethods;
using PenghuSpace.Net;
using Android.OS;
using System.Net.Sockets;
using Resource = UniversityAndroidApp.Resource;
using Xamarin.Essentials;
using Android.Content.Res;
#endregion using

namespace PenghuSpace.Activity
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true, ScreenOrientation = Android.Content.PM.ScreenOrientation.Landscape)]

    public class TitleActivity : AppCompatActivity
    {

        #region 全域變數

        private const int noInternetHeight = 90;

        private Socket _socket;

        private int _width;

        private int _height;

        private bool _workFinished;

        private static TitleActivity _titleActivity;

        private RelativeLayout _noInternetLayout;

        private RelativeLayout _transitions;

        private Button _portal;

        private Button _portal1;

        private Button _portal2;

        private Intent _intent;

        private TextView _loading;

        private AutoCompleteTextView _textID;

        #endregion 全域變數

        #region 屬性

        public static BaseActivityCore activityCore { get; private set; }

        public static string ID { get; private set; }

        public static Task nowLoadingAnimate { get; set; }

        #endregion 屬性

        #region 初始化

        protected override void OnStart()
        {
            base.OnStart();
            Task.Run(() =>
            {
                while (_transitions.Alpha > 0.01f)
                {
                    Thread.Sleep(16);
                    _transitions.Alpha -= 0.027f;
                }
                _transitions.Alpha = 0.01f;
                _transitions.SetX(_width + 2);

                Task.Run(() => ChangedNetwork());

                click();
            });
            Task.Run(() =>
            {
                Thread.Sleep(150);
                _noInternetLayout.SetY(-noInternetHeight);
            });
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void Init()
        {
            _titleActivity = this;
            CreateContent();
            CreateNoInternet();

            Network.CheckInternet();

            Connectivity.ConnectivityChanged += Network.Connectivity_ConnectivityChanged;

            InitNetwork initNetwork = new InitNetwork();
            if (initNetwork.CheckIPv6())
                _socket = new Socket(AddressFamily.InterNetworkV6, SocketType.Dgram, ProtocolType.Udp);
            else
                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            Network.Setsocket(ref _socket);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.title);

            Init();

            ExtensionMethods.width = _width;
            AssetManager assets = this.Assets;
            BaseActivityCore core = new BaseActivityCore(assets);
            activityCore = core;
        }

        #endregion 初始化

        #region Getter

        #region socket

        public static ref Socket Getsocket()
        {
            return ref _titleActivity._socket;
        }

        #endregion socket

        #endregion Getter

        #region 建立元件

        #region 按鈕等元件

        void CreateLayoutContent()
        {
            RelativeLayout layouts = new RelativeLayout(this);
            AddContentView(layouts, new LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent));

            TextView textView = new TextView(this);
            textView.TextAlignment = TextAlignment.Center;
            textView.SetX(textView.GetX() + 10);
            textView.SetY(_height / 12 + 10);
            textView.TextSize = 48;
            textView.SetTextColor(Color.Black);
            textView.SetText(Resource.String.app_name);
            textView.Alpha = 0.3f;
            layouts.AddView(textView, new LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent));
            
            textView = new TextView(this);
            textView.TextAlignment = TextAlignment.Center;
            textView.SetY(_height / 12);
            textView.TextSize = 48;
            textView.SetTextColor(Color.Gold);
            textView.SetText(Resource.String.app_name);
            layouts.AddView(textView, new LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent));
            
            textView = new TextView(this);
            textView.SetX(400);
            textView.SetY(_height - 130 - 100);
            textView.TextSize = 28;
            textView.SetTextColor(Color.Black);
            textView.SetText("ID:", TextView.BufferType.Normal);
            //layouts.AddView(textView, new LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent));

            AutoCompleteTextView text = new AutoCompleteTextView(this);
            text.SetX(500);
            text.SetY(_height - 130 - 100);
            text.Threshold = 100;
            text.SetBackgroundColor(Color.White);
            text.ImeOptions = (ImeAction)ImeFlags.NoFullscreen;
            text.Text = "Pen";
            //layouts.AddView(text, new LayoutParams(_width - 1000, 130));
            _textID = text;

            Button button = new Button(this); //故事模式
            
            SetButtonFunction(_width / 4 * 1, 400, Resource.String.portal1);
            _portal = button;

            button = new Button(this); //自由模式
            SetButtonFunction(_width / 4 * 3 - px2dpi(textView.Context, 24 * 4), 400, Resource.String.portal2);
            _portal1 = button;

            //button = new Button(this); //測試模式
            //SetButtonFunction(_width / 4 * 2 - px2dpi(textView.Context, 24 * 2), 600, Resource.String.portal3);
            //button.SetX(_width + 2);
            //textView.SetX(_width + 2);
            //_portal2 = button;

            void SetButtonFunction(float x, float y, int text)
            {
                button.SetX(x);
                button.SetY(_height - y);
                button.TextSize = 24;
                button.SetBackgroundResource(Resource.Drawable.blank);
                button.SetText(text);
                layouts.AddView(button, new LayoutParams(px2dpi(textView.Context, 24 * 5), 180));
            }
        }

        #endregion 按鈕等元件

        #region 畫面本體

        void CreateContent()
        {
            DisplayMetrics dm = new DisplayMetrics();
            WindowManager.DefaultDisplay.GetMetrics(dm);
            _width = dm.WidthPixels;//2071
            _height = dm.HeightPixels;//1080

            ImageView imageView = new ImageView(this);
            imageView.Alpha = 0.9f;
            imageView.SetImageDrawable(GetDrawable(Resource.Drawable.background));
            AddContentView(imageView, new LayoutParams(9600, 1440));
            Task.Run(() =>
            {
                while (!_workFinished)
                {
                    Thread.Sleep(80);
                    imageView.SetX(imageView.GetX() - 1);
                    if (9600 + imageView.GetX() < _width)
                    {
                        imageView.SetX(0);
                    }
                }
            });

            //mainLayout.SetBackgroundColor(Color.Argb(255, 160, 180, 255));
            CreateLayoutContent();

            RelativeLayout relativeLayouts = new RelativeLayout(this);
            relativeLayouts.SetBackgroundColor(Color.Black);
            AddContentView(relativeLayouts, new LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent));
            _transitions = relativeLayouts;
            relativeLayouts.Click += delegate 
            {
                int a = 0;
                /* 用來防止不當時機按到按鈕 */
            };

            TextView textView = new TextView(this);
            textView.SetX(_width / 2 - px2dpf(textView.Context, 42 * 2));
            textView.SetY(_height / 1.2f);
            textView.TextSize = 36;
            textView.SetTextColor(Color.Argb(255, 184, 184, 184));
            textView.SetText("Now Loading ...", TextView.BufferType.Normal);
            textView.Visibility = ViewStates.Invisible;
            textView.Alpha = 0;
            AddContentView(textView, new LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent));
            _loading = textView;
        }

        #endregion 畫面本體

        #region 沒有網路連線

        private void CreateNoInternet()
        {
            RelativeLayout containerLayout = new RelativeLayout(this);
            containerLayout.SetGravity(GravityFlags.Center);
            AddContentView(containerLayout, new LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent));

            RelativeLayout layout = new RelativeLayout(this);
            layout.SetBackgroundColor(Color.Black);
            layout.Alpha = 0.7f;
            containerLayout.AddView(layout, new LayoutParams(1050, noInternetHeight));
            _noInternetLayout = layout;

            TextView textView = new TextView(this);
            textView.TextSize = 18;
            textView.SetY(10);
            textView.SetTextColor(Color.Argb(255, 184, 184, 184));
            textView.SetText("沒有網路連線或能力受限", TextView.BufferType.Normal);
            textView.TextAlignment = TextAlignment.Center;
            layout.AddView(textView, new LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent));
        }

        #endregion 沒有網路連線

        #endregion 建立元件

        #region 單位轉換
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float dp2pxf(Context context, float px)
        {
            return px / context.Resources.DisplayMetrics.Density + 0.5f;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float px2dpf(Context context, float dp)
        {
            return dp * context.Resources.DisplayMetrics.Density + 0.5f;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dp2pxi(Context context, float px)
        {
            return (int)(px / context.Resources.DisplayMetrics.Density + 0.5f);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int px2dpi(Context context, float dp)
        {
            return (int)(dp * context.Resources.DisplayMetrics.Density + 0.5f);
        }

        #endregion 單位轉換

        #region 淡出轉場

        void FadeOut()
        {
            if (_textID.Text.Length < 1)
            {
                _textID.Text = "ID不可以為空!";
            }
            else
            {
                ID = _textID.Text;
                _transitions.Visibility = ViewStates.Visible;
                _loading.Visibility = ViewStates.Visible;
                Task.Run(() =>
                {
                    if (_transitions.GetX() == _width + 2) _transitions.SetX(0);
                    while (_transitions.Alpha < 1)
                    {
                        Thread.Sleep(16);
                        _transitions.Alpha += 0.0325f;

                        if (_loading.Alpha < 0.5)
                        {
                            _loading.Alpha += 0.1f;
                        }
                        else
                        {
                            _loading.Alpha += 0.03f;
                        }
                    }
                    _workFinished = true;
                    nowLoadingAnimate = Task.Run(() =>
                    {
                        while (true)
                        {
                            Thread.Sleep(150);
                            switch(_loading.Text)
                            {
                                case "Now Loading .":
                                    _loading.Text = "Now Loading ..";
                                    break;
                                case "Now Loading ..":
                                    _loading.Text = "Now Loading ...";
                                    break;
                                case "Now Loading ...":
                                    _loading.Text = "Now Loading .";
                                    break;
                            }
                        }
                    });
                    Thread.Sleep(100);
                    //activityCore.WaitInitFinish();
                    StartActivity(_intent);
                    OverridePendingTransition(Resource.Animation.abc_fade_in, Resource.Animation.abc_fade_out);
                });
            }
        }

        #endregion 淡出轉場
        
        #region 事件

        public void click()
        {
            _portal.Click += delegate
            {
                _intent = new Intent(this, typeof(StoryBase));
                FadeOut();
            };
            _portal1.Click += delegate
            {
                _intent = new Intent(this, typeof(Base));
                FadeOut();
            };
            _portal2.Click += delegate
            {
                _intent = new Intent(this, typeof(TitleActivity));
                FadeOut();
            };
        }

        public static void ChangedNetwork()
        {
            Task.Run(() => _titleActivity.ChangedNetworkRnu());
        }

        private void ChangedNetworkRnu()
        {
            if (Network.internet)
            {
                Task.Run(() =>
                {
                    while (_noInternetLayout.GetY() > -noInternetHeight)
                    {
                        Thread.Sleep(16);
                        _noInternetLayout.SetY(_noInternetLayout.GetY() - 1);
                    }
                    _noInternetLayout.SetY(-_height / 5);
                });
            }
            else
            {
                Task.Run(() =>
                {
                    _noInternetLayout.SetY(-noInternetHeight);
                    while (_noInternetLayout.GetY() < 0)
                    {
                        Thread.Sleep(16);
                        _noInternetLayout.SetY(_noInternetLayout.GetY() + 1);
                    }
                    _noInternetLayout.SetY(0);
                });
            }
        }
        #endregion 事件.
    }
}