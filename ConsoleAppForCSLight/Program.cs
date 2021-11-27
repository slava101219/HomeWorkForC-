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
            int sum = 0;
            int mult = 1;
            Random rand = new Random();
            int[,] array = new int [ 5, 5 ];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = rand.Next(0, 10);

                    if (i == 1)
                    {
                        sum += array[i, j];
                    }
                    
                    if (j == 0)
                    {
                        mult *= array[i, j];
                    }
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine(sum + " | " + mult);

        }
    }
}
