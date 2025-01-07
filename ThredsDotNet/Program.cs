
namespace ThredsDotNet
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine(" {0} main thread start  ", Thread.CurrentThread.ManagedThreadId);


            var vals = Enumerable.Range(0, 100);

            //.WithDegreeOfParallelism(2)

            var evens = from num in vals.AsParallel()
                        where num % 2 == 0
                        select num;

            evens.ForAll(x => Console.WriteLine(x));
            foreach (var ev in evens)
            {
                Console.WriteLine("number is {0}", ev);
            }


            Console.WriteLine(" {0} main thread end  ", Thread.CurrentThread.ManagedThreadId);
            Console.ReadKey();
        }


    }
}


