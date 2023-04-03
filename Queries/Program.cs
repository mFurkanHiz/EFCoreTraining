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

// bu işlemlere linq denir, veritabanına sorgu atmak
// sql mişcesine 

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

#region Method Syntax

//var products = context.Products.Where(u => u.Id > 350).ToList();

//var products2 = await context.Products.Where(u => u.Name.EndsWith("2")).ToListAsync();

//foreach (var item in products2)
//{
//    Console.WriteLine(item.Name);
//}

#endregion

#region Query Syntax

//var urunler = from x in context.Products 
//              where x.Id > 250 && x.Name.EndsWith("2") 
//              select x;

//foreach (var item in urunler)
//{
//    Console.WriteLine(item.Name);
//}

#endregion

#endregion

#region Queryable ve Numarable arasındaki fark nedir?

// Queryable ve Numarable arasındaki fark nedir?

// Queryable: Sorguya karşılık gelir. Efcore üzerinden yapılmış olan sorunun execute edilmemiş halidir.

// Numerable: Sorgunun çalıştırılıp execute edilip verilerin in memory'e yüklenmiş halini ifade eder.

#endregion

#region OrderBy

#region Where
// Oluşturulan sorguya şart eklemeyi sağlar
#endregion

#region Method Syntax

//var products = context.Products.Where(u => u.Id > 350).OrderBy(x => x.Price).ToList();

//foreach (var product in products)
//{
//    Console.WriteLine($"{product.Name} / {product.Price}");
//}

#endregion

#region Query Syntax

//// Queryable
//var products = from x in context.Products
//              where x.Id > 350
//              orderby x.Price
//              select x;

//foreach (var item in products)
//{
//    Console.WriteLine($"{item.Name} / {item.Price}");
//}

//// in memory list (Numerable)
//var urunler = products.ToList();

//foreach (var item in urunler)
//{
//    Console.WriteLine($"{item.Name} / {item.Price}");
//}

#endregion


#endregion

#region ThenBy (Ascending) (küçükten büyüğe)

#region Method Syntax

//var products = context.Products.Where(x => x.Id > 350).OrderBy(x => x.Name).ThenBy(o => o.Price).ToList();

//foreach (var product in products)
//{
//    Console.WriteLine($"{product.Name} / {product.Price} TL");
//}

#endregion

// Query si yok

#endregion

#region Order By Descending

#region Method Syntax

//var products = context.Products.Where(u => u.Id > 350).OrderByDescending(x => x.Name).ThenByDescending(x => x.Price).ToList();

//foreach (var product in products)
//{
//    Console.WriteLine($"{product.Name} / {product.Price} TL");
//}

#endregion

#endregion

#endregion

#region Tekil Veri Getiren Sorgulamalar

#region Single / SingleAsync

//var product = await context.Products.SingleAsync(c => c.Id == 25); // one line
//Console.WriteLine(product.Name + " / " + product.Price); // one line

//var product = await context.Products.SingleAsync(c => c.Id == 50000); // throws exception
//Console.WriteLine(product.Name + " / " + product.Price); // throws exception
// because there is no such id 

//var product = await context.Products.SingleAsync(c => c.Id > 350); // throws exception
//Console.WriteLine(product.Name + " / " + product.Price); // throws exception
//// because there is more lines

// Birden çok kayıt geldiğinde  ya da hiç kayıt gelmediğinde exception fırlatır.

#endregion

#region SingleOrDefault

// SingleOrDefault'ta çoklu veri gelirse exception fırlar, fakat öyle bir kayıt hiç yoksa konsol null şekilde bir dönüş ağlar.


//var product = await context.Products.SingleOrDefaultAsync(u => u.Id > 150); // throws exception
//Console.WriteLine(product.Name + " / " + product.Price); // throws exception


//var product = await context.Products.SingleOrDefaultAsync(u => u.Id > 5500); // throws exception
//Console.WriteLine(product.Name + " / " + product.Price); // throws exception


//var product = await context.Products.SingleOrDefaultAsync(u => u.Id > 5500); // no exception, no result


//var product = await context.Products.SingleOrDefaultAsync(u => u.Id == 150); // no problem
//Console.WriteLine(product.Name); // no problem

#endregion

#region First / FirstOrDefault

//var product = await context.Products.FirstAsync(u => u.Id == 1); 
//Console.WriteLine(product.Name); // Ürün 500

//// eşleşen kayıt yok bu nedenle exception var
//var product = await context.Products.FirstAsync(u => u.Id == 600); // throws exception

//// eşleşen birden fazla kayıt var. id si 150 den sonraki ilk ürünü getirdi
//var product = await context.Products.FirstAsync(u => u.Id > 150); 
//Console.WriteLine(product.Name); // Ürün 150


// kayıt olmasa dahi null döner
//var product = await context.Products.FirstOrDefaultAsync(u => u.Id == 6000); // null

#endregion

#region Find

//var product = context.Products.Find(55); // direk id parametresini alır
//Console.WriteLine(product.Name); // ürün 54


//var product = context.Products.Find(5500); // returns null
//Console.WriteLine(product.Name); // throws exception

#endregion

// en çok FirstOrDefault ve Find kullanılıyor

#region Last

// last son kaydı getirir

// order by kullanmak mecburidir

//var product = context.Products.OrderBy(x => x.Price).LastOrDefault(); // sonuncu değeri getirir
//Console.WriteLine(product.Name); // ürün 500

// Aşağıdaki örnekte order by ile beraber bir kullanımı yapıldı. Last sonrasında id'si 350'den büyük olan ürünleri sıraladı. Normalde yapacağı şey sonuncu ürünü getirmekti. fakat bir bu sorguya bir de order by descending eklediğimiz için ve bu sıralamada ürün fiyatını sondan başa sıralamış olduğumuz için son kayıt olarak ürün fiyatı en düşün olan ve id si 350 den büyük olan ilk ürünü getirmiş oldu.
//var product = context.Products.OrderByDescending(x => x.Price).LastOrDefault(x => x.Id > 350); 
//Console.WriteLine(product.Name + " / "+ product.Price);  // en ucuzunu verir

#endregion

#endregion

#region Diğer Fonksiyonlar

#region Count

//var urunler = (await context.Products.ToListAsync()).Count(); // kayıt sayısını göterir
//Console.WriteLine(urunler); // 501

#endregion

#region LongCount

//var urunler = (await context.Products.ToListAsync()).LongCount(); // kayıt sayısını göterir, integer değer değil long değer tutar. bu nedenle daha büyük veri tabanları için kayıt sayısı bu komutla çağırılır
//Console.WriteLine(urunler); // 501

#endregion

#region Any

// sorgu sonucunda gelen verilerin gelip gelmediğini bool türünde döner.
//var urunler =  context.Products.Where(x => x.Name.Contains("5")).Any(); // 
//Console.WriteLine(urunler); // true

//var urunler = context.Products.Where(x => x.Name.Contains("schwarz")).Any(); // 
//Console.WriteLine(urunler); // false

#endregion

#region Max / Min

//var price = await context.Products.MaxAsync(u => u.Price);
//Console.WriteLine(price);

//var price = await context.Products.MinAsync(u => u.Price);
//Console.WriteLine(price); // 10

#endregion

#region Distinct

//// sorguda tekrar eden (mükerrer) kayıtları tekilleştiren komuttur 

//var price = await context.Products.Distinct().ToListAsync(); 
//Console.WriteLine(price);

#endregion

#region All

//Bir sorgu neticesinde gelen verilerin, verilen şarta uyup uymadığını kontrol etmektedir. Eğer ki tüm veriler şarta uyuyorsa true, uymuyorsa false döndürecektir.

//var price = await context.Products.AllAsync(x => x.Price < 50);
//Console.WriteLine(price); // false
//// çünkü bütün verilerin fiyatı 50 değil, fiyatı 50 üstü olanlar da var

//var price = await context.Products.AllAsync(x => x.Name.Contains("ü"));
//Console.WriteLine(price); // true
//// çünkü bütün verilerin isminde ü ifadesi geçiyor

#endregion

#region Sum

////Vermiş olduğumuz sayısal proeprtynin toplamını alır.
//var toplamFiyat = await context.Products.SumAsync(u => u.Price); // Bütün fiyatların toplamı
//Console.WriteLine(toplamFiyat);

#endregion

#region Average

////Vermiş olduğumuz sayısal proeprtynin aritmatik ortalamasını alır.
//var aritmatikOrtalama = await context.Products.AverageAsync(u => u.Price);
//Console.WriteLine(aritmatikOrtalama);

#endregion

#region StartsWith / EndsWith

//Like '...%' sorgusu oluşturmamızı sağlar.
//var products = context.Products.Where(u => u.Name.StartsWith("8")).ToList();
//Console.WriteLine(products.Count); // 0

//var products = context.Products.Where(u => u.Name.StartsWith("ü")).ToList();
//Console.WriteLine(products.Count); // 501

//var products = context.Products.Where(u => u.Name.EndsWith("8")).ToList();
//Console.WriteLine(products.Count); // 49

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