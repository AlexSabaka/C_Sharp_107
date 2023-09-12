// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

int[] numbers = new int[10]
{
    10,
    11,
    12,
    13,
    14,
    15,
    16,
    17,
    18,
    19,
};

foreach (int x in numbers)
{
    Console.Write($"{x}, ");
}
Console.WriteLine();

var index1 = new Index(1);
Console.WriteLine($"At index {index1} is element {numbers[index1]}");
Console.WriteLine($"At index {1} is element {numbers[1]}");

var index2 = new Index(1, fromEnd: true);
Console.WriteLine($"At index {index2} is element {numbers[index2]}");
Console.WriteLine($"At index {numbers.Length - 1} is element {numbers[numbers.Length - 1]}");
Console.WriteLine($"At index {-1} is element {numbers[^1]}");

var range1 = new Range(new Index(2), new Index(2, fromEnd: true));
int[] range_numbers_1 = numbers[range1];
int[] range_numbers_2 = numbers[2..^2];

foreach (int n in range_numbers_1)
{
    Console.Write($"{n}, ");
}
Console.WriteLine();

foreach (int n in range_numbers_2)
{
    Console.Write($"{n}, ");
}
Console.WriteLine();

int[] partial_copy_of_numbers = new int[numbers.Length - 4];
for (int i = 2; i < numbers.Length - 2; ++i)
    partial_copy_of_numbers[i - 2] = numbers[i];

foreach (int n in partial_copy_of_numbers)
{
    Console.Write($"{n}, ");
}
Console.WriteLine();


int[] int_numbers = new int[20];           // 4 * 20 -> 80 B
double[] double_numbers = new double[20];  // 8 * 20 -> 160 B
bool[] bools = new bool[20];
string[] strings = new string[20];

int_numbers[0] = 12;
strings[15] = "Plate is here";
strings[19] = "Bowl";

int[] int_numbers_2 = new int[20];
Console.WriteLine($"int_numbers_2.Length = {int_numbers_2.Length}");
Console.WriteLine($"int_numbers_2.GetLength(0) = {int_numbers_2.GetLength(0)}");

int[,] int_2d = new int[20, 30];
Console.WriteLine($"int_2d.Length = {int_2d.Length}");
Console.WriteLine($"int_2d.GetLength(0) = {int_2d.GetLength(0)}");
Console.WriteLine($"int_2d.GetLength(1) = {int_2d.GetLength(1)}");

string text = "Hello there!"; 

// text[0] --> 'H'
char first_letter = text[0];
Console.WriteLine($"First letter in \"{text}\" is {first_letter}");
char character = '0';

foreach (char c in text)
{
    Console.Write(c);
}

Console.WriteLine("for-loop");
for (int i = 0; i < strings.Length; ++i)
{
    Console.WriteLine($"{i}: {strings[i]}");
}

Console.WriteLine("foreach-loop");
foreach (string place in strings)
{
    Console.WriteLine(place);
}

Console.WriteLine("foreach-loop underhood");
var e = strings.GetEnumerator();
while (e.MoveNext())
{
    string place = (string)e.Current;
    Console.WriteLine(place);
}
