using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education
{
    internal class WeekSchedule : IEnumerable<Lection>
    {
        private Lection[][] _arrayForForeach;
        internal Lection[] MondaySchedule;
        internal Lection[] TuesdaySchedule;
        internal Lection[] WednesdaySchedule;
        internal Lection[] ThursdaySchedule;
        internal Lection[] FridaySchedule;
        internal Lection[] SaturdaySchedule;


        internal WeekSchedule()
        {
            MondaySchedule = new Lection[3];
            TuesdaySchedule = new Lection[3];
            WednesdaySchedule = new Lection[3];
            ThursdaySchedule = new Lection[3];
            FridaySchedule = new Lection[3];
            SaturdaySchedule = new Lection[3];
            _arrayForForeach = new Lection[][] { MondaySchedule, TuesdaySchedule, WednesdaySchedule, ThursdaySchedule, FridaySchedule, SaturdaySchedule };
        }

        internal void AddLection(Lection lection)
        {
            if (lection == null)
            {
                Console.WriteLine("Lection is not organised well! Not in our University!!!");
                return;
            }
            switch (lection.Day)
            {
                case DayOfWeek.Monday:
                    SetLection(MondaySchedule, lection);
                    break;
                case DayOfWeek.Tuesday:
                    SetLection(TuesdaySchedule, lection);
                    break;
                case DayOfWeek.Wednesday:
                    SetLection(WednesdaySchedule, lection);
                    break;
                case DayOfWeek.Thursday:
                    SetLection(ThursdaySchedule, lection);
                    break;
                case DayOfWeek.Friday:
                    SetLection(FridaySchedule, lection);
                    break;
                case DayOfWeek.Saturday:
                    SetLection(SaturdaySchedule, lection);
                    break;
            }
        }

        private void SetLection(Lection[] daySchedule, Lection lection)
        {
            if (daySchedule[lection.NumberOfLection - 1] != null)
            {
                if (daySchedule[lection.NumberOfLection - 1] == lection)
                {
                    Console.WriteLine($"Lection {lection.Day} {lection.NumberOfLection} {lection} was already set");
                    return;
                }
                Console.WriteLine($"Old {lection.Day} {lection.NumberOfLection} {daySchedule[lection.NumberOfLection - 1]} was changed to new {lection}");
                daySchedule[lection.NumberOfLection - 1] = lection;
            }
            else
            {
                daySchedule[lection.NumberOfLection - 1] = lection;
                Console.WriteLine($"New {lection.Day} {lection.NumberOfLection} {daySchedule[lection.NumberOfLection - 1]} was set");
            }
        }

        internal Lection[] GetDaySchedule(DayOfWeek day)
        {
            switch (day)
            {
                case DayOfWeek.Sunday:
                    return null;
                case DayOfWeek.Monday:
                    return MondaySchedule;
                case DayOfWeek.Tuesday:
                    return TuesdaySchedule;
                case DayOfWeek.Wednesday:
                    return WednesdaySchedule;
                case DayOfWeek.Thursday:
                    return ThursdaySchedule;
                case DayOfWeek.Friday:
                    return FridaySchedule;
                case DayOfWeek.Saturday:
                    return SaturdaySchedule;
                default:
                    return null;
            }
        }

        public IEnumerator<Lection> GetEnumerator()
        {
            foreach (var daySchedule in _arrayForForeach)
                foreach (var lection in daySchedule)
                    yield return lection;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}