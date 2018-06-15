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

        // TODO (должна) Лекция точно должна знать о лекторе и университете? // о лекторе должна, чтобы по этому полю определять, спит ли лектор дома или усердно учит учеников, а о универе должна знать, чтобы посмотреть, есть ли такой препод в штате этого универа или нет
        internal readonly University Univer; 
        internal Teacher Lector;

        private Lection(LectionType typeOfLection, DayOfWeek day, int numberOfLection, University univer, Teacher lector)
        {
            TypeOfLection = typeOfLection;
            Day = day;
            NumberOfLection = numberOfLection;
            Lector = lector;
            Univer = univer;
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

        public override string ToString() => $"{TypeOfLection} lection";
    }
}
