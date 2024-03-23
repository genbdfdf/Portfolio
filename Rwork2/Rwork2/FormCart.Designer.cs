namespace Rwork2
{
    partial class FormCart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCart));
            this.lvCart = new System.Windows.Forms.ListView();
            this.butclose = new System.Windows.Forms.Button();
            this.butCheckout = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lbtotalPrice = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.butClear = new System.Windows.Forms.Button();
            this.butDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvCart
            // 
            this.lvCart.HideSelection = false;
            this.lvCart.Location = new System.Drawing.Point(16, 16);
            this.lvCart.Margin = new System.Windows.Forms.Padding(4);
            this.lvCart.MultiSelect = false;
            this.lvCart.Name = "lvCart";
            this.lvCart.Size = new System.Drawing.Size(447, 302);
            this.lvCart.TabIndex = 0;
            this.lvCart.UseCompatibleStateImageBehavior = false;
            this.lvCart.View = System.Windows.Forms.View.Details;
            this.lvCart.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.lvCart_ColumnWidthChanging);
            this.lvCart.SelectedIndexChanged += new System.EventHandler(this.lvCart_SelectedIndexChanged);
            // 
            // butclose
            // 
            this.butclose.Location = new System.Drawing.Point(273, 358);
            this.butclose.Margin = new System.Windows.Forms.Padding(4);
            this.butclose.Name = "butclose";
            this.butclose.Size = new System.Drawing.Size(190, 51);
            this.butclose.TabIndex = 1;
            this.butclose.Text = "返回";
            this.butclose.UseVisualStyleBackColor = true;
            this.butclose.Click += new System.EventHandler(this.butclose_Click);
            // 
            // butCheckout
            // 
            this.butCheckout.Location = new System.Drawing.Point(273, 417);
            this.butCheckout.Margin = new System.Windows.Forms.Padding(4);
            this.butCheckout.Name = "butCheckout";
            this.butCheckout.Size = new System.Drawing.Size(190, 51);
            this.butCheckout.TabIndex = 2;
            this.butCheckout.Text = "結帳";
            this.butCheckout.UseVisualStyleBackColor = true;
            this.butCheckout.Click += new System.EventHandler(this.butCheckout_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("萝莉体", 20F);
            this.label6.Location = new System.Drawing.Point(418, 322);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 37);
            this.label6.TabIndex = 15;
            this.label6.Text = "元";
            // 
            // lbtotalPrice
            // 
            this.lbtotalPrice.AutoSize = true;
            this.lbtotalPrice.Font = new System.Drawing.Font("萝莉体", 20F);
            this.lbtotalPrice.Location = new System.Drawing.Point(147, 322);
            this.lbtotalPrice.Name = "lbtotalPrice";
            this.lbtotalPrice.Size = new System.Drawing.Size(209, 37);
            this.lbtotalPrice.TabIndex = 14;
            this.lbtotalPrice.Text = "000000000000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("萝莉体", 20F);
            this.label4.Location = new System.Drawing.Point(9, 322);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 37);
            this.label4.TabIndex = 13;
            this.label4.Text = "總價：";
            // 
            // butClear
            // 
            this.butClear.Location = new System.Drawing.Point(16, 417);
            this.butClear.Margin = new System.Windows.Forms.Padding(4);
            this.butClear.Name = "butClear";
            this.butClear.Size = new System.Drawing.Size(190, 51);
            this.butClear.TabIndex = 16;
            this.butClear.Text = "清空";
            this.butClear.UseVisualStyleBackColor = true;
            this.butClear.Click += new System.EventHandler(this.butClear_Click);
            // 
            // butDelete
            // 
            this.butDelete.Location = new System.Drawing.Point(16, 358);
            this.butDelete.Margin = new System.Windows.Forms.Padding(4);
            this.butDelete.Name = "butDelete";
            this.butDelete.Size = new System.Drawing.Size(190, 51);
            this.butDelete.TabIndex = 17;
            this.butDelete.Text = "刪除";
            this.butDelete.UseVisualStyleBackColor = true;
            this.butDelete.Click += new System.EventHandler(this.butDelete_Click);
            // 
            // FormCart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 481);
            this.Controls.Add(this.butDelete);
            this.Controls.Add(this.butClear);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbtotalPrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.butCheckout);
            this.Controls.Add(this.butclose);
            this.Controls.Add(this.lvCart);
            this.Font = new System.Drawing.Font("萝莉体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormCart";
            this.Text = "購物車";
            this.Load += new System.EventHandler(this.FormCart_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvCart;
        private System.Windows.Forms.Button butclose;
        private System.Windows.Forms.Button butCheckout;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbtotalPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button butClear;
        private System.Windows.Forms.Button butDelete;
    }
}