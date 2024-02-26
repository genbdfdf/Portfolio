using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Rwork2
{
    public partial class FormMain : Form
    {
        bool isclose = false;
        public FormMain()
        {
            InitializeComponent();
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            int x = (SystemInformation.WorkingArea.Width - this.Size.Width) / 2;
            int y = (SystemInformation.WorkingArea.Height - this.Size.Height) / 2;
            StartPosition = FormStartPosition.Manual; //窗體的位置由Location屬性決定
            Location = (Point)new Size(x, y);
            //-1不存在,0非會員，1會員，2員工，3主管，4老闆
            lbMemberName.Text = GlobalVar.NowLoginName;
            lbMemberName.Location = new Point(Width / 2 - lbMemberName.Text.Length * 20, lbMemberName.Location.Y);
            switch (GlobalVar.NowLoginclass)
            {
                case 0:
                    butBuy.Text = "訂購系統";
                    butBuy.Visible = true;
                    butProduct.Visible = false;
                    butOrder.Visible = false;
                    butMember.Visible = false;
                    butSystem.Visible = false;
                    butLogout.Visible = true;
                    break;
                case 1:
                    butBuy.Text = "訂購系統";
                    butBuy.Visible = true;
                    butProduct.Visible = false;
                    butOrder.Visible = false;
                    butMember.Visible = false;
                    butSystem.Visible = false;
                    butLogout.Visible = true;
                    break;
                case 2:
                    butBuy.Text = "進貨系統";
                    butBuy.Visible = true;
                    butProduct.Visible = true;
                    butOrder.Visible = true;
                    butMember.Visible = false;
                    butSystem.Visible = false;
                    butLogout.Visible = true;
                    break;
                case 3:
                    butBuy.Text = "進貨系統";
                    butBuy.Visible = true;
                    butProduct.Visible = true;
                    butOrder.Visible = true;
                    butMember.Visible = true;
                    butSystem.Visible = true;
                    butLogout.Visible = true;
                    break;
                case 4:
                    butBuy.Text = "進貨系統";
                    butBuy.Visible = true;
                    butProduct.Visible = true;
                    butOrder.Visible = true;
                    butMember.Visible = true;
                    butSystem.Visible = true;
                    butLogout.Visible = true;
                    break;
                default:
                    MessageBox.Show("不存在會員出現程式即將關閉");
                    Close();
                    break;
            }
        }

        private void butBuy_Click(object sender, EventArgs e)
        {
            //-1不存在,0非會員，1會員，2員工，3主管，4老闆
            if (GlobalVar.NowLoginclass>=2)
            {
                FormPurchase formpurchase = new FormPurchase();
                formpurchase.Show();
                this.Hide();
            }
            else
            {
                FormBuy formBuy = new FormBuy();
                formBuy.Show();
                this.Hide();
            }
        }

        private void butProduct_Click(object sender, EventArgs e)
        {
            FormProduct formProduct = new FormProduct();
            formProduct.Show();
            this.Hide();
        }

        private void butOrder_Click(object sender, EventArgs e)
        {
            FormOrder formOrder = new FormOrder();
            formOrder.Show();
            this.Hide();
        }

        private void butMember_Click(object sender, EventArgs e)
        {
            FormMember formMember = new FormMember();
            formMember.Show();
            this.Hide();
        }

        private void butSystem_Click(object sender, EventArgs e)
        {
            FormSystem formSystem = new FormSystem();
            formSystem.Show();
            this.Hide();
        }

        private void butLogout_Click(object sender, EventArgs e)
        {
            GlobalVar.NowLoginID = "";
            GlobalVar.NowLoginName = "";
            GlobalVar.NowLoginclass = -1;
            isclose = true;
            Close();
        }
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isclose)
            {
                Program.formLogin.Show();
            }
            else
            {
                Program.formLogin.Close();
            }
        }

    }
}
