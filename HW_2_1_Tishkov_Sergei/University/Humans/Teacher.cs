using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Education.Humans
{
    public class Teacher : Human
    {
        // TODO Readonly
        internal LectionType CanTeach;

        public Teacher(string fullName, LectionType lectionType) : base(fullName)
        {
            CanTeach = lectionType;
        }

        public override void DoingBusiness(Lection lection)
        {
            Work(lection);
        }

        internal void Work(Lection lection) => // TODO (сделано) реализовал тернарник
            Console.WriteLine(
                lection.Lector == this ?
                $"{CanTeach} teacher {FullName} is teaching students." :
                $"{CanTeach} teacher {FullName} is sleeping at home during {lection}.");
    }
}
