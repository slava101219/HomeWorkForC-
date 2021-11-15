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
            string nameUser;
            string ageUser;
            string userWork;
            Console.WriteLine("как вас зовут?");
            nameUser = Console.ReadLine();
            Console.WriteLine("сколько вам лет?");
            ageUser = Console.ReadLine();
            Console.WriteLine("гле вы работаете?");
            userWork = Console.ReadLine();
            Console.WriteLine("вас зовут " + nameUser + ". Вам " + ageUser + ". Вы работаете " + userWork + ".");
        }
        
    }
}
