using System;
using System.Runtime.CompilerServices;

internal class Program
{
    private static void ActionsExample()
    {
        //type name = value
        Action action = () =>
            {
                Console.WriteLine("Hello from action!");
            };
        Action action2 =
            delegate ()
            {
                Console.WriteLine("Hello from other action.");
            };
        Action<int> actionWithArg = x => Console.WriteLine($"I'm a number passed to the action {x}");
        var actionWith3args =
            (string x, string y, string z) =>
            {
                Console.WriteLine($"{x} {y} {z}");
            };


        Console.WriteLine("Hi there!");

        action.Invoke();

        action2();

        actionWithArg(120);
        actionWithArg(1);
        actionWith3args("Hello", "from", "yet another action");

    }

    private static void WhenItemAddedToStack(object s, int item)
    {
        Stack<int> stack = s as Stack<int>;
        Console.WriteLine($"Item {item} added to the stack");
        stack.Pop();
    }

    public static void WhenItemRemovedFromStack(object s, int item)
    {
        Console.WriteLine($"Item {item} removed to the stack");
    }

    // GUI WinForms

    private static T FindInArray<T>(T[] array, Predicate<T> predicate)
    {
        foreach (var item in array)
        {
            if (predicate(item))
            {
                return item;
            }
        }

        return default;
    }

    private static void PredicateExamples()
    {
        int[] array = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        Predicate<int> check_for_5 =
            (int x) =>
            {
                return x == 5;
            };
        Predicate<int> check_for_even = x => x % 2 == 0;
        int found_5 = Array.Find(array, check_for_5);
        int found_even = Array.Find(array, check_for_even);

        int found_5_with_my_method = FindInArray(array, check_for_5);
        int found_even_with_my_method = FindInArray(array, check_for_even);

        Console.WriteLine($"With regular find {found_5} and with my method {found_5_with_my_method}");
        Console.WriteLine($"With regular find {found_even} and with my method {found_even_with_my_method}");
    }


    private static void ProcessArrayWithSomeFunc(int[] array, Func<int, int> func)
    {
        for (int i = 0; i < array.Length; ++i)
        {
            array[i] = func(array[i]);
        }
    }

    private static void FuncExamples()
    {
        int[] array = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        var array_twice_the_size = array.Select(x => x.ToString("X2"));

        foreach (var item in array_twice_the_size)
        {
            Console.WriteLine(item);
        }
    }

    private static void ClosureExamples()
    {
        Action action = null;
        for (int i = 0; i < 10; ++i)
        {
            Console.Write(i);
            action = () => Console.WriteLine(i); // closure – замикання
        }
        // i == 10
        action();

        List<Action> actions = new List<Action>();
        for (int i = 0; i < 10; ++i)
        {
            int j = i;
            actions.Add(() => Console.WriteLine(j));
        }

        foreach (var x in actions)
        {
            x();
        }
    }

    private static Func<int, int> GetFunc()
    {
        int my_var = 1;
        Func<int, int> increment =
            (int x) =>
            {
                my_var++;
                return x + my_var;
            };
        return increment;
    }

    public delegate int ProcessInteger(int value);

    private static void OnIncrement(int val)
    {
        Console.WriteLine($"On increment: {val}");
    }

    private static void OnDecrement(int val)
    {
        Console.WriteLine($"On decrement: {val}");
    }

    private static void Main(string[] args)
    {
        // Func
        // Action
        // Predicate
        // EventHandler
        Action<int> onIncLocal =
            (int val) =>
            {
                Console.WriteLine($"On increment: {val}");
            };
        Action<int> onDecLocal =
            (int val) =>
            {
                Console.WriteLine($"On decrement: {val}");
            };

        // wrapper
        Counter.Callback callbackIncLocal = 
            (int val) =>
            {
                onIncLocal(val);
            };
        Counter.Callback callbackDecLocal = 
            (int val) =>
            {
                Console.WriteLine($"On increment: {val}");
            };

        Counter counter = new Counter(callbackIncLocal, callbackDecLocal);
        counter.Inc();
        counter.Dec();
    }

    public class Counter
    {
        public delegate void Callback(int value);
        public delegate void CallbackWithRefArg(ref int value);

        private int _counts = 0;

        private readonly Callback _onIncrement;
        private readonly Callback _onDecrement;

        public Counter(Callback onIncrement, Callback onDecrement) // callback functions
        {
            _onIncrement = onIncrement;
            _onDecrement = onDecrement;
        }

        public void Inc()
        {
            _counts++;
            _onIncrement(_counts);
        }
        
        public void Dec()
        {
            _counts--;
            _onDecrement(_counts);
        }
    }
}