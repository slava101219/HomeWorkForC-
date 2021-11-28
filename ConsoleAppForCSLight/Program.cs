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
            int multiplication = 1;
            Random random = new Random();
            int[,] array = new int [ 5, 5 ];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = random.Next(0, 10);
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }

            for (int i = 0; i < array.GetLength(0); i++)
            {
                sum += array[1, i];
                multiplication *= array[i, 0];
            }

            Console.WriteLine(sum + " | " + multiplication);

        }
    }
}
