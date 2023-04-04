// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

Console.WriteLine("OneToManyRelationships");

#region Default Convention

//public class Employee
//{
//    public int Id { get; set; }
//    public string Name { get; set; }
//    public Department Department { get; set; } // Navigation Property (ilişkinin olduğu class)

//}
//public class Department 
//{
//    public int Id { get; set; }
//    public string DepartmanAdi { get; set; }
//    public ICollection<Employee> Employees { get; set; }
//}
//// bir çalışanın bir departmanı vardır ama bir departmanda birden fazla çalışan olabilir bu yüzden çalışanları temsil etmek adına çalışanları koleksiyon olarak tanımladık

#endregion

#region Data Annotation

////  Default convention yöntemiyle yaptığımız ilişkideki FK'ya (foreign key) karşılık gelen property name'i geleneksel entity kurallarına uygun değilse data annatation kullanarak müdahale ediyoruz

//// Employee class'ı bu örnekte bağımlı classtır. Department class'ından FK alır. Bu gibi classlara department class denir.
//public class Employee
//{
//    public int Id { get; set; }

//    [ForeignKey(nameof(Department))] // bunu yazarak schwarz'ın Department'ın foreign key olduğunu belirtiyoruz. Buradaki isim hemen aşağıda tanımladığımız Department entity prop ismi ile aynı olmalı
//    public int Schwarz { get; set; }
//    public string Name { get; set; }
//    public Department Department { get; set; } // Navigation Property (ilişkinin olduğu class)

//}
//public class Department 
//{
//    public int Id { get; set; }
//    public string DepartmanAdi { get; set; }
//    public ICollection<Employee> Employees { get; set; }
//}

#endregion

#region Fluent API

//  
public class Employee
{
    public int Id { get; set; }
    public int DxId { get; set; }
    public string Name { get; set; }
    public Department Department { get; set; } // Navigation Property (ilişkinin olduğu class)

}
public class Department 
{
    public int Id { get; set; }
    public string DepartmanAdi { get; set; }
    public ICollection<Employee> Employees { get; set; }
}

#endregion



public class RelationshipsEfCoreDbContext : DbContext
{

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-E30TBPJ;Database=OneToManyRelationshipsEfCoreDb;Trusted_Connection=True;TrustServerCertificate=Yes");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().HasOne(c => c.Department).WithMany(x => x.Employees).HasForeignKey(x => x.DxId);
        // HasOne           -> departmanla bir ilişkisi var. (Emp. ile dep.)
        // WithMany         -> dep. içindeki employee ile çoklu ilişkimiz var
        // HasForeignKey    -> bu ilişkide foreign key emp. içindeki DxId
    }

}