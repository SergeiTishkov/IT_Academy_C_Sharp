using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture14HW.Task3
{
    public class FuelCar : Car
    {
        public FuelCar(string brand, string model, int releasedYear, decimal tankSize, decimal price) : 
            base(brand, model, releasedYear, price)
            =>
            TankSize = tankSize;

        public decimal TankSize { get; set; }

        public override string ToString() => $"Car {Brand} {Model} (first released in {ReleasedYead})\nwith {TankSize} litres capacity of fuel tank, cost {Price} dollars";
    }
}
