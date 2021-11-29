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
            int maxValue = 0;
            Random random = new Random();
            int[,] array = new int [ 10, 10 ];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = random.Next(0, 100);
                    Console.Write(array[i, j] + " ");

                    if (maxValue < array[i, j])
                    {
                        maxValue = array[i, j];
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine(maxValue);

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    
                    if (maxValue == array[i, j])
                    {
                        array[i, j] = 0;
                    }

                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }


        }
    }
}
