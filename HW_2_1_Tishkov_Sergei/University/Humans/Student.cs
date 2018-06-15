using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Humans
{
    public abstract class Student : Human
    {
        protected LectionType _specialization;
        public Student(string fullName, LectionType specialization) : base(fullName) => _specialization = specialization;

        public abstract void Learn(Lection lection);

        protected bool IsMySpecialization(Lection lection) => _specialization.HasFlag(lection.TypeOfLection);
    }
}
