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
            int valueForConsole;
            string comand;
            string menu = "команды: getWidth - установить ширину консоли; getHeight - установить высоту консоли; " +
                "getDateTime - вывести сегодняшнюю дату и время; getCountDaysToday - вывести количество дней с начала года;" +
                " exit - выйти из программы";
            Console.WriteLine(menu);
            comand = Console.ReadLine();
            while (comand != "exit")
            {

                switch (comand)
                {
                    case "getWidth":
                        valueForConsole = Console.WindowWidth;
                        Console.WriteLine(valueForConsole);
                        Console.WriteLine(menu);
                        comand = Console.ReadLine();
                        break;
                    case "getHeight":
                        valueForConsole = Console.WindowHeight;
                        Console.WriteLine(valueForConsole);
                        Console.WriteLine(menu);
                        comand = Console.ReadLine();
                        break;
                    case "getDateTime":
                        Console.WriteLine(DateTime.Now);
                        Console.WriteLine(menu);
                        comand = Console.ReadLine();
                        break;
                    case "getCountDaysToday":
                        Console.WriteLine(DateTime.Today.DayOfYear);
                        Console.WriteLine(menu);
                        comand = Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("это не команда");
                        comand = Console.ReadLine();
                        break;
                }

            }
            

        }       
    }
}
