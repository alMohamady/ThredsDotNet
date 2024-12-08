

namespace ThredsDotNet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Thread t = Thread.CurrentThread;
            t.Name = "main thred";
            
            Console.WriteLine($"Thred name : {t.Name}");
            Console.WriteLine($"Thred name : {Thread.CurrentThread.Name}");

            mathod01();
            Console.WriteLine("End of M1");
            mathod02();
            Console.WriteLine("End of M2");
            mathod03();
            Console.WriteLine("End of M3");

        }


        static void mathod01()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"From m1 : {i}");
            }
        }
        static void mathod02()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"From m2 : {i}");
                if (i == 3)
                {
                    Console.WriteLine("Start from databse");
                    Thread.Sleep(10000);
                    Console.WriteLine("End from databse");
                }
            }
        }

        static void mathod03()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"From m3 : {i}");
            }
        }

    }
}


