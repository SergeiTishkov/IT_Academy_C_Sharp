using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniverHW.Humans
{
    public class Student : HomoSapiens
    {
        public Student(string firstName, string lastName, UniversityDepartment department, AllExistingGenders gender) : base(firstName, lastName, department, gender) { }

        public override void GetMoney()
        {
            Console.WriteLine($"{this} got " + (Gender == AllExistingGenders.Male ? "his" : "her") + " scholarship money... and wasted it on booze in half of an hour!");
            Console.WriteLine($"What {FirstName} {LastName} is going to do next month?..\n");
        }

        public override bool Equals(object obj)
            =>
            (obj is Student other &&
            FirstName == other.FirstName &&
            LastName == other.LastName &&
            Department == other.Department) ? true : false;

        public override string ToString()
        {
            return $"Student {FirstName} {LastName} from {Department} Department";
        }
    }
}
