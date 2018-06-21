using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UniverHW.Humans;

namespace UniverHW
{
    public class University
    {
        internal readonly List<HomoSapiens> TechDepartment;
        internal readonly List<HomoSapiens> MathDepartment;
        internal readonly List<HomoSapiens> HistoryDepartment;

        public University()
        {
            TechDepartment = new List<HomoSapiens>();
            MathDepartment = new List<HomoSapiens>();
            HistoryDepartment = new List<HomoSapiens>();
        }

        public void AddPeople(HomoSapiens human)
        {
            if (human == null || string.IsNullOrEmpty(human.FirstName) || string.IsNullOrEmpty(human.LastName))
            {
                Console.WriteLine("Null people or people without name can't be added");
                return;
            }

            switch (human.Department)
            {
                case UniversityDepartment.Tech:
                    AddHuman(TechDepartment, human);
                    break;
                case UniversityDepartment.Math:
                    AddHuman(MathDepartment, human);
                    break;
                case UniversityDepartment.History:
                    AddHuman(HistoryDepartment, human);
                    break;
            }
        }

        public void AddPeoples (params HomoSapiens[] humans)
        {
            foreach (var human in humans)
                AddPeople(human);
        }

        public void MakeUniversityWork()
        {
            MakeDepartmentDoWhatItShouldDo(TechDepartment);
            MakeDepartmentDoWhatItShouldDo(MathDepartment);
            MakeDepartmentDoWhatItShouldDo(HistoryDepartment);
        }

        private void MakeDepartmentDoWhatItShouldDo(List<HomoSapiens> department)
        {
            foreach (var human in department)
            {
                switch (human)
                {
                    case Student student:
                        student.Learn();
                        break;
                    case Teacher teacher when !(teacher is HeadOfDepartment):
                        teacher.Teach();
                        break;
                    case HeadOfDepartment head:
                        head.Teach();
                        head.RuleDepartment();
                        break;
                    default:
                        break;
                }
            }
        }

        private void AddHuman(List<HomoSapiens> departmentList, HomoSapiens human)
        {
            if (departmentList.Contains(human))
            {
                Console.WriteLine($"Can't add {human} one more time.");
            }
            else
            {
                departmentList.Add(human);
                switch (human)
                {
                    case Student student:
                        Console.WriteLine($"Student {student.FirstName} {student.LastName} was added to the {student.Department} Department");
                        break;
                    case Teacher teacher when !(teacher is HeadOfDepartment):
                        Console.WriteLine($"Teacher {teacher.FirstName} {teacher.LastName} was added to the {teacher.Department} Department");
                        break;
                    case HeadOfDepartment head:
                        Console.WriteLine($"{human.FirstName} {human.LastName} was added to the staff as head of {head.Department} Department");
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
