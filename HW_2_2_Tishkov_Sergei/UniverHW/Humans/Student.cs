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

        public void Learn() => Console.WriteLine($"{this} is studying {(Gender == AllExistingGenders.Male ? "his" : "her")} lessons.\n");

        public override bool Equals(object obj)
            =>
            (obj is Student other &&
            FirstName == other.FirstName &&
            LastName == other.LastName &&
            Department == other.Department);

        public override string ToString() => $"Student {FirstName} {LastName} from {Department} Department";

        public override int GetHashCode() => this.ToString().GetHashCode() + (int)Gender; // переопределял чтобы класс зеленым не подчеркивало, не нравится
    }
}
