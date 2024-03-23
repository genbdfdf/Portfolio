namespace Rwork2
{
    partial class FormMember
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMember));
            this.lvMember = new System.Windows.Forms.ListView();
            this.butSearchMemberClear = new System.Windows.Forms.Button();
            this.tbSearchMember = new System.Windows.Forms.TextBox();
            this.butEditMember = new System.Windows.Forms.Button();
            this.cbSearchMember = new System.Windows.Forms.ComboBox();
            this.butSearchMember = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvMember
            // 
            this.lvMember.HideSelection = false;
            this.lvMember.Location = new System.Drawing.Point(12, 12);
            this.lvMember.Name = "lvMember";
            this.lvMember.Size = new System.Drawing.Size(667, 301);
            this.lvMember.TabIndex = 16;
            this.lvMember.UseCompatibleStateImageBehavior = false;
            this.lvMember.View = System.Windows.Forms.View.Details;
            this.lvMember.SelectedIndexChanged += new System.EventHandler(this.lvMember_SelectedIndexChanged);
            // 
            // butSearchMemberClear
            // 
            this.butSearchMemberClear.Font = new System.Drawing.Font("萝莉体", 20F);
            this.butSearchMemberClear.Location = new System.Drawing.Point(214, 379);
            this.butSearchMemberClear.Name = "butSearchMemberClear";
            this.butSearchMemberClear.Size = new System.Drawing.Size(173, 54);
            this.butSearchMemberClear.TabIndex = 22;
            this.butSearchMemberClear.Text = "清除搜尋";
            this.butSearchMemberClear.UseVisualStyleBackColor = true;
            this.butSearchMemberClear.Click += new System.EventHandler(this.butSearchMemberClear_Click);
            // 
            // tbSearchMember
            // 
            this.tbSearchMember.Location = new System.Drawing.Point(12, 349);
            this.tbSearchMember.Name = "tbSearchMember";
            this.tbSearchMember.Size = new System.Drawing.Size(375, 24);
            this.tbSearchMember.TabIndex = 21;
            // 
            // butEditMember
            // 
            this.butEditMember.Font = new System.Drawing.Font("萝莉体", 20F);
            this.butEditMember.Location = new System.Drawing.Point(485, 319);
            this.butEditMember.Name = "butEditMember";
            this.butEditMember.Size = new System.Drawing.Size(194, 114);
            this.butEditMember.TabIndex = 18;
            this.butEditMember.Text = "修改會員資料";
            this.butEditMember.UseVisualStyleBackColor = true;
            this.butEditMember.Click += new System.EventHandler(this.butEditMember_Click);
            // 
            // cbSearchMember
            // 
            this.cbSearchMember.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSearchMember.FormattingEnabled = true;
            this.cbSearchMember.Location = new System.Drawing.Point(12, 319);
            this.cbSearchMember.Name = "cbSearchMember";
            this.cbSearchMember.Size = new System.Drawing.Size(375, 24);
            this.cbSearchMember.TabIndex = 20;
            // 
            // butSearchMember
            // 
            this.butSearchMember.Font = new System.Drawing.Font("萝莉体", 20F);
            this.butSearchMember.Location = new System.Drawing.Point(12, 379);
            this.butSearchMember.Name = "butSearchMember";
            this.butSearchMember.Size = new System.Drawing.Size(173, 54);
            this.butSearchMember.TabIndex = 19;
            this.butSearchMember.Text = "搜尋";
            this.butSearchMember.UseVisualStyleBackColor = true;
            this.butSearchMember.Click += new System.EventHandler(this.butSearchMember_Click);
            // 
            // FormMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 447);
            this.Controls.Add(this.lvMember);
            this.Controls.Add(this.butSearchMemberClear);
            this.Controls.Add(this.tbSearchMember);
            this.Controls.Add(this.butSearchMember);
            this.Controls.Add(this.butEditMember);
            this.Controls.Add(this.cbSearchMember);
            this.Font = new System.Drawing.Font("萝莉体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMember";
            this.Text = "會員資料";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMember_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMember_FormClosed);
            this.Load += new System.EventHandler(this.FormMember_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView lvMember;
        private System.Windows.Forms.Button butSearchMemberClear;
        private System.Windows.Forms.TextBox tbSearchMember;
        private System.Windows.Forms.Button butEditMember;
        private System.Windows.Forms.ComboBox cbSearchMember;
        private System.Windows.Forms.Button butSearchMember;
    }
}