
using System.Threading;

namespace ThredsDotNet
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Main Theard Start");
            Account account1 = new Account(4000, "Ahmed");
            Account account2 = new Account(2000, "Mohamed");

            AccountTransfere transfere1 = new AccountTransfere(account1, account2, 1000);
            AccountTransfere transfere2 = new AccountTransfere(account2, account1, 500);

            Thread thread1 = new Thread(transfere1.doTransfer);
            Thread thread2 = new Thread(transfere2.doTransfer);
            thread1.Name = "t1";
            thread2.Name = "t2";
            
            thread1.Start();
            thread2.Start();
            

            thread1.Join();
            thread2.Join();

            Console.WriteLine("Main Theard End");
        }
    }

    public class AccountTransfere
    {
        Account _fromAccount;
        Account _toAccount;
        double _amount;

        public AccountTransfere(Account from, Account to, double amount)
        {
            _fromAccount = from;
            _toAccount = to;
            _amount = amount;
        }

        public void doTransfer()
        {
            object _lock1, _lock2;
            if (_fromAccount.name == "Ahmed")
            {
                _lock1 = _fromAccount;
                _lock2 = _toAccount;
            }
            else
            {
                _lock1 = _toAccount;
                _lock2 = _fromAccount;
            }
            Console.WriteLine("Thred {0} try to access {1} ", Thread.CurrentThread.Name, _fromAccount.name);
            if (Monitor.TryEnter(_lock1, 3000))
            {
                try
                {
                    Console.WriteLine("Thred {0} start work {1} ", Thread.CurrentThread.Name, _toAccount.name);
                    Thread.Sleep(2000);
                    Console.WriteLine("Thred {0} try to access {1} ", Thread.CurrentThread.Name, _toAccount.name);
                    if (Monitor.TryEnter(_lock2, 3000))
                    {
                        try
                        {
                            Console.WriteLine("Thred {0} now in process", Thread.CurrentThread.Name);
                            _fromAccount.getCash(_amount);
                            _toAccount.addCash(_amount);
                        }
                        finally
                        {
                            Monitor.Exit(_lock2);
                        }
                    }
                }
                finally
                {
                    Monitor.Exit(_lock1);
                }
            }
            else
            {
                Console.WriteLine("Thred {0} time out", Thread.CurrentThread.Name);
            }
        }
    }

    public class Account
    {
        double _balance;
        string _name;

        public Account(double balance, string name)
        {
            _balance = balance;
            _name = name;
        }

        public string name
        {
            get { return _name; }
        }

        public void getCash(double cash)
        { 
           _balance -= cash;
        }

        public void addCash(double cash)
        { 
           _balance += cash;
        }
    }
}


