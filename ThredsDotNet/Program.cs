

using System;

namespace ThredsDotNet
{
    public delegate void CallBackDel(int sum); 

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main Theard Start");
            Thread t1 = new Thread(m1);
            Thread t2 = new Thread(m2);
            t1.Start();
            t2.Start();

            if (t1.Join(1000))
            {
                Console.WriteLine("M1 Completed");
            }

            t2.Join();
            Console.WriteLine("M2 Completed");

            if (!t1.IsAlive)
            {
                Console.WriteLine("M1 apported");
            }
            else
            {
                Console.WriteLine("M1 IsAlive");
            }
            Console.WriteLine("Main Theard End");
        }

        static void m1()
        {
            Console.WriteLine("Start M1 ");
            Thread.Sleep(3000);
            Console.WriteLine("End M1 ");
        }

        static void m2()
        {
            Console.WriteLine("Start M2");
        }
    }
}


