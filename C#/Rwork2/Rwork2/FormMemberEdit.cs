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
using System.Windows.Forms;

namespace Rwork2
{
    public partial class FormMemberEdit : Form
    {
        public string EditID = "";
        public List<int> IntlistLevel = new List<int>();
        public FormMemberEdit()
        {
            InitializeComponent();
        }

        private void FormMemberEdit_Load(object sender, EventArgs e)
        {
            int x = (SystemInformation.WorkingArea.Width - this.Size.Width) / 2;
            int y = (SystemInformation.WorkingArea.Height - this.Size.Height) / 2;
            StartPosition = FormStartPosition.Manual; //窗體的位置由Location屬性決定
            Location = (Point)new Size(x, y);
            cbLevel.Items.Clear();
            SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
            con.Open();
            string strSQL =
                "SELECT * FROM MemberLevel order by Lid";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cbLevel.Items.Add(reader["Lname"].ToString());
                IntlistLevel.Add((int)reader["Lid"]);
            }
            cbLevel.SelectedIndex = 0;
            reader.Close();
            strSQL = "SELECT Member.*,MemberLevel.Lname " +
                "from Member join MemberLevel " +
                "on Member.Lid = MemberLevel.Lid " +
                "WHERE Mid =  @SearchID";
            cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@SearchID", EditID);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                tbId.Text = reader["Mid"].ToString();
                cbLevel.Text = reader["Lname"].ToString();
                tbName.Text = reader["Mname"].ToString();
                tbAccount.Text = reader["Account"].ToString();
                tbPassword.Text = reader["Password"].ToString();
            }
            reader.Close();
            con.Close();
        }

        private void butComplete_Click(object sender, EventArgs e)
        {
            if (tbName.Text != "" && tbAccount.Text != "" && tbPassword.Text != "")
            {
                SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
                con.Open();
                if (int.TryParse(tbId.Text, out int ID))
                {
                    string strSQL =
                       "update Member set Lid=@NewLid, Mname = @NewName, Account = @NewAccount, Password = @NewPassword where Pid = @SearchID";
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    cmd.Parameters.AddWithValue("@NewLid", IntlistLevel[cbLevel.SelectedIndex]);
                    cmd.Parameters.AddWithValue("@NewName", tbName.Text);
                    cmd.Parameters.AddWithValue("@NewAccount", tbAccount.Text);
                    cmd.Parameters.AddWithValue("@NewPassword", tbPassword.Text);
                    cmd.Parameters.AddWithValue("@SearchID", ID);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                else
                {
                    string strSQL =
                    "insert into Member values(@NewLid,@NewName,@NewAccount,@NewPassword)";
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    cmd.Parameters.AddWithValue("@NewLid", IntlistLevel[cbLevel.SelectedIndex]);
                    cmd.Parameters.AddWithValue("@NewName", tbName.Text);
                    cmd.Parameters.AddWithValue("@NewAccount", tbAccount.Text);
                    cmd.Parameters.AddWithValue("@NewPassword", tbPassword.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                Close();
                FormMember formMember = Application.OpenForms["FormMember"] as FormMember;
                if (formMember != null)
                {
                    formMember.initMemberListView();
                }
            }
            else MessageBox.Show("請勿空白");
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
