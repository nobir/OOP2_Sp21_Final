using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountTransaction
{
    class Program
    {
        static void Main(string[] args)
        {
            var a0 = new Account("Nobir 1", "a000", 1000);
            var a1 = new Account("Nobir 2", "a111", 2000);

            a0.Deposit(10000);
            a0.Withdraw(5000);
            a0.Transfer(a1, 4000);

            Console.WriteLine("\n====== Account Balance ======\n");

            a0.ShowInfo();
            a1.ShowInfo();

            Console.WriteLine("\n====== Account Transactions List ======\n");

            a0.ShowAllTransaction();
            a1.ShowAllTransaction();
        }
    }
}
