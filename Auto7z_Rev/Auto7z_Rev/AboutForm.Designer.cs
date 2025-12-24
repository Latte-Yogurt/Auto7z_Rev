
namespace Auto7z_Rev
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.PicBox = new System.Windows.Forms.PictureBox();
            this.MainLabel = new System.Windows.Forms.Label();
            this.LabelCopyRight = new System.Windows.Forms.Label();
            this.LinkLabelGitHub = new System.Windows.Forms.LinkLabel();
            this.LinkLabelLicense = new System.Windows.Forms.LinkLabel();
            this.ButtonConfirm = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 5;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.Controls.Add(this.PicBox, 2, 1);
            this.tableLayoutPanel.Controls.Add(this.MainLabel, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.LabelCopyRight, 0, 6);
            this.tableLayoutPanel.Controls.Add(this.LinkLabelGitHub, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.LinkLabelLicense, 0, 4);
            this.tableLayoutPanel.Controls.Add(this.ButtonConfirm, 0, 5);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 8;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(858, 384);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // PicBox
            // 
            this.PicBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PicBox.ErrorImage = null;
            this.PicBox.Image = ((System.Drawing.Image)(resources.GetObject("PicBox.Image")));
            this.PicBox.InitialImage = null;
            this.PicBox.Location = new System.Drawing.Point(345, 18);
            this.PicBox.Name = "PicBox";
            this.PicBox.Size = new System.Drawing.Size(165, 54);
            this.PicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicBox.TabIndex = 0;
            this.PicBox.TabStop = false;
            // 
            // MainLabel
            // 
            this.MainLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainLabel.AutoSize = true;
            this.tableLayoutPanel.SetColumnSpan(this.MainLabel, 5);
            this.MainLabel.Font = new System.Drawing.Font("Segoe Print", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainLabel.Location = new System.Drawing.Point(3, 75);
            this.MainLabel.Name = "MainLabel";
            this.MainLabel.Size = new System.Drawing.Size(852, 56);
            this.MainLabel.TabIndex = 1;
            this.MainLabel.Text = "Auto7z Rev";
            this.MainLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelCopyRight
            // 
            this.LabelCopyRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelCopyRight.AutoSize = true;
            this.tableLayoutPanel.SetColumnSpan(this.LabelCopyRight, 5);
            this.LabelCopyRight.Font = new System.Drawing.Font("Segoe Print", 8F);
            this.LabelCopyRight.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LabelCopyRight.Location = new System.Drawing.Point(3, 307);
            this.LabelCopyRight.Name = "LabelCopyRight";
            this.LabelCopyRight.Size = new System.Drawing.Size(852, 60);
            this.LabelCopyRight.TabIndex = 2;
            this.LabelCopyRight.Text = "Copyright© 2024 LatteYogurt , All rights reserved.";
            this.LabelCopyRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LinkLabelGitHub
            // 
            this.LinkLabelGitHub.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LinkLabelGitHub.AutoSize = true;
            this.tableLayoutPanel.SetColumnSpan(this.LinkLabelGitHub, 5);
            this.LinkLabelGitHub.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.LinkLabelGitHub.Location = new System.Drawing.Point(3, 131);
            this.LinkLabelGitHub.Name = "LinkLabelGitHub";
            this.LinkLabelGitHub.Size = new System.Drawing.Size(852, 60);
            this.LinkLabelGitHub.TabIndex = 3;
            this.LinkLabelGitHub.TabStop = true;
            this.LinkLabelGitHub.Text = "GitHub主页";
            this.LinkLabelGitHub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LinkLabelGitHub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.GITHUB_LABEL_LINK_CLICKED);
            // 
            // LinkLabelLicense
            // 
            this.LinkLabelLicense.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LinkLabelLicense.AutoSize = true;
            this.tableLayoutPanel.SetColumnSpan(this.LinkLabelLicense, 5);
            this.LinkLabelLicense.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.LinkLabelLicense.Location = new System.Drawing.Point(3, 191);
            this.LinkLabelLicense.Name = "LinkLabelLicense";
            this.LinkLabelLicense.Size = new System.Drawing.Size(852, 60);
            this.LinkLabelLicense.TabIndex = 4;
            this.LinkLabelLicense.TabStop = true;
            this.LinkLabelLicense.Text = "许可证";
            this.LinkLabelLicense.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LinkLabelLicense.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LICENSE_LABEL_LINK_CLICKED);
            // 
            // ButtonConfirm
            // 
            this.ButtonConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.tableLayoutPanel.SetColumnSpan(this.ButtonConfirm, 5);
            this.ButtonConfirm.Location = new System.Drawing.Point(359, 254);
            this.ButtonConfirm.Name = "ButtonConfirm";
            this.ButtonConfirm.Size = new System.Drawing.Size(140, 50);
            this.ButtonConfirm.TabIndex = 5;
            this.ButtonConfirm.Text = "确定";
            this.ButtonConfirm.UseVisualStyleBackColor = true;
            this.ButtonConfirm.Click += new System.EventHandler(this.CONFIRM_BUTTON_CLICK);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(858, 384);
            this.Controls.Add(this.tableLayoutPanel);
            this.Font = new System.Drawing.Font("微软雅黑 Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(880, 440);
            this.Name = "AboutForm";
            this.Text = "关于 Auto7z Rev";
            this.Load += new System.EventHandler(this.ABOUT_FORM_LOAD);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.PictureBox PicBox;
        private System.Windows.Forms.Label MainLabel;
        private System.Windows.Forms.Label LabelCopyRight;
        private System.Windows.Forms.LinkLabel LinkLabelGitHub;
        private System.Windows.Forms.LinkLabel LinkLabelLicense;
        private System.Windows.Forms.Button ButtonConfirm;
    }
}