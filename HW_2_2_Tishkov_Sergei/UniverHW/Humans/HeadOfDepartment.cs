using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniverHW.Humans
{
    public class HeadOfDepartment : Teacher
    {
        public HeadOfDepartment(string firstName, string lastName, UniversityDepartment department, AllExistingGenders gender) : base(firstName, lastName, department, gender)
        {
        }

        public override void GetMoney()
        {
            Console.WriteLine($"{this} got " + (Gender == AllExistingGenders.Male ? "his" : "her") + 
                " wage and it will be enough for the next month for " + (Gender == AllExistingGenders.Male ? "him.\n" : "her.\n"));
        }

        public override bool Equals(object obj)
            =>
            (obj is HeadOfDepartment other &&
            FirstName == other.FirstName &&
            LastName == other.LastName &&
            Department == other.Department) ? true : false;

        public override string ToString()
        {
            return $"Head of {Department} Department {FirstName} {LastName}";
        }
    }
}
