

namespace ThredsDotNet
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine(" {0} main thread start  ", Thread.CurrentThread.ManagedThreadId);

            Task<string> task = Task.Run(() => { 
              return getResult(13); 
            }).ContinueWith((info) => { 
                Console.WriteLine("The Result 1 is {0} ", info.Result);
               return info.Result.ToString();
            }).ContinueWith((infoPlus) => {
                Thread.Sleep(1000);
                Console.WriteLine("The Result 2 is {0} ", infoPlus.Result);
                return infoPlus.Result.ToString();
            });


            task.ContinueWith((info) =>
            {
                Console.WriteLine("The Result 3 is {0} ", info.Result);
                Console.WriteLine("The IsFaulted is {0} ", info.IsFaulted);
                Console.WriteLine("The IsCompleted is {0} ", info.IsCompleted);
                Console.WriteLine("The IsCanceled is {0} ", info.IsCanceled);
                Console.WriteLine("The Ex msg is {0} ", info.Exception?.Message);
            });

            task.ContinueWith((info) =>
            {
                Console.WriteLine("do if canceld");
            }, TaskContinuationOptions.OnlyOnCanceled);


            task.ContinueWith((info) =>
            {
                Console.WriteLine("do if completed");
            }, TaskContinuationOptions.OnlyOnRanToCompletion);


            //Console.WriteLine("the result is {0}", task.Result);

            Console.WriteLine(" {0} main thread end  ", Thread.CurrentThread.ManagedThreadId);
            Console.ReadKey();
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

    }
}


