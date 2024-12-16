

using System;

namespace ThredsDotNet
{
    public delegate void CallBackDel(int sum); 

    internal class Program
    {

        static CallBackDel? callBackDel;

        static void Main(string[] args)
        {
            Console.WriteLine("Main Theard Start");

            //ThreadStart ts = delegate () {
            //    for (int i = 0; i < 5; i++)
            //    {
            //        Console.WriteLine($"From 001 : {i}");
            //    }
            //};

            ParameterizedThreadStart start = new ParameterizedThreadStart(mathod01);
            callBackDel = callBack;
            Thread t1 = new Thread(start)
            {
                Name = "tMathod01"
            };

            t1.Start(12);
            
            Console.WriteLine("Main Theard End");
        }


        static void mathod01(object mx)
        {
            Console.WriteLine("Start of M1");
            int sum = 0;
            for (int i = 0; i < Convert.ToInt32(mx); i++)
            {
                Console.WriteLine($"From m1 : {i}");
                sum += i;
            }
            if (callBackDel != null)
            {
                callBackDel(sum);
            }
            Console.WriteLine("End of M1");
        }

        static void callBack(int sum)
        {
            Console.WriteLine("the Sumtion is {0}", sum);
        }
    }
}


