using System;
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
using static System.Windows.Forms.AxHost;

namespace Rwork2
{
    public partial class FormProductAddAndEdit : Form
    {
        public string EditID= "";
        public List<int> IntlistState = new List<int>();
        public FormProductAddAndEdit()
        {
            InitializeComponent();
        }

        private void FormProductAddAndEdit_Load(object sender, EventArgs e)
        {
            int x = (SystemInformation.WorkingArea.Width - this.Size.Width) / 2;
            int y = (SystemInformation.WorkingArea.Height - this.Size.Height) / 2;
            StartPosition = FormStartPosition.Manual; //窗體的位置由Location屬性決定
            Location = (Point)new Size(x, y);
            cbState.Items.Clear();
            SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
            con.Open();
            string strSQL =
                "SELECT * FROM ProductsState order by Sid";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cbState.Items.Add(reader["State"].ToString());
                IntlistState.Add((int)reader["Sid"]);
            }
            cbState.SelectedIndex = 0;
            reader.Close();
            strSQL ="SELECT Products.*, ProductsState.State FROM Products JOIN ProductsState ON Products.sid = ProductsState.sid WHERE Pid =  @SearchID";
            cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@SearchID",EditID);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                tbId.Text = reader["Pid"].ToString();
                tbName.Text = reader["Pname"].ToString();
                tbDescription.Text = reader["Pdesc"].ToString();
                tbStock.Text = reader["Pcount"].ToString();
                tbPrice.Text = reader["Price"].ToString();
                cbState.Text = reader["State"].ToString();
            }
            reader.Close();
            con.Close();
        }
        private void butClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void butComplete_Click(object sender, EventArgs e)
        {
            if (tbName.Text != "" && tbDescription.Text != "")
                if (int.TryParse(tbStock.Text, out int Stock))
                    if (int.TryParse(tbPrice.Text, out int Price))
                    {
                        SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
                        con.Open();
                        if (int.TryParse(tbId.Text, out int ID))
                        {
                            string strSQL =
                               "update Products set Sid=@NewSid, Pname = @NewName, Pdesc = @NewDesc, Pcount = @NewCount, Price = @NewPrice where Pid = @SearchID";
                            SqlCommand cmd = new SqlCommand(strSQL, con);
                            cmd.Parameters.AddWithValue("@NewSid", IntlistState[cbState.SelectedIndex]);
                            cmd.Parameters.AddWithValue("@NewName", tbName.Text);
                            cmd.Parameters.AddWithValue("@NewCount", Stock);
                            cmd.Parameters.AddWithValue("@NewPrice", Price);
                            cmd.Parameters.AddWithValue("@NewDesc", tbDescription.Text);
                            cmd.Parameters.AddWithValue("@SearchID", ID);
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        else
                        {
                            string strSQL =
                            "insert into Products(Sid,Pname,Pcount,Price,Pdesc) values(@NewSid,@NewName,@NewCount,@NewPrice,@NewDesc)";
                            SqlCommand cmd = new SqlCommand(strSQL, con);
                            cmd.Parameters.AddWithValue("@NewSid", IntlistState[cbState.SelectedIndex]);
                            cmd.Parameters.AddWithValue("@NewName", tbName.Text);
                            cmd.Parameters.AddWithValue("@NewCount", Stock);
                            cmd.Parameters.AddWithValue("@NewPrice", Price);
                            cmd.Parameters.AddWithValue("@NewDesc", tbDescription.Text);
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        Close();
                        FormProduct formProduct = Application.OpenForms["FormProduct"] as FormProduct;
                        if (formProduct != null)
                        {
                            formProduct.initProductListView();
                        }
                    }
                    else MessageBox.Show("價格請輸入數字");
                else MessageBox.Show("存貨請輸入數字");
            else MessageBox.Show("請勿空白");
        }
        private void FormProductAddAndEdit_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void FormProductAddAndEdit_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
