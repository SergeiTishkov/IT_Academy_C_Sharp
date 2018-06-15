using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture14HW.Task2
{
    public delegate void StudentAvgMarkComparerDelegate(IComparer<Student> comparer);
    public delegate void StudentIncreaseAvgMarkDelegate(int low, int high, int increase);
}
