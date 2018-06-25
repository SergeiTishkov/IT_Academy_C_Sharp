using System;
using System.Collections.Generic;
using System.Linq;

using VariantTwo.Event_Args;
using VariantTwo.Exceptions;
using VariantTwo.Loggers;

namespace VariantTwo
{
    public class StudentGroup
    {
        // TODO Const Все с большой буквы
        private const string _nullStudentMessage = "Student is null.";
        private const string _inproperStudentName = "Student don't have propper name.";
        // TODO Readonly
        private List<Student> _list = new List<Student>();

        public int NumberOfGroup { get; }

        public StudentGroup(int numberOfGroup) => NumberOfGroup = numberOfGroup;

        public void AddStudent(Student student)
        {
            ValidateStudent(student, "");

            AddValidatedStudent(student);
        }
        
        public void AddStudents(IEnumerable<Student> students)
        {
            // TODO possible null reference exception
            foreach (var student in students)
            {
                ValidateStudent(student, $" Transaction of adding the whole list of {students.Count()} students is over.");
            }
            foreach (var student in students) // если все студенты валидны, добавит всех, если хоть один не валиден, не добавит никого
            {
                AddValidatedStudent(student);
            }
        }

        private void AddValidatedStudent(Student student)
        {
            OnCollectionChange?.Invoke(this, new CollectionChangeResult(student.FullName, _list.Count));
            _list.Add(student);
        }

        private void ValidateStudent(Student student, string groupAddingCancelation)
        {
            if (student == null)
            {
                InvalidStudentException ex = new InvalidStudentException(_nullStudentMessage + groupAddingCancelation);
                OnInvalidInput?.Invoke(this, new InvalidStudentEventArgs(ex));
                throw ex;
            }
            if (string.IsNullOrEmpty(student.FullName))
            {
                InvalidStudentException ex = new InvalidStudentException(_inproperStudentName + groupAddingCancelation);
                OnInvalidInput?.Invoke(this, new InvalidStudentEventArgs(ex));
                throw ex;
            }
        }

        public void ShowStudentsInGroup()
        {
            if (_list.Count == 0)
            {
                Console.WriteLine("There isn't any student in the group.");
                return;
            }
            Console.WriteLine($"The group has {_list.Count} student{(_list.Count == 1 ? ":" : "s:")}");
            foreach (var student in _list)
            {
                Console.WriteLine(student);
            }
        }

        internal void SubscribeLogger(ILogger logger)
        {
            OnCollectionChange += logger.LogStudentAddition;
            OnInvalidInput += logger.LogStudentException;
        }

        internal event EventHandler<CollectionChangeResult> OnCollectionChange;

        internal event EventHandler<InvalidStudentEventArgs> OnInvalidInput;
    }
}
