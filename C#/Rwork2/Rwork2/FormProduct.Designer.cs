namespace Rwork2
{
    partial class FormProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProduct));
            this.lvProduct = new System.Windows.Forms.ListView();
            this.butAddProduct = new System.Windows.Forms.Button();
            this.butEditProduct = new System.Windows.Forms.Button();
            this.butSearch = new System.Windows.Forms.Button();
            this.cbSearch = new System.Windows.Forms.ComboBox();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.butSearchClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvProduct
            // 
            this.lvProduct.HideSelection = false;
            this.lvProduct.Location = new System.Drawing.Point(12, 12);
            this.lvProduct.Name = "lvProduct";
            this.lvProduct.Size = new System.Drawing.Size(667, 301);
            this.lvProduct.TabIndex = 0;
            this.lvProduct.UseCompatibleStateImageBehavior = false;
            this.lvProduct.View = System.Windows.Forms.View.Details;
            this.lvProduct.SelectedIndexChanged += new System.EventHandler(this.lvProduct_SelectedIndexChanged);
            // 
            // butAddProduct
            // 
            this.butAddProduct.Font = new System.Drawing.Font("萝莉体", 20F);
            this.butAddProduct.Location = new System.Drawing.Point(399, 319);
            this.butAddProduct.Name = "butAddProduct";
            this.butAddProduct.Size = new System.Drawing.Size(137, 114);
            this.butAddProduct.TabIndex = 1;
            this.butAddProduct.Text = "新增商品";
            this.butAddProduct.UseVisualStyleBackColor = true;
            this.butAddProduct.Click += new System.EventHandler(this.butAddProduct_Click);
            // 
            // butEditProduct
            // 
            this.butEditProduct.Font = new System.Drawing.Font("萝莉体", 20F);
            this.butEditProduct.Location = new System.Drawing.Point(542, 319);
            this.butEditProduct.Name = "butEditProduct";
            this.butEditProduct.Size = new System.Drawing.Size(137, 114);
            this.butEditProduct.TabIndex = 2;
            this.butEditProduct.Text = "修改商品";
            this.butEditProduct.UseVisualStyleBackColor = true;
            this.butEditProduct.Click += new System.EventHandler(this.butEditProduct_Click);
            // 
            // butSearch
            // 
            this.butSearch.Font = new System.Drawing.Font("萝莉体", 20F);
            this.butSearch.Location = new System.Drawing.Point(12, 379);
            this.butSearch.Name = "butSearch";
            this.butSearch.Size = new System.Drawing.Size(173, 54);
            this.butSearch.TabIndex = 5;
            this.butSearch.Text = "搜尋";
            this.butSearch.UseVisualStyleBackColor = true;
            this.butSearch.Click += new System.EventHandler(this.butSearch_Click);
            // 
            // cbSearch
            // 
            this.cbSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSearch.FormattingEnabled = true;
            this.cbSearch.Location = new System.Drawing.Point(12, 319);
            this.cbSearch.Name = "cbSearch";
            this.cbSearch.Size = new System.Drawing.Size(375, 24);
            this.cbSearch.TabIndex = 6;
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(12, 349);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(375, 24);
            this.tbSearch.TabIndex = 7;
            // 
            // butSearchClear
            // 
            this.butSearchClear.Font = new System.Drawing.Font("萝莉体", 20F);
            this.butSearchClear.Location = new System.Drawing.Point(214, 379);
            this.butSearchClear.Name = "butSearchClear";
            this.butSearchClear.Size = new System.Drawing.Size(173, 54);
            this.butSearchClear.TabIndex = 8;
            this.butSearchClear.Text = "清除搜尋";
            this.butSearchClear.UseVisualStyleBackColor = true;
            this.butSearchClear.Click += new System.EventHandler(this.butSearchClear_Click);
            // 
            // FormProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 452);
            this.Controls.Add(this.butSearchClear);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.cbSearch);
            this.Controls.Add(this.butSearch);
            this.Controls.Add(this.butEditProduct);
            this.Controls.Add(this.butAddProduct);
            this.Controls.Add(this.lvProduct);
            this.Font = new System.Drawing.Font("萝莉体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormProduct";
            this.Text = "商品管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormProduct_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormProduct_FormClosed);
            this.Load += new System.EventHandler(this.FormProduct_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvProduct;
        private System.Windows.Forms.Button butAddProduct;
        private System.Windows.Forms.Button butEditProduct;
        private System.Windows.Forms.Button butSearch;
        private System.Windows.Forms.ComboBox cbSearch;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button butSearchClear;
    }
}