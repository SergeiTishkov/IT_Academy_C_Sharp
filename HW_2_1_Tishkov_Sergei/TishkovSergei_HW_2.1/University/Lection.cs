using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Education.Humans;

namespace Education
{
    public class Lection
    {
        internal readonly LectionType TypeOfLection;
        internal readonly DayOfWeek Day;
        internal readonly int NumberOfLection;
        internal readonly University Univer;
        internal Teacher Lector;

        private Lection(LectionType typeOfLection, DayOfWeek day, int numberOfLection, University univer, Teacher lector)
        {
            //if(day == DayOfWeek.Sunday)
            //    throw new Exception("There isn't lections on Sunday!"); // я просто не знаю, как предотвратить создание класса с неверными параметрами! Разве что создать метод Factory?
            //if (numberOfLection > 3)                                    // который возвращал бы объект Lection только, если ему передаются верные параметры? А давайте попробуем
            //    throw new Exception("There is 3 lections or less each day!");
            //if (numberOfLection < 0)
            //    throw new Exception("There isn't any 'minus' lections!");
            //if (lector.CanTeach != typeOfLection)
            //    throw new Exception("This teacher can't teach this lection!");
            //if (!univer.HasTeacher(lector))
            //    throw new Exception("This teacher is out of the University staff!");

            TypeOfLection = typeOfLection;
            Day = day;
            NumberOfLection = numberOfLection;
            Lector = lector;
            Univer = univer;
        }
        public override string ToString()
        {
            return $"{TypeOfLection} lection";
        }

        public static Lection CreateLection(LectionType typeOfLection, DayOfWeek day, int numberOfLection, University univer, Teacher lector)
        {
            if (day == DayOfWeek.Sunday)
            {
                Console.WriteLine("ERROR!!! ======>>>>>>>There isn't lections on Sunday!\n");
                return null;
            }
            if (numberOfLection > 3)
            {
                Console.WriteLine("ERROR!!! ======>>>>>>>There is 3 lections or less each day!\n");
                return null;
            }
            if (numberOfLection < 0)
            {
                Console.WriteLine("ERROR!!! ======>>>>>>>There isn't any 'minus' lections!\n");
                return null;
            }
            if (lector.CanTeach != typeOfLection)
            {
                Console.WriteLine("ERROR!!! ======>>>>>>>This teacher can't teach this lection!\n");
                return null;
            }
            if (!univer.HasTeacher(lector))
            {
                Console.WriteLine("ERROR!!! ======>>>>>>>This teacher is out of the University staff!\n");
                return null;
            }
            return new Lection(typeOfLection, day, numberOfLection, univer, lector);
        }
    }
}
