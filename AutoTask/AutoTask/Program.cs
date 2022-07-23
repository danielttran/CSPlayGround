using System.Diagnostics;
using System.Runtime.InteropServices;

namespace AutoTask
{
    internal class Program
    {
        #region Hide Window
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        const int SW_HIDE = 0;

        /// <summary>
        /// We don't show the window running on client
        /// </summary>
        private static void HideWindow()
        {
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);
        }
        #endregion

        [STAThread]
        static void Main(string[] args)
        {
            // list of program to shutdown.
            // after build, create a shortcut in the startup location
            // by Window + R, then type shell:startup
            // the program should close any annoying process
            // on the weekend.
            List<string> ProcessesToShutdown = new List<string> { "Teams" };

            HideWindow();
            int seconds = 0;
            while (true)
            {

                if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday || DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
                {
                    foreach (var processName in ProcessesToShutdown)
                    {
                        ShutdownProcessByName(processName);
                    }
                }

                System.Threading.Thread.Sleep(5000);
                if (seconds++ / 60 > 1) // only run for 1 mins
                {
                    break;
                }
            }
        }

        private static void ShutdownProcessByName(string processName)
        {
            foreach (var process in Process.GetProcessesByName(processName))
            {
                process?.Kill();
            }
        }
    }
}