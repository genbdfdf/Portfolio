using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Rwork2
{
    public partial class FormOrder : Form
    {
        List<string> SearchOrderslist = new List<string>()
        { "Orders.Oid", "State", "Pname", "Mname", "Ocount", "OPrice", "OSale", "Ototalprice", "OrderDate", "ODueDate", "OShipDate", "Oremark" };
  
        public FormOrder()
        {
            InitializeComponent();
        }
      
        private void FormOrder_Load(object sender, EventArgs e)
        {
            int x = (SystemInformation.WorkingArea.Width - this.Size.Width) / 2;
            int y = (SystemInformation.WorkingArea.Height - this.Size.Height) / 2;
            StartPosition = FormStartPosition.Manual; //窗體的位置由Location屬性決定
            Location = (Point)new Size(x, y);
            initOrderListView();
            cbSearchOrder.Items.Clear();
            cbSearchOrder.Items.Add("ID");
            cbSearchOrder.Items.Add("狀態");
            cbSearchOrder.Items.Add("口味");
            cbSearchOrder.Items.Add("訂購人");
            cbSearchOrder.Items.Add("數量");
            cbSearchOrder.Items.Add("價格");
            cbSearchOrder.Items.Add("折扣");
            cbSearchOrder.Items.Add("總價");
            cbSearchOrder.Items.Add("訂貨日期");
            cbSearchOrder.Items.Add("到期日期");
            cbSearchOrder.Items.Add("出貨日期");
            cbSearchOrder.Items.Add("備註");
            cbSearchOrder.SelectedIndex = 0;
        }

        private void FormOrder_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void FormOrder_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.formMain.Show();
        }

        private void butSearchOrder_Click(object sender, EventArgs e)
        {
            if (tbSearchOrder.Text != "")
            {
                initlvOrder();
                lvOrder.BeginUpdate();
                SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
                con.Open();
                string strSQL =
                    "SELECT Orders.*, Products.Pname, Member.Mname ,OrdersState.State " +
                    "FROM Orders " +
                    "JOIN Products ON Orders.Pid = Products.Pid " +
                    "JOIN Member ON Orders.Mid = Member.Mid " +
                    "JOIN OrdersState ON Orders.Sid = OrdersState.Sid " +
                    "WHERE " + SearchOrderslist[cbSearchOrder.SelectedIndex] + " LIKE  @SearchKeyWord;";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@SearchKeyWord", "%" + tbSearchOrder.Text + "%");
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.Text = "口";
                    listViewItem.SubItems.Add(reader["Oid"].ToString());
                    listViewItem.SubItems.Add(reader["State"].ToString());
                    listViewItem.SubItems.Add(reader["Pname"].ToString());
                    listViewItem.SubItems.Add(reader["Mname"].ToString());
                    listViewItem.SubItems.Add(reader["Ocount"].ToString());
                    listViewItem.SubItems.Add(reader["OPrice"].ToString());
                    listViewItem.SubItems.Add(reader["OSale"].ToString());
                    listViewItem.SubItems.Add(reader["Ototalprice"].ToString());
                    listViewItem.SubItems.Add(((DateTime)reader["OrderDate"]).ToString("yyyy/MM/dd"));
                    listViewItem.SubItems.Add(((DateTime)reader["ODueDate"]).ToString("yyyy/MM/dd"));
                    if (reader["OShipDate"] == DBNull.Value)
                    {
                        listViewItem.SubItems.Add("無日期");
                    }
                    else
                    {
                        listViewItem.SubItems.Add(((DateTime)reader["OShipDate"]).ToString("yyyy/MM/dd"));
                    }
                    listViewItem.SubItems.Add(reader["Oremark"].ToString());
                    lvOrder.Items.Add(listViewItem);
                }
                reader.Close();
                con.Close();
                lvOrder.EndUpdate();
            }
            else
            {
                MessageBox.Show("請輸入搜尋文字");
            }
        }
       
        private void butSearchOrderClear_Click(object sender, EventArgs e)
        {
            initOrderListView();
        }

        private void butEditOrder_Click(object sender, EventArgs e)
        {
            if (lvOrder.SelectedIndices.Count > 0)
            {
                FormOrderEdit formOrderEdit = new FormOrderEdit();
                formOrderEdit.EditID = lvOrder.Items[lvOrder.SelectedIndices[0]].SubItems[1].Text;
                formOrderEdit.ShowDialog();
            }
            else
            {
                MessageBox.Show("請勾選修改項目");
            }
        }

        private void lvOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvOrder.Items)
            {
                item.Text = "口";
            }
            if (lvOrder.SelectedIndices.Count > 0)
            {
                lvOrder.Items[lvOrder.SelectedIndices[0]].Text = "☑";
            }
        }

        public void initlvOrder()
        {
            lvOrder.Clear();
            lvOrder.Columns.Add("選擇", 50, HorizontalAlignment.Center);
            lvOrder.Columns.Add("ID", 70, HorizontalAlignment.Center);
            lvOrder.Columns.Add("狀態", 80, HorizontalAlignment.Center);
            lvOrder.Columns.Add("口味", 120, HorizontalAlignment.Center);
            lvOrder.Columns.Add("訂購人", 120, HorizontalAlignment.Center);
            lvOrder.Columns.Add("數量", 100, HorizontalAlignment.Center);
            lvOrder.Columns.Add("價格", 100, HorizontalAlignment.Center);
            lvOrder.Columns.Add("折扣", 100, HorizontalAlignment.Center);
            lvOrder.Columns.Add("總價", 100, HorizontalAlignment.Center);
            lvOrder.Columns.Add("訂貨日期", 100, HorizontalAlignment.Center);
            lvOrder.Columns.Add("到期日期", 100, HorizontalAlignment.Center);
            lvOrder.Columns.Add("出貨日期", 100, HorizontalAlignment.Center);
            lvOrder.Columns.Add("備註", 200, HorizontalAlignment.Center);
        }

        public void initOrderListView()
        {
            initlvOrder();
            lvOrder.BeginUpdate();
            SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
            con.Open();
            string strSQL =
                "SELECT Orders.*, Products.Pname, Member.Mname ,OrdersState.State " +
                "FROM Orders " +
                "JOIN Products ON Orders.Pid = Products.Pid " +
                "JOIN Member ON Orders.Mid = Member.Mid " +
                "JOIN OrdersState ON Orders.Sid = OrdersState.Sid ";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = "口";
                listViewItem.SubItems.Add(reader["Oid"].ToString());
                listViewItem.SubItems.Add(reader["State"].ToString());
                listViewItem.SubItems.Add(reader["Pname"].ToString());
                listViewItem.SubItems.Add(reader["Mname"].ToString());
                listViewItem.SubItems.Add(reader["Ocount"].ToString());
                listViewItem.SubItems.Add(reader["OPrice"].ToString());
                listViewItem.SubItems.Add(reader["OSale"].ToString());
                listViewItem.SubItems.Add(reader["Ototalprice"].ToString());
                listViewItem.SubItems.Add(((DateTime)reader["OrderDate"]).ToString("yyyy/MM/dd"));
                listViewItem.SubItems.Add(((DateTime)reader["ODueDate"]).ToString("yyyy/MM/dd"));
                if (reader["OShipDate"] == DBNull.Value)
                {
                    listViewItem.SubItems.Add("無日期");
                }
                else
                {
                    listViewItem.SubItems.Add(((DateTime)reader["OShipDate"]).ToString("yyyy/MM/dd"));
                }
                listViewItem.SubItems.Add(reader["Oremark"].ToString());
                lvOrder.Items.Add(listViewItem);
            }
            reader.Close();
            con.Close();
            lvOrder.EndUpdate();
        }

        private void butRevenue_Click(object sender, EventArgs e)
        {
            FormRevenue formRevenue = new FormRevenue();
            formRevenue.ShowDialog();
        }
    }
}
