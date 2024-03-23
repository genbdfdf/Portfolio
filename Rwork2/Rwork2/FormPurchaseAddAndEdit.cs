using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;

namespace Rwork2
{
    public partial class FormPurchaseAddAndEdit : Form
    {
        public string EditID = "";
        public List<int> IntlistState = new List<int>();
        public List<int> IntlistProducts = new List<int>();
        public List<int> IntlistPerson = new List<int>();
        public List<int> IntlistPurchaseStore = new List<int>();
        
        public FormPurchaseAddAndEdit()
        {
            InitializeComponent();
        }

        private void FormPurchaseAddAndEdit_Load(object sender, EventArgs e)
        {
            int x = (SystemInformation.WorkingArea.Width - this.Size.Width) / 2;
            int y = (SystemInformation.WorkingArea.Height - this.Size.Height) / 2;
            StartPosition = FormStartPosition.Manual; //窗體的位置由Location屬性決定
            Location = (Point)new Size(x, y);
            cbName.Items.Clear();
            cbPerson.Items.Clear();
            cbState.Items.Clear();
            cbPurchaseStore.Items.Clear();
            SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
            con.Open();

            #region 選擇項填充
            string strSQL = "SELECT * FROM Products order by Pid";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cbName.Items.Add(reader["Pname"].ToString());
                IntlistProducts.Add((int)reader["Pid"]);
            }
            cbName.SelectedIndex = 0;
            reader.Close();
            strSQL = "SELECT * FROM Person order by Pid";
            cmd = new SqlCommand(strSQL, con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cbPerson.Items.Add(reader["Pname"].ToString());
                IntlistPerson.Add((int)reader["Pid"]);
            }
            cbPerson.SelectedIndex = 0;
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
            strSQL = "SELECT * FROM PurchaseStore order by Pid";
            cmd = new SqlCommand(strSQL, con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cbPurchaseStore.Items.Add(reader["Pname"].ToString());
                IntlistPurchaseStore.Add((int)reader["Pid"]);
            }
            cbPurchaseStore.SelectedIndex = 0;
            reader.Close();
            #endregion

            strSQL =
                "SELECT Purchase.*, PurchaseState.State, Person.Pname as PersonName, PurchaseStore.Pname as PurchaseStoreName, Products.Pname as ProductsName " +
                "FROM Purchase " +
                "JOIN Person ON Purchase.Personid = Person.Pid " +
                "JOIN PurchaseStore ON Purchase.Purchaseid = PurchaseStore.Pid " +
                "JOIN Products ON Purchase.Productid = Products.Pid " +
                "JOIN PurchaseState ON Purchase.Sid = PurchaseState.Sid " +
                "WHERE Purchase.Pid=  @SearchID";
            cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@SearchID", EditID);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                tbId.Text = reader["Pid"].ToString();
                cbState.Text = reader["State"].ToString();
                cbName.Text = reader["ProductsName"].ToString();
                cbPurchaseStore.Text = reader["PurchaseStoreName"].ToString();
                cbPerson.Text = reader["PersonName"].ToString();
                tbCount.Text = reader["Pcount"].ToString();
                tbPrice.Text = reader["Price"].ToString();
                tbSale.Text = reader["PSale"].ToString();
                string faststr1 = "";
                for (int i = 0; i < 12 - reader["Ptotalprice"].ToString().Length; i++)
                {
                    faststr1 += "0";
                }
                lbTotalPrice.Text = faststr1 + reader["Ptotalprice"].ToString();
                dtpStartdate.Value = (DateTime)reader["Pstartdate"];
                dtpShipDate.Value = (DateTime)reader["Pshipdate"];
                if (reader["Penddate"] == DBNull.Value)
                {
                    dtpEnddate.Value = DateTime.Now;
                }
                else
                {
                    dtpEnddate.Value = (DateTime)reader["Penddate"];
                    chbShipDate.Checked = true;
                }
                tbRemark.Text = reader["Premark"].ToString();
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
                               "update Purchase set Sid=@NewSid,Personid=@NewPersonid,Purchaseid=@NewPurchaseid,Productid=@NewProductid,Pcount=@NewCount," +
                               "Price = @NewPrice ,PSale = @NewSale,Pstartdate = @NewStartdate,Pshipdate = @NewShipDate, Penddate = @NewEnddate, Premark = @NewRemark " +
                               "where Purchase.Pid = @SearchID";
                            SqlCommand cmd = new SqlCommand(strSQL, con);
                            cmd.Parameters.AddWithValue("@NewSid", IntlistState[cbState.SelectedIndex]);
                            cmd.Parameters.AddWithValue("@NewPersonid", IntlistPerson[cbPerson.SelectedIndex]);
                            cmd.Parameters.AddWithValue("@NewPurchaseid", IntlistPurchaseStore[cbPurchaseStore.SelectedIndex]);
                            cmd.Parameters.AddWithValue("@NewProductid", IntlistProducts[cbName.SelectedIndex]);
                            cmd.Parameters.AddWithValue("@NewCount", Count);
                            cmd.Parameters.AddWithValue("@NewPrice", Price);
                            cmd.Parameters.AddWithValue("@NewSale", Sale);
                            cmd.Parameters.AddWithValue("@NewStartdate", dtpStartdate.Value);
                            cmd.Parameters.AddWithValue("@NewShipDate", dtpShipDate.Value);
                            if (chbShipDate.Checked == true)
                                cmd.Parameters.AddWithValue("@NewEnddate", dtpEnddate.Value);
                            else
                                cmd.Parameters.AddWithValue("@NewEnddate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@NewRemark", tbRemark.Text);
                            cmd.Parameters.AddWithValue("@SearchID", EditID);
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        else
                        {
                            string strSQL =
                            "insert into Orders values(@NewSid,@NewPersonid,@NewPurchaseid,@NewProductid," +
                            "@NewCount,@NewPrice,@NewSale,@NewStartdate,@NewShipdate,@NewEnddate,@NewRemark)";
                            SqlCommand cmd = new SqlCommand(strSQL, con);
                            cmd.Parameters.AddWithValue("@NewSid", IntlistState[cbState.SelectedIndex]);
                            cmd.Parameters.AddWithValue("@NewPersonid", IntlistPerson[cbPerson.SelectedIndex]);
                            cmd.Parameters.AddWithValue("@NewPurchaseid", IntlistPurchaseStore[cbPurchaseStore.SelectedIndex]);
                            cmd.Parameters.AddWithValue("@NewProductid", IntlistProducts[cbName.SelectedIndex]);
                            cmd.Parameters.AddWithValue("@NewCount", Count);
                            cmd.Parameters.AddWithValue("@NewPrice", Price);
                            cmd.Parameters.AddWithValue("@NewSale", Sale);
                            cmd.Parameters.AddWithValue("@NewStartdate", dtpStartdate.Value);
                            cmd.Parameters.AddWithValue("@NewShipdate", dtpShipDate.Value);
                            if (chbShipDate.Checked == true)
                                cmd.Parameters.AddWithValue("@NewEnddate", dtpEnddate.Value);
                            else
                                cmd.Parameters.AddWithValue("@NewEnddate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@NewRemark", tbRemark.Text);
                            cmd.Parameters.AddWithValue("@SearchID", EditID);
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        Close();
                        FormPurchase formPurchase = Application.OpenForms["FormPurchase"] as FormPurchase;
                        if (formPurchase != null)
                        {
                            formPurchase.initPurchaseListView();
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
                dtpEnddate.Visible = true;
            }
            else
            {
                dtpEnddate.Visible = false;
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

        private void tbCount_TextChanged(object sender, EventArgs e)
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
