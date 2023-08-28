using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

ETicaretContext context = new();
#region Change Tracking Neydi?
//Context nesnesi �zerinden gelen t�m nesneler/veriler otomatik olarak bir takip mekanizmas� taraf�ndan izlenirler. ��te bu takip mekanizmas�na Change Tracker denir. Change Traker ile nesneler �zerindeki de�i�iklikler/i�lemler takip edilerek netice itibariyle bu i�lemlerin f�trat�na uygun sql sorgucuklar� generate edilir. ��te bu i�leme de Change Tracking denir. 
#endregion

#region ChangeTracker Propertysi
//Takip edilen nesnelere eri�ebilmemizi sa�layan ve gerekti�i taktirde i�lemler ger�ek�etirmemizi sa�layan bir propertydir.
//Context s�n�f�n�n base class'� olan DbContext s�n�f�n�n bir member'�d�r.

//var urunler = await context.Urunler.ToListAsync();
//urunler[6].Fiyat = 123; //Update
//context.Urunler.Remove(urunler[7]); //Delete
//urunler[8].UrunAdi = "asdasd"; //Update


//var datas = context.ChangeTracker.Entries();

//await context.SaveChangesAsync();
//Console.WriteLine();
#endregion

#region DetectChanges Metodu
//EF Core, context nesnesi taraf�ndan izlenen t�m nesnelerdeki de�i�iklikleri Change Tracker sayesinde takip edebilmekte ve nesnelerde olan verisel de�i�iklikler yakalanarak bunlar�n anl�k g�r�nt�leri(snapshot)'ini olu�turabilir.
//Yap�lan de�i�ikliklerin veritaban�na g�nderilmeden �nce alg�land���ndan emin olmak gerekir. SaveChanges fonksiyonu �a�r�ld��� anda nesneler EF Core taraf�ndan otomatik kontrol edilirler.
//Ancak, yap�lan operasyonlarda g�ncel tracking verilerinden emin olabilmek i�in de�i�i�iklerin alg�ulanmas�n� opsiyonel olarak ger�ekle�tirmek isteyebiliriz. ��te bunun i�in DetectChanges fonksiyonu kullan�labilir ve her ne kadar EF Core de�i�ikleri otomatik alg�l�yor olsa da siz yine de iradenizle kontrole zorlayabilirsiniz.

//var urun = await context.Urunler.FirstOrDefaultAsync(u => u.Id == 3);
//urun.Fiyat = 123;

//context.ChangeTracker.DetectChanges();
//await context.SaveChangesAsync();

#endregion

#region AutoDetectChangesEnabled Property'si
//�lgili metotlar(SaveChanges, Entries) taraf�ndan DetectChanges metodunun otomatik olarak tetiklenmesinin konfig�rasyonunu yapmam�z� sa�layan proeportydir.
//SaveChanges fonksiyonu tetiklendi�inde DetectChanges metodunu i�erisinde default olarak �a��rmaktad�r. Bu durumda DetectChanges fonksiyonunun kullan�m�n� irademizle y�netmek ve maliyet/performans optimizasyonu yapmak istedi�imiz durumlarda AutoDetectChangesEnabled �zelli�ini kapatabiliriz.
#endregion

#region Entries Metodu
//Context'te ki Entry metodunun koleksiyonel versiyonudur.
//Change Tracker mekanizmas� taraf�ndan izlenen her entity nesnesinin bigisini EntityEntry t�r�nden elde etmemizi sa�lar ve belirli i�lemler yapabilmemize olanak tan�r.
//Entries metodu, DetectChanges metodunu tetikler. Bu durum da t�pk� SaveChanges'da oldu�u gibi bir maliyettir. Buradaki maliyetten ka��nmak i�in AuthoDetectChangesEnabled �zelli�ine false de�eri verilebilir.

//var urunler = await context.Urunler.ToListAsync();
//urunler.FirstOrDefault(u => u.Id == 7).Fiyat = 123; //Update
//context.Urunler.Remove(urunler.FirstOrDefault(u => u.Id == 8)); //Delete
//urunler.FirstOrDefault(u => u.Id == 9).UrunAdi = "asdasd"; //Update

//context.ChangeTracker.Entries().ToList().ForEach(e =>
//{

//    if (e.State == EntityState.Unchanged)
//    {
//        //:..
//    }
//    else if (e.State == EntityState.Deleted)
//    {
//        //...
//    }
//    //...
//});
#endregion

#region AcceptAllChanges Metodu
//SaveChanges() veya SaveChanges(true) tetiklendi�inde EF Core her�eyin yolunda oldu�unu varsayarak track etti�i verilerin takibini keser yeni de�i�ikliklerin takip edilmesini bekler. B�yle bir durumda beklenmeyen bir durum/olas� bir hata s�z konusu olursa e�er EF Core takip etti�i nesneleri brakaca�� i�in bir d�zeltme mevzu bahis olamayacakt�r.

//Haliyle bu durumda devreye SaveChanges(false) ve AcceptAllChanges metotlar� girecektir.

//SaveChanges(False), EF Core'a gerekli veritaban� komutlar�n� y�r�tmesini s�yler ancak gerekti�inde yeniden oynat�labilmesi i�in de�i�ikleri beklemeye/nesneleri takip etmeye devam eder. Taa ki AcceptAllChanges metodunu irademizle �a��rana kadar!

//SaveChanges(false) ile i�lemin ba�ar�l� oldu�undan emin olursan�z AcceptAllChanges metodu ile nesnelerden takibi kesebilirsiniz.

//var urunler = await context.Urunler.ToListAsync();
//urunler.FirstOrDefault(u => u.Id == 7).Fiyat = 123; //Update
//context.Urunler.Remove(urunler.FirstOrDefault(u => u.Id == 8)); //Delete
//urunler.FirstOrDefault(u => u.Id == 9).UrunAdi = "asdasd"; //Update

//await context.SaveChangesAsync(false);
//context.ChangeTracker.AcceptAllChanges();

#endregion

#region HasChanges Metodu
//Takip edilen nesneler aras�ndan de�i�iklik yap�lanlar�n olup olmad���n�n bilgisini verir.
//Arkaplanda DetectChanges metodunu tetikler.
//var result = context.ChangeTracker.HasChanges();
#endregion

#region Entity States
//Entity nesnelerinin durumlar�n� ifade eder.

#region Detached
//Nesnenin change tracker mekanizmas� taraf�dnan takip edilmedi�ini ifade eder.
//Urun urun = new();
//Console.WriteLine(context.Entry(urun).State);
//urun.UrunAdi = "asdasd";
//await context.SaveChangesAsync();
#endregion

#region Added
//Veritaban�na eklenecek nesneyi ifade eder. Adeed hen�z veritaban�na i�lenmeyen veriyi ifade eder. SaveChanges fonksiyonu �a�r�ld���nda insert sorgusu olu�turucal���� anlam�n� gelir.
//Urun urun = new() { Fiyat = 123, UrunAdi = "�r�n 1001" };
//Console.WriteLine(context.Entry(urun).State);
//await context.Urunler.AddAsync(urun);
//Console.WriteLine(context.Entry(urun).State);
//await context.SaveChangesAsync();
//urun.Fiyat = 321;
//Console.WriteLine(context.Entry(urun).State);
//await context.SaveChangesAsync();
#endregion

#region Unchanged
//Veritaban�ndan sorguland���ndan beri nesne �zerinde herhangi bir de�i�iklik yap�lmad���n� ifade eder. Sorgu neticesinde elde edilen t�m nesneler ba�lang��ta bu state de�erindedir.
//var urunler = await context.Urunler.ToListAsync();

//var data = context.ChangeTracker.Entries();
//Console.WriteLine();
#endregion

#region Modified
//Nesne �zerinde de��iiklik/g�ncelleme yap�ld���n� ifade eder. SaveChanges fonksiyonu �a�r�ld���nda update sorgusu olu�turulaca�� anlam�na gelir.
//var urun = await context.Urunler.FirstOrDefaultAsync(u => u.Id == 3);
//Console.WriteLine(context.Entry(urun).State);
//urun.UrunAdi = "asdasdasdasdasd";
//Console.WriteLine(context.Entry(urun).State);
//await context.SaveChangesAsync(false);
//Console.WriteLine(context.Entry(urun).State);
#endregion

#region Deleted
//Nesnenin silindi�ini ifade eder. SaveChanges fonksiyonu �a�r�ld���nda delete sorgusu olu�turucula�� anlam�na gelir.
//var urun = await context.Urunler.FirstOrDefaultAsync(u => u.Id == 4);
//context.Urunler.Remove(urun);
//Console.WriteLine(context.Entry(urun).State);
//context.SaveChangesAsync();
#endregion
#endregion

#region Context Nesnesi �zerinden Change Tracker
//var urun = await context.Urunler.FirstOrDefaultAsync(u => u.Id == 55);
//urun.Fiyat = 123;
//urun.UrunAdi = "Silgi"; //Modified | Update

#region Entry Metodu55
#region OriginalValues Property'si
//var fiyat = context.Entry(urun).OriginalValues.GetValue<float>(nameof(Urun.Fiyat));
//var urunAdi = context.Entry(urun).OriginalValues.GetValue<string>(nameof(Urun.UrunAdi));
//Console.WriteLine();
#endregion

#region CurrentValues Property'si
//var urunAdi = context.Entry(urun).CurrentValues.GetValue<string>(nameof(Urun.UrunAdi));
#endregion

#region GetDatabaseValues Metodu
//var _urun = await context.Entry(urun).GetDatabaseValuesAsync();
#endregion
#endregion
#endregion

#region Change Tracker'�n Interceptor Olarak Kullan�lmas�

#endregion

public class ETicaretContext : DbContext
{
    public DbSet<Urun> Urunler { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Database=ETicaretDb3;TrustServerCertificate=True;Encrypt=False;Trusted_Connection=True;Trusted_Connection=True");
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries();
        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {

            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}
public class Urun
{
    public int Id { get; set; }
    public string UrunAdi { get; set; }
    public float Fiyat { get; set; }
}