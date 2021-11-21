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
            string menu = "команды: getWidth - установить ширину консоли; setWidth - установить ширину кончоли; getHeight - установить высоту консоли; " +
                "getDateTime - вывести сегодняшнюю дату и время; getCountDaysToday - вывести количество дней с начала года;" +
                " exit - выйти из программы";
            Console.WriteLine(menu);
            comand = Console.ReadLine();
            while (comand != "exit")
            {
                Console.WriteLine(menu);
                comand = Console.ReadLine();

                switch (comand)
                {
                    case "getWidth":
                        valueForConsole = Console.WindowWidth;
                        Console.WriteLine(valueForConsole);
                        break;
                    case "setWidth":
                        Console.WriteLine("какое значение установить?");
                        valueForConsole = Convert.ToInt32(Console.ReadLine());
                        Console.WindowWidth = valueForConsole;
                        Console.WriteLine("изменено на : " + Console.WindowWidth);
                        break;
                    case "getHeight":
                        valueForConsole = Console.WindowHeight;
                        Console.WriteLine(valueForConsole);
                        break;
                    case "getDateTime":
                        Console.WriteLine(DateTime.Now);
                        break;
                    case "getCountDaysToday":
                        Console.WriteLine(DateTime.Today.DayOfYear);
                        break;
                    default:
                        Console.WriteLine("это не команда");
                        break;
                }

            }
            

        }       
    }
}
