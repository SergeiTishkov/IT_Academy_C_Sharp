using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture14HW.Task3
{
    public static class CarParkExtensions
    {
        public static IEnumerable<Car> GetCars(this CarPark carPark, Func<Car, bool> func) => carPark.Cars.Where(func);

        public static void SortCars(this CarPark carPark, Comparison<Car> comparison) => carPark.Cars.Sort(comparison);
    }
}
