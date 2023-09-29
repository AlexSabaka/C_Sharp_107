using System.Collections;

namespace Lesson_14_Structs
{
    public struct Vector2
    {
        public float X;
        public float Y;

        public float Length
        {
            get
            {
                return MathF.Sqrt(X * X + Y * Y);
            }
        }

        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public Vector2 Normalize()
        {
            return this / Length;
        }


        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 1: return X;
                    case 2: return Y;
                    default: throw new InvalidOperationException("Only 1 or 2 are allowed as a dimension index.");
                }
            }
        }


        // addition
        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            Console.WriteLine("I'm a PLUS operator");
            return new Vector2();
        }

        // ???
        public static Vector2 operator +(Vector2 v1)
        {
            return v1;
        }

        // substraction
        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X - v2.X, v1.Y - v2.Y);
        }

        // negation
        public static Vector2 operator -(Vector2 v1)
        {
            return new Vector2(-v1.X, -v1.Y);
        }


        // division
        public static Vector2 operator /(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X / v2.X, v1.Y / v2.Y);
        }

        public static Vector2 operator /(Vector2 v1, float v2)
        {
            return new Vector2(v1.X / v2, v1.Y / v2);
        }

        // multiplication
        public static Vector2 operator *(Vector2 v1, float v2)
        {
            return new Vector2(v1.X * v2, v1.Y * v2);
        }
        public static Vector2 operator *(float v2, Vector2 v1)
        {
            return new Vector2(v1.X * v2, v1.Y * v2);
        }

        // dot-product
        public static float operator *(Vector2 v1, Vector2 v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y;
        }
    }

    public record Student(string Name, string Course, int Age);


    public class Student_Class
    {
        public string Name { get; init;  }
        public string Course { get; init; }
        public int Age { get; init; }
    }

    internal class Program
    {
        static void Records_RecordClass()
        {
            Student_Class s1 = new Student_Class { Name = "Oleksii", Course = "C#", Age = 29 };
            Student_Class s2 = new Student_Class { Name = "Oleksii", Course = "C#", Age = 29 };
            Console.WriteLine(s1 == s2); // False -- reference equality

            Student s3 = new Student("Oleksii", "C#", 29);
            Student s4 = new Student("Oleksii", "C#", 29);
            Console.WriteLine(s3 == s4); // True -- value equality
        }

        static void Main(string[] args)
        {
            Vector2 v1 = new Vector2(10, 20);
            Vector2 v2 = new Vector2(20, 10);
            Vector2 v3 = v1 + v2;
            Vector2 v4 = v1 - v2;
            Vector2 v5 = -v2;
            Vector2 v6 = +v2;
            Vector2 v7 = v1 / v2;
            Vector2 v8 = v1.Normalize();
            Vector2 v9 = v1 * 10;
            Vector2 v10 = 10 * v1;
            float v11 = v1 * v2;
            float x1 = v1.X;
            float x2 = v1[1];
            float y1 = v1.Y;
            float y2 = v1[2];

            float y3 = y1 + y2;

            DateTime d1 = DateTime.Now;
            bool b = d1 > new DateTime(1, 1, 1);
            DateTime d3 = d1 + new TimeSpan(1, 1, 0);

            for (int i = 1; i < 3; ++i)
            {
                Console.WriteLine(v1[i]);
                Console.WriteLine(v2[i]);
                Console.WriteLine(v3[i]);
            }

            //int j = 1234; // struct --> value type --> stack (4 bytes)
            //object obj = j; // boxing --> [value type] -> HEAP --> reference

            object[] array = new object[]
            {
                1234,               // <-- value type
                12.3124,            // <-- value type
                "asadsaf",          // <-- reference type
                false,              // <-- value type
                null,               // <-- null
                DateTime.Now,       // <-- value type
                new Random(),       // <-- refernce type
                new Vector2(1, 2),  // <-- value type
            };

            foreach (var obj in array)
            {
                PrintAnythingToConsoleWithMessage("My number is", obj); // <--- boxing
            }
        }

        static void PrintAnythingToConsoleWithMessage(string message, object anything)
        {
            Console.WriteLine(message);
            Console.WriteLine(anything);
        }
    }
}