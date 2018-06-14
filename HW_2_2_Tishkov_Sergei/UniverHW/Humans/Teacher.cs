using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniverHW.Humans
{
    public class Teacher : HomoSapiens
    {
        public Teacher(string firstName, string lastName, UniversityDepartment department, AllExistingGenders gender) : base(firstName, lastName, department, gender)
        {
        }

        public override void GetMoney()
        {
            Console.WriteLine($"{this} got " + (Gender == AllExistingGenders.Male ? "his" : "her") + " itsy-bitsy wage... and wasted it on booze in an hour!");
            Console.WriteLine($"{FirstName} {LastName} can live just by taking bribes from " + (Gender == AllExistingGenders.Male ? "his" : "her") + " students.\n");
        }

        public override bool Equals(object obj)
            => 
            (obj is Teacher other &&
            FirstName == other.FirstName &&
            LastName == other.LastName &&
            Department == other.Department) ? true : false; // TODO Опять `if true return true`
        

        public override string ToString()
        {
            return $"Teacher {FirstName} {LastName} from {Department} Department";
        }
    }
}
