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
            List<int> numbers = new List<int>();
            bool isWork = true;
            string result = "";
            int number = 0;
            int sum = 0;
            numbers.Add(number);

            while (isWork)
            {
                result = Console.ReadLine();
                if (result == "sum")
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        sum += numbers[i];
                    }
                    Console.WriteLine(sum);
                    sum = 0;
                }

                if (result == "exit")
                {
                    isWork = false;
                }

                if (!int.TryParse(result, out number) && result != "exit" && result != "sum")
                {
                    Console.WriteLine("Введите целое число.");
                }
                
                if (int.TryParse(result, out number))
                {
                    number = int.Parse(result);
                    numbers.Add(number);
                }
            }           
        }
    }
}
