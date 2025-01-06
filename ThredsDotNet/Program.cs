

namespace ThredsDotNet
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine(" {0} main thread start  ", Thread.CurrentThread.ManagedThreadId);
            //Task task = Task.Factory.StartNew(doSomething);
            //task.Start();
            //Task.Run(() => { doSomething(); });
            //task.Wait();

            Task<int> task = Task.Run(() => { 
              return getResult(13); 
            });

            //task.Wait();

            Console.WriteLine("the result is {0}", task.Result);

            Console.WriteLine(" {0} main thread end  ", Thread.CurrentThread.ManagedThreadId);
        }

        static int getResult(int count)
        {
            int val = 0;
            Console.WriteLine(" {0} nested thread start  ", Thread.CurrentThread.ManagedThreadId);
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("index is {0}", i);
                val += i;
            }
            Console.WriteLine(" {0} nested thread end  ", Thread.CurrentThread.ManagedThreadId);
            return val;
        }


        static void doSomething()
        {
            Console.WriteLine(" {0} nested thread start  ", Thread.CurrentThread.ManagedThreadId);
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("index is {0}",  i);
            }
            Console.WriteLine(" {0} nested thread end  ", Thread.CurrentThread.ManagedThreadId);
        }
    }
}


