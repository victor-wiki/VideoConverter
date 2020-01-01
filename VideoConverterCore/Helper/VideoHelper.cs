using MediaToolkit;
using MediaToolkit.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    return new Engine();
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
