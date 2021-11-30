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
            int[] array = new int [1];
            bool isWork = true;
            int number;
            int sumNumbers = 0;
            string choiceUser;
            while (isWork)
            {
                Console.WriteLine("exit; sum; number.");
                choiceUser = Console.ReadLine();

                if (choiceUser == "exit")
                {
                    isWork = false;
                    Console.WriteLine("bye!");
                }

                if (choiceUser == "sum")
                {
                    sumNumbers = 0;
                    for (int i = 0; i<=array.Length-1; i++)
                    {
                        sumNumbers += array[i];
                    }
                    Console.WriteLine(sumNumbers);
                    foreach (int num in array)
                    {
                        Console.Write(num + " ");
                    }
                }
                else
                {
                    number = Int32.Parse(choiceUser);
                    int[] array2 = new int[] { number };
                    array = array.Concat(array2).ToArray();
                    array[array.Length-1] = number;
                }
            }
        }
    }
}
