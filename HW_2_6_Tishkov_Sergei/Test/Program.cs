using System;

using VariantTwo;
using VariantTwo.Loggers;
using VariantTwo.Exceptions;

namespace Test
{
    class Program 
    {
        static void Main(string[] args)
        {
            VariandTwoTest();
        }

        static void VariandTwoTest()
        {
            var group = new StudentGroup(8294);
            var logger = new ConsoleStudentGroupLogger(group);

            var students = new[]
            {
                new Student("Tishkov Sergei"),
                null,
                new Student(null),
                new Student("Another Student")
            };

            Console.WriteLine("Попробуем добавить целую группу студентов, имеющую невалидные значения:\n");
            try
            {
                group.AddStudents(students);
            }
            catch (InvalidStudentException) { }
            catch { }

            Console.WriteLine("Посмотрим, есть ли студенты в группе после добавления целой группы, где были невалидные студенты:\n");
            group.ShowStudentsInGroup();


            Console.WriteLine("Попробуем добавить эту же группу студентов, валидных и невалидных, по одному:\n");
            foreach (var student in students)
            {
                try
                {
                    group.AddStudent(student);
                }
                catch (InvalidStudentException) { }
                catch { }
            }

            Console.WriteLine("Посмотрим, есть ли студенты в группе после добавления валидных и невалидных студентов поодиночке:\n");
            group.ShowStudentsInGroup();
            Console.ReadKey(true);
        }
    }
}
