namespace Rwork2
{
    partial class FormPurchase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPurchase));
            this.butSearchPurchase = new System.Windows.Forms.Button();
            this.cbSearchPurchase = new System.Windows.Forms.ComboBox();
            this.butEditPurchase = new System.Windows.Forms.Button();
            this.tbSearchPurchase = new System.Windows.Forms.TextBox();
            this.butSearchPurchaseClear = new System.Windows.Forms.Button();
            this.lvPurchase = new System.Windows.Forms.ListView();
            this.butAddPurchase = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // butSearchPurchase
            // 
            this.butSearchPurchase.Font = new System.Drawing.Font("萝莉体", 20F);
            this.butSearchPurchase.Location = new System.Drawing.Point(16, 397);
            this.butSearchPurchase.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.butSearchPurchase.Name = "butSearchPurchase";
            this.butSearchPurchase.Size = new System.Drawing.Size(173, 54);
            this.butSearchPurchase.TabIndex = 25;
            this.butSearchPurchase.Text = "搜尋";
            this.butSearchPurchase.UseVisualStyleBackColor = true;
            this.butSearchPurchase.Click += new System.EventHandler(this.butSearchPurchase_Click);
            // 
            // cbSearchPurchase
            // 
            this.cbSearchPurchase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSearchPurchase.FormattingEnabled = true;
            this.cbSearchPurchase.Location = new System.Drawing.Point(16, 325);
            this.cbSearchPurchase.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbSearchPurchase.Name = "cbSearchPurchase";
            this.cbSearchPurchase.Size = new System.Drawing.Size(375, 24);
            this.cbSearchPurchase.TabIndex = 26;
            // 
            // butEditPurchase
            // 
            this.butEditPurchase.Font = new System.Drawing.Font("萝莉体", 20F);
            this.butEditPurchase.Location = new System.Drawing.Point(574, 325);
            this.butEditPurchase.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.butEditPurchase.Name = "butEditPurchase";
            this.butEditPurchase.Size = new System.Drawing.Size(167, 126);
            this.butEditPurchase.TabIndex = 24;
            this.butEditPurchase.Text = "修改進貨單";
            this.butEditPurchase.UseVisualStyleBackColor = true;
            this.butEditPurchase.Click += new System.EventHandler(this.butEditPurchase_Click);
            // 
            // tbSearchPurchase
            // 
            this.tbSearchPurchase.Location = new System.Drawing.Point(16, 365);
            this.tbSearchPurchase.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbSearchPurchase.Name = "tbSearchPurchase";
            this.tbSearchPurchase.Size = new System.Drawing.Size(375, 24);
            this.tbSearchPurchase.TabIndex = 27;
            // 
            // butSearchPurchaseClear
            // 
            this.butSearchPurchaseClear.Font = new System.Drawing.Font("萝莉体", 20F);
            this.butSearchPurchaseClear.Location = new System.Drawing.Point(218, 397);
            this.butSearchPurchaseClear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.butSearchPurchaseClear.Name = "butSearchPurchaseClear";
            this.butSearchPurchaseClear.Size = new System.Drawing.Size(173, 54);
            this.butSearchPurchaseClear.TabIndex = 28;
            this.butSearchPurchaseClear.Text = "清除搜尋";
            this.butSearchPurchaseClear.UseVisualStyleBackColor = true;
            this.butSearchPurchaseClear.Click += new System.EventHandler(this.butSearchPurchaseClear_Click);
            // 
            // lvPurchase
            // 
            this.lvPurchase.HideSelection = false;
            this.lvPurchase.Location = new System.Drawing.Point(16, 16);
            this.lvPurchase.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lvPurchase.Name = "lvPurchase";
            this.lvPurchase.Size = new System.Drawing.Size(725, 301);
            this.lvPurchase.TabIndex = 23;
            this.lvPurchase.UseCompatibleStateImageBehavior = false;
            this.lvPurchase.View = System.Windows.Forms.View.Details;
            this.lvPurchase.SelectedIndexChanged += new System.EventHandler(this.lvPurchase_SelectedIndexChanged);
            // 
            // butAddPurchase
            // 
            this.butAddPurchase.Font = new System.Drawing.Font("萝莉体", 20F);
            this.butAddPurchase.Location = new System.Drawing.Point(399, 325);
            this.butAddPurchase.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.butAddPurchase.Name = "butAddPurchase";
            this.butAddPurchase.Size = new System.Drawing.Size(167, 126);
            this.butAddPurchase.TabIndex = 29;
            this.butAddPurchase.Text = "新增進貨單";
            this.butAddPurchase.UseVisualStyleBackColor = true;
            this.butAddPurchase.Click += new System.EventHandler(this.butAddPurchase_Click);
            // 
            // FormPurchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 464);
            this.Controls.Add(this.butAddPurchase);
            this.Controls.Add(this.lvPurchase);
            this.Controls.Add(this.butSearchPurchaseClear);
            this.Controls.Add(this.tbSearchPurchase);
            this.Controls.Add(this.butEditPurchase);
            this.Controls.Add(this.cbSearchPurchase);
            this.Controls.Add(this.butSearchPurchase);
            this.Font = new System.Drawing.Font("萝莉体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormPurchase";
            this.Text = "進貨系統";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Formpurchase_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Formpurchase_FormClosed);
            this.Load += new System.EventHandler(this.Formpurchase_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butSearchPurchase;
        private System.Windows.Forms.ComboBox cbSearchPurchase;
        private System.Windows.Forms.Button butEditPurchase;
        private System.Windows.Forms.TextBox tbSearchPurchase;
        private System.Windows.Forms.Button butSearchPurchaseClear;
        private System.Windows.Forms.ListView lvPurchase;
        private System.Windows.Forms.Button butAddPurchase;
    }
}