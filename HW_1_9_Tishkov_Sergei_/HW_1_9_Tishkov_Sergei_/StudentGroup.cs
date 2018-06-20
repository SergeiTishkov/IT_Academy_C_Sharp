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
        // TODO Правило хорошего тона:
        // если не планируете переписывать ссылку в вашем поле - делаете его readonly
        // SonarCube: https://rules.sonarsource.com/csharp/RSPEC-2933
        // Прироста производительности не будет, но на StackOverflow можете поискать
        // статьи по поводу чем же всё таки лучше использовать Immutable поля.
        // Если память мне не изменяет, то это было связано с рефлексией и много поточностью
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
            // TODO Удаляйте ненужный код
            // а почему он не нужный? Ведь можно в листе по индексу поставить новое значение.
            // TODO Потому что если другой программист видит у вас закоментированный кусок,
            // он считает что вы просто забыли его удалить
            // Code Smells
            /*
               MISRA C:2012, Dir. 4.4 - Sections of code should not be "commented out"
             */
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