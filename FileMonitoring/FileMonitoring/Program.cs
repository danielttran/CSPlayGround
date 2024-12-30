using System.Text.RegularExpressions;
using HtmlAgilityPack;
using System.Xml.Serialization;
using System.Diagnostics;

namespace FileMonitoring
{

    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        private static string htmlUrl = ""; // Replace with your HTML URL
        private static string wordToCount = ""; // The word you want to count
        private static int expectedCount = 0;
        private static int minuteToCheck = 30;
        private static readonly string logFilePath = "html_monitor.log";

        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting HTML Monitor...");
            LogAndShow("Application started.");
            if (args.Length != 4)
            {
                Console.WriteLine("Please enter URL you want to monitor");
                htmlUrl = Console.ReadLine();
                Console.WriteLine("Please enter word to count");
                wordToCount = Console.ReadLine();
                Console.WriteLine("Please enter the expected count");
                int.TryParse(Console.ReadLine(), out expectedCount);
                Console.WriteLine("Please enter the interval minutes to check");
                int.TryParse(Console.ReadLine(), out minuteToCheck);
            }
            else
            {
                htmlUrl = args[0];
                wordToCount = args[1];
                int.TryParse(args[2], out expectedCount);
                int.TryParse(args[3], out minuteToCheck);
            }

            while (true)
            {
                try
                {
                    await CheckHtmlForChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    LogAndShow($"Error: {ex.Message}");
                }

                await Task.Delay(TimeSpan.FromMinutes(minuteToCheck));
            }
        }

        static async Task CheckHtmlForChanges()
        {
            Console.WriteLine("Checking HTML...");
            LogAndShow("Checking HTML...");

            try
            {
                using (var response = await client.GetAsync(htmlUrl))
                {
                    response.EnsureSuccessStatusCode();

                    string htmlContent = await response.Content.ReadAsStringAsync();

                    int currentCount = CountWordInHtml(htmlContent, wordToCount);

                    if (currentCount != expectedCount)
                    {
                        var output = $"Count of '{wordToCount}' has changed! Expecting {expectedCount}, yet found: {currentCount}";
                        LogAndShow($"Count of '{wordToCount}' has changed! Expecting {expectedCount}, yet found: {currentCount} at URL {htmlUrl}");
                        Process.Start("notepad.exe", logFilePath);
                    }
                    else
                    {
                        var output = $"Count of '{wordToCount}' has not changed: {currentCount} is expected";
                        LogAndShow(output);
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error downloading HTML: {ex.Message}");
                LogAndShow($"Error downloading HTML: {ex.Message}");
            }
        }

        static int CountWordInHtml(string html, string word)
        {
            // Use HtmlAgilityPack to parse the HTML and extract text content
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            // Select all text nodes and concatenate their content
            string textContent = string.Join(" ", doc.DocumentNode.SelectNodes("//text()")?.Select(n => n.InnerText) ?? new string[0]);

            // Use Regex for case-insensitive and whole-word matching
            return Regex.Matches(textContent, $@"\b{Regex.Escape(word)}\b", RegexOptions.IgnoreCase).Count;
        }

        static void LogAndShow(string message)
        {
            try
            {
                using (StreamWriter writer = File.AppendText(logFilePath))
                {
                    var output = $"UTC {DateTime.UtcNow:g}: {message}";
                    writer.WriteLine(output);
                    Console.WriteLine(output);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to log: {ex.Message}");
            }
        }
    }
}