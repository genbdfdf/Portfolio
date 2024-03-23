#region using
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using static Android.Views.ViewGroup;
using Android.Views.InputMethods;
using 函式庫.資料表;
using Map = 函式庫.資料表.Map;
using Picture = 函式庫.資料表.Picture;
using PenghuSpace.lib;
using Debug = System.Diagnostics.Debug;
using System.Net;
using System.Text;
using PenghuSpace.Net;
using PenghuSpace.Event;
using PenghuSpace.Enums;
using Resource = UniversityAndroidApp.Resource;
#endregion using

namespace PenghuSpace.Activity
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", ScreenOrientation = Android.Content.PM.ScreenOrientation.Landscape)]

    public class Base : AppCompatActivity
    {

        #region 常數向變數

        protected const ushort mapId = 1;

        protected ushort nowX = 56;
        protected ushort nowY = 100;

        protected const byte widthcount = 19;

        protected const byte heightcount = 10;

        protected const byte moveSpeedDelayTime = 20;

        protected ushort miniMapGridNum = 30;
        protected ushort minimap_size = 15;
        protected ushort bigmapGridNum = 130;
        protected ushort bigmap_size = 15;

        #endregion 常數向變數

        #region 元件變數

        protected RelativeLayout noInternetLayout { get; set; }

        private RelativeLayout _transitions;

        protected TextView lb_MapTitle { get; set; }

        protected TextView lb_MapTitleShadow { get; set; }

        protected TextView lb_portal { get; set; }

        protected Button up { get; set; }

        protected Button down { get; set; }

        protected Button left { get; set; }

        protected Button right { get; set; }

        protected Button portal { get; set; }

        protected Button portal1 { get; set; }

        protected Button portal2 { get; set; }

        protected Button portal3 { get; set; }

        protected Button portal4 { get; set; }

        protected Button buttonreturn { get; set; }

        protected Button search { get; set; }

        protected Button enlarge { get; set; }

        protected Button buttontest { get; set; }

        protected Button minimapportal { get; set; }

        protected Button minimapportal1 { get; set; }

        protected Button minimapportal2 { get; set; }

        protected Button minimapportal3 { get; set; }

        private ImageView _imageBackground;

        protected ImageView imageViewhero { get; set; }

        protected ImageView imageViewhero2 { get; set; }

        protected RelativeLayout mapLayout { get; set; }

        protected RelativeLayout miniMapLayout { get; set; }

        protected RelativeLayout bigMapViewLayout { get; set; }

        protected RelativeLayout bigMapContextLayout { get; set; }

        protected RelativeLayout moveButtonLayout { get; set; }

        protected RelativeLayout buttonLayout { get; set; }

        protected AutoCompleteTextView searchtext { get; set; }

        #endregion

        #region 列表變數

        protected ImageView[,] mapImage { get; set; }

        protected ImageView[,] mapRoadImage { get; set; }

        protected ImageView[,] mapTeleportImage { get; set; }

        protected ImageView[,] miniMapImage { get; set; }

        protected ImageView[,] miniMapRoadImage { get; set; }

        protected ImageView[,] bigMapImage { get; set; }
        #endregion

        #region 全域變數

        private bool _roleAnimationIsRunnimg;

        private bool _teleportMapTextAnimationIsRunnimg;

        private bool _backgroundAnimationIsRunnimg;

        protected bool _mapTitleIsRunnimg;

        protected TeleportEvent teleportEvent;

        protected EndPoint Remote;

        private Socket _socket;

        protected IPEndPoint remoteIP { get; set; }
        protected IPEndPoint sender { get; set; }
        protected int otherX { get; set; }
        protected int otherY { get; set; }
        protected byte myID { get; set; }
        protected byte[] message { get; set; }

        //private TcpClient tcpClient;

        //private NetworkStream stream;

        protected Task _mapTitleTask;

        private string _mapDB;

        protected Bitmap[] picture { get; set; }

        protected Bitmap[] drawable { get; set; }

        protected List<Node[]> nearestTeleportNode { get; set; }

        protected Maps nowMap { get; set; }

        private Maps previewMap;

        private List<Map> roadMaps;

        protected byte direction { get; set; }

        private List<Teleport> teleportList { get; set; }

        private List<Teleport> readyTeleport;

        private byte teleportPage { get; set; }

        private ushort[] _teleportLocation;

        protected List<RollBackBigMap> rollBackBigMap { get; set; }

        protected bool[,] canWalk { get; set; }

        protected ushort[,] teleport { get; set; }

        protected ushort[,] road { get; set; }

        protected ushort totalX { get; set; }

        protected ushort totalY { get; set; }

        protected ushort totalBigMapX { get; set; }

        protected ushort totalBigMapY { get; set; }

        protected short xDotRange { get; set; }

        protected short yDotRange { get; set; }

        protected int temp { get; set; }

        protected int temp2 { get; set; }

        protected float herox { get; set; }

        protected float heroy { get; set; }

        private bool _moveing;

        protected byte myRoleStats { get; set; }

        protected int width { get; set; }

        protected int height { get; set; }

        protected int widthment { get; set; }

        protected int heightment { get; set; }

        #endregion

        #region Getter / Setter

        #region socket

        public Socket Getsocket()
        {
            return _socket;
        }

        public void Setsocket(ref Socket sk)
        {
            _socket = sk;
        }

        #endregion socket

        #endregion Getter / Setter

        #region 動畫執行緒

        #region 人物動畫

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected void CreateRoleAnimation()
        {
            _roleAnimationIsRunnimg = true;
            Task.Run(() =>
            {
                while (_roleAnimationIsRunnimg)
                {
                    Thread.Sleep(100);
                    RunOnUiThread(() =>
                    {
                        try
                        {
                            DrawHERO();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("-----------人物動畫出錯-----------");
                            Console.WriteLine(ex.Message);
                            Console.WriteLine("-----------人物動畫出錯-----------");
                        }
                    });
                }
            });
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected void RemoveRoleAnimation()
        {
            _roleAnimationIsRunnimg = false;
        }

        #endregion 人物動畫

        #region 傳送門動畫

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected void CreateTeleportMapTitleAnimation()
        {
            _teleportMapTextAnimationIsRunnimg = true;
            Task.Run(() =>
            {
                Random rm = new Random();
                while (_teleportMapTextAnimationIsRunnimg)
                {
                    Thread.Sleep(200);
                    try
                    {
                        lb_portal.SetTextColor(Color.Argb(255, rm.Next(50, 255), rm.Next(50, 255), rm.Next(50, 255)));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("-----------傳送門動畫出錯-----------");
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("-----------傳送門動畫出錯-----------");
                    }
                }
            });
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected void RemoveTeleportMapTitleAnimation()
        {
            _teleportMapTextAnimationIsRunnimg = false;
        }

        #endregion 傳送門動畫

        #region 背景動畫

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected void CreateBackgroundAnimation()
        {
            _backgroundAnimationIsRunnimg = true;
            Task.Run(() =>
            {
                while (_backgroundAnimationIsRunnimg)
                {
                    Thread.Sleep(80);
                    try
                    {
                        _imageBackground.SetX(_imageBackground.GetX() - 1);
                        if (_imageBackground.GetX() < -620)
                        {
                            _imageBackground.SetX(0);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("-----------背景動畫出錯-----------");
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("-----------背景動畫出錯-----------");
                    }
                }
            });
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected void RemoveBackgroundAnimation()
        {
            _backgroundAnimationIsRunnimg = false;
        }

        #endregion 背景動畫

        #endregion 動畫執行緒

        #region 開始 (初始化)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void OtherInit()
        {
            Task.Run(() =>
            {
                try
                {
                    _teleportLocation = new ushort[2];
                    readyTeleport = new List<Teleport>();
                    roadMaps = new List<Map>();
                    roadMaps.Add(new Map());
                    teleportEvent = new TeleportEvent();
                    rollBackBigMap = new List<RollBackBigMap>();
                    nearestTeleportNode = new List<Node[]>();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("-----------額外初始化出錯-----------");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("-----------額外初始化出錯-----------");
                }

                /*
                string ID = TitleActivity.ID;
                _socket = TitleActivity.Getsocket();
                Network.Send(0, ref ID);
                Task.Run(() => Listen());*/
            });/*
            Task.Run(() =>
            {
                while (true)
                {
                    stream.Read(message, 0, message.Length);

                    byte x = (byte)(message[1] + 1);
                    byte y = (byte)(message[2] + 1);
                    if (x == 1 || y == 1)
                    {
                        continue;
                    }
                    imageViewhero2.SetX(x * 10.3f);
                    imageViewhero2.SetY(y * 10.3f);
                }
            });*/
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected void Init()
        {
            var activityCore = TitleActivity.activityCore;
            _mapDB = activityCore.mapDB;
            picture = activityCore.picture;
            teleportList = activityCore.teleportList;
            drawable = activityCore.drawable;

            LoadMap(mapId);
            previewMap = nowMap;

            CreateElement();
            OtherInit();
            for (ushort x = (ushort)(bigmapGridNum - 1); x != 0; x--)
                for (ushort y = (ushort)(bigmapGridNum - 1); y != 0; y--)
                    BigMapImageIsClick(x,y);

            herox = widthcount / 2;
            heroy = heightcount / 2 - 1;
            imageViewhero.SetX(widthment * herox);
            imageViewhero.SetY(heightment * (heroy - 1) + heightment / 2f);
            click();
            portalclick();
            minimap_bigmap_click();
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine("-----------初始化出錯-----------");
                Console.WriteLine(ex.Message);
                Console.WriteLine("-----------初始化出錯-----------");
            }


            try
            {
                TitleActivity.nowLoadingAnimate.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("-----------讀取畫面動畫出錯-----------");
                Console.WriteLine(ex.Message);
                Console.WriteLine("-----------讀取畫面動畫出錯-----------");
            }

            DrawMapTitle();

            /*tcpClient = new TcpClient();
            await tcpClient.ConnectAsync("192.168.123.124", 51420);
            if(tcpClient.Connected)
            {
                stream = tcpClient.GetStream();
                const int bytesize = 1024 * 1024;
                message = new byte[bytesize];
                message[0] = 255;
                stream.Write(message, 0, 1);
                stream.Read(message, 0, message.Length);
                myID = message[0];
            }*/
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Init();
        }

        protected override void OnStart()
        {
            base.OnStart();
            CreateRoleAnimation();
            CreateBackgroundAnimation();
        }

        protected override void OnStop()
        {
            RemoveRoleAnimation();
            RemoveBackgroundAnimation();
            base.OnStop();
            //string ID = TitleActivity.ID;
            //Network.Send(1, ref ID);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        #endregion

        #region 讀取地圖

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected void LoadMap(ushort mId)
        {
            nowMap = new Maps(mId);
            totalBigMapX = totalX = nowMap.totalCol;
            totalBigMapY = totalY = nowMap.totalRow;
            teleport = nowMap.teleport;
            canWalk = nowMap.mapWalk;
            Task.Run(() => road = new ushort[totalX, totalY]);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected void LoadMap2(ushort mId)
        {
            previewMap = new Maps(mId);
            totalBigMapX = previewMap.totalCol;
            totalBigMapY = previewMap.totalRow;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected string LoadMapTitle(ushort mId)
        {
            var title = new Maps(mId, true);
            return title.title;
        }

        #endregion

        #region 傳送

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected void CheckTeleport()
        {
            byte index = 0;
            ushort X = nowX;
            ushort Y = nowY;
            while (index < 9)
                try
                {
                    if (teleport[X, Y] > 0 && index == 0)
                    {
                        CheckTeleportNum(X, Y);
                        break;
                    }
                    else index = 1;

                    X = (ushort)(nowX - 1);
                    Y = (ushort)(nowY - 1);
                    if (teleport[X, Y] > 0 && index == 1)
                    {
                        CheckTeleportNum(X, Y);
                        break;
                    }
                    else index = 2;

                    X = (ushort)(nowX - 1);
                    Y = nowY;
                    if (teleport[X, Y] > 0 && index == 2)
                    {
                        CheckTeleportNum(X, Y);
                        break;
                    }
                    else index = 3;

                    X = (ushort)(nowX - 1);
                    Y = (ushort)(nowY + 1);
                    if (teleport[X, Y] > 0 && index == 3)
                    {
                        CheckTeleportNum(X, Y);
                        break;
                    }
                    else index = 4;

                    X = nowX;
                    Y = (ushort)(nowY - 1);
                    if (teleport[X, Y] > 0 && index == 4)
                    {
                        CheckTeleportNum(X, Y);
                        break;
                    }
                    else index = 5;

                    X = nowX;
                    Y = (ushort)(nowY + 1);
                    if (teleport[X, Y] > 0 && index == 5)
                    {
                        CheckTeleportNum(X, Y);
                        break;
                    }
                    else index = 6;

                    X = (ushort)(nowX + 1);
                    Y = (ushort)(nowY - 1);
                    if (teleport[X, Y] > 0 && index == 6)
                    {
                        CheckTeleportNum(X, Y);
                        break;
                    }
                    else index = 7;

                    X = (ushort)(nowX + 1);
                    Y = nowY;
                    if (teleport[X, Y] > 0 && index == 7)
                    {
                        CheckTeleportNum(X, Y);
                        break;
                    }
                    else index = 8;

                    X = (ushort)(nowX + 1);
                    Y = (ushort)(nowY + 1);
                    if (teleport[X, Y] > 0 && index == 8)
                    {
                        CheckTeleportNum(X, Y);
                        break;
                    }
                    else index = 9;
                    portal1.Invisible();
                    portal2.Invisible();
                    portal3.Invisible();
                    portal4.Invisible();
                    index = 9;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("-----------檢查傳送點出錯-----------");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("-----------檢查傳送點出錯-----------");
                }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected void CheckTeleportNum(ushort x, ushort y)
        {
            _teleportLocation[0] = x;
            _teleportLocation[1] = y;
            readyTeleport.Clear();
            foreach (var item in teleportList)
                if (item.col == x && item.row == y && item.teleport > 0 && item.mId == nowMap.mId)
                    readyTeleport.Add(item);

            switch (readyTeleport.Count)
            {
                case 1:
                    portal1.Text = LoadMapTitle(teleportList[readyTeleport[0].teleport - 1].mId).Substring(5);
                    portal1.Visible(0);
                    portal2.Invisible();
                    portal3.Invisible();
                    portal4.Invisible();
                    break;
                case 2:
                    portal1.Text = LoadMapTitle(teleportList[readyTeleport[0].teleport - 1].mId).Substring(5);
                    portal2.Text = LoadMapTitle(teleportList[readyTeleport[1].teleport - 1].mId).Substring(5);
                    portal1.Visible(0);
                    portal2.Visible(0);
                    portal3.Invisible();
                    portal4.Invisible();
                    break;
                case 3:
                    portal1.Text = LoadMapTitle(teleportList[readyTeleport[0].teleport - 1].mId).Substring(5);
                    portal2.Text = LoadMapTitle(teleportList[readyTeleport[1].teleport - 1].mId).Substring(5);
                    portal3.Text = LoadMapTitle(teleportList[readyTeleport[2].teleport - 1].mId).Substring(5);
                    portal1.Visible(0);
                    portal2.Visible(0);
                    portal3.Visible(0);
                    portal4.Invisible();
                    break;
                default:
                    portal1.Text = LoadMapTitle(teleportList[readyTeleport[0].teleport - 1].mId).Substring(5);
                    portal2.Text = LoadMapTitle(teleportList[readyTeleport[1].teleport - 1].mId).Substring(5);
                    portal3.Text = LoadMapTitle(teleportList[readyTeleport[2].teleport - 1].mId).Substring(5);
                    portal4.Text = "下一頁";
                    portal1.Visible(0);
                    portal2.Visible(0);
                    portal3.Visible(0);
                    portal4.Visible(0);
                    break;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected void Teleport(int num)
        {
            Task.Run(() =>
            {
                try
                {
                    _transitions.Visible(0);
                    while (_transitions.Alpha < 1)
                    {
                        Thread.Sleep(16);
                        _transitions.Alpha += 0.0325f;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("-----------傳送黑幕動畫出錯-----------");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("-----------傳送黑幕動畫出錯-----------");
                }
                try
                {
                    var nextMap = teleportList[readyTeleport[num + teleportPage * 2 - 1].teleport - 1];
                    LoadMap(nextMap.mId);
                    nowX = nextMap.col;
                    nowY = nextMap.row;
                    previewMap = nowMap;
                    teleportPage = 0;
                    SwitchRoad();
                    CheckTeleport();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("-----------傳送時讀取地圖出錯-----------");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("-----------傳送時讀取地圖出錯-----------");
                }
                RunOnUiThread(() =>
                {
                    CreateBigMapContext(width, height);
                    DrawBigMap();
                });
                DrawMapTitle();
                try
                {
                    while (_transitions.Alpha > 0.1f)
                    {
                        Thread.Sleep(16);
                        _transitions.Alpha -= 0.027f;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("-----------傳送時黑幕消失動畫出錯-----------");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("-----------傳送時黑幕消失動畫出錯-----------");
                }
                try
                {
                    _transitions.Invisible();
                    _transitions.Alpha = 0.01f;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("-----------傳送時黑幕隱藏出錯-----------");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("-----------傳送時黑幕隱藏出錯-----------");
                }
                Task.Run(() => CheckTeleport());
                teleportEvent.Run();
            });
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected void SwitchRoad()
        {

            #region 1
            void _1(Node item)
            {
                switch (item.toLoc.direction)
                {
                    case 1:
                        road[item.x, item.y] = 23;
                        break;
                    case 2:
                        road[item.x, item.y] = 25;
                        break;
                    case 3:
                        road[item.x, item.y] = 10;
                        break;
                    case 4:
                        road[item.x, item.y] = 27;
                        break;
                    case 5:
                        road[item.x, item.y] = 0000000;
                        break;
                    case 6:
                        road[item.x, item.y] = 26;
                        break;
                    case 7:
                        road[item.x, item.y] = 5;
                        break;
                    case 8:
                        road[item.x, item.y] = 24;
                        break;
                }
            }
            #endregion 1

            #region 2
            void _2(Node item)
            {
                switch (item.toLoc.direction)
                {
                    case 1:
                        road[item.x, item.y] = 17;
                        break;
                    case 2:
                        road[item.x, item.y] = 20;
                        break;
                    case 3:
                        road[item.x, item.y] = 11;
                        break;
                    case 4:
                        road[item.x, item.y] = 21;
                        break;
                    case 5:
                        road[item.x, item.y] = 26;
                        break;
                    case 6:
                        road[item.x, item.y] = 0000000;
                        break;
                    case 7:
                        road[item.x, item.y] = 5;
                        break;
                    case 8:
                        road[item.x, item.y] = 19;
                        break;
                }
            }
            #endregion 2

            #region 3
            void _3(Node item)
            {
                switch (item.toLoc.direction)
                {
                    case 1:
                        road[item.x, item.y] = 2;
                        break;
                    case 2:
                        road[item.x, item.y] = 36;
                        break;
                    case 3:
                        road[item.x, item.y] = 1;
                        break;
                    case 4:
                        road[item.x, item.y] = 6;
                        break;
                    case 5:
                        road[item.x, item.y] = 4;
                        break;
                    case 6:
                        road[item.x, item.y] = 5;
                        break;
                    case 7:
                        road[item.x, item.y] = 0000000;
                        break;
                    case 8:
                        road[item.x, item.y] = 6;
                        break;
                }
            }
            #endregion 3

            #region 4
            void _4(Node item)
            {
                switch (item.toLoc.direction)
                {
                    case 1:
                        road[item.x, item.y] = 18;
                        break;
                    case 2:
                        road[item.x, item.y] = 22;
                        break;
                    case 3:
                        road[item.x, item.y] = 8;
                        break;
                    case 4:
                        road[item.x, item.y] = 14;
                        break;
                    case 5:
                        road[item.x, item.y] = 24;
                        break;
                    case 6:
                        road[item.x, item.y] = 21;
                        break;
                    case 7:
                        road[item.x, item.y] = 6;
                        break;
                    case 8:
                        road[item.x, item.y] = 0000000;
                        break;
                }
            }
            #endregion 4

            #region 5
            void _5(Node item)
            {
                switch (item.toLoc.direction)
                {
                    case 1:
                        road[item.x, item.y] = 0000000;
                        break;
                    case 2:
                        road[item.x, item.y] = 16;
                        break;
                    case 3:
                        road[item.x, item.y] = 7;
                        break;
                    case 4:
                        road[item.x, item.y] = 18;
                        break;
                    case 5:
                        road[item.x, item.y] = 23;
                        break;
                    case 6:
                        road[item.x, item.y] = 17;
                        break;
                    case 7:
                        road[item.x, item.y] = 2;
                        break;
                    case 8:
                        road[item.x, item.y] = 15;
                        break;
                }
            }
            #endregion 5

            #region 6
            void _6(Node item)
            {
                switch (item.toLoc.direction)
                {
                    case 1:
                        road[item.x, item.y] = 16;
                        break;
                    case 2:
                        road[item.x, item.y] = 0000000;
                        break;
                    case 3:
                        road[item.x, item.y] = 9;
                        break;
                    case 4:
                        road[item.x, item.y] = 22;
                        break;
                    case 5:
                        road[item.x, item.y] = 25;
                        break;
                    case 6:
                        road[item.x, item.y] = 20;
                        break;
                    case 7:
                        road[item.x, item.y] = 36;
                        break;
                    case 8:
                        road[item.x, item.y] = 13;
                        break;
                }
            }
            #endregion 6

            #region 7
            void _7(Node item)
            {
                switch (item.toLoc.direction)
                {
                    case 1:
                        road[item.x, item.y] = 7;
                        break;
                    case 2:
                        road[item.x, item.y] = 9;
                        break;
                    case 3:
                        road[item.x, item.y] = 0000000;
                        break;
                    case 4:
                        road[item.x, item.y] = 12;
                        break;
                    case 5:
                        road[item.x, item.y] = 10;
                        break;
                    case 6:
                        road[item.x, item.y] = 11;
                        break;
                    case 7:
                        road[item.x, item.y] = 1;
                        break;
                    case 8:
                        road[item.x, item.y] = 8;
                        break;
                }
            }
            #endregion 7

            #region 8
            void _8(Node item)
            {
                switch (item.toLoc.direction)
                {
                    case 1:
                        road[item.x, item.y] = 18;
                        break;
                    case 2:
                        road[item.x, item.y] = 22;
                        break;
                    case 3:
                        road[item.x, item.y] = 12;
                        break;
                    case 4:
                        road[item.x, item.y] = 0000000;
                        break;
                    case 5:
                        road[item.x, item.y] = 27;
                        break;
                    case 6:
                        road[item.x, item.y] = 21;
                        break;
                    case 7:
                        road[item.x, item.y] = 6;
                        break;
                    case 8:
                        road[item.x, item.y] = 14;
                        break;
                }
            }
            #endregion 8

            for (ushort i = 0; i < roadMaps.Count; i++)
            {
                if (roadMaps[i].mId == nowMap.mId)
                {
                    road.Clear();
                    foreach (var item in nearestTeleportNode[i])
                    {
                        ushort x = item.x;
                        ushort y = item.y;
                        if (item.toLoc != null)
                            switch (item.direction)
                            {
                                case 1:
                                    _1(item);
                                    break;
                                case 2:
                                    _2(item);
                                    break;
                                case 3:
                                    _3(item);
                                    break;
                                case 4:
                                    _4(item);
                                    break;
                                case 5:
                                    _5(item);
                                    break;
                                case 6:
                                    _6(item);
                                    break;
                                case 7:
                                    _7(item);
                                    break;
                                case 8:
                                    _8(item);
                                    break;
                            }
                        else
                            switch (item.direction)
                            {
                                case 1:
                                    road[x, y] = 33;
                                    break;
                                case 2:
                                    road[x, y] = 34;
                                    break;
                                case 3:
                                    road[x, y] = 28;
                                    break;
                                case 4:
                                    road[x, y] = 31;
                                    break;
                                case 5:
                                    road[x, y] = 30;
                                    break;
                                case 6:
                                    road[x, y] = 32;
                                    break;
                                case 7:
                                    road[x, y] = 29;
                                    break;
                                case 8:
                                    road[x, y] = 35;
                                    break;
                            }
                    }
                    break;
                }
            }
            DrawMap();
            DrawMiniMap();
        }
        #endregion

        #region 繪製地圖

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected void DrawMap()
        {
            ushort mapX = (ushort)(nowX - widthcount / 2 - 2);
            ushort mapY = (ushort)(nowY - heightcount / 2 - 2);

            if (nowX - widthcount / 2 - 2 < 0)
                mapX = 0;
            else if (nowX + widthcount / 2 + 1 > totalX)
                mapX = (ushort)(totalX - widthcount - 2);

            if (nowY - heightcount / 2 - 2 < 0)
                mapY = 0;
            else if (nowY + heightcount / 2 + 1 > totalY)
                mapY = (ushort)(totalY - heightcount - 1);

            herox = nowX - mapX - 1;
            heroy = nowY - mapY - 1;
            imageViewhero.SetX(widthment * herox);
            imageViewhero.SetY(heightment * (heroy - 1) + heightment / 2f);

            DrawMap(ref mapX, ref mapY);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected void DrawMap(ref ushort mapX, ref ushort mapY)
        {
            ushort baseY = mapY;
            bool outOfRange;
            for (ushort x = 0; x < widthcount + 2; x++)
            {
                for (ushort y = 0; y < heightcount + 2; y++)
                {
                    outOfRange = false;
                    if (mapX < 0 || mapX + 1 > totalX) outOfRange = true;
                    if (mapY < 0 || mapY + 1 > totalY) outOfRange = true;
                    if (outOfRange)
                        mapImage[x, y].SetImageBitmap(picture[0]);
                    else
                        mapImage[x, y].SetImageBitmap(picture[nowMap.mapBackPic[mapX, mapY] - 1]);

                    try
                    {
                        mapTeleportImage[x, y].SetImageBitmap(picture[0]);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("-----------改變地圖圖片出錯-----------");
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("-----------改變地圖圖片出錯-----------");
                    }
                    try
                    {
                        if (teleport[mapX, mapY] > 0)
                            mapTeleportImage[x, y].SetImageDrawable(GetDrawable(Resource.Drawable.teleport));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("-----------改變地圖顯示傳送點出錯-----------");
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("-----------改變地圖顯示傳送點出錯-----------");
                    }
                    try
                    {
                        if (road[mapX, mapY] > 0)
                            mapRoadImage[x, y].SetImageBitmap(drawable[road[mapX, mapY] - 1]);
                        else
                            mapRoadImage[x, y].SetImageBitmap(picture[0]);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("-----------改變地圖顯示路線出錯-----------");
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("-----------改變地圖顯示路線出錯-----------");
                    }

                    mapY++;
                }

                mapX++;
                mapY = baseY;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected void DrawMiniMap()
        {
            ushort mapX = (ushort)(nowX - miniMapGridNum / 2 - 1);
            ushort mapY = (ushort)(nowY - miniMapGridNum / 2);

            if (nowX - miniMapGridNum / 2 - 1 < 0)
                mapX = 0;
            else if (nowX + miniMapGridNum / 2 > totalX)
                mapX = (ushort)(totalX - miniMapGridNum - 1);

            if (nowY - miniMapGridNum / 2 < 0)
                mapY = 0;
            else if (nowY + miniMapGridNum / 2 > totalY)
                mapY = (ushort)(totalY - miniMapGridNum);

            ushort baseX = mapX;
            ushort baseY = mapY;

            for (ushort x = 0; x < miniMapGridNum; x++)
            {
                for (ushort y = 0; y < miniMapGridNum; y++)
                {
                    try
                    {
                        miniMapImage[x, y].SetImageBitmap(picture[0]);
                        miniMapImage[x, y].SetImageBitmap(picture[nowMap.mapBackPic[mapX, mapY] - 1]);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("-----------改變小地圖圖片出錯-----------");
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("-----------改變小地圖圖片出錯-----------");
                    }
                    try
                    {
                        if (road[mapX, mapY] > 0)
                            miniMapRoadImage[x, y].SetImageBitmap(drawable[road[mapX, mapY] - 1]);
                        else
                            miniMapRoadImage[x, y].SetImageBitmap(picture[0]);
                        mapY++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("-----------改變小地圖顯示路線出錯-----------");
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("-----------改變小地圖顯示路線出錯-----------");
                    }
                }

                mapX++;
                mapY = baseY;
            }
            try
            {
                miniMapImage[nowX - baseX, nowY - baseY].SetImageDrawable(GetDrawable(Resource.Drawable.hero00));
            }
            catch (Exception ex)
            {
                Console.WriteLine("-----------在小地圖顯示位置出錯-----------");
                Console.WriteLine(ex.Message);
                Console.WriteLine("-----------在小地圖顯示位置出錯-----------");
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected void DrawBigMap()
        {
            for (int x = 0; x < totalBigMapX; x++)
            {
                for (int y = 0; y < totalBigMapY; y++)
                {
                    try
                    {
                        bigMapImage[x, y].SetImageBitmap(picture[nowMap.mapBackPic[x, y] - 1]);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("-----------繪製大地圖出錯-----------");
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("-----------繪製大地圖出錯-----------");
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected void DrawMP4()
        {
            for (int x = 0; x < totalBigMapX; x++)
            {
                for (int y = 0; y < totalBigMapY; y++)
                {
                    try
                    {
                        bigMapImage[x, y].SetImageBitmap(picture[previewMap.mapBackPic[x, y] - 1]);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("-----------搜尋後改變大地圖圖片出錯-----------");
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("-----------搜尋後改變大地圖圖片出錯-----------");
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected void DrawMapTitle()
        {
            _mapTitleIsRunnimg = false;
            try
            {
                _mapTitleTask.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("-----------顯示地圖名稱出錯-----------");
                Console.WriteLine(ex.Message);
                Console.WriteLine("-----------顯示地圖名稱出錯-----------");
            }
            lb_MapTitle.Text = "《" + nowMap.title.Substring(5) + "》";
            lb_MapTitle.TextAlignment = TextAlignment.Center;
            lb_MapTitle.Alpha = 1;
            lb_MapTitleShadow.Text = "《" + nowMap.title.Substring(5) + "》";
            lb_MapTitleShadow.TextAlignment = TextAlignment.Center;
            lb_MapTitleShadow.Alpha = 0.3f;
            _mapTitleTask = Task.Run(() =>
            {
                Thread.Sleep(2000);
                _mapTitleIsRunnimg = true;
                while (_mapTitleIsRunnimg && lb_MapTitle.Alpha > 0.1f)
                {
                    Thread.Sleep(16);
                    lb_MapTitle.Alpha -= 0.027f;
                    lb_MapTitleShadow.Alpha -= 0.01f;
                }
                if (lb_MapTitle.Alpha < 0.1f) lb_MapTitle.Alpha = 0.01f;
                _mapTitleIsRunnimg = false;
            });
        }

        #endregion

        #region 繪製角色

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected void DrawHERO()
        {
            if (++myRoleStats > 5) myRoleStats = 0;
            switch (direction)
            {
                case (byte)Direction.direction.上:
                    switch (myRoleStats)
                    {
                        case 0: imageViewhero.SetImageResource(Resource.Drawable.hero30); break;
                        case 1: imageViewhero.SetImageResource(Resource.Drawable.hero30); break;
                        case 2: imageViewhero.SetImageResource(Resource.Drawable.hero30); break;
                        case 3: imageViewhero.SetImageResource(Resource.Drawable.hero30); break;
                        case 4: imageViewhero.SetImageResource(Resource.Drawable.hero30); break;
                        case 5: imageViewhero.SetImageResource(Resource.Drawable.hero30); break;
                    }
                    break;
                case (byte)Direction.direction.下:
                    switch (myRoleStats)
                    {
                        case 0: imageViewhero.SetImageResource(Resource.Drawable.hero00); break;
                        case 1: imageViewhero.SetImageResource(Resource.Drawable.hero00); break;
                        case 2: imageViewhero.SetImageResource(Resource.Drawable.hero00); break;
                        case 3: imageViewhero.SetImageResource(Resource.Drawable.hero00); break;
                        case 4: imageViewhero.SetImageResource(Resource.Drawable.hero00); break;
                        case 5: imageViewhero.SetImageResource(Resource.Drawable.hero00); break;
                    }
                    break;
                case (byte)Direction.direction.左:
                    switch (myRoleStats)
                    {
                        case 0: imageViewhero.SetImageResource(Resource.Drawable.hero20); break;
                        case 1: imageViewhero.SetImageResource(Resource.Drawable.hero20); break;
                        case 2: imageViewhero.SetImageResource(Resource.Drawable.hero20); break;
                        case 3: imageViewhero.SetImageResource(Resource.Drawable.hero20); break;
                        case 4: imageViewhero.SetImageResource(Resource.Drawable.hero20); break;
                        case 5: imageViewhero.SetImageResource(Resource.Drawable.hero20); break;
                    }
                    break;
                case (byte)Direction.direction.右:
                    switch (myRoleStats)
                    {
                        case 0: imageViewhero.SetImageResource(Resource.Drawable.hero10); break;
                        case 1: imageViewhero.SetImageResource(Resource.Drawable.hero10); break;
                        case 2: imageViewhero.SetImageResource(Resource.Drawable.hero10); break;
                        case 3: imageViewhero.SetImageResource(Resource.Drawable.hero10); break;
                        case 4: imageViewhero.SetImageResource(Resource.Drawable.hero10); break;
                        case 5: imageViewhero.SetImageResource(Resource.Drawable.hero10); break;
                    }
                    break;
            }
        }
        #endregion

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
        #endregion

        #region 產生元件

        #region ImageView

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CreateImageView()
        {
            ImageView[,] Run(ushort runCount)
            {
                ImageView[,] views = new ImageView[runCount, runCount];
                for (ushort i = 0; i < runCount; i++)
                {
                    for (ushort j = 0; j < runCount; j++)
                    {
                        views[i, j] = new ImageView(this);
                        views[i, j].SetScaleType(ImageView.ScaleType.FitXy);
                    }
                }
                return views;
            }
            Task sk0 = Task.Run(() => mapImage = Run((ushort)(widthcount + 2)));
            Task sk1 = Task.Run(() => mapRoadImage = Run((ushort)(widthcount + 2)));
            Task sk2 = Task.Run(() => miniMapImage = Run(miniMapGridNum));
            Task sk3 = Task.Run(() => miniMapRoadImage = Run(miniMapGridNum));
            Task sk4 = Task.Run(() => bigMapImage = Run(bigmapGridNum));
            Task sk5 = Task.Run(() => mapTeleportImage = Run((ushort)(widthcount + 2)));
            sk0.Wait();
            sk1.Wait();
            sk2.Wait();
            sk3.Wait();
            sk4.Wait();
            sk5.Wait();
        }
        #endregion ImageView

        #region 上下左右移動按紐

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CreateMoveButton(int height)
        {
            RelativeLayout mainLayout = new RelativeLayout(this);
            mainLayout.SetY(px2dpf(mainLayout.Context, dp2pxi(mainLayout.Context, height) - 72 - 36 - 25));
            moveButtonLayout = mainLayout;
            moveButtonLayout.Click += delegate { /* 防止按移動時誤觸其他東西 */ };

            Button button = new Button(this);
            SetButtonFunction(48 + 10, 0, Resource.Drawable.up);
            up = button;

            button = new Button(this);
            SetButtonFunction(48 + 10, 72 + 20, Resource.Drawable.down);
            down = button;

            button = new Button(this);
            SetButtonFunction(0, 36 + 10, Resource.Drawable.left);
            left = button;

            button = new Button(this);
            SetButtonFunction(96 + 20, 36 + 10, Resource.Drawable.right);
            right = button;

            void SetButtonFunction(float x, float y, int backgroundResource)
            {
                button.SetX(px2dpi(button.Context, x));
                button.SetY(px2dpi(button.Context, y));
                button.SetBackgroundResource(backgroundResource);
                button.Alpha = 0.32f;
                mainLayout.AddView(button, new LayoutParams(px2dpi(button.Context, 48), px2dpi(button.Context, 36)));
            }
        }
        #endregion 上下左右移動按紐

        #region 右方互動按紐

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CreateButton(int width, int height)
        {
            int bt_height = height / 5;

            RelativeLayout mainLayout = new RelativeLayout(this);
            mainLayout.SetX(width - 252);
            mainLayout.SetY(bt_height / 6);
            buttonLayout = mainLayout;

            Button button = new Button(this);
            button.SetX(width - 250);
            button.SetY(bt_height * 4 + bt_height / 5);
            //button.Alpha = 0.32f;
            button.SetText(Resource.String.portal);
            button.SetTextSize(ComplexUnitType.Pt, 1);
            button.Visibility = ViewStates.Invisible;
            button.SetBackgroundResource(Resource.Color.colorAccent);
            button.SetBackgroundResource(Resource.Drawable.open);
            portal = button;

            button = new Button(this);
            SetButtonFunction(0);
            portal1 = button;

            button = new Button(this);
            SetButtonFunction(1);
            portal2 = button;

            button = new Button(this);
            SetButtonFunction(2);
            portal3 = button;

            button = new Button(this);
            SetButtonFunction(3);
            portal4 = button;

            void SetButtonFunction(float y)
            {
                button.SetY(bt_height * 4 / 4 * y + bt_height / 6);
                button.SetText(Resource.String.portal);
                button.SetBackgroundResource(Resource.Color.colorAccent);
                button.SetBackgroundResource(Resource.Drawable.blank);
                button.Invisible();
                mainLayout.AddView(button, new LayoutParams(200, 160));
            }
        }
        #endregion 右方互動按紐

        #region 文字

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CreateTextView(int width, int height)
        {
            TextView textView = new TextView(this);
            textView.TextAlignment = TextAlignment.Center;
            textView.SetY(height / 12);
            textView.TextSize = 48;
            textView.SetTextColor(Color.Gold);
            lb_MapTitle = textView;

            textView = new TextView(this);
            textView.TextAlignment = TextAlignment.Center;
            textView.SetY(height / 12 + 10);
            textView.TextSize = 48;
            textView.Alpha = 0.3f;
            textView.SetTextColor(Color.Black);
            lb_MapTitleShadow = textView;

            textView = new TextView(this);
            textView.SetX(widthment * (widthcount / 2) - widthment / 2f);
            textView.SetY(heightment * ((heightcount / 2 - 1) - 1) - heightment / 2f);
            textView.TextSize = 24;
            textView.SetTextColor(Color.White);
            lb_portal = textView;
        }

        #endregion 文字

        #region 人物

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CreateRole()
        {
            ImageView imageViewhero = new ImageView(this);
            temp = dp2pxi(imageViewhero.Context, GetDrawable(Resource.Drawable.hero00).IntrinsicWidth) / widthment;
            imageViewhero.SetScaleType(ImageView.ScaleType.FitXy);
            imageViewhero.SetImageDrawable(GetDrawable(Resource.Drawable.hero00));
            this.imageViewhero = imageViewhero;

            imageViewhero = new ImageView(this);
            temp2 = dp2pxi(imageViewhero.Context, GetDrawable(Resource.Drawable.hero00).IntrinsicWidth) / widthment;
            imageViewhero.SetScaleType(ImageView.ScaleType.FitXy);
            imageViewhero.SetImageDrawable(GetDrawable(Resource.Drawable.hero00));
            this.imageViewhero2 = imageViewhero;
        }

        #endregion 人物

        #region 地圖

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CreateMap(int width, int height)
        {
            LinearLayout linearly = null;
            RelativeLayout mainLayout = new RelativeLayout(this);
            mainLayout.SetX(-widthment);
            mainLayout.SetY(-heightment);

            void Run(ImageView[,] views)
            {
                for (int y = 0; y < heightcount + 2; y++)
                {
                    linearly = new LinearLayout(this);
                    linearly.Orientation = Orientation.Horizontal;
                    linearly.SetX(0);
                    linearly.SetY(heightment * y);
                    linearly.SetPadding((width - widthcount * widthment) / 2, (height - heightcount * heightment) / 2, (width - widthcount * widthment) / 2, (height - heightcount * heightment) / 2);
                    for (int x = 0; x < widthcount + 2; x++)
                    {
                        linearly.AddView(views[x, y], new LayoutParams(widthment, heightment));
                    }
                    mainLayout.AddView(linearly, new LayoutParams(widthment * (widthcount + 2), heightment));
                }
            }
            Run(mapImage);
            Run(mapTeleportImage);
            Run(mapRoadImage);

            mapLayout = mainLayout;

            DrawMap();
        }
        #endregion 地圖

        #region 小地圖

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CreateMiniMap()
        {
            RelativeLayout mainLayout = new RelativeLayout(this);
            mainLayout.Visible(10);
            mainLayout.SetY(15);
            mainLayout.SetBackgroundColor(Color.Argb(255, 160, 180, 255));
            miniMapLayout = mainLayout;

            LinearLayout clickMask = new LinearLayout(this);
            clickMask.Orientation = Orientation.Horizontal;
            mainLayout.AddView(clickMask, new LayoutParams(miniMapGridNum * minimap_size, miniMapGridNum * minimap_size));

            LinearLayout linearly = null;
            void Run(ImageView[,] views)
            {
                for (int y = 0; y < miniMapGridNum; y++)
                {
                    linearly = new LinearLayout(this);
                    linearly.Orientation = Orientation.Horizontal;
                    linearly.SetX(20);
                    linearly.SetY(25 + minimap_size * y);
                    for (int x = 0; x < miniMapGridNum; x++)
                    {
                        linearly.AddView(views[x, y], new LayoutParams(minimap_size, minimap_size));
                    }
                    mainLayout.AddView(linearly, new LayoutParams(miniMapGridNum * minimap_size, minimap_size));
                }
            }
            Run(miniMapImage);
            Run(miniMapRoadImage);
            DrawMiniMap();
        }
        #endregion 小地圖

        #region 大地圖

        #region 本體內容

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CreateBigMapContext(int width, int height)
        {
            bigMapContextLayout.RemoveAllViews();
            for (int x = 0; x < totalBigMapX; x++)
            {
                for (int y = 0; y < totalBigMapY; y++)
                {
                    bigMapImage[x, y].SetX(width / totalBigMapX * (x + 1) * 2 / 3);
                    bigMapImage[x, y].SetY(20 + height / totalBigMapY * (y + 1) * 17 / 18);
                    bigMapContextLayout.AddView(bigMapImage[x, y], new LayoutParams(
                        width / totalBigMapX * 2 / 3 + width / totalBigMapX * 2 % 3,
                        height / totalBigMapY * 17 / 18 + height / totalBigMapY * 17 % 18));
                }
            }
        }

        #endregion 本體內容

        #region 本體

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CreateBigMap(int width, int height)
        {
            RelativeLayout mainLayout = new RelativeLayout(this);
            mainLayout.Invisible();
            //mainLayout.Visibility = ViewStates.Invisible;
            bigMapViewLayout = mainLayout;
            mainLayout.Click += delegate
            {
                // 防止開著大地圖時點到背後的地圖
            };

            RelativeLayout layouts = new RelativeLayout(this);
            layouts.SetX(width / 6);
            layouts.SetY(height % totalBigMapY / 2);
            layouts.SetBackgroundColor(Color.Argb(255, 160, 180, 255));
            //layouts.SetPadding(width % TColNext + width, height % TRowNext + height, 0, 0);
            mainLayout.AddView(layouts, new LayoutParams(width * 2 / 3, height - height % totalBigMapY));
            bigMapContextLayout = layouts;

            CreateBigMapContext(width, height);

            DrawBigMap();

            CreateBigMapFeature(width, height);
        }
        #endregion 本體

        #region 周邊元件

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CreateBigMapFeature(int width, int height)
        {
            int bt_height = height / 5;

            Button button = new Button(this);
            SetButtonFunction(100, 0, Resource.Drawable.search);
            search = button;

            button = new Button(this);
            button.Visibility = ViewStates.Invisible;
            SetButtonFunction(100, 2, Resource.Drawable.search);
            enlarge = button;

            button = new Button(this);
            SetButtonFunction(width - 250, 0, Resource.Drawable.cross);
            buttonreturn = button;

            button = new Button(this);
            button.Visibility = ViewStates.Invisible;
            SetButtonFunction(1000, 5/*00*/, Resource.Drawable.cross);
            // y會飛出去
            buttontest = button;

            void SetButtonFunction(float x, float y, int backgroundResource)
            {
                button.SetX(x);
                button.SetY(bt_height * 4 / 5 * y + bt_height / 4);
                button.SetBackgroundResource(backgroundResource);
                button.Alpha = 0.32f;
                bigMapViewLayout.AddView(button, new LayoutParams(200, 160));
            }

            AutoCompleteTextView text = new AutoCompleteTextView(this);
            text.Invisible();
            text.SetY(100);
            text.Threshold = 1;
            text.SetBackgroundColor(Color.White);
            text.ImeOptions = (ImeAction)ImeFlags.NoFullscreen;
            bigMapViewLayout.AddView(text, new LayoutParams(width - 1000, 100));
            searchtext = text;
            string[] countries = null;
            using (var cn = new SQLiteConnection(_mapDB))
            {
                string titleQuery = "SELECT [title] FROM [Map]";
                List<Map> Map_title = cn.Query<Map>(titleQuery).ToList();
                countries = new string[Map_title.Count];
                for (int i = 0; i < Map_title.Count; i++)
                {
                    countries[i] = Map_title[i].title.Substring(5);
                }
            }
            text.ItemClick += (s, e) =>
            {
                AutoCompleteTextView textView = (AutoCompleteTextView)s;
                string name = textView.Text;
                using (var cn = new SQLiteConnection(_mapDB))
                {
                    string pictureQuery = $"SELECT * FROM [Map] WHERE [title] LIKE '%{name}'";
                    List<Map> Map_mId = cn.Query<Map>(pictureQuery).ToList();
                    for (int i = 0; i < Map_mId.Count; i++)
                    {
                        LoadMap2(Map_mId[i].mId);
                    }
                }
                CreateBigMapContext(width, height);
                DrawMP4();
                buttontest.Invisible();
                InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
                if (imm != null)
                {
                    imm.HideSoftInputFromWindow(this.Window.DecorView.WindowToken, 0);
                }
                searchtext.Invisible();
            };
            RunOnUiThread(() =>
            {
                ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Resource.Layout.list_item, countries);
                text.Adapter = adapter;
            });
        }
        #endregion 周邊元件

        #endregion 大地圖

        #region 沒有網路連線

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void CreateNoInternet()
        {
            RelativeLayout containerLayout = new RelativeLayout(this);
            containerLayout.SetGravity(GravityFlags.Center);
            AddContentView(containerLayout, new LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent));

            RelativeLayout layout = new RelativeLayout(this);
            layout.SetBackgroundColor(Color.Black);
            layout.Alpha = 0;
            containerLayout.AddView(layout, new LayoutParams(1050, 90));
            noInternetLayout = layout;

            TextView textView = new TextView(this);
            textView.TextSize = 18;
            textView.SetY(10);
            textView.SetTextColor(Color.Argb(255, 184, 184, 184));
            textView.SetText("沒有網路連線或能力受限", TextView.BufferType.Normal);
            textView.TextAlignment = TextAlignment.Center;
            layout.AddView(textView, new LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent));
        }

        #endregion 沒有網路連線

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CreateElement()
        {
            #region 前置
            DisplayMetrics dm = new DisplayMetrics();
            WindowManager.DefaultDisplay.GetMetrics(dm);
            width = dm.WidthPixels;//2071
            height = dm.HeightPixels;//1080
            widthment = width / widthcount;
            heightment = height / heightcount;
            #endregion

            ImageView imageView = new ImageView(this);
            imageView.Alpha = 0.85f;
            imageView.SetImageDrawable(GetDrawable(Resource.Drawable.background));
            AddContentView(imageView, new LayoutParams(9600, 1440));
            _imageBackground = imageView;

            RelativeLayout relativeLayouts = new RelativeLayout(this);
            relativeLayouts.SetBackgroundColor(Color.Black);
            relativeLayouts.Alpha = 0.01f;
            relativeLayouts.SetX(width + 2);
            relativeLayouts.Click += delegate { /* 用來防止不當時機按到按鈕 */};
            _transitions = relativeLayouts;

            CreateImageView();
            CreateRole();


            Task[] runSk = new Task[6];
            runSk[0] = Task.Run(() => CreateMap(width, height));
            runSk[1] = Task.Run(() => CreateMiniMap());
            runSk[2] = Task.Run(() => CreateBigMap(width, height));
            runSk[3] = Task.Run(() => CreateMoveButton(height));
            runSk[4] = Task.Run(() => CreateTextView(width, height));
            runSk[5] = Task.Run(() => CreateButton(width, height));
            Task.WaitAll(runSk);

            /*
            CreateMap(width, height);
            CreateMiniMap();
            CreateBigMap(width, height);
            CreateMoveButton(height);
            CreateTextView(width, height);
            CreateButton(width, height);
            */

            AddContentView(mapLayout, new LayoutParams(widthment * (widthcount + 2), heightment * (heightcount + 2)));
            AddContentView(miniMapLayout, new LayoutParams(miniMapGridNum * minimap_size + 40, miniMapGridNum * minimap_size + 50));
            AddContentView(portal, new LayoutParams(200, 160));
            AddContentView(moveButtonLayout, new LayoutParams(px2dpi(moveButtonLayout.Context, 96 + 68), px2dpi(moveButtonLayout.Context, 72 + 36 + 36 + 20)));
            AddContentView(imageViewhero, new LayoutParams(widthment, dp2pxi(imageViewhero.Context, GetDrawable(Resource.Drawable.hero00).IntrinsicHeight) / temp));
            //AddContentView(imageViewhero2, new LayoutParams(widthment, dp2pxi(imageViewhero.Context,GetDrawable(Resource.Drawable.hero00).IntrinsicHeight) / temp2));
            AddContentView(lb_portal, new LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent));
            AddContentView(bigMapViewLayout, new LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent));
            AddContentView(lb_MapTitleShadow, new LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent));
            AddContentView(lb_MapTitle, new LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent));
            AddContentView(buttonLayout, new LayoutParams(204, height));
            TextView textView = new TextView(this);
            //textView.SetX(widthment * (herox - message[3] + nowCol));
            //textView.SetY(heightment * (heroy - 1) + (heightment / 2f - message[4] + nowRow));
            textView.SetX(widthment * widthcount / 2 - 100);
            textView.SetY(heightment * (heightcount / 2) + heightment / 2f);
            textView.TextSize = 24;
            textView.SetTextColor(Color.DarkGray);
            textView.SetText(TitleActivity.ID, TextView.BufferType.Normal);
            //AddContentView(textView, new LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent));


            AddContentView(_transitions, new LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent));
        }
        #endregion

        #region 網路類

        #region 列表

        /*
         * 0 -> 上線 (後續資料為字串 -> ID)
         * 1 -> 下線 (後續資料為字串 -> ID)
         * 2 -> 移動 (後續資料為位元陣列 -> ID,mId,nowCol,nowRow)
         * 3 -> 獲得ID
        */
        #endregion 列表



        protected void Listen()
        {
            message = new byte[4096]; //存放接收的資料
            while (true)
            {
                try
                {

                    int recv = _socket.ReceiveFrom(message, ref Remote); //(收到的資料,來自哪個IP放進Remote) 不能放IPEndPoint 好像是它唯獨的關係 這時候sender已經變成跟remoteIP一樣
                    switch (message[0])
                    {
                        case 0:

                            break;
                        case 1:

                            break;
                        case 2:
                            if (myID == message[1])
                            {

                            }
                            else
                            {
                                imageViewhero2.SetX(widthment * (herox + message[3] - nowX));
                                imageViewhero2.SetY(heightment * (heroy - 1) + (heightment / 2f + message[4] - nowY));
                            }
                            break;
                        case 3:
                            myID = message[1];
                            break;
                        default:

                            break;
                    }
                    //Debug.WriteLine("伺服器來自 " + "[" + Remote.ToString() + "] : " + Encoding.UTF8.GetString(message, 0, recv)); //顯示資料前也要編碼一次 轉換回string資料格式
                }
                catch (Exception ex)
                {
                    Console.WriteLine("-----------接收網路訊息出錯-----------");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("-----------接收網路訊息出錯-----------");
                }
            }
        }

        #endregion 網路類

        #region 事件驅動方法

        #region 移動

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected void MoveMindRole()
        {
            void Move(byte directions, int range)
            {
                if (directions > 2)
                {
                    if (xDotRange != -4 && xDotRange != 4)
                    {
                        if (nowX - widthcount / 2 - 2 < 1 || nowX + widthcount / 2 + 2 > totalX ||
                            nowY - heightcount / 2 - 2 < 1 || nowY + heightcount / 2 + 2 > totalY)
                        {
                            imageViewhero.SetX(imageViewhero.GetX() + range / 4f);
                            return;
                        }
                        else
                        {
                            mapLayout.SetX(mapLayout.GetX() - range / 4f);
                            return;
                        }
                    }
                    else
                    {
                        xDotRange = 0;
                        nowX += (ushort)(range > 0 ? 1 : -1);
                        mapLayout.SetX(-widthment);
                        imageViewhero.SetX(widthment * herox);
                    }
                }
                else
                {
                    if (yDotRange != -4 && yDotRange != 4)
                    {
                        if (nowX - widthcount / 2 - 2 < 1 || nowX + widthcount / 2 + 2 > totalX ||
                            nowY - heightcount / 2 - 2 < 1 || nowY + heightcount / 2 + 2 > totalY)
                        {
                            imageViewhero.SetY(imageViewhero.GetY() + range / 4f);
                            return;
                        }
                        else
                        {
                            mapLayout.SetY(mapLayout.GetY() - range / 4f);
                            return;
                        }
                    }
                    else
                    {
                        yDotRange = 0;
                        nowY += (ushort)(range > 0 ? 1 : -1);
                        mapLayout.SetY(-heightment);
                        imageViewhero.SetY(heightment * (heroy - 1) + heightment / 2f);
                    }
                }
                //byte[] loc = { myID, (byte)mapId, (byte)nowX, (byte)nowY };
                //Network.Send(2, ref loc);

                /*message[1] = (byte)nowCol;
                message[2] = (byte)nowRow;
                stream.Write(message, 0, 3);*/
                DrawMiniMap();
                DrawMap();
                CheckTeleport();
                xxxx();
                if (imageViewhero.GetX() < miniMapLayout.GetX() + miniMapLayout.Width)
                    miniMapLayout.SetX(width - miniMapLayout.Width);
                else
                    miniMapLayout.SetX(10);
                if (imageViewhero.GetY() < miniMapLayout.GetY() + miniMapLayout.Height)
                    miniMapLayout.SetX(height - miniMapLayout.Height);
                else
                    miniMapLayout.SetX(15);
            }
            Task.Run(() =>
            {
                _moveing = true;
                while (_moveing)
                {
                    Thread.Sleep(moveSpeedDelayTime);
                    switch (direction)
                    {
                        case (byte)Direction.direction.上:
                            if (nowY - 1 > 0)
                            {
                                if (canWalk[nowX, nowY - 1])
                                {
                                    RunOnUiThread(() =>
                                    {
                                        yDotRange++;
                                        Move((byte)Direction.direction.上, -heightment);
                                    });

                                }
                            }
                            break;
                        case (byte)Direction.direction.下:
                            if (nowY + 1 < totalY)
                            {
                                if (canWalk[nowX, nowY + 1])
                                {
                                    RunOnUiThread(() =>
                                    {
                                        yDotRange--;
                                        Move((byte)Direction.direction.下, heightment);
                                    });

                                }
                            }
                            break;
                        case (byte)Direction.direction.左:
                            if (nowX - 1 > 0)
                            {
                                if (canWalk[nowX - 1, nowY])
                                {
                                    RunOnUiThread(() =>
                                    {
                                        xDotRange++;
                                        Move((byte)Direction.direction.左, -widthment);
                                    });

                                }
                            }
                            break;
                        case (byte)Direction.direction.右:
                            if (nowX + 1 < totalX)
                            {
                                if (canWalk[nowX + 1, nowY])
                                {
                                    RunOnUiThread(() =>
                                    {
                                        xDotRange--;
                                        Move((byte)Direction.direction.右, widthment);
                                    });

                                }
                            }
                            break;
                    }
                }
            });
        }

        #endregion 移動

        #region 在大地圖時點擊圖片

        protected void seaechpath(Maps previewMap, ushort x,ushort y)
        {
            if (previewMap.mapWalk[x, y])
            {
                roadMaps.Clear();
                nearestTeleportNode.Clear();

                if (previewMap.mId == nowMap.mId)
                {
                    PathSearch search = new PathSearch(nowX, nowY, x, y, canWalk);
                    Task.Run(() =>
                    {
                        nearestTeleportNode.Add(search.GetResultPath());
                        var map = new Map();
                        map.mId = nowMap.mId;
                        roadMaps.Add(map);
                        SwitchRoad();
                    });
                }
                else
                {
                    string previewMapTitle = previewMap.title.Substring(0, 5);
                    string nowMapTitle = nowMap.title.Substring(0, 5);
                    string APath = nowMapTitle + "-";
                    if (nowMapTitle.Substring(0, 1) == "0")
                    {
                        APath += previewMapTitle.Substring(0, 1) + "1000";
                        if (previewMapTitle.Substring(1, 1) != "1")
                        {
                            APath += "-" + previewMapTitle.Substring(0, 2) + "000";
                        }
                        if (previewMapTitle.Substring(2, 3) != "000")
                        {
                            APath += "-" + previewMapTitle;
                        }
                    }
                    else
                    {
                        if (previewMapTitle.Substring(0, 1) == "0")
                        {
                            if (nowMapTitle.Substring(2, 3) != "000")
                            {
                                APath += nowMapTitle.Substring(0, 2) + "000-";
                            }
                            if (nowMapTitle.Substring(1, 1) != "1")
                            {
                                APath += nowMapTitle.Substring(0, 1) + "1000-";
                            }
                        }
                        else
                        {
                            if (previewMapTitle.Substring(0, 1) == nowMapTitle.Substring(0, 1))
                            {
                                if (previewMapTitle.Substring(1, 1) != nowMapTitle.Substring(1, 1))
                                {
                                    if (nowMapTitle.Substring(2, 3) != "000")
                                    {
                                        APath += nowMapTitle.Substring(0, 2) + "000-";
                                    }
                                }
                            }
                            else
                            {
                                if (nowMapTitle.Substring(2, 3) != "000")
                                {
                                    if (nowMapTitle.Substring(1, 1) != "1")
                                    {
                                        APath += nowMapTitle.Substring(0, 2) + "000-";
                                    }
                                }
                                if (nowMapTitle.Substring(1, 1) != "1")
                                {
                                    APath += nowMapTitle.Substring(0, 1) + "1000-";
                                }
                                APath += "00000-";
                                if (previewMapTitle.Substring(1, 1) != "1")
                                {
                                    APath += previewMapTitle.Substring(0, 1) + "1000-";
                                }
                            }
                            if (previewMapTitle.Substring(2, 3) != "000")
                            {
                                APath += previewMapTitle.Substring(0, 2) + "000-";
                            }
                        }
                        APath += previewMapTitle;
                    }

                    string[] targetMapCode = APath.Split('-');
                    for (int i = 0; i < targetMapCode.Length; i++)
                    {
                        using (var cn = new SQLiteConnection(_mapDB))
                        {
                            string pictureQuery = $"SELECT * FROM [Map] WHERE [title] LIKE '{targetMapCode[i]}%'";
                            roadMaps.Add(cn.Query<Map>(pictureQuery)[0]);
                        }
                    }



                    var relayPointTeleports = new List<List<Teleport>>();
                    foreach (var item in targetMapCode)
                        relayPointTeleports.Add(new List<Teleport>());

                    var targetPointTeleports = new List<Teleport>();

                    for (ushort i = 0; i < targetMapCode.Length; i++)
                        foreach (var item in teleportList)
                            if (item.mId == roadMaps[i].mId)
                                relayPointTeleports[i].Add(item);

                    for (ushort index = 0; index < relayPointTeleports.Count; index++)
                    {
                        var item = relayPointTeleports[index];

                        if (index + 1 < relayPointTeleports.Count)
                        {
                            var itemNext = relayPointTeleports[index + 1];
                            for (ushort i = 0; i < item.Count; i++)
                                for (ushort j = 0; j < itemNext.Count; j++)
                                    if (item[i].teleport == itemNext[j].tId)
                                        targetPointTeleports.Add(item[i]);
                        }
                    }

                    foreach (var item in relayPointTeleports)
                        item.Clear();

                    foreach (var item in targetPointTeleports)
                    {
                        for (ushort i = 0; i < roadMaps.Count; i++)
                            if (item.mId == roadMaps[i].mId)
                                relayPointTeleports[i].Add(item);
                    }

                    targetPointTeleports.Clear();

                    float minHscore = float.MaxValue;
                    ushort targetTId = 0;

                    for (ushort index = 0; index < relayPointTeleports[0].Count; index++)
                    {
                        var item = relayPointTeleports[0][index];
                        float hscore = (float)Math.Sqrt((item.col - nowX) * (item.col - nowX) + (item.row - nowY) * (item.row - nowY));
                        if (hscore < minHscore)
                        {
                            minHscore = hscore;
                            targetTId = item.tId;
                        }
                    }

                    foreach (var item in relayPointTeleports[0])
                        if (targetTId == item.tId)
                            targetPointTeleports.Add(item);

                    for (ushort index = 1; index < relayPointTeleports.Count; index++)
                    {
                        minHscore = float.MaxValue;
                        var itemNow = teleportList[targetPointTeleports[index - 1].teleport - 1];
                        for (ushort i = 0; i < relayPointTeleports[index].Count; i++)
                        {
                            var item = relayPointTeleports[index][i];
                            float hscore = (float)Math.Sqrt((item.col - itemNow.col) * (item.col - itemNow.col) + (item.row - itemNow.row) * (item.row - itemNow.row));
                            if (hscore < minHscore)
                            {
                                minHscore = hscore;
                                targetTId = item.tId;
                            }
                        }
                        foreach (var item in relayPointTeleports[index])
                            if (targetTId == item.tId)
                                targetPointTeleports.Add(item);
                    }

                    var teleport = new Teleport();
                    teleport.col = x;
                    teleport.row = y;
                    teleport.mId = previewMap.mId;
                    targetPointTeleports.Add(teleport);

                    var mapsData = new Maps[roadMaps.Count - 1];
                    var nearestTeleportPathSearch = new PathSearch[roadMaps.Count];

                    ushort targetX = targetPointTeleports[0].col;
                    ushort targetY = targetPointTeleports[0].row;
                    nearestTeleportPathSearch[0] = new PathSearch(nowX, nowY, targetX, targetY, canWalk);

                    for (ushort index = 1; index < roadMaps.Count; index++)
                    {
                        teleport = targetPointTeleports[index - 1];
                        teleport = teleportList[teleport.teleport - 1];

                        var nowX = teleport.col;
                        var nowY = teleport.row;

                        mapsData[index - 1] = new Maps(roadMaps[index].mId);

                        targetX = targetPointTeleports[index].col;
                        targetY = targetPointTeleports[index].row;

                        nearestTeleportPathSearch[index] = new PathSearch(nowX, nowY, targetX, targetY, mapsData[index - 1].mapWalk);
                    }
                    Task task = Task.Run(() =>
                    {
                        for (ushort i = 0; i < nearestTeleportPathSearch.Length; i++)
                        {
                            nearestTeleportNode.Add(nearestTeleportPathSearch[i].GetResultPath());
                        }
                    });
                    task.Wait();
                }

                SwitchRoad();
                bigMapViewLayout.Invisible();
                searchtext.Invisible();
                miniMapLayout.Visible(10);
                buttonLayout.Visible(width - 252);
                moveButtonLayout.Visible(0);
            }
        }

        #endregion 在大地圖時點擊圖片

        #endregion 事件驅動方法

        #region 事件

        public void minimap_bigmap_click()
        {
            miniMapLayout.Click += delegate
            {
                bigMapViewLayout.Visible(0);
                miniMapLayout.Invisible();
                moveButtonLayout.Invisible();
                buttonLayout.Invisible();
                bigMapContextLayout.Invalidate();
                if (rollBackBigMap.Count > 0)
                {
                    foreach (var item in rollBackBigMap)
                        bigMapImage[item.x, item.y].SetImageDrawable(item.image);
                    rollBackBigMap.Clear();
                }
                rollBackBigMap.Add(new RollBackBigMap(nowX, nowY, bigMapImage[nowX, nowY].Drawable));
                bigMapImage[nowX, nowY].SetImageDrawable(GetDrawable(Resource.Drawable.hero00));
            };
            buttonreturn.Click += delegate
            {
                bigMapViewLayout.Invisible();
                searchtext.Invisible();
                miniMapLayout.Visible(10);
                buttonLayout.Visible(width - 252);
                moveButtonLayout.Visible(0);
            };
            search.Click += delegate
            {
                if (searchtext.IsVisible())
                    searchtext.Invisible();
                else
                    searchtext.Visible(500);
            };
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void BigMapImageIsClick(ushort x , ushort y)
        {
                    bigMapImage[x, y].Click += delegate
                    {
                        if (previewMap.mapWalk[x, y])
                        {
                            roadMaps.Clear();
                            nearestTeleportNode.Clear();
                            _mapTitleIsRunnimg = false;
                            try
                            {
                                _mapTitleTask.Dispose();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("-----------顯示地圖名稱出錯-----------");
                                Console.WriteLine(ex.Message);
                                Console.WriteLine("-----------顯示地圖名稱出錯-----------");
                            }
                            lb_MapTitle.Text = "規劃路線中";
                            lb_MapTitle.TextAlignment = TextAlignment.Center;
                            lb_MapTitle.Alpha = 1;
                            lb_MapTitleShadow.Text = "規劃路線中";
                            lb_MapTitleShadow.TextAlignment = TextAlignment.Center;
                            lb_MapTitleShadow.Alpha = 0.3f;
                            Task task = Task.Run(() => { });
                            if (previewMap.mId == nowMap.mId)
                            {
                                PathSearch search = new PathSearch(nowX, nowY, x, y, canWalk);
                                Task.Run(() =>
                                {
                                    nearestTeleportNode.Add(search.GetResultPath());
                                    var map = new Map();
                                    map.mId = nowMap.mId;
                                    roadMaps.Add(map);
                                    RunOnUiThread(() =>
                                    {
                                        _mapTitleTask = Task.Run(() =>
                                        {
                                            Thread.Sleep(2000);
                                            _mapTitleIsRunnimg = true;
                                            while (_mapTitleIsRunnimg && lb_MapTitle.Alpha > 0.1f)
                                            {
                                                Thread.Sleep(16);
                                                lb_MapTitle.Alpha -= 0.027f;
                                                lb_MapTitleShadow.Alpha -= 0.01f;
                                            }
                                            if (lb_MapTitle.Alpha < 0.1f) lb_MapTitle.Alpha = 0.01f;
                                            _mapTitleIsRunnimg = false;
                                        });
                                        SwitchRoad();
                                        bigMapViewLayout.Invisible();
                                        searchtext.Invisible();
                                        miniMapLayout.Visible(10);
                                        buttonLayout.Visible(width - 252);
                                        moveButtonLayout.Visible(0);
                                    });
                                });
                            }
                            else
                            {
                                string previewMapTitle = previewMap.title.Substring(0, 5);
                                string nowMapTitle = nowMap.title.Substring(0, 5);
                                string APath = nowMapTitle + "-";
                                if (nowMapTitle.Substring(0, 1) == "0")
                                {
                                    APath += previewMapTitle.Substring(0, 1) + "1000";
                                    if (previewMapTitle.Substring(1, 1) != "1")
                                    {
                                        APath += "-" + previewMapTitle.Substring(0, 2) + "000";
                                    }
                                    if (previewMapTitle.Substring(2, 3) != "000")
                                    {
                                        APath += "-" + previewMapTitle;
                                    }
                                }
                                else
                                {
                                    if (previewMapTitle.Substring(0, 1) == "0")
                                    {
                                        if (nowMapTitle.Substring(2, 3) != "000")
                                        {
                                            APath += nowMapTitle.Substring(0, 2) + "000-";
                                        }
                                        if (nowMapTitle.Substring(1, 1) != "1")
                                        {
                                            APath += nowMapTitle.Substring(0, 1) + "1000-";
                                        }
                                    }
                                    else
                                    {
                                        if (previewMapTitle.Substring(0, 1) == nowMapTitle.Substring(0, 1))
                                        {
                                            if (previewMapTitle.Substring(1, 1) != nowMapTitle.Substring(1, 1))
                                            {
                                                if (nowMapTitle.Substring(2, 3) != "000")
                                                {
                                                    APath += nowMapTitle.Substring(0, 2) + "000-";
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (nowMapTitle.Substring(2, 3) != "000")
                                            {
                                                if (nowMapTitle.Substring(1, 1) != "1")
                                                {
                                                    APath += nowMapTitle.Substring(0, 2) + "000-";
                                                }
                                            }
                                            if (nowMapTitle.Substring(1, 1) != "1")
                                            {
                                                APath += nowMapTitle.Substring(0, 1) + "1000-";
                                            }
                                            APath += "00000-";
                                            if (previewMapTitle.Substring(1, 1) != "1")
                                            {
                                                APath += previewMapTitle.Substring(0, 1) + "1000-";
                                            }
                                        }
                                        if (previewMapTitle.Substring(2, 3) != "000")
                                        {
                                            APath += previewMapTitle.Substring(0, 2) + "000-";
                                        }
                                    }
                                    APath += previewMapTitle;
                                }

                                string[] targetMapCode = APath.Split('-');
                                for (int i = 0; i < targetMapCode.Length; i++)
                                {
                                    using (var cn = new SQLiteConnection(_mapDB))
                                    {
                                        string pictureQuery = $"SELECT * FROM [Map] WHERE [title] LIKE '{targetMapCode[i]}%'";
                                        roadMaps.Add(cn.Query<Map>(pictureQuery)[0]);
                                    }
                                }



                                var relayPointTeleports = new List<List<Teleport>>();
                                foreach (var item in targetMapCode)
                                    relayPointTeleports.Add(new List<Teleport>());

                                var targetPointTeleports = new List<Teleport>();

                                for (ushort i = 0; i < targetMapCode.Length; i++)
                                    foreach (var item in teleportList)
                                        if (item.mId == roadMaps[i].mId)
                                            relayPointTeleports[i].Add(item);

                                for (ushort index = 0; index < relayPointTeleports.Count; index++)
                                {
                                    var item = relayPointTeleports[index];

                                    if (index + 1 < relayPointTeleports.Count)
                                    {
                                        var itemNext = relayPointTeleports[index + 1];
                                        for (ushort i = 0; i < item.Count; i++)
                                            for (ushort j = 0; j < itemNext.Count; j++)
                                                if (item[i].teleport == itemNext[j].tId)
                                                    targetPointTeleports.Add(item[i]);
                                    }
                                }

                                foreach (var item in relayPointTeleports)
                                    item.Clear();

                                foreach (var item in targetPointTeleports)
                                {
                                    for (ushort i = 0; i < roadMaps.Count; i++)
                                        if (item.mId == roadMaps[i].mId)
                                            relayPointTeleports[i].Add(item);
                                }

                                targetPointTeleports.Clear();

                                float minHscore = float.MaxValue;
                                ushort targetTId = 0;

                                for (ushort index = 0; index < relayPointTeleports[0].Count; index++)
                                {
                                    var item = relayPointTeleports[0][index];
                                    float hscore = (float)Math.Sqrt((item.col - nowX) * (item.col - nowX) + (item.row - nowY) * (item.row - nowY));
                                    if (hscore < minHscore)
                                    {
                                        minHscore = hscore;
                                        targetTId = item.tId;
                                    }
                                }

                                foreach (var item in relayPointTeleports[0])
                                    if (targetTId == item.tId)
                                        targetPointTeleports.Add(item);

                                for (ushort index = 1; index < relayPointTeleports.Count; index++)
                                {
                                    minHscore = float.MaxValue;
                                    var itemNow = teleportList[targetPointTeleports[index - 1].teleport - 1];
                                    for (ushort i = 0; i < relayPointTeleports[index].Count; i++)
                                    {
                                        var item = relayPointTeleports[index][i];
                                        float hscore = (float)Math.Sqrt((item.col - itemNow.col) * (item.col - itemNow.col) + (item.row - itemNow.row) * (item.row - itemNow.row));
                                        if (hscore < minHscore)
                                        {
                                            minHscore = hscore;
                                            targetTId = item.tId;
                                        }
                                    }
                                    foreach (var item in relayPointTeleports[index])
                                        if (targetTId == item.tId)
                                            targetPointTeleports.Add(item);
                                }

                                var teleport = new Teleport();
                                teleport.col = x;
                                teleport.row = y;
                                teleport.mId = previewMap.mId;
                                targetPointTeleports.Add(teleport);

                                var mapsData = new Maps[roadMaps.Count - 1];
                                var nearestTeleportPathSearch = new PathSearch[roadMaps.Count];

                                ushort targetX = targetPointTeleports[0].col;
                                ushort targetY = targetPointTeleports[0].row;
                                nearestTeleportPathSearch[0] = new PathSearch(nowX, nowY, targetX, targetY, canWalk);

                                for (ushort index = 1; index < roadMaps.Count; index++)
                                {
                                    teleport = targetPointTeleports[index - 1];
                                    teleport = teleportList[teleport.teleport - 1];

                                    var nowX = teleport.col;
                                    var nowY = teleport.row;

                                    mapsData[index - 1] = new Maps(roadMaps[index].mId);

                                    targetX = targetPointTeleports[index].col;
                                    targetY = targetPointTeleports[index].row;

                                    nearestTeleportPathSearch[index] = new PathSearch(nowX, nowY, targetX, targetY, mapsData[index - 1].mapWalk);
                                }
                                task = Task.Run(() =>
                                {
                                    for (ushort i = 0; i < nearestTeleportPathSearch.Length; i++)
                                    {
                                        nearestTeleportNode.Add(nearestTeleportPathSearch[i].GetResultPath());
                                    }
                                    RunOnUiThread(() =>
                                    {
                                        _mapTitleTask = Task.Run(() =>
                                        {
                                            Thread.Sleep(2000);
                                            _mapTitleIsRunnimg = true;
                                            while (_mapTitleIsRunnimg && lb_MapTitle.Alpha > 0.1f)
                                            {
                                                Thread.Sleep(16);
                                                lb_MapTitle.Alpha -= 0.027f;
                                                lb_MapTitleShadow.Alpha -= 0.01f;
                                            }
                                            if (lb_MapTitle.Alpha < 0.1f) lb_MapTitle.Alpha = 0.01f;
                                            _mapTitleIsRunnimg = false;
                                        });
                                        SwitchRoad();
                                        bigMapViewLayout.Invisible();
                                        searchtext.Invisible();
                                        miniMapLayout.Visible(10);
                                        buttonLayout.Visible(width - 252);
                                        moveButtonLayout.Visible(0);
                                    });
                                });
                            }
                        }
                    };
        }
        public virtual void xxxx()
        {

        }
        public void click()
        {
            up.Touch += (v, e) =>
            {
                direction = (byte)Direction.direction.上;
                switch (e.Event.Action)
                {
                    case MotionEventActions.Down:
                        MoveMindRole();
                        break;
                    case MotionEventActions.Up:
                        _moveing = false;
                        break;
                }
            };
            down.Touch += (v, e) =>
            {
                direction = (byte)Direction.direction.下;
                switch (e.Event.Action)
                {
                    case MotionEventActions.Down:
                        MoveMindRole();
                        break;
                    case MotionEventActions.Up:
                        _moveing = false;
                        break;
                }
            };
            left.Touch += (v, e) =>
            {
                direction = (byte)Direction.direction.左;
                switch (e.Event.Action)
                {
                    case MotionEventActions.Down:
                        MoveMindRole();
                        break;
                    case MotionEventActions.Up:
                        _moveing = false;
                        break;
                }
            };
            right.Touch += (v, e) =>
            {
                direction = (byte)Direction.direction.右;
                switch (e.Event.Action)
                {
                    case MotionEventActions.Down:
                        MoveMindRole();
                        break;
                    case MotionEventActions.Up:
                        _moveing = false;
                        break;
                }
            };
        }

        public void portalclick()
        {
            portal.Click += delegate
            {
                Intent intent = new Intent(Intent.ActionView, Android.Net.Uri.Parse("https://www.npu.edu.tw/index.aspx"));
                StartActivity(intent);
            };
            portal1.Click += delegate
            {
                if (portal1.Text.Equals("上一頁"))
                {
                    teleportPage--;
                    if (teleportPage > 0)
                        portal1.Text = "上一頁";
                    else
                        LoadMapTitle(teleportList[readyTeleport[0].teleport - 1].mId).Substring(5);
                    if (teleportPage == 0)
                    {
                        portal1.Text = LoadMapTitle(teleportList[readyTeleport[0].teleport - 1].mId).Substring(5);
                        portal2.Text = LoadMapTitle(teleportList[readyTeleport[1].teleport - 1].mId).Substring(5);
                        portal3.Text = LoadMapTitle(teleportList[readyTeleport[2].teleport - 1].mId).Substring(5);
                        portal4.Text = "下一頁";
                        portal1.Visibility = ViewStates.Visible;
                        portal2.Visibility = ViewStates.Visible;
                        portal3.Visibility = ViewStates.Visible;
                        portal4.Visibility = ViewStates.Visible;
                    }
                    else
                    {
                        portal1.Visibility = ViewStates.Visible;
                        portal2.Text = LoadMapTitle(teleportList[readyTeleport[teleportPage * 2 + 1].teleport - 1].mId).Substring(5);
                        portal3.Text = LoadMapTitle(teleportList[readyTeleport[teleportPage * 2 + 2].teleport - 1].mId).Substring(5);
                        portal4.Text = "下一頁";
                        portal2.Visibility = ViewStates.Visible;
                        portal3.Visibility = ViewStates.Visible;
                        portal4.Visibility = ViewStates.Visible;
                    }
                }
                else
                    Teleport(1);

            };
            portal2.Click += delegate
            {
                Teleport(2);
            };
            portal3.Click += delegate
            {
                Teleport(3);
            };
            portal4.Click += delegate
            {
                teleportPage++;
                portal1.Text = "上一頁";
                portal1.Visible(0);
                /*if (teleportPage ==1)
                {
                    portal3.SetTextColor(Color.Argb(255, 255, 0, 0));
                }
                else
                {
                    portal3.SetTextColor(Color.Black);
                }*/
                switch (readyTeleport.Count - 1 - teleportPage * 2)
                {
                    case 1:
                        portal2.Text = LoadMapTitle(teleportList[readyTeleport[teleportPage * 2 + 1].teleport - 1].mId).Substring(5);
                        portal2.Visible(0);
                        portal3.Invisible();
                        portal4.Invisible();
                        break;
                    case 2:
                        portal2.Text = LoadMapTitle(teleportList[readyTeleport[teleportPage * 2 + 1].teleport - 1].mId).Substring(5);
                        portal3.Text = LoadMapTitle(teleportList[readyTeleport[teleportPage * 2 + 2].teleport - 1].mId).Substring(5);
                        portal2.Visible(0);
                        portal3.Visible(0);
                        portal4.Invisible();
                        break;
                    default:
                        portal2.Text = LoadMapTitle(teleportList[readyTeleport[teleportPage * 2 + 1].teleport - 1].mId).Substring(5);
                        portal3.Text = LoadMapTitle(teleportList[readyTeleport[teleportPage * 2 + 2].teleport - 1].mId).Substring(5);
                        portal4.Text = "下一頁";
                        portal2.Visible(0);
                        portal3.Visible(0);
                        portal4.Visible(0);
                        break;
                }
            };
        }

        #endregion 事件

    }
}