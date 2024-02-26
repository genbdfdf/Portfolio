namespace Rwork2
{
    partial class FormBuy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBuy));
            this.label1 = new System.Windows.Forms.Label();
            this.lbMemberName = new System.Windows.Forms.Label();
            this.lvbuy = new System.Windows.Forms.ListView();
            this.butAddCart = new System.Windows.Forms.Button();
            this.butViewCart = new System.Windows.Forms.Button();
            this.butCheckout = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbBuycount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbtotalPrice = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("萝莉体", 20F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "會員：";
            // 
            // lbMemberName
            // 
            this.lbMemberName.AutoSize = true;
            this.lbMemberName.Font = new System.Drawing.Font("萝莉体", 20F);
            this.lbMemberName.Location = new System.Drawing.Point(119, 9);
            this.lbMemberName.Name = "lbMemberName";
            this.lbMemberName.Size = new System.Drawing.Size(101, 37);
            this.lbMemberName.TabIndex = 1;
            this.lbMemberName.Text = "會員名";
            // 
            // lvbuy
            // 
            this.lvbuy.HideSelection = false;
            this.lvbuy.Location = new System.Drawing.Point(19, 49);
            this.lvbuy.MultiSelect = false;
            this.lvbuy.Name = "lvbuy";
            this.lvbuy.Size = new System.Drawing.Size(653, 207);
            this.lvbuy.TabIndex = 3;
            this.lvbuy.UseCompatibleStateImageBehavior = false;
            this.lvbuy.View = System.Windows.Forms.View.Details;
            this.lvbuy.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.lvbuy_ColumnWidthChanging);
            this.lvbuy.SelectedIndexChanged += new System.EventHandler(this.lvbuy_SelectedIndexChanged);
            // 
            // butAddCart
            // 
            this.butAddCart.Font = new System.Drawing.Font("萝莉体", 12F);
            this.butAddCart.Location = new System.Drawing.Point(300, 265);
            this.butAddCart.Name = "butAddCart";
            this.butAddCart.Size = new System.Drawing.Size(120, 52);
            this.butAddCart.TabIndex = 4;
            this.butAddCart.Text = "加進購物車";
            this.butAddCart.UseVisualStyleBackColor = true;
            this.butAddCart.Click += new System.EventHandler(this.butAddCart_Click);
            // 
            // butViewCart
            // 
            this.butViewCart.Font = new System.Drawing.Font("萝莉体", 12F);
            this.butViewCart.Location = new System.Drawing.Point(426, 265);
            this.butViewCart.Name = "butViewCart";
            this.butViewCart.Size = new System.Drawing.Size(120, 52);
            this.butViewCart.TabIndex = 5;
            this.butViewCart.Text = "查看購物車";
            this.butViewCart.UseVisualStyleBackColor = true;
            this.butViewCart.Click += new System.EventHandler(this.butViewCart_Click);
            // 
            // butCheckout
            // 
            this.butCheckout.Font = new System.Drawing.Font("萝莉体", 12F);
            this.butCheckout.Location = new System.Drawing.Point(552, 265);
            this.butCheckout.Name = "butCheckout";
            this.butCheckout.Size = new System.Drawing.Size(120, 52);
            this.butCheckout.TabIndex = 6;
            this.butCheckout.Text = "結帳";
            this.butCheckout.UseVisualStyleBackColor = true;
            this.butCheckout.Click += new System.EventHandler(this.butCheckout_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("萝莉体", 20F);
            this.label2.Location = new System.Drawing.Point(12, 269);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 37);
            this.label2.TabIndex = 7;
            this.label2.Text = "買";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("萝莉体", 20F);
            this.label3.Location = new System.Drawing.Point(205, 269);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 37);
            this.label3.TabIndex = 8;
            this.label3.Text = "個";
            // 
            // tbBuycount
            // 
            this.tbBuycount.Font = new System.Drawing.Font("萝莉体", 20F);
            this.tbBuycount.Location = new System.Drawing.Point(63, 266);
            this.tbBuycount.MaxLength = 5;
            this.tbBuycount.Name = "tbBuycount";
            this.tbBuycount.Size = new System.Drawing.Size(136, 44);
            this.tbBuycount.TabIndex = 9;
            this.tbBuycount.Text = "1";
            this.tbBuycount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("萝莉体", 20F);
            this.label4.Location = new System.Drawing.Point(305, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 37);
            this.label4.TabIndex = 10;
            this.label4.Text = "總價：";
            // 
            // lbtotalPrice
            // 
            this.lbtotalPrice.AutoSize = true;
            this.lbtotalPrice.Font = new System.Drawing.Font("萝莉体", 20F);
            this.lbtotalPrice.Location = new System.Drawing.Point(412, 9);
            this.lbtotalPrice.Name = "lbtotalPrice";
            this.lbtotalPrice.Size = new System.Drawing.Size(209, 37);
            this.lbtotalPrice.TabIndex = 11;
            this.lbtotalPrice.Text = "000000000000";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("萝莉体", 20F);
            this.label6.Location = new System.Drawing.Point(627, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 37);
            this.label6.TabIndex = 12;
            this.label6.Text = "元";
            // 
            // FormBuy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 326);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbtotalPrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbBuycount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.butCheckout);
            this.Controls.Add(this.butViewCart);
            this.Controls.Add(this.butAddCart);
            this.Controls.Add(this.lvbuy);
            this.Controls.Add(this.lbMemberName);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("萝莉体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FormBuy";
            this.Text = "訂購系統";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormBuy_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormBuy_FormClosed);
            this.Load += new System.EventHandler(this.FormBuy_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbMemberName;
        private System.Windows.Forms.ListView lvbuy;
        private System.Windows.Forms.Button butAddCart;
        private System.Windows.Forms.Button butViewCart;
        private System.Windows.Forms.Button butCheckout;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbBuycount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbtotalPrice;
        private System.Windows.Forms.Label label6;
    }
}