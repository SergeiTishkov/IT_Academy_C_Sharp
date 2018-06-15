using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture14HW.Task3
{
    public class ElectroCar : Car
    {
        public ElectroCar(string brand, string model, int releasedYear, decimal batterySize, decimal price) : 
            base(brand, model, releasedYear, price)
            =>
            BatterySize = batterySize;
         
        public decimal BatterySize { get; set; }

        public override string ToString() => $"ElectroCar {Brand} {Model} (first released in {ReleasedYead})\nwith {BatterySize} kw/h battery capacity, cost {Price} dollars";
    }
}
