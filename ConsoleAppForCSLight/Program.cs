using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppForCSLight
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();
            bool isWork = true;
            string choice;

            while (isWork)
            {
                ShowMenu();
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        controller.Fight(controller.ChoiceFighter(), controller.ChoiceFighter());
                        break;
                    case "2":
                        isWork = false;
                        break;
                    default:
                        Console.WriteLine("ошибка ввода");
                        break;
                }
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("1) сражение. 2) выход");
        }
    }

    class Controller
    {
        public void Fight(Fighter fighter1, Fighter fighter2)
        {
            while(fighter1.Health > 0 && fighter2.Health > 0)
            {
                fighter1.ReceiveDamage(fighter2.GiveDamage());

                if (fighter1.Health > 0)
                {
                    fighter2.ReceiveDamage(fighter1.GiveDamage());
                }
            }

            if(fighter1.Health <= 0)
            {
                Console.WriteLine("победил игрок 2 : " + fighter2.Name);
            }
            else
            {
                Console.WriteLine("победил игрок 1 : " + fighter1.Name);
            }
            
        }

        public Fighter ChoiceFighter()
        {
            Console.WriteLine("выбери бойца.");
            Console.WriteLine("1) маг. 2) рыцарь. 3) ассасин. 4) зверь. 5) призрак.");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    return new Wizard();
                case "2":
                    return new Knight();
                case "3":
                    return new Assasin();
                case "4":
                    return new Beast();
                case "5":
                    return new Ghost();
                default:
                    return ChoiceFighter();
            }
        }
    }

    class Fighter 
    {
        public int Health { get; protected set; }
        protected int Attack;
        protected int Defense;
        public string Name { get; protected set; }

        protected Random random = new Random();

        public Fighter(int health, int attack, int defense, string name)
        {
            Health = health;
            Attack = attack;
            Defense = defense;
            Name = name;
        }

        public virtual int GiveDamage()
        {
            return Attack;
        }

        public virtual void ReceiveDamage(int damage)
        {
        }
    }

    class Wizard : Fighter
    {
        public Wizard() : base(500, 100, 35, "маг")
        {
        }

        public override int GiveDamage()
        {
            Console.WriteLine("маг бъет.");
            return Attack;
        }

        public override void ReceiveDamage(int damage)
        {
            if(random.Next(0,2) == 0)
            {
                Console.WriteLine("маг блокирует урон.");
            }
            else
            {
                double lossHealth = (double)damage / (double)Defense * (double)damage;
                Health -= (int)lossHealth;
                Console.WriteLine("маг получил " + (int)lossHealth + "урона. Осталось " + Health + " здоровья");
            }
        }
    }

    class Knight : Fighter
    {
        private int coeffDefence = 2;
        public Knight() : base(1000, 50, 70, "рыцарь")
        {
        }

        public override int GiveDamage()
        {
            Console.WriteLine("рыцарь бъет.");
            return Attack;
        }

        public override void ReceiveDamage(int damage)
        {
            if (random.Next(0, 2) == 0)
            {

                double lossHealth = (double)damage / (double)Defense * (double)damage/(double)coeffDefence;
                Health -= (int)lossHealth;
                Console.WriteLine("рыцарь блокировал часть урона. рыцарь получил " + (int)lossHealth + "урона. Осталось " + Health + " здоровья");
            }
            else
            {
                double lossHealth = (double)damage / (double)Defense * (double)damage;
                Health -= (int)lossHealth;
                Console.WriteLine("рыцарь получил " + (int)lossHealth + "урона. Осталось " + Health + " здоровья");
            }
        }
    }

    class Assasin : Fighter
    {
        private int corffAttack = 2;
        public Assasin() : base(650, 80, 40, "убийца")
        {
        }

        public override int GiveDamage()
        {
            if(random.Next(0,2) == 0)
            {
                Console.Write("Убийца бъет в спину.");
                return Attack * corffAttack;
            }
            else
            {
                Console.WriteLine("убийца бъет.");
                return Attack;
            }           
        }

        public override void ReceiveDamage(int damage)
        {
            if (random.Next(0, 4) > 2)
            {
                Console.WriteLine("убийца увернулся.");
            }
            else
            {
                double lossHealth = (double)damage / (double)Defense * (double)damage;
                Health -= (int)lossHealth;
                Console.WriteLine("убийца получил " + (int)lossHealth + "урона. Осталось " + Health + " здоровья");
            }
        }
    }

    class Beast : Fighter
    {
        private int coeffAttack = 3;

        public Beast() : base(1200, 35, 30, "зверь")
        {
        }

        public override int GiveDamage()
        {
            Console.WriteLine("зверь бъет.");
            return Attack * coeffAttack;
        }

        public override void ReceiveDamage(int damage)
        {
            double lossHealth = (double)damage / (double)Defense * (double)damage;
            Health -= (int)lossHealth;
            Console.WriteLine("зверь получил " + (int)lossHealth + "урона. Осталось " + Health + " здоровья");
        }
    }

    class Ghost : Fighter
    {
        public Ghost() : base(400, 140, 10, "призрак")
        {
        }

        public override int GiveDamage()
        {
            Console.WriteLine("призрак бъет.");
            return Attack;
        }

        public override void ReceiveDamage(int damage)
        {
            if (random.Next(0, 4) > 0)
            {
                Console.WriteLine("призрак увернулся.");
            }
            else
            {
                double lossHealth = (double)damage / (double)Defense * (double)damage;
                Health -= (int)lossHealth;
                Console.WriteLine("призрак получил " + (int)lossHealth + "урона. Осталось " + Health + " здоровья");
            }
        }
    }
}
