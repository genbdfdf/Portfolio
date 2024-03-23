
using System.Windows.Forms;

namespace mapMaker
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.container = new SharpDX.Windows.RenderControl();
            this.tb_mapArea = new System.Windows.Forms.TextBox();
            this.lv_image = new System.Windows.Forms.ListView();
            this.iml_jpg = new System.Windows.Forms.ImageList(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.tb_map = new System.Windows.Forms.TextBox();
            this.iml_png = new System.Windows.Forms.ImageList(this.components);
            this.iml_gif = new System.Windows.Forms.ImageList(this.components);
            this.iml_bmp = new System.Windows.Forms.ImageList(this.components);
            this.lb_teleportNo = new System.Windows.Forms.Label();
            this.pl_angle = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lb_mapName = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.bt_importimage = new System.Windows.Forms.ToolStripDropDownButton();
            this.選擇檔案ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.選擇資料夾ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bt_readMap = new System.Windows.Forms.ToolStripButton();
            this.bt_saveMap = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.框線ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.前景ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.背景ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.傳送點ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.能否行走ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.地圖邊界ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tb_size = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripLb_per = new System.Windows.Forms.ToolStripLabel();
            this.pl_MSG = new System.Windows.Forms.Panel();
            this.lb_MSG = new System.Windows.Forms.Label();
            this.lb_imageorMap = new System.Windows.Forms.Label();
            this.bt_sizeUp = new System.Windows.Forms.Button();
            this.bt_sizeDown = new System.Windows.Forms.Button();
            this.pl_teleportArea = new System.Windows.Forms.Panel();
            this.button_createTeleport = new System.Windows.Forms.Button();
            this.button_deleteTeleport = new System.Windows.Forms.Button();
            this.comboBox_tpLoction = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_newtpLoction = new System.Windows.Forms.ComboBox();
            this.cb_donotAlertOverrideMap = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rb_useBack = new System.Windows.Forms.RadioButton();
            this.rb_useFore = new System.Windows.Forms.RadioButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tb_lv_imageloading = new System.Windows.Forms.TextBox();
            this.lv_map = new System.Windows.Forms.ListView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.pl_mapSetting = new System.Windows.Forms.Panel();
            this.cb_allSave = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.bt_colUp = new System.Windows.Forms.Button();
            this.bt_colDown = new System.Windows.Forms.Button();
            this.bt_rowUp = new System.Windows.Forms.Button();
            this.bt_rowDown = new System.Windows.Forms.Button();
            this.bt_widthUp = new System.Windows.Forms.Button();
            this.bt_widthDown = new System.Windows.Forms.Button();
            this.bt_heightUp = new System.Windows.Forms.Button();
            this.bt_heightDown = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_col = new System.Windows.Forms.TextBox();
            this.tb_row = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_height = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_width = new System.Windows.Forms.TextBox();
            this.lb_mapSetting = new System.Windows.Forms.Label();
            this.pl_gridSetting = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.bt_gridSetting = new System.Windows.Forms.Button();
            this.lb_gridSetting = new System.Windows.Forms.Label();
            this.bt_mapSetting = new System.Windows.Forms.Button();
            this.iml_map = new System.Windows.Forms.ImageList(this.components);
            this.pl_angle.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.pl_MSG.SuspendLayout();
            this.pl_teleportArea.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.pl_mapSetting.SuspendLayout();
            this.panel7.SuspendLayout();
            this.pl_gridSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // container
            // 
            this.container.AllowDrop = true;
            this.container.Location = new System.Drawing.Point(2233, 108);
            this.container.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(993, 673);
            this.container.TabIndex = 0;
            this.container.DragDrop += new System.Windows.Forms.DragEventHandler(this.container_DragDrop);
            this.container.DragEnter += new System.Windows.Forms.DragEventHandler(this.container_DragEnter);
            // 
            // tb_mapArea
            // 
            this.tb_mapArea.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_mapArea.Enabled = false;
            this.tb_mapArea.Location = new System.Drawing.Point(260, 51);
            this.tb_mapArea.Multiline = true;
            this.tb_mapArea.Name = "tb_mapArea";
            this.tb_mapArea.Size = new System.Drawing.Size(993, 475);
            this.tb_mapArea.TabIndex = 127;
            this.tb_mapArea.Text = "\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n                                                               " +
    "                                                                    載入中...\r\n\r\n";
            // 
            // lv_image
            // 
            this.lv_image.AllowDrop = true;
            this.lv_image.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lv_image.LabelEdit = true;
            this.lv_image.Location = new System.Drawing.Point(5, 16);
            this.lv_image.Margin = new System.Windows.Forms.Padding(5);
            this.lv_image.MultiSelect = false;
            this.lv_image.Name = "lv_image";
            this.lv_image.Size = new System.Drawing.Size(224, 468);
            this.lv_image.TabIndex = 1;
            this.lv_image.UseCompatibleStateImageBehavior = false;
            this.lv_image.Visible = false;
            // 
            // iml_jpg
            // 
            this.iml_jpg.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.iml_jpg.ImageSize = new System.Drawing.Size(40, 40);
            this.iml_jpg.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 21);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 18);
            this.label6.TabIndex = 23;
            this.label6.Text = "名稱";
            // 
            // tb_map
            // 
            this.tb_map.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.tb_map.Location = new System.Drawing.Point(63, 18);
            this.tb_map.Margin = new System.Windows.Forms.Padding(5);
            this.tb_map.Name = "tb_map";
            this.tb_map.Size = new System.Drawing.Size(372, 25);
            this.tb_map.TabIndex = 24;
            // 
            // iml_png
            // 
            this.iml_png.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.iml_png.ImageSize = new System.Drawing.Size(40, 40);
            this.iml_png.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // iml_gif
            // 
            this.iml_gif.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.iml_gif.ImageSize = new System.Drawing.Size(16, 16);
            this.iml_gif.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // iml_bmp
            // 
            this.iml_bmp.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.iml_bmp.ImageSize = new System.Drawing.Size(16, 16);
            this.iml_bmp.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // lb_teleportNo
            // 
            this.lb_teleportNo.AutoSize = true;
            this.lb_teleportNo.Location = new System.Drawing.Point(13, 15);
            this.lb_teleportNo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lb_teleportNo.Name = "lb_teleportNo";
            this.lb_teleportNo.Size = new System.Drawing.Size(90, 18);
            this.lb_teleportNo.TabIndex = 62;
            this.lb_teleportNo.Text = "新增傳送到...";
            // 
            // pl_angle
            // 
            this.pl_angle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.pl_angle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pl_angle.Controls.Add(this.textBox2);
            this.pl_angle.Controls.Add(this.textBox1);
            this.pl_angle.Location = new System.Drawing.Point(63, 57);
            this.pl_angle.Margin = new System.Windows.Forms.Padding(5);
            this.pl_angle.Name = "pl_angle";
            this.pl_angle.Size = new System.Drawing.Size(373, 30);
            this.pl_angle.TabIndex = 93;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.textBox2.Location = new System.Drawing.Point(232, 2);
            this.textBox2.Margin = new System.Windows.Forms.Padding(5);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(123, 25);
            this.textBox2.TabIndex = 134;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.textBox1.Location = new System.Drawing.Point(5, 2);
            this.textBox1.Margin = new System.Windows.Forms.Padding(5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(131, 25);
            this.textBox1.TabIndex = 133;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 60);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 18);
            this.label5.TabIndex = 95;
            this.label5.Text = "經緯度";
            // 
            // lb_mapName
            // 
            this.lb_mapName.AutoSize = true;
            this.lb_mapName.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lb_mapName.Location = new System.Drawing.Point(256, 27);
            this.lb_mapName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lb_mapName.Name = "lb_mapName";
            this.lb_mapName.Size = new System.Drawing.Size(197, 20);
            this.lb_mapName.TabIndex = 96;
            this.lb_mapName.Text = "地圖編輯區　(未命名地圖)";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bt_importimage,
            this.toolStripSeparator2,
            this.bt_readMap,
            this.bt_saveMap,
            this.toolStripSeparator3,
            this.toolStripDropDownButton1,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.tb_size,
            this.toolStripProgressBar1,
            this.toolStripLb_per});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1254, 31);
            this.toolStrip1.TabIndex = 105;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // bt_importimage
            // 
            this.bt_importimage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.選擇檔案ToolStripMenuItem,
            this.選擇資料夾ToolStripMenuItem});
            this.bt_importimage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bt_importimage.Name = "bt_importimage";
            this.bt_importimage.Size = new System.Drawing.Size(124, 28);
            this.bt_importimage.Text = "匯入圖片素材(&O)";
            // 
            // 選擇檔案ToolStripMenuItem
            // 
            this.選擇檔案ToolStripMenuItem.Name = "選擇檔案ToolStripMenuItem";
            this.選擇檔案ToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.選擇檔案ToolStripMenuItem.Text = "選擇檔案";
            // 
            // 選擇資料夾ToolStripMenuItem
            // 
            this.選擇資料夾ToolStripMenuItem.Name = "選擇資料夾ToolStripMenuItem";
            this.選擇資料夾ToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.選擇資料夾ToolStripMenuItem.Text = "選擇資料夾";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // bt_readMap
            // 
            this.bt_readMap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bt_readMap.Name = "bt_readMap";
            this.bt_readMap.Size = new System.Drawing.Size(85, 28);
            this.bt_readMap.Text = "讀取地圖(&R)";
            // 
            // bt_saveMap
            // 
            this.bt_saveMap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bt_saveMap.Name = "bt_saveMap";
            this.bt_saveMap.Size = new System.Drawing.Size(84, 28);
            this.bt_saveMap.Text = "儲存地圖(&S)";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.框線ToolStripMenuItem,
            this.前景ToolStripMenuItem,
            this.背景ToolStripMenuItem,
            this.傳送點ToolStripMenuItem,
            this.能否行走ToolStripMenuItem,
            this.地圖邊界ToolStripMenuItem});
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(49, 28);
            this.toolStripDropDownButton1.Text = "檢視";
            // 
            // 框線ToolStripMenuItem
            // 
            this.框線ToolStripMenuItem.Checked = true;
            this.框線ToolStripMenuItem.CheckOnClick = true;
            this.框線ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.框線ToolStripMenuItem.Name = "框線ToolStripMenuItem";
            this.框線ToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.框線ToolStripMenuItem.Text = "框線";
            // 
            // 前景ToolStripMenuItem
            // 
            this.前景ToolStripMenuItem.Checked = true;
            this.前景ToolStripMenuItem.CheckOnClick = true;
            this.前景ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.前景ToolStripMenuItem.Name = "前景ToolStripMenuItem";
            this.前景ToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.前景ToolStripMenuItem.Text = "前景";
            // 
            // 背景ToolStripMenuItem
            // 
            this.背景ToolStripMenuItem.Checked = true;
            this.背景ToolStripMenuItem.CheckOnClick = true;
            this.背景ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.背景ToolStripMenuItem.Name = "背景ToolStripMenuItem";
            this.背景ToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.背景ToolStripMenuItem.Text = "背景";
            // 
            // 傳送點ToolStripMenuItem
            // 
            this.傳送點ToolStripMenuItem.Checked = true;
            this.傳送點ToolStripMenuItem.CheckOnClick = true;
            this.傳送點ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.傳送點ToolStripMenuItem.Name = "傳送點ToolStripMenuItem";
            this.傳送點ToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.傳送點ToolStripMenuItem.Text = "傳送點";
            // 
            // 能否行走ToolStripMenuItem
            // 
            this.能否行走ToolStripMenuItem.Checked = true;
            this.能否行走ToolStripMenuItem.CheckOnClick = true;
            this.能否行走ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.能否行走ToolStripMenuItem.Name = "能否行走ToolStripMenuItem";
            this.能否行走ToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.能否行走ToolStripMenuItem.Text = "能否行走";
            // 
            // 地圖邊界ToolStripMenuItem
            // 
            this.地圖邊界ToolStripMenuItem.Checked = true;
            this.地圖邊界ToolStripMenuItem.CheckOnClick = true;
            this.地圖邊界ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.地圖邊界ToolStripMenuItem.Name = "地圖邊界ToolStripMenuItem";
            this.地圖邊界ToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.地圖邊界ToolStripMenuItem.Text = "地圖邊界";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(64, 28);
            this.toolStripLabel1.Text = "顯示比例";
            // 
            // tb_size
            // 
            this.tb_size.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.tb_size.Name = "tb_size";
            this.tb_size.Size = new System.Drawing.Size(56, 31);
            this.tb_size.Text = "100%";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Margin = new System.Windows.Forms.Padding(5, 2, 1, 1);
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(400, 28);
            // 
            // toolStripLb_per
            // 
            this.toolStripLb_per.Name = "toolStripLb_per";
            this.toolStripLb_per.Size = new System.Drawing.Size(28, 28);
            this.toolStripLb_per.Text = "0%";
            // 
            // pl_MSG
            // 
            this.pl_MSG.BackColor = System.Drawing.Color.Black;
            this.pl_MSG.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pl_MSG.Controls.Add(this.lb_MSG);
            this.pl_MSG.Location = new System.Drawing.Point(12, 526);
            this.pl_MSG.Name = "pl_MSG";
            this.pl_MSG.Size = new System.Drawing.Size(1241, 45);
            this.pl_MSG.TabIndex = 106;
            // 
            // lb_MSG
            // 
            this.lb_MSG.AutoSize = true;
            this.lb_MSG.BackColor = System.Drawing.Color.Transparent;
            this.lb_MSG.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lb_MSG.ForeColor = System.Drawing.Color.LightGreen;
            this.lb_MSG.Location = new System.Drawing.Point(2, 2);
            this.lb_MSG.Name = "lb_MSG";
            this.lb_MSG.Size = new System.Drawing.Size(169, 20);
            this.lb_MSG.TabIndex = 0;
            this.lb_MSG.Text = "讀取中，請稍候．．．";
            // 
            // lb_imageorMap
            // 
            this.lb_imageorMap.AutoSize = true;
            this.lb_imageorMap.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lb_imageorMap.Location = new System.Drawing.Point(79, -1);
            this.lb_imageorMap.Name = "lb_imageorMap";
            this.lb_imageorMap.Size = new System.Drawing.Size(73, 20);
            this.lb_imageorMap.TabIndex = 108;
            this.lb_imageorMap.Text = "圖片素材";
            // 
            // bt_sizeUp
            // 
            this.bt_sizeUp.Font = new System.Drawing.Font("新細明體", 4.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bt_sizeUp.Location = new System.Drawing.Point(470, 2);
            this.bt_sizeUp.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.bt_sizeUp.Name = "bt_sizeUp";
            this.bt_sizeUp.Size = new System.Drawing.Size(20, 14);
            this.bt_sizeUp.TabIndex = 111;
            this.bt_sizeUp.Text = "▲";
            this.bt_sizeUp.UseVisualStyleBackColor = true;
            // 
            // bt_sizeDown
            // 
            this.bt_sizeDown.Font = new System.Drawing.Font("新細明體", 4.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bt_sizeDown.Location = new System.Drawing.Point(470, 14);
            this.bt_sizeDown.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.bt_sizeDown.Name = "bt_sizeDown";
            this.bt_sizeDown.Size = new System.Drawing.Size(20, 14);
            this.bt_sizeDown.TabIndex = 112;
            this.bt_sizeDown.Text = "▼";
            this.bt_sizeDown.UseVisualStyleBackColor = true;
            // 
            // pl_teleportArea
            // 
            this.pl_teleportArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.pl_teleportArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pl_teleportArea.Controls.Add(this.button_createTeleport);
            this.pl_teleportArea.Controls.Add(this.button_deleteTeleport);
            this.pl_teleportArea.Controls.Add(this.comboBox_tpLoction);
            this.pl_teleportArea.Controls.Add(this.label2);
            this.pl_teleportArea.Controls.Add(this.comboBox_newtpLoction);
            this.pl_teleportArea.Controls.Add(this.lb_teleportNo);
            this.pl_teleportArea.Location = new System.Drawing.Point(12, 70);
            this.pl_teleportArea.Name = "pl_teleportArea";
            this.pl_teleportArea.Size = new System.Drawing.Size(440, 85);
            this.pl_teleportArea.TabIndex = 125;
            // 
            // button_createTeleport
            // 
            this.button_createTeleport.Location = new System.Drawing.Point(360, 13);
            this.button_createTeleport.Name = "button_createTeleport";
            this.button_createTeleport.Size = new System.Drawing.Size(75, 23);
            this.button_createTeleport.TabIndex = 89;
            this.button_createTeleport.Text = "新增";
            this.button_createTeleport.UseVisualStyleBackColor = true;
            this.button_createTeleport.Click += new System.EventHandler(this.button_createTeleport_Click);
            // 
            // button_deleteTeleport
            // 
            this.button_deleteTeleport.Location = new System.Drawing.Point(360, 45);
            this.button_deleteTeleport.Name = "button_deleteTeleport";
            this.button_deleteTeleport.Size = new System.Drawing.Size(75, 23);
            this.button_deleteTeleport.TabIndex = 88;
            this.button_deleteTeleport.Text = "刪除";
            this.button_deleteTeleport.UseVisualStyleBackColor = true;
            this.button_deleteTeleport.Click += new System.EventHandler(this.button_deleteTeleport_Click);
            // 
            // comboBox_tpLoction
            // 
            this.comboBox_tpLoction.FormattingEnabled = true;
            this.comboBox_tpLoction.Location = new System.Drawing.Point(111, 43);
            this.comboBox_tpLoction.Name = "comboBox_tpLoction";
            this.comboBox_tpLoction.Size = new System.Drawing.Size(243, 26);
            this.comboBox_tpLoction.TabIndex = 87;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 18);
            this.label2.TabIndex = 86;
            this.label2.Text = "會傳送的地點";
            // 
            // comboBox_newtpLoction
            // 
            this.comboBox_newtpLoction.FormattingEnabled = true;
            this.comboBox_newtpLoction.Location = new System.Drawing.Point(111, 12);
            this.comboBox_newtpLoction.Name = "comboBox_newtpLoction";
            this.comboBox_newtpLoction.Size = new System.Drawing.Size(243, 26);
            this.comboBox_newtpLoction.TabIndex = 85;
            // 
            // cb_donotAlertOverrideMap
            // 
            this.cb_donotAlertOverrideMap.AutoSize = true;
            this.cb_donotAlertOverrideMap.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cb_donotAlertOverrideMap.Checked = true;
            this.cb_donotAlertOverrideMap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_donotAlertOverrideMap.Location = new System.Drawing.Point(446, 62);
            this.cb_donotAlertOverrideMap.Name = "cb_donotAlertOverrideMap";
            this.cb_donotAlertOverrideMap.Size = new System.Drawing.Size(167, 22);
            this.cb_donotAlertOverrideMap.TabIndex = 133;
            this.cb_donotAlertOverrideMap.Text = "不要提醒我有同名地圖";
            this.cb_donotAlertOverrideMap.UseVisualStyleBackColor = true;
            this.cb_donotAlertOverrideMap.CheckedChanged += new System.EventHandler(this.cb_donotAlertOverrideMap_CheckedChanged);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.rb_useBack);
            this.panel4.Controls.Add(this.rb_useFore);
            this.panel4.Location = new System.Drawing.Point(12, 17);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(155, 41);
            this.panel4.TabIndex = 128;
            // 
            // rb_useBack
            // 
            this.rb_useBack.AutoSize = true;
            this.rb_useBack.Checked = true;
            this.rb_useBack.Location = new System.Drawing.Point(80, 11);
            this.rb_useBack.Name = "rb_useBack";
            this.rb_useBack.Size = new System.Drawing.Size(54, 22);
            this.rb_useBack.TabIndex = 1;
            this.rb_useBack.TabStop = true;
            this.rb_useBack.Text = "背景";
            this.rb_useBack.UseVisualStyleBackColor = true;
            // 
            // rb_useFore
            // 
            this.rb_useFore.AutoSize = true;
            this.rb_useFore.Location = new System.Drawing.Point(9, 11);
            this.rb_useFore.Name = "rb_useFore";
            this.rb_useFore.Size = new System.Drawing.Size(54, 22);
            this.rb_useFore.TabIndex = 0;
            this.rb_useFore.Text = "前景";
            this.rb_useFore.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.tb_lv_imageloading);
            this.panel5.Controls.Add(this.lv_map);
            this.panel5.Controls.Add(this.lv_image);
            this.panel5.Location = new System.Drawing.Point(12, 12);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(236, 486);
            this.panel5.TabIndex = 129;
            // 
            // tb_lv_imageloading
            // 
            this.tb_lv_imageloading.BackColor = System.Drawing.SystemColors.Window;
            this.tb_lv_imageloading.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_lv_imageloading.Enabled = false;
            this.tb_lv_imageloading.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tb_lv_imageloading.Location = new System.Drawing.Point(-1, -1);
            this.tb_lv_imageloading.Multiline = true;
            this.tb_lv_imageloading.Name = "tb_lv_imageloading";
            this.tb_lv_imageloading.Size = new System.Drawing.Size(236, 481);
            this.tb_lv_imageloading.TabIndex = 137;
            this.tb_lv_imageloading.Text = "\r\n\r\n\r\n\r\n\r\n\r\n載入中...";
            this.tb_lv_imageloading.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lv_map
            // 
            this.lv_map.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lv_map.LabelEdit = true;
            this.lv_map.Location = new System.Drawing.Point(5, 16);
            this.lv_map.Margin = new System.Windows.Forms.Padding(5);
            this.lv_map.MultiSelect = false;
            this.lv_map.Name = "lv_map";
            this.lv_map.Size = new System.Drawing.Size(224, 464);
            this.lv_map.TabIndex = 138;
            this.lv_map.UseCompatibleStateImageBehavior = false;
            this.lv_map.Visible = false;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.lb_imageorMap);
            this.panel6.Controls.Add(this.panel5);
            this.panel6.Location = new System.Drawing.Point(0, 28);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(254, 499);
            this.panel6.TabIndex = 130;
            // 
            // pl_mapSetting
            // 
            this.pl_mapSetting.BackColor = System.Drawing.SystemColors.Control;
            this.pl_mapSetting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pl_mapSetting.Controls.Add(this.cb_donotAlertOverrideMap);
            this.pl_mapSetting.Controls.Add(this.cb_allSave);
            this.pl_mapSetting.Controls.Add(this.label12);
            this.pl_mapSetting.Controls.Add(this.panel7);
            this.pl_mapSetting.Controls.Add(this.label6);
            this.pl_mapSetting.Controls.Add(this.tb_map);
            this.pl_mapSetting.Controls.Add(this.label5);
            this.pl_mapSetting.Controls.Add(this.pl_angle);
            this.pl_mapSetting.Location = new System.Drawing.Point(260, 342);
            this.pl_mapSetting.Name = "pl_mapSetting";
            this.pl_mapSetting.Size = new System.Drawing.Size(614, 185);
            this.pl_mapSetting.TabIndex = 133;
            this.pl_mapSetting.Visible = false;
            // 
            // cb_allSave
            // 
            this.cb_allSave.AutoSize = true;
            this.cb_allSave.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cb_allSave.Location = new System.Drawing.Point(446, 21);
            this.cb_allSave.Name = "cb_allSave";
            this.cb_allSave.Size = new System.Drawing.Size(153, 22);
            this.cb_allSave.TabIndex = 132;
            this.cb_allSave.Text = "相同的地圖一併修改";
            this.cb_allSave.UseVisualStyleBackColor = true;
            this.cb_allSave.CheckedChanged += new System.EventHandler(this.cb_forceSave_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label12.Location = new System.Drawing.Point(11, 91);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(36, 18);
            this.label12.TabIndex = 124;
            this.label12.Text = "大小";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.bt_colUp);
            this.panel7.Controls.Add(this.bt_colDown);
            this.panel7.Controls.Add(this.bt_rowUp);
            this.panel7.Controls.Add(this.bt_rowDown);
            this.panel7.Controls.Add(this.bt_widthUp);
            this.panel7.Controls.Add(this.bt_widthDown);
            this.panel7.Controls.Add(this.bt_heightUp);
            this.panel7.Controls.Add(this.bt_heightDown);
            this.panel7.Controls.Add(this.label3);
            this.panel7.Controls.Add(this.label4);
            this.panel7.Controls.Add(this.tb_col);
            this.panel7.Controls.Add(this.tb_row);
            this.panel7.Controls.Add(this.label1);
            this.panel7.Controls.Add(this.tb_height);
            this.panel7.Controls.Add(this.label8);
            this.panel7.Controls.Add(this.tb_width);
            this.panel7.Location = new System.Drawing.Point(6, 101);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(595, 54);
            this.panel7.TabIndex = 131;
            // 
            // bt_colUp
            // 
            this.bt_colUp.Font = new System.Drawing.Font("新細明體", 4.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bt_colUp.Location = new System.Drawing.Point(77, 15);
            this.bt_colUp.Name = "bt_colUp";
            this.bt_colUp.Size = new System.Drawing.Size(20, 14);
            this.bt_colUp.TabIndex = 129;
            this.bt_colUp.Text = "▲";
            this.bt_colUp.UseVisualStyleBackColor = true;
            // 
            // bt_colDown
            // 
            this.bt_colDown.Font = new System.Drawing.Font("新細明體", 4.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bt_colDown.Location = new System.Drawing.Point(77, 28);
            this.bt_colDown.Name = "bt_colDown";
            this.bt_colDown.Size = new System.Drawing.Size(20, 14);
            this.bt_colDown.TabIndex = 130;
            this.bt_colDown.Text = "▼";
            this.bt_colDown.UseVisualStyleBackColor = true;
            // 
            // bt_rowUp
            // 
            this.bt_rowUp.Font = new System.Drawing.Font("新細明體", 4.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bt_rowUp.Location = new System.Drawing.Point(242, 15);
            this.bt_rowUp.Name = "bt_rowUp";
            this.bt_rowUp.Size = new System.Drawing.Size(20, 14);
            this.bt_rowUp.TabIndex = 127;
            this.bt_rowUp.Text = "▲";
            this.bt_rowUp.UseVisualStyleBackColor = true;
            // 
            // bt_rowDown
            // 
            this.bt_rowDown.Font = new System.Drawing.Font("新細明體", 4.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bt_rowDown.Location = new System.Drawing.Point(242, 28);
            this.bt_rowDown.Name = "bt_rowDown";
            this.bt_rowDown.Size = new System.Drawing.Size(20, 14);
            this.bt_rowDown.TabIndex = 128;
            this.bt_rowDown.Text = "▼";
            this.bt_rowDown.UseVisualStyleBackColor = true;
            // 
            // bt_widthUp
            // 
            this.bt_widthUp.Font = new System.Drawing.Font("新細明體", 4.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bt_widthUp.Location = new System.Drawing.Point(408, 15);
            this.bt_widthUp.Name = "bt_widthUp";
            this.bt_widthUp.Size = new System.Drawing.Size(20, 14);
            this.bt_widthUp.TabIndex = 125;
            this.bt_widthUp.Text = "▲";
            this.bt_widthUp.UseVisualStyleBackColor = true;
            // 
            // bt_widthDown
            // 
            this.bt_widthDown.Font = new System.Drawing.Font("新細明體", 4.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bt_widthDown.Location = new System.Drawing.Point(408, 28);
            this.bt_widthDown.Name = "bt_widthDown";
            this.bt_widthDown.Size = new System.Drawing.Size(20, 14);
            this.bt_widthDown.TabIndex = 126;
            this.bt_widthDown.Text = "▼";
            this.bt_widthDown.UseVisualStyleBackColor = true;
            // 
            // bt_heightUp
            // 
            this.bt_heightUp.Font = new System.Drawing.Font("新細明體", 4.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bt_heightUp.Location = new System.Drawing.Point(560, 15);
            this.bt_heightUp.Name = "bt_heightUp";
            this.bt_heightUp.Size = new System.Drawing.Size(20, 14);
            this.bt_heightUp.TabIndex = 123;
            this.bt_heightUp.Text = "▲";
            this.bt_heightUp.UseVisualStyleBackColor = true;
            // 
            // bt_heightDown
            // 
            this.bt_heightDown.Font = new System.Drawing.Font("新細明體", 4.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bt_heightDown.Location = new System.Drawing.Point(560, 28);
            this.bt_heightDown.Name = "bt_heightDown";
            this.bt_heightDown.Size = new System.Drawing.Size(20, 14);
            this.bt_heightDown.TabIndex = 124;
            this.bt_heightDown.Text = "▼";
            this.bt_heightDown.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 18);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 18);
            this.label3.TabIndex = 14;
            this.label3.Text = "欄";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(171, 18);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 18);
            this.label4.TabIndex = 15;
            this.label4.Text = "列";
            // 
            // tb_col
            // 
            this.tb_col.Location = new System.Drawing.Point(36, 14);
            this.tb_col.Margin = new System.Windows.Forms.Padding(5);
            this.tb_col.Name = "tb_col";
            this.tb_col.Size = new System.Drawing.Size(62, 25);
            this.tb_col.TabIndex = 16;
            this.tb_col.Text = "65";
            // 
            // tb_row
            // 
            this.tb_row.Location = new System.Drawing.Point(202, 14);
            this.tb_row.Margin = new System.Windows.Forms.Padding(5);
            this.tb_row.Name = "tb_row";
            this.tb_row.Size = new System.Drawing.Size(61, 25);
            this.tb_row.TabIndex = 17;
            this.tb_row.Text = "57";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(491, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 18);
            this.label1.TabIndex = 30;
            this.label1.Text = "高";
            // 
            // tb_height
            // 
            this.tb_height.Location = new System.Drawing.Point(521, 14);
            this.tb_height.Margin = new System.Windows.Forms.Padding(5);
            this.tb_height.Name = "tb_height";
            this.tb_height.Size = new System.Drawing.Size(60, 25);
            this.tb_height.TabIndex = 31;
            this.tb_height.Text = "32";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(338, 18);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 18);
            this.label8.TabIndex = 32;
            this.label8.Text = "寬";
            // 
            // tb_width
            // 
            this.tb_width.Location = new System.Drawing.Point(368, 14);
            this.tb_width.Margin = new System.Windows.Forms.Padding(5);
            this.tb_width.Name = "tb_width";
            this.tb_width.Size = new System.Drawing.Size(61, 25);
            this.tb_width.TabIndex = 33;
            this.tb_width.Text = "32";
            // 
            // lb_mapSetting
            // 
            this.lb_mapSetting.AutoSize = true;
            this.lb_mapSetting.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lb_mapSetting.Location = new System.Drawing.Point(268, 329);
            this.lb_mapSetting.Name = "lb_mapSetting";
            this.lb_mapSetting.Size = new System.Drawing.Size(73, 20);
            this.lb_mapSetting.TabIndex = 132;
            this.lb_mapSetting.Text = "地圖設定";
            // 
            // pl_gridSetting
            // 
            this.pl_gridSetting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pl_gridSetting.Controls.Add(this.label17);
            this.pl_gridSetting.Controls.Add(this.pl_teleportArea);
            this.pl_gridSetting.Controls.Add(this.label18);
            this.pl_gridSetting.Controls.Add(this.panel4);
            this.pl_gridSetting.Location = new System.Drawing.Point(789, 342);
            this.pl_gridSetting.Name = "pl_gridSetting";
            this.pl_gridSetting.Size = new System.Drawing.Size(464, 185);
            this.pl_gridSetting.TabIndex = 134;
            this.pl_gridSetting.Visible = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label17.Location = new System.Drawing.Point(23, 61);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(50, 18);
            this.label17.TabIndex = 130;
            this.label17.Text = "傳送點";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label18.Location = new System.Drawing.Point(22, 7);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(64, 18);
            this.label18.TabIndex = 126;
            this.label18.Text = "操作目標";
            // 
            // bt_gridSetting
            // 
            this.bt_gridSetting.Location = new System.Drawing.Point(1167, 502);
            this.bt_gridSetting.Name = "bt_gridSetting";
            this.bt_gridSetting.Size = new System.Drawing.Size(45, 26);
            this.bt_gridSetting.TabIndex = 136;
            this.bt_gridSetting.Text = "︽";
            this.bt_gridSetting.UseVisualStyleBackColor = true;
            // 
            // lb_gridSetting
            // 
            this.lb_gridSetting.AutoSize = true;
            this.lb_gridSetting.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lb_gridSetting.Location = new System.Drawing.Point(973, 329);
            this.lb_gridSetting.Name = "lb_gridSetting";
            this.lb_gridSetting.Size = new System.Drawing.Size(73, 20);
            this.lb_gridSetting.TabIndex = 135;
            this.lb_gridSetting.Text = "格子設定";
            // 
            // bt_mapSetting
            // 
            this.bt_mapSetting.Location = new System.Drawing.Point(539, 501);
            this.bt_mapSetting.Name = "bt_mapSetting";
            this.bt_mapSetting.Size = new System.Drawing.Size(45, 26);
            this.bt_mapSetting.TabIndex = 132;
            this.bt_mapSetting.Text = "︽";
            this.bt_mapSetting.UseVisualStyleBackColor = true;
            // 
            // iml_map
            // 
            this.iml_map.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.iml_map.ImageSize = new System.Drawing.Size(40, 40);
            this.iml_map.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1254, 574);
            this.Controls.Add(this.bt_sizeDown);
            this.Controls.Add(this.bt_sizeUp);
            this.Controls.Add(this.lb_gridSetting);
            this.Controls.Add(this.lb_mapSetting);
            this.Controls.Add(this.bt_gridSetting);
            this.Controls.Add(this.bt_mapSetting);
            this.Controls.Add(this.pl_gridSetting);
            this.Controls.Add(this.pl_mapSetting);
            this.Controls.Add(this.pl_MSG);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.tb_mapArea);
            this.Controls.Add(this.container);
            this.Controls.Add(this.lb_mapName);
            this.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Form1";
            this.Text = "地圖編輯器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.pl_angle.ResumeLayout(false);
            this.pl_angle.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pl_MSG.ResumeLayout(false);
            this.pl_MSG.PerformLayout();
            this.pl_teleportArea.ResumeLayout(false);
            this.pl_teleportArea.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.pl_mapSetting.ResumeLayout(false);
            this.pl_mapSetting.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.pl_gridSetting.ResumeLayout(false);
            this.pl_gridSetting.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListView lv_image;
        private ImageList iml_jpg;
        private Label label6;
        private TextBox tb_map;
        private ImageList iml_png;
        private ImageList iml_gif;
        private ImageList iml_bmp;
        private Label lb_teleportNo;
        private Panel pl_angle;
        private Label label5;
        private Label lb_mapName;
        private SharpDX.Windows.RenderControl container;
        private ToolStrip toolStrip1;
        private ToolStripDropDownButton bt_importimage;
        private ToolStripButton bt_saveMap;
        private ToolStripButton bt_readMap;
        private Panel pl_MSG;
        private Label lb_MSG;
        private Label lb_imageorMap;
        private Button bt_sizeUp;
        private Button bt_sizeDown;
        private Panel pl_teleportArea;
        private TextBox tb_mapArea;
        private Panel panel4;
        private RadioButton rb_useBack;
        private RadioButton rb_useFore;
        private Panel panel5;
        private Panel panel6;
        private Panel pl_mapSetting;
        private Label label12;
        private Panel panel7;
        private Label label3;
        private Label label4;
        private TextBox tb_col;
        private TextBox tb_row;
        private Label label1;
        private TextBox tb_height;
        private Label label8;
        private TextBox tb_width;
        private Label lb_mapSetting;
        private Button bt_colUp;
        private Button bt_colDown;
        private Button bt_rowUp;
        private Button bt_rowDown;
        private Button bt_widthUp;
        private Button bt_widthDown;
        private Button bt_heightUp;
        private Button bt_heightDown;
        private Panel pl_gridSetting;
        private Label lb_gridSetting;
        private Label label18;
        private Button bt_gridSetting;
        private Button bt_mapSetting;
        private Label label17;
        private TextBox tb_lv_imageloading;
        private ListView lv_map;
        private ImageList iml_map;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem 框線ToolStripMenuItem;
        private ToolStripMenuItem 前景ToolStripMenuItem;
        private ToolStripMenuItem 背景ToolStripMenuItem;
        private ToolStripMenuItem 傳送點ToolStripMenuItem;
        private ToolStripMenuItem 能否行走ToolStripMenuItem;
        private ToolStripMenuItem 地圖邊界ToolStripMenuItem;
        private ToolStripLabel toolStripLabel1;
        private ToolStripTextBox tb_size;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripProgressBar toolStripProgressBar1;
        private ToolStripLabel toolStripLb_per;
        private ToolStripMenuItem 選擇檔案ToolStripMenuItem;
        private ToolStripMenuItem 選擇資料夾ToolStripMenuItem;
        private CheckBox cb_allSave;
        private TextBox textBox2;
        private TextBox textBox1;
        private ComboBox comboBox_newtpLoction;
        private ComboBox comboBox_tpLoction;
        private Label label2;
        private Button button_deleteTeleport;
        private Button button_createTeleport;
        private CheckBox cb_donotAlertOverrideMap;
    }
}

