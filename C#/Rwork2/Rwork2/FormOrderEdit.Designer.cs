namespace Rwork2
{
    partial class FormOrderEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOrderEdit));
            this.butClose = new System.Windows.Forms.Button();
            this.butComplete = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbCount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbName = new System.Windows.Forms.ComboBox();
            this.cbMember = new System.Windows.Forms.ComboBox();
            this.chbShipDate = new System.Windows.Forms.CheckBox();
            this.dtpOrderDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpShipDate = new System.Windows.Forms.DateTimePicker();
            this.tbRemark = new System.Windows.Forms.TextBox();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cbState = new System.Windows.Forms.ComboBox();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbSale = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lbTotalPrice = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // butClose
            // 
            this.butClose.Font = new System.Drawing.Font("萝莉体", 20F);
            this.butClose.Location = new System.Drawing.Point(15, 347);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(200, 69);
            this.butClose.TabIndex = 27;
            this.butClose.Text = "返回";
            this.butClose.UseVisualStyleBackColor = true;
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // butComplete
            // 
            this.butComplete.Font = new System.Drawing.Font("萝莉体", 20F);
            this.butComplete.Location = new System.Drawing.Point(221, 347);
            this.butComplete.Name = "butComplete";
            this.butComplete.Size = new System.Drawing.Size(200, 69);
            this.butComplete.TabIndex = 26;
            this.butComplete.Text = "完成修改";
            this.butComplete.UseVisualStyleBackColor = true;
            this.butComplete.Click += new System.EventHandler(this.butComplete_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("萝莉体", 12F);
            this.label6.Location = new System.Drawing.Point(13, 239);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 21);
            this.label6.TabIndex = 24;
            this.label6.Text = "訂購日期";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("萝莉体", 12F);
            this.label5.Location = new System.Drawing.Point(221, 209);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 21);
            this.label5.TabIndex = 22;
            this.label5.Text = "總價";
            // 
            // tbCount
            // 
            this.tbCount.Font = new System.Drawing.Font("萝莉体", 12F);
            this.tbCount.Location = new System.Drawing.Point(221, 148);
            this.tbCount.Margin = new System.Windows.Forms.Padding(4);
            this.tbCount.Name = "tbCount";
            this.tbCount.Size = new System.Drawing.Size(200, 29);
            this.tbCount.TabIndex = 21;
            this.tbCount.TextChanged += new System.EventHandler(this.tbCount_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("萝莉体", 12F);
            this.label4.Location = new System.Drawing.Point(221, 123);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 21);
            this.label4.TabIndex = 20;
            this.label4.Text = "數量";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("萝莉体", 12F);
            this.label3.Location = new System.Drawing.Point(13, 67);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 21);
            this.label3.TabIndex = 18;
            this.label3.Text = "訂購人";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("萝莉体", 12F);
            this.label2.Location = new System.Drawing.Point(221, 67);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 21);
            this.label2.TabIndex = 16;
            this.label2.Text = "口味";
            // 
            // tbId
            // 
            this.tbId.Font = new System.Drawing.Font("萝莉体", 12F);
            this.tbId.Location = new System.Drawing.Point(13, 34);
            this.tbId.Margin = new System.Windows.Forms.Padding(4);
            this.tbId.Name = "tbId";
            this.tbId.ReadOnly = true;
            this.tbId.Size = new System.Drawing.Size(200, 29);
            this.tbId.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("萝莉体", 12F);
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 21);
            this.label1.TabIndex = 14;
            this.label1.Text = "ID";
            // 
            // cbName
            // 
            this.cbName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbName.Font = new System.Drawing.Font("萝莉体", 12F);
            this.cbName.FormattingEnabled = true;
            this.cbName.Location = new System.Drawing.Point(221, 91);
            this.cbName.Name = "cbName";
            this.cbName.Size = new System.Drawing.Size(200, 29);
            this.cbName.TabIndex = 28;
            // 
            // cbMember
            // 
            this.cbMember.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMember.Font = new System.Drawing.Font("萝莉体", 12F);
            this.cbMember.FormattingEnabled = true;
            this.cbMember.Location = new System.Drawing.Point(13, 91);
            this.cbMember.Name = "cbMember";
            this.cbMember.Size = new System.Drawing.Size(200, 29);
            this.cbMember.TabIndex = 29;
            // 
            // chbShipDate
            // 
            this.chbShipDate.AutoSize = true;
            this.chbShipDate.Location = new System.Drawing.Point(94, 293);
            this.chbShipDate.Name = "chbShipDate";
            this.chbShipDate.Size = new System.Drawing.Size(120, 16);
            this.chbShipDate.TabIndex = 31;
            this.chbShipDate.Text = "是否需要收貨時間";
            this.chbShipDate.UseVisualStyleBackColor = true;
            this.chbShipDate.CheckedChanged += new System.EventHandler(this.chbShipDate_CheckedChanged);
            // 
            // dtpOrderDate
            // 
            this.dtpOrderDate.Location = new System.Drawing.Point(13, 263);
            this.dtpOrderDate.Name = "dtpOrderDate";
            this.dtpOrderDate.Size = new System.Drawing.Size(200, 22);
            this.dtpOrderDate.TabIndex = 32;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("萝莉体", 12F);
            this.label7.Location = new System.Drawing.Point(13, 288);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 21);
            this.label7.TabIndex = 34;
            this.label7.Text = "出貨日期";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("萝莉体", 12F);
            this.label8.Location = new System.Drawing.Point(221, 288);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 21);
            this.label8.TabIndex = 35;
            this.label8.Text = "備註";
            // 
            // dtpShipDate
            // 
            this.dtpShipDate.Location = new System.Drawing.Point(14, 313);
            this.dtpShipDate.Name = "dtpShipDate";
            this.dtpShipDate.Size = new System.Drawing.Size(200, 22);
            this.dtpShipDate.TabIndex = 36;
            this.dtpShipDate.Visible = false;
            // 
            // tbRemark
            // 
            this.tbRemark.Font = new System.Drawing.Font("萝莉体", 12F);
            this.tbRemark.Location = new System.Drawing.Point(221, 311);
            this.tbRemark.Margin = new System.Windows.Forms.Padding(4);
            this.tbRemark.Name = "tbRemark";
            this.tbRemark.Size = new System.Drawing.Size(200, 29);
            this.tbRemark.TabIndex = 37;
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.Location = new System.Drawing.Point(221, 263);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(200, 22);
            this.dtpDueDate.TabIndex = 39;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("萝莉体", 12F);
            this.label9.Location = new System.Drawing.Point(217, 239);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 21);
            this.label9.TabIndex = 38;
            this.label9.Text = "到期日期";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("萝莉体", 12F);
            this.label10.Location = new System.Drawing.Point(221, 9);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 21);
            this.label10.TabIndex = 40;
            this.label10.Text = "狀態";
            // 
            // cbState
            // 
            this.cbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbState.Font = new System.Drawing.Font("萝莉体", 12F);
            this.cbState.FormattingEnabled = true;
            this.cbState.Location = new System.Drawing.Point(221, 34);
            this.cbState.Name = "cbState";
            this.cbState.Size = new System.Drawing.Size(200, 29);
            this.cbState.TabIndex = 41;
            // 
            // tbPrice
            // 
            this.tbPrice.Font = new System.Drawing.Font("萝莉体", 12F);
            this.tbPrice.Location = new System.Drawing.Point(13, 148);
            this.tbPrice.Margin = new System.Windows.Forms.Padding(4);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(200, 29);
            this.tbPrice.TabIndex = 42;
            this.tbPrice.TextChanged += new System.EventHandler(this.tbPrice_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("萝莉体", 12F);
            this.label11.Location = new System.Drawing.Point(13, 123);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 21);
            this.label11.TabIndex = 43;
            this.label11.Text = "價格";
            // 
            // tbSale
            // 
            this.tbSale.Font = new System.Drawing.Font("萝莉体", 12F);
            this.tbSale.Location = new System.Drawing.Point(13, 206);
            this.tbSale.Margin = new System.Windows.Forms.Padding(4);
            this.tbSale.Name = "tbSale";
            this.tbSale.Size = new System.Drawing.Size(200, 29);
            this.tbSale.TabIndex = 45;
            this.tbSale.TextChanged += new System.EventHandler(this.tbSale_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("萝莉体", 12F);
            this.label12.Location = new System.Drawing.Point(9, 181);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 21);
            this.label12.TabIndex = 44;
            this.label12.Text = "折扣";
            // 
            // lbTotalPrice
            // 
            this.lbTotalPrice.AutoSize = true;
            this.lbTotalPrice.Font = new System.Drawing.Font("萝莉体", 12F);
            this.lbTotalPrice.Location = new System.Drawing.Point(264, 209);
            this.lbTotalPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTotalPrice.Name = "lbTotalPrice";
            this.lbTotalPrice.Size = new System.Drawing.Size(130, 21);
            this.lbTotalPrice.TabIndex = 46;
            this.lbTotalPrice.Text = "000000000000";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("萝莉体", 12F);
            this.label14.Location = new System.Drawing.Point(395, 209);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(26, 21);
            this.label14.TabIndex = 47;
            this.label14.Text = "元";
            // 
            // FormOrderEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 430);
            this.Controls.Add(this.lbTotalPrice);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.tbSale);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tbPrice);
            this.Controls.Add(this.cbState);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dtpDueDate);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbRemark);
            this.Controls.Add(this.dtpShipDate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtpOrderDate);
            this.Controls.Add(this.chbShipDate);
            this.Controls.Add(this.cbMember);
            this.Controls.Add(this.cbName);
            this.Controls.Add(this.butClose);
            this.Controls.Add(this.butComplete);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbCount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbId);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormOrderEdit";
            this.Text = "訂單修改";
            this.Load += new System.EventHandler(this.FormOrderEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butClose;
        private System.Windows.Forms.Button butComplete;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbName;
        private System.Windows.Forms.ComboBox cbMember;
        private System.Windows.Forms.CheckBox chbShipDate;
        private System.Windows.Forms.DateTimePicker dtpOrderDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpShipDate;
        private System.Windows.Forms.TextBox tbRemark;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbState;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbSale;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbTotalPrice;
        private System.Windows.Forms.Label label14;
    }
}