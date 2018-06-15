using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_1_9_Tishkov_Sergei_
{
    public class StudentGroup : IEnumerable<Student>
    {
        private List<Student> _studentList = new List<Student>();

        public Student this[int index]
        {
            get
            {
                if (index <= _studentList.Count && index >= 0)
                    return _studentList[index];
                else
                {
                    Console.WriteLine("Индекс вне границ списка!");
                    return null;
                }
            }
            // TODO Удаляйте ненужный код // а почему он не нужный? Ведь можно в листе по индексу поставить новое значение.
            //set
            //{
            //    if (index < _studentList.Count) 
            //        _studentList[index] = value;
            //    else
            //    {
            //        Console.WriteLine("Индекс вне границ списка!");
            //    }
            //}
        }

        public void AddStudent(Student student)
        {
            _studentList.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            if (_studentList.Contains(student))
                _studentList.Remove(student);
            else
                Console.WriteLine("Студент не является членом этой группы");
        }

        public IEnumerator<Student> GetEnumerator() => _studentList.GetEnumerator();

         IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
