using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

ApplicationDbContext context = new();

#region EF Core'da Neden Yapýlandýrmalara Ýhtiyacýmýz Olur?
//Default davranýþlarý yeri geldiðinde geçersiz kýlmak ve özelleþtirmek isteyebiliriz. Bundan dolayý yapýlandýrmalara ihtiyacýmýz olacaktýr.
#endregion

#region OnModelCreating Metodu
//EF Core'da yapýlandýrma deyince akla ilk gelen metot OnModelCreating metodudur.
//Bu metot, DbContext sýnýfý içerisinde virtual olarak ayarlanmýþ bir metottur.
//Bizler bu metodu kullanarak model'larýmýzla ilgili temel konfigürasyonel davranýþlarý(Fluent API) sergileyeibliriz.
//Bir model'ýn yaratýlýþýyla ilgili tüm konfigürasyonlarý burada gerçekleþtirebilmekteyiz.

#region GetEntityTypes
//EF Core'da kullanýlan entity'leri elde etmek, programatik olarak öðrenmek istiyorsak eðer GetEntityTypes fonksiyonunu kullanabiliriz.
#endregion

#endregion

#region Configurations | Data Annotations & Fluent API

#region Table - ToTable
//Generate edilecek tablonun ismini belirlememizi saðlayan yapýlandýrmadýr.
//Ef Core normal þartlarda generate edeceði tablonun adýný DbSet property'sinden almaktadýr. Bizler eðer ki bunu özelleþtirmek istiyorsak Table attribute'unu yahut ToTable api'ýný kullanabilriiz.
#endregion

#region Column - HasColumnName, HasColumnType, HasColumnOrder
//EF Core'da tablolarýn kolonlarý entity sýnýflarý içerisindeki property'lere karþýlýk gelmektedir. 
//Default olarak property'lerin adý kolon adýyken, türleri/tipleri kolon türleridir.
//Eðer ki generate edilecek kolon isimlerine ve türlerine müdahale etmek sitiyorsak bu konfigürasyon kullanýlýr.
#endregion

#region ForeignKey - HasForeignKey
//Ýliþkisel tablo tasarýmlarýnda, baðýmlý tabloda esas tabloya karþýlýk gelecek verilerin tutulduðu kolonu foreign key olarak temsil etmekteyiz.
//EF Core'da foreign key kolonu genellikle Entity Tnaýmlama kurallarý gereði default yapýlanmalarla oluþturulur.
//ForeignKey Data Annotations Attribute'unu direkt kullanabilirsiniz. Lakin Fluent api ile bu konfigürasyonu yapacaksanýz iki entity arasýndaki iliþkiyide modellemeniz gerekmektedir. Aksi taktirde fluent api üzerinde HasForeignKey fonksiyonunu kullanamnazsýnýz!
#endregion

#region NotMapped - Ignore
//EF Core, entity sýnýflarý içerisindeki tüm proeprtyleri default olarak modellenen tabloya kolon þeklinde migrate eder.
//Bazn bizler entity sýnýflarý içerisinde tabloda bir kolona karþýlýk gelmeyen propertyler tanýmlamak mecburiyetinde kalabiliriz.
//Bu property'lerin ef core tarafýndan kolon olarak map edilmesini istemediðimizi bildirebilmek için NotMapped ya da Ignore kullanabiliriz.
#endregion

#region Key - HasKey
//EF Core'da, default convention olarak bir entity'nin içerisinde Id, ID, EntityId, EntityID vs. þeklinde tanýmlanan tüm proeprtylere varsayýlan olarak primary key constraint uygulanýr.
//Key ya da HasKey yapýlanmalarýyla istediðinmiz her hangi bir proeprty'e default convention dýþýnda pk uygulayabiliriz.
//EF Core'da bir entity içerisinde kesinlikle PK'i temsil edecek olan property bulunmalýdýr. Aksi taktirde EF Core migration olutþurken hata verecektir. Eðer ki tablonun PK'i yoksa bunun bildirilmesi gerekir. 
#endregion

#region Timestamp - IsRowVersion
//Ýleride/sonraki derlerde veri tutarlýlýðý ile ilgili bir ders yapacaðýz.
//Bu derste bir satýrdaki verinin bütünsel olarak deðiþikliðini takip etmemizi saðlayacak olan verisyon mantýðýný konuþuyor olacaðýz.
//Ýþte bir verinin verisyonunu oluþturmamýzý saðlayan yapýlanma bu konfigürasyonlardýr.
#endregion

#region Required - IsRequired
//Bir kolonun nullable ya da not null olup olmamasýný bu konfigürasyonla belirleyebiliriz.
//EF Core'da bir property default oalrak not null þeklinde tanýmlanýr. Eðer ki property'si nullable yapmak istyorsak türü üzerinde ?(nullable) operatörü ile bbildirimde bulunmamýz gerekmektedir.
#endregion

#region MaxLenght | StringLength - HasMaxLength
//Bir kolonun max karakter sayýsýný belirlememizi saðlar.
#endregion

#region Precision - HasPrecision
//Küsüratlý sayýlarda bir kesinlik belirtmemizi ve noktanýn hanesini bildirmemizi saðlayan bir yapýlandýrmadýr.
#endregion

#region Unicode - IsUnicode
//Kolon içerisinde unicode karakterler kullanýlacaksa bu yapýlandýrmadan istifade edilebilir.
#endregion

#region Comment - HasComment
//EF Core üzerinden oluþturulmuþ olan veritabaný nesneleri üzerinde bir açýkalama/yorum yapmak istiyorsanýz Comment'i kullanblirsiniz.
#endregion

#region ConcurrencyCheck - IsConcurrencyToken
//Ýleride/sonraki derlerde veri tutarlýlýðý ile ilgili bir ders yapacaðýz.
//Bu derste bir satýrdaki verinin bütünsel olarak tutarlýlýðýný saðlayacak bir concurrency token yapýlanmasýndan bahsececeðiz.
#endregion

#region InverseProperty
//Ýki entity arasýnda birden fazla iliþki varsa eðer bu iliþkilerin hangi navigation property üzerinden oýlacaðýný ayarlamamýzý saðlayan bir konfigrasyondur.
#endregion

#endregion

#region Configurations | Fluent API

#region Composite Key
//Tablolarda birden fazla kolonu kümülatif olarak primary key yapmak istiyorsak buna composite key denir.
#endregion

#region HasDefaultSchema
//EF Core üzerinden inþa edilen herhangi bir veritabaný nesnesi default olarak dbo þemasýna sahiptir. Bunu özelleþtirebilmek için kullanýlan bir yapýlandýrmadýr.
#endregion

#region Property

#region HasDefaultValue
//Tablodaki herhangi bir kolonun deðer gönderilmediði durumlarda default olarak hangi deðeri alacaðýný belirler.
#endregion

#region HasDefaultValueSql
//Tablodaki herhangi bir kolonun deðer gönderilmediði durumlarda default olarak hangi sql cümleciðinden deðeri alacaðýný belirler.
#endregion

#endregion

#region HasComputedColumnSql
//Tablolarda birden fazla kolondaki veirleri iþleyerek deðerini oluþturan kolonlara Computed Column denmektedir. EF Core üzerinden bu tarz computed column oluþturabilmek için kullanýolan bir yapýlandýrmadýr.
#endregion

#region HasConstraintName
//EF Core üzerinden oluþturulkan constraint'lere default isim yerine özelleþtirilmiþ bir isim verebilmek için kullanýlan yapýlandýrmadýr.
#endregion

#region HasData
//Sonraki derslerimizde Seed Data isimli bir konuyu incleyeceðiz. Bu konuda migrate sürecinde veritabanýný inþa ederken bir yandan da yazýlým üzerinden hazýr veriler oluþturmak istiyorsak eðer buunun yöntemini usulünü inceliyor olacaðýz.
//Ýþte HasData konfigürasyonu bu operasyonun yapýlandýrma ayaðýdýr.
//HasData ile migrate sürecinde oluþturulacak olan verilerin pk olan id kolonlarýna iradeli bir þekilde deðerlerin girilmesi zorunludur!
#endregion

#region HasDiscriminator
//Ýleride entityler arasýnda kalýtýmsal iliþkilerin olduðu TPT ve TPH isminde konularý inceliyor olacaðýz. Ýþte bu konularla ilgili yapýlandýrmalarýmýz HasDiscriminator ve HasValue fonksiyonlarýdýr.

#region HasValue

#endregion

#endregion

#region HasField
//Backing Field özelliðini kullanmamýzý saðlayan bir yapýlandýrmadýr.
#endregion

#region HasNoKey
//Normal þartlarda EF Core'da tüm entitylerin bir PK kolonu olmak zorundadýr. Eðer ki entity'de pk kolonu olmayacaksa bunun bildirilmesi gerekmektedir! Ýþte bunun için kullanuýlan fonksiyondur.
#endregion

#region HasIndex
//Sonraki derslerimizde EF Core üzerinden Index yapýlanmasýný detaylýca inceliyor olacaðýz.
//Bu ypýlanmaya dair konfigürasyonlarýmýz HasIndex ve Index attribute'dur.
#endregion

#region HasQueryFilter
//Ýleride göreceðimiz Global QUery Filter baþlýklý dersimizin yapýlandýrmasýdýr.
//Temeldeki görevi bir entitye karþýlýk uygulama bazýnda global bir filtre koymaktýr.
#endregion

#region DatabaseGenerated - ValueGeneratedOnAddOrUpdate, ValueGeneratedOnAdd, ValueGeneratedNever

#endregion
#endregion



//[Table("Kisiler")]
class Person
{
    //[Key]
    public int Id { get; set; }
    //public int Id2 { get; set; }
    //[ForeignKey(nameof(Department))]
    //public int DId { get; set; }
    //[Column("Adi", TypeName = "metin", Order = 7)]
    public int DepartmentId { get; set; }
    public string _name;
    public string Name { get => _name; set => _name = value; }
    //[Required()]
    //[MaxLength(13)]
    //[StringLength(14)]
    [Unicode]
    public string? Surname { get; set; }
    //[Precision(5, 3)]
    public decimal Salary { get; set; }
    //Yazýlýmsal amaçla oluþturduðum bir property
    //[NotMapped]
    //public string Laylaylom { get; set; }

    [Timestamp]
    //[Comment("Bu þuna yaramaktadýr...")]
    public byte[] RowVersion { get; set; }

    //[ConcurrencyCheck]
    //public int ConcurrencyCheck { get; set; }

    public DateTime CreatedDate { get; set; }
    public Department Department { get; set; }
}
class Department
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<Person> Persons { get; set; }
}
class Example
{

    public int X { get; set; }
    public int Y { get; set; }
    public int Computed { get; set; }
}
class Entity
{
    public int Id { get; set; }
    public string X { get; set; }
}
class A : Entity
{
    public int Y { get; set; }
}
class B : Entity
{
    public int Z { get; set; }
}
class ApplicationDbContext : DbContext
{
    //public DbSet<Entity> Entities { get; set; }
    //public DbSet<A> As { get; set; }
    //public DbSet<B> Bs { get; set; }

    public DbSet<Person> Persons { get; set; }
    public DbSet<Department> Departments { get; set; }
    //public DbSet<Flight> Flights { get; set; }
    //public DbSet<Airport> Airports { get; set; }
    public DbSet<Example> Examples { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region GetEntityTypes
       // var entities = modelBuilder.Model.GetEntityTypes();
       // foreach (var entity in entities)
       // {
       //    Console.WriteLine(entity.Name);
      //  }
        #endregion
        #region ToTable
        //modelBuilder.Entity<Person>().ToTable("aksdmkasmdk");
        #endregion
        #region Column
        //modelBuilder.Entity<Person>()
        //    .Property(p => p.Name)
        //    .HasColumnName("Adi")
        //    .HasColumnType("asldalsd")
        //    .HasColumnOrder(7);
        #endregion
        #region ForeignKey
        //modelBuilder.Entity<Person>()
        //    .HasOne(p => p.Department)
        //    .WithMany(d => d.Persons)
        //    .HasForeignKey(p => p.DId);
        #endregion
        #region Ignore
        //modelBuilder.Entity<Person>()
        //    .Ignore(p => p.Laylaylom);
        #endregion
        #region Primary Key
        //modelBuilder.Entity<Person>()
        //    .HasKey(p => p.Id);
        #endregion
        #region IsRowVersion
        //modelBuilder.Entity<Person>()
        //    .Property(p => p.RowVersion)
        //    .IsRowVersion();
        #endregion
        #region Required
        //modelBuilder.Entity<Person>()
        //    .Property(p => p.Surname).IsRequired();
        #endregion
        #region MaxLength
        //modelBuilder.Entity<Person>()
        //    .Property(p => p.Surname)
        //    .HasMaxLength(13);
        #endregion
        #region Precision
        //modelBuilder.Entity<Person>()
        //    .Property(p => p.Salary)
        //    .HasPrecision(5, 3);
        #endregion
        #region Unicode
        //modelBuilder.Entity<Person>()
        //    .Property(p => p.Surname)
        //    .IsUnicode();
        #endregion
        #region Comment
        //modelBuilder.Entity<Person>()
        //        .HasComment("Bu tablo þuna yaramaktadýr...")
        //    .Property(p => p.Surname)
        //        .HasComment("Bu kolon þuna yaramaktadýr.");
        #endregion
        #region ConcurrencyCheck
        //modelBuilder.Entity<Person>()
        //    .Property(p => p.ConcurrencyCheck)
        //    .IsConcurrencyToken();
        #endregion
        #region CompositeKey
        //modelBuilder.Entity<Person>().HasKey("Id", "Id2");
        //modelBuilder.Entity<Person>().HasKey(p => new { p.Id, p.Id2 });
        #endregion
        #region HasDefaultSchema
        //modelBuilder.HasDefaultSchema("ahmet");
        #endregion
        #region Property
        #region HasDefaultValue
        //modelBuilder.Entity<Person>()
        // .Property(p => p.Salary)
        // .HasDefaultValue(100);
        #endregion
        #region HasDefaultValueSql
        //modelBuilder.Entity<Person>()
        //    .Property(p => p.CreatedDate)
        //    .HasDefaultValueSql("GETDATE()");
        #endregion
        #endregion
        #region HasComputedColumnSql
        //modelBuilder.Entity<Example>()
        //    .Property(p => p.Computed)
        //    .HasComputedColumnSql("[X] + [Y]");
        #endregion
        #region HasConstraintName
        //modelBuilder.Entity<Person>()
        //    .HasOne(p => p.Department)
        //    .WithMany(d => d.Persons)
        //    .HasForeignKey(p => p.DepartmentId)
        //    .HasConstraintName("ahmet");
        #endregion
        #region HasData
        //modelBuilder.Entity<Department>().HasData(
        //    new Department()
        //    {
        //        Name = "asd",
        //        Id = 1
        //    });
        //modelBuilder.Entity<Person>().HasData(
        //    new Person
        //    {
        //        Id = 1,
        //        DepartmentId = 1,
        //        Name = "ahmet",
        //        Surname = "filanca",
        //        Salary = 100,
        //        CreatedDate = DateTime.Now
        //    },
        //    new Person
        //    {
        //        Id = 2,
        //        DepartmentId = 1,
        //        Name = "mehmet",
        //        Surname = "filanca",
        //        Salary = 200,
        //        CreatedDate = DateTime.Now
        //    }
        //    );
        #endregion
        #region HasDiscriminator
        //modelBuilder.Entity<Entity>()
        //    .HasDiscriminator<int>("Ayirici")
        //    .HasValue<A>(1)
        //    .HasValue<B>(2)
        //    .HasValue<Entity>(3);

        #endregion
        #region HasField
        //modelBuilder.Entity<Person>()
        //    .Property(p => p.Name)
        //    .HasField(nameof(Person._name));
        #endregion
        #region HasNoKey
        //modelBuilder.Entity<Example>()
        //    .HasNoKey();
        #endregion
        #region HasIndex
        //modelBuilder.Entity<Person>()
        //    .HasIndex(p => new { p.Name, p.Surname });
        #endregion
        #region HasQueryFilter
        //modelBuilder.Entity<Person>()
        //    .HasQueryFilter(p => p.CreatedDate.Year == DateTime.Now.Year);
        #endregion
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost, 1433;Database=ApplicationDb;User ID=SA;Password=1q2w3e4r+!");
    }
}

public class Flight
{
    public int FlightID { get; set; }
    public int DepartureAirportId { get; set; }
    public int ArrivalAirportId { get; set; }
    public string Name { get; set; }
    public Airport DepartureAirport { get; set; }
    public Airport ArrivalAirport { get; set; }
}

public class Airport
{
    public int AirportID { get; set; }
    public string Name { get; set; }
    [InverseProperty(nameof(Flight.DepartureAirport))]
    public virtual ICollection<Flight> DepartingFlights { get; set; }

    [InverseProperty(nameof(Flight.ArrivalAirport))]
    public virtual ICollection<Flight> ArrivingFlights { get; set; }
}