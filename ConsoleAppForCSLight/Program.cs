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
            string spacesForArray = "         ";

            while (selectionUser != "7")
            {
                Console.WriteLine("usd : " + usdCount + " eur : " + eurCount + " rub : " + rubCount);
                Console.WriteLine("ввести : 1 для usd => eur;\n" + spacesForArray + "2 для usd => rub;\n" + spacesForArray + "3 для eur => usd;\n" +
                spacesForArray + "4 для eur => rub;\n" + spacesForArray + "5 для rub => usd;\n" + spacesForArray + "6 для rub => eur;\n" + spacesForArray +
                "7 для выхода");
                selectionUser = Console.ReadLine();
                
                if (selectionUser == "1")
                {
                    Console.WriteLine("сколько меняем?");
                    changeMoneyCount = Convert.ToDouble(Console.ReadLine());
                    while (changeMoneyCount > usdCount || changeMoneyCount < 0)
                    {
                        Console.WriteLine("Не верная сумма. Еще раз.");
                        changeMoneyCount = Convert.ToDouble(Console.ReadLine());
                    }
                    usdCount -= changeMoneyCount;
                    eurCount += changeMoneyCount * exchangeRateUsdToEur;                                       
                }

                else if (selectionUser == "2")
                {
                    Console.WriteLine("сколько меняем?");
                    changeMoneyCount = Convert.ToDouble(Console.ReadLine());
                    while (changeMoneyCount > usdCount || changeMoneyCount < 0)
                    {
                        Console.WriteLine("Не верная сумма. Еще раз.");
                        changeMoneyCount = Convert.ToDouble(Console.ReadLine());
                    }
                    usdCount -= changeMoneyCount;
                    rubCount += changeMoneyCount * exchangeRateUsdToRub;
                }

                else if (selectionUser == "3")
                {
                    Console.WriteLine("сколько меняем?");
                    changeMoneyCount = Convert.ToDouble(Console.ReadLine());
                    while (changeMoneyCount > eurCount || changeMoneyCount < 0)
                    {
                        Console.WriteLine("Не верная сумма. Еще раз.");
                        changeMoneyCount = Convert.ToDouble(Console.ReadLine());
                    }
                    eurCount -= changeMoneyCount;
                    usdCount += changeMoneyCount * exchangeRateEurToUsd;
                }

                else if (selectionUser == "4")
                {
                    Console.WriteLine("сколько меняем?");
                    changeMoneyCount = Convert.ToDouble(Console.ReadLine());
                    while (changeMoneyCount > eurCount || changeMoneyCount < 0)
                    {
                        Console.WriteLine("Не верная сумма. Еще раз.");
                        changeMoneyCount = Convert.ToDouble(Console.ReadLine());
                    }
                    eurCount -= changeMoneyCount;
                    rubCount += + changeMoneyCount * exchangeRateEurToRub;
                }

                else if (selectionUser == "5")
                {
                    Console.WriteLine("сколько меняем?");
                    changeMoneyCount = Convert.ToDouble(Console.ReadLine());
                    while (changeMoneyCount > rubCount || changeMoneyCount < 0)
                    {
                        Console.WriteLine("Не верная сумма. Еще раз.");
                        changeMoneyCount = Convert.ToDouble(Console.ReadLine());
                    }
                    rubCount -= changeMoneyCount;
                    usdCount += + changeMoneyCount * exchangeRateRubToUsd;
                }

                else if (selectionUser == "6")
                {
                    Console.WriteLine("сколько меняем?");
                    changeMoneyCount = Convert.ToDouble(Console.ReadLine());
                    while (changeMoneyCount > rubCount || changeMoneyCount < 0)
                    {
                        Console.WriteLine("Не верная сумма. Еще раз.");
                        changeMoneyCount = Convert.ToDouble(Console.ReadLine());
                    }
                    rubCount -= changeMoneyCount;
                    eurCount += + changeMoneyCount * exchangeRateRubToEur;
                }
            }
            Console.WriteLine("досвидания");
        }       
    }
}
