﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture14HW.Task2
{
    public class StudentAvgMarkComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y) => x?.AvgMark.CompareTo(y?.AvgMark) ?? 1;
    }
}
