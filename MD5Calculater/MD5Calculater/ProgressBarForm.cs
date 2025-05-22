using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MD5Calculater
{
    public partial class ProgressBarForm : Form
    {
		private Dictionary<string, Dictionary<string, string>> languageTexts;

		private readonly string currentLanguage;
		private readonly string[] newArgs;
		private readonly int numOfFiles = 0;

		private bool isMultipleFiles = false;
		private bool packedOneFile = false;

		public class LogSetting
		{
			private readonly string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			private readonly string logFileName = "MD5Calculator.log";
			public readonly string logFilePath;

			public LogSetting()
			{
				logFilePath = Path.Combine(desktopPath, logFileName);
			}
		}

		public ProgressBarForm(string[] args)
        {
			newArgs = args;
			InitializeComponent();
			INITIALIZE_MAINFORM_SIZE();

			currentLanguage = GET_CURRENT_LANGUAGE();

			InitializeLanguageTexts();
			UpdateLanguage();
			UpdateLabelText();

			if (newArgs.Length != 0)
			{
				if (newArgs.Length > 1)
				{
					isMultipleFiles = true;
					bool allPathAreFiles = true;

					foreach (string path in newArgs)
					{
						numOfFiles += 1;
						if (!File.Exists(path))
						{
							allPathAreFiles = false;
							break;
						}
					}

					if (allPathAreFiles)
					{
						QUESTION_PACKED_IN_ONE_FILE();
					}
				}

				else
				{
					isMultipleFiles = false;
				}
			}

			if (newArgs != null && newArgs.Length != 0)
			{
				Show();
			}

            else
            {
				ERROR_NO_FILE();
				Close();
			}
		}

		private async void PROGRESS_BAR_FORM_SHOWN(object sender, EventArgs e)
		{
			if (newArgs != null && newArgs.Length > 0)
			{
				await ASYNC_TASK(newArgs);
			}
		}

		private async Task ASYNC_TASK(string[] args)
		{
			if (args != null && args.Length > 0 && args.ToList().TrueForAll(arg => !string.IsNullOrEmpty(arg)))
			{
				if (!isMultipleFiles)
				{
					string nowTime = DateTime.Now.ToString("HH-mm-ss");
					string filePath = Path.GetFullPath(args[0]);
					string[] fileInDirectoryPaths = null;
					long sizeBytes = GET_SINGLE_FILE_SIZE(filePath);

					string md5FileName = $"{Path.GetFileNameWithoutExtension(filePath)}_{nowTime}.md5";
					string md5Path = File.Exists(filePath) ? Path.Combine(Path.GetDirectoryName(filePath), md5FileName) : Path.Combine(filePath, md5FileName);

					if (Directory.Exists(filePath))
					{
						fileInDirectoryPaths = GET_DIRECTORY_FILES(filePath);
					}

					Exception fileEx = null;
					Exception folderEx = null;

					string[] md5 = File.Exists(filePath) ? await Task.Run(() => CALCULATE_MD5(sizeBytes, new string[] { filePath }, out fileEx)) : await Task.Run(() => CALCULATE_MD5(sizeBytes, fileInDirectoryPaths, out folderEx));

					if (md5 == null)
					{
						Exception error = (File.Exists(filePath) ? fileEx : folderEx);
						ERROR_EXCEPTION_MESSAGE(error);
						return;
					}
					CHECK_MD5_FILE_LEGAL(md5Path);
					WRITE_MD5(md5Path, md5);
					Close();
				}

				else
				{
					string nowTime = DateTime.Now.ToString("HH-mm-ss");
					string[] filePaths = args;

					if (!packedOneFile)
					{
						foreach (string file in filePaths)
						{
							string filePath = Path.GetFullPath(file);
							string[] fileInDirectoryPaths = null;
							long sizeBytes = GET_SINGLE_FILE_SIZE(filePath);

							string md5FileName = $"{Path.GetFileNameWithoutExtension(filePath)}_{nowTime}.md5";
							string md5Path = File.Exists(filePath) ? Path.Combine(Path.GetDirectoryName(filePath), md5FileName) : Path.Combine(filePath, md5FileName);

							if (Directory.Exists(filePath))
							{
								fileInDirectoryPaths = GET_DIRECTORY_FILES(filePath);
							}

							Exception fileEx = null;
							Exception folderEx = null;

							string[] md5 = File.Exists(filePath) ? await Task.Run(() => CALCULATE_MD5(sizeBytes, new string[] { filePath }, out fileEx)) : await Task.Run(() => CALCULATE_MD5(sizeBytes, fileInDirectoryPaths, out folderEx));

							if (md5 == null)
							{
								Exception error = File.Exists(filePath) ? fileEx : folderEx;
								ERROR_EXCEPTION_MESSAGE(error);
								return;
							}

							CHECK_MD5_FILE_LEGAL(md5Path);
							WRITE_MD5(md5Path, md5);
						}
					}

					else
					{
						string filePath = Path.GetFullPath(args[0]);
						string[] fileInDirectoryPaths = null;
						long sizeBytes = GET_MULTIPLE_FILES_SIZE(filePaths, out string[] newFilePaths);

						string md5FileName = $"{Path.GetFileNameWithoutExtension(filePath)}等{numOfFiles}个文件_{nowTime}.md5";
						string md5Path = File.Exists(filePath) ? Path.Combine(Path.GetDirectoryName(filePath), md5FileName) : Path.Combine(filePath, md5FileName);

						List<string> md5 = new List<string>();

						foreach (var file in newFilePaths)
						{
							if (Directory.Exists(file))
							{
								fileInDirectoryPaths = GET_DIRECTORY_FILES(file);
							}

							Exception fileEx = null;
							Exception folderEx = null;

							string[] value;

							if (File.Exists(file))
							{
								value = await Task.Run(() => CALCULATE_MD5(sizeBytes, new string[] { file }, out fileEx));
							}

							else
							{
								value = await Task.Run(() => CALCULATE_MD5(sizeBytes, fileInDirectoryPaths, out folderEx));
							}

							if (fileEx != null)
							{
								ERROR_EXCEPTION_MESSAGE(fileEx);
								return;
							}

							if (folderEx != null)
							{
								ERROR_EXCEPTION_MESSAGE(folderEx);
								return;
							}

							if (value != null)
							{
								md5.AddRange(value);
							}
						}

						CHECK_MD5_FILE_LEGAL(md5Path);
						WRITE_MD5(md5Path, md5.ToArray());
					}
				}

				Close();
			}

			else
			{
				Close();
			}
		}

		private void INITIALIZE_MAINFORM_SIZE()
		{
			AutoScaleMode = AutoScaleMode.Dpi;
			MinimumSize = new Size(450, 250);
			MaximumSize = MinimumSize;
		}

		private void InitializeLanguageTexts()
		{
			languageTexts = new Dictionary<string, Dictionary<string, string>>
			{
				{
					"zh-CN",
					new Dictionary<string, string>
					{
						{ "Title", "计算MD5..." },
						{ "LabelCalculating", "正在计算MD5..." }
					}
				},
				{
					"zh-TW",
					new Dictionary<string, string>
					{
						{ "Title", "計算MD5..." },
						{ "LabelCalculating", "正在計算MD5..." }
					}
				},
				{
					"en-US",
					new Dictionary<string, string>
					{
						{ "Title", "Calculate MD5..." },
						{ "LabelCalculating", "Calculating MD5..." }
					}
				}
			};
		}

		private void UpdateLanguage()
		{
			Text = languageTexts[currentLanguage]["Title"];
			LabelCalculating.Text = languageTexts[currentLanguage]["LabelCalculating"];
		}

		private void UpdateLabelText()
		{
			string text = null;
			switch (currentLanguage)
			{
				case "zh-CN":
					text = "已完成：0%";
					break;
				case "zh-TW":
					text = "已完成：0%";
					break;
				case "en-US":
					text = "Processed: 0%";
					break;
			}
			LabelPercent.Text = text;
		}

		private void PROGRESSBAR_FORM_LOAD(object sender, EventArgs e)
		{
			int locationX = Screen.PrimaryScreen.Bounds.Width / 2 - Width / 2;
			int locationY = Screen.PrimaryScreen.Bounds.Height / 2 - Height / 2;
			Location = new Point(locationX, locationY);
			Size = MinimumSize;
		}

		private string[] GET_DIRECTORY_FILES(string path)
		{
			return Directory.GetFiles(path);
		}

		private string[] CALCULATE_MD5(long size, string[] paths, out Exception error)
		{
			List<string> data = new List<string>();

			long processedSize = 0;

			string labelText = null;
			switch (currentLanguage)
			{
				case "zh-CN":
					labelText = "已完成：";
					break;
				case "zh-TW":
					labelText = "已完成：";
					break;
				case "en-US":
					labelText = "Processed: ";
					break;
			}

			error = null;

			foreach (string path in paths)
			{
				try
				{
					string fullPath = Path.GetFullPath(path);
					string valueName = Path.GetFileName(fullPath);

					using (var md5 = MD5.Create())
					{
						using (var stream = File.OpenRead(fullPath))
						{
							byte[] hashBytes = md5.ComputeHash(stream);
							// 将字节数组转换为十六进制字符串
							string originValue = $"{BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant()} *{valueName}";
							data.Add(originValue);

							processedSize += new FileInfo(fullPath).Length;
							int percent = (int)(processedSize * 100 / size);

							Invoke((MethodInvoker)delegate
							{
								ProgressBar.Value = percent;
								LabelPercent.Text = $"{labelText}{percent}%";
							});
						}
					}
				}
				catch (Exception ex)
				{
					error = ex;
					return new string[0];
				}
			}
			string[] result = data.ToArray();

			Invoke((MethodInvoker)delegate
			{
                ProgressBar.Value = 100;
				LabelPercent.Text = labelText + "100%";
			});
			return result;
		}

		private long GET_SINGLE_FILE_SIZE(string path)
		{
			string fullPath = Path.GetFullPath(path);
			string name = Path.GetFileNameWithoutExtension(fullPath);
			string dirertory = Path.GetDirectoryName(fullPath);

			long fileSize;
			long folderSize;

			if (File.Exists(fullPath))
			{
				fileSize = GET_FILE_SIZE(fullPath);

				if (fileSize == -1)
				{
					ERROR_EMPTY_SIZE(name, fullPath);
					return -1;
				}

				return fileSize;
			}

			else if (Directory.Exists(fullPath))
			{
				folderSize = GET_FOLDER_SIZE(fullPath);

				if (folderSize == -1)
				{
					ERROR_EMPTY_SIZE(name, fullPath);
					return -1;
				}

				return folderSize;
			}

			else if (!File.Exists(fullPath) || !Directory.Exists(fullPath))
			{
				bool canReadWrite = CHECK_PATH_READ_WRITE(dirertory, out Exception ex);

				if (fullPath.Length >= 260)
				{
					ERROR_TOO_LONG_PATH(fullPath);
				}

				if (!canReadWrite)
				{
					ERROR_APPLICATION_NO_PREMISSION(dirertory, ex);
				}

				return -1;
			}

			return -1;
		}

		private long GET_MULTIPLE_FILES_SIZE(string[] paths,out string[] newFilePaths)
		{
			List<string> fileList = new List<string>(paths);

			long fileSize;
			long fileSizes = 0;
			long folderSize;
			long folderSizes = 0;
			long totalSize;

			foreach (var path in paths)
			{
				string fullPath = Path.GetFullPath(path);
				string name = Path.GetFileNameWithoutExtension(fullPath);
				string dirertory = Path.GetDirectoryName(fullPath);

				if (File.Exists(fullPath))
				{
					fileSize = GET_FILE_SIZE(fullPath);

					if (fileSize != -1)
					{
						fileSizes += fileSize;
					}

					else
					{
						fileList.Remove(fullPath);
						WARNING_REMOVE_ELEMENT(name, fullPath);
					}
				}

				else if (Directory.Exists(fullPath))
				{
					folderSize = GET_FOLDER_SIZE(fullPath);

					if (folderSize != -1)
					{
						folderSizes += folderSize;
					}

					else
					{
						fileList.Remove(fullPath);
						WARNING_REMOVE_ELEMENT(name, fullPath);
					}
				}

				else if (!File.Exists(fullPath) || !Directory.Exists(fullPath))
				{
					bool canReadWrite = CHECK_PATH_READ_WRITE(dirertory, out Exception ex);

					if (fullPath.Length >= 260)
					{
						ERROR_TOO_LONG_PATH(fullPath);
					}

					if (!canReadWrite)
					{
						ERROR_APPLICATION_NO_PREMISSION(dirertory, ex);
					}
				}
			}

			string[] filePaths = fileList.ToArray();
			newFilePaths = filePaths;

			if (filePaths != null)
			{
				totalSize = fileSizes + folderSizes;
				return totalSize;
			}

			return -1;
		}

		private long GET_FILE_SIZE(string filePath)
		{
			if (filePath != null)
			{
				FileInfo fileInfo = new FileInfo(filePath);
				long fileSizeBytes = fileInfo.Length;

				return fileSizeBytes;
			}

			else
			{
				return -1;
			}
		}

		private long GET_FOLDER_SIZE(string filePath)
		{
			if (filePath != null)
			{
				long folderSizeBytes = 0;

				// 获取文件夹中的所有文件和子文件夹
				DirectoryInfo directoryInfo = new DirectoryInfo(filePath);

				// 计算文件大小
				FileInfo[] files = directoryInfo.GetFiles("*", SearchOption.AllDirectories);
				foreach (FileInfo file in files)
				{
					folderSizeBytes += file.Length;
				}

				return folderSizeBytes;
			}

			else
			{
				return -1;
			}
		}

		private void WRITE_MD5(string md5Path, string[] message)
		{
			try
			{
				foreach (var md5 in message)
				{
					using (StreamWriter writer = new StreamWriter(md5Path, true, Encoding.GetEncoding("GBK")))
					{
						writer.WriteLine(md5);
					}
				}
			}

			catch (Exception error)
			{
				ERROR_EXCEPTION_MESSAGE(error);
			}
		}

		private bool CHECK_PATH_READ_WRITE(string path, out Exception error)
		{
			error = null; // 初始化异常为 null

			try
			{
				// 检查可写性
				string checkFilePath = Path.Combine(path, "Directory_checker");

				// 尝试写入
				using (FileStream testFile = File.Create(checkFilePath))
				{
					// 写入一些数据（随意）
					byte[] info = new UTF8Encoding(true).GetBytes("dir check");
					testFile.Write(info, 0, info.Length);
				}

				// 尝试读取
				using (FileStream testFile = File.OpenRead(checkFilePath))
				{
					// 尝试读取数据
					byte[] buffer = new byte[1024];
					testFile.Read(buffer, 0, buffer.Length);
				}

				// 删除测试文件
				File.Delete(checkFilePath);

				return true; // 两者都成功
			}
			catch (UnauthorizedAccessException unauthorizedEx)
			{
				error = unauthorizedEx;
				return false; // 不具备权限
			}
			catch (Exception otherEx)
			{
				error = otherEx;
				return false; // 发生其他异常
			}
		}

		private void CHECK_LOG_LEGAL(string configFilePath)
		{
			FileInfo configFile = new FileInfo(configFilePath);

			if (configFile.Exists && (configFile.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
			{
				configFile.Attributes = FileAttributes.Normal;
			}

			if (configFile.Exists && (configFile.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
			{
				configFile.Attributes = FileAttributes.Normal;
			}
		}

		private void CHECK_MD5_FILE_LEGAL(string configFilePath)
		{
			FileInfo fileInfo = new FileInfo(configFilePath);

			if (fileInfo.Exists && (fileInfo.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
			{
				fileInfo.Attributes = FileAttributes.Normal;
			}
			if (fileInfo.Exists && (fileInfo.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
			{
				fileInfo.Attributes = FileAttributes.Normal;
			}

			if (File.Exists(configFilePath))
			{
				try
				{
					File.WriteAllText(configFilePath, string.Empty);
				}
				catch (Exception error)
				{
					ERROR_EXCEPTION_MESSAGE(error);
				}
			}
		}

		private void WRITE_ERROR_LOG(string message, Exception error)
		{
			LogSetting logSetting = new LogSetting();

			string nowTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
			CHECK_LOG_LEGAL(logSetting.logFilePath);

			using (StreamWriter writer = new StreamWriter(logSetting.logFilePath, true))
			{
				writer.WriteLine($"{nowTime}: {message},{error.Message}");
				writer.WriteLine();
			}
		}

		private void WRITE_MESSAGE_LOG(string message)
		{
			LogSetting logSetting = new LogSetting();

			string nowTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
			CHECK_LOG_LEGAL(logSetting.logFilePath);

			using (StreamWriter writer = new StreamWriter(logSetting.logFilePath, true))
			{
				writer.WriteLine($"{nowTime}: {message}");
				writer.WriteLine();
			}
		}

		private void QUESTION_PACKED_IN_ONE_FILE()
		{
			DialogResult dialogResult = DialogResult.None;

			switch (currentLanguage)
			{
				case "zh-CN":
					dialogResult = MessageBox.Show("检测到多个文件传入，是否需要将多个文件的MD5值打包到单个MD5文件中？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
					break;
				case "zh-TW":
					dialogResult = MessageBox.Show("檢測到多個文件傳入，是否需要將多個文件的MD5值打包到單個MD5文件中？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
					break;
				case "en-US":
					dialogResult = MessageBox.Show("Multiple files have been detected. Do you want to package the values into a single MD5 file?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
					break;
			}

			if (dialogResult == DialogResult.Yes)
			{
				packedOneFile = true;
			}

			else
			{
				packedOneFile = false;
			}
		}

		private void WARNING_REMOVE_ELEMENT(string name, string incomingPath)
		{
			switch (currentLanguage)
			{
				case "zh-CN":
					MessageBox.Show($"没有获取到{name}的大小，所以该文件并没有被添加到压缩文件中。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
				case "zh-TW":
					MessageBox.Show($"沒有獲取到{name}的大小，所以該文件并沒有被添加到壓縮檔中。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
				case "en-US":
					MessageBox.Show($"The size of {name} could not be obtained, so it has not been added to the compressed file.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
			}

			string message = $"传入文件路径为:{incomingPath},错误为:没有获取到{name}的大小，所以该文件并没有被添加到压缩文件中。";
			WRITE_MESSAGE_LOG(message);
		}

		private void ERROR_APPLICATION_NO_PREMISSION(string directoryPath, Exception error)
		{
			switch (currentLanguage)
			{
				case "zh-CN":
					MessageBox.Show($"应用程序没有在{directoryPath}内进行读写的权限，错误为: {error.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
					break;
				case "zh-TW":
					MessageBox.Show($"應用程式沒有在{directoryPath}内進行讀寫的權限，錯誤為: {error.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
					break;
				case "en-US":
					MessageBox.Show($"The application does not have read/write permissions in {directoryPath}, the error is: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					break;
			}

			string message = $"应用程序没有在{directoryPath}内进行读写的权限";
			WRITE_ERROR_LOG(message, error);
		}

		private void ERROR_TOO_LONG_PATH(string incomingPath)
		{
			switch (currentLanguage)
			{
				case "zh-CN":
					MessageBox.Show("传入路径超过260个字符，无法处理。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
					break;
				case "zh-TW":
					MessageBox.Show("傳入路徑超過260個字符，無法處理。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
					break;
				case "en-US":
					MessageBox.Show("The path exceeds 260 characters and cannot be processed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					break;
			}

			string message = $"传入文件路径为:{incomingPath},错误为:传入路径超过260个字符，无法处理。";
			WRITE_MESSAGE_LOG(message);
		}

		private void ERROR_NO_FILE()
		{
			switch (currentLanguage)
			{
				case "zh-CN":
					MessageBox.Show("没有传入任何文件，任务终止。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
					break;
				case "zh-TW":
					MessageBox.Show("沒有傳入任何文件，任務終止。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
					break;
				case "en-US":
					MessageBox.Show("No file uploaded, task terminated.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					break;
			}
		}

		private void ERROR_EMPTY_SIZE(string name, string incomingPath)
		{
			switch (currentLanguage)
			{
				case "zh-CN":
					MessageBox.Show($"没有获取到{name}的大小。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
					break;
				case "zh-TW":
					MessageBox.Show($"沒有獲取到{name}的大小。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
					break;
				case "en-US":
					MessageBox.Show($"The size of {name} could not be obtained.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					break;
			}

			string message = $"没有获取到{name}的大小，传入的路径为{incomingPath}。";
			WRITE_MESSAGE_LOG(message);
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

			string message = $"出现错误";
			WRITE_ERROR_LOG(message, error);
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
