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
            int paymentСount = 0;
            Queue<int> payments = new Queue<int>();
            AddPurchases(ref payments, 23);
            AddPurchases(ref payments, 21);
            AddPurchases(ref payments, 67);
            AddPurchases(ref payments, 43);
            AddPurchases(ref payments, 56);

            while (payments.Count != 0)
            {
                ShowAllPurchases(payments, ref paymentСount);
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void AddPurchases (ref Queue <int> payments, int pay)
        {
            payments.Enqueue(pay);
        }

        static void ShowAllPurchases (Queue <int> payments, ref int paymentСount)
        {
            int pay = payments.Dequeue();
            paymentСount += pay;
            Console.WriteLine("купили на " + pay);
            Console.WriteLine("На счету " + paymentСount);
        }
    }
}
