using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace VideoConvertCore
{
    public class ConvertHandler
    {
        private IObserver<FeedbackInfo> observer;
        private string CurrentFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        private string toolFileName = "ffmpeg.exe";
        private List<Process> processes = new List<Process>();

        private Dictionary<string, string> dictFilePath = new Dictionary<string, string>();
        private Dictionary<string, ConvertTaskState> dictFileConverted = new Dictionary<string, ConvertTaskState>();
        private static object obj = new object();
        private List<string> toolFilePaths = new List<string>();

        public ConvertSetting Setting = new ConvertSetting();
        public ConvertOption Option = new ConvertOption();

        public List<string> FilePaths { get; set; } = new List<string>();
        public List<Process> Processes { get { return this.processes; } }

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
                if (!this.dictFileConverted.ContainsKey(filePath))
                {
                    this.dictFileConverted.Add(filePath, ConvertTaskState.Ready);
                }
                else
                {
                    this.dictFileConverted[filePath] = ConvertTaskState.Ready;
                }
            }

            var initItems = this.FilePaths.Take(this.Setting.TaskParallelLimit);
            foreach (var item in initItems)
            {
                this.Execute(this.Option.SaveFolder, item);
            }
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

                this.processes.Add(p);

                p.StartInfo.FileName = "cmd.exe";

                string args = "";

                if (!string.IsNullOrEmpty(this.Option.CustomCommand))
                {
                    args = this.Option.CustomCommand.Replace(this.toolFileName, "").Replace(Path.GetFileNameWithoutExtension(this.toolFileName), "");
                    args = args.Replace("##SourceFile##", $"\"{fileName}\"").Replace("##TargetFile##", $"\"{targetFileName}\"");
                }
                else
                {
                    string resolution = "";
                    if (this.Option.ResolutionWidth.HasValue && this.Option.ResolutionHeight.HasValue)
                    {
                        resolution = $"-s {this.Option.ResolutionWidth.Value}x{this.Option.ResolutionHeight.Value}";
                    };

                    args = $"-i \"{fileName}\" -c:v libx264 -crf {this.Option.Quality} {resolution} \"{targetFileName}\"";
                }

                string cmd = $"{this.toolFileName} {args}";

                videoInfo.TaskState = ConvertTaskState.Running;
                this.Feedback(videoInfo, $"Run command:{cmd}", false, true);

                p.StartInfo.Arguments = file.FullName;
                p.ErrorDataReceived += P_ErrorDataReceived;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.Start();

                string folder = Path.GetDirectoryName(exeFilePath);
                p.StandardInput.WriteLine(Path.GetPathRoot(folder).Trim('\\'));
                p.StandardInput.WriteLine($"cd {folder}");
                p.StandardInput.WriteLine(cmd);

                p.BeginErrorReadLine();

                p.StandardInput.AutoFlush = true;
                p.StandardInput.Flush();
                p.StandardInput.Close();
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
                   
                    if (this.dictFileConverted[filePath] == ConvertTaskState.Running)
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
                            File.Delete(exeFilePath);
                        }

                        this.Feedback(null, "Done", true, true);

                        this.Clearup();
                    }
                    else
                    {
                        var fp = this.dictFileConverted.Skip(this.Setting.TaskParallelLimit).Where(item => item.Value == ConvertTaskState.Ready).FirstOrDefault();
                        if (!string.IsNullOrEmpty(fp.Key))
                        {
                            this.dictFileConverted[fp.Key] = ConvertTaskState.Running;
                            this.Execute(saveFolder, fp.Key);
                        }
                    }
                }
            });
        }

        private void Clearup()
        {
            this.dictFilePath.Clear();
            this.dictFileConverted.Clear();
            this.toolFilePaths.Clear();
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
                string numberStr = fileName.Substring(leftIndex + 1, rightIndex - leftIndex-1);
                int number = 0;
                if (int.TryParse(numberStr, out number))
                {
                    return $"{fileName.Substring(0, leftIndex)}({ number + 1})";
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
                    string args = process.StartInfo.Arguments;
                    if (!string.IsNullOrEmpty(args))
                    {
                        string filePath = args;

                        string message = filePath + ":" + e.Data;
                        if (this.Setting.EnableDebug)
                        {
                            Console.WriteLine(message);
                        }

                        string data = e.Data.ToLower();
                        ConvertTaskState taskState = ConvertTaskState.Running;

                        bool hasError = false;
                        if (data.Contains("invalid") || data.Contains("error"))
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
                                taskState= ConvertTaskState.Running;
                                this.RunningCount++;
                            }
                        }                        

                        this.Feedback(new VideoInfo(args) { TaskState = taskState, CurrentTime = this.GetCurrentTime(e.Data) }, e.Data, false, hasError);
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
                    if(!time.StartsWith("-"))
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
                    if (this.toolFilePaths.Contains(p.MainModule.FileName) ||
                    this.processes.Any(item => item != null && item.Id == p.Id))
                    {
                        p.Kill();
                    }
                }
                catch (Exception ex)
                {
                }
            }

            this.toolFilePaths.ForEach(item => 
            {
                if(File.Exists(item) && new FileInfo(item).FullName != new FileInfo(Path.Combine(this.CurrentFolder, this.toolFileName)).FullName)
                {
                    File.Delete(item);
                }
            });            
        }
    }
}
