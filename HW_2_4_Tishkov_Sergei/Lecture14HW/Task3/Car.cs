using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture14HW.Task3
{
    public abstract class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ReleasedYead { get; set; }
        public decimal Price { get; set; }

        public Car(string brand, string model, int releasedYear, decimal price)
        {
            Brand = brand;
            Model = model;
            ReleasedYead = releasedYear;
            Price = price;
        }
    }
}
