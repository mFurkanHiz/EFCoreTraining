namespace AbstractClass01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            /*
             * Öyle bir sınıf düşünelim ki bu sınıftan bir instance almak mümkün olmasın. Bu class tpine abstract (soyut) class denmektedir. Soyut sınıflar kendi başlarına kullanılmamaktadır. Bunun yerine bu sınıflar türetmiş oldukları sınıflar tarafından uygulanması gereken bir dizi soyut yöntemler veya özellikler tanımlarlar.
             * 
             * Genel kullanımları bir arayüz (interface) oluşturulmak istendiği zaman, fakat bu arayüdeki bir takım yöntemlerin uyulanmasını zorunlu tutmak istediğimiz zaman kullanmaktayız. 
             * 
             * Abstrat classlar ile normal classlar arasındaki farkla normal classlarda metot bildirimi sadece imzasıyla yapılmazken abstract classlarda bu yapılabilir. zaten temel amaç da budur. Abstract classlardan türhyen sınıflarda metotlar zaten imza olarak göösterilebilmektedir.
             * 
             * Normal sınıflarda newleme işlemi yapılabilirken abstract classlarda newleme işlemi gerçekleşrtirilemez.
             * 
             * Abstract metotlar sadece abstract sınıflar içerisinde kullanılabilen metotlardır. Mirasçı olan sınıflarda override edilmek zorundadırlar.
             * 
             * Abstract metotlar sadece tanımlanır, herhangi bir işlemi yerine getirmez. yapacakları işlemler override edildikleri sınıfta kodlanmalıdır.
             * 
             * Abstract elemanlar private OLAMAZ.
             */

            //Mobilya m1 = new Mobilya(); // HATA
            // Çünkü abstract classlar newlenemez
            // abstract classlar sadece kalıtım vermek bilgi aktarmak için kullanılır
            Kanepe h1 = new Kanepe();
            h1.renk = "Siyah";
            h1.kumas = "Deri";
            masa m1 = new masa();
            m1.renk = "Ahşap Rengi";
            m1.malzeme = "Ahşap";

            Console.WriteLine("----------------------");
            h1.Tanimla();
            Console.WriteLine("----------------------");
            m1.Tanimla();
            Console.WriteLine("----------------------");

            Dog dog1 = new Dog();
            Dog dog2 = new Dog();
            Cat cat1 = new Cat();
            Cat cat2 = new Cat();

            dog1.name = "asd";
            dog2.name = "qwe";
            cat1.name = "zxc";
            cat2.name = "123";

            dog1.eat("meat");
            cat2.move();
            dog2.speak();
            cat1.eat("cat food");
            dog1.move();


        }
    }

    abstract class Mobilya
    {
        public string renk;
        abstract public void Tanimla();
    }

    class Kanepe : Mobilya
    {
        public string kumas;
        // kalıtım aldığın yerden otomatik olarak çağırmaya implement etmek denir (implementation)
        public override void Tanimla()
        {
            Console.WriteLine($"Kanepenin Özellikleri: \nRenk: {renk},\nKumaş: {kumas}");
        }
    }

    class masa : Mobilya
    {
        public string malzeme;
        public override void Tanimla()
        {
            Console.WriteLine($"Masanın Özellikleri: \nRenk: {renk},\nMalzeme: {malzeme}");
        }
    }

    abstract class Animal
    {
        public string name;
        public int age;
        abstract public void move();
        abstract public void eat(string food);
        abstract public void speak();
    }

    class Cat  : Animal
    {
        public override void eat(string food)
        {
            Console.WriteLine($"{name} eats {food}");
        }

        public override void move()
        {
            Console.WriteLine($"{name} moves");
        }

        public override void speak()
        {
            Console.WriteLine($"{name} Mouws");
        }
    }

    class Dog : Animal
    {
        public override void eat(string food)
        {
            Console.WriteLine($"{name} eats {food}");
        }

        public override void move()
        {
            Console.WriteLine($"{name} runs");
        }

        public override void speak()
        {
            Console.WriteLine($"{name} Barks");
        }
    }

}