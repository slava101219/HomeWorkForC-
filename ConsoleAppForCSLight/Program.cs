using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppForCSLight
{
    class Program
    {
        static void Main(string[] args)
        {
            int paymentAcount = 0;
            Queue<int> payments = new Queue<int>();

            AddPurchases(payments);

            while (payments.Count != 0)
            {
                CustomerService(payments, ref paymentAcount);
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void AddPurchases (Queue <int> payments)
        {
            payments.Enqueue(23);
            payments.Enqueue(21);
            payments.Enqueue(67);
            payments.Enqueue(43);
            payments.Enqueue(56);
        }

        static void CustomerService (Queue <int> payments,ref int paymentAcount)
        {
            int pay = payments.Dequeue();
            paymentAcount += pay;
            Console.WriteLine("купили на " + pay);
            Console.WriteLine("На счету " + paymentAcount);
        }
    }
}
