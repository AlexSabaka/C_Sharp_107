public static class Program
{
    private static int SomePrivateField = 123;

    public static void Main(string[] args)
    {
        Program2.SomeMethodWithReflection();
    }

    private static void RunCalcWithArgs(string[] args)
    {
        // 1. number
        // 2. operation (+,-,*,/)
        // 3. number
        if (args.Length != 3)
        {
            Console.WriteLine("Usage help: ");
            Console.WriteLine("dotnet run [number] [operation] [number]");
            return;
        }

        if (!float.TryParse(args[0], out var num1) || !float.TryParse(args[2], out var num2))
        {
            Console.WriteLine("Either first or third argument isn't a number. Try again.");
            return;
        }

        Console.WriteLine($"Result: {Calculator(num1, num2, args[1])}");
    }

    private static float Calculator(float num1, float num2, string operation)
        => operation switch
        {
            "+" => num1 + num2,
            "-" => num1 - num2,
            "/" => num1 / num2,
            "*" => num1 * num2,
            "^" => MathF.Pow(num1, num2),
            _ => float.NaN,         // IEEE 754, -Inf, +Inf, NaN
        };
}

public static class Program2
{
    public static void SomeMethodWithReflection()
    {
        Type type = typeof(Program);
        var method = type.GetMethod("Calculator", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
        var parameters = method.GetParameters();
        var somePrivateField = type.GetField("SomePrivateField", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
        var someValue = somePrivateField.GetValue(null);

        var obj = new SomeObject(1234);
        var fieldInfo = obj.GetType().GetField("SomeInstanceField", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        var fieldVal = fieldInfo.GetValue(obj);

        var attrs = fieldInfo.GetCustomAttributes(false);
        var concreteAttrs = fieldInfo.GetCustomAttributes(typeof(FieldDescriptionAttribute) , false);

        var ctor = obj.GetType().GetConstructor(new Type[] { typeof(int) });
        var instance1 = ctor.Invoke(new object[] { 123 });

        var ctors = obj.GetType().GetConstructors();

        var instance2 = Activator.CreateInstance(typeof(SomeObject), new object[] { 1234 });


        IImportantInterface value1 = new ImportantClass();
        IImportantInterface value2 = new NotSoImportantClass();

        var interfaceType = typeof(IImportantInterface);
        var importantClassType = value1.GetType(); 
        var notImportantClassType = value2.GetType(); 

        Console.WriteLine($"Iterface = Important Class: {interfaceType.IsAssignableFrom(importantClassType)}");
        Console.WriteLine($"Iterface = Class: {interfaceType.IsAssignableFrom(notImportantClassType)}");

        Console.WriteLine($"Important Class = Iterface: {importantClassType.IsAssignableFrom(interfaceType)}");
        Console.WriteLine($"Class = Iterface: {notImportantClassType.IsAssignableFrom(interfaceType)}");

        Console.WriteLine($"Class = Important Class: {notImportantClassType.IsAssignableFrom(importantClassType)}");
        Console.WriteLine($"Important Class = Class: {importantClassType.IsAssignableFrom(notImportantClassType)}");
    }
}

public interface IImportantInterface
{
    void ImportantMethod();
}

public class ImportantClass : IImportantInterface
{
    public void ImportantMethod()
    {
        Console.WriteLine("Important method in the important class");
    }
}

public class NotSoImportantClass : IImportantInterface
{
    public void ImportantMethod()
    {
        Console.WriteLine("No so important method in the not so important class");
    }
}


public class SomeObject
{
    [FieldDefaultValue(10)]
    [FieldDescription("Some very important value")]
    private int SomeInstanceField;

    public SomeObject(int val)
    {
        SomeInstanceField = val;
    }
}

[AttributeUsage(AttributeTargets.Field)]
public class FieldDescriptionAttribute : Attribute
{
    public string Description { get; }

    public FieldDescriptionAttribute(string description)
    {
        Description = description;
    }
}

[AttributeUsage(AttributeTargets.Field)]
public class FieldDefaultValueAttribute : Attribute
{
    public object Value { get; }

    public FieldDefaultValueAttribute(object value)
    {
        Value = value;
    }
}