namespace Rwork2
{
    partial class FormOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOrder));
            this.lvOrder = new System.Windows.Forms.ListView();
            this.butEditOrder = new System.Windows.Forms.Button();
            this.butSearchOrder = new System.Windows.Forms.Button();
            this.cbSearchOrder = new System.Windows.Forms.ComboBox();
            this.tbSearchOrder = new System.Windows.Forms.TextBox();
            this.butSearchOrderClear = new System.Windows.Forms.Button();
            this.butRevenue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvOrder
            // 
            this.lvOrder.HideSelection = false;
            this.lvOrder.Location = new System.Drawing.Point(12, 12);
            this.lvOrder.Name = "lvOrder";
            this.lvOrder.Size = new System.Drawing.Size(691, 301);
            this.lvOrder.TabIndex = 9;
            this.lvOrder.UseCompatibleStateImageBehavior = false;
            this.lvOrder.View = System.Windows.Forms.View.Details;
            this.lvOrder.SelectedIndexChanged += new System.EventHandler(this.lvOrder_SelectedIndexChanged);
            // 
            // butEditOrder
            // 
            this.butEditOrder.Font = new System.Drawing.Font("萝莉体", 20F);
            this.butEditOrder.Location = new System.Drawing.Point(566, 319);
            this.butEditOrder.Name = "butEditOrder";
            this.butEditOrder.Size = new System.Drawing.Size(137, 114);
            this.butEditOrder.TabIndex = 11;
            this.butEditOrder.Text = "修改訂單";
            this.butEditOrder.UseVisualStyleBackColor = true;
            this.butEditOrder.Click += new System.EventHandler(this.butEditOrder_Click);
            // 
            // butSearchOrder
            // 
            this.butSearchOrder.Font = new System.Drawing.Font("萝莉体", 20F);
            this.butSearchOrder.Location = new System.Drawing.Point(12, 379);
            this.butSearchOrder.Name = "butSearchOrder";
            this.butSearchOrder.Size = new System.Drawing.Size(173, 54);
            this.butSearchOrder.TabIndex = 12;
            this.butSearchOrder.Text = "搜尋";
            this.butSearchOrder.UseVisualStyleBackColor = true;
            this.butSearchOrder.Click += new System.EventHandler(this.butSearchOrder_Click);
            // 
            // cbSearchOrder
            // 
            this.cbSearchOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSearchOrder.FormattingEnabled = true;
            this.cbSearchOrder.Location = new System.Drawing.Point(12, 319);
            this.cbSearchOrder.Name = "cbSearchOrder";
            this.cbSearchOrder.Size = new System.Drawing.Size(375, 24);
            this.cbSearchOrder.TabIndex = 13;
            // 
            // tbSearchOrder
            // 
            this.tbSearchOrder.Location = new System.Drawing.Point(12, 349);
            this.tbSearchOrder.Name = "tbSearchOrder";
            this.tbSearchOrder.Size = new System.Drawing.Size(375, 24);
            this.tbSearchOrder.TabIndex = 14;
            // 
            // butSearchOrderClear
            // 
            this.butSearchOrderClear.Font = new System.Drawing.Font("萝莉体", 20F);
            this.butSearchOrderClear.Location = new System.Drawing.Point(214, 379);
            this.butSearchOrderClear.Name = "butSearchOrderClear";
            this.butSearchOrderClear.Size = new System.Drawing.Size(173, 54);
            this.butSearchOrderClear.TabIndex = 15;
            this.butSearchOrderClear.Text = "清除搜尋";
            this.butSearchOrderClear.UseVisualStyleBackColor = true;
            this.butSearchOrderClear.Click += new System.EventHandler(this.butSearchOrderClear_Click);
            // 
            // butRevenue
            // 
            this.butRevenue.Font = new System.Drawing.Font("萝莉体", 20F);
            this.butRevenue.Location = new System.Drawing.Point(393, 320);
            this.butRevenue.Name = "butRevenue";
            this.butRevenue.Size = new System.Drawing.Size(167, 113);
            this.butRevenue.TabIndex = 16;
            this.butRevenue.Text = "營業額計算";
            this.butRevenue.UseVisualStyleBackColor = true;
            this.butRevenue.Click += new System.EventHandler(this.butRevenue_Click);
            // 
            // FormOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 444);
            this.Controls.Add(this.butRevenue);
            this.Controls.Add(this.lvOrder);
            this.Controls.Add(this.butSearchOrderClear);
            this.Controls.Add(this.tbSearchOrder);
            this.Controls.Add(this.butSearchOrder);
            this.Controls.Add(this.butEditOrder);
            this.Controls.Add(this.cbSearchOrder);
            this.Font = new System.Drawing.Font("萝莉体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormOrder";
            this.Text = "訂單管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormOrder_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormOrder_FormClosed);
            this.Load += new System.EventHandler(this.FormOrder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvOrder;
        private System.Windows.Forms.Button butEditOrder;
        private System.Windows.Forms.Button butSearchOrder;
        private System.Windows.Forms.ComboBox cbSearchOrder;
        private System.Windows.Forms.TextBox tbSearchOrder;
        private System.Windows.Forms.Button butSearchOrderClear;
        private System.Windows.Forms.Button butRevenue;
    }
}