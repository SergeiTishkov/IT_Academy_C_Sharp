using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Humans
{
    public abstract class Human
    {
        public readonly string FullName;

        public Human(string fullName)
        {
            FullName = fullName;
        }

        public abstract void DoingBusiness(Lection lection);
    }
}
