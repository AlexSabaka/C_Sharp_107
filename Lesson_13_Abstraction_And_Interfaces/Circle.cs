namespace Lesson_13_Abstraction_And_Interfaces
{
    public class Circle : Shape
    {
        public Circle(float radius)
            : base(nameof(Circle))
        {
            Radius = radius;
        }

        public float Radius { get; set; }

        public override float GetArea()
            => MathF.PI * Radius * Radius;


        public override float GetPerimeter()
            => 2 * MathF.PI * Radius;

        public override string ToString()
        {
            return base.ToString() + $" Radius={Radius}";
        }
    }
}