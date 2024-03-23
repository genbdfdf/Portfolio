using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using System.Xml.Linq;
using System.Security.Cryptography;

namespace Rwork2
{
    public partial class FormCheckout : Form
    {
        long totalPrice = 0;
        double Sale = 1;
        public FormCheckout()
        {
            InitializeComponent();
        }
        private void FormCheckout_Load(object sender, EventArgs e)
        {
            int x = (SystemInformation.WorkingArea.Width - this.Size.Width) / 2;
            int y = (SystemInformation.WorkingArea.Height - this.Size.Height) / 2;
            StartPosition = FormStartPosition.Manual; //窗體的位置由Location屬性決定
            Location = (Point)new Size(x, y);
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

        private void chbBuyShoppingBag_CheckedChanged(object sender, EventArgs e)
        {
            if (chbBuyShoppingBag.Checked == true)
            {
                totalPrice += 2;
                string faststr1 = "";
                for (int i = 0; i < 12 - totalPrice.ToString().Length; i++)
                {
                    faststr1 += "0";
                }
                lbtotalPrice.Text = faststr1 + totalPrice.ToString();
            }
            else
            {
                totalPrice -= 2;
                string faststr1 = "";
                for (int i = 0; i < 12 - totalPrice.ToString().Length; i++)
                {
                    faststr1 += "0";
                }
                lbtotalPrice.Text = faststr1 + totalPrice.ToString();
            }
        }

        private void chbUBN_CheckedChanged(object sender, EventArgs e)
        {

            if (chbUBN.Checked == true)
            {
                tbUBN.Visible = true;
            }
            else
            {
                tbUBN.Visible = false;
            }
        }

        private void rbCreditCard_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCreditCard.Checked == true)
            {
                tbCreditCard.Visible = true;
            }
            else
            {
                tbCreditCard.Visible = false;
            }
        }
        private void butCheckout_Click(object sender, EventArgs e)
        {
            if (chbUBN.Checked != true || tbUBN.Text != "")
                if (rbCreditCard.Checked != true || tbCreditCard.Text != "")
                {
                    DialogResult dialogresult = MessageBox.Show("確定結帳", "結帳通知", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogresult == DialogResult.Yes)
                    {
                        List<ArrayList> fastListarraylist = new List<ArrayList>();
                        SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
                        con.Open();
                        string strSQL =
                            "SELECT * FROM Products";
                        SqlCommand cmd = new SqlCommand(strSQL, con);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            ArrayList fastarraylist = new ArrayList();
                            fastarraylist.Add(reader["Pid"].ToString());
                            fastarraylist.Add(reader["Pname"].ToString());
                            fastarraylist.Add((int)reader["Pcount"]);
                            fastarraylist.Add(0);
                            fastListarraylist.Add(fastarraylist);
                        }
                        reader.Close();
                        strSQL =
                            "SELECT * FROM Member where Mid=@NowMid";
                        cmd = new SqlCommand(strSQL, con);
                        cmd.Parameters.AddWithValue("@NowMid", GlobalVar.NowLoginID);
                        reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            switch (reader["Lid"])
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
                        }
                        con.Close();
                        foreach (var item in GlobalVar.ArrayListBuys)
                        {
                            int x = 0;
                            for (int i = 0; i < fastListarraylist.Count; i++)
                            {
                                if (item[0].Equals(fastListarraylist[i][0].ToString()))
                                {
                                    x = (int)fastListarraylist[i][3];
                                    x += (int)item[2];
                                    fastListarraylist[i][3] = x;
                                    break;
                                }
                            }
                        }
                        string faststr = "缺少以下存貨\n";
                        foreach (var item in fastListarraylist)
                            if ((int)item[3] > (int)item[2])
                                faststr += ((int)item[3] - (int)item[2]) + "個" + item[1]+ "\n";
                        faststr += "需要補貨請問是否願意等待";
                        if (faststr == "缺少以下存貨\n需要補貨請問是否願意等待")
                        {
                            checkout();
                        }
                        else
                        {
                            DialogResult dialogresult2 = MessageBox.Show(faststr, "缺貨通知", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogresult2 == DialogResult.Yes)
                                checkout();
                            else 
                                MessageBox.Show("請修改訂購單");
                        }
                    }
                }
                else
                    MessageBox.Show("請輸入信用卡");
            else
                MessageBox.Show("請輸入統編");
        }
        public void checkout()
        {
            List<ArrayList> ArrayListOrder = new List<ArrayList>();

            string Remark ="";
            if (chbTakeout.Checked == true) Remark += "外帶";
            if (chbDonateReceipt.Checked == true) Remark += "捐贈發票";
            if (chbUBN.Checked == true)
            {
                Remark += "統編：" + tbUBN.Text;
            }
            if (rbCash.Checked == true) Remark += "現金";
            if (rbCreditCard.Checked == true)
            {
                Remark += "信用卡：" + tbCreditCard.Text;
            }
            //Remark+=
            SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
            con.Open();
            string strSQL="";
            foreach (var item in GlobalVar.ArrayListBuys)
            { 
                //ID,口味,存貨,價格
                strSQL =
           "insert into Orders(Pid,Mid,Ocount,OPrice,OSale,OrderDate,ODueDate,Oremark) " +
           "values(@NewPid,@NewMid,@NewCount,@NewPrice,@NewSale,@NewOrderDate,DATEADD(DAY, 30, @NewDueDate),@NewRemark)";
                 SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@NewPid", item[0]);
                cmd.Parameters.AddWithValue("@NewMid", GlobalVar.NowLoginID);
                cmd.Parameters.AddWithValue("@NewCount", item[2]);
                cmd.Parameters.AddWithValue("@NewPrice", item[3]);
                cmd.Parameters.AddWithValue("@NewSale", Sale);
                cmd.Parameters.AddWithValue("@NewOrderDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@NewDueDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@NewRemark", Remark);
                cmd.ExecuteNonQuery();
            }
            if (chbBuyShoppingBag.Checked == true)
            {
                //ID,口味,存貨,價格
                strSQL =
           "insert into Orders(Pid,Mid,Ocount,OPrice,OSale,OrderDate,ODueDate,Oremark) " +
           "values(@NewPid,@NewMid,@NewCount,@NewPrice,@NewSale,@NewOrderDate,DATEADD(DAY, 30, @NewDueDate),@NewRemark)";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@NewPid", 109);
                cmd.Parameters.AddWithValue("@NewMid", GlobalVar.NowLoginID);
                cmd.Parameters.AddWithValue("@NewCount", 1);
                cmd.Parameters.AddWithValue("@NewPrice", 2);
                cmd.Parameters.AddWithValue("@NewSale", 1);
                cmd.Parameters.AddWithValue("@NewOrderDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@NewDueDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@NewRemark", "購物袋");
                cmd.ExecuteNonQuery();
            }
        
            con.Close();
            MessageBox.Show("已完成訂單");
            this.Close();
            FormBuy formBuy = Application.OpenForms["FormBuy"] as FormBuy;
            if (formBuy != null)
            {
                formBuy.Close();
            }
            FormCart formCart = Application.OpenForms["FormCart"] as FormCart;
            if (formCart != null)
            {
                formCart.Close();
            }
        }
        private void butclose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
