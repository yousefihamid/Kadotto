namespace Common.Utility
{
    public class DisplayFormat
    {
        public static string DateStringFormat { get { return System.Configuration.ConfigurationManager.AppSettings["DateStringFormat"]; } }
        public static string DateStringPersianFormat { get { return System.Configuration.ConfigurationManager.AppSettings["DateStringPersianFormat"]; } }
        public static string DecimalStringFormat { get { return System.Configuration.ConfigurationManager.AppSettings["DecimalStringFormat"]; } }
        public static string DateDisplayFormat { get { return System.Configuration.ConfigurationManager.AppSettings["DateDisplayFormat"]; } }
        public static string DecimalDisplayFormat { get { return System.Configuration.ConfigurationManager.AppSettings["DecimalDisplayFormat"]; } }
        public static string DateTimeStringPersianFormat { get { return System.Configuration.ConfigurationManager.AppSettings["DateTimeStringPersianFormat"]; } }

        public static string ProjectTitleFormat { get { return System.Configuration.ConfigurationManager.AppSettings["ProjectTitleFormat"]; } }
        public static string EmployeeNameFormat { get { return System.Configuration.ConfigurationManager.AppSettings["EmployeeNameFormat"]; } }

        public static string DefaultLanguage { get { return System.Configuration.ConfigurationManager.AppSettings["DefaultLanguage"]; } }
    }
}
