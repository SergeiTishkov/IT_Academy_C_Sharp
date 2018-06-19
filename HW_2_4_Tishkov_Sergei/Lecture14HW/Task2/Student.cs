﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lecture14HW.Helpers;

namespace Lecture14HW.Task2
{
    public class Student 
    {
        public Student()
        {
            FirstName = Rnd.RandomFirstName;
            LastName = Rnd.RandomLastName;
            AvgMark = Rnd.RandomMark;
        }

        public Student(int avgMark, string lastName, string firstName)
        {
            AvgMark = avgMark;
            LastName = lastName;
            FirstName = firstName;
        }

        public double AvgMark { get; private set; }

        public string LastName { get; }

        public string FirstName { get; }

        public StudentIncreaseAvgMarkDelegate AvgMarkIncrease() => new StudentIncreaseAvgMarkDelegate
            ( (lowBound, highBound, increase) => { if (AvgMark <= highBound && AvgMark >= lowBound) AvgMark += increase; } );

        public override string ToString() => $"Student {FirstName} {LastName} with average mark {AvgMark:0.##}";
    }
}