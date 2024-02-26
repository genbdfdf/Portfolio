namespace Rwork2
{
    partial class FormRevenue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRevenue));
            this.lvOrder = new System.Windows.Forms.ListView();
            this.butSearch = new System.Windows.Forms.Button();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chartRevenue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.butWeek = new System.Windows.Forms.Button();
            this.butMonth = new System.Windows.Forms.Button();
            this.butYear = new System.Windows.Forms.Button();
            this.butColumn = new System.Windows.Forms.Button();
            this.butPie = new System.Windows.Forms.Button();
            this.butBar = new System.Windows.Forms.Button();
            this.butLine = new System.Windows.Forms.Button();
            this.cbSearchOrder2 = new System.Windows.Forms.ComboBox();
            this.butClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenue)).BeginInit();
            this.SuspendLayout();
            // 
            // lvOrder
            // 
            this.lvOrder.HideSelection = false;
            this.lvOrder.Location = new System.Drawing.Point(16, 16);
            this.lvOrder.Margin = new System.Windows.Forms.Padding(4);
            this.lvOrder.Name = "lvOrder";
            this.lvOrder.Size = new System.Drawing.Size(445, 301);
            this.lvOrder.TabIndex = 16;
            this.lvOrder.UseCompatibleStateImageBehavior = false;
            this.lvOrder.View = System.Windows.Forms.View.Details;
            // 
            // butSearch
            // 
            this.butSearch.Font = new System.Drawing.Font("萝莉体", 20F);
            this.butSearch.Location = new System.Drawing.Point(318, 325);
            this.butSearch.Margin = new System.Windows.Forms.Padding(4);
            this.butSearch.Name = "butSearch";
            this.butSearch.Size = new System.Drawing.Size(142, 42);
            this.butSearch.TabIndex = 17;
            this.butSearch.Text = "搜尋";
            this.butSearch.UseVisualStyleBackColor = true;
            this.butSearch.Click += new System.EventHandler(this.butSearch_Click);
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(47, 356);
            this.dtpStart.Margin = new System.Windows.Forms.Padding(4);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(265, 24);
            this.dtpStart.TabIndex = 21;
            this.dtpStart.Value = new System.DateTime(1980, 1, 1, 0, 0, 0, 0);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(47, 388);
            this.dtpEnd.Margin = new System.Windows.Forms.Padding(4);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(265, 24);
            this.dtpEnd.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("萝莉体", 12F);
            this.label1.Location = new System.Drawing.Point(13, 358);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 21);
            this.label1.TabIndex = 23;
            this.label1.Text = "從";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("萝莉体", 12F);
            this.label2.Location = new System.Drawing.Point(13, 390);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 21);
            this.label2.TabIndex = 24;
            this.label2.Text = "到";
            // 
            // chartRevenue
            // 
            this.chartRevenue.Location = new System.Drawing.Point(468, 17);
            this.chartRevenue.Name = "chartRevenue";
            this.chartRevenue.Size = new System.Drawing.Size(435, 300);
            this.chartRevenue.TabIndex = 25;
            this.chartRevenue.Text = "chart1";
            // 
            // butWeek
            // 
            this.butWeek.Font = new System.Drawing.Font("萝莉体", 20F);
            this.butWeek.Location = new System.Drawing.Point(16, 420);
            this.butWeek.Margin = new System.Windows.Forms.Padding(4);
            this.butWeek.Name = "butWeek";
            this.butWeek.Size = new System.Drawing.Size(140, 42);
            this.butWeek.TabIndex = 29;
            this.butWeek.Text = "一周前";
            this.butWeek.UseVisualStyleBackColor = true;
            this.butWeek.Click += new System.EventHandler(this.butWeek_Click);
            // 
            // butMonth
            // 
            this.butMonth.Font = new System.Drawing.Font("萝莉体", 20F);
            this.butMonth.Location = new System.Drawing.Point(164, 420);
            this.butMonth.Margin = new System.Windows.Forms.Padding(4);
            this.butMonth.Name = "butMonth";
            this.butMonth.Size = new System.Drawing.Size(140, 42);
            this.butMonth.TabIndex = 30;
            this.butMonth.Text = "一月前";
            this.butMonth.UseVisualStyleBackColor = true;
            this.butMonth.Click += new System.EventHandler(this.butMonth_Click);
            // 
            // butYear
            // 
            this.butYear.Font = new System.Drawing.Font("萝莉体", 20F);
            this.butYear.Location = new System.Drawing.Point(312, 420);
            this.butYear.Margin = new System.Windows.Forms.Padding(4);
            this.butYear.Name = "butYear";
            this.butYear.Size = new System.Drawing.Size(149, 42);
            this.butYear.TabIndex = 31;
            this.butYear.Text = "一年前";
            this.butYear.UseVisualStyleBackColor = true;
            this.butYear.Click += new System.EventHandler(this.butYear_Click);
            // 
            // butColumn
            // 
            this.butColumn.Font = new System.Drawing.Font("萝莉体", 20F);
            this.butColumn.Location = new System.Drawing.Point(468, 324);
            this.butColumn.Margin = new System.Windows.Forms.Padding(4);
            this.butColumn.Name = "butColumn";
            this.butColumn.Size = new System.Drawing.Size(211, 55);
            this.butColumn.TabIndex = 32;
            this.butColumn.Text = "長條圖";
            this.butColumn.UseVisualStyleBackColor = true;
            this.butColumn.Click += new System.EventHandler(this.butColumn_Click);
            // 
            // butPie
            // 
            this.butPie.Font = new System.Drawing.Font("萝莉体", 20F);
            this.butPie.Location = new System.Drawing.Point(692, 407);
            this.butPie.Margin = new System.Windows.Forms.Padding(4);
            this.butPie.Name = "butPie";
            this.butPie.Size = new System.Drawing.Size(211, 55);
            this.butPie.TabIndex = 33;
            this.butPie.Text = "圓餅圖";
            this.butPie.UseVisualStyleBackColor = true;
            this.butPie.Click += new System.EventHandler(this.butPie_Click);
            // 
            // butBar
            // 
            this.butBar.Font = new System.Drawing.Font("萝莉体", 20F);
            this.butBar.Location = new System.Drawing.Point(692, 325);
            this.butBar.Margin = new System.Windows.Forms.Padding(4);
            this.butBar.Name = "butBar";
            this.butBar.Size = new System.Drawing.Size(211, 55);
            this.butBar.TabIndex = 34;
            this.butBar.Text = "長條圖橫";
            this.butBar.UseVisualStyleBackColor = true;
            this.butBar.Click += new System.EventHandler(this.butBar_Click);
            // 
            // butLine
            // 
            this.butLine.Font = new System.Drawing.Font("萝莉体", 20F);
            this.butLine.Location = new System.Drawing.Point(468, 407);
            this.butLine.Margin = new System.Windows.Forms.Padding(4);
            this.butLine.Name = "butLine";
            this.butLine.Size = new System.Drawing.Size(211, 55);
            this.butLine.TabIndex = 35;
            this.butLine.Text = "折線圖";
            this.butLine.UseVisualStyleBackColor = true;
            this.butLine.Click += new System.EventHandler(this.butLine_Click);
            // 
            // cbSearchOrder2
            // 
            this.cbSearchOrder2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSearchOrder2.FormattingEnabled = true;
            this.cbSearchOrder2.Location = new System.Drawing.Point(16, 325);
            this.cbSearchOrder2.Name = "cbSearchOrder2";
            this.cbSearchOrder2.Size = new System.Drawing.Size(296, 24);
            this.cbSearchOrder2.TabIndex = 37;
            // 
            // butClear
            // 
            this.butClear.Font = new System.Drawing.Font("萝莉体", 20F);
            this.butClear.Location = new System.Drawing.Point(318, 369);
            this.butClear.Margin = new System.Windows.Forms.Padding(4);
            this.butClear.Name = "butClear";
            this.butClear.Size = new System.Drawing.Size(142, 42);
            this.butClear.TabIndex = 38;
            this.butClear.Text = "搜尋清除";
            this.butClear.UseVisualStyleBackColor = true;
            this.butClear.Click += new System.EventHandler(this.butClear_Click);
            // 
            // FormRevenue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 480);
            this.Controls.Add(this.butClear);
            this.Controls.Add(this.cbSearchOrder2);
            this.Controls.Add(this.butLine);
            this.Controls.Add(this.butBar);
            this.Controls.Add(this.butPie);
            this.Controls.Add(this.butColumn);
            this.Controls.Add(this.butYear);
            this.Controls.Add(this.butMonth);
            this.Controls.Add(this.butWeek);
            this.Controls.Add(this.chartRevenue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.lvOrder);
            this.Controls.Add(this.butSearch);
            this.Font = new System.Drawing.Font("萝莉体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormRevenue";
            this.Text = "營業額計算";
            this.Load += new System.EventHandler(this.FormRevenue_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvOrder;
        private System.Windows.Forms.Button butSearch;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRevenue;
        private System.Windows.Forms.Button butWeek;
        private System.Windows.Forms.Button butMonth;
        private System.Windows.Forms.Button butYear;
        private System.Windows.Forms.Button butColumn;
        private System.Windows.Forms.Button butPie;
        private System.Windows.Forms.Button butBar;
        private System.Windows.Forms.Button butLine;
        private System.Windows.Forms.ComboBox cbSearchOrder2;
        private System.Windows.Forms.Button butClear;
    }
}