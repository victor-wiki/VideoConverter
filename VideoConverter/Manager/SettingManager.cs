using Newtonsoft.Json;
using System.IO;
using VideoConvertCore;

namespace VideoConverter
{
    public class SettingManager
    {
        private const string settingFileName = "setting.json";
        private static ConvertSetting _setting;

        public static ConvertSetting Setting
        {
            get
            {
                if(_setting==null)
                {
                    return GetSetting();
                }
                return _setting;
            }

        }

        public static ConvertSetting GetSetting()
        {
            if(File.Exists(settingFileName))
            {
                string content = File.ReadAllText(settingFileName);
                ConvertSetting setting = (ConvertSetting) JsonConvert.DeserializeObject(content, typeof(ConvertSetting));
                return setting;
            }
            else
            {
                return new ConvertSetting();
            }
        }

        public static void SaveSetting(ConvertSetting setting)
        {
            _setting = setting;
            string content = JsonConvert.SerializeObject(setting, Formatting.Indented);
            File.WriteAllText(settingFileName, content);
        }
    }
}
