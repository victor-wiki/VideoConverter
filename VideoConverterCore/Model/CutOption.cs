using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoConvertCore
{
    public class CutOption
    {
        public double Starting { get; set; }
        public CutType CutType { get; set; }
        public double Duration { get; set; }
    }

    public enum CutType
    {
        Normal=0,
        IntroOutro=1
    }
}
