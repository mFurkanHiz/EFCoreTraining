// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

ECommerceDbContext context = new();

//for(int i = 0; i < 500; i++)
//{
//    Product p = new Product();
//    p.Name = $"Ürün {i + 1}";
//    p.Price = i * 10;
//    context.Products.Add(p);
//}

//context.SaveChanges();


#region En temel şekilde sorgu kullanımı

#region Metod Syntax

//var products = context.Products.ToList();

//foreach(var item in products)
//{
//    Console.WriteLine($"Ürün adı: {item.Name} / Ürün Fiyatı: {item.Price}");
//}

#endregion

#region Query Syntax

//var urunler = await (from x in context.Products select x).ToListAsync();

//// foreach kullanarak sorgumuzu execute ediyoruz
//foreach (var item in urunler)
//{
//    Console.WriteLine($"Ürün adı: {item.Name} / Ürün Fiyatı: {item.Price}");
//}

#endregion

#region Gecikmeli Execution (Deferred Execution) —> foreach

//var urunId = 200;
//var products = from x in context.Products
//               where x.Id > urunId && x.Price > 400
//               select x;

//urunId = 300;

//foreach (var item in products) // foreach gecikmeli bir inceleme yaptığı için 300 e göre yazdırdı
//{
//    Console.WriteLine(item.Name + " / " + item.Id + " / " + item.Price);
//}

#endregion

#endregion


#region Çoğul veri getiren sorgular


#region Where
// Oluşturulan sorguya şart eklemeyi sağlar
#endregion

#region Method Syntax

//var products = context.Products.Where(u => u.Id > 350).ToList();

//var products2 = await context.Products.Where(u => u.Name.EndsWith("2")).ToListAsync();

//foreach (var item in products2)
//{
//    Console.WriteLine(item.Name);
//}

#endregion

#region Query Syntax

var urunler = from x in context.Products 
              where x.Id > 250 && x.Name.EndsWith("2") 
              select x;

foreach (var item in urunler)
{
    Console.WriteLine(item.Name);
}

#endregion

#endregion

public class ECommerceDbContext: DbContext
{
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-E30TBPJ;Database=CodeFirstETicaretDb;Trusted_Connection=True;TrustServerCertificate=Yes");
    }
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
}