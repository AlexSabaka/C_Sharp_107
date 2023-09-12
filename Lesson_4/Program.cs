// See https://aka.ms/new-console-template for more information

using LessonFour;

// 3! = 1 * 2 * 3 = 6
// 5! = 1 * 2 * 3 * 4 * 5 = 120

// N! = 1 * 2 * ... * (N - 1) * N
// N! = (N - 1)! * N

int factorial_for(int n)
{
    int result = 1;
    for (int i = 1; i <= n; i++)
    {
        result *= i;
    }
    return result;
}

int factorial_recursive(int n) => n == 1 ? 1 : factorial_recursive(n - 1) * n;

// f(x) = sin(x) * x^2
double HereIsTheNameOfTheFunction(double hereIsAnArgument)
    => Math.Sin(hereIsAnArgument) * Math.Pow(hereIsAnArgument, 2);

double FunctionWithCurlyBrackets(double x)
{
    return Math.Sin(x) * Math.Pow(x, 2);
}

Console.WriteLine($"5! = {factorial_for(5)}");
Console.WriteLine($"5! = {factorial_recursive(5)}");

void Calculator_NotGood()
{
    Console.Write("Enter 1st number: ");
    double num1 = double.Parse(Console.ReadLine());

    Console.Write("Enter 2nd number: ");
    double num2 = double.Parse(Console.ReadLine());

    Console.Write("Enter operation (+, -, *, /): ");
    string op = Console.ReadLine();

    switch (op)
    {
        case "+":
            Console.WriteLine(num1 + num2);
            break;
        case "-":
            Console.WriteLine(num1 - num2);
            break;
        case "*":
            Console.WriteLine(num1 * num2);
            break;
        case "/":
            Console.WriteLine(num1 / num2);
            break;
        default:
            Console.WriteLine("Unknown operation:(");
            break;
    }
}

void TaskOne()
{
    Console.Write("Enter 1st number: ");
    double num1 = double.Parse(Console.ReadLine());

    Console.Write("Enter 2nd number: ");
    double num2 = double.Parse(Console.ReadLine());
}

// num1 = 1, num2 = 5
// 1 + 2 + 3 + 4 + ... + 5
// 1 - 2 - 3 - 4 - .... - 5
// 1 * 2 * ...
// 1 / 2 / 3 / ...
// 1 + 2 -> 3
//   3   + 3 + 4 + 5 -> 6 + 4 + 5 -> 10 + 5 -> 15
void TaskTwo()
{
    Console.Write("Enter min number: ");
    double min = double.Parse(Console.ReadLine());

    Console.Write("Enter max number: ");
    double max = double.Parse(Console.ReadLine());

    Console.Write("Enter operation (+, -, *, /): ");
    string op = Console.ReadLine();

    double resutl = Calculator.PerformAction(min, min + 1, op);
    for (double i = min + 2; i <= max; ++i)
    {
        resutl = Calculator.PerformAction(resutl, i, op);
    }

    Console.WriteLine($"Result is {resutl}");
}


void Calculator_UnitTest()
{
    int result1 = Calculator.PerformAction(1, 2, "+");
    if (result1 != 3)
    {
        Console.WriteLine("Alarm!!! Method is wrong +");
    }

    int result2 = Calculator.PerformAction(1, 2, "-");
    if (result2 != -1)
    {
        Console.WriteLine("Alarm!!! Method is wrong -");
    }

    int result3 = Calculator.PerformAction(1, 2, "*");
    if (result3 != 2)
    {
        Console.WriteLine("Alarm!!! Method is wrong *");
    }

    int result4 = Calculator.PerformAction(1, 2, "/");
    if (result4 != 0)
    {
        Console.WriteLine("Alarm!!! Method is wrong /");
    }

    int result5 = Calculator.PerformAction(3, 2, "%");
    if (result5 != 1)
    {
        Console.WriteLine("Alarm!!! Method is wrong %");
    }
}

string name = Console.ReadLine();
Calculator.PerformAction(13, 24, "+");
