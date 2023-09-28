namespace Lesson_13_Abstraction_And_Interfaces
{
    public abstract class Shape
    {
        public Shape(string name)
        {
            Name = name;
        }

        public Shape(string name, string color)
            : this(name)
        {
            Color = color;
        }

        public abstract float GetArea();

        public abstract float GetPerimeter();

        public string Name { get; }

        public string Color { get; set; }

        public override string ToString()
            => $"{Name} of color {Color}, Area={GetArea()}, Perimeter={GetPerimeter()}";
    }
}