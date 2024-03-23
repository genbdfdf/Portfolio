namespace Rwork2
{
    partial class FormCheckout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCheckout));
            this.label6 = new System.Windows.Forms.Label();
            this.lbtotalPrice = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chbTakeout = new System.Windows.Forms.CheckBox();
            this.chbBuyShoppingBag = new System.Windows.Forms.CheckBox();
            this.tbFeedback = new System.Windows.Forms.TextBox();
            this.rbCash = new System.Windows.Forms.RadioButton();
            this.butclose = new System.Windows.Forms.Button();
            this.butCheckout = new System.Windows.Forms.Button();
            this.chbDonateReceipt = new System.Windows.Forms.CheckBox();
            this.tbUBN = new System.Windows.Forms.TextBox();
            this.chbUBN = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCreditCard = new System.Windows.Forms.TextBox();
            this.rbCreditCard = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("萝莉体", 20F);
            this.label6.Location = new System.Drawing.Point(334, 227);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 37);
            this.label6.TabIndex = 15;
            this.label6.Text = "元";
            // 
            // lbtotalPrice
            // 
            this.lbtotalPrice.AutoSize = true;
            this.lbtotalPrice.Font = new System.Drawing.Font("萝莉体", 20F);
            this.lbtotalPrice.Location = new System.Drawing.Point(119, 227);
            this.lbtotalPrice.Name = "lbtotalPrice";
            this.lbtotalPrice.Size = new System.Drawing.Size(209, 37);
            this.lbtotalPrice.TabIndex = 14;
            this.lbtotalPrice.Text = "000000000000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("萝莉体", 20F);
            this.label4.Location = new System.Drawing.Point(12, 227);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 37);
            this.label4.TabIndex = 13;
            this.label4.Text = "總價：";
            // 
            // chbTakeout
            // 
            this.chbTakeout.AutoSize = true;
            this.chbTakeout.Location = new System.Drawing.Point(12, 13);
            this.chbTakeout.Name = "chbTakeout";
            this.chbTakeout.Size = new System.Drawing.Size(50, 20);
            this.chbTakeout.TabIndex = 16;
            this.chbTakeout.Text = "外帶";
            this.chbTakeout.UseVisualStyleBackColor = true;
            // 
            // chbBuyShoppingBag
            // 
            this.chbBuyShoppingBag.AutoSize = true;
            this.chbBuyShoppingBag.Location = new System.Drawing.Point(12, 40);
            this.chbBuyShoppingBag.Name = "chbBuyShoppingBag";
            this.chbBuyShoppingBag.Size = new System.Drawing.Size(74, 20);
            this.chbBuyShoppingBag.TabIndex = 17;
            this.chbBuyShoppingBag.Text = "買購物袋";
            this.chbBuyShoppingBag.UseVisualStyleBackColor = true;
            this.chbBuyShoppingBag.CheckedChanged += new System.EventHandler(this.chbBuyShoppingBag_CheckedChanged);
            // 
            // tbFeedback
            // 
            this.tbFeedback.Location = new System.Drawing.Point(12, 163);
            this.tbFeedback.Multiline = true;
            this.tbFeedback.Name = "tbFeedback";
            this.tbFeedback.Size = new System.Drawing.Size(367, 61);
            this.tbFeedback.TabIndex = 18;
            // 
            // rbCash
            // 
            this.rbCash.AutoSize = true;
            this.rbCash.Checked = true;
            this.rbCash.Location = new System.Drawing.Point(201, 39);
            this.rbCash.Name = "rbCash";
            this.rbCash.Size = new System.Drawing.Size(49, 20);
            this.rbCash.TabIndex = 19;
            this.rbCash.TabStop = true;
            this.rbCash.Text = "現金";
            this.rbCash.UseVisualStyleBackColor = true;
            // 
            // butclose
            // 
            this.butclose.Location = new System.Drawing.Point(12, 267);
            this.butclose.Name = "butclose";
            this.butclose.Size = new System.Drawing.Size(178, 41);
            this.butclose.TabIndex = 20;
            this.butclose.Text = "返回";
            this.butclose.UseVisualStyleBackColor = true;
            this.butclose.Click += new System.EventHandler(this.butclose_Click);
            // 
            // butCheckout
            // 
            this.butCheckout.Location = new System.Drawing.Point(201, 267);
            this.butCheckout.Name = "butCheckout";
            this.butCheckout.Size = new System.Drawing.Size(178, 41);
            this.butCheckout.TabIndex = 21;
            this.butCheckout.Text = "結帳";
            this.butCheckout.UseVisualStyleBackColor = true;
            this.butCheckout.Click += new System.EventHandler(this.butCheckout_Click);
            // 
            // chbDonateReceipt
            // 
            this.chbDonateReceipt.AutoSize = true;
            this.chbDonateReceipt.Location = new System.Drawing.Point(12, 66);
            this.chbDonateReceipt.Name = "chbDonateReceipt";
            this.chbDonateReceipt.Size = new System.Drawing.Size(74, 20);
            this.chbDonateReceipt.TabIndex = 22;
            this.chbDonateReceipt.Text = "捐贈發票";
            this.chbDonateReceipt.UseVisualStyleBackColor = true;
            // 
            // tbUBN
            // 
            this.tbUBN.Location = new System.Drawing.Point(12, 115);
            this.tbUBN.MaxLength = 8;
            this.tbUBN.Name = "tbUBN";
            this.tbUBN.Size = new System.Drawing.Size(178, 24);
            this.tbUBN.TabIndex = 23;
            this.tbUBN.Visible = false;
            // 
            // chbUBN
            // 
            this.chbUBN.AutoSize = true;
            this.chbUBN.Location = new System.Drawing.Point(12, 92);
            this.chbUBN.Name = "chbUBN";
            this.chbUBN.Size = new System.Drawing.Size(50, 20);
            this.chbUBN.TabIndex = 24;
            this.chbUBN.Text = "統編";
            this.chbUBN.UseVisualStyleBackColor = true;
            this.chbUBN.CheckedChanged += new System.EventHandler(this.chbUBN_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 25;
            this.label1.Text = "意見回饋";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(198, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 26;
            this.label2.Text = "花費方式";
            // 
            // tbCreditCard
            // 
            this.tbCreditCard.Location = new System.Drawing.Point(201, 115);
            this.tbCreditCard.Name = "tbCreditCard";
            this.tbCreditCard.Size = new System.Drawing.Size(178, 24);
            this.tbCreditCard.TabIndex = 30;
            this.tbCreditCard.Visible = false;
            // 
            // rbCreditCard
            // 
            this.rbCreditCard.AutoSize = true;
            this.rbCreditCard.Location = new System.Drawing.Point(201, 92);
            this.rbCreditCard.Name = "rbCreditCard";
            this.rbCreditCard.Size = new System.Drawing.Size(61, 20);
            this.rbCreditCard.TabIndex = 31;
            this.rbCreditCard.TabStop = true;
            this.rbCreditCard.Text = "信用卡";
            this.rbCreditCard.UseVisualStyleBackColor = true;
            this.rbCreditCard.CheckedChanged += new System.EventHandler(this.rbCreditCard_CheckedChanged);
            // 
            // FormCheckout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 326);
            this.Controls.Add(this.rbCreditCard);
            this.Controls.Add(this.tbCreditCard);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chbUBN);
            this.Controls.Add(this.tbUBN);
            this.Controls.Add(this.chbDonateReceipt);
            this.Controls.Add(this.butCheckout);
            this.Controls.Add(this.butclose);
            this.Controls.Add(this.rbCash);
            this.Controls.Add(this.tbFeedback);
            this.Controls.Add(this.chbBuyShoppingBag);
            this.Controls.Add(this.chbTakeout);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbtotalPrice);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("萝莉体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormCheckout";
            this.Text = "結帳";
            this.Load += new System.EventHandler(this.FormCheckout_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbtotalPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chbTakeout;
        private System.Windows.Forms.CheckBox chbBuyShoppingBag;
        private System.Windows.Forms.TextBox tbFeedback;
        private System.Windows.Forms.RadioButton rbCash;
        private System.Windows.Forms.Button butclose;
        private System.Windows.Forms.Button butCheckout;
        private System.Windows.Forms.CheckBox chbDonateReceipt;
        private System.Windows.Forms.TextBox tbUBN;
        private System.Windows.Forms.CheckBox chbUBN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCreditCard;
        private System.Windows.Forms.RadioButton rbCreditCard;
    }
}