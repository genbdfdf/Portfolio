using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Rwork2
{
    public partial class FormOrderEdit : Form
    {
        public string EditID = "";
        public List<int> IntlistProducts = new List<int>();
        public List<int> IntlistMember = new List<int>();
        public List<int> IntlistState = new List<int>();
        public FormOrderEdit()
        {
            InitializeComponent();
        }

        private void FormOrderEdit_Load(object sender, EventArgs e)
        {
            int x = (SystemInformation.WorkingArea.Width - this.Size.Width) / 2;
            int y = (SystemInformation.WorkingArea.Height - this.Size.Height) / 2;
            StartPosition = FormStartPosition.Manual; //窗體的位置由Location屬性決定
            Location = (Point)new Size(x, y);
            cbName.Items.Clear();
            cbMember.Items.Clear();
            cbState.Items.Clear();
            SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
            con.Open();

            #region 選擇項填充
            string strSQL ="SELECT * FROM Products order by Pid";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cbName.Items.Add(reader["Pname"].ToString());
                IntlistProducts.Add((int)reader["Pid"]);
            }
            cbName.SelectedIndex = 0;
            reader.Close();
            strSQL = "SELECT * FROM Member order by Mid";
            cmd = new SqlCommand(strSQL, con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cbMember.Items.Add(reader["Mname"].ToString());
                IntlistMember.Add((int)reader["Mid"]);
            }
            cbMember.SelectedIndex = 0;
            reader.Close();
            strSQL = "SELECT * FROM OrdersState order by Sid";
            cmd = new SqlCommand(strSQL, con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cbState.Items.Add(reader["State"].ToString());
                IntlistState.Add((int)reader["Sid"]);
            }
            cbState.SelectedIndex = 0;
            reader.Close();
            #endregion

            strSQL =
                "SELECT Orders.*, Products.Pname, Member.Mname ,OrdersState.State " +
                "FROM Orders " +
                "JOIN Products ON Orders.Pid = Products.Pid " +
                "JOIN Member ON Orders.Mid = Member.Mid " +
                "JOIN OrdersState ON Orders.Sid = OrdersState.Sid " +
                "WHERE Oid =  @SearchID";
            cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@SearchID", EditID);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                tbId.Text = reader["Oid"].ToString();
                cbState.Text = reader["State"].ToString();
                cbName.Text = reader["Pname"].ToString();
                cbMember.Text = reader["Mname"].ToString();
                tbCount.Text = reader["Ocount"].ToString();
                tbPrice.Text = reader["OPrice"].ToString();
                tbSale.Text = reader["OSale"].ToString();
                string faststr1 = "";
                for (int i = 0; i < 12 - reader["Ototalprice"].ToString().Length; i++)
                {
                    faststr1 += "0";
                }
                lbTotalPrice.Text = faststr1+reader["Ototalprice"].ToString();
                dtpOrderDate.Value = (DateTime)reader["OrderDate"];
                dtpDueDate.Value = (DateTime)reader["ODueDate"];
                if (reader["OShipDate"] == DBNull.Value)
                {
                    dtpShipDate.Value=DateTime.Now;
                }
                else
                {
                    dtpShipDate.Value = (DateTime)reader["OShipDate"];
                    chbShipDate.Checked = true;
                }
                tbRemark.Text = reader["Oremark"].ToString();
            }
            reader.Close();
            con.Close();
        }

        private void butComplete_Click(object sender, EventArgs e)
        {
            if (int.TryParse(tbCount.Text, out int Count))
                if (int.TryParse(tbPrice.Text, out int Price))
                    if (double.TryParse(tbSale.Text, out double Sale))
                    {
                        SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
                        con.Open();
                        if (int.TryParse(tbId.Text, out int ID))
                        {
                            string strSQL =
                               "update Orders set Sid=@NewSid,Pid=@NewPid,Mid=@NewMid,Ocount=@NewCount, OPrice = @NewPrice ,OSale = @NewSale," +
                               "OrderDate = @NewOrderDate,ODueDate = @NewDueDate, OShipDate = @NewShipDate, Oremark = @NewRemark where Oid = @SearchID";
                            SqlCommand cmd = new SqlCommand(strSQL, con);
                            cmd.Parameters.AddWithValue("@NewSid", IntlistState[cbState.SelectedIndex]);
                            cmd.Parameters.AddWithValue("@NewPid", IntlistProducts[cbName.SelectedIndex]);
                            cmd.Parameters.AddWithValue("@NewMid", IntlistMember[cbMember.SelectedIndex]);
                            cmd.Parameters.AddWithValue("@NewCount", Count);
                            cmd.Parameters.AddWithValue("@NewPrice", Price);
                            cmd.Parameters.AddWithValue("@NewSale", Sale);
                            cmd.Parameters.AddWithValue("@NewOrderDate", dtpOrderDate.Value);
                            cmd.Parameters.AddWithValue("@NewDueDate", dtpDueDate.Value);
                            if (chbShipDate.Checked == true)
                                cmd.Parameters.AddWithValue("@NewShipDate", dtpShipDate.Value);
                            else
                                cmd.Parameters.AddWithValue("@NewShipDate", DBNull.Value);

                            cmd.Parameters.AddWithValue("@NewRemark", tbRemark.Text);
                            cmd.Parameters.AddWithValue("@SearchID", EditID);
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        else
                        {
                            string strSQL =
                            "insert into Orders values(@NewSid,@NewPid,@NewMid,@NewCount,@NewPrice,@NewSale,@NewOrderDate,@NewDueDate,@NewShipDate,@NewRemark)";
                            SqlCommand cmd = new SqlCommand(strSQL, con);
                            cmd.Parameters.AddWithValue("@NewSid", IntlistState[cbState.SelectedIndex]);
                            cmd.Parameters.AddWithValue("@NewPid", IntlistProducts[cbName.SelectedIndex]);
                            cmd.Parameters.AddWithValue("@NewMid", IntlistMember[cbMember.SelectedIndex]);
                            cmd.Parameters.AddWithValue("@NewCount", Count);
                            cmd.Parameters.AddWithValue("@NewPrice", Price);
                            cmd.Parameters.AddWithValue("@NewSale", Sale);
                            cmd.Parameters.AddWithValue("@NewOrderDate", dtpOrderDate.Value);
                            cmd.Parameters.AddWithValue("@NewDueDate", dtpDueDate.Value);
                            if (chbShipDate.Checked == true)
                                cmd.Parameters.AddWithValue("@NewShipDate", dtpShipDate.Value);
                            else
                                cmd.Parameters.AddWithValue("@NewShipDate", DBNull.Value);

                            cmd.Parameters.AddWithValue("@NewRemark", tbRemark.Text);
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        Close();
                        FormOrder formOrder = Application.OpenForms["FormOrder"] as FormOrder;
                        if (formOrder != null)
                        {
                            formOrder.initOrderListView();
                        }
                    }
                    else
                        MessageBox.Show("折扣請輸入數字");
                else 
                    MessageBox.Show("價格請輸入數字");
            else
                MessageBox.Show("數量請輸入數字");
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void chbShipDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chbShipDate.Checked == true)
            {
                dtpShipDate.Visible = true;
            }
            else
            {
                dtpShipDate.Visible = false;
            }
        }

        private void tbCount_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(tbCount.Text,out int Count))
            {
                if (int.TryParse(tbPrice.Text, out int Price))
                {
                    if (double.TryParse(tbSale.Text, out double Sale))
                    {
                        string faststr1 = "";
                        for (int i = 0; i < 12 - (Count * Price * Sale).ToString("F0").Length; i++)
                        {
                            faststr1 += "0";
                        }
                        lbTotalPrice.Text = faststr1+(Count * Price * Sale).ToString("F0");
                    }
                }
            }
        }

        private void tbPrice_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(tbCount.Text, out int Count))
            {
                if (int.TryParse(tbPrice.Text, out int Price))
                {
                    if (double.TryParse(tbSale.Text, out double Sale))
                    {
                        string faststr1 = "";
                        for (int i = 0; i < 12 - (Count * Price * Sale).ToString("F0").Length; i++)
                        {
                            faststr1 += "0";
                        }
                        lbTotalPrice.Text = faststr1 + (Count * Price * Sale).ToString("F0");
                    }
                }
            }
        }

        private void tbSale_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(tbCount.Text, out int Count))
            {
                if (int.TryParse(tbPrice.Text, out int Price))
                {
                    if (double.TryParse(tbSale.Text, out double Sale))
                    {
                        string faststr1 = "";
                        for (int i = 0; i < 12 - (Count * Price * Sale).ToString("F0").Length; i++)
                        {
                            faststr1 += "0";
                        }
                        lbTotalPrice.Text = faststr1 + (Count * Price * Sale).ToString("F0");
                    }
                }
            }
        }
    }
}
