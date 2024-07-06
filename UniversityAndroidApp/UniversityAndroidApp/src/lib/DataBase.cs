#region using
using Android.Content.Res;
using System;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using Xamarin.Essentials;
#endregion using

namespace PenghuSpace.lib
{
    public class DataBase
    {
        public string mapDB { get; private set; }

        public string drawableDB { get; private set; }

        public DataBase(AssetManager assetManager)
        {
            Init(assetManager);
        }

        private void Init(AssetManager assets)
        {
            mapDB = Path.Combine(FileSystem.AppDataDirectory, "map.db");
            drawableDB = Path.Combine(FileSystem.AppDataDirectory, "drawable.db");
            string mapDBHash = Path.Combine(FileSystem.AppDataDirectory, "map.db.hash");
            string drawableDBHash = Path.Combine(FileSystem.AppDataDirectory, "drawable.db.hash");
            string hash = "";
            string remoteHash = "";
            //if (File.Exists(mapDBHash))
            //{
            //    hash = LoadDBHash(mapDBHash);
            //    remoteHash = GetDBHashAndLoad("https://www.dropbox.com/s/nxuy3fcq4ule4mq/map.db.sha256?dl=1", mapDBHash);
            //    if (hash.Equals(remoteHash))
            //    {
            //        // 代表裝置上擁有最新的資料庫，故不做事。
            //    }
            //    else
            //    {
            //        GetDB("https://www.dropbox.com/s/ri4smv3f1lujcgg/map.db?dl=1", mapDB);

            //        hash = CheckDBHash(mapDB);

            //        while (!hash.Equals(remoteHash)) GetDB("https://www.dropbox.com/s/ri4smv3f1lujcgg/map.db?dl=1", mapDB);
            //    }
            //    SaveHashFile(mapDBHash, hash);

            //    hash = LoadDBHash(drawableDBHash);
            //    remoteHash = GetDBHashAndLoad("https://www.dropbox.com/s/1jpfmsbdv1irna5/drawable.db.sha256?dl=1", drawableDBHash);
            //    if (hash.Equals(remoteHash))
            //    {
            //        // 代表裝置上擁有最新的資料庫，故不做事。
            //    }
            //    else
            //    {
            //        GetDB("https://www.dropbox.com/s/5u1yal1xwitipm9/drawable.db?dl=1", drawableDB);

            //        hash = CheckDBHash(drawableDB);

            //        while (!hash.Equals(remoteHash)) GetDB("https://www.dropbox.com/s/5u1yal1xwitipm9/drawable.db?dl=1", drawableDB);
            //    }
            //    SaveHashFile(drawableDBHash, hash);
            //}
            //else
            //{
            //    GetDB("https://www.dropbox.com/s/ri4smv3f1lujcgg/map.db?dl=1", mapDB);
            //    hash = CheckDBHash(mapDB);
            //    SaveHashFile(mapDBHash, hash);

            //    GetDB("https://www.dropbox.com/s/5u1yal1xwitipm9/drawable.db?dl=1", drawableDB);
            //    hash = CheckDBHash(drawableDB);
            //    SaveHashFile(drawableDBHash, hash);
            //}

            #region 離線獲得資料庫
            using (Stream sr = assets.Open("map.db"))
            {
                using (MemoryStream output = new MemoryStream())
                {
                    sr.CopyTo(output);
                    File.WriteAllBytes(mapDB, output.ToArray());
                }
            }
            using (Stream sr = assets.Open("drawable.db"))
            {
                using (MemoryStream output = new MemoryStream())
                {
                    sr.CopyTo(output);
                    File.WriteAllBytes(drawableDB, output.ToArray());
                }
            }
            #endregion 離線獲得資料庫

            #region 下載完檔案的事件

            /*
            wb.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(Completed);
            void Completed(object sender, AsyncCompletedEventArgs e)
            {
                using (var cn = new SQLiteConnection(db))
                {
                    string map22 = @"REPLACE INTO Map ([mId],[angle],[title],[background]) 
                                   VALUES (57, 1, 'ABC', 6)";
                    cn.Query<Map>(map22);
                    string mapquery = "SELECT * FROM [Map]";
                    List<Map> map = cn.Query<Map>(mapquery).ToList();
                    foreach (var item in map)
                    {
                    }

                }
            }
            */

            #endregion 下載完檔案的事件

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void GetDB(string targetFile, string saveFile)
        {
            WebClient wb = new WebClient();
            //wb.DownloadFile(new Uri("https://chmc.ml/penghuSpace/hash.txt"), dbs);
            //wb.DownloadFile(new Uri("https://www.dropbox.com/s/ri4smv3f1lujcgg/map.db?dl=1"), mapDB);
            wb.DownloadFile(new Uri(targetFile), saveFile);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private string GetDBHashAndLoad(string targetFile, string targetHash)
        {
            string hash = "";
            WebClient wb = new WebClient();
            //wb.DownloadFile(new Uri("https://www.dropbox.com/s/nxuy3fcq4ule4mq/map.db.sha256?dl=1"), mapDBHash);
            wb.DownloadFile(new Uri(targetFile), targetHash);
            using (StreamReader sr = new StreamReader(targetHash))
            {
                hash = sr.ReadToEnd();
            }
            return hash.Split(' ')[0];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void SaveHashFile(string DBHash, string hash)
        {
            using (StreamWriter sw = new StreamWriter(DBHash))
            {
                sw.Write(hash);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private string LoadDBHash(string DBHash)
        {
            string hash = null;
            using(StreamReader sr = new StreamReader(DBHash))
            {
                hash = sr.ReadToEnd();
            }
            return hash;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private string CheckDBHash(string DB)
        {
            string hash = null;
            using (Stream sw = File.OpenRead(DB))
            {
                SHA256 sha = SHA256.Create();
                byte[] hashByteArray = sha.ComputeHash(sw);
                hash = BitConverter.ToString(hashByteArray, 0, hashByteArray.Length).Replace("-", "").ToLower();
            }
            return hash;
        }
    }
}