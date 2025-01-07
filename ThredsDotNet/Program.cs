
using System.Diagnostics;

namespace ThredsDotNet
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine(" {0} main thread start  ", Thread.CurrentThread.ManagedThreadId);

            Console.WriteLine("start parallel loop C#");
            ParallelOptions parallelOptions = new ParallelOptions() { 
               MaxDegreeOfParallelism = -1,
            };

            int count = 0;

            Parallel.For(0, 10, parallelOptions,  (x, breakLoop) => {

                count += 1;
                if (count >= 5)
                {
                    Console.WriteLine("loop will break {0}", count);
                    breakLoop.Break();
                }
                else
                {
                    Console.WriteLine(" {0} parallel working on val {1}  ", Thread.CurrentThread.ManagedThreadId, count);
                    Thread.Sleep(100);
                }
            });


            Console.WriteLine(" {0} main thread end  ", Thread.CurrentThread.ManagedThreadId);
            Console.ReadKey();
        }
    }
}


