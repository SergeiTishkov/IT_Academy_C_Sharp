using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lecture14HW.Task1;
using Lecture14HW.Task2;
using Lecture14HW.Task3;

namespace Lecture14HW
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskOne();
            TaskTwo();
            TaskThree();
        }

        static void TaskOne() 
        {
            // Задача 1 Делегаты и методы
            /*
             1. Объявить делегат для работы с выборками.
             2. Создать метод, в классе каталог, позволяющий делать выборки из каталога.
             3. Создать класс BookSorter и объявить в нём методы необходимые для 
                выполнения задач по сортировке книг
             3. Вывести в консоль книги написанные до 85ого года. Передав статический метод и BookSorter-a
             4. Вывести книги написаны в названии которых есть слово "мир"
             */
            
            var catalog = new Catalog();
            catalog._books = new List<Book>()
            {
                new Book("War and Peace", 1869),
                new Book("Pride and Prejudice", 1813),
                new Book("Pro C# 7. With .NET and .NET Core", 2017)
            };

            Console.WriteLine("Books with \"Peace\" in title:");
            BookSorter.PrintSortedBooks(catalog, BookSorter.IfBookHasSubstringInTitle, "Peace");

            Console.WriteLine("Books written before 1985:");
            BookSorter.PrintSortedBooks(catalog, BookSorter.WasBookWrittenBeforeSomeYear, 1985);
        }

        static void TaskTwo()
        {
            // Задача 2 Делегаты и анонимные методы и/или лямбда выражения
            /* 
             1. Объявить делегаты для работы со студентами
             2. Создать метод, в классе группа, позволяющий сортировать студентов.
             3. Создать метод, в классе группа, предоставляющий возможность выполнить действие
                с приватной коллекцией студентов.
             4. Используя метод из пункта 2, отсортировать студентов по средней оценке
             5. Используя метод из пункта 3, всем студентам с оценкой от 4 до 6 добавить 1 балл.
             */
            var group = new Group();
            group.AddRangeOfRandomStudents(10);

            group.ShowStudents();
            group.SortStudents()(Group.AvgMarkComparerAscending);
            //group.SortStudentsByStandartDelegate( (x, y) => x.AvgMark > y.AvgMark ? 1 : x.AvgMark < y.AvgMark ? -1 : 0 ); // или так, не вынося делегат наружу

            Console.WriteLine();
            group.ShowStudents();

            group.AddAvgMarks(4, 6, 1);
            Console.WriteLine();
            group.ShowStudents();
        }

        static void TaskThree()
        {
            // Задача 3* Func, Action + =>
            // В задаче нельзя объявлять делегаты
            /*
             1. Создать методы расширения для класса CarPark:
                а. Производит выборку из внутренней коллекции используя передаваемую функцию
                б. Производит сортировку внутренней коллекции используя передаваемую функцию
             2. Создать внутреннее свойство в классе CarPark для хранение действия.
             3. Вызывать это действие при добавлении новой машины в парк:
                 => Как вариант выводить в консоль информацию о машине 
                 Console: Toyota RAV4 was added to the park. It costs ... $. 
             */
            var group = new CarPark(message => Console.WriteLine(message));
            group.AddCars(new ElectroCar("Tesla", "S", 2009, 85, 70000), new ElectroCar("Tesla", "X", 2012, 75, 100000), new ElectroCar("Tesla", "3", 2016, 100, 49000),
                new FuelCar("Porsche", "Panamera", 2009, 80, 80000), new FuelCar("Mersedes", "Gelentwagen", 2018, 120, 115000), new FuelCar("Ford", "Focus", 1991, 100, 16000));

            Console.WriteLine("\n\n**** FIRST LOOK ON OUR CAR PARK ****\n\n");
            group.ShowCars();

            group.SortCars((a, b) => a.Price.CompareTo(b.Price));
            Console.WriteLine("\n\n**** SECOND LOOK ON OUR CAR PARK AFTER SORTING ****\n\n");
            group.ShowCars();

            Console.WriteLine("\n\n**** LET'S TAKE A LOOK ON THE TESLAS ****\n\n");
            foreach (var car in group.GetCars(c => c.Brand == "Tesla"))
            {
                Console.WriteLine(car);
            }

        }
    }
}
