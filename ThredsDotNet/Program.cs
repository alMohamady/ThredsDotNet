
using System.Threading;

namespace ThredsDotNet
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Main Theard Start");
            string filePath = "example.txt";
            File.WriteAllText(filePath, "Hello, this is a test file for APM example!"); // Create a test file

            // Begin the asynchronous read operation
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 1024, true);
            byte[] buffer = new byte[fileStream.Length];

            IAsyncResult asyncResult = fileStream.BeginRead(buffer, 0, buffer.Length, ReadCallback, new Tuple<FileStream, byte[]>(fileStream, buffer));

            Console.WriteLine("Reading file asynchronously...");
            Console.ReadLine(); // Wait to keep the application open
        }

        static void ReadCallback(IAsyncResult asyncResult)
        {
            // Retrieve the state object
            var state = (Tuple<FileStream, byte[]>)asyncResult.AsyncState;
            FileStream fileStream = state.Item1;
            byte[] buffer = state.Item2;

            try
            {
                // Complete the asynchronous read operation
                int bytesRead = fileStream.EndRead(asyncResult);
                string content = System.Text.Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine($"File content:\n{content}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }
            finally
            {
                fileStream.Close();
            }
        }
    }
}


