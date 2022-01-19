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
            War war = new War();
            war.Buttle(new Country("италия"), new Country("испания"));
        }
    }

    class War
    {
        static Random Random = new Random();
        public void Buttle(Country country1, Country country2)
        {
            Console.WriteLine("Битва между " + country1.Name + " и " + country2.Name + " начинается.");
            country1.ShowTroop();
            country2.ShowTroop();

            while(country1.CheckConsistTroop() == true && country2.CheckConsistTroop() == true)
            {
                country1.GetHit(country2.GetSoldier());
                if (country1.CheckConsistTroop() == true)
                {
                    country2.GetHit(country1.GetSoldier());
                }               
            }

            if (country1.CheckConsistTroop() == true)
            {
                Console.WriteLine("Победила " + country1.Name);
                country1.ShowTroop();
            }
            else
            {
                Console.WriteLine("Победила " + country2.Name);
                country2.ShowTroop();
            }
        }
    }

    class Country
    {
        static Random Random = new Random();
        private List<Soldier> _troop = new List<Soldier>();
        public string Name { get; private set; }

        public Country(string name)
        {
            int fullSoldierCount = 60;
            Name = name;

            for (int i = 0; i < fullSoldierCount; i++)
            {
                _troop.Add(new Soldier());
            }
        }

        public bool CheckConsistTroop()
        {
            if(_troop.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void GetHit(Soldier soldier)
        {
            int indexSoldier = Random.Next(1, _troop.Count) - 1;
            _troop[indexSoldier].TakeDamage(soldier.Attack);
            if (_troop[indexSoldier].Health < 0)
            {
                _troop.RemoveAt(indexSoldier);
                Console.WriteLine("погиб солдат страны " + Name);
            }
        }

        public Soldier GetSoldier()
        {
            return _troop[Random.Next(1, _troop.Count) - 1];
        }

        public void ShowTroop()
        {
            int i = 1;
            Console.WriteLine("Отряд " + Name);

            foreach(Soldier soldier in _troop)
            {               
                Console.WriteLine(i + ") " + soldier.ToString());
                i++;
            }
            Console.WriteLine("---------------------------");
            Console.ReadKey();
        }
    }

    class Soldier
    {
        static Random Random = new Random();
        public int Health { get; private set; }
        public int Attack { get; private set; }

        public Soldier()
        {
            int minHealth = 50;
            int maxHealth = 100;
            int minAttack = 10;
            int maxAttack = 20;
            Health = Random.Next(minHealth, maxHealth);
            Attack = Random.Next(minAttack, maxAttack);
        }

        public void TakeDamage(int attack)
        {
            Health -= attack;
        }

        public int MakeDamage()
        {
            return Attack;
        }

        public override string ToString()
        {
            return "| hp: " + Health + " attack: " + Attack + " |";
        }
    }
}
