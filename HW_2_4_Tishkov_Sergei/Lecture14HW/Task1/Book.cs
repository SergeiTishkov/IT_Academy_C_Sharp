using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture14HW.Task1
{
    public class Book
    {
        public string Title { get; }
        public int YearOfWriting { get; }

        public Book(string title, int yearOfWriting)
        {
            Title = title;
            YearOfWriting = yearOfWriting;
        }

        public override string ToString() => $"Book \"{Title}\" was written in {YearOfWriting} year.";
    }
}
