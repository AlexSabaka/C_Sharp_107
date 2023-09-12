
for (int i = 0; i <= 10; )
{
    Console.WriteLine(i++);
}

Console.WriteLine();

for (int i = 0; i <= 10; )
{
    if (!(i == 3))
        break;
    Console.WriteLine(++i);
}

Console.WriteLine("Goodbye!");
Console.ReadKey();