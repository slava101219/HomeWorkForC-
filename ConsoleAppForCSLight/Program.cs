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
            string[] fullNames = new string[0];
            string[] workPositionArray = new string[0];
            string choice;
            bool workApp = true;

            while (workApp)
            {
                ShowMenu();
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddDossier(ref fullNames,ref workPositionArray);
                        break;
                    case "2":
                        OutPutAllDossiers(fullNames, workPositionArray);
                        break;
                    case "3":
                        DeleteDossier(ref fullNames, ref workPositionArray);
                        break;
                    case "4":
                        SearchByLastName(fullNames, workPositionArray);
                        break;
                    case "5":
                        workApp = false;
                        break;
                    default:
                        Console.WriteLine("не верный ввод.");
                        break;
                }                  
            }
        }
        static void SearchByLastName(string[] arrayForSearch, string[] workPositionArray)
        {
            Console.WriteLine("введите фамилию.");
            string lastName = Console.ReadLine();
            for (int i = 0; i < arrayForSearch.Length - 1; i++)
            {
                if (lastName.ToLower() == arrayForSearch[i].ToLower())
                {
                    Console.WriteLine(arrayForSearch[i] + " " + workPositionArray[i]);
                }
            }
        }

        static void DeleteDossier(ref string[] fullNames, ref string[] workPositions)
        {
            Console.WriteLine("введите номер удаляемого досье.");
            int indexDelete = Convert.ToInt32(Console.ReadLine())-1;

            if (fullNames.Length == 0 || workPositions.Length == 0)
            {
                Console.WriteLine("удалять нечего.");
            }
            else if(fullNames.Length <= indexDelete || indexDelete < 0)
            {
                Console.WriteLine("неверный номер.");
            }
            else
            {
                fullNames = DeletePosition(fullNames, indexDelete);
                workPositions = DeletePosition(workPositions, indexDelete);
            } 
        }

        static string[] DeletePosition(string[] sourceArray, int indexDelete)
        {
            int counter = 0;
            string[] copyArray = new string[sourceArray.Length - 1];

            for (int i = 0; i < sourceArray.Length; i++)
            {
                if (i == indexDelete)
                {
                    continue;
                }
                copyArray[counter] = sourceArray[i];
                counter++;
            }
            return copyArray;
        }

        static void OutPutAllDossiers(string[] fullNames, string[] workPositions)
        {
            int i = 0;
            foreach (string name in fullNames)
            {
                Console.Write(++i + ") " + fullNames[i-1] + " - " + workPositions[i-1] + " ");
            }
            Console.WriteLine();
        }

        static void AddDossier(ref string[] fullNames, ref string[] workPositions)
        {
            Console.WriteLine("введите фамилию.");
            string fullName = Console.ReadLine();
            Console.WriteLine("введите должность.");
            string workPosition = Console.ReadLine();
            fullNames = AddToArray(fullNames, fullName);
            workPositions = AddToArray(workPositions, workPosition);
        }

        static string[] AddToArray(string[] sourceArray, string fullNames)
        {
            string[] increasedArray = new string[sourceArray.Length + 1];
            for (int i = 0; i < sourceArray.Length; i++)
            {
                increasedArray[i] = sourceArray[i];
            }
            increasedArray[increasedArray.Length - 1] = fullNames;
            return increasedArray;
        }

        static void ShowMenu()
        {
            Console.WriteLine("1) добавить досье " +
                "2) вывести все досье" +
                "3) удалить досье" +
                "4) поиск по фамилии" +
                "5) выход");
        }
    }
}
