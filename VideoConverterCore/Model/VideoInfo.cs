using System;
using System.IO;

namespace VideoConvertCore
{
    public class VideoInfo
    {
        public string Name { get; set; }
        public string FilePath { get; set; }
        public VideoInfo(string filePath)
        {
            this.FilePath = filePath;
            this.Name = new FileInfo(filePath).Name;
        }
       
        public int Width { get; set; }
        public int Height { get; set; }
        public TimeSpan Duration { get; set; }
        public TimeSpan CurrentTime { get; set; }

        public ConvertTaskState TaskState { get; set; }

        public string TargetFilePath { get; set; }

        public string DurationString
        {
            get
            {
                return $"{Duration.Hours.ToString().PadLeft(2, '0')}:{Duration.Minutes.ToString().PadLeft(2,'0')}:{Duration.Seconds.ToString().PadLeft(2, '0')}";
            }
        }
    }
}
