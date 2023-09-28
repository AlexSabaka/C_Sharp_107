namespace Lesson_13_Abstraction_And_Interfaces
{
    // HOMEWORK:
    // Implement design patterns
    // 1. Singletone (Anti-pattern) -- https://dofactory.com/net/singleton-design-pattern
    // 2. Decorator -- https://dofactory.com/net/decorator-design-pattern
    // 3. Abstract Factory -- https://dofactory.com/net/abstract-factory-design-pattern
    //    3.1. Fabric Method 
    // 4. Strategy -- https://www.dofactory.com/net/strategy-design-pattern

    internal class Program
    {
        static bool MethodOne()
        {
            Console.WriteLine(nameof(MethodOne));
            return false;
        }

        static bool MethodTwo()
        {
            Console.WriteLine(nameof(MethodTwo));
            return true;
        }

        static void TaskOne()
        {
            //  false       && ___________    ---> false
            if (MethodOne() && MethodTwo())
            {
                Console.WriteLine("And");
            }

            //  true        || ___________    ---> true
            if (MethodOne() || MethodTwo())
            {
                Console.WriteLine("Or");
            }

            // Or (x 2)

            // MethodOne
            // MethodTwo
            // MethodOne
            // MethodTwo
            // Or
        }

        static void Main(string[] args)
        {
            IShapeFactory[] factories = new IShapeFactory[]
            {
                new RedShapesFactory(),
                new YellowShapesFactory(),
                new CustomColorFactoryWithDoubleSizedShapes("Brown"),
            };

            Shape[] shapes = new Shape[10];
            for (int i = 0; i < 10; ++i)
            {
                var random_factory = factories[Random.Shared.Next(factories.Length)];
                if (Random.Shared.NextDouble() > 0.5)
                {
                    shapes[i] = random_factory.CreateCircle(i);
                }
                else
                {
                    shapes[i] = random_factory.CreateRectangle(i, 2 * i);
                }
            }

            foreach (Shape shape in shapes)
            {
                Console.WriteLine(shape);
            }
        }


        // Unary Operator
        // -, +, ++, --, !, ~
        // -x, +x, ++x, x++, --x, x--
        // !true == false, !false == true

        // Binary (two operands) -- int, short, long, byte, sbyte, ulong, ushort, uint
        //                          float, double, decimal
        // +, -, *, /, % 

        // Boolean Operators -- bool
        // ||, &&, >, <, >=, <=, !

        // Equality Operators
        // !=, ==

        // |, &, ^, >>, <<, ~
        // ~x -- bitwise (binary) operator not -- int, short, long, byte, sbyte, ulong, ushort, uint
        // x = 0b01010110, ~x = ~0b01010110 --> 0b10101001
        // x = 0, ~x = ~0 --> 1
        // x = 1, ~x = ~1 --> 0
        // x|y --> 0|0 --> 0
        //         0|1 --> 1
        //         1|0 --> 1
        //         1|1 --> 1
        // x&y --> 0&0 --> 0
        //         0&1 --> 0
        //         1&0 --> 0
        //         1&1 --> 1
        // x^y --> xor --> eXclusive OR
        // x|y --> 0|0 --> 0
        //         0|1 --> 1
        //         1|0 --> 1
        //         1|1 --> 0
        // x>>y --> RSH --> Right Shift
        // (4 dec) 100>>2 --> 001 (1 dec)
        // x<<y LSH --> Left Shift
        // (4 dec) 100<<2 --> 10000 (16 dec)
    }
}