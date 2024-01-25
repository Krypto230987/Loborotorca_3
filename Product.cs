using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loborotorca_3._2
{
    public class Product
    {
        public double Weight { get; set; }
        public ProductType Type { get; set; }
        public double PurchasePrice { get; set; }
        public double Quality { get; set; }

        public Product(double weight, ProductType type, double purchasePrice, double quality)
        {
            Weight = weight;
            Type = type;
            PurchasePrice = purchasePrice;
            Quality = quality;
        }
    }
}
