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
using Xamarin.Essentials;
using System.Threading;
using Android.Content;
using PenghuSpace.lib;
using DocumentFormat.OpenXml.Drawing;
using Resource = UniversityAndroidApp.Resource;
#endregion using

namespace PenghuSpace.Activity
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", ScreenOrientation = Android.Content.PM.ScreenOrientation.Landscape)]

    public class StoryBase : Base
    {
        #region 元件變數
        TextView lbDialog, lbMission, lbMixProduct, lbMixMaterial;
        Button butBackpack, eventPortal, butMission, butMissionYes, butMissionNo, butMix;
        RelativeLayout BackpackInterface, dialogInterface, MissionInterface, BulletinInterface, MixInterface;
        RecyclerView rvBackpack, rvBulletin;
        RecyclerView.LayoutManager rlayoutmanager, rlayoutmanagerBulletin;
        RecyclerViewAdapter radapter;
        RecyclerViewAdapterBulletin radapterBulletin;
        #endregion

        #region 列表變數
        internal List<ushort> items = new List<ushort>();
        internal string[] nowDialoglist;
        internal List<Data> datas = new List<Data>();
        internal List<Bulletin> Bulletins = new List<Bulletin>();
        internal List<Event> eventList = new List<Event>();
        List<Event> nowEventList = new List<Event>();
        List<string> StartList = new List<string>();
        List<string> StoryList = new List<string>();
        List<string> dialogList = new List<string>();
        List<string> MissionList = new List<string>();
        List<string> returnList = new List<string>();
        List<List<string>> StartAndStoryAndDialogList = new List<List<string>>();
        #endregion

        #region 全域變數
        internal int dialogCount = 0;
        internal int nowlevel = 1;
        internal int nowDialogLocation = 0;
        internal int itemtypeCount = 0;
        internal bool nowDialog = true;
        story story = new story();
        Array EnumNames = Enum.GetNames(typeof(story.itemEnum));
        Array EnumValues = Enum.GetValues(typeof(story.itemEnum));
        int widthPix = 0;
        int heightPix = 0;
        #endregion

        #region 開始
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Platform.Init(this, savedInstanceState);
            CreateBag();
            rlayoutmanager = new LinearLayoutManager(this);
            rvBackpack.SetLayoutManager(rlayoutmanager);
            radapter = new RecyclerViewAdapter(datas);
            rvBackpack.SetAdapter(radapter);

            rlayoutmanagerBulletin = new LinearLayoutManager(this);
            rvBulletin.SetLayoutManager(rlayoutmanagerBulletin);
            radapterBulletin = new RecyclerViewAdapterBulletin(Bulletins);
            rvBulletin.SetAdapter(radapterBulletin);
            radapterBulletin.DatasAdd(Resource.Drawable.search, "澎科大資管系網");
            radapterBulletin.DatasAdd(Resource.Drawable.search, "澎科大資管系最新消息");
            //imageViewhero.SetX(widthment * herox);
            //imageViewhero.SetY(heightment * (heroy - 1) + heightment / 2f);
            StartList.Add("");
            StoryList.Add("");
            dialogList.Add("");
            StartAndStoryAndDialogList.Add(StartList);
            StartAndStoryAndDialogList.Add(StoryList);
            StartAndStoryAndDialogList.Add(dialogList);
            MissionList.Add("專題發表會快來不及了快去210吧");
            MissionList.Add("去看六樓布告欄吧。");
            MissionList.Add("鄰近聖誕節為了不要被情侶閃瞎，去生輔組做生命輔導吧");

            /*MissionList.Add("你從小父母雙亡現在已經助學貸款的最後一天了，為了不要被退學趕快跑向註冊組吧!!");
            MissionList.Add("開學第一天一定要塑造好形象，為了霸凌快找出實驗大樓地下演講廳吧!!");
            MissionList.Add("合成澎科之魂a");
            MissionList.Add("找尋澎科之魂b");
            MissionList.Add("合成完整的澎科之魂");

            MissionList.Add("大學一定會去一次");
            MissionList.Add("我的人生沒有蘋果");
            MissionList.Add("那裡有著一堆廢話但你不得不去");
            MissionList.Add("去離你生活最近的地方");
            MissionList.Add("前往我所在的地方合成澎科之魂a");
            MissionList.Add("找尋澎科之魂b");
            MissionList.Add("合成完整的澎科之魂");*/
            NewClick();
            itemtypeCount = EnumNames.Length;
            eventList = story.AddEvent(eventList);
            SetEvent();
            CheckEvent();
            for (int i = 0; i < itemtypeCount; i++)
            {
                items.Add(0);
            }
            teleportEvent.teleportevent += new EventHandler(TeleportEvent);
            /*System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();
            stopWatch.Stop();
            System.Diagnostics.Debug.WriteLine(stopWatch.ElapsedMilliseconds);*/
        }
        #endregion
        private void WhoWakeMeUp()
        {
            //取得調用堆疊
            System.Diagnostics.StackTrace oStack = new System.Diagnostics.StackTrace(true);
            //取得呼叫當前方法之上一層類別方法（因為程式碼已經寫在「父類別的方法」裡面了，所以要跳２層）
            System.Reflection.MethodBase oMethod = oStack.GetFrame(2).GetMethod();
            //取得呼叫當前方法之上一層類別方法的類別名稱
            string x = $"我知道是{oMethod.DeclaringType.Name}類別的{oMethod.Name}方法來調用我。";
        }

        #region 事件
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void GetEvent(Event Event)
        {
            //EventId
            //1:取得物品 2:傳送 3:開啟文字描述 4:開啟布告欄
            //100:獲勝 101:死亡
            //textID
            //0:劇情 1:故事 2:對話
            switch (Event.EventID)
            {
                case 1:
                    Random random = new Random();
                    int rm = random.Next(EnumValues.Length);
                    while ((int)EnumValues.GetValue(rm) == 100)
                    {
                        rm = random.Next(EnumValues.Length);
                    }
                    TitleAnimation("你取得了" + Event.ItemCount + "個" + EnumValues.GetValue(rm).ToString() + "");
                    items[(ushort)rm] = (ushort)(items[rm] + Event.ItemCount);
                    break;
                case 2:
                    /*LoadMap(Event.nextmId);
                    LoadMapTitle();
                    nowX = Event.nextcol;
                    nowY = Event.nextrow;
                    DrawMap();
                    SetEvent();
                    teleportEvent.Run();*/
                    break;
                case 3:
                    dialogInterface.SetY(height / 2);
                    eventPortal.SetX(widthPix);//width - 250
                    nowDialoglist = StartAndStoryAndDialogList[Event.textID][Event.dialogueParagraph].Split("\n");
                    nowDialogLocation = 0;
                    lbDialog.Text = nowDialoglist[nowDialogLocation];
                    break;
                case 4:
                    ShowBulletin();
                    break;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void SetEvent()
        {
            nowEventList.Clear();
            foreach (var item in eventList)
            {
                if (item.mId == nowMap.mId)
                {
                    nowEventList.Add(item);
                }
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void CheckEvent()
        {
            foreach (var item in nowEventList)
            {
                if (item.row == nowY && item.col == nowX)
                {
                    if (item.EventID < 100)
                    {
                        eventPortal.SetBackgroundResource(Resource.Drawable.hand);
                        eventPortal.SetX(width - 250);
                        break;
                    }
                    else
                    {
                        eventPortal.SetX(widthPix);//width - 250
                    }
                }
                else
                {
                    eventPortal.SetX(widthPix);//width - 250
                }
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CommandTeleport(int Commandid)
        {
            foreach (var item in eventList)
            {
                if (item.Commandid == Commandid)
                {
                    eventPortal.SetBackgroundResource(Resource.Drawable.open);
                    LoadMap(item.nextmId);
                    nowX = item.nextcol;
                    nowY = item.nextrow;
                    switch (Commandid)
                    {
                        case 1:
                            Maps maps = new Maps(26);
                            seaechpath(maps, 2, 4);
                            break;
                        case 2:
                            Maps maps2 = new Maps(119);
                            seaechpath(maps2, 8, 42);
                            break;
                    }
                    DrawMap();
                    DrawMiniMap();
                    DrawMapTitle();
                    SetEvent();
                }
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CommandItem(int ItemID)
        {
            foreach (var item in eventList)
            {
                if (item.ItemID == ItemID)
                {
                    for (int i = 0; i < EnumValues.Length; i++)
                    {
                        if ((int)EnumValues.GetValue(i) == ItemID)
                        {
                            nowDialoglist = ("你取得了" + item.ItemCount + "個" + EnumValues.GetValue(i).ToString()).Split("\n");
                            nowDialogLocation = 0;
                            lbDialog.Text = nowDialoglist[nowDialogLocation];
                            items[i] = (ushort)(items[i] + item.ItemCount);
                            break;
                        }
                    }
                    break;
                }
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected void TeleportEvent(object o, EventArgs e)
        {
            SetEvent();
            foreach (var item in eventList)
            {
                if (item.IsMissionRun)
                {
                    if (item.mId == nowMap.mId)
                    {
                        nowlevel++;
                        CommandItem(item.reward);
                        item.IsMissionRun = false;
                        CheckEvent();
                        butMissionYes.SetY(height - 370);//height - 370
                        butMissionNo.SetY(height - 370);//height - 370
                        dialogInterface.SetY(height / 2);
                        TitleAnimation(item.EventDescribe);
                        break;
                    }
                }
            }
        }
        #endregion

        #region 產生元件
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CreateBag()
        {
            #region 前置
            DisplayMetrics dm = new DisplayMetrics();
            WindowManager.DefaultDisplay.GetMetrics(dm);
            int width = dm.WidthPixels;//2071
            int height = dm.HeightPixels;//1080
            widthPix = width + 2;
            heightPix = width + 2;
            int bt_height = height / 5;
            Button button = new Button(this);
            RelativeLayout relativeLayout = new RelativeLayout(this);
            #endregion

            #region 對話框
            relativeLayout = new RelativeLayout(this);
            relativeLayout.SetX(px2dpf(button.Context, 96 + 20 + 20 + 48));
            relativeLayout.SetY(heightPix);//height / 2
            relativeLayout.SetBackgroundColor(Color.Argb(255, 160, 180, 255));
            dialogInterface = relativeLayout;

            TextView textView = new TextView(this);
            textView.SetX(10);
            textView.SetY(10);
            textView.TextSize = 48;
            textView.SetTextColor(Color.Black);
            textView.SetBackgroundColor(Color.White);
            lbDialog = textView;

            relativeLayout.AddView(textView, new LayoutParams(width / 5 * 3 + 30, height / 2 - 120));
            AddContentView(relativeLayout, new LayoutParams(width / 5 * 3 + 50, height / 2 - 100));
            #endregion

            #region 背包
            button = new Button(this);
            button.SetX(30);
            button.SetY(px2dpf(button.Context, dp2pxi(button.Context, height) - 72 - 36 - 20) - px2dpi(button.Context, 72));
            //button.Alpha = 0.32f;
            button.SetBackgroundResource(Resource.Drawable.Backpack);
            butBackpack = button;
            AddContentView(button, new LayoutParams(200, 160));

            relativeLayout = new RelativeLayout(this);
            relativeLayout.SetX(width / 3);
            relativeLayout.SetY(heightPix);//100
            relativeLayout.SetBackgroundColor(Color.Argb(255, 160, 180, 255));
            BackpackInterface = relativeLayout;

            RecyclerView recyclerView = new RecyclerView(this);
            recyclerView.SetX(10);
            recyclerView.SetY(20);
            recyclerView.SetBackgroundColor(Color.White);
            recyclerView.HasFixedSize = true;
            rvBackpack = recyclerView;

            relativeLayout.AddView(recyclerView, new LayoutParams(width / 3 - 20, height - 200 - 40));
            AddContentView(relativeLayout, new LayoutParams(width / 3, height - 200));
            #endregion

            #region 合成
            relativeLayout = new RelativeLayout(this);
            relativeLayout.SetX(width / 3 * 2 + 50);
            relativeLayout.SetY(heightPix);//100
            relativeLayout.SetBackgroundColor(Color.White);
            relativeLayout.SetBackgroundColor(Color.Argb(255, 160, 180, 255));
            MixInterface = relativeLayout;

            textView = new TextView(this);
            textView.SetX(10);
            textView.SetY(height - 1050);
            textView.TextSize = 12;
            textView.SetTextColor(Color.Black);
            textView.Text = "素材：";
            textView.SetBackgroundColor(Color.Transparent);
            relativeLayout.AddView(textView, new LayoutParams(100, 100));

            textView = new TextView(this);
            textView.SetX(10);
            textView.SetY(100);
            textView.TextSize = 20;
            textView.SetTextColor(Color.Black);
            textView.SetBackgroundColor(Color.White);
            textView.Text = "澎湖之魂碎片  Ｘ10";
            lbMixMaterial = textView;
            relativeLayout.AddView(textView, new LayoutParams(480, 400));

            textView = new TextView(this);
            textView.SetX(10);
            textView.SetY(height - 550);
            textView.TextSize = 12;
            textView.SetTextColor(Color.Black);
            textView.Text = "成品：";
            textView.SetBackgroundColor(Color.Transparent);
            relativeLayout.AddView(textView, new LayoutParams(100, 100));

            textView = new TextView(this);
            textView.SetX(10);
            textView.SetY(height - 500);
            textView.TextSize = 20;
            textView.SetTextColor(Color.Black);
            textView.SetBackgroundColor(Color.White);
            textView.Text = "澎湖之魂           Ｘ1";
            lbMixProduct = textView;
            relativeLayout.AddView(textView, new LayoutParams(480, 100));

            button = new Button(this);
            button.SetX(145);
            button.SetY(height - 370);
            //button.Alpha = 0.32f;
            button.SetBackgroundResource(Resource.Drawable.blank);
            button.Text = "合成";
            butMix = button;
            relativeLayout.AddView(button, new LayoutParams(200, 160));
            AddContentView(relativeLayout, new LayoutParams(500, height - 200));
            #endregion

            #region 事件
            button = new Button(this);
            button.SetX(widthPix);//width - 250
            button.SetY(bt_height * 4 + bt_height / 5);
            //button.Alpha = 0.32f;
            button.SetText(Resource.String.portal);
            button.SetTextSize(ComplexUnitType.Pt, 1);
            button.SetBackgroundResource(Resource.Color.colorAccent);
            button.SetBackgroundResource(Resource.Drawable.open);
            eventPortal = button;
            AddContentView(button, new LayoutParams(200, 160));
            #endregion

            #region 任務

            relativeLayout = new RelativeLayout(this);
            relativeLayout.SetX(width / 3);
            relativeLayout.SetY(heightPix);//100
            relativeLayout.SetBackgroundColor(Color.Argb(255, 160, 180, 255));
            MissionInterface = relativeLayout;

            button = new Button(this);
            button.SetX(270);
            button.SetY(px2dpf(button.Context, dp2pxi(button.Context, height) - 72 - 36 - 20) - px2dpi(button.Context, 72));
            //button.Alpha = 0.32f;
            button.SetBackgroundResource(Resource.Drawable.search);
            butMission = button;
            AddContentView(button, new LayoutParams(200, 160));

            button = new Button(this);
            button.SetX(10);
            button.SetY(height - 370);
            //button.Alpha = 0.32f;
            button.SetText(Resource.String.Yes);
            button.SetTextSize(ComplexUnitType.Pt, 10);
            button.SetBackgroundResource(Resource.Drawable.blank);
            relativeLayout.AddView(button, new LayoutParams(200, 160));
            butMissionYes = button;

            button = new Button(this);
            button.SetX(width / 3 - 210);
            button.SetY(height - 370);
            //button.Alpha = 0.32f;
            button.SetText(Resource.String.No);
            button.SetTextSize(ComplexUnitType.Pt, 10);
            button.SetBackgroundResource(Resource.Drawable.blank);
            relativeLayout.AddView(button, new LayoutParams(200, 160));
            butMissionNo = button;

            textView = new TextView(this);
            textView.SetX(10);
            textView.SetY(10);
            textView.TextSize = 32;
            textView.SetTextColor(Color.Black);
            textView.SetBackgroundColor(Color.White);
            relativeLayout.AddView(textView, new LayoutParams(width / 3 - 20, height - 400));
            lbMission = textView;

            AddContentView(relativeLayout, new LayoutParams(width / 3, height - 200));
            #endregion

            #region 布告欄
            relativeLayout = new RelativeLayout(this);
            relativeLayout.SetX(width / 3);
            relativeLayout.SetY(heightPix);//100
            relativeLayout.SetBackgroundColor(Color.Argb(255, 160, 180, 255));
            BulletinInterface = relativeLayout;

            recyclerView = new RecyclerView(this);
            recyclerView.SetX(10);
            recyclerView.SetY(20);
            recyclerView.SetBackgroundColor(Color.White);
            recyclerView.HasFixedSize = true;
            rvBulletin = recyclerView;
            relativeLayout.AddView(recyclerView, new LayoutParams(width / 3 - 20, height - 200 - 40));
            AddContentView(relativeLayout, new LayoutParams(width / 3, height - 200));
            #endregion
        }
        #endregion

        #region 點擊事件
        public void NewClick()
        {
            eventPortal.Click += delegate //最下面那個，用於樓梯傳送點和互動和外部連接
            {
                foreach (var item in nowEventList)
                {
                    if (item.row == nowY && item.col == nowX)
                    {
                        GetEvent(item);
                        break;
                    }
                }
            };
            butBackpack.Click += delegate
            {
                //if (Backpack_interface.GetY() == 100000f)
                if (BackpackInterface.GetY() == heightPix)
                {
                    BackpackInterface.SetY(100);
                    moveButtonLayout.SetX(widthPix);
                    portal1.Visibility = ViewStates.Invisible;
                    Task.Run(() =>
                    {
                        RunOnUiThread(() =>
                        {
                            radapter.DatasClear();
                            for (int i = 0; i < itemtypeCount; i++)
                            {
                                if (items[i] != 0)
                                {
                                    radapter.DatasAdd(Resource.Drawable.hand, EnumNames.GetValue(i).ToString(), "Ｘ " + items[i]);
                                }
                            }
                        });
                    });
                    Task.Run(() =>
                    {
                        for (int x = 0; x < widthcount + 2; x++)
                        {
                            for (int y = 0; y < heightcount + 2; y++)
                            {
                                mapImage[x, y].Alpha = 0.5f;
                            }
                        }
                    });
                }
                else
                {
                    //Backpack_interface.SetY(100000);
                    BackpackInterface.SetY(heightPix);
                    moveButtonLayout.SetX(0);
                    portal1.Visibility = ViewStates.Visible;
                    for (int x = 0; x < widthcount + 2; x++)
                    {
                        for (int y = 0; y < heightcount + 2; y++)
                        {
                            mapImage[x, y].Alpha = 1;
                        }
                    }
                }
            };
            butMix.Click += delegate
            {
                items[0] = (ushort)(items[0] - 10);
                radapter.DatasClear();
                items[1]++;
                BackpackInterface.SetY(heightPix);
                moveButtonLayout.SetX(0);
                for (int x = 0; x < widthcount + 2; x++)
                {
                    for (int y = 0; y < heightcount + 2; y++)
                    {
                        mapImage[x, y].Alpha = 1;
                    }
                }
                BackpackInterface.SetY(heightPix);
                MixInterface.SetY(heightPix);//100
                moveButtonLayout.SetX(0);
                for (int x = 0; x < widthcount + 2; x++)
                {
                    for (int y = 0; y < heightcount + 2; y++)
                    {
                        mapImage[x, y].Alpha = 1;
                    }
                }
            };
            butMission.Click += delegate
            {
                if (MissionInterface.GetY() == heightPix)
                {
                    MissionInterface.SetY(100);//100
                    moveButtonLayout.SetX(widthPix);
                    lbMission.Text = MissionList[nowlevel - 1];
                    Task.Run(() =>
                    {
                        for (int x = 0; x < widthcount + 2; x++)
                        {
                            for (int y = 0; y < heightcount + 2; y++)
                            {
                                mapImage[x, y].Alpha = 0.5f;
                            }
                        }
                    });
                }
                else
                {
                    MissionInterface.SetY(heightPix);//100
                    moveButtonLayout.SetX(0);
                    for (int x = 0; x < widthcount + 2; x++)
                    {
                        for (int y = 0; y < heightcount + 2; y++)
                        {
                            mapImage[x, y].Alpha = 1;
                        }
                    }
                }
            };
            butMissionYes.Click += delegate
            {
                MissionInterface.SetY(heightPix);//100
                butMissionYes.SetY(heightPix);//height - 370
                butMissionNo.SetY(heightPix);//height - 370
                moveButtonLayout.SetX(0);
                for (int x = 0; x < widthcount + 2; x++)
                {
                    for (int y = 0; y < heightcount + 2; y++)
                    {
                        mapImage[x, y].Alpha = 1;
                    }
                }
                foreach (var item in eventList)
                {
                    if (item.MissionId == nowlevel)
                    {
                        item.IsMissionRun = true;
                        break;
                    }
                }
                CommandTeleport(nowlevel);
                TitleAnimation("已接取任務");
            };
            butMissionNo.Click += delegate
            {
                MissionInterface.SetY(heightPix);//100
                moveButtonLayout.SetX(0);
                for (int x = 0; x < widthcount + 2; x++)
                {
                    for (int y = 0; y < heightcount + 2; y++)
                    {
                        mapImage[x, y].Alpha = 1;
                    }
                }
                CheckEvent();
            };
            lbDialog.Click += delegate
            {
                nowDialogLocation++;
                if (nowDialogLocation + 1 > nowDialoglist.Length)
                {
                    dialogInterface.SetY(heightPix);//height / 2
                }
                else
                {
                    lbDialog.Text = nowDialoglist[nowDialogLocation];
                }
            };
            radapter.ItemClick += (v, e) =>
            {
                int UseItemValues = 0;
                for (int i = 0; i < EnumNames.Length; i++)
                {
                    if (EnumNames.GetValue(i).Equals(radapter.DatasGet()[e].caption))
                    {
                        UseItemValues = i;
                        break;
                    }
                }
                if ((int)EnumValues.GetValue(UseItemValues) <= 100)
                {
                    //TitleAnimation("你使用了" + EnumNames.GetValue(UseItemValues).ToString());
                    //BackPackUniversal(UseItemValues);
                    Task.Run(() =>
                    {
                        RunOnUiThread(() =>
                        {
                            MixInterface.SetY(100);
                            //BackPackUseAndClear(UseItemValues);
                        });
                    });
                }
                else
                {
                    BackPackUniversal(UseItemValues);
                }
                /*  BackpackInterface.SetY(heightPix);
                 moveButtonLayout.SetX(0);
                 for (int x = 0; x < widthcount + 2; x++)
                 {
                     for (int y = 0; y < heightcount + 2; y++)
                     {
                         mapImage[x, y].Alpha = 1;
                     }
                 }*/
            };
            radapterBulletin.ItemClick += (v, e) =>
            {
                switch (e)
                {
                    case 0:
                        Intent intent = new Intent(Intent.ActionView, Android.Net.Uri.Parse("https://mis.npu.edu.tw/"));
                        StartActivity(intent);
                        break;
                    case 1:
                        Intent intent1 = new Intent(Intent.ActionView, Android.Net.Uri.Parse("https://mis.npu.edu.tw/latestevent/index?Parser=22,3,23"));
                        StartActivity(intent1);
                        break;
                    case 2:
                        Intent intent2 = new Intent(Intent.ActionView, Android.Net.Uri.Parse("https://mis.npu.edu.tw/"));
                        StartActivity(intent2);
                        break;
                    case 3:
                        Intent intent3 = new Intent(Intent.ActionView, Android.Net.Uri.Parse("https://mis.npu.edu.tw/"));
                        StartActivity(intent3);
                        break;
                    case 4:
                        Intent intent4 = new Intent(Intent.ActionView, Android.Net.Uri.Parse("https://mis.npu.edu.tw/"));
                        StartActivity(intent4);
                        break;
                }
                BulletinInterface.SetY(heightPix);//100
                moveButtonLayout.SetX(0);
                for (int x = 0; x < widthcount + 2; x++)
                {
                    for (int y = 0; y < heightcount + 2; y++)
                    {
                        mapImage[x, y].Alpha = 1;
                    }
                }
            };
        }
        #endregion
        public override void xxxx()
        {
            CheckEvent();
        }

        #region 布告欄通用
        public void ShowBulletin()
        {
            if (BulletinInterface.GetY() == heightPix)
            {
                BulletinInterface.SetY(100);//100
                moveButtonLayout.SetX(widthPix);
                Task.Run(() =>
                {
                    for (int x = 0; x < widthcount + 2; x++)
                    {
                        for (int y = 0; y < heightcount + 2; y++)
                        {
                            mapImage[x, y].Alpha = 0.5f;
                        }
                    }
                });
            }
            else
            {
                BulletinInterface.SetY(heightPix);//100
                moveButtonLayout.SetX(0);
                for (int x = 0; x < widthcount + 2; x++)
                {
                    for (int y = 0; y < heightcount + 2; y++)
                    {
                        mapImage[x, y].Alpha = 1;
                    }
                }
            }
        }
        #endregion

        #region 背包點擊通用
        public void BackPackUniversal(int UseItemValues)
        {
            //Backpack_interface.SetY(100000);
            BackpackInterface.SetY(heightPix);
            moveButtonLayout.SetX(0);
            for (int x = 0; x < widthcount + 2; x++)
            {
                for (int y = 0; y < heightcount + 2; y++)
                {
                    mapImage[x, y].Alpha = 1;
                }
            }
        }
        public void BackPackUseAndClear(int UseItemValues)
        {
            items[UseItemValues]--;
            radapter.DatasClear();
            for (int i = 0; i < itemtypeCount; i++)
                if (items[i] != 0)
                    radapter.DatasAdd(Resource.Drawable.open, EnumNames.GetValue(UseItemValues).ToString(), "Ｘ " + items[i]);
        }
        #endregion

        public void TitleAnimation(string Text)
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
            lb_MapTitle.Text = Text;
            lb_MapTitle.TextAlignment = TextAlignment.Center;
            lb_MapTitle.Alpha = 1;
            lb_MapTitleShadow.Text = Text;
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
    }
}