using MediaToolkit;
using MediaToolkit.Model;
using System.Linq;

namespace VideoConvertCore
{
    public class VideoHelper
    {
        private static Engine _engine;
        private static Engine Engine
        {
            get
            {
                if(_engine==null)
                {
                    _engine = new Engine();
                }
                return _engine;
            }
        }       

        public static VideoInfo GetVideoInfo(string fileName)
        {
            var inputFile = new MediaFile { Filename = fileName };
            Engine.GetMetadata(inputFile);

            var video = inputFile.Metadata.VideoData;           
          
            int width = 0;
            int height = 0;
            
            if(video != null)
            {
                var size = video.FrameSize.Split(new[] { 'x' }).Select(o => int.Parse(o)).ToArray();
                width = size[0];
                height = size[1];
            }                     

            return new VideoInfo(fileName) { Width= width, Height= height, Duration= inputFile.Metadata.Duration };
        }
    }
}
