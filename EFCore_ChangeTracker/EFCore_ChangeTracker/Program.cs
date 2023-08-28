using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

ETicaretContext context = new();
#region Change Tracking Neydi?
//Context nesnesi üzerinden gelen tüm nesneler/veriler otomatik olarak bir takip mekanizmasý tarafýndan izlenirler. Ýþte bu takip mekanizmasýna Change Tracker denir. Change Traker ile nesneler üzerindeki deðiþiklikler/iþlemler takip edilerek netice itibariyle bu iþlemlerin fýtratýna uygun sql sorgucuklarý generate edilir. Ýþte bu iþleme de Change Tracking denir. 
#endregion

#region ChangeTracker Propertysi
//Takip edilen nesnelere eriþebilmemizi saðlayan ve gerektiði taktirde iþlemler gerçekþetirmemizi saðlayan bir propertydir.
//Context sýnýfýnýn base class'ý olan DbContext sýnýfýnýn bir member'ýdýr.

//var urunler = await context.Urunler.ToListAsync();
//urunler[6].Fiyat = 123; //Update
//context.Urunler.Remove(urunler[7]); //Delete
//urunler[8].UrunAdi = "asdasd"; //Update


//var datas = context.ChangeTracker.Entries();

//await context.SaveChangesAsync();
//Console.WriteLine();
#endregion

#region DetectChanges Metodu
//EF Core, context nesnesi tarafýndan izlenen tüm nesnelerdeki deðiþiklikleri Change Tracker sayesinde takip edebilmekte ve nesnelerde olan verisel deðiþiklikler yakalanarak bunlarýn anlýk görüntüleri(snapshot)'ini oluþturabilir.
//Yapýlan deðiþikliklerin veritabanýna gönderilmeden önce algýlandýðýndan emin olmak gerekir. SaveChanges fonksiyonu çaðrýldýðý anda nesneler EF Core tarafýndan otomatik kontrol edilirler.
//Ancak, yapýlan operasyonlarda güncel tracking verilerinden emin olabilmek için deðiþiþiklerin algýulanmasýný opsiyonel olarak gerçekleþtirmek isteyebiliriz. Ýþte bunun için DetectChanges fonksiyonu kullanýlabilir ve her ne kadar EF Core deðiþikleri otomatik algýlýyor olsa da siz yine de iradenizle kontrole zorlayabilirsiniz.

//var urun = await context.Urunler.FirstOrDefaultAsync(u => u.Id == 3);
//urun.Fiyat = 123;

//context.ChangeTracker.DetectChanges();
//await context.SaveChangesAsync();

#endregion

#region AutoDetectChangesEnabled Property'si
//Ýlgili metotlar(SaveChanges, Entries) tarafýndan DetectChanges metodunun otomatik olarak tetiklenmesinin konfigürasyonunu yapmamýzý saðlayan proeportydir.
//SaveChanges fonksiyonu tetiklendiðinde DetectChanges metodunu içerisinde default olarak çaðýrmaktadýr. Bu durumda DetectChanges fonksiyonunun kullanýmýný irademizle yönetmek ve maliyet/performans optimizasyonu yapmak istediðimiz durumlarda AutoDetectChangesEnabled özelliðini kapatabiliriz.
#endregion

#region Entries Metodu
//Context'te ki Entry metodunun koleksiyonel versiyonudur.
//Change Tracker mekanizmasý tarafýndan izlenen her entity nesnesinin bigisini EntityEntry türünden elde etmemizi saðlar ve belirli iþlemler yapabilmemize olanak tanýr.
//Entries metodu, DetectChanges metodunu tetikler. Bu durum da týpký SaveChanges'da olduðu gibi bir maliyettir. Buradaki maliyetten kaçýnmak için AuthoDetectChangesEnabled özelliðine false deðeri verilebilir.

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
//SaveChanges() veya SaveChanges(true) tetiklendiðinde EF Core herþeyin yolunda olduðunu varsayarak track ettiði verilerin takibini keser yeni deðiþikliklerin takip edilmesini bekler. Böyle bir durumda beklenmeyen bir durum/olasý bir hata söz konusu olursa eðer EF Core takip ettiði nesneleri brakacaðý için bir düzeltme mevzu bahis olamayacaktýr.

//Haliyle bu durumda devreye SaveChanges(false) ve AcceptAllChanges metotlarý girecektir.

//SaveChanges(False), EF Core'a gerekli veritabaný komutlarýný yürütmesini söyler ancak gerektiðinde yeniden oynatýlabilmesi için deðiþikleri beklemeye/nesneleri takip etmeye devam eder. Taa ki AcceptAllChanges metodunu irademizle çaðýrana kadar!

//SaveChanges(false) ile iþlemin baþarýlý olduðundan emin olursanýz AcceptAllChanges metodu ile nesnelerden takibi kesebilirsiniz.

//var urunler = await context.Urunler.ToListAsync();
//urunler.FirstOrDefault(u => u.Id == 7).Fiyat = 123; //Update
//context.Urunler.Remove(urunler.FirstOrDefault(u => u.Id == 8)); //Delete
//urunler.FirstOrDefault(u => u.Id == 9).UrunAdi = "asdasd"; //Update

//await context.SaveChangesAsync(false);
//context.ChangeTracker.AcceptAllChanges();

#endregion

#region HasChanges Metodu
//Takip edilen nesneler arasýndan deðiþiklik yapýlanlarýn olup olmadýðýnýn bilgisini verir.
//Arkaplanda DetectChanges metodunu tetikler.
//var result = context.ChangeTracker.HasChanges();
#endregion

#region Entity States
//Entity nesnelerinin durumlarýný ifade eder.

#region Detached
//Nesnenin change tracker mekanizmasý tarafýdnan takip edilmediðini ifade eder.
//Urun urun = new();
//Console.WriteLine(context.Entry(urun).State);
//urun.UrunAdi = "asdasd";
//await context.SaveChangesAsync();
#endregion

#region Added
//Veritabanýna eklenecek nesneyi ifade eder. Adeed henüz veritabanýna iþlenmeyen veriyi ifade eder. SaveChanges fonksiyonu çaðrýldýðýnda insert sorgusu oluþturucalþýðý anlamýný gelir.
//Urun urun = new() { Fiyat = 123, UrunAdi = "Ürün 1001" };
//Console.WriteLine(context.Entry(urun).State);
//await context.Urunler.AddAsync(urun);
//Console.WriteLine(context.Entry(urun).State);
//await context.SaveChangesAsync();
//urun.Fiyat = 321;
//Console.WriteLine(context.Entry(urun).State);
//await context.SaveChangesAsync();
#endregion

#region Unchanged
//Veritabanýndan sorgulandýðýndan beri nesne üzerinde herhangi bir deðiþiklik yapýlmadýðýný ifade eder. Sorgu neticesinde elde edilen tüm nesneler baþlangýçta bu state deðerindedir.
//var urunler = await context.Urunler.ToListAsync();

//var data = context.ChangeTracker.Entries();
//Console.WriteLine();
#endregion

#region Modified
//Nesne üzerinde deðþiiklik/güncelleme yapýldýðýný ifade eder. SaveChanges fonksiyonu çaðrýldýðýnda update sorgusu oluþturulacaðý anlamýna gelir.
//var urun = await context.Urunler.FirstOrDefaultAsync(u => u.Id == 3);
//Console.WriteLine(context.Entry(urun).State);
//urun.UrunAdi = "asdasdasdasdasd";
//Console.WriteLine(context.Entry(urun).State);
//await context.SaveChangesAsync(false);
//Console.WriteLine(context.Entry(urun).State);
#endregion

#region Deleted
//Nesnenin silindiðini ifade eder. SaveChanges fonksiyonu çaðrýldýðýnda delete sorgusu oluþturuculaðý anlamýna gelir.
//var urun = await context.Urunler.FirstOrDefaultAsync(u => u.Id == 4);
//context.Urunler.Remove(urun);
//Console.WriteLine(context.Entry(urun).State);
//context.SaveChangesAsync();
#endregion
#endregion

#region Context Nesnesi Üzerinden Change Tracker
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

#region Change Tracker'ýn Interceptor Olarak Kullanýlmasý

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