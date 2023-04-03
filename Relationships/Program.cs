// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

Console.WriteLine("Relationships");



public class RelationshipsEfCoreDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<EmployeeAddress> EmployeeAddresses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-E30TBPJ;Database=RelationshipsEfCoreDb;Trusted_Connection=True;TrustServerCertificate=Yes");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // luent api bilen diye isterler işverenler
        modelBuilder.Entity<EmployeeAddress>().HasKey(e => e.Id);
        modelBuilder.Entity<Employee>().HasOne(e => e.EmployeeAddress).WithOne(c => c.Employee).HasForeignKey<EmployeeAddress>(c => c.Id);
        // hem primary hem de foreign key olarak aynı id değerini kullanmak için böyle yaptık
    }
}


public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public EmployeeAddress EmployeeAddress { get; set; }
}
public class EmployeeAddress
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public string Address { get; set; }
    public Employee Employee { get; set; }
}

/*
 * Her iki entity de navigation property ile birbirlerini tekil olarak refere ederek fiziksel bir ilişkinin olacağı ifade edilir.
 * 1-1 ilişki türünde bağımlı entitynin hangisi olduğunu default olarak belirlemek için bizler de foreign key'e karşılık gelen bir property tanımlayarak çözüm ağlamaktayız
 */

#region Default Convension

#region Data Annotations

//public class Employee
//{
//    public int Id { get; set; }
//    public string Name { get; set; }
//    public EmployeeAddress EmployeeAddress { get; set; }
//}

//public class EmployeeAddress
//{
//    public int Id { get; set; }

//    //public int EmployeeId { get; set; }
//    // daha fazla property de ekleneblir
//    // burada Schwarz'ı foreign key olduğunu belirttik
//    [ForeignKey(nameof(Employee))]
//    // Üstündekiler propertyleridir
//    public int Schwarz { get; set; }
//    public string Address { get; set; }
//    public Employee Employee { get; set; }
//}

#endregion

#region Fluent API

// Bu yöntemde entityler arasındaki ilişki cotext sınıfı içinde bulunan onmodel creating fonksiyonu override edilerek gerçekleştirilir

//Navigation Proeprtyler tanımlanmalı!
//Fleunt API yönteminde entity'ler arasındaki ilişki context sınıfı içerisinde OnModelCreating fonksiyonun override edilerek metotlar aracılığıyla tasarlanması gerekmektedir. Yani tüm sorumluluk bu fonksiyon içerisindeki çalışmalardadır.
class Calisan
{
    public int Id { get; set; }
    public string Adi { get; set; }

    public CalisanAdresi CalisanAdresi { get; set; }
}
class CalisanAdresi
{
    public int Id { get; set; }
    public string Adres { get; set; }

    public Calisan Calisan { get; set; }
}



#endregion

#endregion




#region

#region



#endregion

#endregion



#region

#region



#endregion

#endregion


