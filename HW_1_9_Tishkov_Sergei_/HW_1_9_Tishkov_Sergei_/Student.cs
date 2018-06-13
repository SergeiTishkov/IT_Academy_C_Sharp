using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_1_9_Tishkov_Sergei_
{
    public class Student
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime DoB { get; private set; }
        private List<Mark> _marks = new List<Mark>();

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

        public void AddMarks(params Mark[] marks)
        {
            foreach (var mark in marks)
            {
                AddMark(mark);
            }
        }

        public override bool Equals(object obj) =>
            (obj is Student other &&
            this.FirstName == other.FirstName &&
            this.LastName == other.LastName &&
            this.DoB == other.DoB) ? true : false;

        public override string ToString()
        {
            if (_marks?.Count == 0)
                return $"Student {FirstName} {LastName}, born {DoB:dd MM yyyy}";
            else
                return $"Student {FirstName} {LastName}, born {DoB:dd MM yyyy}, with his best mark {_marks.Max().MarkNumber}, worst mark {_marks.Min().MarkNumber} and average mark {GetAverageMark}";
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public double GetAverageMark
        {
            get
            {
                if (_marks?.Count == 0)
                {
                    return 0;
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