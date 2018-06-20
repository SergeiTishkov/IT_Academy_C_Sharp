using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.Humans;

namespace Education
{
    public class University
    {
        // TODO private readonly naming я предпочитаю _listOfHumans, _schedule
        private readonly List<Human> listOfHumans = new List<Human>();
        private readonly WeekSchedule Schedule = new WeekSchedule();
        // TODO Убирайте вы эти снежные поля, на которых белые медведи едят мороженное

        public void AddPerson(Human human)
        {
            if (string.IsNullOrEmpty(human?.FullName))
            {
                Console.WriteLine("Wrong null human without even a name!");
                return;
            }

            if (listOfHumans.Contains(human))
            {
                Console.WriteLine($"{human.GetType().Name} {human.FullName} has already been added.\n");
                return;
            }

            Console.WriteLine($"{human.GetType().Name} {human.FullName} is added!\n");
            listOfHumans.Add(human);
        }

        public void AddPersons(params Human[] humans)
        {
            foreach (var human in humans)
            {
                AddPerson(human);
            }
        }

        public void AddLection(Lection lection)
        {
            Schedule.AddLection(lection);
        }

        public void AddLections(params Lection[] lections)
        {
            foreach (var lection in lections)
            {
                Schedule.AddLection(lection);
            }
        }

        public void CheckWholeWeek()
        {
            Console.WriteLine("\n\n\nOuch! There is Comission from the Ministry on our threshold!");
            Console.WriteLine("They come to check what is going on during the whole learning week in our University,");
            Console.WriteLine("So the inspection begins from Monday");
            Console.WriteLine("There is all lections in University during this week:\n");
            foreach (var lection in Schedule)
            {
                if (lection != null)
                {
                    _checkDayAndLection(lection.Day, lection.NumberOfLection);
                    Console.WriteLine("\n");
                }
            }
        }

        public void CheckDayAndLection(DayOfWeek day, int numberOfLection)
        {
            Console.WriteLine(
                $"Ouch! Comission from the Ministry came on {day} to check what is going on {numberOfLection} lection!\n");
            _checkDayAndLection(day, numberOfLection);
        }

        private void _checkDayAndLection(DayOfWeek day, int numberOfLection)
        {
            // TODO Я бы вначале создал переменную
            Lection lection = Schedule.GetDaySchedule(day)[numberOfLection - 1];

            //if (Schedule.GetDaySchedule(day)[numberOfLection - 1] == null)
            if (lection == null)
            {
                Console.WriteLine($"There isn't any lection during {numberOfLection} lection place on {day}");
                return;
            }

            //Lection lection = Schedule.GetDaySchedule(day)[numberOfLection - 1];
            Console.WriteLine($"{lection.Day} {lection.NumberOfLection} lection is {lection.TypeOfLection}:");
            foreach (var human in listOfHumans)
                human.DoingBusiness(lection);
        }

        // TODO Ааааааа... да ладно? А что измениться если просто удалить "? true : false"
        internal bool HasTeacher(Teacher teacher) => listOfHumans.Contains(teacher) ? true : false;
    }
}