using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loborotorca_3._2
{
    public enum ProductType
    {
        Meat,
        DriedFruits,
        Grain,
        Flour,
        Fabrics,
        Paint
    }

    public enum Event
    {
        NormalDay,
        Rain,
        SmoothRoad,
        BrokenWheel,
        River,
        LocalEncounter,
        HighwayRobbers,
        RoadsideTavern,
        SpoiledGoods
    }

    

    public class Program
    {
        public static void Main(string[] args)
        {
            List<City> cities = new List<City>
            {
                new City("Город1", 50),
                new City("Город2", 60),
                new City("Город3", 70),
                new City("Город4", 80),
                new City("Город5", 90),
                new City("Город6", 100),
                new City("Город7", 110)
            };

            Random random = new Random();
            Trader trader = new Trader(100, random.Next(1, 6), random.Next(100, 1000));

            while (true)
            {
                Console.WriteLine("__________________________________________");
                City currentCity = cities[random.Next(0, cities.Count)];
                Console.WriteLine($"Торговец отправляется в город {currentCity.Name}");

                while (trader.CarryingCapacity > 0 && trader.Money > 0)
                {
                    ProductType randomProductType = (ProductType)random.Next(Enum.GetValues(typeof(ProductType)).Length);
                    double randomWeight = random.Next(1, 10);
                    double randomPurchasePrice = random.Next(10, 100);
                    double randomQuality = random.NextDouble() * 0.9 + 0.1;
                    Product product = new Product(randomWeight, randomProductType, randomPurchasePrice, randomQuality);

                    if (product.PurchasePrice > trader.Money || product.Weight > trader.CarryingCapacity)
                    {
                        break;
                    }

                    trader.LoadProduct(product);
                }

                trader.PrintCart();
                trader.PrintStatus(currentCity);

                // Выбор случайного события
                Event randomEvent = (Event)random.Next(Enum.GetValues(typeof(Event)).Length);
                Console.WriteLine($"Событие: ");

                switch (randomEvent)
                {
                    case Event.Rain:
                        trader.Speed -= 2;
                        if (random.NextDouble() <= 0.3)
                        {
                            int randomIndex = random.Next(0, trader.Cart.Count);
                            trader.Cart[randomIndex].Quality *= 0.95;
                        }
                        Console.WriteLine("Дождь");
                        break;
                    case Event.SmoothRoad:
                        trader.Speed = Math.Min(trader.Speed + 2, 5);
                        Console.WriteLine("Гладкая дорога");
                        break;
                    case Event.BrokenWheel:
                        Console.WriteLine("Сломанное колесо");
                        break;
                    case Event.River:
                        Console.WriteLine("День потрачен на поиск брода");
                        break;
                    case Event.LocalEncounter:
                        int extraDistance = random.Next(3, 7);
                        trader.Speed += extraDistance;
                        Console.WriteLine("Местная встреча");
                        break;
                    case Event.HighwayRobbers:
                        if (trader.Money > 0)
                        {
                            trader.Money -= random.NextDouble() * trader.Money;
                            Console.WriteLine($"Дорожные грабители.Они забрали:{Math.Floor(trader.Money)}");
                        }
                        else if (trader.Cart.Count > 0)
                        {
                            int randomIndex = random.Next(0, trader.Cart.Count);
                            trader.Cart.RemoveAt(randomIndex);
                            Console.WriteLine($"Дорожные грабители");
                        }
                        
                        break;
                    case Event.RoadsideTavern:
                        Console.WriteLine("Возможность продажи/покупки товара и траты денег на еду/ночлег");
                        break;
                    case Event.SpoiledGoods:
                        if (trader.Cart.Count > 0)
                        {
                            int randomIndex = random.Next(0, trader.Cart.Count);
                            trader.Cart[randomIndex].Quality *= 0.1;

                            Console.WriteLine("Испорченный товар"); 
                        }
                        break;
                    default:
                        Console.WriteLine("Обычный день, ничего не происходит");
                        // Обычный день, ничего не происходит
                        break;
                }

                double travelTime = currentCity.Distance / trader.Speed;
                Console.WriteLine($"Путешествие займет {Math.Floor(travelTime)} дней");
                Console.WriteLine();
                Console.ReadLine();
                // Переход в следующий город
                cities.Remove(currentCity);
                if (cities.Count == 0)
                {
                    break;
                }
            }

            Console.WriteLine("Путешествие завершено!");
            Console.ReadLine();
        }
    }
}
