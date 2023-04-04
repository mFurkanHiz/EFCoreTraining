// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

Console.WriteLine("ManyToManyRelationships");

#region Default Convention

//İki entity arasındaki ilişkiyi navigation propertyler üzerinden çoğul olarak kurmalıyız. (ICollection, List)
//Default Convention'da cross table'ı manuel oluşturmak zorunda değiliz. EF Core tasarıma uygun bir şekilde cross table'ı kendisi otomatik basacak ve generate edecektir.
//Ve oluşturulan cross table'ın içerisinde composite primary key'i de otomatik oluşturmuş olacaktır.

//public class Book
//{
//    public int Id { get; set; }
//    public string Name { get; set; }
//    public ICollection<Author> Authors { get; set; }

//}
//public class Author 
//{
//    public int Id { get; set; }
//    public string AuthorName { get; set; }
//    public ICollection<Book> Books { get; set; }
//}

#endregion

#region Data Annotation

////Cross table manuel olarak oluşturulmak zorundadır.
////Entity'lerde oluşturduğumuz cross table entity si ile bire çok bir ilişki kurulmalı.
////CT'da composite primary key'i data annotation(Attributes)lar ile manuel kuramıyoruz. Bunun için de Fluent API'da çalışma yaopmamız gerekiyor.
////Cross table'a karşılık bir entity modeli oluşturuyorsak eğer bunu context sınıfı içerisinde DbSet property'si olarka bildirmek mecburiyetinde değiliz!
//// Sadece ek olarak OnModelCreating metodu içerisinde bir Id tanımlanması yapmamız gerekiyor yoksa PrimaryKey'in ne olduğunu algılamıyor.

//public class Book
//{
//    public int Id { get; set; }
//    public string Name { get; set; }
//    public ICollection<YazarKitap> Authors { get; set; }

//}
//public class Author
//{
//    public int Id { get; set; }
//    public string AuthorName { get; set; }
//    public ICollection<YazarKitap> Books { get; set; }
//}

//public class YazarKitap
//{
//    [ForeignKey(nameof(Book))]
//    public int BId { get; set; }
//    [ForeignKey(nameof(Author))]
//    public int AId { get; set; }
//    public Book Book { get; set; }
//    public Author Author { get; set; }

//}

#endregion

#region Fluent API

public class Book
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<YazarKitap> Authors { get; set; } // navigation property

}
public class Author
{
    public int Id { get; set; }
    public string AuthorName { get; set; }
    public ICollection<YazarKitap> Books { get; set; } // navigation property
}

// Cross Table

public class YazarKitap
{
    public int BookId { get; set; }
    public int AuthorId { get; set; }
    public Book Book { get; set; } // navigation property
    public Author Author { get; set; } // navigation property
}

#endregion

public class RelationshipsEfCoreDbContext : DbContext
{

    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-E30TBPJ;Database=ManyToManyRelationshipsEfCoreDb;Trusted_Connection=True;TrustServerCertificate=Yes");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<YazarKitap>().HasKey(x => new { x.AuthorId, x.BookId });
        // yukarıdaki hem data annotationda hem de fluent api de kullanıldı
        modelBuilder.Entity<YazarKitap>().HasOne(x => x.Book).WithMany(x => x.Authors).HasForeignKey(x => x.BookId);
        modelBuilder.Entity<YazarKitap>().HasOne(x => x.Author).WithMany(x => x.Books).HasForeignKey(x => x.AuthorId);
    }
}


