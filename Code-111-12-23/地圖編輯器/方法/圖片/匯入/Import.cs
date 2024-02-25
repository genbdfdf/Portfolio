#region using
using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 函式庫.資料表;
using Encoder = System.Drawing.Imaging.Encoder;

namespace 地圖編輯器.方法.圖片.匯入
{
    internal class Import
    {
    }
}
#endregion using
namespace mapMaker
{
    partial class Form1
    {
        private void lv_image_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void lv_image_DragDrop(object sender, DragEventArgs e)
        {
            string[] path = (string[])e.Data.GetData(DataFormats.FileDrop);
            InitImport(path);
        }

        private void container_DragDrop(object sender, DragEventArgs e)
        {
            string[] path = (string[])e.Data.GetData(DataFormats.FileDrop);
            InitImport(path);
        }

        private void container_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] path = (string[])e.Data.GetData(DataFormats.FileDrop);
            InitImport(path);
        }
        private void bt_importimagefile_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Title = "開啟檔案";
                dialog.Filter = "影像檔(*.png)|*.png|所有檔案(*.*)|*.*";
                dialog.Multiselect = true;

                DialogResult result = dialog.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    Task.Run(() => importImage(dialog.FileNames));
                }
            }

        }
        private cutImageStruct[] PictureCut(string folderDirPath, string filename)
        {
            GridData data = new GridData();
            data.SrcFileName = folderDirPath;
            data.OutDirectory = Environment.CurrentDirectory + "\\" + filename + "\\";
            data.titlePrefixName = filename;
            Image srcImage = Image.FromFile(data.SrcFileName);
            int width = srcImage.Width;
            int height = srcImage.Height;
            //列數
            int columnNum = (int)Math.Ceiling(width * 1.0f / data.GridWidth);
            //行數
            int rowNum = (int)Math.Ceiling(height * 1.0f / data.GridHeight);

            ImageCodecInfo codecInfo = ImageCutterTool.GetEncodeInfo(ImageCutterConfig.mimeType);
            EncoderParameters encoderParams = new EncoderParameters(2);
            encoderParams.Param[0] = new EncoderParameter(Encoder.ColorDepth, 1L);
            encoderParams.Param[1] = new EncoderParameter(Encoder.Quality, 1L);

            ToolParam toolParam = new ToolParam(srcImage, data, codecInfo, encoderParams, columnNum, rowNum);
            var images = new List<cutImageStruct>();
            for (int i = 0; i < rowNum; ++i)
            {
                for (int j = 0; j < columnNum; ++j)
                {
                    toolParam.RefreshIndex(j, i);
                    images.Add(ImageCutterTool.SaveSlice(toolParam));
                }
            }
            tb_col.Text = "" + (columnNum + 1);
            tb_row.Text = "" + (rowNum + 1);
            return images.ToArray();
        }

        private void bt_importimage_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                DialogResult result = dialog.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    string[] path = { dialog.SelectedPath };
                    InitImport(path);
                }
            }
        }

        private void InitImport(string[] path)
        {
            Task.Run(() =>
            {
                foreach (var item in path)
                {
                    ShowMSG("準備讀取中，請稍候．．．");
                    string[] subpath = { item };
                    var images = new cutImageStruct[1];
                    try
                    {
                        Image image = Image.FromFile(item);
                        if (image.Width > 32 || image.Height > 32)
                        {
                            //string tempPath = Environment.CurrentDirectory + "\\" + Path.GetFileNameWithoutExtension(item) + "\\";
                            //Directory.CreateDirectory(tempPath);
                            nowEditMapName = Path.GetFileNameWithoutExtension(item);
                            lb_mapName.Text = $"地圖編輯區　({nowEditMapName})";
                            images = PictureCut(item, nowEditMapName);
                            //subpath = Directory.GetFiles(tempPath, "*.png", SearchOption.TopDirectoryOnly);
                        }
                    }
                    catch { }

                    for (int i = 0; i < 300; i++)
                        for (int j = 0; j < 300; j++)
                        {
                            mapForePic[i, j] = 0;
                            mapBackPic[i, j] = 0;
                        }
                    container.Refresh();

                    newImportImage(images);

                    #region 計算圖片色彩平均值，影像辨識用
                    using (var cn = new SqliteConnection(cnStr))
                    {
                        string querystr = "SELECT [pId],[name],[binData] FROM Picture";
                        List<Picture> dbImage = cn.Query<Picture>(querystr).ToList();
                        MemoryStream stream;
                        bitPixelAvg = new StringBuilder[dbImage.Count];
                        for (short l = 0; l < dbImage.Count; l++)
                        {
                            stream = new MemoryStream(dbImage[l].GetbinData());
                            System.Drawing.Bitmap bitmap = (System.Drawing.Bitmap)System.Drawing.Image.FromStream(stream);
                            ushort wx, hx;
                            System.Drawing.Size size = bitmap.Size;
                            bitPixelAvg[l] = new StringBuilder();
                            for (short i = 0; i < size.Width; i += 4)
                            {
                                wx = 4;
                                if (i + 3 > size.Width)
                                {
                                    wx = (ushort)(size.Width - i);
                                }
                                for (short j = 0; j < size.Height; j += 4)
                                {
                                    hx = 4;
                                    if (j + 3 > size.Height)
                                    {
                                        hx = (ushort)(size.Height - j);
                                    }
                                    int r = 0;
                                    for (short ii = 0; ii < wx; ii++)
                                    {
                                        for (short jj = 0; jj < hx; jj++)
                                        {
                                            r += bitmap.GetPixel(i + ii, j + jj).ToArgb();
                                        }
                                    }
                                    bitPixelAvg[l].Append(r / wx / hx + "|");
                                }
                            }
                        }
                    }
                    #endregion 計算圖片色彩平均值，影像辨識用

                    #region 嘗試把圖片檔名的座標直接映射到地圖上
                    short row, col;

                    void asdgd(ushort len)
                    {
                        for (ushort i = 0; i < len; i++)
                        {
                            try
                            {
                                mapBackPic[sameImgRow_t1[i], sameImgCol_t1[i]] = sameImgpId_t1[i];
                                mapBackPic[sameImgRow_t2[i], sameImgCol_t2[i]] = sameImgpId_t2[i];
                                mapBackPic[sameImgRow_t3[i], sameImgCol_t3[i]] = sameImgpId_t3[i];
                            }
                            catch
                            {

                            }
                        }
                    }
                    void asdgd2(ushort len)
                    {
                        for (ushort i = 0; i < len; i++)
                        {
                            try
                            {
                                mapBackPic[sameImgRow1t1[i], sameImgCol1t1[i]] = mapBackPic[sameImgRow2t1[i], sameImgCol2t1[i]];
                                mapBackPic[sameImgRow1t2[i], sameImgCol1t2[i]] = mapBackPic[sameImgRow2t2[i], sameImgCol2t2[i]];
                                mapBackPic[sameImgRow1t3[i], sameImgCol1t3[i]] = mapBackPic[sameImgRow2t3[i], sameImgCol2t3[i]];
                            }
                            catch
                            {

                            }
                        }
                    }
                    for (short i = 0; i < 3; i++)
                    {
                        asdgd(sameImgLen[i]);
                    }
                    for (short i = 3; i < 6; i++)
                    {
                        asdgd2(sameImgLen[i]);
                    }
                    using (var cn = new SqliteConnection(cnStr))
                    {
                        string querystr = "SELECT [name] FROM Picture";
                        List<Picture> dbImage = cn.Query<Picture>(querystr).ToList();
                        for (int i = 0; i < dbImage.Count; i++)
                        {
                            try
                            {
                                if (dbImage[i].name.Split('_')[0].Equals(nowEditMapName))
                                {
                                    string location = dbImage[i].name.Split('_')[1];
                                    string[] lo2 = location.Split('Z');
                                    row = Convert.ToInt16(lo2[0]);
                                    col = Convert.ToInt16(lo2[1]);
                                    mapBackPic[col, row] = (ushort)i;
                                }
                            }
                            catch { }
                        }
                    }
                    #endregion 嘗試把圖片檔名的座標直接映射到地圖上

                    ShowMSG("準備讀取中，請稍候．．．");
                    //System.Threading.Thread.Sleep(100);
                    newImportImage(images);

                    read_Image();
                    SaveMap();
                    //System.Threading.Thread.Sleep(2600);

                    if (path.Length > 1)
                    {
                        importing = true;
                        using (StreamWriter sw = new StreamWriter("list"))
                        {
                            for (int i = 1; i < path.Length; i++)
                            {
                                sw.WriteLine(path[i]);
                            }
                        }
                        using (StreamWriter sw = new StreamWriter("status"))
                        {
                            sw.WriteLine("1");
                        }
                    }
                    importFin = true; 
                    Close();
                }
            });
        }
        private void newImportImage(cutImageStruct[] path)
        {
            ShowMSG("讀取中，請稍候．．．");
                        
            ProgressBarVaultStartCount();

            toolStripProgressBar1.Maximum = path.Length;

            using (var cn = new SqliteConnection(cnStr))
            {
                // 啟動SQL交易。
                cn.Open();
                var transaction = cn.BeginTransaction();
                Bitmap toBit;
                int CT = path.Length + pic.Length;
                sameImgRow_t1 = new ushort[CT];
                sameImgCol_t1 = new ushort[CT];
                sameImgpId_t1 = new ushort[CT];
                sameImgRow_t2 = new ushort[CT];
                sameImgCol_t2 = new ushort[CT];
                sameImgpId_t2 = new ushort[CT];
                sameImgRow_t3 = new ushort[CT];
                sameImgCol_t3 = new ushort[CT];
                sameImgpId_t3 = new ushort[CT];
                sameImgRow1t1 = new ushort[CT];
                sameImgCol1t1 = new ushort[CT];
                sameImgRow2t1 = new ushort[CT];
                sameImgCol2t1 = new ushort[CT];
                sameImgRow1t2 = new ushort[CT];
                sameImgCol1t2 = new ushort[CT];
                sameImgRow2t2 = new ushort[CT];
                sameImgCol2t2 = new ushort[CT];
                sameImgRow1t3 = new ushort[CT];
                sameImgCol1t3 = new ushort[CT];
                sameImgRow2t3 = new ushort[CT];
                sameImgCol2t3 = new ushort[CT];
                StringBuilder[] anybuilders = new StringBuilder[path.Length];
                for (short r = 0; r < path.Length; r++)
                {
                    try
                    {
                        ushort pId = 0;
                        string name = path[r].name;
                        string querystr = "INSERT INTO Picture ([name],[binData]) VALUES (:name,:data)";

                        string selectquerystr = "SELECT [pId] FROM [Picture] WHERE [name] = :name";
                        List<Picture> picname = cn.Query<Picture>(selectquerystr, new
                        {
                            name = name
                        }).ToList();
                        foreach (var target in picname)
                        {
                            pId = target.pId;
                            querystr = "UPDATE Picture SET [name] = :name, [binData] = :data WHERE [pId] = :pId";
                        }
                        Task task = Task.Run(() => lb_MSG.Text = "讀取 " + path[r].name);

                        Task task2 = Task.Run(() => ProgressBarVaultAdd());

                        ushort wx, hx;
                        int fromPixel;

                        toBit = path[r].image;
                        StringBuilder builder = new StringBuilder();
                        anybuilders[r] = builder;

                        for (short i = 0; i < toBit.Width; i += 4)
                        {
                            wx = 4;
                            if (i + 3 > toBit.Width)
                            {
                                wx = (ushort)(toBit.Width - i);
                            }
                            for (short j = 0; j < toBit.Height; j += 4)
                            {
                                fromPixel = 0;
                                hx = 4;
                                if (j + 3 > toBit.Height)
                                {
                                    hx = (ushort)(toBit.Height - j);
                                }
                                for (short ii = 0; ii < wx; ii++)
                                {
                                    for (short jj = 0; jj < hx; jj++)
                                    {
                                        fromPixel += toBit.GetPixel(i + ii, j + jj).ToArgb();
                                    }
                                }
                                builder.Append(fromPixel / wx / hx + "|");
                            }
                        }
                        string[] nowavg = builder.ToString().Split('|');
                        short[] equals = new short[6];

                        // 跟資料庫裡的圖片比較。
                        Task sk = Task.Run(() =>
                        {
                            sameif(0, bitPixelAvg.Length / 3, 0);
                        });
                        Task sk2 = Task.Run(() =>
                        {
                            sameif(bitPixelAvg.Length / 3, bitPixelAvg.Length / 3 * 2, 1);
                        });
                        Task sk3 = Task.Run(() =>
                        {
                            sameif(bitPixelAvg.Length / 3 * 2, bitPixelAvg.Length, 2);
                        });
                        int endX = anybuilders.Length;
                        for (int i = 0; i < anybuilders.Length; i++)
                        {
                            if (anybuilders[i] != null)
                            {
                                endX = i;
                            }
                        }
                        // 跟前面同一批丟進來的圖片比較。
                        Task sk4 = Task.Run(() =>
                        {
                            sameLocif(0, endX / 3, 3);
                        });
                        Task sk5 = Task.Run(() =>
                        {
                            sameLocif(endX / 3, endX / 3 * 2, 4);
                        });
                        Task sk6 = Task.Run(() =>
                        {
                            sameLocif(endX / 3 * 2, endX, 5);
                        });
                        void sameif(int start, int end, int id)
                        {
                            for (int l = start; l < end; l++)
                            {
                                string[] avg = bitPixelAvg[l].ToString().Split('|');
                                for (short o = 0; o < avg.Length; o++)
                                {
                                    if (avg[o].Equals(nowavg[o]))
                                    {
                                        equals[id]++;
                                    }
                                }
                                if (equals[id] * 1.0f / nowavg.Length * 1.0f > 0.99f)
                                {
                                    //Debug.Write(id+" "+equals[id] * 1.0f / nowavg.Length * 1.0f + "|");
                                    //Debug.WriteLine("");
                                    string[] tb = path[r].name.Split('_');
                                    string[] loc = tb[tb.Length - 1].Replace(".png", "").Split('Z');
                                    switch (id)
                                    {
                                        case 0:
                                            sameImgCol_t1[sameImgLen[id]] = Convert.ToUInt16(loc[0]);
                                            sameImgRow_t1[sameImgLen[id]] = Convert.ToUInt16(loc[1]);
                                            sameImgpId_t1[sameImgLen[id]] = (ushort)l;
                                            break;
                                        case 1:
                                            sameImgCol_t2[sameImgLen[id]] = Convert.ToUInt16(loc[0]);
                                            sameImgRow_t2[sameImgLen[id]] = Convert.ToUInt16(loc[1]);
                                            sameImgpId_t2[sameImgLen[id]] = (ushort)l;
                                            break;
                                        case 2:
                                            sameImgCol_t3[sameImgLen[id]] = Convert.ToUInt16(loc[0]);
                                            sameImgRow_t3[sameImgLen[id]] = Convert.ToUInt16(loc[1]);
                                            sameImgpId_t3[sameImgLen[id]] = (ushort)l;
                                            break;
                                    }
                                    sameImgLen[id]++;
                                    throw new Exception();
                                }
                                equals[id] = 0;
                            }
                        }
                        void sameLocif(int start, int end, int id)
                        {
                            for (int l = start; l < end; l++)
                            {
                                string[] avg = anybuilders[l].ToString().Split('|');
                                for (short o = 0; o < avg.Length; o++)
                                {
                                    if (avg[o].Equals(nowavg[o]))
                                    {
                                        equals[id]++;
                                    }
                                }
                                if (equals[id] * 1.0f / nowavg.Length * 1.0f > 0.99f)
                                {
                                    //Debug.Write(id+" "+equals[id] * 1.0f / nowavg.Length * 1.0f + "|");
                                    //Debug.WriteLine("");
                                    string[] tb = path[r].name.Split('_');
                                    string[] tb2 = path[l].name.Split('_');

                                    string[] loc = tb[tb.Length - 1].Replace(".png", "").Split('Z');
                                    string[] loc2 = tb2[tb2.Length - 1].Replace(".png", "").Split('Z');
                                    switch (id)
                                    {
                                        case 0:
                                            sameImgCol1t1[sameImgLen[id]] = Convert.ToUInt16(loc[0]);
                                            sameImgRow1t1[sameImgLen[id]] = Convert.ToUInt16(loc[1]);
                                            sameImgCol2t1[sameImgLen[id]] = Convert.ToUInt16(loc2[0]);
                                            sameImgRow2t1[sameImgLen[id]] = Convert.ToUInt16(loc2[1]);
                                            break;
                                        case 1:
                                            sameImgCol1t2[sameImgLen[id]] = Convert.ToUInt16(loc[0]);
                                            sameImgRow1t2[sameImgLen[id]] = Convert.ToUInt16(loc[1]);
                                            sameImgCol2t2[sameImgLen[id]] = Convert.ToUInt16(loc2[0]);
                                            sameImgRow2t2[sameImgLen[id]] = Convert.ToUInt16(loc2[1]);
                                            break;
                                        case 2:
                                            sameImgCol1t3[sameImgLen[id]] = Convert.ToUInt16(loc[0]);
                                            sameImgRow1t3[sameImgLen[id]] = Convert.ToUInt16(loc[1]);
                                            sameImgCol2t3[sameImgLen[id]] = Convert.ToUInt16(loc2[0]);
                                            sameImgRow2t3[sameImgLen[id]] = Convert.ToUInt16(loc2[1]);
                                            break;
                                    }
                                    sameImgLen[id]++;

                                    //sameLocImg.Append(tb[tb.Length - 1].Replace(".png", "") + "_" + tb2[tb2.Length - 1].Replace(".png", "") + "|");
                                    throw new Exception();
                                }
                                equals[id] = 0;
                            }
                        }
                        sk.Wait();
                        sk2.Wait();
                        sk3.Wait();
                        sk4.Wait();
                        sk5.Wait();
                        sk6.Wait();
                        task.Wait();
                        task2.Wait();
                        using (MemoryStream ms = new MemoryStream())
                        {
                            toBit.Save(ms, ImageFormat.Png);
                            byte[] byData = ms.ToArray();
                            // 將圖片寫入資料庫。
                            cn.Query(querystr, new { pId = pId, name = name, data = byData });
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                // 結束SQL交易。
                transaction.Commit();
            }
            lb_MSG.Text = "讀取中，請稍候．．．";

            tryparse();

            // 寫入完馬上從資料庫讀取圖片並檢視結果。
            //read_Image();
        }
        private void importImage(string[] path)
        {
            ShowMSG("讀取中，請稍候．．．");

            // 取得選擇的東西。
            List<string> lsPath = new List<string>();
            List<string> tsPath = new List<string>();
            foreach (var item in path)
            {
                lsPath.Add(item);
                tsPath.Add(item);
            }
            
            ProgressBarVaultStartCount();

            // 判斷是資料夾還是檔案。
            // 如果是資料夾就取得裡面的檔案。
            foreach (var item in lsPath)
            {
                if (Directory.Exists(item))
                {
                    try
                    {
                        tsPath.Remove(item);
                        string[] subPath = Directory.GetDirectories(item, "*", SearchOption.TopDirectoryOnly);
                        foreach (var item0 in subPath)
                        {
                            // 排除掉系統資料夾。
                            if (item0.Contains("System Volume Information")) continue;
                            else if (new FileInfo(item0).Attributes == FileAttributes.System) continue;
                            else if (new FileInfo(item0).Attributes == FileAttributes.Hidden) continue;

                            string[] subPath1 = Directory.GetFiles(item0, "*.png", SearchOption.AllDirectories);
                            foreach (var item1 in subPath1)
                            {
                                lb_MSG.Text = "掃描 " + item1;
                                tsPath.Add(item1);
                            }
                        }

                        // 尋找自己本身內的檔案。
                        string[] subPath2 = Directory.GetFiles(item, "*.png", SearchOption.TopDirectoryOnly);
                        foreach (var item1 in subPath2)
                        {
                            lb_MSG.Text = "掃描 " + item1;
                            tsPath.Add(item1);
                        }
                    }
                    catch (Exception se)
                    {
#if DEBUG
                        Debug.WriteLine(se);
#endif
                    }
                }
            }

            toolStripProgressBar1.Maximum = tsPath.Count;
            using (var cn = new SqliteConnection(cnStr))
            {
                // 啟動SQL交易。
                cn.Open();
                var transaction = cn.BeginTransaction();
                Bitmap toBit;
                int CT = tsPath.Count + pic.Length;
                sameImgRow_t1 = new ushort[CT];
                sameImgCol_t1 = new ushort[CT];
                sameImgpId_t1 = new ushort[CT];
                sameImgRow_t2 = new ushort[CT];
                sameImgCol_t2 = new ushort[CT];
                sameImgpId_t2 = new ushort[CT];
                sameImgRow_t3 = new ushort[CT];
                sameImgCol_t3 = new ushort[CT];
                sameImgpId_t3 = new ushort[CT];
                sameImgRow1t1 = new ushort[CT];
                sameImgCol1t1 = new ushort[CT];
                sameImgRow2t1 = new ushort[CT];
                sameImgCol2t1 = new ushort[CT];
                sameImgRow1t2 = new ushort[CT];
                sameImgCol1t2 = new ushort[CT];
                sameImgRow2t2 = new ushort[CT];
                sameImgCol2t2 = new ushort[CT];
                sameImgRow1t3 = new ushort[CT];
                sameImgCol1t3 = new ushort[CT];
                sameImgRow2t3 = new ushort[CT];
                sameImgCol2t3 = new ushort[CT];
                StringBuilder[] anybuilders = new StringBuilder[tsPath.Count];
                for (short r = 0; r < tsPath.Count; r++)
                {
                    try
                    {
                        ushort pId = 0;
                        string name = Path.GetFileNameWithoutExtension(tsPath[r]);
                        string querystr = "INSERT INTO Picture ([name],[binData]) VALUES (:name,:data)";

                        string selectquerystr = "SELECT [pId] FROM [Picture] WHERE [name] = :name";
                        List<Picture> picname = cn.Query<Picture>(selectquerystr, new
                        {
                            name = name
                        }).ToList();
                        foreach (var target in picname)
                        {
                            pId = target.GetpId();
                            querystr = "UPDATE Picture SET [name] = :name, [binData] = :data WHERE [pId] = :pId";
                        }
                        lb_MSG.Text = "讀取 " + tsPath[r];
                        ProgressBarVaultAdd();

                        // 讀取圖片檔案。
                        using (FileStream fs = new FileStream(tsPath[r], FileMode.Open, FileAccess.Read))
                        {
                            // 忽略掉超過70MB的檔案
                            if (fs.Length < 70000000)
                            {
                                using (BinaryReader br = new BinaryReader(fs))
                                {
                                    byte[] byData = br.ReadBytes((short)fs.Length);

                                    using (MemoryStream ms = new MemoryStream(byData))
                                    {
                                        ushort wx, hx;
                                        int fromPixel;

                                        // 檢查是否為影像檔。
                                        toBit = (Bitmap)Image.FromStream(ms);
                                        StringBuilder builder = new StringBuilder();
                                        anybuilders[r] = builder;

                                        for (short i = 0; i < toBit.Width; i += 4)
                                        {
                                            wx = 4;
                                            if (i + 3 > toBit.Width)
                                            {
                                                wx = (ushort)(toBit.Width - i);
                                            }
                                            for (short j = 0; j < toBit.Height; j += 4)
                                            {
                                                fromPixel = 0;
                                                hx = 4;
                                                if (j + 3 > toBit.Height)
                                                {
                                                    hx = (ushort)(toBit.Height - j);
                                                }
                                                for (short ii = 0; ii < wx; ii++)
                                                {
                                                    for (short jj = 0; jj < hx; jj++)
                                                    {
                                                        fromPixel += toBit.GetPixel(i + ii, j + jj).ToArgb();
                                                    }
                                                }
                                                builder.Append(fromPixel / wx / hx + "|");
                                            }
                                        }
                                        string[] nowavg = builder.ToString().Split('|');
                                        short[] equals = new short[6];

                                        // 跟資料庫裡的圖片比較。
                                        Task sk = Task.Run(() =>
                                        {
                                            sameif(0, bitPixelAvg.Length / 3, 0);
                                        });
                                        Task sk2 = Task.Run(() =>
                                        {
                                            sameif(bitPixelAvg.Length / 3, bitPixelAvg.Length / 3 * 2, 1);
                                        });
                                        Task sk3 = Task.Run(() =>
                                        {
                                            sameif(bitPixelAvg.Length / 3 * 2, bitPixelAvg.Length, 2);
                                        });
                                        int endX = anybuilders.Length;
                                        for (int i = 0; i < anybuilders.Length; i++)
                                        {
                                            if (anybuilders[i] != null)
                                            {
                                                endX = i;
                                            }
                                        }
                                        // 跟前面同一批丟進來的圖片比較。
                                        Task sk4 = Task.Run(() =>
                                        {
                                            sameLocif(0, endX / 3, 3);
                                        });
                                        Task sk5 = Task.Run(() =>
                                        {
                                            sameLocif(endX / 3, endX / 3 * 2, 4);
                                        });
                                        Task sk6 = Task.Run(() =>
                                        {
                                            sameLocif(endX / 3 * 2, endX, 5);
                                        });
                                        void sameif(int start, int end, int id)
                                        {
                                            for (int l = start; l < end; l++)
                                            {
                                                string[] avg = bitPixelAvg[l].ToString().Split('|');
                                                for (short o = 0; o < avg.Length; o++)
                                                {
                                                    if (avg[o].Equals(nowavg[o]))
                                                    {
                                                        equals[id]++;
                                                    }
                                                }
                                                if (equals[id] * 1.0f / nowavg.Length * 1.0f > 0.99f)
                                                {
                                                    //Debug.Write(id+" "+equals[id] * 1.0f / nowavg.Length * 1.0f + "|");
                                                    //Debug.WriteLine("");
                                                    string[] tb = tsPath[r].Split('_');
                                                    string[] loc = tb[tb.Length - 1].Replace(".png", "").Split('Z');
                                                    switch (id)
                                                    {
                                                        case 0:
                                                            sameImgCol_t1[sameImgLen[id]] = Convert.ToUInt16(loc[0]);
                                                            sameImgRow_t1[sameImgLen[id]] = Convert.ToUInt16(loc[1]);
                                                            sameImgpId_t1[sameImgLen[id]] = (ushort)l;
                                                            break;
                                                        case 1:
                                                            sameImgCol_t2[sameImgLen[id]] = Convert.ToUInt16(loc[0]);
                                                            sameImgRow_t2[sameImgLen[id]] = Convert.ToUInt16(loc[1]);
                                                            sameImgpId_t2[sameImgLen[id]] = (ushort)l;
                                                            break;
                                                        case 2:
                                                            sameImgCol_t3[sameImgLen[id]] = Convert.ToUInt16(loc[0]);
                                                            sameImgRow_t3[sameImgLen[id]] = Convert.ToUInt16(loc[1]);
                                                            sameImgpId_t3[sameImgLen[id]] = (ushort)l;
                                                            break;
                                                    }
                                                    sameImgLen[id]++;
                                                    throw new Exception();
                                                }
                                                equals[id] = 0;
                                            }
                                        }
                                        void sameLocif(int start, int end, int id)
                                        {
                                            for (int l = start; l < end; l++)
                                            {
                                                string[] avg = anybuilders[l].ToString().Split('|');
                                                for (short o = 0; o < avg.Length; o++)
                                                {
                                                    if (avg[o].Equals(nowavg[o]))
                                                    {
                                                        equals[id]++;
                                                    }
                                                }
                                                if (equals[id] * 1.0f / nowavg.Length * 1.0f > 0.99f)
                                                {
                                                    //Debug.Write(id+" "+equals[id] * 1.0f / nowavg.Length * 1.0f + "|");
                                                    //Debug.WriteLine("");
                                                    string[] tb = tsPath[r].Split('_');
                                                    string[] tb2 = tsPath[l].Split('_');

                                                    string[] loc = tb[tb.Length - 1].Replace(".png", "").Split('Z');
                                                    string[] loc2 = tb2[tb2.Length - 1].Replace(".png", "").Split('Z');
                                                    switch (id)
                                                    {
                                                        case 0:
                                                            sameImgCol1t1[sameImgLen[id]] = Convert.ToUInt16(loc[0]);
                                                            sameImgRow1t1[sameImgLen[id]] = Convert.ToUInt16(loc[1]);
                                                            sameImgCol2t1[sameImgLen[id]] = Convert.ToUInt16(loc2[0]);
                                                            sameImgRow2t1[sameImgLen[id]] = Convert.ToUInt16(loc2[1]);
                                                            break;
                                                        case 1:
                                                            sameImgCol1t2[sameImgLen[id]] = Convert.ToUInt16(loc[0]);
                                                            sameImgRow1t2[sameImgLen[id]] = Convert.ToUInt16(loc[1]);
                                                            sameImgCol2t2[sameImgLen[id]] = Convert.ToUInt16(loc2[0]);
                                                            sameImgRow2t2[sameImgLen[id]] = Convert.ToUInt16(loc2[1]);
                                                            break;
                                                        case 2:
                                                            sameImgCol1t3[sameImgLen[id]] = Convert.ToUInt16(loc[0]);
                                                            sameImgRow1t3[sameImgLen[id]] = Convert.ToUInt16(loc[1]);
                                                            sameImgCol2t3[sameImgLen[id]] = Convert.ToUInt16(loc2[0]);
                                                            sameImgRow2t3[sameImgLen[id]] = Convert.ToUInt16(loc2[1]);
                                                            break;
                                                    }
                                                    sameImgLen[id]++;

                                                    //sameLocImg.Append(tb[tb.Length - 1].Replace(".png", "") + "_" + tb2[tb2.Length - 1].Replace(".png", "") + "|");
                                                    throw new Exception();
                                                }
                                                equals[id] = 0;
                                            }
                                        }
                                        sk.Wait();
                                        sk2.Wait();
                                        sk3.Wait();
                                        sk4.Wait();
                                        sk5.Wait();
                                        sk6.Wait();
                                    }
                                    // 將圖片寫入資料庫。
                                    cn.Query(querystr, new { pId = pId, name = name, data = byData });
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                // 結束SQL交易。
                transaction.Commit();
            }
            lb_MSG.Text = "讀取中，請稍候．．．";

            tryparse();

            // 寫入完馬上從資料庫讀取圖片並檢視結果。
            //read_Image();
        }
    }
}