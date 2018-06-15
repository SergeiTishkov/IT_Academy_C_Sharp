using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Education;
using Education.Humans;


namespace Tishkov_Sergei_2_1_HW
{
    class Program
    {
        static void Main(string[] args)
        {
            University univer = new University();

            Teacher histTeach = new Teacher("Eugeniy Ponasenkov", LectionType.History);
            Teacher engTeach = new Teacher("Aleksandr Pushkin", LectionType.Literature);
            Teacher mathTeach = new Teacher("Isaak Newton", LectionType.Math);
            Teacher physTeach = new Teacher("Albert Einstein", LectionType.Physics);

            TechStudent tst1 = new TechStudent("Sergei Tishkov");
            TechStudent tst2 = new TechStudent("Aleksandr Maisak");
            TechStudent tst3 = new TechStudent("Anton Akulenok");

            HumanitarianStudent hst1 = new HumanitarianStudent("Anton Chekhov");
            HumanitarianStudent hst2 = new HumanitarianStudent("Leo Tolstoi");
            HumanitarianStudent hst3 = new HumanitarianStudent("Feodor Dostoevsky");

            univer.AddPersons(histTeach, engTeach, mathTeach, physTeach, tst1, tst2, tst3, hst1, hst2, hst3);

            univer.AddPerson(tst1);

            Console.WriteLine("\n\n********************************\n\n");
            Console.WriteLine("End of the first test. Press any key to enter the second test.");
            Console.ReadKey(true);
            Console.Clear();

            var fridaySecondLection = Lection.CreateLection(LectionType.Math, DayOfWeek.Friday, 2, univer, mathTeach);
            univer.AddLection(fridaySecondLection);

            univer.CheckDayAndLection(DayOfWeek.Friday, 2);

            Console.WriteLine("\n\n********************************\n\n");
            Console.WriteLine("End of the second test. Press any key to enter the third test.");
            Console.ReadKey(true);
            Console.Clear();

            var mondayFirstLection = Lection.CreateLection(LectionType.Literature, DayOfWeek.Monday, 1, univer, engTeach);
            var tuedaySecondLection = Lection.CreateLection(LectionType.Math, DayOfWeek.Tuesday, 2, univer, mathTeach);
            var wednesdayFirstLection = Lection.CreateLection(LectionType.Physics, DayOfWeek.Wednesday, 1, univer, physTeach);
            var thursdayThirdLection = Lection.CreateLection(LectionType.Physics, DayOfWeek.Thursday, 3, univer, physTeach);
            var fridaySecondLection_Redefine = Lection.CreateLection(LectionType.Literature, DayOfWeek.Friday, 2, univer, engTeach);
            var saturdayFirstLEction = Lection.CreateLection(LectionType.Math, DayOfWeek.Saturday, 1, univer, mathTeach);
            var saturdayThirdLection = Lection.CreateLection(LectionType.History, DayOfWeek.Saturday, 3, univer, histTeach);

            univer.AddLections(mondayFirstLection, tuedaySecondLection, wednesdayFirstLection, thursdayThirdLection, fridaySecondLection_Redefine, saturdayFirstLEction, saturdayThirdLection);

            univer.CheckWholeWeek();


        }
    }
}
