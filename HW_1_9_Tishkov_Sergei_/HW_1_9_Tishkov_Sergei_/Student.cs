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

        // TODO Вот вам вариантик как не считать каждый раз Average при запросе значения свойства
        public void AddMark(Mark mark)
        {
            // TODO при добавлении сбрасываем среднее, я использовать nullable double 
            // но можно было устанавливать любое экстремальное значение
            // (которое точно не может получиться нормальным путём)
            // к примеру: double.NaN, double.NegativeInfinity, double.PositiveInfinity
            _averageMark = null;
            if (mark.MarkNumber < 10 && mark.MarkNumber > 0)
                _marks.Add(mark);
        }

        public void AddMarks(params Mark[] marks)
        {
            foreach (var mark in marks) // чтобы нельзя было вставить оценку больше 10 и меньше 0,  _averageMark = null производится в AddMark
                _marks.Add(mark);
        }

        public override bool Equals(object obj) =>
            obj is Student other &&
            this.FirstName == other.FirstName &&
            this.LastName == other.LastName &&
            this.DoB == other.DoB;

        public override string ToString() =>
            _marks.Count == 0
                ? $"Student {FirstName} {LastName}, born {DoB:dd MM yyyy}"
                : $"Student {FirstName} {LastName}, born {DoB:dd MM yyyy}, with his best mark {_marks.Max().MarkNumber}, worst mark {_marks.Min().MarkNumber} and average mark {GetAverageMark}";

        public override int GetHashCode() => this.ToString().GetHashCode();

        private double? _averageMark = null;

        public double GetAverageMark
        {
            get
            {
                // TODO А здесь просто проверяете что если значение адекватно
                // то можно его возвращать
                if (_marks.Count == 0) return -1;
                if (_averageMark.HasValue) return _averageMark.Value;

                double result = 0;
                foreach (var mark in _marks)
                    result += mark.MarkNumber;
                
                _averageMark = result / _marks.Count;
                return _averageMark.Value;
            }
        }
    }
}