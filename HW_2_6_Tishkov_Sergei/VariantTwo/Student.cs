namespace VariantTwo
{
    public class Student
    {
        public string FullName { get; }

        public Student(string fullName) => FullName = fullName;

        public override string ToString() => $"Student {FullName}.";
    }
}
