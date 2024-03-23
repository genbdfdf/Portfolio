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
    public partial class FormSystem : Form
    {
        List<string> SearchMemberlist = new List<string>()
        { "Pid", "Lname", "Pname", "Phone", "Account", "Password" };
        public FormSystem()
        {
            InitializeComponent();
        }

        private void FormSystem_Load(object sender, EventArgs e)
        {
            int x = (SystemInformation.WorkingArea.Width - this.Size.Width) / 2;
            int y = (SystemInformation.WorkingArea.Height - this.Size.Height) / 2;
            StartPosition = FormStartPosition.Manual; //窗體的位置由Location屬性決定
            Location = (Point)new Size(x, y);
            initMemberListView();
            cbSearchPerson.Items.Clear();
            cbSearchPerson.Items.Add("ID");
            cbSearchPerson.Items.Add("等級");
            cbSearchPerson.Items.Add("姓名");
            cbSearchPerson.Items.Add("電話");
            cbSearchPerson.Items.Add("帳號");
            cbSearchPerson.Items.Add("密碼");
            cbSearchPerson.SelectedIndex = 0;
        }

        private void butSearchPerson_Click(object sender, EventArgs e)
        {
            if (tbSearchPerson.Text != "")
            {
                initlvMember();
                lvPerson.BeginUpdate();
                SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
                con.Open();
                string strSQL =
                       "SELECT Person.*,PersonLevel.Lname " +
                       "from Person join PersonLevel " +
                       "on Person.Lid = PersonLevel.Lid " +
                       "WHERE " + SearchMemberlist[cbSearchPerson.SelectedIndex] + " LIKE  @SearchKeyWord;";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@SearchKeyWord", "%" + tbSearchPerson.Text + "%");
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.Text = "口";
                    listViewItem.SubItems.Add(reader["Pid"].ToString());
                    listViewItem.SubItems.Add(reader["Lname"].ToString());
                    listViewItem.SubItems.Add(reader["Pname"].ToString());
                    listViewItem.SubItems.Add(reader["Phone"].ToString());
                    listViewItem.SubItems.Add(reader["Account"].ToString());
                    listViewItem.SubItems.Add(reader["Password"].ToString());
                    lvPerson.Items.Add(listViewItem);
                }
                reader.Close();
                con.Close();
                lvPerson.EndUpdate();
            }
            else
            {
                MessageBox.Show("請輸入搜尋文字");
            }
        }

        private void butSearchPersonClear_Click(object sender, EventArgs e)
        {
            initMemberListView();
        }

        private void butAddPerson_Click(object sender, EventArgs e)
        {
            if (GlobalVar.NowLoginclass >= 3)
            {
                FormPersonAddAndEdit formPersonAddAndEdit = new FormPersonAddAndEdit();
                formPersonAddAndEdit.ShowDialog();
            }
            else
            {
                MessageBox.Show("權限不足");
            }
        }

        private void butEditPerson_Click(object sender, EventArgs e)
        {
            if (lvPerson.SelectedIndices.Count > 0)
            {
                if (GlobalVar.NowLoginclass>=3)
                {
                    FormPersonAddAndEdit formPersonAddAndEdit = new FormPersonAddAndEdit();
                    formPersonAddAndEdit.EditID = lvPerson.Items[lvPerson.SelectedIndices[0]].SubItems[1].Text;
                    formPersonAddAndEdit.ShowDialog();
                }
                else
                {
                    MessageBox.Show("權限不足");
                }
            }
            else
            {
                MessageBox.Show("請勾選修改項目");
            }
        }
        private void tabSystem_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabSystem.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    tabSystem.SelectedIndex = 0;
                    MessageBox.Show("暫無功能");
                    break;
            }
        }
        private void FormSystem_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void FormSystem_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.formMain.Show();
        }
        public void initlvMember()
        {
            lvPerson.Clear();
            lvPerson.Columns.Add("選擇", 50, HorizontalAlignment.Center);
            lvPerson.Columns.Add("ID", 50, HorizontalAlignment.Center);
            lvPerson.Columns.Add("等級", 100, HorizontalAlignment.Center);
            lvPerson.Columns.Add("姓名", 130, HorizontalAlignment.Center);
            lvPerson.Columns.Add("電話", 100, HorizontalAlignment.Center);
            lvPerson.Columns.Add("帳號", 100, HorizontalAlignment.Center);
            lvPerson.Columns.Add("密碼", 100, HorizontalAlignment.Center);
        }

        public void initMemberListView()
        {
            initlvMember();
            lvPerson.BeginUpdate();
            SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
            con.Open();
            string strSQL =
                "SELECT Person.*,PersonLevel.Lname " +
                "from Person join PersonLevel " +
                "on Person.Lid = PersonLevel.Lid ";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = "口";
                listViewItem.SubItems.Add(reader["Pid"].ToString());
                listViewItem.SubItems.Add(reader["Lname"].ToString());
                listViewItem.SubItems.Add(reader["Pname"].ToString());
                listViewItem.SubItems.Add(reader["Phone"].ToString());
                listViewItem.SubItems.Add(reader["Account"].ToString());
                listViewItem.SubItems.Add(reader["Password"].ToString());
                lvPerson.Items.Add(listViewItem);
            }
            reader.Close();
            con.Close();
            lvPerson.EndUpdate();
        }

        private void lvPerson_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvPerson.Items)
            {
                item.Text = "口";
            }
            if (lvPerson.SelectedIndices.Count > 0)
            {
                lvPerson.Items[lvPerson.SelectedIndices[0]].Text = "☑";
            }
        }
    }
}
