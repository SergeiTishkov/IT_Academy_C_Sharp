using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture14HW.Task1
{
    public class Catalog : IEnumerable<Book>
    {
        public List<Book> _books { get; set; }

        public IEnumerable<Book> GetBooks(BookSorterDelegate bookSorter) => _books.Where(b => bookSorter(b));

        public IEnumerable<Book> GetBooks(BookSorterBySubstringDelegate bookSorter, string substring) => _books.Where(b => bookSorter(b, substring));

        public IEnumerable<Book> GetBooksByYear(BookSorterByYearDelegate bookSorter, int year) => _books.Where(b => bookSorter(b, year));

        public IEnumerator<Book> GetEnumerator() => _books.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _books.GetEnumerator();
    }
}
