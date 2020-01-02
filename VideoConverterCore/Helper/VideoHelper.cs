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

            var size = inputFile.Metadata.VideoData.FrameSize.Split(new[] { 'x' }).Select(o => int.Parse(o)).ToArray();

            return new VideoInfo(fileName) { Width= size[0], Height= size[1], Duration= inputFile.Metadata.Duration };
        }
    }
}
