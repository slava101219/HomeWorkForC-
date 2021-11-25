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
            double healthHero = 1000;
            double HealthBoss = 10000;
            double attackHero = 200;
            double attackBoss = 100;
            double defenceHero = 70;
            double defenceBoss = 140;
            double damageToHero = attackBoss / defenceHero * attackBoss;
            double damageForOneSkill; 
            double damageForTwoSkill;
            double currentDamage = 0;
            int cooldownForTwoSkill = 0;
            int cooldownForThreeSkill = 0;
            string selectSkill;
            Console.WriteLine("To battle!");

            while (HealthBoss > 0 && healthHero > 0)
            {
                Console.WriteLine("1 - обычный удар. без отката.");
                Console.WriteLine("2 - Укус вампира. игнорирует 20% защиты врага. 50% урона крадет в виде здоровья. откат 2 хода");
                Console.WriteLine("3 - прилив ярости. навсегда сокращает защиту врага на 5%. откат 4 хода.");
                selectSkill = Console.ReadLine();

                while (selectSkill != "1" && selectSkill != "2" && selectSkill != "3")
                {
                    Console.WriteLine("не выбран навык.");
                    selectSkill = Console.ReadLine();
                }

                while (selectSkill == "2" && cooldownForTwoSkill > 0 || selectSkill == "3" && cooldownForThreeSkill > 0)
                {
                    Console.WriteLine("не выбран навык.");
                    selectSkill = Console.ReadLine();
                }

                switch (selectSkill)
                {
                    case "1":
                        damageForOneSkill = attackHero / defenceBoss * attackHero;
                        HealthBoss -= damageForOneSkill;
                        currentDamage = damageForOneSkill;
                        break;
                    case "2":
                        damageForTwoSkill = attackHero / (defenceBoss * 0.8) * attackHero;
                        HealthBoss -= damageForTwoSkill;
                        currentDamage = damageForTwoSkill;
                        healthHero += damageForTwoSkill;
                        cooldownForTwoSkill = 3;
                        break;
                    case "3":
                        defenceBoss = defenceBoss * 0.95;
                        damageForOneSkill = attackHero / defenceBoss * attackHero;
                        HealthBoss -= damageForOneSkill;
                        currentDamage = damageForOneSkill;
                        cooldownForThreeSkill = 5;
                        break;
                }

                Console.WriteLine("Вы нанесли " + ((int)currentDamage) + " урона." + "у босса осталось " + ((int)HealthBoss) + " здоровья.");
                healthHero -= damageToHero;

                if (healthHero > 1000)
                {
                    healthHero = 1000;
                }
                Console.WriteLine("босс нанес вам " + ((int)damageToHero) + " урона. у вас осталось " + ((int)healthHero) + " здоровья.");

                if (cooldownForTwoSkill != 0)
                {
                    cooldownForTwoSkill--;
                }

                if (cooldownForThreeSkill != 0)
                {
                    cooldownForThreeSkill--;
                }

                if (HealthBoss <= 0)
                {
                    Console.WriteLine("You WIN!!!!!");
                }
                else if (healthHero <= 0)
                {
                    Console.WriteLine("You Lose:(");
                }
            }

        }
    }
}
