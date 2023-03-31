// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");
Console.WriteLine();

#region Veri Ekleme
CodeFirstKitaplikDbContext context = new();
//Book book = new();
//Book book = new()
//{
//    KitapAdi = "Muhittin",
//    Fiyat = 60
//};

//context.Add(book);

//context.SaveChanges();
//await context.AddAsync(); // aynı işlem
//await context.SaveChangesAsync(); // aynısı ama daha hızlı


// SaveChanges: insert update delete sorgularını oluşturup bir transaction eşliğinde vt'na gönderip execute eden fonksiyondur. Eğer ki sorgulardan herangi herhangi biri başarısız olursa tüm işlemler geri alınacaktır. bu işleme rollback denir [mülekatlarda sorulur]

#endregion

#region EFCore verinin ekleneceğini nereden anlıyor

//Book book2 = new()
//{
//    KitapAdi = "Muhittin2",
//    Fiyat = 60
//};

//Console.WriteLine(context.Entry(book2).State);

//await context.AddAsync(book2);

//Console.WriteLine(context.Entry(book2).State);

//await context.SaveChangesAsync();

//Console.WriteLine(context.Entry(book2).State);

#endregion

#region Birden Fazla Veri Eklerken Nelere Dikkat Edeceğiz

//Book book = new()
//{
//    KitapAdi = "Muhittin3",
//    Fiyat = 60
//};

//Book book1 = new()
//{
//    KitapAdi = "Ökkeş Dolmuşçu",
//    Fiyat = 60
//};
//Book book2 = new()
//{
//    KitapAdi = "Yunus Günçe",
//    Fiyat = 60
//};

//context.Books.Add(book);
//context.Books.Add(book1);
//context.Books.Add(book2);
//await context.SaveChangesAsync();

//context.Books.AddRange(book, book1, book2);
//await context.SaveChangesAsync();





#endregion

#region Veri Nasıl Güncellenmaktedir??

//Book book = context.Books.FirstOrDefault(x => x.Id == 5); // Id si 5 olan veriyi getir

//book.KitapAdi = "Ökkeş Balıkçı";
//book.Fiyat = 100;

//context.SaveChanges();



#endregion

#region change tracker

// change tracker
// contexttten gelen dataların takibinden sorumlu bir mekanizma. Bu takip mekanizması sayesinde context üzerinden gelen verilerle ilgili işlemlerin sonucunda update veya delete sorgularının oluşacağını anlar.

//Book book1 = await context.Books.FirstOrDefaultAsync(u => u.Id == 9); // => lambda operator

//Console.WriteLine(context.Entry(book1).State); // Unchanged

//book1.KitapAdi = "Tuna Tavus";

//Console.WriteLine(context.Entry(book1).State); // Modified

//await context.SaveChangesAsync();

//Console.WriteLine(context.Entry(book1).State); // Unchanged


//// takip edilebilir olmayan update
//Book bookOrnek = new()
//{
//    Id = 7,
//    KitapAdi = "Karpuz",
//    Fiyat = 450
//};

////context.Update(); // bu şekilde de kullanılabilir ama diğeri kadar güvenli değil
//// Change tracker mekanizması tarafnıdan takip edilemeyen nesnelerin güncellenebilmesi açısından update fonksiyonu kullanılmaktadır. Bu takip edilememe meselesini şöyle algılayabiliriz. İlk yaptığımız güncelleme örneğinde veritabanımıza context üzerinden bir sorgu atıp istediğimiz Id ye sahip olan nesneyi programımıza çağırdık. Sonrasında bu gelen ve haliyle takip edilebilen nesne üzerinde değişiklik yapıp savechanges dedik. Şu an ise context üzerinden herhangi bir işlem yapmadan ve haliyle takip edemediğimiz bir nesne üzerinden işlem yapmak istedik. Bu yüzden update metodunu kullanmak zorunda kaldık.
//context.Books.Update(bookOrnek);
//context.SaveChanges();

//// diğerinde dinleme mekanizması var

#endregion

#region Toplu Update (foreach ile)

//var kitaplar = await context.Books.ToListAsync(); // takip edilebilir

//foreach(var item in kitaplar)
//{
//    item.KitapAdi += " :)";
//}

//await context.SaveChangesAsync();

#endregion

#region Veri Silme

//Book book1 = context.Books.FirstOrDefault(u => u.Id == 7);

//context.Books.Remove(book1);
//context.SaveChanges();

#endregion

#region Toplu Silme

//List<Book> kitaplar = context.Books.ToList(); // bütün verileri çeker

//foreach(var item in kitaplar)
//{
//    Console.WriteLine(item.KitapAdi);
//}
//context.Books.RemoveRange(kitaplar);
//context.SaveChanges();

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