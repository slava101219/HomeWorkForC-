using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppForCSLight
{
    class Program
    {
        static Player player = new Player(1000);
        static Saller saller = new Saller();

        static void Main(string[] args)
        {
            bool isWork = true;
            string choice;
            

            while (isWork)
            {
                Console.WriteLine(player.Money + " руб.");
                Console.WriteLine("1 - показать сумку. 2 - купить товар. 3 - показать ассортимент. 4 - выход.");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        player.ShowBag();
                        break;
                    case "2":
                        ShowAssortment();
                        Buy(Console.ReadLine());
                        break;
                    case "3":
                        saller.ShowWarehouse();
                        break;
                    case "4":
                        isWork = false;
                        break;
                    default:
                        Console.WriteLine("ошибка ввода");
                        break;
                }
            }
        }

        static void Buy(string choice)
        {
            int amount;
            switch (choice)
            {
                case "1":
                    amount = GetInputAmountProduct();
                    if (player.CheckEnoughMoney(amount, 0) && CheckProductExistence(amount, 0))
                    {
                        saller.SalleProduct(amount, 0);
                        player.BuyProduct(amount, 0);
                    }                   
                    break;
                case "2":
                    amount = GetInputAmountProduct();
                    if (player.CheckEnoughMoney(amount, 1) && CheckProductExistence(amount, 1))
                    {                      
                        saller.SalleProduct(amount, 1);
                        player.BuyProduct(amount, 1);
                    }                  
                    break;
                case "3":
                    amount = GetInputAmountProduct();
                    if (player.CheckEnoughMoney(amount, 2) && CheckProductExistence(amount, 2))
                    {
                        saller.SalleProduct(amount, 2);
                        player.BuyProduct(amount, 2);
                    }                    
                    break;
                case "4":
                    amount = GetInputAmountProduct();
                    if (player.CheckEnoughMoney(amount, 3) && CheckProductExistence(amount, 3))
                    {
                        saller.SalleProduct(amount, 3);
                        player.BuyProduct(amount, 3);
                    }                   
                    break;
                default:
                    Console.WriteLine("ошибка ввода.");
                    break;
            }
        }

        static int GetInputAmountProduct()
        {
            Console.WriteLine("Введи количество товара.");

            if (int.TryParse(Console.ReadLine(), out int result))
            {
                return result;
            }
            else
            {
                return -1;
            }
        }

        static bool CheckProductExistence(int amount, int choice)
        {
            if (amount > 0 && amount < saller.GetAmountProduct(choice))
            {
                return true;
            }
            else
            {
                Console.WriteLine("ошибка ввода");
                return false;
            }
        }

        static void ShowAssortment()
        {
            List<Product> products = new List<Product>(player.GetBag().Keys);
            Console.Write("выбери товар:");
            for (int i = 0; i < products.Count; i++)
            {
                Console.Write((i + 1) + ") " + products[i].Description + ". ");
            }
        }
    }

    class Player : IAddable
    {
        private Dictionary<Product, int> _bag = new Dictionary<Product, int>
        {
            { new Product("молоко", 4), 0 },
            { new Product("хлеб", 3), 0 },
            { new Product("рыба", 14), 0 },
            { new Product("икра", 46), 0 }
        };
        public int Money { get; private set; }

        public Player(int money)
        {
            Money = money;
        }

        public Dictionary<Product, int> GetBag()
        {
            return _bag;
        }

        public void ShowBag()
        {
            foreach(KeyValuePair<Product, int> keyValue in _bag)
            {
                Console.WriteLine(keyValue.Key.ToString() + " - " + keyValue.Value + " шт.");
            }
        }

        public void BuyProduct(int amount, int index)
        {
            List<Product> products = new List<Product>(_bag.Keys);
            _bag[products[index]] += amount;
            Money -= products[index].Price * amount;
        }

        public bool CheckEnoughMoney(int amount, int index)
        {
            List<Product> products = new List<Product>(_bag.Keys);
            if (Money >= products[index].Price * amount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddProduct(string description, int price, int amount)
        {
            _bag.Add(new Product(description, price), amount);
        }
    }

    class Saller : IAddable
    {
        private Dictionary<Product, int> _warehouse = new Dictionary<Product, int>
        {
            { new Product("молоко", 4), 100 },
            { new Product("хлеб", 3), 100 },
            { new Product("рыба", 14), 50 },
            { new Product("икра", 46), 20 }
        };
            
        public void ShowWarehouse()
        {
            foreach (KeyValuePair<Product, int> keyValue in _warehouse)
            {
                Console.WriteLine(keyValue.Key.ToString() + " - " + keyValue.Value + " шт.");
            }
        }

        public void SalleProduct(int amount, int index)
        {
            List<Product> products = new List<Product>(_warehouse.Keys);
            _warehouse[products[index]] -= amount;
        }

        public int GetAmountProduct(int choice)
        {
            List<Product> products = new List<Product>(_warehouse.Keys);
            _warehouse.TryGetValue(products[choice], out int amount);
            return amount;
        }

        public void AddProduct(string description, int price, int amount)
        {
            _warehouse.Add(new Product(description, price), amount);
        }
    }

    class Product
    {
        public string Description { get; private set; }
        public int Price { get; private set; }

        public Product(string description, int price)
        {
            Description = description;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Description}: цена - {Price} р.";
        }
    }

    interface IAddable
    {
        void AddProduct(string description, int price, int amount);
    }
}
