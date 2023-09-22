namespace Lesson_11_Classes_And_OOP
{
    class Phonebook
    {
        private string _phonebookFile; // camelCase

        private Person[] _contacts; // camelCase

        public Phonebook(string file)
        {
            _phonebookFile = file;
            _contacts = new Person[0];
        }

        public void AddContact(Person newPerson) // CamelCase
        {
            Array.Resize(ref _contacts, _contacts.Length + 1);
            _contacts[^1] = newPerson;
        }

        public bool EditContactByName(string name, Person newPerson)
        {
            int contactIndex = GetContactIndexByName(name);
            if (contactIndex < 0)
            {
                return false;
            }
            _contacts[contactIndex] = newPerson;
            return true;
        }

        public bool DeleteContactByName(string name)
        {
            int contactIndex = GetContactIndexByName(name);
            if (contactIndex < 0)
            {
                return false;
            }

            // contactIndex = 3
            // [0], [1], [2], -> [3] <- , [4], [5]
            Person[] contactsCopy = new Person[_contacts.Length];
            Array.Copy(_contacts, contactsCopy, _contacts.Length);

            _contacts = new Person[_contacts.Length - 1];                   // Resize array by 1
            Array.Copy(contactsCopy, 0, _contacts, 0, contactIndex);        // Copy to new array elements from 0..index
            Array.Copy(contactsCopy, contactIndex + 1, _contacts, contactIndex, _contacts.Length - contactIndex);  // Copy from (index + 1)..N

            return true;
        }

        public Person[] GetAllContacts()
            => _contacts;

        public Person SearchContactByQuery(string query)
            => _contacts[GetContactIndexByName(query)];

        private int GetContactIndexByName(string searchQuery)
        {
            for (int i = 0; i < _contacts.Length; ++i)
            {
                if (_contacts[i].FirstName.Contains(searchQuery, StringComparison.OrdinalIgnoreCase) ||
                    _contacts[i].LastName.Contains(searchQuery, StringComparison.OrdinalIgnoreCase) ||
                    _contacts[i].Phone.Contains(searchQuery, StringComparison.OrdinalIgnoreCase))
                {
                    return i;
                }
            }

            return -1;
        }


        public bool SaveToFile()
        {
            try
            {
                string[] lines = new string[_contacts.Length];
                for (int i = 0; i < lines.Length; i++)
                {
                    lines[i] = $"{_contacts[i].FullName},{_contacts[i].Phone},{_contacts[i].BirthDate}";
                }
                File.WriteAllLines(_phonebookFile, lines);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static Phonebook ReadPhonebookFromFile(string fileName)
        {
            string[] lines = ReadDatabaseAllTextLines(fileName);

            return new Phonebook(fileName)
            {
                _contacts = ConvertStringsToContacts(lines),
            };
        }

        private static string[] ReadDatabaseAllTextLines(string file)
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

        private static Person[] ConvertStringsToContacts(string[] records)
        {
            // records:
            // "name,phone,date of birth"
            // Oleksii,+38090873928,30.03.1993
            var contacts = new Person[records.Length];
            for (int i = 0; i < records.Length; ++i)
            {
                string[] array = records[i].Split(','); // "Oleksii", "+38090873928", "30.03.1993"
                if (array.Length != 3)
                {
                    continue;
                }

                string[] nameParts = array[0].Split(' ', StringSplitOptions.RemoveEmptyEntries); // "Oleksi" "Kruhlyk"
                contacts[i] = new Person(nameParts[0], nameParts[1], array[1], DateTime.Parse(array[2]));
            }
            return contacts;
        }
    }
}