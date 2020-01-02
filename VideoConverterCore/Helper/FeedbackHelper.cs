using System;

namespace VideoConvertCore
{
    public class FeedbackHelper
    {
        public static bool EnableLog { get; set; }

        public static void Feedback(IObserver<string> observer, string info)
        {
            if (observer != null)
            {
                observer.OnNext(info);
            }
        }

        public static void Feedback(IObserver<string> observer, string info, string logFilePath)
        {
            Feedback(observer, info);

            if(EnableLog)
            {
                LogHelper.LogInfo(logFilePath, info);
            }            
        }

        public static void Feedback(IObserver<FeedbackInfo> observer, FeedbackInfo info)
        {
            if (observer != null)
            {
                observer.OnNext(info);
            }
        }

        public static void Feedback(IObserver<FeedbackInfo> observer, FeedbackInfo info, string logFilePath, bool enableLog=true)
        {
            Feedback(observer, info);

            if(EnableLog && enableLog)
            {
                string prefix = "";
                if (info.Source != null && info.Source.GetType() == typeof(VideoInfo))
                {
                    prefix = ((VideoInfo)info.Source).Name + ":";
                }

                LogHelper.LogInfo(logFilePath, prefix + info.Content);
            }           
        }
    }
}
