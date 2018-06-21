using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Humans
{
    public class HumanitarianStudent : Student
    {
        public HumanitarianStudent(string fullName) : base(fullName, LectionType.History | LectionType.Literature){ }

        public override void DoingBusiness(Lection lection) => Learn(lection);

        public override void Learn(Lection lection) =>  // не стал переносить в класс Student чтобы не потерять в ToString указание на то, какой тип это студента,
            Console.WriteLine(                          //  и не хотел делать свич паттерн матчинг в Learn() в Student, т.к. затраты машинных ресурсов.
                IsMySpecialization(lection)
                ? $"{this} is enjoying {lection} and studying hard!"
                : $"{this} is bored to sleep by {lection}.");

        public override string ToString() => $"Humanitarian student {FullName}";
    }
}
