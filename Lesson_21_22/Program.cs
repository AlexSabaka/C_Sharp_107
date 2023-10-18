
Lesson_21_Library.Library lib = new();
Lesson_21_Library.Author author = new Lesson_21_Library.Author { Name = "J. Rolling", Age = 50, Phone = "1234567890"};
lib.Books.Add(new Lesson_21_Library.Book { Title = "Harry Potter", Year = 1997, Author = author });
lib.Books.Add(new Lesson_21_Library.Book {});

var otherAuthor = Activator.CreateInstance<Lesson_21_Library.Author>();
Console.WriteLine(otherAuthor);

string json = Newtonsoft.Json.JsonConvert.SerializeObject(lib, Newtonsoft.Json.Formatting.Indented);
Console.WriteLine(json);

System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(Lesson_21_Library.Library));
// var fileStream = File.CreateText("./book_lib.xml");
// xs.Serialize(fileStream, lib);
// fileStream.Close();

var fileStream2 = File.OpenRead("./book_lib.xml");
Lesson_21_Library.Library lib2 = (Lesson_21_Library.Library)xs.Deserialize(fileStream2);
foreach (var b in lib2.Books)
{
    Console.WriteLine(b.Title);
}
