using System;

namespace VariantTwo.Exceptions
{
    public class InvalidStudentException : Exception
    {
        public InvalidStudentException() { }

        public InvalidStudentException(string message) : base(message) { }

        public InvalidStudentException(string message, Exception innerException) : base(message, innerException) { }
    }
}
