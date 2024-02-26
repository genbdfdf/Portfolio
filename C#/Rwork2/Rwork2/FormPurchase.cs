using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rwork2
{
    public partial class FormPurchase : Form
    {
        List<string> SearchPurchaselist = new List<string>()
        { "Purchase.pid", "State", "PersonName", "PurchaseStoreName", "ProductsName", "Price", "Pcount","PSale", "Ptotalprice", "Pstartdate", "Pshipdate", "Penddate", "Premark" };

        public FormPurchase()
        {
            InitializeComponent();
        }

        private void Formpurchase_Load(object sender, EventArgs e)
        {
            int x = (SystemInformation.WorkingArea.Width - this.Size.Width) / 2;
            int y = (SystemInformation.WorkingArea.Height - this.Size.Height) / 2;
            StartPosition = FormStartPosition.Manual; //窗體的位置由Location屬性決定
            Location = (Point)new Size(x, y);
            initPurchaseListView();
            cbSearchPurchase.Items.Clear();
            cbSearchPurchase.Items.Add("ID");
            cbSearchPurchase.Items.Add("狀態");
            cbSearchPurchase.Items.Add("員工");
            cbSearchPurchase.Items.Add("廠商");
            cbSearchPurchase.Items.Add("口味");
            cbSearchPurchase.Items.Add("價格");
            cbSearchPurchase.Items.Add("數量");
            cbSearchPurchase.Items.Add("折扣");
            cbSearchPurchase.Items.Add("總價");
            cbSearchPurchase.Items.Add("訂貨日期");
            cbSearchPurchase.Items.Add("到期日期");
            cbSearchPurchase.Items.Add("收貨日期");
            cbSearchPurchase.Items.Add("備註");
            cbSearchPurchase.SelectedIndex = 0;
        }

        private void butSearchPurchase_Click(object sender, EventArgs e)
        {
            if (tbSearchPurchase.Text != "")
            {
                initlvPurchase();
                lvPurchase.BeginUpdate();
                SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
                con.Open();
                string strSQL =
                    "SELECT Purchase.*, PurchaseState.State, Person.Pname as PersonName, PurchaseStore.Pname as PurchaseStoreName, Products.Pname as ProductsName " +
                    "FROM Purchase " +
                    "JOIN Person ON Purchase.Personid = Person.Pid " +
                    "JOIN PurchaseStore ON Purchase.Purchaseid = PurchaseStore.Pid " +
                    "JOIN Products ON Purchase.Productid = Products.Pid " +
                    "JOIN PurchaseState ON Purchase.Sid = PurchaseState.Sid " +
                    "WHERE " + SearchPurchaselist[cbSearchPurchase.SelectedIndex] + " LIKE  @SearchKeyWord;";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@SearchKeyWord", "%" + tbSearchPurchase.Text + "%");
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.Text = "口";
                    listViewItem.SubItems.Add(reader["Pid"].ToString());
                    listViewItem.SubItems.Add(reader["State"].ToString());
                    listViewItem.SubItems.Add(reader["PersonName"].ToString());
                    listViewItem.SubItems.Add(reader["PurchaseStoreName"].ToString());
                    listViewItem.SubItems.Add(reader["ProductsName"].ToString());
                    listViewItem.SubItems.Add(reader["Price"].ToString());
                    listViewItem.SubItems.Add(reader["Pcount"].ToString());
                    listViewItem.SubItems.Add(reader["PSale"].ToString());
                    listViewItem.SubItems.Add(reader["Ptotalprice"].ToString());
                    listViewItem.SubItems.Add(((DateTime)reader["Pstartdate"]).ToString("yyyy/MM/dd"));
                    listViewItem.SubItems.Add(((DateTime)reader["Pshipdate"]).ToString("yyyy/MM/dd"));
                    if (reader["Penddate"] == DBNull.Value)
                    {
                        listViewItem.SubItems.Add("");
                    }
                    else
                    {
                        listViewItem.SubItems.Add(((DateTime)reader["Penddate"]).ToString("yyyy/MM/dd"));
                    }
                    listViewItem.SubItems.Add(reader["Premark"].ToString());
                    lvPurchase.Items.Add(listViewItem);
                }
                reader.Close();
                con.Close();
                lvPurchase.EndUpdate();
            }
            else
            {
                MessageBox.Show("請輸入搜尋文字");
            }
        }

        private void butSearchPurchaseClear_Click(object sender, EventArgs e)
        {
            initPurchaseListView();
        }

        private void butAddPurchase_Click(object sender, EventArgs e)
        {
            FormPurchaseAddAndEdit formPurchaseAddAndEdit = new FormPurchaseAddAndEdit();
            formPurchaseAddAndEdit.ShowDialog();
        }

        private void butEditPurchase_Click(object sender, EventArgs e)
        {
            if (lvPurchase.SelectedIndices.Count > 0)
            {
                FormPurchaseAddAndEdit formPurchaseAddAndEdit = new FormPurchaseAddAndEdit();
                formPurchaseAddAndEdit.EditID = lvPurchase.Items[lvPurchase.SelectedIndices[0]].SubItems[1].Text;
                formPurchaseAddAndEdit.ShowDialog();
            }
            else
            {
                MessageBox.Show("請勾選修改項目");
            }

        }

        private void Formpurchase_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        private void Formpurchase_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.formMain.Show();
        }

        private void lvPurchase_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvPurchase.Items)
            {
                item.Text = "口";
            }
            if (lvPurchase.SelectedIndices.Count > 0)
            {
                lvPurchase.Items[lvPurchase.SelectedIndices[0]].Text = "☑";
            }
        }
        public void initlvPurchase()
        {
            lvPurchase.Clear();
            lvPurchase.Columns.Add("選擇", 50, HorizontalAlignment.Center);
            lvPurchase.Columns.Add("ID", 70, HorizontalAlignment.Center);
            lvPurchase.Columns.Add("狀態", 80, HorizontalAlignment.Center);
            lvPurchase.Columns.Add("員工", 120, HorizontalAlignment.Center);
            lvPurchase.Columns.Add("廠商", 120, HorizontalAlignment.Center);
            lvPurchase.Columns.Add("口味", 100, HorizontalAlignment.Center);
            lvPurchase.Columns.Add("價格", 100, HorizontalAlignment.Center);
            lvPurchase.Columns.Add("數量", 100, HorizontalAlignment.Center);
            lvPurchase.Columns.Add("折扣", 100, HorizontalAlignment.Center);
            lvPurchase.Columns.Add("總價", 100, HorizontalAlignment.Center);
            lvPurchase.Columns.Add("訂貨日期", 100, HorizontalAlignment.Center);
            lvPurchase.Columns.Add("到期日期", 100, HorizontalAlignment.Center);
            lvPurchase.Columns.Add("收貨日期", 100, HorizontalAlignment.Center);
            lvPurchase.Columns.Add("備註", 200, HorizontalAlignment.Center);
        }

        public void initPurchaseListView()
        {
            initlvPurchase();
            lvPurchase.BeginUpdate();
            SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
            con.Open();
            string strSQL =
                "SELECT Purchase.*, PurchaseState.State, Person.Pname as PersonName, PurchaseStore.Pname as PurchaseStoreName, Products.Pname as ProductsName " +
                "FROM Purchase " +
                "JOIN Person ON Purchase.Personid = Person.Pid " +
                "JOIN PurchaseStore ON Purchase.Purchaseid = PurchaseStore.Pid " +
                "JOIN Products ON Purchase.Productid = Products.Pid " +
                "JOIN PurchaseState ON Purchase.Sid = PurchaseState.Sid ";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = "口";
                listViewItem.SubItems.Add(reader["Pid"].ToString());
                listViewItem.SubItems.Add(reader["State"].ToString());
                listViewItem.SubItems.Add(reader["PersonName"].ToString());
                listViewItem.SubItems.Add(reader["PurchaseStoreName"].ToString());
                listViewItem.SubItems.Add(reader["ProductsName"].ToString());
                listViewItem.SubItems.Add(reader["Price"].ToString());
                listViewItem.SubItems.Add(reader["Pcount"].ToString());
                listViewItem.SubItems.Add(reader["PSale"].ToString());
                listViewItem.SubItems.Add(reader["Ptotalprice"].ToString());
                listViewItem.SubItems.Add(((DateTime)reader["Pstartdate"]).ToString("yyyy/MM/dd"));
                listViewItem.SubItems.Add(((DateTime)reader["Pshipdate"]).ToString("yyyy/MM/dd"));
                if (reader["Penddate"] == DBNull.Value)
                {
                    listViewItem.SubItems.Add("");
                }
                else
                {
                    listViewItem.SubItems.Add(((DateTime)reader["Penddate"]).ToString("yyyy/MM/dd"));
                }
                listViewItem.SubItems.Add(reader["Premark"].ToString());
                lvPurchase.Items.Add(listViewItem);
            }
            reader.Close();
            con.Close();
            lvPurchase.EndUpdate();
        }
    }
}
