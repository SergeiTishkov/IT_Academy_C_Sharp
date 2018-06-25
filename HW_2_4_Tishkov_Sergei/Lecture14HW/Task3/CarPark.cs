using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture14HW.Task3
{
    public class CarPark
    {
        public List<Car> Cars { get; set; } = new List<Car>();
        private Action<string> _addingAction;

        public CarPark(Action<string> action) => _addingAction = action;

        public void AddCar(Car car)
        {
            // TODO Инвертируем, уменьшаем вложенность, улучшаем читаемость
            if (car == null) return;

            _addingAction(car.ToString() + " was added to the park;");
            Cars.Add(car);
        }

        public void AddCars(params Car[] cars)
        {
            foreach (var car in cars)
                AddCar(car);
        }

        public void ShowCars()
        {
            foreach (var car in Cars)
                Console.WriteLine(car);
        }


    }
}
