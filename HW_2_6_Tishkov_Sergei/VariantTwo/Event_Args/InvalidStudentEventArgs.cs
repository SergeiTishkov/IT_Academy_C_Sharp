using System;

using VariantTwo.Exceptions;

namespace VariantTwo.Event_Args
{
    public class InvalidStudentEventArgs : EventArgs
    {
        public InvalidStudentException StudentException { get; }

        public InvalidStudentEventArgs(InvalidStudentException studentException) => StudentException = studentException;
    }
}
