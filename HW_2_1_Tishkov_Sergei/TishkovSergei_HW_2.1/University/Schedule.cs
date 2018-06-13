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
        internal Lection[] MondaySchedule = new Lection[3];
        internal Lection[] TuesdaySchedule = new Lection[3];
        internal Lection[] WednesdaySchedule = new Lection[3];
        internal Lection[] ThursdaySchedule = new Lection[3];
        internal Lection[] FridaySchedule = new Lection[3];
        internal Lection[] SaturdaySchedule = new Lection[3];


        internal WeekSchedule()
        {
            MondaySchedule = new Lection[3];
            TuesdaySchedule = new Lection[3];
            WednesdaySchedule = new Lection[3];
            ThursdaySchedule = new Lection[3];
            FridaySchedule = new Lection[3];
            SaturdaySchedule = new Lection[3];
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

        // TODO Идея понятна, но реализация не очень. А если бы вам пришлось на весь месяц расписание писать?
        public IEnumerator<Lection> GetEnumerator()
        {
            yield return MondaySchedule[0];
            yield return MondaySchedule[1];
            yield return MondaySchedule[2];

            yield return TuesdaySchedule[0];
            yield return TuesdaySchedule[1];
            yield return TuesdaySchedule[2];

            yield return WednesdaySchedule[0];
            yield return WednesdaySchedule[1];
            yield return WednesdaySchedule[2];

            yield return ThursdaySchedule[0];
            yield return ThursdaySchedule[1];
            yield return ThursdaySchedule[2];

            yield return FridaySchedule[0];
            yield return FridaySchedule[1];
            yield return FridaySchedule[2];

            yield return SaturdaySchedule[0];
            yield return SaturdaySchedule[1];
            yield return SaturdaySchedule[2];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return MondaySchedule[0];
            yield return MondaySchedule[1];
            yield return MondaySchedule[2];

            yield return TuesdaySchedule[0];
            yield return TuesdaySchedule[1];
            yield return TuesdaySchedule[2];

            yield return WednesdaySchedule[0];
            yield return WednesdaySchedule[1];
            yield return WednesdaySchedule[2];

            yield return ThursdaySchedule[0];
            yield return ThursdaySchedule[1];
            yield return ThursdaySchedule[2];

            yield return FridaySchedule[0];
            yield return FridaySchedule[1];
            yield return FridaySchedule[2];

            yield return SaturdaySchedule[0];
            yield return SaturdaySchedule[1];
            yield return SaturdaySchedule[2];
        }
    }
}
