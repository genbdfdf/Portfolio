using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace Rwork2
{
    public partial class FormCart : Form
    {
        public FormCart()
        {
            InitializeComponent();
        }
        private void FormCart_Load(object sender, EventArgs e)
        {

            int x = (SystemInformation.WorkingArea.Width - this.Size.Width) / 2;
            int y = (SystemInformation.WorkingArea.Height - this.Size.Height) / 2;
            StartPosition = FormStartPosition.Manual; //窗體的位置由Location屬性決定
            Location = (Point)new Size(x, y);
            lvCart.Columns.Add("選擇", 50, HorizontalAlignment.Center);
            lvCart.Columns.Add("ID", 50, HorizontalAlignment.Center);
            lvCart.Columns.Add("口味", 80, HorizontalAlignment.Center);
            lvCart.Columns.Add("購買數", 80, HorizontalAlignment.Center);
            lvCart.Columns.Add("價格", 80, HorizontalAlignment.Center);
            lvCart.Columns.Add("總價", 120, HorizontalAlignment.Center);
            lvCart.BeginUpdate();
            foreach (ArrayList item in GlobalVar.ArrayListBuys)
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = "口";
                listViewItem.SubItems.Add(item[0].ToString());
                listViewItem.SubItems.Add((string)item[1]);
                listViewItem.SubItems.Add(item[2].ToString());
                listViewItem.SubItems.Add(item[3].ToString());
                listViewItem.SubItems.Add(((long)(int)item[2] * (int)item[3]).ToString());
                lvCart.Items.Add(listViewItem);
            }
            CalculateTotalPrice();
            lvCart.EndUpdate();
        }
        private void butCheckout_Click(object sender, EventArgs e)
        {
            if (GlobalVar.NowLoginclass == 0)
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
        private void butclose_Click(object sender, EventArgs e)
        {
            Close();
            FormBuy formBuy = Application.OpenForms["FormBuy"] as FormBuy;
            if (formBuy != null)
            {
                formBuy.CalculateTotalPrice();
            }
        }

        private void lvCart_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvCart.Items)
            {
                item.Text = "口";
            }
            if (lvCart.SelectedIndices.Count > 0)
            {
                lvCart.Items[lvCart.SelectedIndices[0]].Text = "☑";
            }
        }

        private void lvCart_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            ColumnHeader header = this.lvCart.Columns[e.ColumnIndex];
            e.NewWidth = lvCart.Columns[e.ColumnIndex].Width;
            e.Cancel = true;
        }

        private void butClear_Click(object sender, EventArgs e)
        {
            GlobalVar.ArrayListBuys.Clear();
            lvCart.Items.Clear();
            CalculateTotalPrice();
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            if (lvCart.SelectedIndices.Count>0)
            {
                GlobalVar.ArrayListBuys.RemoveAt(lvCart.SelectedIndices[0]);
                lvCart.Items[lvCart.SelectedIndices[0]].Remove();
                CalculateTotalPrice();
            }
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
