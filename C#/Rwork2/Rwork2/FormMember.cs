using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rwork2
{
    public partial class FormMember : Form
    {
        List<string> SearchMemberlist = new List<string>()
        { "Mid", "Lname", "Mname", "Account", "Password" };
        public FormMember()
        {
            InitializeComponent();
        }
        private void FormMember_Load(object sender, EventArgs e)
        {
            int x = (SystemInformation.WorkingArea.Width - this.Size.Width) / 2;
            int y = (SystemInformation.WorkingArea.Height - this.Size.Height) / 2;
            StartPosition = FormStartPosition.Manual; //窗體的位置由Location屬性決定
            Location = (Point)new Size(x, y);
            initMemberListView();
            cbSearchMember.Items.Clear();
            cbSearchMember.Items.Add("ID");
            cbSearchMember.Items.Add("等級");
            cbSearchMember.Items.Add("暱稱");
            cbSearchMember.Items.Add("帳號");
            cbSearchMember.Items.Add("密碼");
            cbSearchMember.SelectedIndex = 0;
        }

        private void butSearchMember_Click(object sender, EventArgs e)
        {
            if (tbSearchMember.Text != "")
            {
                initlvMember();
                lvMember.BeginUpdate();
                SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
                con.Open();
                string strSQL =
                       "SELECT Member.*,MemberLevel.Lname "+
                       "from Member join MemberLevel " +
                       "on Member.Lid = MemberLevel.Lid " +
                       "WHERE " + SearchMemberlist[cbSearchMember.SelectedIndex] + " LIKE  @SearchKeyWord;";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@SearchKeyWord", "%" + tbSearchMember.Text + "%");
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.Text = "口";
                    listViewItem.SubItems.Add(reader["Mid"].ToString());
                    listViewItem.SubItems.Add(reader["Lname"].ToString());
                    listViewItem.SubItems.Add(reader["Mname"].ToString());
                    listViewItem.SubItems.Add(reader["Account"].ToString());
                    listViewItem.SubItems.Add(reader["Password"].ToString());
                    lvMember.Items.Add(listViewItem);
                }
                reader.Close();
                con.Close();
                lvMember.EndUpdate();
            }
            else
            {
                MessageBox.Show("請輸入搜尋文字");
            }
        }

        private void butSearchMemberClear_Click(object sender, EventArgs e)
        {
            initMemberListView();
        }

        private void butEditMember_Click(object sender, EventArgs e)
        {
            if (lvMember.SelectedIndices.Count > 0)
            {
                FormMemberEdit formMemberEdit = new FormMemberEdit();
                formMemberEdit.EditID = lvMember.Items[lvMember.SelectedIndices[0]].SubItems[1].Text;
                formMemberEdit.ShowDialog();
            }
            else
            {
                MessageBox.Show("請勾選修改項目");
            }
        }
        private void FormMember_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void FormMember_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.formMain.Show();
        }

        public void initlvMember()
        {
            lvMember.Clear();
            lvMember.Columns.Add("選擇", 50, HorizontalAlignment.Center);
            lvMember.Columns.Add("ID", 50, HorizontalAlignment.Center);
            lvMember.Columns.Add("等級", 100, HorizontalAlignment.Center);
            lvMember.Columns.Add("暱稱", 200, HorizontalAlignment.Center);
            lvMember.Columns.Add("帳號", 100, HorizontalAlignment.Center);
            lvMember.Columns.Add("密碼", 100, HorizontalAlignment.Center);
        }

        public void initMemberListView()
        {
            initlvMember();
            lvMember.BeginUpdate();
            SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
            con.Open();
            string strSQL =
                "SELECT Member.*,MemberLevel.Lname " +
                "from Member join MemberLevel " +
                "on Member.Lid = MemberLevel.Lid";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = "口";
                listViewItem.SubItems.Add(reader["Mid"].ToString());
                listViewItem.SubItems.Add(reader["Lname"].ToString());
                listViewItem.SubItems.Add(reader["Mname"].ToString());
                listViewItem.SubItems.Add(reader["Account"].ToString());
                listViewItem.SubItems.Add(reader["Password"].ToString());
                lvMember.Items.Add(listViewItem);
            }
            reader.Close();
            con.Close();
            lvMember.EndUpdate();
        }

        private void lvMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvMember.Items)
            {
                item.Text = "口";
            }
            if (lvMember.SelectedIndices.Count > 0)
            {
                lvMember.Items[lvMember.SelectedIndices[0]].Text = "☑";
            }
        }
    }
}
