

namespace ThredsDotNet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main Theard Start");
            Thread t1 = new Thread(mathod01)
            {
                Name = "tMathod01"
            };
            Thread t2 = new Thread(mathod02)
            {
                Name = "tMathod02"
            };
            Thread t3 = new Thread(mathod03)
            {
                Name = "tMathod03"
            };

            t1.Start();
            t2.Start();
            t3.Start();

            Console.WriteLine("Main Theard End");
        }


        static void mathod01()
        {
            Console.WriteLine("Start of M1");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"From m1 : {i}");
            }
            Console.WriteLine("End of M1");
        }

        static void mathod02()
        {
            Console.WriteLine("Start of M2");
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
            Console.WriteLine("End of M2");
        }

        static void mathod03()
        {
            Console.WriteLine("Start of M3");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"From m3 : {i}");
            }
            Console.WriteLine("End of M3");
        }

    }
}


