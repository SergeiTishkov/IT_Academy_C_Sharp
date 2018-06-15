using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniverHW.Humans
{
    public abstract class HomoSapiens
    {
        public readonly string FirstName;
        public readonly string LastName;
        public readonly AllExistingGenders Gender;
        public UniversityDepartment Department { get; internal set; }

        public HomoSapiens(string firstName, string lastName, UniversityDepartment department, AllExistingGenders gender)
        {
            FirstName = firstName;
            LastName = lastName;
            Department = department;
            Gender = gender;
        }
    }
}
