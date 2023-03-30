// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");
Console.WriteLine();

#region Veri Ekleme
CodeFirstKitaplikDbContext context = new();
//Book book = new();
Book book = new()
{
    KitapAdi = "Muhittin",
    Fiyat = 60
};

context.Add(book);

//context.SaveChanges();
await context.AddAsync(); // aynı işlem
await context.SaveChangesAsync(); // aynısı ama daha hızlı


// SaveChanges: insert update delete sorgularını oluşturup bir transaction eşliğinde vt'na gönderip execute eden fonksiyondur. Eğer ki sorgulardan herangi herhangi biri başarısız olursa tüm işlemler geri alınacaktır. bu işleme rollback denir [mülekatlarda sorulur]

#endregion

#region EFCore verinin ekleneceğini nereden anlıyor
Book book2 = new()
{
    KitapAdi = "Muhittin2",
    Fiyat = 60
};

Console.WriteLine(context.Entry(book2).State);

await context.AddAsync(book2);

Console.WriteLine(context.Entry(book2).State);

await context.SaveChangesAsync();

Console.WriteLine(context.Entry(book2).State);

#endregion



public class CodeFirstKitaplikDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-E30TBPJ;Database=CodeFirstKitaplikDb;Trusted_Connection=True;TrustServerCertificate=Yes");
    }
}

public class Book
{
    public int Id { get; set; }
    public string KitapAdi { get; set; }
    public double Fiyat { get; set; }
}