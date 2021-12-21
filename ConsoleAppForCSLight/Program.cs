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
            string choice;
            List<string> dossiers = new List<string>();
            bool isWork = true;
            

            while(isWork)
            {
                int iterator = 1;
                Console.WriteLine("1)добавить досье 2) вывести все досье 3) удалить досье 4) выход");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("введите фио");
                        dossiers.Add(Console.ReadLine());
                        break;
                    case "2":
                        foreach (string s in dossiers)
                        {
                            Console.Write((iterator) + " " + s + "; ");
                            iterator++;
                        }
                        Console.WriteLine();
                        break;
                    case "3":
                        Console.WriteLine("введите номер удаляемого досье");
                        DeleteFromDossiers(Console.ReadLine(), dossiers);
                        break;
                    case "4":
                        isWork = false;
                        break;
                    default:
                        Console.WriteLine("неверный ввод");
                        break;
                }
                
            }
        }

        static void DeleteFromDossiers (string choice, List<string> dossiers)
        {
            int numberDelete = 0;

            if (int.TryParse(choice, out numberDelete))
            {
                if (numberDelete > dossiers.Count || numberDelete < 1)
                {
                    Console.WriteLine("такого досье нет.");
                }
                else
                {
                    dossiers.RemoveAt(numberDelete - 1);
                }
            }
            else
            {
                Console.WriteLine("нужно ввести номер");
            }
        }
    }
}
