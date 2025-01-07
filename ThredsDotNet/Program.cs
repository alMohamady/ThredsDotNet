
using System.Diagnostics;

namespace ThredsDotNet
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine(" {0} main thread start  ", Thread.CurrentThread.ManagedThreadId);

            Stopwatch sw = Stopwatch.StartNew();
            Console.WriteLine("start noraml loop C#");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(" {0}  thread working on val {1}  ", Thread.CurrentThread.ManagedThreadId, i);
                Thread.Sleep(100);
            }
            sw.Stop();
            Console.WriteLine("time is {0} ",sw.ElapsedMilliseconds);

            sw = Stopwatch.StartNew();
            Console.WriteLine("start parallel loop C#");
            Parallel.For(0, 10, x => {
                Console.WriteLine(" {0} parallel working on val {1}  ", Thread.CurrentThread.ManagedThreadId, x);
                Thread.Sleep(100);
            });
            sw.Stop();
            Console.WriteLine("time is {0} ", sw.ElapsedMilliseconds);

            Console.WriteLine(" {0} main thread end  ", Thread.CurrentThread.ManagedThreadId);
            Console.ReadKey();
        }
    }
}


