
using System.Threading;

namespace ThredsDotNet
{
    internal class Program
    {

        //static Mutex mutex = new Mutex();
        static Semaphore semaphore = new Semaphore(2, 2);

        static void Main(string[] args)
        {
            Console.WriteLine("Main Theard Start");

            for (int i = 0; i < 5; i++)
            {
                new Thread(method00).Start();
            }

            //Thread.Sleep(3000);
            //mutex.ReleaseMutex();

            Console.WriteLine("Main Theard End");
        }

        public static void method00()
        {
            Console.WriteLine(" {0} : Method 0 wating", Thread.CurrentThread.ManagedThreadId);
            //mutex.WaitOne();
            semaphore.WaitOne();
            Console.WriteLine(" {0} : Method 0 working", Thread.CurrentThread.ManagedThreadId);

            Thread.Sleep(5000);
            Console.WriteLine(" {0} : Method 0 Completed", Thread.CurrentThread.ManagedThreadId);
            //mutex.ReleaseMutex();
            semaphore.Release();
        }
    }
}


