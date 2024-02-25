namespace gametest
{
    partial class gametest
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tmr_music = new System.Windows.Forms.Timer(this.components);
            this.update = new System.Windows.Forms.Timer(this.components);
            this.container = new SharpDX.Windows.RenderControl();
            this.fruitUpdate = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tmr_music
            // 
            this.tmr_music.Tick += new System.EventHandler(this.tmr_music_Tick);
            // 
            // update
            // 
            this.update.Enabled = true;
            this.update.Interval = 1000;
            this.update.Tick += new System.EventHandler(this.update_Tick);
            // 
            // container
            // 
            this.container.Location = new System.Drawing.Point(632, 119);
            this.container.Margin = new System.Windows.Forms.Padding(2);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(1, 1);
            this.container.TabIndex = 0;
            this.container.Paint += new System.Windows.Forms.PaintEventHandler(this.container_Paint);
            this.container.KeyDown += new System.Windows.Forms.KeyEventHandler(this.container_KeyDown);
            this.container.MouseClick += new System.Windows.Forms.MouseEventHandler(this.container_MouseClick);
            this.container.MouseMove += new System.Windows.Forms.MouseEventHandler(this.container_MouseMove);
            // 
            // fruitUpdate
            // 
            this.fruitUpdate.Enabled = true;
            this.fruitUpdate.Interval = 1000;
            this.fruitUpdate.Tick += new System.EventHandler(this.fruitUpdate_Tick);
            // 
            // gametest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 360);
            this.Controls.Add(this.container);
            this.Name = "gametest";
            this.Text = "gametest";
            this.Resize += new System.EventHandler(this.gametest_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmr_music;
        private System.Windows.Forms.Timer update;
        private SharpDX.Windows.RenderControl container;
        private System.Windows.Forms.Timer fruitUpdate;
    }
}

