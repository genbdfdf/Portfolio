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
    public partial class FormSignup : Form
    {
        public FormSignup()
        {
            InitializeComponent();
        }

        private void FormSignup_Load(object sender, EventArgs e)
        {
            int x = (SystemInformation.WorkingArea.Width - this.Size.Width) / 2;
            int y = (SystemInformation.WorkingArea.Height - this.Size.Height) / 2;
            StartPosition = FormStartPosition.Manual; //窗體的位置由Location屬性決定
            Location = (Point)new Size(x, y);
        }

        private void butSignup_Click(object sender, EventArgs e)
        {
            if (tbName.Text != "" && tbAccount.Text != "" && tbPassword.Text != "" &&  tbPasswordOK.Text != "")
            {
                if (tbPassword.Text== tbPasswordOK.Text)
                {
                    SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
                    con.Open();

                    string strSQL = "select * from Member where Mname= @SearchName or Account= @SearchAccount";
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    cmd.Parameters.AddWithValue("@SearchName", tbName.Text);
                    cmd.Parameters.AddWithValue("@SearchAccount", tbAccount.Text);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (!reader.Read())
                    {
                        reader.Close();
                        strSQL = "insert into Member values(1,@SearchName,@SearchAccount,@SearchPassword)";
                        cmd = new SqlCommand(strSQL, con);
                        cmd.Parameters.AddWithValue("@SearchName", tbName.Text);
                        cmd.Parameters.AddWithValue("@SearchAccount", tbAccount.Text);
                        cmd.Parameters.AddWithValue("@SearchPassword", tbPassword.Text);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        Close();
                    }
                    else
                    {
                        reader.Close();
                        con.Close();
                        MessageBox.Show("帳號密碼重複");
                    }
                }
                else
                {
                    MessageBox.Show("確認密碼輸入錯誤");
                }              
            }
            else
            {
                MessageBox.Show("請輸入完整資料");
            }
        }

        private void butReturn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormSignup_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void FormSignup_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.formLogin.Show();
        }
    }
}
