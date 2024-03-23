namespace Rwork2
{
    partial class FormSignup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSignup));
            this.butSignup = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbAccount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.butReturn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbPasswordOK = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // butSignup
            // 
            this.butSignup.Location = new System.Drawing.Point(228, 186);
            this.butSignup.Margin = new System.Windows.Forms.Padding(4);
            this.butSignup.Name = "butSignup";
            this.butSignup.Size = new System.Drawing.Size(164, 48);
            this.butSignup.TabIndex = 16;
            this.butSignup.Text = "註冊";
            this.butSignup.UseVisualStyleBackColor = true;
            this.butSignup.Click += new System.EventHandler(this.butSignup_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 125);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 16);
            this.label3.TabIndex = 19;
            this.label3.Text = "密碼";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 88);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "帳號";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(79, 122);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(4);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(313, 24);
            this.tbPassword.TabIndex = 13;
            // 
            // tbAccount
            // 
            this.tbAccount.Location = new System.Drawing.Point(79, 85);
            this.tbAccount.Margin = new System.Windows.Forms.Padding(4);
            this.tbAccount.Name = "tbAccount";
            this.tbAccount.Size = new System.Drawing.Size(313, 24);
            this.tbAccount.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(180, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "註冊";
            // 
            // butReturn
            // 
            this.butReturn.Location = new System.Drawing.Point(19, 186);
            this.butReturn.Margin = new System.Windows.Forms.Padding(4);
            this.butReturn.Name = "butReturn";
            this.butReturn.Size = new System.Drawing.Size(164, 48);
            this.butReturn.TabIndex = 15;
            this.butReturn.Text = "返回";
            this.butReturn.UseVisualStyleBackColor = true;
            this.butReturn.Click += new System.EventHandler(this.butReturn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 51);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "暱稱";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(79, 48);
            this.tbName.Margin = new System.Windows.Forms.Padding(4);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(313, 24);
            this.tbName.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 157);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 16);
            this.label5.TabIndex = 20;
            this.label5.Text = "密碼確認";
            // 
            // tbPasswordOK
            // 
            this.tbPasswordOK.Location = new System.Drawing.Point(79, 154);
            this.tbPasswordOK.Margin = new System.Windows.Forms.Padding(4);
            this.tbPasswordOK.Name = "tbPasswordOK";
            this.tbPasswordOK.Size = new System.Drawing.Size(313, 24);
            this.tbPasswordOK.TabIndex = 14;
            // 
            // FormSignup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 251);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbPasswordOK);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.butReturn);
            this.Controls.Add(this.butSignup);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbAccount);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("萝莉体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormSignup";
            this.Text = "註冊";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSignup_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormSignup_FormClosed);
            this.Load += new System.EventHandler(this.FormSignup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butSignup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbAccount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butReturn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbPasswordOK;
    }
}