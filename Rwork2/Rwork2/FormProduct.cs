using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Rwork2
{
    public partial class FormProduct : Form
    {
        List<string> Searchlist = new List<string>() { "pid", "Pname", "Pdesc", "Pcount", "Price", "State" };
        public FormProduct()
        {
            InitializeComponent();
        }
      
        private void FormProduct_Load(object sender, EventArgs e)
        {
            int x = (SystemInformation.WorkingArea.Width - this.Size.Width) / 2;
            int y = (SystemInformation.WorkingArea.Height - this.Size.Height) / 2;
            StartPosition = FormStartPosition.Manual; //窗體的位置由Location屬性決定
            Location = (Point)new Size(x, y);
            initProductListView();
            cbSearch.Items.Clear();
            cbSearch.Items.Add("ID");
            cbSearch.Items.Add("口味");
            cbSearch.Items.Add("描述");
            cbSearch.Items.Add("存貨");
            cbSearch.Items.Add("價格");
            cbSearch.Items.Add("狀態");
            cbSearch.SelectedIndex = 0;
        }

        private void butSearch_Click(object sender, EventArgs e)
        {
            if (tbSearch.Text != "")
            {
                initlvProduct();
                lvProduct.BeginUpdate();
                SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
                con.Open();
                string strSQL =
                    "SELECT Products.*, ProductsState.State FROM Products JOIN ProductsState ON Products.sid = ProductsState.sid " +
                    "WHERE " + Searchlist[cbSearch.SelectedIndex] + " LIKE  @SearchKeyWord;";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@SearchKeyWord", "%" + tbSearch.Text + "%");
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.Text = "口";
                    listViewItem.SubItems.Add(reader["Pid"].ToString());
                    listViewItem.SubItems.Add(reader["Pname"].ToString());
                    listViewItem.SubItems.Add(reader["Pdesc"].ToString());
                    listViewItem.SubItems.Add(reader["Pcount"].ToString());
                    listViewItem.SubItems.Add(reader["Price"].ToString());
                    listViewItem.SubItems.Add(reader["State"].ToString());
                    lvProduct.Items.Add(listViewItem);
                }
                reader.Close();
                con.Close();
                lvProduct.EndUpdate();
            }
            else
            {
                MessageBox.Show("請輸入搜尋文字");
            }
        }
   
        private void butSearchClear_Click(object sender, EventArgs e)
        {
            initProductListView();
        }
     
        private void butAddProduct_Click(object sender, EventArgs e)
        {
            FormProductAddAndEdit formProductAddAndEdit = new FormProductAddAndEdit();
            formProductAddAndEdit.ShowDialog();
        }
      
        private void butEditProduct_Click(object sender, EventArgs e)
        {
            if (lvProduct.SelectedIndices.Count > 0)
            {
                FormProductAddAndEdit formProductAddAndEdit = new FormProductAddAndEdit();
                formProductAddAndEdit.EditID = lvProduct.Items[lvProduct.SelectedIndices[0]].SubItems[1].Text;
                formProductAddAndEdit.ShowDialog();
            }
            else
            {
                MessageBox.Show("請勾選修改項目");
            }
        }

        private void FormProduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.formMain.Show();
        }
  
        private void FormProduct_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
     
        private void lvProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvProduct.Items)
            {
                item.Text = "口";
            }
            if (lvProduct.SelectedIndices.Count > 0)
            {
                lvProduct.Items[lvProduct.SelectedIndices[0]].Text = "☑";
            }
        }

        public void initlvProduct()
        {
            lvProduct.Clear();
            lvProduct.Columns.Add("選擇", 50, HorizontalAlignment.Center);
            lvProduct.Columns.Add("ID", 50, HorizontalAlignment.Center);
            lvProduct.Columns.Add("口味", 80, HorizontalAlignment.Center);
            lvProduct.Columns.Add("描述", lvProduct.Width - 481, HorizontalAlignment.Center);
            lvProduct.Columns.Add("存貨", 80, HorizontalAlignment.Center);
            lvProduct.Columns.Add("價格", 80, HorizontalAlignment.Center);
            lvProduct.Columns.Add("狀態", 120, HorizontalAlignment.Center);
        }
  
        public void initProductListView()
        {
            initlvProduct();
            lvProduct.BeginUpdate();
            SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
            con.Open();
            string strSQL =
                "SELECT Products.*,ProductsState.State " +
                "from ProductsState join Products " +
                "on Products.sid = ProductsState.sid";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = "口";
                listViewItem.SubItems.Add(reader["Pid"].ToString());
                listViewItem.SubItems.Add(reader["Pname"].ToString());
                listViewItem.SubItems.Add(reader["Pdesc"].ToString());
                listViewItem.SubItems.Add(reader["Pcount"].ToString());
                listViewItem.SubItems.Add(reader["Price"].ToString());
                listViewItem.SubItems.Add(reader["State"].ToString());
                lvProduct.Items.Add(listViewItem);
            }
            reader.Close();
            con.Close();
            lvProduct.EndUpdate();
        }

    }
}
