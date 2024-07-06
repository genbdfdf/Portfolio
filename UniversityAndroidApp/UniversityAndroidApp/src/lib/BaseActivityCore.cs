#region using
using Android.Content.Res;
using Android.Graphics;
using SQLite;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using 函式庫.資料表;
using Picture = 函式庫.資料表.Picture;
#endregion using

namespace PenghuSpace.lib
{
    public class BaseActivityCore
    {

        #region 屬性

        public string mapDB { get; private set; }

        public string drawableDB { get; private set; }

        public Location location { get; private set; }

        public Bitmap[] picture { get; private set; }

        public Bitmap[] drawable { get; private set; }

        public List<Teleport> teleportList { get; private set; }

        private Task _initSk;

        #endregion 屬性

        #region 建構式暨初始化

        public BaseActivityCore(AssetManager assetManager)
        {
            _initSk = Task.Run(() => Init(assetManager));
        }

        private void Init(AssetManager assetManager)
        {
            InitDB(assetManager);
            InitDBData();
        }

        public void WaitInitFinish()
        {
            _initSk.Wait();
        }
        #endregion 建構式暨初始化

        #region 初始化資料庫

        private void InitDB(AssetManager assetManager)
        {
            var dataBase = new DataBase(assetManager);
            mapDB = dataBase.mapDB;
            drawableDB = dataBase.drawableDB;
        }

        #endregion 初始化資料庫

        #region 初始化資料庫資料

        private void InitDBData()
        { 
            Task sk = Task.Run(() =>
            {
                           using (var cn = new SQLiteConnection(mapDB))
                {
                    string pictureQuery = "SELECT [pId], [binData] FROM [Picture]";
                    var pic = cn.Query<Picture>(pictureQuery);
                    picture = new Bitmap[pic.Count];
                    for (int i = 0; i < pic.Count; i++)
                    {
                        picture[i] = BitmapFactory.DecodeByteArray(pic[i].binData, 0, pic[i].binData.Length);
                    }
                }
            });
            Task sk2 = Task.Run(() =>
            {
                using (var cn = new SQLiteConnection(mapDB))
                {
                    string teleportQuery = $"SELECT * FROM [Teleport]";
                    teleportList = cn.Query<Teleport>(teleportQuery);
                    teleportList.Sort();
                }
            });

            Task sk3 = Task.Run(() =>
            {
                using (var cn = new SQLiteConnection(drawableDB))
                {
                    string pictureQuery = "SELECT [pId], [binData] FROM [Picture]";
                    var pic = cn.Query<Picture>(pictureQuery);
                    drawable = new Bitmap[pic.Count];
                    for (int i = 0; i < pic.Count; i++)
                    {
                        drawable[i] = BitmapFactory.DecodeByteArray(pic[i].binData, 0, pic[i].binData.Length);
                    }
                }
            });
            sk.Wait();
            sk2.Wait();
            sk3.Wait();
        }
        #endregion 初始化資料庫資料

        #region 初始化GPS

        CancellationTokenSource cts;
        void InitGPS()
        {
            var sk = Task.Run(() => GetCurrentLocation());
            sk.Wait();
            if (cts != null && !cts.IsCancellationRequested)
            {
                cts.Cancel();
            }
        }

        async Task GetCurrentLocation()
        {
            try
            {
                GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                cts = new CancellationTokenSource();
                location = await Geolocation.GetLocationAsync(request, cts.Token);

                if (location != null)
                {
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
                Console.WriteLine(fnsEx.Message);
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
                Console.WriteLine($"\n{fneEx.Message}");
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
                Console.WriteLine(pEx.Message);
            }
            catch (Exception ex)
            {
                // Unable to get location
                Console.WriteLine(ex.Message);
            }
        }
        #endregion 初始化GPS

    }
}