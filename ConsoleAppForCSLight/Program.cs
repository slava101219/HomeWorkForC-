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
            DatabasePatients databasePatients = new DatabasePatients();
            bool isWork = true;
            string choice;
            
            while(isWork == true)
            {
                Console.WriteLine("1) сортировка по возрасту. 2) по имени. 3) по болезни. 4) выход");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        databasePatients.SortedByAge();
                        break;
                    case "2":
                        databasePatients.SortedByName();
                        break;
                    case "3":
                        databasePatients.SortedByDisease();
                        break;
                    case "4":
                        isWork = false;
                        break;
                }
            }
        }
    }

    class Patient
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public Diseases Disease { get; private set; }

        public Patient(string name, int age, Diseases disease)
        {
            Name = name;
            Age = age;
            Disease = disease;
        }

        public override string ToString()
        {
            string patient = Name + " / " + Age + " лет. / " + Disease;
            return patient;
        }
    }

    enum Diseases
    {
        Отит,
        Диарея,
        Ковид,
        Травма,
        Простуда
    }

    class DatabasePatients
    {
        private List<Patient> _patients = new List<Patient>() {
        new Patient("Майкл", 10, Diseases.Диарея),
        new Patient("Байрам", 15, Diseases.Ковид),
        new Patient("Джек", 25, Diseases.Отит),
        new Patient("Усама", 8, Diseases.Простуда),
        new Patient("Пабло", 24, Diseases.Травма),
        new Patient("Джозеф", 51, Diseases.Диарея),
        new Patient("Роберт", 46, Diseases.Ковид),
        new Patient("Алексис", 18, Diseases.Отит),
        new Patient("Дима", 32, Diseases.Простуда),
        new Patient("Василий", 45, Diseases.Травма)};

    public void ShowAllPatients()
        {
            Console.Clear();
            Console.WriteLine("----------------------");

            foreach (Patient patient in _patients)
            {
                Console.WriteLine(patient.ToString());
            }

            Console.WriteLine("----------------------");
        }

        public void SortedByAge()
        {
            ShowAllPatients();
            Console.WriteLine("Сортируем по возрасту:");
            var sortedPatients = _patients.OrderBy(patient => patient.Age);

            foreach(Patient patient in sortedPatients)
            {
                Console.WriteLine(patient.ToString());
            }
        }

        public void SortedByName()
        {
            ShowAllPatients();
            Console.WriteLine("Сортируем по имени:");
            var sortedPatients = _patients.OrderBy(patient => patient.Name);

            foreach (Patient patient in sortedPatients)
            {
                Console.WriteLine(patient.ToString());
            }
        }

        public void SortedByDisease()
        {
            ShowAllPatients();
            Console.WriteLine("Введите название болезни..");

            string soughtForDisease = Console.ReadLine();
            Console.WriteLine("Сортируем по болезни:");
            var sortedPatients = _patients.Where(patient => patient.Disease.ToString().ToUpper() == soughtForDisease.ToUpper());

            foreach (Patient patient in sortedPatients)
            {
                Console.WriteLine(patient.ToString());
            }
        }
    }
}
