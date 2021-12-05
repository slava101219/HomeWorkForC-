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
            string[] fullNameArray = new string[0];
            string[] workPositionArray = new string[0];
            string choice;
            bool workApp = true;

            while (workApp)
            {
                choice = ShowMenu();

                switch (choice)
                {
                    case "1":
                        AddDossier(ref fullNameArray,ref workPositionArray);
                        break;
                    case "2":
                        OutPutAllDossiers(fullNameArray, workPositionArray);
                        break;
                    case "3":
                        DeleteDossier(ref fullNameArray, ref workPositionArray);
                        break;
                    case "4":
                        SearchByLastName(fullNameArray, workPositionArray);
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
        static void SearchByLastName(string[] fullNameArray, string[] workPositionArray)
        {
            int iterator = 0;
            string lastName;
            Console.WriteLine("введите фамилию.");
            lastName = Console.ReadLine();
            foreach (string name in fullNameArray)
            {
                if (lastName.ToLower() == name.ToLower())
                {
                    Console.WriteLine(name + " " + workPositionArray[iterator]);
                }
                iterator++;
            }
        }

        static void DeleteDossier(ref string[] fullNameArray, ref string[] workPositionArray)
        {
            Console.WriteLine("введите номер удаляемого досье.");
            int indexDelete = Convert.ToInt32(Console.ReadLine())-1;

            if (fullNameArray.Length == 0 || workPositionArray.Length == 0)
            {
                Console.WriteLine("удалять нечего.");
            }
            else if(fullNameArray.Length <= indexDelete || indexDelete < 0)
            {
                Console.WriteLine("неверный номер.");
            }

            fullNameArray = CopyArray(fullNameArray, indexDelete);
            workPositionArray = CopyArray(workPositionArray, indexDelete);
        }

        static string[] CopyArray(string[] sourceArray, int indexDelete)
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

        static void OutPutAllDossiers(string[] fullNameArray, string[] workPositionArray)
        {
            int i = 0;
            foreach (string name in fullNameArray)
            {
                Console.Write(++i + ") " + fullNameArray[i-1] + " - " + workPositionArray[i-1] + " ");
            }
            Console.WriteLine();
        }

        static void AddDossier(ref string[] fullNameArray, ref string[] workPositionArray)
        {
            Console.WriteLine("введите фамилию.");
            string fullNames = Console.ReadLine();
            Console.WriteLine("введите должность.");
            string workPositions = Console.ReadLine();
            fullNameArray = AddToArray(fullNameArray, fullNames);
            workPositionArray = AddToArray(workPositionArray, workPositions);
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

        static string ShowMenu()
        {
            Console.WriteLine("1) добавить досье " +
                "2) вывести все досье" +
                "3) удалить досье" +
                "4) поиск по фамилии" +
                "5) выход");
            string choice = Console.ReadLine();
            return choice;
        }
    }
}
