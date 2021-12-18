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
            numbers.Add(number);

            while (isWork)
            {
                result = Console.ReadLine();

                if (result == "sum")
                {
                    Console.WriteLine(SumNumbers(numbers));
                }
                else if (result == "exit")
                {
                    isWork = false;
                }
                else if (!int.TryParse(result, out number) && result != "exit" && result != "sum")
                {
                    Console.WriteLine("Введите целое число.");
                }
                else
                {
                    numbers.Add(int.Parse(result));
                }
            }           
        }

        static int SumNumbers (List<int> numbers)
        {
            int sum = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];
            }
            return sum;
        }
    }
}
