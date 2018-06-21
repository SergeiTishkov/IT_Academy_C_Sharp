using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Humans
{
    public class TechStudent : Student
    {
        public TechStudent(string fullName) : base(fullName, LectionType.Math | LectionType.Physics) { }

        public override void DoingBusiness(Lection lection) => Learn(lection);

        public override void Learn(Lection lection) => 
            Console.WriteLine(
                IsMySpecialization(lection)                             // не стал переносить в класс Student чтобы не потерять в ToString указание на то, какой тип это студента,
                ? $"{this} is enjoying {lection} and studying hard!"    //  и не хотел делать свич паттерн матчинг в Learn() в Student, т.к. затраты машинных ресурсов.
                : $"{this} is bored to sleep by {lection}.");
            
        public override string ToString() => $"Tech student {FullName}";
    }
}
