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
        public string Encoder { get; set; }
    }    
}
