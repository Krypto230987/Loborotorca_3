using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loborotorca_3._2
{
    public class Trader
    {
        public double CarryingCapacity { get; set; }
        public double Speed { get; set; }
        public double Money { get; set; }
        public List<Product> Cart { get; set; }

        public Trader(double carryingCapacity, double speed, double money)
        {
            CarryingCapacity = carryingCapacity;
            Speed = speed;
            Money = money;
            Cart = new List<Product>();
        }

        public void LoadProduct(Product product)
        {
            if (product.Weight <= CarryingCapacity && product.PurchasePrice <= Money)
            {
                Cart.Add(product);
                CarryingCapacity -= product.Weight;
                Money -= product.PurchasePrice;
            }
        }

        public void PrintCart()
        {
            Console.WriteLine("Товары в телеге:");
            foreach (var product in Cart)
            {
                Console.WriteLine($"- {product.Type}, вес: {product.Weight}, стоимость: {product.PurchasePrice}");
            }
            Console.WriteLine();
        }

        public void PrintStatus(City currentCity)
        {
            Console.WriteLine($"Текущий город: {currentCity.Name}");
            Console.WriteLine($"Оставшаяся грузоподъемность: {CarryingCapacity}");
            Console.WriteLine($"Оставшиеся деньги: {Money}");
            Console.WriteLine();
        }
    }
}
