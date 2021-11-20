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
            double usdCount = 1000;
            double eurCount = 1000;
            double rubCount = 1000;
            double changeMoneyCount;
            double exchangeRateUsdToEur = 0.88;
            double exchangeRateUsdToRub = 73.21;
            double exchangeRateEurToUsd = 1.13;
            double exchangeRateEurToRub = 83.1;
            double exchangeRateRubToUsd = 0.014;
            double exchangeRateRubToEur = 0.012;
            string selectionUser = "0";
            string spaceNine = "         ";

            while (selectionUser != "7")
            {
                Console.WriteLine("usd : " + usdCount + " eur : " + eurCount + " rub : " + rubCount);
                Console.WriteLine("ввести : 1 для usd => eur;\n" + spaceNine + "2 для usd => rub;\n" + spaceNine + "3 для eur => usd;\n" +
                spaceNine + "4 для eur => rub;\n" + spaceNine + "5 для rub => usd;\n" + spaceNine + "6 для rub => eur;\n" + spaceNine +
                "7 для выхода");
                selectionUser = Console.ReadLine();

                if (selectionUser == "1")
                {
                    Console.WriteLine("сколько меняем?");
                    changeMoneyCount = Convert.ToDouble(Console.ReadLine());
                    usdCount -= changeMoneyCount;
                    eurCount = eurCount + changeMoneyCount * exchangeRateUsdToEur;                                       
                }

                else if (selectionUser == "2")
                {
                    Console.WriteLine("сколько меняем?");
                    changeMoneyCount = Convert.ToDouble(Console.ReadLine());
                    usdCount -= changeMoneyCount;
                    rubCount = rubCount + changeMoneyCount * exchangeRateUsdToRub;
                }

                else if (selectionUser == "3")
                {
                    Console.WriteLine("сколько меняем?");
                    changeMoneyCount = Convert.ToDouble(Console.ReadLine());
                    eurCount -= changeMoneyCount;
                    usdCount = usdCount + changeMoneyCount * exchangeRateEurToUsd;
                }

                else if (selectionUser == "4")
                {
                    Console.WriteLine("сколько меняем?");
                    changeMoneyCount = Convert.ToDouble(Console.ReadLine());
                    eurCount -= changeMoneyCount;
                    rubCount = rubCount + changeMoneyCount * exchangeRateEurToRub;
                }

                else if (selectionUser == "5")
                {
                    Console.WriteLine("сколько меняем?");
                    changeMoneyCount = Convert.ToDouble(Console.ReadLine());
                    rubCount -= changeMoneyCount;
                    usdCount = usdCount + changeMoneyCount * exchangeRateRubToUsd;
                }

                else if (selectionUser == "6")
                {
                    Console.WriteLine("сколько меняем?");
                    changeMoneyCount = Convert.ToDouble(Console.ReadLine());
                    rubCount -= changeMoneyCount;
                    eurCount = eurCount + changeMoneyCount * exchangeRateRubToEur;
                }
            }
            Console.WriteLine("досвидания");
        }       
    }
}
