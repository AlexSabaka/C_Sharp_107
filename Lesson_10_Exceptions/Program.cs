﻿using System.Text;

namespace Lesson_9_Text_And_Files
{
    internal class Program
    {
        static string database = "db.txt";
        static (string name, string phone, DateTime birth)[] contacts;

        static void Main(string[] args)
        {
            // string absolute_path_to_file = @"C:\Users\alexl\source\repos\C_Sharp_107\Lesson_9_Text_And_Files\document.txt";
            // string relative_path_to_file = @"./../../../document_2.txt";

            // string text = File.ReadAllText(absolute_path_to_file, Encoding.UTF8);
            // string[] lines = File.ReadAllLines(relative_path_to_file);

            // 0. SAVE IT TO THE FILE WITH ".CSV"
            // 1. Writes to console currently available contacts in the file
            // 2. Add new contact
            // 3. Edit contact
            // 4. Search contacts
            // 5. Calculates the contact age
            // 6. Save database

            string[] records = ReadDatabaseAllTextLines(database);
            contacts = ConvertStringsToContacts(records);

            while (true)
            {
                UserInteraction();
            }
        }

        static void UserInteraction()
        {
            Console.WriteLine("1. Write all contacts");
            Console.WriteLine("2. Add new contact");
            Console.WriteLine("3. Edit contact");
            Console.WriteLine("4. Search by name");
            Console.WriteLine("6. Save");
            Console.Write("Enter a choice: ");

            ulong input = 0;
            bool tryAgain = true;
            while (tryAgain)
            {
                try
                {
                    input = ulong.Parse(Console.ReadLine(), System.Globalization.CultureInfo.GetCultureInfo("en-US"));
                    tryAgain = false;
                }
                catch (FormatException)
                {
                    Console.Write("You've entered a wrong choice, please try again: ");
                }
                catch (OverflowException)
                {
                    Console.Write("You suck at math, try a POSITIVE number: ");
                }
                catch (SystemException)
                {
                    Console.WriteLine("Sorry, some system happened");
                }
                catch
                {
                    Console.WriteLine("Sorry, idk what happaned");
                }
                finally
                {
                }
            }

            switch (input)
            {
                case 1:
                    WriteAllContactsToConsole();
                    break;
                case 2:
                    AddNewContact();
                    break;
                case 3:
                    EditContact();
                    break;
                case 4:
                    SearchContact();
                    break;
                case 6:
                    SaveContactsToFile();
                    break;
                default:
                    Console.WriteLine("No such operation.");
                    break;
            }
        }

        static void AddNewContact()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.Write("Enter phone: ");
            string phone = Console.ReadLine();
            DateTime date = DateTime.Now;
            try
            {
                Console.Write("Enter date of birth: ");
                date = DateTime.Parse(Console.ReadLine()); // mm/dd/yyyy - 
            }
            catch (FormatException)
            {
                Console.WriteLine("Sorry, wrong format. Date of birth set to default value.");
            }

            Array.Resize(ref contacts, contacts.Length + 1);
            contacts[^1] = (name, phone, date);
        }

        static void EditContact()
        {
            int id = SearchContact();
            if (id == -1)
            {
                Console.WriteLine("Sorry, nothing is found.");
                return;
            }

            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.Write("Enter phone: ");
            string phone = Console.ReadLine();
            DateTime date = DateTime.Now;
            try
            {
                Console.Write("Enter date of birth: ");
                date = DateTime.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Sorry, wrong format. Date of birth set to default value.");
            }

            contacts[id] = (name, phone, date);
        }

        static int SearchContact()
        {
            Console.Write("Enter search query: ");
            string searchQuery = Console.ReadLine().Trim(); // sanize

            for (int i = 0; i < contacts.Length; ++i)
            {
                if (contacts[i].name.Contains(searchQuery, StringComparison.OrdinalIgnoreCase) ||
                    contacts[i].phone.Contains(searchQuery, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"#{i+1}: {contacts[i].name}, {contacts[i].phone}, {contacts[i].birth}");
                    return i;
                }
            }
            return -1;
        }

        static void WriteAllContactsToConsole()
        {
            for (int i = 0; i < contacts.Length; i++)
            {
                int age = DateTime.Now.Year - contacts[i].birth.Year;
                Console.WriteLine($"#{i + 1}: Name: {contacts[i].Item1}, Phone: {contacts[i].Item2}, Age: {age}");
            }
        }

        static (string name, string phone, DateTime date)[] ConvertStringsToContacts(string[] records)
        {
            // records:
            // "name,phone,date of birth"
            // Oleksii,+38090873928,30.03.1993
            var contacts = new (string name, string phone, DateTime date)[records.Length];
            for (int i = 0; i < records.Length; ++i)
            {
                string[] array = records[i].Split(','); // "Oleksii", "+38090873928", "30.03.1993"
                if (array.Length != 3)
                {
                    Console.WriteLine($"Line #{i + 1}: '{records[i]}' cannot be parsed");
                    continue;
                }
                contacts[i].name = array[0];
                contacts[i].phone = array[1];
                contacts[i].date = DateTime.Parse(array[2]);
            }
            return contacts;
        }

        static void SaveContactsToFile()
        {
            string[] lines = new string[contacts.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = $"{contacts[i].Item1},{contacts[i].Item2},{contacts[i].Item3}";
            }
            File.WriteAllLines(database, lines);
        }

        static string[] ReadDatabaseAllTextLines(string file)
        {
            try
            {
                return File.ReadAllLines(file);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new string[0];
            }
        }
    }
}