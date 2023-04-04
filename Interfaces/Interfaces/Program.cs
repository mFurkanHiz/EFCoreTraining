namespace Interfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            /*
             * Diğer sınıflara şablon oluşturmak yol göstermek amacıyla implementasyon kullanarak kendisindeki alanları doldurulması zorunlu hale getiren bir yapıdır. Interfaceler bir class değildir. Kendilerine özgü bir yapıdır.
             * 
             * Sınıflarda birden fazla interface implemente edilebilir. içinde neler bulunur. İnterface içindeki bağlı tüm yapılar publictir. interfacelerde neler bulunur? proplar e metotlar bulunur.
             * 
             * Tanımlaması yapılan memberlar interface içerisinde uygulanmazlar. Fakat kendisinden implemente edilen classlar kendi içlerinde bu imzaları bodylerine oluşturabilirler. Genelde gösterimi baına I harfi eklenerek olur (zorunlu değil ama öyle kullanılır) 
             * 
             * Abstract classlar interfaceler aslında benzer amaçla kullanılmaktadırlar. iki yapı da sınıfın davranış biçimine yön verir ve benzer nitelikler barındırır. 
             * 
                Örneğin;
             * Soyut sınıflar hem somut(concrete) üyeler barındırır hem de soyut üyeler barındırır. soyut üyeler alt sınıflarda ezilerek kullanılır. Soyut sınıflarda kalıtım kullanılır ve alt sınıflarda newleme işlemi yaptırılır. Fakat soyut metotlar alt sınıflarda uygulanmak zorundadırlar.
             * 
                interfaceler ve soyut sınıflar arasındaki farklar;
             * soyut sınıflar soyut üyeler de içerebilirken interfaceler sadece tanım içerirler.
             * Soyut sınıflar , barındırdıkları memberların uygulanması, gerçekleşmesi için kalıtım kullanılır ve kalıtımla alt sınıflar oluşturulur fakat interfaceler birden fazla interface uygulamasına olanak tanır.
             * Biri classtır diğeri değildir.
             * soyut sınıflarda varsayılan olarak erişim belirtici protected tır. interfacelerde default olarak public gelir.
             * 
             */

            Audi a = new Audi();
            Mercedes m = new Mercedes();

            a.Model = "Sedan";
            a.Yil = 2022;
            m.Model = "SUV";
            m.Yil = 2021;
            a.Tur = "asd";

            a.HareketEt();
            m.HareketEt();
        }
    }

    public interface ITasit
    {
        public string Tur { get; set; }
    }

    public interface IVehicle
    {
        string Model { get; set; }
        public int Yil { get; set; }

        void HareketEt();
    }

    public class Audi : IVehicle, ITasit
    {
        public string Model { get; set; }
        public int Yil { get; set; }
        public string Tur { get; set; }

        public void HareketEt()
        {
            Console.WriteLine("Audi hareket etti.");
        }
    }
    public class Mercedes : IVehicle
    {
        public string Model { get; set; }
        public int Yil { get; set; }

        public void HareketEt()
        {
            Console.WriteLine("Mercedes hareket etti.");
        }
    }
}