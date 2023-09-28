namespace Lesson_13_Abstraction_And_Interfaces
{
    public class Rectangle : Shape
    {
        public Rectangle(float width, float heiht)
            : base(nameof(Rectangle))
        {
            Width = width;
            Height = heiht;
        }

        public float Width { get; }
        public float Height { get; }

        public override float GetArea()
            => Width * Height;

        public override float GetPerimeter()
            => 2 * (Width + Height);
    }
}