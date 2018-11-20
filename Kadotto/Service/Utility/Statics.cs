using System.Configuration;

namespace Service.Utility
{
    public class Statics
    {
        public static string ClientFilePath { get { return ConfigurationManager.AppSettings["ClientFilePath"]; } }
        public static string TempFilePath { get { return ConfigurationManager.AppSettings["TempFilePath"]; } }
        public static string BoxFilePath { get { return ConfigurationManager.AppSettings["BoxFilePath"]; } }
    }
}
