using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniverHW.Humans
{
    public class Teacher : HomoSapiens
    {
        public Teacher(string firstName, string lastName, UniversityDepartment department, AllExistingGenders gender) : base(firstName, lastName, department, gender) { }

        public virtual void Teach() => Console.WriteLine($"{this} is teaching " + (Gender == AllExistingGenders.Male ? "his" : "her") + " students.\n");

        public override bool Equals(object obj)
            =>
            obj is Teacher other &&
            FirstName == other.FirstName &&
            LastName == other.LastName &&
            Department == other.Department;

        public override string ToString() => $"Teacher {FirstName} {LastName} from {Department} Department";

        public override int GetHashCode() => this.ToString().GetHashCode() + (int)Gender; // переопределял чтобы класс зеленым не подчеркивало, не нравится
    }
}
