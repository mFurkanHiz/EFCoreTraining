// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");
Console.WriteLine();

// DbContext'in tanımlanması
public class DenemeDbContext : DbContext // while it was giving error, press [ctrl + .]
{
    public DbSet<Urun> Urunler { get; set; }
    public DbSet<Musteri> Musteriler { get; set; }
    public DbSet<Siparis> Siparisler { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-E30TBPJ;Database=CodeFirstDb;Trusted_Connection=True;TrustServerCertificate=Yes");
    }
}
// Entity'lerin tanımlanması

public class Urun
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }

}

public class Musteri
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }

    public string Gender { get; set; }
}
public class Siparis
{
    public int SiparisId { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
}