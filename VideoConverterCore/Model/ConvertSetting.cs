namespace VideoConvertCore
{
    public class ConvertSetting
    {
        public int TaskParallelLimit { get; set; } = 2;
        public int ThreadNumber { get; set; } = 1;
        public bool UseDefaultThreadNumber { get; set; }
        public bool EnableLog { get; set; }
        public bool EnableDebug { get; set; }
    }    
}
