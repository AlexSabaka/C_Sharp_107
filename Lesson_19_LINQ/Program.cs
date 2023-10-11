public static class Program
{
    public static void PrintToConsole<T>(this T[] array)
    {
        Console.WriteLine($"Array contents:");
        for (int i = 0; i < array.Length; ++i)
        {
            Console.WriteLine($"Index {i + 1}: Value is '{array[i]}'");
        }
    }

    private static void Main(string[] args)
    {
        int[] array_of_numbers = new int[20];
        for (int i = 0; i < array_of_numbers.Length; ++i)
        {
            array_of_numbers[i] = Random.Shared.Next(12*20000, 12*40000);
        }
        array_of_numbers.PrintToConsole();

        // Task
        // 1. filter only even
        // 2. filter out less 50

        Console.WriteLine("Using 'classic' for approach");
        List<int> list = new();
        for (int i = 0; i < array_of_numbers.Length; ++i)
        {
            if (array_of_numbers[i] % 2 == 0 && array_of_numbers[i] > 50)
            {
                list.Add(array_of_numbers[i]);
            }
        }
        list.ToArray().PrintToConsole();

        Console.WriteLine("Using LINQ approach");
        var list_linq = array_of_numbers
            .Where(x => x % 2 == 0) 
            .Where(x => x > 50)
            .ToArray();                      // for () chained_delegate() -> new collection

        list_linq.PrintToConsole();

        var list_select = array_of_numbers
            .Select(x => x / 12)
            .ToArray();

        Console.Write("Select example: ");
        list_select.PrintToConsole();

        var list_3 = array_of_numbers
            .Select(x => x / 12)
            .Where(x => x > 35000)
            .Select(x => x / 20)
            .ToArray();

        list_3.PrintToConsole();

        // zipping
        string[] employees_names = new string[] {
            "John",
            "Jack",
            "Vasiliy",
            "Oleksii",
            "alex",
            "Yura",
            "Olena",
            "Zorian",
            "John 2",
            "Jack 2",
            "Vasiliy 2",
            "Oleksii 2",
            "alex 2",
            "Yura 2",
            "Olena 2",
            "Zorian 2",
            "alex 3",
            "Yura 3",
            "Olena 3",
            "Zorian 3"
        };

        array_of_numbers                                                // 1. вихідна колекція з вашими даними
            .Zip(employees_names)                                       // 2.1   |
            .Where(x => x.First > 12*35000)                             // .
            .Select(x => (Salary: x.First / 240, Name: x.Second))       // .
            .Select(x => new Employee(x.Name, x.Salary))                // 2.10. |- Маніпуляції з колекціями (фільтрація, трансформування, зіпування, і тд)
            .ToArray()                                                  // 3. виконання LINQ-запиту
            .PrintToConsole();

        // Contains
        // ElementAt
        // First (FirstOrDefault) / Last (LastOrDefault)
        // Single / Last (OrDefault)
        // Repeat
        // SkipWhile / TakeWhile

        // All / Any

        // Max / Min / Sum

        var dictionary = array_of_numbers
            .Zip(employees_names)
            .ToDictionary(x => x.Second, x => x.First);

        // Skip / Take / Max
        array_of_numbers
            .Zip(employees_names)
            .SkipWhile(x => x.First < 12*30000)
            .TakeWhile(x => x.First > 12*30000)
            .ToArray()
            .PrintToConsole();

        // All / Any
        bool all = array_of_numbers
            .Zip(employees_names)
            .All(x => x.First > 12*30000);

        bool any = array_of_numbers
            .Zip(employees_names)
            .Any(x => x.First > 12*30000);

        Console.WriteLine($"All: {all}, Any: {any}");
    }

    public record Employee(string Name, int MeanDailySalary);
}