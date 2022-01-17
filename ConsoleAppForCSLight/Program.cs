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
            Shop shop = new Shop();
            shop.CreateCustomers();
            shop.AcceptCustomers();
        }
    }

    class Shop
    {
        private List<Product> _products = new List<Product> {new Milk(), new Curd(), new Mayonnaise(), new SourCream(), new Kefir()};
        private Queue<Customer> _customers = new Queue<Customer>();
        private int _maxCustomerCount = 10;
        private Random _random = new Random();

        public void CreateCustomers()
        {
            int customerCount = _random.Next(0, _maxCustomerCount);
            Console.WriteLine("кажется мы забыли повесить ценники.. хорошо клиентов сегодня будет не много," + "всего то " + customerCount +
                ", веть никто из них не знает, хватит ли у него денег.");

            for (int i = 0; i < customerCount; i++)
            {
                _customers.Enqueue(new Customer());
            }
        }
        public void AcceptCustomers()
        {
            foreach(Customer customer in _customers)
            {
                Console.WriteLine("у клиента " + customer.Momey + " денег. вот что ему нужно.");                
                customer.AddProductsToBasket(_products);
                customer.ShowBasket();
                customer.DeleteProduct();
                Console.WriteLine("наконец то у него хватило денег! вот что он купил.");
                customer.ShowBasket();
            }
            Console.WriteLine("все на сегодня!");
        }
    }
    class Customer
    {
        private List<Product> _basketOfProduct = new List<Product>();
        private int _minMoney = 10;
        private int _maxMoney = 50;
        private int _minProductCount = 5;
        private int _maxProductCount = 20;
        private Random _random = new Random();
        public int Momey { get; private set; }

        public Customer()
        {
            Momey = _random.Next(_minMoney, _maxMoney);
        }

        public void AddProductsToBasket(List<Product> productsShop)
        {
            for (int _productCount = _random.Next(_minProductCount, _maxProductCount); _productCount > 0; _productCount--)
            {
                _basketOfProduct.Add(productsShop[_random.Next(0, productsShop.Count - 1)]);
            }
        }

        public void ShowBasket()
        {
            Console.WriteLine("------------------------------");
            foreach(Product product in _basketOfProduct)
            {
                Console.WriteLine(product.Name);
            }
            Console.WriteLine("------------------------------");
        }

        public bool CheckMoneyEnough()
        {
            int needMoney = 0;

            foreach (Product product in _basketOfProduct)
            {
                needMoney += product.price;
            }

            if (needMoney <= Momey)
            {
                return true;
            }
            else
            {
                Console.WriteLine("мне нужно " + needMoney + ", а у меня только " + Momey);
                return false;
            }
        }

        public void DeleteProduct()
        {
            int indexDeleteProduct = _random.Next(1, _basketOfProduct.Count) - 1;
            while (!CheckMoneyEnough())
            {
                Console.WriteLine(indexDeleteProduct);
                Console.WriteLine("выложил " + _basketOfProduct[indexDeleteProduct].Name + " :( это ");
                _basketOfProduct.RemoveAt(indexDeleteProduct);
                
                Console.ReadKey();
            }
        }
    }

    class Product 
    {
        public string Name { get; protected set; }
        public int price { get; protected set; }

        public Product(string name, int price)
        {
            Name = name;
            this.price = price;
        }
    }

    class Milk : Product
    {
        public Milk() : base ("молоко", 1)
        {
        }
    }

    class Curd : Product
    {
        public Curd() : base("творог", 4)
        {
        }
    }
    class Mayonnaise : Product
    {
        public Mayonnaise() : base("майонез", 6)
        {
        }
    }

    class SourCream : Product
    {
        public SourCream() : base("сметана", 5)
        {
        }
    }

    class Kefir : Product
    {
        public Kefir() : base("кефир", 2)
        {
        }
    }
}
