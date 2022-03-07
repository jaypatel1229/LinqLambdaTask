using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqLambdaTask
{
    public class Program
    {
        static void Main(string[] args)
        {
            //List<Cities> cities = new List<Cities>
            //{
            //   new Cities{Id = 1,Name = "Mumbai" },
            //   new Cities{Id = 2,Name = "Delhi" },
            //   new Cities{Id = 3,Name = "Ahemdabad" },
            //   new Cities{Id = 4,Name = "Surat" },
            //   new Cities{Id = 5,Name = "Valsad" },
            //   new Cities{Id = 6,Name = "Varanasi" },
            //   new Cities{Id = 7,Name = "Chennai" },
            //   new Cities{Id = 8,Name = "Bhopal" },
            //   new Cities{Id = 9,Name = "Darjeeling" }


            //};

            //Link method
            //Console.WriteLine("1");
            //var ordercityLinkDes = (from Cities in cities orderby Cities.Name descending select Cities).ToList();
            //dispCity(ordercityLinkDes);


            //Console.WriteLine("2");
            //var ordercityLinkAsc = (from Cities in cities orderby Cities.Name descending select Cities).ToList();
            //dispCity(ordercityLinkAsc);

            //var CoutnCity = (from  Cities in cities orderby Cities.Name descending select Cities).ToList();
            //dispCity(CoutnCity);



            // Lambda method
            //Console.WriteLine("3");
            //var ordercityLambda = cities.OrderByDescending(Cities => Cities.Name).ToList();
            //dispCity(ordercityLambda);


            //dispCity(cities);


            List<string> cities = new List<string>
            {
                "Mumbai",
                "Delhi",
                "Ahemdabad",
                "Surat",
                "Valsad",
                "Varanasi",
                "Chennai",
                "Bhopal",
                "Darjeeling"
            };

            // 1: Descending Order City using Linq
            Console.WriteLine("1: Descending Order City using Linq");
            var descendingCity = (from City in cities orderby City descending select City).ToList();
            displayCity(descendingCity);

            // 2: Ascending Order City using Linq
            Console.WriteLine("2: Ascending Order City using Linq");
            var ascendingCity = (from City in cities orderby City ascending select City).Reverse().ToList();
            displayCity(ascendingCity);

            // 3: Display Descending Order By Its length
            Console.WriteLine("3: Display Descending Order By Its length");
            var DescendingCityByLength = (from City in cities
                                          orderby City.Length descending
                                          select City).ToList();

            var citiesDescendingLenghtLambda = cities.OrderByDescending(city => city.Length).ToList();
            displayCity(citiesDescendingLenghtLambda);


            //  4: Display Ascending Order By Its length
            Console.WriteLine("4: Display Ascending Order By Its length");
            var ascendingCityByLength = (from City in cities
                                         orderby City.Length ascending
                                         select City).ToList();

            var citiesAscendingLengthLambda = cities.OrderBy(city => city.Length).ToList();
            displayCity(citiesAscendingLengthLambda);

            // 5: Get cities names starts with V and D letter.
            Console.WriteLine("5: Get cities names starts with V and D letter.");
            var startCityVandD = (from City in cities
                                  where City.StartsWith("V") || City.StartsWith("D")
                                  select City);
            var CityStartwithVandD = cities.Where(City => City.StartsWith("V") || City.StartsWith("D")).ToList();
            displayCity(CityStartwithVandD);

            // 6:Get count of city names starts with A letter.
            Console.WriteLine("6:Get count of city names starts with A letter.");
            var CountCityStartWithA = (from City in cities
                                       where City.StartsWith("A")
                                       select City).Count();
            Console.WriteLine("City Start With A : " + CountCityStartWithA);
            Console.ReadKey();

            // 7:Group ordered city names by its first letter
            Console.WriteLine("7:Group ordered city names by its first letter");

            var GruopOrderCityStartWithFirstLater = from City in cities  group City by City[0] into cityGroup
                                                    orderby cityGroup.Key
                                                    select cityGroup;

            var citiesOrderedFirstLetterLambda = cities.GroupBy(city => city[0]).OrderBy(city => city.Key);

            foreach (var cityGroup in citiesOrderedFirstLetterLambda)
            {
                Console.WriteLine(cityGroup.Key);

                foreach (var city in cityGroup)
                {

                    Console.WriteLine(city);
                }

            }
            Console.ReadKey();


            List<Fruit> fruits = new List<Fruit>
            {
                new Fruit{Id ="f1",Name="Apple",Color = Color.Red,Price=23.0},
                new Fruit{Id ="f2",Name="Banana",Color = Color.Yellow,Price=10.0},
                new Fruit{Id ="f3",Name="Pineapple",Color = Color.Yellow,Price=55.0},
                new Fruit{Id ="f4",Name="Cherry",Color = Color.Red,Price=40.0},
                new Fruit{Id ="f5",Name="Watermelon",Color = Color.Green,Price=28.0},
                new Fruit{Id ="f6",Name="Strawberry",Color = Color.Red,Price=30.0}

            };


            // 1:Get ordered fruits in descending order.
            Console.WriteLine("1:Get ordered fruits in descending order.");
            var descendingFruit = (from Fruit in fruits orderby Fruit.Name descending select Fruit).ToList();
            displayfruit(descendingFruit);

            // 2:Get ordered fruits in ascending order.
            Console.WriteLine("2:Get ordered fruits in ascending order.");
            var ascendingFruit = (from Fruit in fruits orderby Fruit.Name ascending select Fruit).ToList();
            displayfruit(ascendingFruit);

            // 3:Get red and green fruits.
            Console.WriteLine("3:Get red and green fruits.");
            var RedGreenFruit = (from Fruit in fruits
                                 where Fruit.Color == Color.Red || Fruit.Color == Color.Green
                                 select Fruit).ToList();
            displayfruit(RedGreenFruit);

            // 4: Get cheapest fruit.
            var chepCompair = 20;
            Console.WriteLine("4: Get cheapest fruit.");
            var CheapestFruit = (from Fruit in fruits
                                 where Fruit.Price <= chepCompair
                                 select Fruit).ToList();
            displayfruit(CheapestFruit);

            // 5: Get most expensive fruit.
            var chepExCompair = 50;
            Console.WriteLine("5: Get most expensive fruit.");
            var ExpensiveFruit = (from Fruit in fruits
                                  where Fruit.Price >= chepExCompair
                                  select Fruit).ToList();
            displayfruit(ExpensiveFruit);

            // 6: Get fruits by budget of 40 RS.
            var budget = 40;
            Console.WriteLine("6:get fruits by budget of 40 rs.");
            var mybudget = (from fruit in fruits
                            where fruit.Price <= budget
                            select fruit).ToList();
            displayfruit(mybudget);

            // 7: Get count of red fruits.
            Console.WriteLine("7: Get count of red fruits.");
            var CountRedFruit = (from Fruit in fruits
                                 where Fruit.Color == Color.Red
                                 select Fruit).Count();
            Console.WriteLine("Red Color Fruit " + CountRedFruit);
            Console.ReadKey();

            // 8: Group fruits with colors.
            Console.WriteLine("8: Group fruits with colors.");

            var grpFruit = from Fruit in fruits group Fruit by Fruit.Color into fruitGroup select fruitGroup;

            var groupColorFruitsLambda = fruits.GroupBy(Fruit => Fruit.Color);
            foreach (var fruitGroup in grpFruit)
            {
                Console.WriteLine(fruitGroup.Key);
                foreach (var fruit in fruitGroup)
                {
                    Console.WriteLine("   " + fruit.Name);
                }
            }
            Console.ReadKey();
        }
        static void dispCity(List<Cities> cities)
        {
            foreach (var Cities in cities)
            {
                Console.WriteLine(Cities.Name);

            }
            Console.ReadKey();
        }


        static void displayCity(List<string> cities)
        {
            foreach (var City in cities)
            {
                Console.WriteLine(City);
            }
            Console.ReadKey();
        }

        static void displayfruit(List<Fruit> fruits)
        {
            foreach (var Fruit in fruits)
            {
                Console.WriteLine(Fruit.Name);
            }
            Console.ReadKey();
        }
    }

    public class Cities
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public enum Color
    {
        Red,Green,Yellow
    }

    public class Fruit
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Color Color { get; set; }
        public double Price { get; set; }

    }
}
