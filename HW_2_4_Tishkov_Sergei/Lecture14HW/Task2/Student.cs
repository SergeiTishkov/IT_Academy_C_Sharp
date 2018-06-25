using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lecture14HW.Helpers;

namespace Lecture14HW.Task2
{
    public class Student 
    {
        public Student()
        {
            FirstName = Rnd.RandomFirstName;
            LastName = Rnd.RandomLastName;
            AvgMark = Rnd.RandomMark;
        }

        public Student(int avgMark, string lastName, string firstName)
        {
            AvgMark = avgMark;
            LastName = lastName;
            FirstName = firstName;
        }

        public double AvgMark { get; private set; }

        public string LastName { get; }

        public string FirstName { get; }

        //public StudentIncreaseAvgMarkDelegate AvgMarkIncreaseAction() => new StudentIncreaseAvgMarkDelegate
        //    ( (lowBound, highBound, increase) => { if (AvgMark <= highBound && AvgMark >= lowBound) AvgMark += increase; } );
        // 
        // 1. Мне кажется можно спокойно сделать это свойством
        // 2. На ревью я бы настаивал на выносе в отдельный класс.
        // На мой взгляд такое действие не относится к студенту.

        // комментарий ученика - вообще эта задача была сугубо учебной, смысла делать делегат тут не было вовсе,
        // и потому просто исправлять тут что бы то ни было не вижу мотива - в нормальном коде это был бы простой метод,
        // возвращающий void и меняющий состояние студента, все.
        // что до выноса в отдельный класс - так AvgMark имеет private set, потому его можно менять только внутри кода этого класса

        public StudentIncreaseAvgMarkDelegate AvgMarkIncreaseAction => 
            (lowBound, highBound, increase) => { if (AvgMark <= highBound && AvgMark >= lowBound) AvgMark += increase; };

        public override string ToString() => 
            $"Student {FirstName} {LastName} with average mark {AvgMark:0.##}";
    }
}
