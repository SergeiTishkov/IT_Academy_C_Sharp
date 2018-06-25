using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture14HW.Task2
{
    public class StudentAvgMarkComparer : IComparer<Student>
    {
        // TODO
        // 1. Студент может быть Null
        // 2. AvgMark является double у него уже реализован CompareTo
        public int Compare(Student x, Student y) => x?.AvgMark.CompareTo(y?.AvgMark) ?? 1;
        //=>
        //x.AvgMark > y.AvgMark ? 1 :
        //x.AvgMark < y.AvgMark ? -1 : 0;
    }
}
