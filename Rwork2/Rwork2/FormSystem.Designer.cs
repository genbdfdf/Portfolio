namespace Rwork2
{
    partial class FormSystem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSystem));
            this.tabSystem = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lvPerson = new System.Windows.Forms.ListView();
            this.butAddPerson = new System.Windows.Forms.Button();
            this.cbSearchPerson = new System.Windows.Forms.ComboBox();
            this.butEditPerson = new System.Windows.Forms.Button();
            this.butSearchPersonClear = new System.Windows.Forms.Button();
            this.butSearchPerson = new System.Windows.Forms.Button();
            this.tbSearchPerson = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabSystem.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabSystem
            // 
            this.tabSystem.Controls.Add(this.tabPage1);
            this.tabSystem.Controls.Add(this.tabPage2);
            this.tabSystem.Location = new System.Drawing.Point(12, 12);
            this.tabSystem.Name = "tabSystem";
            this.tabSystem.SelectedIndex = 0;
            this.tabSystem.Size = new System.Drawing.Size(695, 468);
            this.tabSystem.TabIndex = 30;
            this.tabSystem.SelectedIndexChanged += new System.EventHandler(this.tabSystem_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lvPerson);
            this.tabPage1.Controls.Add(this.butAddPerson);
            this.tabPage1.Controls.Add(this.cbSearchPerson);
            this.tabPage1.Controls.Add(this.butEditPerson);
            this.tabPage1.Controls.Add(this.butSearchPersonClear);
            this.tabPage1.Controls.Add(this.butSearchPerson);
            this.tabPage1.Controls.Add(this.tbSearchPerson);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(687, 439);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "員工列表";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lvPerson
            // 
            this.lvPerson.HideSelection = false;
            this.lvPerson.Location = new System.Drawing.Point(6, 6);
            this.lvPerson.Name = "lvPerson";
            this.lvPerson.Size = new System.Drawing.Size(667, 301);
            this.lvPerson.TabIndex = 30;
            this.lvPerson.UseCompatibleStateImageBehavior = false;
            this.lvPerson.View = System.Windows.Forms.View.Details;
            this.lvPerson.SelectedIndexChanged += new System.EventHandler(this.lvPerson_SelectedIndexChanged);
            // 
            // butAddPerson
            // 
            this.butAddPerson.Font = new System.Drawing.Font("萝莉体", 20F);
            this.butAddPerson.Location = new System.Drawing.Point(479, 313);
            this.butAddPerson.Name = "butAddPerson";
            this.butAddPerson.Size = new System.Drawing.Size(194, 54);
            this.butAddPerson.TabIndex = 36;
            this.butAddPerson.Text = "新增員工資料";
            this.butAddPerson.UseVisualStyleBackColor = true;
            this.butAddPerson.Click += new System.EventHandler(this.butAddPerson_Click);
            // 
            // cbSearchPerson
            // 
            this.cbSearchPerson.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSearchPerson.FormattingEnabled = true;
            this.cbSearchPerson.Location = new System.Drawing.Point(6, 313);
            this.cbSearchPerson.Name = "cbSearchPerson";
            this.cbSearchPerson.Size = new System.Drawing.Size(375, 24);
            this.cbSearchPerson.TabIndex = 33;
            // 
            // butEditPerson
            // 
            this.butEditPerson.Font = new System.Drawing.Font("萝莉体", 20F);
            this.butEditPerson.Location = new System.Drawing.Point(479, 373);
            this.butEditPerson.Name = "butEditPerson";
            this.butEditPerson.Size = new System.Drawing.Size(194, 54);
            this.butEditPerson.TabIndex = 31;
            this.butEditPerson.Text = "修改員工資料";
            this.butEditPerson.UseVisualStyleBackColor = true;
            this.butEditPerson.Click += new System.EventHandler(this.butEditPerson_Click);
            // 
            // butSearchPersonClear
            // 
            this.butSearchPersonClear.Font = new System.Drawing.Font("萝莉体", 20F);
            this.butSearchPersonClear.Location = new System.Drawing.Point(208, 373);
            this.butSearchPersonClear.Name = "butSearchPersonClear";
            this.butSearchPersonClear.Size = new System.Drawing.Size(173, 54);
            this.butSearchPersonClear.TabIndex = 35;
            this.butSearchPersonClear.Text = "清除搜尋";
            this.butSearchPersonClear.UseVisualStyleBackColor = true;
            this.butSearchPersonClear.Click += new System.EventHandler(this.butSearchPersonClear_Click);
            // 
            // butSearchPerson
            // 
            this.butSearchPerson.Font = new System.Drawing.Font("萝莉体", 20F);
            this.butSearchPerson.Location = new System.Drawing.Point(6, 373);
            this.butSearchPerson.Name = "butSearchPerson";
            this.butSearchPerson.Size = new System.Drawing.Size(173, 54);
            this.butSearchPerson.TabIndex = 32;
            this.butSearchPerson.Text = "搜尋";
            this.butSearchPerson.UseVisualStyleBackColor = true;
            this.butSearchPerson.Click += new System.EventHandler(this.butSearchPerson_Click);
            // 
            // tbSearchPerson
            // 
            this.tbSearchPerson.Location = new System.Drawing.Point(6, 343);
            this.tbSearchPerson.Name = "tbSearchPerson";
            this.tbSearchPerson.Size = new System.Drawing.Size(375, 24);
            this.tbSearchPerson.TabIndex = 34;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(687, 439);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "其他";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // FormSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 482);
            this.Controls.Add(this.tabSystem);
            this.Font = new System.Drawing.Font("萝莉体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormSystem";
            this.Text = "系統管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSystem_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormSystem_FormClosed);
            this.Load += new System.EventHandler(this.FormSystem_Load);
            this.tabSystem.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabSystem;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView lvPerson;
        private System.Windows.Forms.Button butAddPerson;
        private System.Windows.Forms.ComboBox cbSearchPerson;
        private System.Windows.Forms.Button butEditPerson;
        private System.Windows.Forms.Button butSearchPersonClear;
        private System.Windows.Forms.Button butSearchPerson;
        private System.Windows.Forms.TextBox tbSearchPerson;
    }
}