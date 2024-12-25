
using System.Net;
using System.Threading;

namespace ThredsDotNet
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string url = "https://google.com"; // URL of the content to download
            string destinationPath = "downloaded_file.html";

            using (WebClient webClient = new WebClient())
            {
                // Attach event handlers
                webClient.DownloadFileCompleted += WebClient_DownloadFileCompleted;
                webClient.DownloadProgressChanged += WebClient_DownloadProgressChanged;

                // Start asynchronous download
                Console.WriteLine("Starting download...");
                webClient.DownloadFileAsync(new Uri(url), destinationPath);

                Console.WriteLine("Downloading file asynchronously...");
                Console.ReadLine(); // Wait for user input to keep the console open
            }
        }

        // Event handler for download progress
        private static void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Console.WriteLine($"Download progress: {e.ProgressPercentage}%");
        }

        // Event handler for download completion
        private static void WebClient_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                Console.WriteLine($"Download failed: {e.Error.Message}");
            }
            else if (e.Cancelled)
            {
                Console.WriteLine("Download canceled.");
            }
            else
            {
                Console.WriteLine("Download completed successfully!");
            }
        }
    }
}


