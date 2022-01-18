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
        private IReadOnlyList<Product> _products = new List<Product> 
        {new Product("молоко", 1), new Product("сыр", 6), new Product("майонез", 4), new Product("сметана", 3), new Product("кефир", 2)};
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
                Thread.Sleep(100);
            }
        }
        public void AcceptCustomers()
        {
            foreach(Customer customer in _customers)
            {
                Console.WriteLine("у клиента " + customer.Money + " денег. вот что ему нужно.");                
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
        private Random _random = new Random();
        public int Money { get; private set; }

        public Customer()
        {
            int _minMoney = 10;
            int _maxMoney = 50;
            Money = _random.Next(_minMoney, _maxMoney);
        }

        public void AddProductsToBasket(IReadOnlyList<Product> productsShop)
        {
            int _minProductCount = 5;
            int _maxProductCount = 20;

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

            if (needMoney <= Money)
            {
                return true;
            }
            else
            {
                Console.WriteLine("мне нужно " + needMoney + ", а у меня только " + Money);
                return false;
            }
        }

        public void DeleteProduct()
        {
            
            while (!CheckMoneyEnough())
            {
                int indexDeleteProduct = _random.Next(1, _basketOfProduct.Count) - 1;
                Console.WriteLine("выложил " + _basketOfProduct[indexDeleteProduct].Name + " :(");
                _basketOfProduct.RemoveAt(indexDeleteProduct);
                
                Console.ReadKey();
            }
        }
    }

    class Product 
    {
        private static int _nextId = 0;
        public int IdProduct { get; private set; }
        public string Name { get; protected set; }
        public int price { get; protected set; }

        public Product(string name, int price)
        {
            IdProduct = _nextId++;
            Name = name;
            this.price = price;
        }
    }
}
