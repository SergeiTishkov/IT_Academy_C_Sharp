using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_1_9_Tishkov_Sergei_
{
    class Program
    {
        static void Main(string[] args)
        {
            var student = new Student("Sergei", "Tishkov", new DateTime(1992, 8, 28));

            student.AddMarks(new Mark(7, "Sopromat", new DateTime(2011, 11, 24)), new Mark(9, "Sopromat", new DateTime(2011, 11, 27)));
            Console.WriteLine("Check if ToString works correctly\n");
            Console.WriteLine(student + "\n\n");
            var studentGroup = new StudentGroup();
            studentGroup.AddStudent(student);
            Console.WriteLine("Check if indexer works correctly\n");
            Console.WriteLine(studentGroup[0] + "\n\n");

            var oneMoreStudent = new Student("Igor", "Tishkov", new DateTime(1986, 11, 22));
            studentGroup.AddStudent(oneMoreStudent);
            studentGroup.RemoveStudent(student);

            foreach (var stdnt in studentGroup)
            {
                Console.WriteLine(stdnt);
            }
        }
    }
}
