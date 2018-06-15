using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture14HW.Task1
{
    public static class BookSorter
    {
        public static bool WasBookWrittenBeforeSomeYear(Book book, int year) => book.YearOfWriting < year;

        public static bool IfBookHasSubstringInTitle(Book book, string substring) => book.Title.Contains(substring);

        public static void PrintSortedBooks(Catalog catalog, BookSorterDelegate bookSorter)
        {
            foreach (var book in catalog.GetBooks(bookSorter))
                Console.WriteLine(book);
        }

        public static void PrintSortedBooks(Catalog catalog, BookSorterBySubstringDelegate bookSorter, string substring)
        {
            foreach (var book in catalog.GetBooks(bookSorter, substring))
                Console.WriteLine(book);
        }

        public static void PrintSortedBooks(Catalog catalog, BookSorterByYearDelegate bookSorter, int year)
        {
            foreach (var book in catalog.GetBooksByYear(bookSorter, year))
                Console.WriteLine(book);
        }
    }
}
