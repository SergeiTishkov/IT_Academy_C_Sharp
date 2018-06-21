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

        private Lection(LectionType typeOfLection, DayOfWeek day, int numberOfLection)
        {
            TypeOfLection = typeOfLection;
            Day = day;
            NumberOfLection = numberOfLection;
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
            return new Lection(typeOfLection, day, numberOfLection);
        }

        public override string ToString() => $"{TypeOfLection} lection";
    }
}
