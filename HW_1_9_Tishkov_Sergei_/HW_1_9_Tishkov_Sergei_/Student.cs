using System;
using System.Collections.Generic;
using System.Linq;

namespace HW_1_9_Tishkov_Sergei_
{
    public class Student
    {
        private readonly List<Mark> _marks;

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime DoB { get; private set; }

        public Student(string firstName, string lastName, DateTime doB)
        {
            FirstName = firstName;
            LastName = lastName;
            DoB = doB;
            _marks = new List<Mark>();
        }

        public void AddMark(Mark mark)
        {
            _marks.Add(mark);
        }

        public void AddMarks(params Mark[] marks) // TODO исправил, раньше добавлял через foreach и внутренний единичный метод AddMark 
        {
            _marks.AddRange(marks);
        }

        public override bool Equals(object obj) => // TODO удалил if true = true else = false
            obj is Student other &&
            this.FirstName == other.FirstName &&
            this.LastName == other.LastName &&
            this.DoB == other.DoB;

        public override string ToString() => // TODO исправил на тернарник
            _marks.Count == 0 ?
            $"Student {FirstName} {LastName}, born {DoB:dd MM yyyy}" :
            $"Student {FirstName} {LastName}, born {DoB:dd MM yyyy}, with his best mark {_marks.Max().MarkNumber}, worst mark {_marks.Min().MarkNumber} and average mark {GetAverageMark}";

        public override int GetHashCode() => this.ToString().GetHashCode();

        public double GetAverageMark
        {
            get
            {
                if (_marks.Count == 0)
                {
                    return -1;
                }
                double result = 0;
                foreach (var mark in _marks)
                {
                    result += mark.MarkNumber;
                }
                return result / _marks.Count;
            }
        }
    }
}