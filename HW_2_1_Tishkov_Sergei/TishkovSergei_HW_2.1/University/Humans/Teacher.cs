using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Education.Humans
{
    public class Teacher : Human
    {
        internal LectionType CanTeach;
        public Teacher(string fullName, LectionType lectionType) : base(fullName)
        {
            CanTeach = lectionType;
        }

        public override void DoingBusiness(Lection lection)
        {
            Work(lection);
        }

        internal void Work(Lection lection)
        {
            if(lection.Lector == this)
                Console.WriteLine($"{CanTeach} teacher {FullName} is teaching students.");
            else
                Console.WriteLine($"{CanTeach} teacher {FullName} is sleeping at home during {lection}.");
        }
    }
}
