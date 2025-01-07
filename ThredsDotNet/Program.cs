
using System.Diagnostics;

namespace ThredsDotNet
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine(" {0} main thread start  ", Thread.CurrentThread.ManagedThreadId);

            //Console.WriteLine("start parallel loop C#");
            ParallelOptions parallelOptions = new ParallelOptions()
            {
                MaxDegreeOfParallelism = 2,
            };

            //List<int> collection = Enumerable.Range(0, 10).ToList();

            //Parallel.ForEach(collection, parallelOptions, item =>
            //{
            //    Console.WriteLine(" {0} Parallel thread val {1}  ", Thread.CurrentThread.ManagedThreadId, item);
            //});

            Parallel.Invoke(parallelOptions, 
                () => doThometing(10),
                () => doThometing(20),
                delegate  () {
                    Console.WriteLine(" {0} method 2 ", Thread.CurrentThread.ManagedThreadId);
                },
                () => Console.WriteLine(" {0} method 3 ", Thread.CurrentThread.ManagedThreadId)
                
                );




            Console.WriteLine(" {0} main thread end  ", Thread.CurrentThread.ManagedThreadId);
            Console.ReadKey();
        }


        static void doThometing(int val)
        {
            Console.WriteLine(" {0} thread # and val {1}  ", Thread.CurrentThread.ManagedThreadId, val);
        }
    }
}


