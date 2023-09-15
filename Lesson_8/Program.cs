// See https://aka.ms/new-console-template for more information

using System.Text;

var text = "Hello, World!\n";
foreach (var currentCharacterInText in text)
{
    Console.Write($"{currentCharacterInText}, ");
}
Console.WriteLine();

for (var i = 0; i < text.Length; i++)
{
    Console.Write($"{text[i]}, ");
}
Console.WriteLine();

string text_2 = text + " Hi there!";
//string text_3 = "2" * 2; // -> 2222222222
string text_3 = new string('2', 10);
Console.WriteLine(text_3);

//string text_4 = "";
//for (int i = 0; i < 100000; ++i)
//{
//    text_4 += "Hello, world!";
//}
//Console.WriteLine(text_4);

//StringBuilder builder = new StringBuilder();
//for (int i = 0; i < 100000; ++i)
//{
//    builder.Append(text);
//}
//Console.WriteLine();

Console.WriteLine("----------------------------------------");
Console.WriteLine();

StringBuilder builder = new StringBuilder();
builder.Append("Hello");
builder.AppendLine();
builder.AppendLine("world");
builder.Append('!', 10);
int x = 10;
for (int i = 0; i < 1000000; ++i)
    builder.AppendLine($"This text is interpolated with variable {x}");

int a = 11, b = 12, c = 13;
int d = 90;

for (int i = 0; i < 1000000; ++i)
    builder.AppendFormat("This text is formatted with variable {0}, {1}, {2}, {3}\n", d, a, b, c);



StringBuilder sb = new StringBuilder();
for (int i = 0; i < 10; ++i)
{
    sb.Append(x++);
    sb.AppendLine();
}

x = 10;
for (int i = 0; i < 10; ++i)
{
    sb.Append(++x);
    sb.AppendLine();
}

sb.Insert(0, "hello!!\n");
sb.Insert(50, "world!!\n");

sb.Replace('1', '2');
sb.Replace("hello", "How are you?\n\n\n");


Console.WriteLine();

Console.WriteLine(text);
Console.WriteLine(text.ToLower());
Console.WriteLine(text.ToUpper());

Console.WriteLine(text.Replace('l', '1'));
Console.WriteLine(text.Replace("ll", "LL"));

string text_with_spaces = "    long text very long text      ";
Console.WriteLine(text_with_spaces);
Console.WriteLine(text_with_spaces.Trim());
Console.WriteLine(text_with_spaces.TrimEnd());
Console.WriteLine(text_with_spaces.TrimStart());

string long_text = "  here is a. %%   very long text,   example ! that  talks about  nothing  ";
Console.WriteLine(long_text);
Console.WriteLine(long_text.PadLeft(100));
Console.WriteLine(long_text.PadRight(100) + "end");

Console.WriteLine(long_text.IndexOf('i'));
Console.WriteLine(long_text.IndexOf("long"));

Console.WriteLine(long_text.StartsWith("here"));
Console.WriteLine(long_text.StartsWith("very"));

Console.WriteLine(long_text.EndsWith("here"));
Console.WriteLine(long_text.EndsWith("nothing"));

char[] long_text_chars = long_text.ToCharArray();
char[] long_text_substring = long_text.ToCharArray(5, 15);

string[] words = long_text.Split(',', StringSplitOptions.TrimEntries);

Console.WriteLine(long_text.Substring(10));
Console.WriteLine(long_text.Substring(10, 10));

Console.WriteLine(string.Format("Here is formatted string '{0}'", long_text));

Console.WriteLine();

string other_string = "The Contains method returns a boolean value which tells you if the string you were searching for was found. A boolean stores either a true or a false value. When displayed as text output, they are capitalized: True and False, respectively. You'll learn more about boolean values in a later lesson.\r\n\r\nChallenge\r\n\r\nThere are two similar methods, StartsWith and EndsWith that also search for sub-strings in a string. These find a substring at the beginning or the end of the string. Try to modify the previous sample to use StartsWith and EndsWith instead of Contains. Search for \"You\" or \"goodbye\" at the beginning of a string. Search for \"hello\" or \"goodbye\" at the end of a string.";

string raw_string_literal = """
The Contains method returns a boolean value which tells you if
the string you were searching for was found. A boolean stores either a true
or a false value. When displayed as text output, they are capitalized:
True and False, respectively. You'll learn more about boolean values in a later lesson.

Challenge
"


There are two similar methods, StartsWith and EndsWith
that also search for sub-strings in a string. These find
a substring at the beginning or the end of the string.
Try to modify the previous sample to use StartsWith and EndsWith
instead of Contains. Search for "You" or "goodbye" at the beginning of a string. Search for "hello" or "goodbye" at the end of a string.
""";

string AppendText(string s)
{
    return s + "Hello, world!";
}

class HelloAppender
{
    public static string AppendHelloWorld(string s)
    {
        return s + "Hello, world!";
    }

    public static string AppendHelloWorld(object o)
    {
        return AppendHelloWorld(o.ToString());
    }
}