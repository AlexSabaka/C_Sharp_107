namespace Lesson_13_Abstraction_And_Interfaces
{
    public interface IShapeFactory
    {
        Shape CreateCircle(float r);
        Shape CreateRectangle(float w, float h);
    }

    public class RedShapesFactory : IShapeFactory
    {
        public const string RedColorName = "Red";

        public Shape CreateCircle(float r)
        {
            return new Circle(r)
            {
                Color = RedColorName
            };
        }

        public Shape CreateRectangle(float w, float h)
        {
            return new Rectangle(w, h)
            {
                Color = RedColorName
            };
        }
    }

    public class YellowShapesFactory : IShapeFactory
    {
        public string YellowColorName
        {
            get
            {
                return "Yellow";
            }
        }

        public Shape CreateCircle(float r)
        {
            return new Circle(r)
            {
                Color = YellowColorName
            };
        }

        public Shape CreateRectangle(float w, float h)
        {
            return new Rectangle(w, h)
            {
                Color = YellowColorName
            };
        }
    }

    public class CustomColorFactoryWithDoubleSizedShapes : IShapeFactory
    {
        public CustomColorFactoryWithDoubleSizedShapes(string customColor)
        {
            CustomShapeColor = customColor;
        }

        public string CustomShapeColor { get; }

        public Shape CreateCircle(float r)
        {
            return new Circle(2 * r)
            {
                Color = CustomShapeColor
            };
        }

        public Shape CreateRectangle(float w, float h)
        {
            return new Rectangle(2 * w, 2 * h)
            {
                Color = CustomShapeColor
            };
        }
    }
}