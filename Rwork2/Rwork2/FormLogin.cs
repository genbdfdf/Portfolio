using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Rwork2
{
    public partial class FormLogin : Form
    {

        public FormLogin()
        {
            InitializeComponent();
        }
        private void FormLogin_Load(object sender, EventArgs e)
        {
            //老闆帳號: 101二君
            //老闆密碼:二君1234君1234
            //經理帳號:102A君帳
            //經理帳號:君1234
            //員工帳號:105D君帳
            //員工帳號:D君1234
            //(最高級顧客)野比海皇帳號: god
            //(最高級顧客)野比海皇密碼: god1234
            //(高級顧客)帳號: 101二君1
            //(高級顧客)密碼: 二君1234君1234
            int x = (SystemInformation.WorkingArea.Width - this.Size.Width) / 2;
            int y = (SystemInformation.WorkingArea.Height - this.Size.Height) / 2;
            StartPosition = FormStartPosition.Manual; //窗體的位置由Location屬性決定
            Location = (Point)new Size(x, y);
            FormStart formStart = new FormStart();
            formStart.ShowDialog();
        }
        private void butLogin_Click(object sender, EventArgs e)
        {
             
            if (tbAccount.Text != "" && tbPassword.Text != "")
            {
                SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
                con.Open();
                string strSQL = "select * from Member where Account= @SearchAccount and Password= @SearchPassword";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@SearchAccount", tbAccount.Text);
                cmd.Parameters.AddWithValue("@SearchPassword", tbPassword.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    //為顧客
                    GlobalVar.NowLoginID = reader["Mid"].ToString();
                    GlobalVar.NowLoginName = reader["Mname"].ToString();
                    GlobalVar.NowLoginclass = 1;//-1不存在,0非會員，1會員，2員工，3主管，4老闆
                    GlobalVar.NowLoginMemberLevel = (int)reader["Lid"];//-1不存在,0非會員，1普通會員，2好一點會員，3不錯的會員，4真會員，5神會員，6真神級會員，7停權
                    if (GlobalVar.NowLoginMemberLevel == 7)
                    {
                        GlobalVar.NowLoginclass = -1;//-1不存在,0非會員，1會員，2員工，3主管，4老闆
                    }
                    Program.formMain = new FormMain();
                    Program.formMain.Show();
                    this.Hide();
                    reader.Close();
                    con.Close();
                }
                else
                {
                    reader.Close();
                    strSQL = "select * from Person where Account= @SearchAccount and Password= @SearchPassword";
                    cmd = new SqlCommand(strSQL, con);
                    cmd.Parameters.AddWithValue("@SearchAccount", tbAccount.Text);
                    cmd.Parameters.AddWithValue("@SearchPassword", tbPassword.Text);
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        //為員工
                        GlobalVar.NowLoginID = reader["Pid"].ToString();
                        GlobalVar.NowLoginName = reader["Pname"].ToString();
                        int level = (int)reader["Lid"];
                        GlobalVar.NowLoginclass = 3;//-1不存在,0非會員，1會員，2員工，3主管，4老闆
                        if (level == 1)
                        {
                            GlobalVar.NowLoginclass = 2;//-1不存在,0非會員，1會員，2員工，3主管，4老闆
                        }
                        else if (level == 6)
                        {
                            GlobalVar.NowLoginclass = 4; //-1不存在,0非會員，1會員，2員工，3主管，4老闆
                        }
                        else if (level == 7)
                        {
                            GlobalVar.NowLoginclass = -1;//-1不存在,0非會員，1會員，2員工，3主管，4老闆
                        }
                        Program.formMain = new FormMain();
                        Program.formMain.Show();
                        this.Hide();
                        reader.Close();
                        con.Close();
                    }
                    else
                    {
                        reader.Close();
                        con.Close();
                        MessageBox.Show("帳號密碼錯誤");
                    }
                }
            }
            else
            {
                MessageBox.Show("帳號密碼請勿空白");
            }
        }

        private void butGuestLogin_Click(object sender, EventArgs e)
        {
            GlobalVar.NowLoginID = "0000";
            GlobalVar.NowLoginName = "訪客";
            GlobalVar.NowLoginclass = 0;//-1不存在,0非會員，1會員，2員工，3主管，4老闆
            GlobalVar.NowLoginMemberLevel = 0;//-1不存在,0非會員，1普通會員，2好一點會員，3不錯的會員，4真會員，5神會員，6真神級會員，7停權
            Program.formMain = new FormMain();
            Program.formMain.Show();
            this.Hide();
        }

        private void butSignup_Click(object sender, EventArgs e)
        {
            FormSignup formSignup = new FormSignup();
            formSignup.Show();
            this.Hide();
        }

        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}