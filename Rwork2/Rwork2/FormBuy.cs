using SharpDX.Direct2D1.Effects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rwork2
{
    public partial class FormBuy : Form
    {
        public FormBuy()
        {
            InitializeComponent();
        }

        private void FormBuy_Load(object sender, EventArgs e)
        {
            int x = (SystemInformation.WorkingArea.Width - this.Size.Width) / 2;
            int y = (SystemInformation.WorkingArea.Height - this.Size.Height) / 2;
            StartPosition = FormStartPosition.Manual; //窗體的位置由Location屬性決定
            Location = (Point)new Size(x, y);
            lbMemberName.Text = GlobalVar.NowLoginName;
            GlobalVar.ArrayListBuys.Clear();

            lvbuy.Columns.Add("選擇", 50, HorizontalAlignment.Center);
            lvbuy.Columns.Add("ID", 50,HorizontalAlignment.Center);
            lvbuy.Columns.Add("口味", 80, HorizontalAlignment.Center);
            lvbuy.Columns.Add("描述", lvbuy.Width-361, HorizontalAlignment.Center);
            lvbuy.Columns.Add("存貨", 80, HorizontalAlignment.Center);
            lvbuy.Columns.Add("價格", 80, HorizontalAlignment.Center);
            lvbuy.BeginUpdate();

            SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
            con.Open();

            string strSQL = "select * from Products";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int sid=(int)reader["Sid"];
                if (sid >= 4&& sid <= 7)
                {
                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.Text = "口";
                    listViewItem.SubItems.Add(reader["Pid"].ToString());
                    listViewItem.SubItems.Add(reader["Pname"].ToString());
                    listViewItem.SubItems.Add(reader["Pdesc"].ToString());
                    listViewItem.SubItems.Add(reader["Pcount"].ToString());
                    listViewItem.SubItems.Add(reader["Price"].ToString());
                    lvbuy.Items.Add(listViewItem);
                }
            }
            lvbuy.EndUpdate();
            reader.Close();
            con.Close();
          
        }

        private void butAddCart_Click(object sender, EventArgs e)
        {
            //選擇,ID,口味,描述,存貨,價格
            if (lvbuy.SelectedIndices.Count > 0)
            {
                if (int.TryParse(tbBuycount.Text,out int Buycount))
                {
                    ArrayList arraylistbuy = new ArrayList();
                    arraylistbuy.Add(lvbuy.Items[lvbuy.SelectedIndices[0]].SubItems[1].Text);
                    arraylistbuy.Add(lvbuy.Items[lvbuy.SelectedIndices[0]].SubItems[2].Text);
                    arraylistbuy.Add(Buycount);
                    arraylistbuy.Add(Convert.ToInt32(lvbuy.Items[lvbuy.SelectedIndices[0]].SubItems[5].Text));
                    GlobalVar.ArrayListBuys.Add(arraylistbuy);
                    CalculateTotalPrice();
                    MessageBox.Show("已新增商品");
                }
                else
                {
                    MessageBox.Show("請輸入購買數量");
                }
            }
            else
            {
                MessageBox.Show("請選擇品項");
            }
        }

        private void butViewCart_Click(object sender, EventArgs e)
        {
            FormCart formCart = new FormCart();
            formCart.ShowDialog();
        }
        private void butCheckout_Click(object sender, EventArgs e)
        {
            if (GlobalVar.NowLoginclass==0)
            {
                MessageBox.Show("請登錄會員");
            }
            else
            {
                if (GlobalVar.ArrayListBuys.Count != 0)
                {
                    FormCheckout formCheckout = new FormCheckout();
                    formCheckout.ShowDialog();
                }
                else
                    MessageBox.Show("請選擇商品");
            }
        }
        private void lvbuy_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvbuy.Items)
            {
                item.Text = "口";
            }
            if (lvbuy.SelectedIndices.Count > 0)
            {
                lvbuy.Items[lvbuy.SelectedIndices[0]].Text = "☑";
            }
        }
        private void lvbuy_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            ColumnHeader header = this.lvbuy.Columns[e.ColumnIndex];
            e.NewWidth = lvbuy.Columns[e.ColumnIndex].Width;
            e.Cancel = true;
        }
        private void FormBuy_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        private void FormBuy_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.formMain.Show();
        }
        public void CalculateTotalPrice()
        {
            double Sale = 1;
            long totalPrice = 0;
            switch (GlobalVar.NowLoginMemberLevel)
            {
                case 1:
                    Sale = 1;
                    break;
                case 2:
                    Sale = 0.95;
                    break;
                case 3:
                    Sale = 0.9;
                    break;
                case 4:
                    Sale = 0.85;
                    break;
                case 5:
                    Sale = 0.8;
                    break;
                case 6:
                    Sale = 0;
                    break;
            }
            foreach (var item in GlobalVar.ArrayListBuys)
            {
                totalPrice += (long)((int)item[2] * (int)item[3] * Sale);
            }
            //12
            string faststr1 = "";
            for (int i = 0; i < 12 - totalPrice.ToString().Length; i++)
            {
                faststr1 += "0";
            }
            lbtotalPrice.Text = faststr1 + totalPrice.ToString();
        }
    }
}
