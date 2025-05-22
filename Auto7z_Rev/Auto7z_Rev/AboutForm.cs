using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Auto7z_Rev
{
    public partial class AboutForm : Form
    {
        private Dictionary<string, Dictionary<string, string>> languageTexts;

        public static class Parameters
        {
            public static string currentLanguage { get; set; }
        }

        public AboutForm()
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;
            Parameters.currentLanguage = Auto7zMainForm.Parameters.currentLanguage;
            InitializeLanguageTexts();
            UpdateLanguage();
        }

        private void InitializeLanguageTexts()
        {
            languageTexts = new Dictionary<string, Dictionary<string, string>>
            {
                { "zh-CN", new Dictionary<string, string>
                    {
                        { "Title","关于 Auto7z Rev" },
                        { "LinkLabelGitHub","Github主页" },
                        { "LinkLabelLicense","许可证" },
                        { "ButtonConfirm","确定" },
                    }
                },
                { "zh-TW", new Dictionary<string, string>
                    {
                        { "Title","關於 Auto7z Rev" },
                        { "LinkLabelGitHub","Github主頁" },
                        { "LinkLabelLicense","許可證" },
                        { "ButtonConfirm","確定" },
                    }
                },
                { "en-US", new Dictionary<string, string>
                    {
                        { "Title","About Auto7z Rev" },
                        { "LinkLabelGitHub","Github Page" },
                        { "LinkLabelLicense","License" },
                        { "ButtonConfirm","Confirm" },
                    }
                }
            };
        }

        private void UpdateLanguage()
        {
            Text = languageTexts[Parameters.currentLanguage]["Title"];
            LinkLabelGitHub.Text = languageTexts[Parameters.currentLanguage]["LinkLabelGitHub"];
            LinkLabelLicense.Text = languageTexts[Parameters.currentLanguage]["LinkLabelLicense"];
            ButtonConfirm.Text = languageTexts[Parameters.currentLanguage]["ButtonConfirm"];
        }

        private void GITHUB_LABEL_LINK_CLICKED(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // 打开网址
            System.Diagnostics.Process.Start("https://github.com/Latte-Yogurt");

            // 标记为已访问
            LinkLabelGitHub.LinkVisited = true;
        }

        private void LICENSE_LABEL_LINK_CLICKED(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // 打开网址
            System.Diagnostics.Process.Start("https://www.gnu.org/licenses/gpl-3.0.html");

            // 标记为已访问
            LinkLabelLicense.LinkVisited = true;
        }

        private void CONFIRM_BUTTON_CLICK(object sender, EventArgs e)
        {
            Close();
        }

        private void ABOUT_FORM_LOAD(object sender, EventArgs e)
        {
            int locationX = Screen.PrimaryScreen.Bounds.Width / 2 - this.Width / 2;
            int locationY = Screen.PrimaryScreen.Bounds.Height / 2 - this.Height / 2;

            this.Location = new Point(locationX, locationY);
        }
    }
}
