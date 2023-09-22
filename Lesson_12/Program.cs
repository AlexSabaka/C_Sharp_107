using System.Numerics;
using System.Text;
using System.Xml.Linq;

namespace Lesson_11_Classes_And_OOP
{
    // SOLID
    // S - Single Responsibility Principle
    // DRY - Don't Repeat Yourself
    // DIE - Duplication Is Evil
    // KISS - Keep It Siple Stupid
    // overengineering
    internal class Program
    {
        static Phonebook _phonebook;

        static void Main(string[] args)
        {
            _phonebook = Phonebook.ReadPhonebookFromFile(args.Length == 0 ? "db.txt" : args[0]);

            while (true)
            {
                UserInteraction();
            }
        }

        static Person ReadPersonDataFromConsole()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.Write("Enter phone: ");
            string phone = Console.ReadLine();
            Console.Write("Enter date of birth: ");
            DateTime date = DateTime.Parse(Console.ReadLine());

            return new Person(name, "", phone, date);
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
                    string stringInput = Console.ReadLine();
                    if (stringInput != null)
                    {
                        input = ulong.Parse(stringInput, System.Globalization.CultureInfo.GetCultureInfo("en-US"));
                        tryAgain = false;
                    }
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
                    var all = _phonebook.GetAllContacts();
                    for (int i = 0; i < all.Length; ++i)
                    {
                        Console.WriteLine($"{i + 1}: {all[i]}");
                    }
                    break;
                case 2:
                    _phonebook.AddContact(ReadPersonDataFromConsole());
                    break;
                case 3:
                    Console.Write("Enter name to edit: ");
                    string nameToEdit = Console.ReadLine();
                    Person newData = ReadPersonDataFromConsole();

                    _phonebook.EditContactByName(nameToEdit, newData);
                    break;
                case 4:
                    Console.Write("Enter query: ");
                    string query = Console.ReadLine();

                    Console.WriteLine(_phonebook.SearchContactByQuery(query));
                    break;
                case 6:
                    _phonebook.SaveToFile();
                    break;
                default:
                    Console.WriteLine("No such operation.");
                    break;
            }
        }

    }
}