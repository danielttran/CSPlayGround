namespace PowerPoint
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var title = RegisterApp();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new PowerPointHelperForm(title));
        }

        private static string RegisterApp()
        {
            var key = File.ReadAllText("key.txt").Trim();
            if (string.IsNullOrEmpty(key) == false)
            {
                Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(key);
                return "Power Point Helper is licensed";
            }
            else
            {
                return "Power Point Helper is Unlicensed";
            }
        }
    }
}