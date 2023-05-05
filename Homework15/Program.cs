using System.Linq;
using System;
using System.Security.Cryptography.X509Certificates;

namespace _13._04._2023
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Phone[] phones =
            {
                new Phone("Iphone", "Apple", 500, "06.05.2023"),
                new Phone("Meizu", "Meizu Company", 100, "05.05.2023"),
                new Phone("Samsung", "Android", 900, "04.05.2023")
            };


            var Count = phones.Count();
            Console.WriteLine("Count: " + Count);
            var PriceMore100 = phones.Where(x => x.Price > 100).Count();
            Console.WriteLine("\nPhones more then 100: " + PriceMore100);

            var From400To700Price = phones.Where(x => x.Price >= 400 && x.Price < 700).Count();
            Console.WriteLine("\nPhones between 400 and 700: " + From400To700Price);

            var CountPhone = phones.Where(x => x.Manufacturer == "Apple").Count();
            Console.WriteLine("\nNumber of phones by company");

            Console.WriteLine("Phones by Company: " + CountPhone);


            var MinPrice = phones.OrderBy(x => x.Price).Take(1);
            Console.WriteLine("\nLowest Price: ");

            foreach (var min in MinPrice)
                min.Output();


            var MaxPrice = phones.OrderBy(x => -x.Price).Take(1);
            Console.WriteLine("\nHighest price:");

            foreach (var max in MaxPrice)
                max.Output();


            var OldestPhone = phones.OrderBy(x => x.date).Take(1);
            Console.WriteLine("\nOldest:");

            foreach (var old in OldestPhone)
                old.Output();


            var NewPhone = phones.OrderByDescending(x => x.date).Take(1);
            Console.WriteLine("\nNewest:");

            foreach (var New in NewPhone)
                New.Output();


            double AverageAmount = phones.Sum(x => x.Price);
            Console.WriteLine("\nAverage amount: {0:f2}", (AverageAmount / Count));


            var _5min = phones.OrderBy(x => x.Price).Take(5);
            Console.WriteLine("\n5 phone at the lowest price: ");

            foreach (var min in _5min)
                min.Output();

            var _5max = phones.OrderBy(x => -x.Price).Take(5);
            Console.WriteLine("\nTop 5 Highest Price:");

            foreach (var max in _5max)
                max.Output();


            var Oldest_3 = phones.OrderBy(x => x.date).Take(3);
            Console.WriteLine("\nTop 3 Oldest Phones:");

            foreach (var old in Oldest_3)
                old.Output();


            var NewPhone_3 = phones.OrderByDescending(x => x.date).Take(3);
            Console.WriteLine("\nTop 3 Newest Phones:");

            foreach (var New in NewPhone_3)
                New.Output();



            var AllCompany = phones.GroupBy(x => x.Manufacturer).Select(x => new
            {
                Manufacturer = x.Key,
                Count = x.Count()
            }).OrderBy(x => x.Manufacturer);
            Console.WriteLine("\nStatistic By Manufacturer");

            foreach (var item in AllCompany)
                Console.WriteLine($"{item.Manufacturer}: {item.Count}");

            var AllModels = phones.GroupBy(x => x.Title).Select(x => new
            {
                Title = x.Key,
                Count = x.Count()
            }).OrderBy(x => x.Title);
            Console.WriteLine("\nStatistic By Model");

            foreach (var item in AllModels)
                Console.WriteLine($"{item.Title}: {item.Count}");

            var Dates = phones.GroupBy(x => x.date.Year).Select(x => new
            {
                Year = x.Key,
                Count = x.Count()
            }).OrderBy(x => x.Year);
            Console.WriteLine("\nStatistic By Year");

            foreach (var item in Dates)
                Console.WriteLine($"{item.Year}: {item.Count}");
        }

        class Phone
        {
            public string Title { get; set; }
            public string Manufacturer { get; set; }
            public double Price { get; set; }
            public DateTime date { get; set; }
            public Phone(string title, string manufacturer, double price, string date)
            {
                Title = title;
                Manufacturer = manufacturer;
                Price = price;
                this.date = DateTime.Parse(date);
            }

            public void Output()
            {
                Console.WriteLine("\nTitle: " + Title);
                Console.WriteLine("Manufacturer " + Manufacturer);
                Console.WriteLine("Price: " + Price);
                Console.WriteLine("Date: " + date.ToShortDateString());
            }
        }
    }
}