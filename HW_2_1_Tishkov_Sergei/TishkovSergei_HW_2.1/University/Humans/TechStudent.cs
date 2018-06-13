using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Humans
{
    public class TechStudent : Student
    {
        public TechStudent(string fullName) : base(fullName)
        {
        }

        public override void DoingBusiness(Lection lection)
        {
            Learn(lection);
        }

        public override void Learn(Lection lection)
        {
            if ((int)lection.TypeOfLection > 2)
            {
                Console.WriteLine($"{this} is bored to sleep by {lection}.");
            }
            else
            {
                Console.WriteLine($"{this} is enjoying {lection} and studying hard!");
            }
        }

        public override string ToString() => $"Tech student {FullName}";
    }
}
