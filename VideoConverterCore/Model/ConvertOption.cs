using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoConvertCore
{
    public class ConvertOption
    {
        public string SaveFolder { get; set; }
        public string FileType { get; set; }
        public string CustomCommand { get; set; }
        public int Quality { get; set; }
        public int? ResolutionWidth { get; set; }
        public int? ResolutionHeight { get; set; }
    }    
}
