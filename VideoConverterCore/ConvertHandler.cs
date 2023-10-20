using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VideoConvertCore
{
    public class ConvertHandler
    {
        private IObserver<FeedbackInfo> observer;
        private string CurrentFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        private string toolFileName = "ffmpeg.exe";
        private Regex errorRegex = new Regex("\\b(error|invalid)\\b");
        private Dictionary<Process, string> processFiles = new Dictionary<Process, string>();

        private Dictionary<string, string> dictFilePath = new Dictionary<string, string>();
        private Dictionary<string, ConvertTaskState> dictFileConverted = new Dictionary<string, ConvertTaskState>();
        private static object obj = new object();
        private List<string> toolFilePaths = new List<string>();

        public ConvertSetting Setting = new ConvertSetting();
        public ConvertOption Option = new ConvertOption();
        public string DefaultCommandTemplate;

        public List<string> FilePaths { get; set; } = new List<string>();

        public int RunningCount { get; private set; }
        public int FinishCount
        {
            get { return this.dictFileConverted.Where(item => item.Value == ConvertTaskState.Finished || item.Value == ConvertTaskState.Error).Count(); }
        }

        public ConvertHandler() { }
        public ConvertHandler(List<string> filePaths)
        {
            this.FilePaths = filePaths;
        }

        public void Convert()
        {
            foreach (string filePath in this.FilePaths)
            {
                this.AddFile(filePath);
            }

            var initItems = this.FilePaths.Take(this.Setting.TaskParallelLimit);

            foreach (var item in initItems)
            {
                this.Execute(this.Option.SaveFolder, item);
            }
        }

        public void AppendFile(string filePath)
        {
            this.FilePaths.Add(filePath);
            this.AddFile(filePath);
        }

        private void AddFile(string filePath)
        {
            if (!this.dictFileConverted.ContainsKey(filePath))
            {
                this.dictFileConverted.Add(filePath, ConvertTaskState.Ready);
            }
            else
            {
                this.dictFileConverted[filePath] = ConvertTaskState.Ready;
            }
        }

        public void RemoveFile(string filePath)
        {
            if (this.FilePaths.Contains(filePath))
            {
                this.FilePaths.Remove(filePath);
            }

            if (this.dictFileConverted.ContainsKey(filePath))
            {
                this.dictFileConverted.Remove(filePath);
            }
        }

        private bool IsOnlyForScaleOrQuality()
        {
            if (string.IsNullOrEmpty(this.Option.FileType) && string.IsNullOrEmpty(this.Option.Encoder))
            {
                if (this.Option.ResolutionWidth > 0 && this.Option.ResolutionHeight > 0)
                {
                    return true;
                }
                else if (this.Option.Quality > 0)
                {
                    return true;
                }
            }

            return false;
        }

        private void Execute(string saveFolder, string filePath)
        {
            FileInfo file = new FileInfo(filePath);
            VideoInfo videoInfo = new VideoInfo(file.FullName);
            string sourceFolder = file.DirectoryName;

            string exeFilePath = Path.Combine(sourceFolder, this.toolFileName);
            bool isSameExeFolder = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory) == Path.GetDirectoryName(exeFilePath);

            if (!File.Exists(exeFilePath))
            {
                File.Copy(this.toolFileName, exeFilePath, true);
            }

            if (!this.toolFilePaths.Contains(exeFilePath))
            {
                this.toolFilePaths.Add(exeFilePath);
            }

            string fileName = file.Name;
            string fileType = string.IsNullOrEmpty(this.Option.FileType) ? file.Extension.Trim('.') : this.Option.FileType;
            string targetFileName = $"{Path.GetFileNameWithoutExtension(fileName)}.{fileType.Trim('.')}";

            if (string.IsNullOrEmpty(saveFolder))
            {
                saveFolder = file.DirectoryName;
            }

            string targetFilePath = Path.Combine(saveFolder, targetFileName);

            string sourceFolderTargetFilePath = Path.Combine(file.DirectoryName, targetFileName);

            while (File.Exists(sourceFolderTargetFilePath))
            {
                sourceFolderTargetFilePath = this.GetNewFilePath(sourceFolderTargetFilePath);
                targetFileName = new FileInfo(sourceFolderTargetFilePath).Name;
            }

            string sourceFilePath = Path.Combine(sourceFolder, targetFileName);

            if (!this.dictFilePath.ContainsKey(sourceFilePath))
            {
                this.dictFilePath.Add(sourceFilePath, targetFilePath);
            }
            else
            {
                this.dictFilePath[sourceFilePath] = targetFilePath;
            }

            Action execCmd = () =>
            {
                Process p = new Process();

                this.processFiles.Add(p, filePath);

                string args = "";

                if (!string.IsNullOrEmpty(this.Option.CustomCommand))
                {
                    args = this.Option.CustomCommand.Replace(this.toolFileName, "").Replace(Path.GetFileNameWithoutExtension(this.toolFileName), "");
                    args = args.Replace("##SourceFile##", $"\"{fileName}\"").Replace("##TargetFile##", $"\"{targetFileName}\"");
                }
                else
                {
                    if (this.IsOnlyForScaleOrQuality())
                    {
                        string scale = this.Option.ResolutionWidth > 0 && this.Option.ResolutionHeight > 0 ? $" -vf scale={this.Option.ResolutionWidth.Value}:{this.Option.ResolutionHeight.Value} " : "";
                        string quality = this.Option.Quality == 0 ? "" : $" -crf {this.Option.Quality} ";

                        args = $"-i \"{fileName}\"{scale}{quality} \"{targetFileName}\"";
                    }
                    else
                    {
                        string resolution = "";

                        if (this.Option.ResolutionWidth.HasValue && this.Option.ResolutionHeight.HasValue)
                        {
                            resolution = $"-s {this.Option.ResolutionWidth.Value}x{this.Option.ResolutionHeight.Value}";
                        }

                        if (!string.IsNullOrEmpty(this.DefaultCommandTemplate))
                        {
                            args = this.DefaultCommandTemplate
                                   .Replace("##SourceFile##", $"\"{fileName}\"")
                                   .Replace("##TargetFile##", $"\"{targetFileName}\"")
                                   .Replace("##ThreadNumber##", this.Setting.ThreadNumber.ToString())
                                   .Replace("##Quality##", this.Option.Quality.ToString())
                                   .Replace("##Resolution##", resolution)
                                   .Replace("##Encoder##", this.Option.Encoder);
                        }
                        else
                        {
                            string threadNumber = "";

                            if (!this.Setting.UseDefaultThreadNumber)
                            {
                                threadNumber = $" -threads {this.Setting.ThreadNumber} ";
                            }

                            args = $"-i \"{fileName}\"{threadNumber}-c:v libx264 -crf {this.Option.Quality} {resolution} \"{targetFileName}\"";
                        }
                    }
                }

                videoInfo.TaskState = ConvertTaskState.Running;
                this.Feedback(videoInfo, $"Run command:{args}", false, true);

                string folder = Path.GetDirectoryName(exeFilePath);

                p.StartInfo.WorkingDirectory = folder;
                p.StartInfo.FileName = exeFilePath;
                p.StartInfo.Arguments = args;
                p.ErrorDataReceived += P_ErrorDataReceived;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.Start();

                p.BeginErrorReadLine();

                p.WaitForExit();
                p.Close();
                p.Dispose();
            };

            var task = Task.Factory.StartNew(execCmd);

            task.ContinueWith(i =>
            {
                lock (obj)
                {
                    if (this.dictFilePath.ContainsKey(sourceFolderTargetFilePath) && File.Exists(sourceFolderTargetFilePath) && !this.IsInSameFolder(sourceFolderTargetFilePath, targetFilePath))
                    {
                        while (File.Exists(targetFilePath))
                        {
                            targetFilePath = this.GetNewFilePath(targetFilePath);
                        }

                        File.Move(sourceFolderTargetFilePath, targetFilePath);
                    }

                    videoInfo.TargetFilePath = targetFilePath;

                    if (this.dictFileConverted.ContainsKey(filePath) && this.dictFileConverted[filePath] == ConvertTaskState.Running)
                    {
                        videoInfo.TaskState = ConvertTaskState.Finished;
                        this.Feedback(videoInfo, "Finished", false, true);
                        this.dictFileConverted[filePath] = ConvertTaskState.Finished;
                    }

                    if (this.FinishCount == this.FilePaths.Count)
                    {
                        this.RunningCount = 0;

                        if (!isSameExeFolder)
                        {
                            try
                            {
                                File.Delete(exeFilePath);
                            }
                            catch (Exception ex)
                            {
                            }
                        }

                        this.Feedback(null, "Done", true, true);

                        this.Clearup();
                    }
                    else
                    {
                        int runningCount = this.dictFileConverted.Count(item => item.Value == ConvertTaskState.Running);
                        int takeCount = this.Setting.TaskParallelLimit - runningCount;

                        if (takeCount > 0)
                        {
                            var fps = this.dictFileConverted.Where(item => item.Value == ConvertTaskState.Ready).Take(takeCount);

                            if (fps.Any())
                            {
                                foreach (var fp in fps)
                                {
                                    if (!string.IsNullOrEmpty(fp.Key))
                                    {
                                        this.dictFileConverted[fp.Key] = ConvertTaskState.Running;
                                        this.Execute(saveFolder, fp.Key);
                                    }
                                }
                            }
                        }
                    }
                }
            });
        }

        public void Clearup()
        {
            this.dictFilePath.Clear();
            this.dictFileConverted.Clear();
            this.toolFilePaths.Clear();
            this.processFiles.Clear();
        }

        private string GetNewFilePath(string filePath)
        {
            if (File.Exists(filePath))
            {
                FileInfo file = new FileInfo(filePath);
                return Path.Combine(file.DirectoryName, this.GetNewFileName(Path.GetFileNameWithoutExtension(file.Name)) + file.Extension);
            }
            return filePath;
        }

        private string GetNewFileName(string fileName)
        {
            int leftIndex = fileName.LastIndexOf('(');
            int rightIndex = fileName.LastIndexOf(')');

            if (leftIndex > 0 && rightIndex == fileName.Length - 1)
            {
                string numberStr = fileName.Substring(leftIndex + 1, rightIndex - leftIndex - 1);
                int number = 0;
                if (int.TryParse(numberStr, out number))
                {
                    return $"{fileName.Substring(0, leftIndex)}({number + 1})";
                }
            }
            return fileName + "(1)";
        }

        private void P_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                Process process = sender as Process;
                if (process != null)
                {
                    if (this.processFiles.ContainsKey(process))
                    {
                        string filePath = this.processFiles[process];

                        if (!this.dictFileConverted.ContainsKey(filePath))
                        {
                            try
                            {
                                process.ErrorDataReceived -= this.P_ErrorDataReceived;
                                process.Kill();
                                this.processFiles.Remove(process);
                                this.RunningCount--;
                            }
                            catch (Exception ex)
                            {
                            }

                            return;
                        }

                        string message = filePath + ":" + e.Data;
                        if (this.Setting.EnableDebug)
                        {
                            Console.WriteLine(message);
                        }

                        string data = e.Data.ToLower();
                        ConvertTaskState taskState = ConvertTaskState.Running;

                        bool hasError = false;

                        MatchCollection matches = errorRegex.Matches(data);
                        if (matches != null && matches.Count > 0)
                        {
                            hasError = true;
                            taskState = ConvertTaskState.Error;
                            this.dictFileConverted[filePath] = taskState;
                            this.RunningCount--;
                        }
                        else
                        {
                            if (this.dictFileConverted[filePath] == ConvertTaskState.Ready)
                            {
                                this.dictFileConverted[filePath] = ConvertTaskState.Running;
                                taskState = ConvertTaskState.Running;
                                this.RunningCount++;
                            }
                        }

                        this.Feedback(new VideoInfo(filePath) { TaskState = taskState, CurrentTime = this.GetCurrentTime(e.Data) }, e.Data, false, hasError);
                    }
                }
            }
        }

        private TimeSpan GetCurrentTime(string data)
        {
            TimeSpan ts = new TimeSpan();
            if (data.Contains("frame") && data.Contains("time"))
            {
                string[] items = data.Split(' ');
                string timeItem = items.Where(item => item.Contains("time")).FirstOrDefault();
                if (timeItem != null && timeItem.Contains("="))
                {
                    string time = timeItem.Split('=')[1].Trim();
                    if (!time.StartsWith("-"))
                    {
                        ts = TimeSpan.Parse(time);
                    }
                }
            }
            return ts;
        }

        private bool IsInSameFolder(string file1, string file2)
        {
            return new FileInfo(file1).DirectoryName == new FileInfo(file2).DirectoryName;
        }

        public void Subscribe(IObserver<FeedbackInfo> observer)
        {
            this.observer = observer;
        }

        protected virtual void Feedback(VideoInfo info, string content, bool isDone = false, bool enableLog = true)
        {
            string fileName = DateTime.Now.ToString("yyyyMMdd") + ".txt";

            string logFolder = Path.Combine(this.CurrentFolder, "log");

            if (!Directory.Exists(logFolder))
            {
                Directory.CreateDirectory(logFolder);
            }

            string logFilePath = Path.Combine(logFolder, fileName);

            FeedbackHelper.Feedback(this.observer, new FeedbackInfo() { Content = content, Source = info, IsDone = isDone }, logFilePath, enableLog);
        }

        public void Terminate()
        {
            foreach (Process p in Process.GetProcesses())
            {
                try
                {
                    if (p.ProcessName == Path.GetFileNameWithoutExtension(this.toolFileName))
                    {
                        if (this.toolFilePaths.Contains(p.MainModule.FileName))
                        {
                            p.Kill();
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }


            this.toolFilePaths.ForEach(item =>
            {
                if (File.Exists(item) && new FileInfo(item).FullName != new FileInfo(Path.Combine(this.CurrentFolder, this.toolFileName)).FullName)
                {
                    try
                    {
                        File.Delete(item);
                    }
                    catch (Exception ex)
                    {
                    }
                }
            });
        }
    }
}
