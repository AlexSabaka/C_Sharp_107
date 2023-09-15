using System.Text;

namespace Lesson_8_Homework_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            CharTable();
        }

        static void CharTable()
        {
            for (int i = 0; i < 256; ++i)
            {
                Console.WriteLine($"{i}: {(char)i}");
            }
        }

        static bool Compare(string a, string b)
        {
            if (a == null || b == null)
            {
                return false;
            }

            if (a.Length != b.Length)
            {
                return false;
            }

            for (int i = 0; i < a.Length; ++i)
            {
                if (a[i] != b[i])
                {
                    return false;
                }
            }

            return true;
        }

        static (int letters, int digits, int separators, int punctuations) Analyze(string s)
        {
            int count_letter = 0;
            int count_digit = 0;
            int count_sep = 0;
            int count_pun = 0;

            foreach (char c in s)
            {
                count_letter += char.IsLetter(c) ? 1 : 0;
                count_digit += char.IsDigit(c) ? 1 : 0;
                count_sep += char.IsSeparator(c) ? 1 : 0;
                count_pun += char.IsPunctuation(c) ? 1 : 0;
            }

            return (count_letter, count_digit, count_sep, count_pun);
        }

        static string Sort(string s)
        {
            char[] chars = s.ToLower().ToCharArray();
            for (int i = 0; i < s.Length - 1; ++i)
            {
                for (int j = 0; j < s.Length - i - 1; ++j)
                {
                    if (chars[j] > chars[j + 1])
                    {
                        (chars[j], chars[j + 1]) = (chars[j + 1], chars[j]);
                    }
                }
            }
            return new string(chars);
        }

        static string Duplicates(string s)
        {
            string result = "";
            foreach (char c in s.ToLower())
            {
                int count = s.Length - s.Replace(c.ToString(), "").Length; // he_l_lo, world! --> heo, word!
                if (count > 1 && !result.Contains(c))
                {
                    result += c;
                }
            }
            return result;
        }
    }
}