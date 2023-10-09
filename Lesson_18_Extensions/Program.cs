internal static class ExtensionMethods
{
    private static void DelegateMulticasting()
    {
        Action action1 = () => Console.WriteLine("Hello, world!");
        Action action2 = () => Console.WriteLine("Goodbye!");

        Action action = action1 + action2;
        action();
    }

    private static void Main(string[] args)
    {
        List<int> list = new List<int>();
        for (int i = 0; i < 20; ++i)
        {
            list.Add(Random.Shared.Next(0, 1000));
        }

        Console.WriteLine("Even numbers:");
        List<int> evenNumbers = list.FilterEvenNumbers();
        foreach (var x in evenNumbers)
        {
            Console.WriteLine(x);
        }

        var (even, odd) = list.SplitByEvenAndOddNumbers();
        Console.WriteLine("Even numbers:");
        even.ForEach(Console.WriteLine);
        Console.WriteLine("Odd numbers:");
        odd.ForEach(Console.WriteLine);

        var chunkedArray = list.ChunkBy(3);
        foreach (var chunk in chunkedArray)
        {
            Console.Write("Chunk: ");
            foreach (int x in chunk)
            {
                Console.Write($"{x}, ");
            }
            Console.WriteLine();
        }

        // chaining
        Console.WriteLine($"Today is friday: {DateTime.Now.IsItAlreadyFriday()}, next friday gonna be at {DateTime.Now.NextFriday().ToReadableDate()}");

        Console.Write("Enter yes/no/true/false/0/1: ");
        bool result = Console.ReadLine().ToBooleanWithSwitchExpr();
        Console.WriteLine(result);
    }

    public static string ToReadableDate(this DateTime date)
        => $"{date.Day}.{date.Month}.{date.Year}";

    public static bool IsItAlreadyFriday(this DateTime date)
        => date.DayOfWeek == DayOfWeek.Friday;

    public static DateTime NextFriday(this DateTime date)
    {
        if (date.IsItAlreadyFriday())
        {
            return date.AddDays(7);
        }

        int toNextFriday = DayOfWeek.Friday - date.DayOfWeek;
        if (toNextFriday < 0)
        {
            toNextFriday += 7;
        }

        return date.AddDays(toNextFriday);
    }

    public static bool ToBoolean(this string s)
    {
        // switch operator
        switch (s.ToLower())
        {
            case "yes":
            case "true":
            case "1":
                return true;
            case "no":
            case "false":
            case "0":
                return false;
            default:
                throw new ArgumentException("Invalid value for string");
        }
    }

    public static bool ToBooleanWithSwitchExpr(this string s)
        => s.ToLower() switch {
            "yes" => true,
            "true" => true,
            "1" => true,

            "no" => false,
            "false" => false,
            "0" => false,

            _ => throw new ArgumentException("Invalid value for string"),
        };

    // jagged array
    public static T[][] ChunkBy<T>(this T[] array, int chunkSize)
    {
        T[][] result = new T[array.Length / chunkSize + 1][];
        for (int i = 0; i < array.Length; ++i)
        {
            result[i / chunkSize] = new T[chunkSize];
            result[i / chunkSize][i - chunkSize * (i / chunkSize)] = array[i];
        }
        return result;
    }

    public static IEnumerable<T[]> ChunkBy<T>(this IEnumerable<T> collection, int chunkSize)
    {
        T[] result = new T[chunkSize];
        int count = 0;
        foreach (var x in collection)
        {
            result[count++] = x;
            if (count == chunkSize)
            {
                yield return result;

                result = new T[chunkSize];
                count = 0;
            }
        }

        yield return result;
    }

    public static (List<int> even, List<int> odd) SplitByEvenAndOddNumbers(this List<int> list)
    {
        List<int> even = list.FilterEvenNumbers();
        List<int> odd = list.Except(even).ToList();

        return (even, odd);
    }

    public static List<int> FilterEvenNumbers(this List<int> list)
    {
        List<int> result = new List<int>();
        foreach (var x in list)
        {
            if (x % 2 == 0)
            {
                result.Add(x);
            }
        }
        return result;
    }
}