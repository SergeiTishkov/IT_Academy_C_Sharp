using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Humans
{
    public abstract class Student : Human
    {
        public Student(string fullName) : base(fullName)
        { }
        public abstract void Learn(Lection lection);
    }
}
