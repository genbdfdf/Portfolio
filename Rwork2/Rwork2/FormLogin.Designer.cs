namespace Rwork2
{
    partial class FormLogin
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.butLogin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbAccount = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.butGuestLogin = new System.Windows.Forms.Button();
            this.butSignup = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // butLogin
            // 
            this.butLogin.Location = new System.Drawing.Point(12, 190);
            this.butLogin.Name = "butLogin";
            this.butLogin.Size = new System.Drawing.Size(379, 36);
            this.butLogin.TabIndex = 0;
            this.butLogin.Text = "登入";
            this.butLogin.UseVisualStyleBackColor = true;
            this.butLogin.Click += new System.EventHandler(this.butLogin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(165, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "登入";
            // 
            // tbAccount
            // 
            this.tbAccount.Location = new System.Drawing.Point(78, 48);
            this.tbAccount.Name = "tbAccount";
            this.tbAccount.Size = new System.Drawing.Size(313, 24);
            this.tbAccount.TabIndex = 2;
            this.tbAccount.Text = "101二君";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(78, 96);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(313, 24);
            this.tbPassword.TabIndex = 3;
            this.tbPassword.Text = "二君1234君1234";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "帳號";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "密碼";
            // 
            // butGuestLogin
            // 
            this.butGuestLogin.Location = new System.Drawing.Point(207, 145);
            this.butGuestLogin.Name = "butGuestLogin";
            this.butGuestLogin.Size = new System.Drawing.Size(184, 36);
            this.butGuestLogin.TabIndex = 8;
            this.butGuestLogin.Text = "遊客登入";
            this.butGuestLogin.UseVisualStyleBackColor = true;
            this.butGuestLogin.Click += new System.EventHandler(this.butGuestLogin_Click);
            // 
            // butSignup
            // 
            this.butSignup.Location = new System.Drawing.Point(12, 145);
            this.butSignup.Name = "butSignup";
            this.butSignup.Size = new System.Drawing.Size(184, 36);
            this.butSignup.TabIndex = 7;
            this.butSignup.Text = "註冊";
            this.butSignup.UseVisualStyleBackColor = true;
            this.butSignup.Click += new System.EventHandler(this.butSignup_Click);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 238);
            this.Controls.Add(this.butSignup);
            this.Controls.Add(this.butGuestLogin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbAccount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butLogin);
            this.Font = new System.Drawing.Font("萝莉体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FormLogin";
            this.Text = "二君股份有限公司高雄區紅豆餅販賣中心";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormLogin_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormLogin_FormClosed);
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbAccount;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button butGuestLogin;
        private System.Windows.Forms.Button butSignup;
    }
}

