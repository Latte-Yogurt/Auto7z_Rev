using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace DelList
{
    public partial class MainForm : Form
    {
        private string currentLanguage;
        private string exe1Path;
        private string exe2Path;
        private string exe3Path;

        public MainForm()
        {
            string workPath = GET_WORK_PATH(); // 获取程序路径
            currentLanguage = GET_CURRENT_LANGUAGE();

            exe1Path = Path.Combine(workPath, "Auto7z_GUI.exe");

            exe2Path = Path.Combine(workPath, "Auto7z_RAR_GUI.exe");

            exe3Path = Path.Combine(workPath, "Auto7z_Rev.exe");

            if (File.Exists(exe1Path) || File.Exists(exe2Path) || File.Exists(exe3Path))
            {
                bool auto7zForFile = RemoveContextMenuItem(@"*\\shell\\auto7z_GUI");
                bool auto7zForFolder = RemoveContextMenuItem(@"Directory\\shell\\auto7z_GUI");

                bool auto7zRarForFile = RemoveContextMenuItem(@"*\\shell\\auto7z_RAR");
                bool auto7zRarForFolder = RemoveContextMenuItem(@"Directory\\shell\\auto7z_RAR");

                bool auto7zRevForFile = RemoveContextMenuItem(@"*\\shell\\auto7z_Rev");
                bool auto7zRevForFolder = RemoveContextMenuItem(@"Directory\\shell\\auto7z_Rev");

                if (auto7zForFile && auto7zForFolder)
                {
                    NOTICE_DEL_LIST_SUCCEED();
                    this.Close();
                }

                if (auto7zRarForFile && auto7zRarForFolder)
                {
                    NOTICE_DEL_LIST_SUCCEED();
                    this.Close();
                }

                if (auto7zRevForFile && auto7zRevForFolder)
                {
                    NOTICE_DEL_LIST_SUCCEED();
                    this.Close();
                }

                if (File.Exists(exe1Path) && (!auto7zForFile || !auto7zForFolder))
                {
                    ERROR_DEL_LIST_FAILURE();
                    this.Close();
                }

                if (File.Exists(exe2Path) && (!auto7zRarForFile || !auto7zRarForFolder))
                {
                    ERROR_DEL_LIST_FAILURE();
                    this.Close();
                }

                if (File.Exists(exe3Path) && (!auto7zRevForFile || !auto7zRevForFolder))
                {
                    ERROR_DEL_LIST_FAILURE();
                    this.Close();
                }
            }

            else
            {
                ERROR_NO_TASK();
                this.Close();
            }
        }

        private bool RemoveContextMenuItem(string keyPath)
        {
            try
            {
                // 打开注册表项
                RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, RegistryView.Registry64).OpenSubKey(keyPath, true);

                if (key != null)
                {
                    // 删除整个子项
                    key.DeleteSubKeyTree(""); // 请检查该方法里的字符串是否是有效的子项名称
                    key.Close(); // 确保关闭注册表项

                    return true; // 返回删除成功
                }

                else
                {
                    // 如果没有找到注册表项
                    return false; // 返回删除失败
                }
            }

            catch (UnauthorizedAccessException)
            {
                ERROR_NO_PERMISSION();
                return false; // 返回没有权限的错误
            }

            catch (Exception ex)
            {
                ERROR_EXCEPTION_MESSAGE(ex);
                return false; // 返回其他错误
            }
        }


        static string GET_WORK_PATH()
        {
            // 获取当前执行程序集
            string assemblyPath = Assembly.GetExecutingAssembly().Location;
            // 返回路径
            return Path.GetDirectoryName(assemblyPath);
        }

        private void ERROR_EXCEPTION_MESSAGE(Exception error)
        {
            switch (currentLanguage)
            {
                case "zh-CN":
                    MessageBox.Show($"出现错误: {error.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case "zh-TW":
                    MessageBox.Show($"出現錯誤: {error.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case "en-US":
                    MessageBox.Show($"An error occurred: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void NOTICE_DEL_LIST_SUCCEED()
        {
            switch (currentLanguage)
            {
                case "zh-CN":
                    MessageBox.Show("右键菜单 <Auto7z> 已移除。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case "zh-TW":
                    MessageBox.Show("右鍵菜單 <Auto7z> 已移除。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case "en-US":
                    MessageBox.Show("Right-click menu <Auto7z> has been deleted.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }

        private void ERROR_DEL_LIST_FAILURE()
        {
            switch (currentLanguage)
            {
                case "zh-CN":
                    MessageBox.Show($"右键菜单 <Auto7z> 移除失败。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case "zh-TW":
                    MessageBox.Show($"右鍵菜單 <Auto7z> 移除失敗。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case "en-US":
                    MessageBox.Show($"Right-click menu <Auto7z> delete failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void ERROR_NO_TASK()
        {
            switch (currentLanguage)
            {
                case "zh-CN":
                    MessageBox.Show("没有找到有关Auto7z程序的内容，任务终止。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case "zh-TW":
                    MessageBox.Show("沒有找到有關Auto7z程序的内容，任務終止。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case "en-US":
                    MessageBox.Show("No content found related to the Auto7z program, task terminated..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void ERROR_NO_PERMISSION()
        {
            switch (currentLanguage)
            {
                case "zh-CN":
                    MessageBox.Show("没有权限访问注册表。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case "zh-TW":
                    MessageBox.Show("沒有權限訪問註冊表。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case "en-US":
                    MessageBox.Show("No permission to access the registry.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private string GET_CURRENT_LANGUAGE()
        {
            // 获取当前系统的显示语言
            var currentCulture = CultureInfo.CurrentUICulture;

            // 创建一个示例词典，包含支持的语言
            var supportedLanguages = new HashSet<string>
                {
                    "zh-CN", // 中文 (简体)
                    "zh-TW", // 中文 (繁体)
                    "en-US", // 英语 (美国)
                    // 其他语言...
                };

            if (supportedLanguages.Contains(currentCulture.Name))
            {
                return currentCulture.Name;
            }

            else
            {
                return "en-US";
            }
        }
    }
}
