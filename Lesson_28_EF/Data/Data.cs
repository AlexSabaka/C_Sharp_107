using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Lesson_28_EF.Data;

[Table("countries")]
public class Country
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [MaxLength(100)]
    public string Name { get; set; }

    [Column("code")]
    [MaxLength(2)]
    public string Code { get; set; }
}

[Table("authors")]
public class Author
{
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string Name { get; set; }

    [Column("surname")]
    public string Surname { get; set; }

    [Column("email")]
    public string Email { get; set; }

    [ForeignKey(nameof(CountryId))]
    public Country? Country { get; set; } = new Country();

    [Column("country_id")]
    public int? CountryId { get; set; }

    [Column("birthday")]
    public DateTime Birthday { get; set; }

    [InverseProperty(nameof(Author))]
    public ICollection<Book> Books { get; set; } = new List<Book>();
}

[Table("publishers")]
public class Publisher
{
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string Name { get; set; }

    [Column("address")]
    public string Address { get; set; }

    [ForeignKey(nameof(CountryId))]
    public Country? Country { get; set; } = new Country();

    [Column("country_id")]
    public int CountryId { get; set; }

    [InverseProperty(nameof(Publisher))]
    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}

[Table("books")]
public class Book
{
    [Column("id")]
    public int Id { get; set; }

    [Column("title")]
    public string Title { get; set; }

    [Column("publish_date")]
    public DateTime PublishDate { get; set; }

    [ForeignKey(nameof(AuthorId))]
    public Author Author { get; set; } = new Author();

    [Column("author_id")]
    public int AuthorId { get; set; }

    [ForeignKey(nameof(PublisherId))]
    public Publisher? Publisher { get; set; } = new Publisher();

    [Column("publisher_id")]
    public int PublisherId { get; set; }
}

public class BookLibraryDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Country> Countries { get; set; }

    public BookLibraryDbContext()
        : base()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        //Server=[host];Port=[5432];User Id=[username];Password=[secret];Database=[databasename];
        optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;User Id=admin;Password=admin;Database=books_library;");
    }
}