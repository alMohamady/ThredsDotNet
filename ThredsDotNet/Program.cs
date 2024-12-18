
using System.Threading;

namespace ThredsDotNet
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Main Theard Start");
            for (int i = 0; i < 5; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(myThreadPool));
            }
            Console.WriteLine("Main Theard End");
            Console.ReadLine();
        }

        public static void myThreadPool(object obj)
        { 
            Thread thread = Thread.CurrentThread;
            Console.WriteLine($"""
                   Background: {thread.IsBackground}
                   Thread Pool: {thread.IsThreadPoolThread}
                   Thread Id: {thread.ManagedThreadId}
                """);
        }
    }
}


