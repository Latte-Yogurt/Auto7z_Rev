
namespace Auto7z_Rev
{
    partial class Auto7zMainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Auto7zMainForm));
            this.TextBoxPassword = new System.Windows.Forms.TextBox();
            this.CheckBoxAutoSave = new System.Windows.Forms.CheckBox();
            this.LabelPassword = new System.Windows.Forms.Label();
            this.LabelFormat = new System.Windows.Forms.Label();
            this.ComboBoxFormat = new System.Windows.Forms.ComboBox();
            this.CheckBoxZstd = new System.Windows.Forms.CheckBox();
            this.LabelUnit = new System.Windows.Forms.Label();
            this.TextBoxSize = new System.Windows.Forms.TextBox();
            this.LabelSize = new System.Windows.Forms.Label();
            this.ButtonConfig = new System.Windows.Forms.Button();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.LanguageMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.LanguageMenuSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.ZHCNItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ZHTWItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ENUSItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionMenuDisableVolume = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionMenuGenerateMD5 = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutAuto7zRev = new System.Windows.Forms.ToolStripMenuItem();
            this.MainPanel.SuspendLayout();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextBoxPassword
            // 
            this.TextBoxPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TextBoxPassword.Location = new System.Drawing.Point(170, 286);
            this.TextBoxPassword.Name = "TextBoxPassword";
            this.TextBoxPassword.Size = new System.Drawing.Size(182, 31);
            this.TextBoxPassword.TabIndex = 9;
            this.TextBoxPassword.TextChanged += new System.EventHandler(this.TEXTBOX_PASSWORD_TEXT_CHANGED);
            // 
            // CheckBoxAutoSave
            // 
            this.CheckBoxAutoSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CheckBoxAutoSave.Location = new System.Drawing.Point(12, 402);
            this.CheckBoxAutoSave.Name = "CheckBoxAutoSave";
            this.CheckBoxAutoSave.Size = new System.Drawing.Size(240, 30);
            this.CheckBoxAutoSave.TabIndex = 11;
            this.CheckBoxAutoSave.Text = "程序关闭时自动保存配置";
            this.CheckBoxAutoSave.UseVisualStyleBackColor = true;
            this.CheckBoxAutoSave.CheckedChanged += new System.EventHandler(this.CHECKBOX_AUTOSAVE_CHECKED_CHANGED);
            // 
            // LabelPassword
            // 
            this.LabelPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LabelPassword.AutoSize = true;
            this.LabelPassword.Location = new System.Drawing.Point(78, 289);
            this.LabelPassword.Name = "LabelPassword";
            this.LabelPassword.Size = new System.Drawing.Size(86, 24);
            this.LabelPassword.TabIndex = 4;
            this.LabelPassword.Text = "添加密码:";
            this.LabelPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelFormat
            // 
            this.LabelFormat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LabelFormat.AutoSize = true;
            this.LabelFormat.Location = new System.Drawing.Point(78, 214);
            this.LabelFormat.Name = "LabelFormat";
            this.LabelFormat.Size = new System.Drawing.Size(86, 24);
            this.LabelFormat.TabIndex = 2;
            this.LabelFormat.Text = "生成格式:";
            this.LabelFormat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ComboBoxFormat
            // 
            this.ComboBoxFormat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ComboBoxFormat.Cursor = System.Windows.Forms.Cursors.Default;
            this.ComboBoxFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxFormat.FormattingEnabled = true;
            this.ComboBoxFormat.Location = new System.Drawing.Point(170, 211);
            this.ComboBoxFormat.Name = "ComboBoxFormat";
            this.ComboBoxFormat.Size = new System.Drawing.Size(143, 32);
            this.ComboBoxFormat.TabIndex = 7;
            this.ComboBoxFormat.SelectedIndexChanged += new System.EventHandler(this.COMBOBOX_FORMAT_SELECTED_INDEX_CHANGED);
            // 
            // CheckBoxZstd
            // 
            this.CheckBoxZstd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CheckBoxZstd.AutoSize = true;
            this.CheckBoxZstd.Location = new System.Drawing.Point(319, 213);
            this.CheckBoxZstd.Name = "CheckBoxZstd";
            this.CheckBoxZstd.Size = new System.Drawing.Size(70, 28);
            this.CheckBoxZstd.TabIndex = 8;
            this.CheckBoxZstd.Text = "zstd";
            this.CheckBoxZstd.UseVisualStyleBackColor = true;
            this.CheckBoxZstd.CheckedChanged += new System.EventHandler(this.CHECKBOX_ZSTD_CHECKED_CHANGED);
            // 
            // LabelUnit
            // 
            this.LabelUnit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LabelUnit.AutoSize = true;
            this.LabelUnit.Location = new System.Drawing.Point(319, 140);
            this.LabelUnit.Name = "LabelUnit";
            this.LabelUnit.Size = new System.Drawing.Size(37, 24);
            this.LabelUnit.TabIndex = 6;
            this.LabelUnit.Text = "MB";
            this.LabelUnit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TextBoxSize
            // 
            this.TextBoxSize.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TextBoxSize.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.TextBoxSize.Location = new System.Drawing.Point(170, 137);
            this.TextBoxSize.Name = "TextBoxSize";
            this.TextBoxSize.Size = new System.Drawing.Size(143, 31);
            this.TextBoxSize.TabIndex = 5;
            this.TextBoxSize.TextChanged += new System.EventHandler(this.TEXTBOX_SIZE_TEXT_CHANGED);
            this.TextBoxSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TEXTBOX_SIZE_KEYPRESS);
            // 
            // LabelSize
            // 
            this.LabelSize.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LabelSize.AutoSize = true;
            this.LabelSize.Location = new System.Drawing.Point(78, 140);
            this.LabelSize.Name = "LabelSize";
            this.LabelSize.Size = new System.Drawing.Size(86, 24);
            this.LabelSize.TabIndex = 1;
            this.LabelSize.Text = "分卷大小:";
            this.LabelSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ButtonConfig
            // 
            this.ButtonConfig.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ButtonConfig.Location = new System.Drawing.Point(296, 382);
            this.ButtonConfig.Name = "ButtonConfig";
            this.ButtonConfig.Size = new System.Drawing.Size(170, 50);
            this.ButtonConfig.TabIndex = 10;
            this.ButtonConfig.Text = "保存配置";
            this.ButtonConfig.UseVisualStyleBackColor = true;
            this.ButtonConfig.Click += new System.EventHandler(this.BUTTON_CONFIG_CLICK);
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.CheckBoxAutoSave);
            this.MainPanel.Controls.Add(this.MenuStrip);
            this.MainPanel.Controls.Add(this.ButtonConfig);
            this.MainPanel.Controls.Add(this.TextBoxSize);
            this.MainPanel.Controls.Add(this.LabelSize);
            this.MainPanel.Controls.Add(this.ComboBoxFormat);
            this.MainPanel.Controls.Add(this.LabelUnit);
            this.MainPanel.Controls.Add(this.CheckBoxZstd);
            this.MainPanel.Controls.Add(this.TextBoxPassword);
            this.MainPanel.Controls.Add(this.LabelPassword);
            this.MainPanel.Controls.Add(this.LabelFormat);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(478, 444);
            this.MainPanel.TabIndex = 1;
            // 
            // MenuStrip
            // 
            this.MenuStrip.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.MenuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LanguageMenu,
            this.OptionMenu,
            this.AboutMenu});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(478, 32);
            this.MenuStrip.TabIndex = 10;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // LanguageMenu
            // 
            this.LanguageMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LanguageMenuSelect});
            this.LanguageMenu.Name = "LanguageMenu";
            this.LanguageMenu.Size = new System.Drawing.Size(62, 28);
            this.LanguageMenu.Text = "语言";
            // 
            // LanguageMenuSelect
            // 
            this.LanguageMenuSelect.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ZHCNItem,
            this.ZHTWItem,
            this.ENUSItem});
            this.LanguageMenuSelect.Name = "LanguageMenuSelect";
            this.LanguageMenuSelect.Size = new System.Drawing.Size(182, 34);
            this.LanguageMenuSelect.Text = "选择语言";
            // 
            // ZHCNItem
            // 
            this.ZHCNItem.Name = "ZHCNItem";
            this.ZHCNItem.Size = new System.Drawing.Size(182, 34);
            this.ZHCNItem.Text = "简体中文";
            this.ZHCNItem.Click += new System.EventHandler(this.LANGUAGE_MENU_SELECT_zhCN_CLICK);
            // 
            // ZHTWItem
            // 
            this.ZHTWItem.Name = "ZHTWItem";
            this.ZHTWItem.Size = new System.Drawing.Size(182, 34);
            this.ZHTWItem.Text = "繁體中文";
            this.ZHTWItem.Click += new System.EventHandler(this.LANGUAGE_MENU_SELECT_zhTW_CLICK);
            // 
            // ENUSItem
            // 
            this.ENUSItem.Name = "ENUSItem";
            this.ENUSItem.Size = new System.Drawing.Size(182, 34);
            this.ENUSItem.Text = "English";
            this.ENUSItem.Click += new System.EventHandler(this.LANGUAGE_MENU_SELECT_enUS_CLICK);
            // 
            // OptionMenu
            // 
            this.OptionMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OptionMenuDisableVolume,
            this.OptionMenuGenerateMD5});
            this.OptionMenu.Name = "OptionMenu";
            this.OptionMenu.Size = new System.Drawing.Size(62, 28);
            this.OptionMenu.Text = "选项";
            // 
            // OptionMenuDisableVolume
            // 
            this.OptionMenuDisableVolume.Name = "OptionMenuDisableVolume";
            this.OptionMenuDisableVolume.Size = new System.Drawing.Size(315, 34);
            this.OptionMenuDisableVolume.Text = "禁用分卷";
            this.OptionMenuDisableVolume.CheckedChanged += new System.EventHandler(this.OPTION_MENU_DISABLE_VOLUME_CHECKED_CHANGED);
            this.OptionMenuDisableVolume.Click += new System.EventHandler(this.OPTION_MENU_DISABLE_VOLUME_CLICK);
            // 
            // OptionMenuGenerateMD5
            // 
            this.OptionMenuGenerateMD5.Name = "OptionMenuGenerateMD5";
            this.OptionMenuGenerateMD5.Size = new System.Drawing.Size(315, 34);
            this.OptionMenuGenerateMD5.Text = "压缩完成后生成MD5文件";
            this.OptionMenuGenerateMD5.CheckedChanged += new System.EventHandler(this.OPTION_MENU_GENERATE_MD5_CHECKED_CHANGED);
            this.OptionMenuGenerateMD5.Click += new System.EventHandler(this.OPTION_MENU_GENERATE_MD5_CLICK);
            // 
            // AboutMenu
            // 
            this.AboutMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutAuto7zRev});
            this.AboutMenu.Name = "AboutMenu";
            this.AboutMenu.Size = new System.Drawing.Size(62, 28);
            this.AboutMenu.Text = "关于";
            // 
            // AboutAuto7zRev
            // 
            this.AboutAuto7zRev.Name = "AboutAuto7zRev";
            this.AboutAuto7zRev.Size = new System.Drawing.Size(249, 34);
            this.AboutAuto7zRev.Text = "关于 Auto7z Rev";
            this.AboutAuto7zRev.Click += new System.EventHandler(this.ABOUT_AUTO7Z_REV_CLICK);
            // 
            // Auto7zMainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(478, 444);
            this.Controls.Add(this.MainPanel);
            this.Font = new System.Drawing.Font("微软雅黑 Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Auto7zMainForm";
            this.Text = "Auto7z";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AUTO7Z_MAINFORM_FORM_CLOSING);
            this.Load += new System.EventHandler(this.AUTO7Z_MAINFORM_LOAD);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MAINFORM_DRAGDROP);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MAINFORM_DRAGENTER);
            this.DragLeave += new System.EventHandler(this.MAINFORM_DRAGLEAVE);
            this.Resize += new System.EventHandler(this.AUTO7Z_MAINFORM_RESIZE);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label LabelSize;
        private System.Windows.Forms.Label LabelFormat;
        private System.Windows.Forms.Label LabelPassword;
        private System.Windows.Forms.TextBox TextBoxSize;
        private System.Windows.Forms.Label LabelUnit;
        private System.Windows.Forms.ComboBox ComboBoxFormat;
        private System.Windows.Forms.CheckBox CheckBoxZstd;
        private System.Windows.Forms.TextBox TextBoxPassword;
        private System.Windows.Forms.Button ButtonConfig;
        private System.Windows.Forms.CheckBox CheckBoxAutoSave;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem LanguageMenu;
        private System.Windows.Forms.ToolStripMenuItem LanguageMenuSelect;
        private System.Windows.Forms.ToolStripMenuItem ZHCNItem;
        private System.Windows.Forms.ToolStripMenuItem ZHTWItem;
        private System.Windows.Forms.ToolStripMenuItem ENUSItem;
        private System.Windows.Forms.ToolStripMenuItem OptionMenu;
        private System.Windows.Forms.ToolStripMenuItem OptionMenuDisableVolume;
        private System.Windows.Forms.ToolStripMenuItem OptionMenuGenerateMD5;
        private System.Windows.Forms.ToolStripMenuItem AboutMenu;
        private System.Windows.Forms.ToolStripMenuItem AboutAuto7zRev;
    }
}

