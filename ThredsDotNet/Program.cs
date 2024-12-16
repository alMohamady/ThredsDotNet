
namespace ThredsDotNet
{
    internal class Program
    {

        static ManualResetEvent resetEvent = new ManualResetEvent(false);
        static AutoResetEvent auto = new AutoResetEvent(true);

        static void Main(string[] args)
        {
            Console.WriteLine("Main Theard Start");

            //Thread t1 = new Thread(method01);
            //t1.Start();

            //for (int i = 0; i < 5; i++)
            //{
            //    new Thread(method02).Start();
            //}

            for (int i = 0; i < 5; i++)
            {
                new Thread(method00).Start();
            }

            Console.WriteLine("Main Theard End");
        }

        public static void method00()
        {
            Console.WriteLine("Method 0 wating");
            auto.WaitOne();
            Console.WriteLine("Method 0 working");

            Thread.Sleep(5000);
            Console.WriteLine("Method 0 Completed");
            auto.Set();
        }

        public static void method01()
        {
            Console.WriteLine("Method 1 working");
            resetEvent.Reset();
            Thread.Sleep(5000);
            Console.WriteLine("Method 1 Completed");
            resetEvent.Set();
        }

        public static void method02()
        {
            Console.WriteLine("Method 2 working");
            resetEvent.WaitOne();
            Console.WriteLine("Method 2 Completed");
        }
    }
}


