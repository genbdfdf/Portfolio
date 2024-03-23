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
    public partial class FormPersonAddAndEdit : Form
    {
        public string EditID = "";
        public List<int> IntlistLevel = new List<int>();
        public FormPersonAddAndEdit()
        {
            InitializeComponent();
        }

        private void FormPersonAddAndEdit_Load(object sender, EventArgs e)
        {
            int x = (SystemInformation.WorkingArea.Width - this.Size.Width) / 2;
            int y = (SystemInformation.WorkingArea.Height - this.Size.Height) / 2;
            StartPosition = FormStartPosition.Manual; //窗體的位置由Location屬性決定
            Location = (Point)new Size(x, y);
            cbLevel.Items.Clear();
            SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
            con.Open();
            string strSQL ="SELECT * FROM PersonLevel order by Lid";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cbLevel.Items.Add(reader["Lname"].ToString());
                IntlistLevel.Add((int)reader["Lid"]);
            }
            cbLevel.SelectedIndex = 0;
            reader.Close();
            strSQL = "SELECT Person.*,PersonLevel.Lname " +
                "from Person join PersonLevel " +
                "on Person.Lid = PersonLevel.Lid " +
                "WHERE Pid =  @SearchID";
            cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@SearchID", EditID);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                tbId.Text = reader["Pid"].ToString();
                cbLevel.Text = reader["Lname"].ToString();
                tbName.Text = reader["Pname"].ToString();
                tbPhone.Text = reader["Phone"].ToString();
                tbAccount.Text = reader["Account"].ToString();
                tbPassword.Text = reader["Password"].ToString();
            }
            reader.Close();
            con.Close();
        }

        private void butComplete_Click(object sender, EventArgs e)
        {
            if (GlobalVar.NowLoginclass==4)
            {
                Revise();
            }
            else
            {
                if (cbLevel.SelectedIndex == 5)
                {
                    MessageBox.Show("權限不足");
                }
                else
                {
                    Revise();
                }
            }
        }
        void Revise()
        {
            if (tbName.Text != "" && tbAccount.Text != "" && tbPassword.Text != "")
            {
                SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
                con.Open();
                if (int.TryParse(tbId.Text, out int ID))
                {
                    string strSQL =
                       "update Member set Pid=@NewPid, Pname = @NewName,Phone= @NewPhone, Account = @NewAccount, Password = @NewPassword where Pid = @SearchID";
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    cmd.Parameters.AddWithValue("@NewPid", IntlistLevel[cbLevel.SelectedIndex]);
                    cmd.Parameters.AddWithValue("@NewName", tbName.Text);
                    cmd.Parameters.AddWithValue("@NewPhone", tbPhone.Text);
                    cmd.Parameters.AddWithValue("@NewAccount", tbAccount.Text);
                    cmd.Parameters.AddWithValue("@NewPassword", tbPassword.Text);
                    cmd.Parameters.AddWithValue("@SearchID", ID);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                else
                {
                    string strSQL =
                    "insert into Member values(@NewPid,@NewName,@NewPhone,@NewAccount,@NewPassword)";
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    cmd.Parameters.AddWithValue("@NewPid", IntlistLevel[cbLevel.SelectedIndex]);
                    cmd.Parameters.AddWithValue("@NewName", tbName.Text);
                    cmd.Parameters.AddWithValue("@NewPhone", tbPhone.Text);
                    cmd.Parameters.AddWithValue("@NewAccount", tbAccount.Text);
                    cmd.Parameters.AddWithValue("@NewPassword", tbPassword.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                Close();
                FormSystem formSystem = Application.OpenForms["FormSystem"] as FormSystem;
                if (formSystem != null)
                {
                    formSystem.initMemberListView();
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
