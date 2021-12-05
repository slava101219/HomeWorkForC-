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
                choice = OutPutMenu();

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
                if (lastName.ToLower() == fullNameArray[iterator].ToLower())
                {
                    Console.WriteLine(fullNameArray[iterator] + " " + workPositionArray[iterator]);
                }
                iterator++;
            }
        }

        static void DeleteDossier(ref string[] fullNameArray, ref string[] workPositionArray)
        {
            Console.WriteLine("введите номер удаляемого досье.");
            int indexDelete = Convert.ToInt32(Console.ReadLine())-1;
            string[] copyArray = new string[0];
            string[] copyArray2 = new string[0];
            int counter = 0;

            if (fullNameArray.Length == 0 || workPositionArray.Length == 0)
            {
                Console.WriteLine("удалять нечего.");
                return;
            }
            else if (fullNameArray.Length <= indexDelete || indexDelete < 0)
            {
                Console.WriteLine("неверный номер.");
                DeleteDossier(ref fullNameArray, ref workPositionArray);
            }

            for (int i = 0; i < fullNameArray.Length; i++)
            {
                if (i == indexDelete)
                {
                    continue;
                }
                Array.Resize(ref copyArray, copyArray.Length + 1);
                copyArray[counter] = fullNameArray[i];
                counter++;
            }

            counter = 0;

            for (int i = 0; i < workPositionArray.Length; i++)
            {
                if (i == indexDelete)
                {
                    continue;
                }
                Array.Resize(ref copyArray2, copyArray2.Length + 1);
                copyArray2[counter] = workPositionArray[i];
                counter++;
            }

            fullNameArray = copyArray;
            workPositionArray = copyArray2;
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
            string fullName = Console.ReadLine();
            Console.WriteLine("введите должность.");
            string workPosition = Console.ReadLine();
            Array.Resize(ref fullNameArray, fullNameArray.Length + 1);
            fullNameArray[fullNameArray.Length - 1] = fullName;
            Array.Resize(ref workPositionArray, workPositionArray.Length + 1);
            workPositionArray[workPositionArray.Length - 1] = workPosition;
        }
        static string OutPutMenu()
        {
            Console.WriteLine("1) добавить досье " +
                "2) вывести все досье" +
                "3) удалить досье" +
                "4) поиск по фамилии" +
                "5) выход");
            string choice = Console.ReadLine();

            if (choice == "1" || choice == "2" || choice == "3" || choice == "4" || choice == "5")
            {
                return choice;
            }
            else
            {
                return OutPutMenu();
            }
        }
    }
}
