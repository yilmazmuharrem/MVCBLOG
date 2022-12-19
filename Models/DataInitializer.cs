using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Blog.Models
{
    public class DataInitializer:DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var kategori = new List<Kategori>()
            {
                new Kategori() {KategoriAd="C#" },
                 new Kategori() {KategoriAd="PHP" },
                  new Kategori() {KategoriAd="JAVA" }
            };
            foreach (var item in kategori)
            {
                context.Kategoris.Add(item);
            }
            context.SaveChanges();

            var makale = new List<Makale>()
            {
               new Makale() {Baslik="C# Dilindeki Temel Veri Türleri",Aciklama="Öncelikle veri tipi nedir ve ne gibi bir görevi vardır sorularının cevabını arayalım. C# dili için her sınıf bir veri tipidir. Klasik programlama dillerinde karakterler, tamsayılar, kesirli sayılar ve boolean gibi ilkel veri tipleri dile gömülüdür ve her bir veri tipi bir anahtar sözcükle ifade edilmektedir. Fakat C# gibi nesne yönelimli programlama dillerinde her sınıf soyut bir veri yapısını göstermektedir. Bundan dolayı C# ilkel veri tiplerinden arındırılmış haldedir",Resim="a1.png",YayinTarih=Convert.ToDateTime("2020-06-06"),Goruntulenme=0,Onay=true,KategoriId=1,KullaniciAd="ilyasdagdelen" },
               new Makale() {Baslik="C# Akış Kontrol Mekanizmaları",Aciklama="Program yazarken çoğu zaman herşey ak ve kara gibi net olmaz, çoğu zaman çeşitli koşullara göre farklı komutlar çalıştırmamız gerekir. Benzer şekilde çoğu komutun da yalnızca bir kez çalıştırılması bizim için yeterli gelmez, belli koşulları sağladığı sürece sürekli çalıştırılmasını istediğimiz komutlar olabilir. İşte bu gibi durumlar için C#'ta akış kontrol mekanizmaları vardır. Aslında en basitinden en karmaşığına kadar bütün programlama dillerinde bu mekanizmalar mevcuttur ve programlama dillerinin en önemli ögelerinden birisidir. ",Resim="a2.jpg",YayinTarih=Convert.ToDateTime("2020-06-05"),Goruntulenme=0,Onay=true,KategoriId=1,KullaniciAd="hamzadagdelen" },
                new Makale() {Baslik="PHP Operatörler",Aciklama="  Bir veya birden fazla değer arasında gerçekleştirilecek işlemleri temsil eden simge ya da sözcüklere operatör veya işleç denir. Örneğin matematikte kullandığımız + (artı), - (eksi), * (çarpı), / (bölü) gibi semboller PHP'de birer operatördür. Aynı şekilde mantıksal  işlemlerde kullanılan && ile and ve || ile veya sembol ve sözcükleri de birer operatördür. Bunların dışında, başka görevler üstlenen operatörler de vardır. Operatörlerle işleme sokulan ifadelere operand denir. ",Resim="a3.png",YayinTarih=Convert.ToDateTime("2010-06-05"),Goruntulenme=0,Onay=true,KategoriId=2,KullaniciAd="hamzadagdelen" },
            };
            foreach (var item in makale)
            {
                context.Makales.Add(item);
            }
            context.SaveChanges();

            base.Seed(context);
        }
    }
}