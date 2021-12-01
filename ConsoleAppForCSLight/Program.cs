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
            int[] array = new int [0];
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
                else if (choiceUser == "sum")
                {
                    sumNumbers = 0;
                    for (int i = 0; i<=array.Length-1; i++)
                    {
                        sumNumbers += array[i];
                    }
                    Console.WriteLine(sumNumbers);
                }
                else
                {
                    number = Int32.Parse(choiceUser);
                    int[] array2 = new int[array.Length + 1];
                    array2[array2.Length - 1] = number;
                    for (int i = 0; i < array.Length; i++)
                    {
                        array2[i] = array[i];
                    }
                    
                }
                Console.WriteLine("--------------------");
                foreach (int e in array)
                {
                    Console.WriteLine(e + " ");
                }
                Console.WriteLine("--------------------");
                Console.WriteLine("--------------------");
                foreach (int e in array)
                {
                    Console.WriteLine(e + " ");
                }
                Console.WriteLine("--------------------");
            }
        }
    }
}
