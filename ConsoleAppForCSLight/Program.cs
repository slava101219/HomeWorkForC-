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
            List<string> positionsHeld = new List<string>();
            bool isWork = true;
            
            while(isWork)
            {              
                Console.WriteLine("1)добавить досье 2) вывести все досье 3) удалить досье 4) выход");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddNewDossier(dossiers, positionsHeld);
                        break;
                    case "2":
                        ShowAllDossiers(dossiers, positionsHeld);
                        break;
                    case "3":
                        DeleteFromDossiers(Console.ReadLine(), dossiers, positionsHeld);
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

        static void DeleteFromDossiers (string choice, List<string> dossiers, List<string> positionsHeld)
        {
            int numberDelete;
            Console.WriteLine("введите номер удаляемого досье");

            if (int.TryParse(choice, out numberDelete))
            {
                if (numberDelete > dossiers.Count || numberDelete < 1)
                {
                    Console.WriteLine("такого досье нет.");
                }
                else
                {
                    dossiers.RemoveAt(numberDelete - 1);
                    positionsHeld.RemoveAt(numberDelete - 1);
                }
            }
            else
            {
                Console.WriteLine("нужно ввести номер");
            }
        }

        static void AddNewDossier(List<string> dossiers, List<string> positionsHeld)
        {
            Console.WriteLine("введите фио");
            dossiers.Add(Console.ReadLine());
            Console.WriteLine("введите должность");
            positionsHeld.Add(Console.ReadLine());
        }

        static void ShowAllDossiers (List<string> dossiers, List<string> positionsHeld)
        {
            for (int i = 0; i < dossiers.Count; i++)
            {
                Console.Write((i + 1) + " " + dossiers[i] + " - " + positionsHeld[i] + "; ");
            }
            Console.WriteLine();
        }
    }
}
