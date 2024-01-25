using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loborotorca_3._2
{
    public class City
    {
        public string Name { get; set; }
        public double Distance { get; set; }

        public City(string name, double distance)
        {
            Name = name;
            Distance = distance;
        }
    }
}
