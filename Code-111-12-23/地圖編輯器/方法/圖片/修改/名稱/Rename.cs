#region using
using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 地圖編輯器.方法.圖片.修改.名稱
{
    internal class Rename
    {
    }
}
#endregion using
namespace mapMaker
{
    partial class Form1
    {
        private void lv_image_BeforeLabelEdit(object sender, LabelEditEventArgs e)
        {
            lv_imageText = lv_image.SelectedItems[0].Text;
        }
        private void lv_image_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            Task.Run(() =>
            {
                ushort pId;
                try
                {
                    if (e.Label == null)
                    {
                        // 如果沒改名字就不動作。
                    }
                    else
                    {
                        pId = (ushort)(lv_image.SelectedItems[0].Index + 1);
                        string name = e.Label;
                        using (var cn = new SqliteConnection(cnStr))
                        {
                            string mapquery = "UPDATE [Picture] SET [name] = :name WHERE [pId] = :pId";
                            cn.Query(mapquery, new
                            {
                                pId = pId,
                                name = name
                            }).ToList();
                        }
                    }
                }
                catch
                {
                    ShowErrorMSG("圖片名稱不可重複");
                    lv_image.SelectedItems[0].Text = lv_imageText;
                }
            });
        }
    }
}