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
            string[] letters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "j"};
            WriteArray(letters);
            ShuffleArray(ref letters);
            WriteArray(letters);
        }

        static void WriteArray (string[] array)
        {
            foreach (string s in array)
            {
                Console.Write(s + " ");
            }

            Console.WriteLine();
        }

        static void ShuffleArray(ref string[] letters)
        {
            Random random = new Random();

            for (int i = letters.Length - 1; i >= 0; i--)
            {
                int randomItem = random.Next(i);
                string shuffledElement = letters[randomItem];
                letters[randomItem] = letters[i];
                letters[i] = shuffledElement;
            }
        }
    }
}
