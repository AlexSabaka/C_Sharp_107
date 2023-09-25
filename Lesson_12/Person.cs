namespace Lesson_11_Classes_And_OOP
{
    record Person(string FirstName, string LastName, string Phone, DateTime BirthDate)
    {
        public string FullName => $"{FirstName} {LastName}"; // CamelCase

        public Lesson_12_Inheritance_And_Polymorphism.Shape[] Shapes { get; }

        public override string ToString() => $"{FullName}, {Phone}, {BirthDate:dd.mm.yyyy}";
    }
}