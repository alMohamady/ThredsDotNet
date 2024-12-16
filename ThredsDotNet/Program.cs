

using System.Diagnostics;

namespace ThredsDotNet
{
    public delegate void CallBackDel(int sum); 

    internal class Program
    {
        static object _lock = new object();
        static int Count = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Main Theard Start");

            //Stopwatch sw = Stopwatch.StartNew();

            //Thread t1 = new Thread(increment);
            //Thread t2 = new Thread(increment);
            //Thread t3 = new Thread(increment);

            //t1.Start();
            //t2.Start();
            //t3.Start();

            //t1.Join();
            //t2.Join();
            //t3.Join();

            //Console.WriteLine("The Total : {0}", Count);

            //sw.Stop();
            //Console.WriteLine("The time is {0}", sw.ElapsedTicks);

            Thread t1 = new Thread(method01);
            Thread t2 = new Thread(method02);

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            Console.WriteLine("Main Theard End");
        }

        public static void method01()
        {
            Monitor.Enter(_lock);
            for (int i = 0; i < 5; i++)
            {
                Monitor.Pulse(_lock);
                Console.WriteLine("Method 1 working : {0}", i);

                Console.WriteLine("Method 1 Completed : {0}", i);
                Monitor.Wait(_lock);
            }
        }

        public static void method02()
        {
            Monitor.Enter(_lock);
            for (int i = 0; i < 5; i++)
            {
                Monitor.Pulse(_lock);
                Console.WriteLine("Method 2 working : {0}", i);

                Console.WriteLine("Method 2 Completed : {0}", i);
                Monitor.Wait(_lock);
            }
        }


        static void increment()
        {
            for (int i = 0; i < 500000; i++)
            {
                //Count++;
                //Interlocked.Increment(ref Count);
                //lock (obj)
                //{ 
                //   Count++;
                //}
                bool lockToken = false;
                Monitor.Enter(_lock, ref lockToken);
                try
                {
                    Count++;
                }
                finally { 
                    if (lockToken)
                        Monitor.Exit(_lock); 
                }
            }
        }

    }
}


