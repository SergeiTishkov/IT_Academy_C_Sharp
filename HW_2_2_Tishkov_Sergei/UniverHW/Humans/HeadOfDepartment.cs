using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniverHW.Humans
{
    public class HeadOfDepartment : Teacher
    {
        public HeadOfDepartment(string firstName, string lastName, UniversityDepartment department, AllExistingGenders gender) : base(firstName, lastName, department, gender) { }

        public override void Teach() => Console.WriteLine($"{this} is teaching {(Gender == AllExistingGenders.Male ? "his" : "her")} staff how to teach their students.");

        public void RuleDepartment() => Console.WriteLine($"Also {FirstName} ruling {(Gender == AllExistingGenders.Male ? "his" : "her")} department, whatever that means.\n");

        public override bool Equals(object obj)
            =>
            (obj is HeadOfDepartment other &&
            FirstName == other.FirstName &&
            LastName == other.LastName &&
            Department == other.Department);

        public override string ToString() => $"Head of {Department} Department {FirstName} {LastName}";

        public override int GetHashCode() => this.ToString().GetHashCode() + (int)Gender; // переопределял чтобы класс зеленым не подчеркивало, не нравится
    }
}
