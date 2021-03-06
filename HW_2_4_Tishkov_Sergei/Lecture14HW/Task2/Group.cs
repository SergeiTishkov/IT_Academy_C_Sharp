﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture14HW.Task2
{
    public class Group
    {
        private readonly List<Student> _students = new List<Student>();

        public static StudentAvgMarkComparer AvgMarkComparerAscending { get; } = new StudentAvgMarkComparer();

        public void AddRandomStudent() => _students.Add(new Student());

        public void AddRangeOfRandomStudents(int range)
        {
            for (int i = 0; i < range; i++)
                AddRandomStudent();
        }

        public StudentAvgMarkComparerDelegate SortStudents() => 
            new StudentAvgMarkComparerDelegate(_students.Sort); 
        // вот так можно вынести наружу делегат, сортирующий студентов приватной коллекции
        
        public void SortStudentsByStandartDelegate(Comparison<Student> comparer) => 
            _students.Sort(comparer); // а так посортировать их без выноса 

        public void ShowStudents()
        {
            foreach (var student in _students)
            {
                Console.WriteLine(student);
            }
        }

        public void AddAvgMarks(int lowBound, int highBound, int increase)
        {
            foreach (var student in _students)
                student.AvgMarkIncreaseAction()(lowBound, highBound, increase);
        }
    }
}
