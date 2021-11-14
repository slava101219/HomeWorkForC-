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
            int priceCrystal = 16;
            Console.WriteLine("Приветствую в нашем магазине. Хотите купить кристаллы? Отлично, сегодня всего по " + priceCrystal + 
                "! Сколько золота вы готовы потратить?");
            int myGold = Convert.ToInt32(Console.ReadLine());
            while (true)
            {

                if (myGold < priceCrystal)
                {
                    Console.WriteLine("Я не могу разбить кристалл( Нужно потратить немного больше.");
                    myGold = Convert.ToInt32(Console.ReadLine());
                }
                else break;
                }               
            int crystalsAvailableForPurchase = myGold / priceCrystal;
            Console.WriteLine("За свои " + myGold + " золота, вы можете купить " + crystalsAvailableForPurchase +
            " кристалла. Сколько же кристалов вам требуется?");
            int myCrystals = Convert.ToInt32(Console.ReadLine());
            while (true)
            {
                if (myCrystals > crystalsAvailableForPurchase)
                {
                    Console.WriteLine("Вам нехватит золота( купите чуть меньше.");
                    myCrystals = Convert.ToInt32(Console.ReadLine());
                }
                else break;
            }
            int finalGold = myGold - (priceCrystal * myCrystals);
            if (myCrystals == 0)
            {
                Console.WriteLine("Жаль. Теперь у вас " + myCrystals + " кристалов. У вас осталось " + finalGold + " золота.");
            }
            Console.WriteLine("Отлично! Теперь у вас " + myCrystals + " кристалов. У вас осталось " + finalGold + " золота.");
        }
        
    }
}
