using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture14HW.Task1
{
    public delegate bool BookSorterDelegate(Book book);
    public delegate bool BookSorterBySubstringDelegate(Book books, string substring);
    public delegate bool BookSorterByYearDelegate(Book books, int year);
}
