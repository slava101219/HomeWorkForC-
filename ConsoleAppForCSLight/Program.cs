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
            string searchWord;

            Dictionary<string, string> interpretationDictionary = new Dictionary<string, string>();
            interpretationDictionary.Add("1", "цифра");
            interpretationDictionary.Add("2", "цифра");
            interpretationDictionary.Add("3", "цифра");
            interpretationDictionary.Add("4", "цифра");
            Console.WriteLine("ввести искомое слово.");
            searchWord = Console.ReadLine();

            if(interpretationDictionary.ContainsKey(searchWord))
            {
                Console.WriteLine(interpretationDictionary[searchWord]);
            }
            else
            {
                Console.WriteLine("такого слова нет.");
            }
        }
    }
}
