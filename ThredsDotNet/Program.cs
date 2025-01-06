
namespace ThredsDotNet
{
    internal class Program
    {

        static async Task Main(string[] args)
        {
            Console.WriteLine(" {0} main thread start  ", Thread.CurrentThread.ManagedThreadId);

            await CallMe();

            Console.WriteLine(" {0} main thread end  ", Thread.CurrentThread.ManagedThreadId);
            Console.ReadKey();
        }

        static async Task CallMe()
        {
            Console.WriteLine("Hi I'am calling you");
            string processVal = await process(true);
            Console.WriteLine("Call with value {0}", processVal);
        }

        static Task<string> process(bool ok)
        {
            return Task.Run(() =>
            {
                try
                {
                    Thread.Sleep(1000);
                    if (ok)
                        throw new Exception("My Ex");

                    return "process completed";
                }
                catch (Exception ex)
                { 
                    return ex.Message;
                }
            });
        }
    }
}


