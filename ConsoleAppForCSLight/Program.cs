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
            int finalGold;
            int myGold;
            int crystalsAvailableForPurchase;
            int myCrystals;
            int priceCrystal = 16;
            Console.WriteLine("Приветствую в нашем магазине. Хотите купить кристаллы? Отлично, сегодня всего по " + priceCrystal + 
                "! Сколько золота вы готовы потратить?");
            myGold = Convert.ToInt32(Console.ReadLine());              
            crystalsAvailableForPurchase = myGold / priceCrystal;
            Console.WriteLine("За свои " + myGold + " золота, вы можете купить " + crystalsAvailableForPurchase +
            " кристалла. Сколько же кристалов вам требуется?");
            myCrystals = Convert.ToInt32(Console.ReadLine());
            finalGold = myGold - (priceCrystal * myCrystals);
            Console.WriteLine("Отлично! Теперь у вас " + myCrystals + " кристалов. У вас осталось " + finalGold + " золота.");
        }
        
    }
}
