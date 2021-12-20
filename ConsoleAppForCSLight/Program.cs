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
            /*
             1) добавить досье

2) вывести все досье (в одну строку через “-” фио и должность)

3) удалить досье

4) выход
             */
            string choice = " ";
            Dictionary<int, string> dossiers = new Dictionary<int, string>();
            bool isWork = true;
            int numberDelete = 0;

            while(isWork)
            {
                Console.WriteLine("1)добавить досье 2) вывести все досье(в одну строку через “-” фио и должность) 3) удалить досье 4) выход");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("введите фио");
                        dossiers.Add(dossiers.Count + 1, Console.ReadLine());
                        break;
                    case "2":
                        for (int i = 0; i < dossiers.Count; i++)
                        {
                            Console.Write((i + 1) + " " + dossiers[i + 1] + "; ");
                        }
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

        static void DeleteFromDossiers (string choice, Dictionary<int, string> dossiers)
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
                    dossiers.Remove(numberDelete);
                }
            }
            else
            {
                Console.WriteLine("нужно ввести номер");
            }
        }
    }
}
