using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace AddList
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

            if (File.Exists(exe1Path))
            {
                string filePath = exe1Path;

                try
                {
                    bool auto7zForFile = AddContextMenuItem(@"Software\Classes\*\shell\auto7z_GUI", filePath);
                    bool auto7zForFolder = AddContextMenuItem(@"Software\Classes\Directory\shell\auto7z_GUI", filePath);

                    if (auto7zForFile && auto7zForFolder)
                    {
                        NOTICE_ADD_LIST_SUCCEED();
                    }

                    else
                    {
                        ERROR_ADD_LIST_FAILURE();
                    }
                }
                catch (Exception ex)
                {
                    ERROR_EXCEPTION_MESSAGE(ex);
                }
                finally
                {
                    this.Close();
                }
            }

            if (File.Exists(exe2Path))
            {
                string filePath = exe2Path;

                try
                {
                    bool auto7zForFile = AddContextMenuItem(@"Software\Classes\*\shell\auto7z_RAR", filePath);
                    bool auto7zForFolder = AddContextMenuItem(@"Software\Classes\Directory\shell\auto7z_RAR", filePath);

                    if (auto7zForFile && auto7zForFolder)
                    {
                        NOTICE_ADD_LIST_SUCCEED();
                    }

                    else
                    {
                        ERROR_ADD_LIST_FAILURE();
                    }
                }
                catch (Exception ex)
                {
                    ERROR_EXCEPTION_MESSAGE(ex);
                }
                finally
                {
                    this.Close();
                }
            }

            if (File.Exists(exe3Path))
            {
                string filePath = exe3Path;

                try
                {
                    bool auto7zForFile = AddContextMenuItem(@"Software\Classes\*\shell\auto7z_Rev", filePath);
                    bool auto7zForFolder = AddContextMenuItem(@"Software\Classes\Directory\shell\auto7z_Rev", filePath);

                    if (auto7zForFile && auto7zForFolder)
                    {
                        NOTICE_ADD_LIST_SUCCEED();
                    }

                    else
                    {
                        ERROR_ADD_LIST_FAILURE();
                    }
                }
                catch (Exception ex)
                {
                    ERROR_EXCEPTION_MESSAGE(ex);
                }
                finally
                {
                    this.Close();
                }
            }

            if (!File.Exists(exe1Path) && !File.Exists(exe2Path) && !File.Exists(exe3Path))
            {
                ERROR_NO_TASK();
                this.Close();
            }
        }

        static string GET_WORK_PATH()
        {
            // 获取当前执行程序集
            string assemblyPath = Assembly.GetExecutingAssembly().Location;
            // 返回路径
            return Path.GetDirectoryName(assemblyPath);
        }

        private bool AddContextMenuItem(string registryPath, string exePath)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(registryPath))
                {
                    if (key != null)
                    {
                        key.SetValue("MUIVerb", "Auto7z");
                        key.SetValue("Icon", exePath);
                        key.SetValue("MultiSelectModel", "Single");

                        using (RegistryKey commandKey = key.CreateSubKey("command"))
                        {
                            commandKey.SetValue("", $"\"{exePath}\" \"%1\"");
                        }
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                ERROR_EXCEPTION_MESSAGE(ex);
            }
            return false;
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

        private void NOTICE_ADD_LIST_SUCCEED()
        {
            switch (currentLanguage)
            {
                case "zh-CN":
                    MessageBox.Show("右键菜单 <Auto7z> 已添加。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case "zh-TW":
                    MessageBox.Show("右鍵菜單 <Auto7z> 已添加。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case "en-US":
                    MessageBox.Show("Right-click menu <Auto7z> has been added.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }

        private void ERROR_ADD_LIST_FAILURE()
        {
            switch (currentLanguage)
            {
                case "zh-CN":
                    MessageBox.Show("右键菜单 <Auto7z> 添加失败。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case "zh-TW":
                    MessageBox.Show("右鍵菜單 <Auto7z> 添加失敗。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case "en-US":
                    MessageBox.Show("Failed to add <Auto7z> to the right-click menu.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("No content found related to the Auto7z program, task terminated.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
