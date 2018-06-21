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

        // TODO (должна) Лекция точно должна знать о лекторе и университете?
        // о лекторе должна, чтобы по этому полю определять,
        
        // TODO lector.CanTeach != typeOfLection не достаточно?
        // спит ли лектор дома или усердно учит учеников,
        // а о универе должна знать, чтобы посмотреть,
        
        // TODO Это вы уже проверяете в методе создания лекции.
        // есть ли такой препод в штате этого универа или нет

        // TODO Всё равно не согласен.
        // Студенты, Лекторы, Лекции это составные части Университета.
        // Если детальнее то я бы сказал что универ агрегирует Студентов и Лекторов.
        // А в случае лекций у нас композиция так как без универа они не должны существовать.
        // Если я ничего не перепутал, то они примерно объекты одного уровня а значит им не стоит
        // содержать ссылки на друг друга
        // Диаграмка - https://i.imgur.com/LYH6FtP.png
        // Синие стрелки - зависимость. Направление - кто от кого.
        // Толщина - на сколько сильно (зависит от количиства использования одного класса внутри другого).
        // Зелёные трассеры - передаётся как параметр метода.
        // Почти все ваши классы зависят от одной лекции, но и лекция зависит от пары классов которые зависят от неё.
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
