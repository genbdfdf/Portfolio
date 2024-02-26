namespace Rwork2
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.butBuy = new System.Windows.Forms.Button();
            this.lbMemberName = new System.Windows.Forms.Label();
            this.butProduct = new System.Windows.Forms.Button();
            this.butOrder = new System.Windows.Forms.Button();
            this.butMember = new System.Windows.Forms.Button();
            this.butSystem = new System.Windows.Forms.Button();
            this.butLogout = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // butBuy
            // 
            this.butBuy.Font = new System.Drawing.Font("萝莉体", 20F);
            this.butBuy.Location = new System.Drawing.Point(12, 98);
            this.butBuy.Name = "butBuy";
            this.butBuy.Size = new System.Drawing.Size(200, 100);
            this.butBuy.TabIndex = 0;
            this.butBuy.Text = "訂購系統";
            this.butBuy.UseVisualStyleBackColor = true;
            this.butBuy.Click += new System.EventHandler(this.butBuy_Click);
            // 
            // lbMemberName
            // 
            this.lbMemberName.AutoSize = true;
            this.lbMemberName.Font = new System.Drawing.Font("萝莉体", 20F);
            this.lbMemberName.Location = new System.Drawing.Point(281, 20);
            this.lbMemberName.Name = "lbMemberName";
            this.lbMemberName.Size = new System.Drawing.Size(129, 37);
            this.lbMemberName.TabIndex = 1;
            this.lbMemberName.Text = "會員名稱";
            // 
            // butProduct
            // 
            this.butProduct.Font = new System.Drawing.Font("萝莉体", 20F);
            this.butProduct.Location = new System.Drawing.Point(243, 98);
            this.butProduct.Name = "butProduct";
            this.butProduct.Size = new System.Drawing.Size(200, 100);
            this.butProduct.TabIndex = 2;
            this.butProduct.Text = "商品管理";
            this.butProduct.UseVisualStyleBackColor = true;
            this.butProduct.Click += new System.EventHandler(this.butProduct_Click);
            // 
            // butOrder
            // 
            this.butOrder.Font = new System.Drawing.Font("萝莉体", 20F);
            this.butOrder.Location = new System.Drawing.Point(472, 98);
            this.butOrder.Name = "butOrder";
            this.butOrder.Size = new System.Drawing.Size(200, 100);
            this.butOrder.TabIndex = 3;
            this.butOrder.Text = "訂單管理";
            this.butOrder.UseVisualStyleBackColor = true;
            this.butOrder.Click += new System.EventHandler(this.butOrder_Click);
            // 
            // butMember
            // 
            this.butMember.Font = new System.Drawing.Font("萝莉体", 20F);
            this.butMember.Location = new System.Drawing.Point(12, 204);
            this.butMember.Name = "butMember";
            this.butMember.Size = new System.Drawing.Size(200, 100);
            this.butMember.TabIndex = 4;
            this.butMember.Text = "會員管理";
            this.butMember.UseVisualStyleBackColor = true;
            this.butMember.Click += new System.EventHandler(this.butMember_Click);
            // 
            // butSystem
            // 
            this.butSystem.Font = new System.Drawing.Font("萝莉体", 20F);
            this.butSystem.Location = new System.Drawing.Point(243, 204);
            this.butSystem.Name = "butSystem";
            this.butSystem.Size = new System.Drawing.Size(200, 100);
            this.butSystem.TabIndex = 5;
            this.butSystem.Text = "系統管理";
            this.butSystem.UseVisualStyleBackColor = true;
            this.butSystem.Click += new System.EventHandler(this.butSystem_Click);
            // 
            // butLogout
            // 
            this.butLogout.Font = new System.Drawing.Font("萝莉体", 20F);
            this.butLogout.Location = new System.Drawing.Point(472, 204);
            this.butLogout.Name = "butLogout";
            this.butLogout.Size = new System.Drawing.Size(200, 100);
            this.butLogout.TabIndex = 6;
            this.butLogout.Text = "登出";
            this.butLogout.UseVisualStyleBackColor = true;
            this.butLogout.Click += new System.EventHandler(this.butLogout_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("萝莉体", 20F);
            this.label1.Location = new System.Drawing.Point(76, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 37);
            this.label1.TabIndex = 7;
            this.label1.Text = "歡迎";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("萝莉体", 20F);
            this.label2.Location = new System.Drawing.Point(544, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 37);
            this.label2.TabIndex = 8;
            this.label2.Text = "使用";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 326);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butLogout);
            this.Controls.Add(this.butSystem);
            this.Controls.Add(this.butMember);
            this.Controls.Add(this.butOrder);
            this.Controls.Add(this.butProduct);
            this.Controls.Add(this.lbMemberName);
            this.Controls.Add(this.butBuy);
            this.Font = new System.Drawing.Font("萝莉体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "系統主選單";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butBuy;
        private System.Windows.Forms.Label lbMemberName;
        private System.Windows.Forms.Button butProduct;
        private System.Windows.Forms.Button butOrder;
        private System.Windows.Forms.Button butMember;
        private System.Windows.Forms.Button butSystem;
        private System.Windows.Forms.Button butLogout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}