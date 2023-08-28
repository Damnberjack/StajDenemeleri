using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

ApplicationDbContext context = new();

#region EF Core'da Neden Yap�land�rmalara �htiyac�m�z Olur?
//Default davran��lar� yeri geldi�inde ge�ersiz k�lmak ve �zelle�tirmek isteyebiliriz. Bundan dolay� yap�land�rmalara ihtiyac�m�z olacakt�r.
#endregion

#region OnModelCreating Metodu
//EF Core'da yap�land�rma deyince akla ilk gelen metot OnModelCreating metodudur.
//Bu metot, DbContext s�n�f� i�erisinde virtual olarak ayarlanm�� bir metottur.
//Bizler bu metodu kullanarak model'lar�m�zla ilgili temel konfig�rasyonel davran��lar�(Fluent API) sergileyeibliriz.
//Bir model'�n yarat�l���yla ilgili t�m konfig�rasyonlar� burada ger�ekle�tirebilmekteyiz.

#region GetEntityTypes
//EF Core'da kullan�lan entity'leri elde etmek, programatik olarak ��renmek istiyorsak e�er GetEntityTypes fonksiyonunu kullanabiliriz.
#endregion

#endregion

#region Configurations | Data Annotations & Fluent API

#region Table - ToTable
//Generate edilecek tablonun ismini belirlememizi sa�layan yap�land�rmad�r.
//Ef Core normal �artlarda generate edece�i tablonun ad�n� DbSet property'sinden almaktad�r. Bizler e�er ki bunu �zelle�tirmek istiyorsak Table attribute'unu yahut ToTable api'�n� kullanabilriiz.
#endregion

#region Column - HasColumnName, HasColumnType, HasColumnOrder
//EF Core'da tablolar�n kolonlar� entity s�n�flar� i�erisindeki property'lere kar��l�k gelmektedir. 
//Default olarak property'lerin ad� kolon ad�yken, t�rleri/tipleri kolon t�rleridir.
//E�er ki generate edilecek kolon isimlerine ve t�rlerine m�dahale etmek sitiyorsak bu konfig�rasyon kullan�l�r.
#endregion

#region ForeignKey - HasForeignKey
//�li�kisel tablo tasar�mlar�nda, ba��ml� tabloda esas tabloya kar��l�k gelecek verilerin tutuldu�u kolonu foreign key olarak temsil etmekteyiz.
//EF Core'da foreign key kolonu genellikle Entity Tna�mlama kurallar� gere�i default yap�lanmalarla olu�turulur.
//ForeignKey Data Annotations Attribute'unu direkt kullanabilirsiniz. Lakin Fluent api ile bu konfig�rasyonu yapacaksan�z iki entity aras�ndaki ili�kiyide modellemeniz gerekmektedir. Aksi taktirde fluent api �zerinde HasForeignKey fonksiyonunu kullanamnazs�n�z!
#endregion

#region NotMapped - Ignore
//EF Core, entity s�n�flar� i�erisindeki t�m proeprtyleri default olarak modellenen tabloya kolon �eklinde migrate eder.
//Bazn bizler entity s�n�flar� i�erisinde tabloda bir kolona kar��l�k gelmeyen propertyler tan�mlamak mecburiyetinde kalabiliriz.
//Bu property'lerin ef core taraf�ndan kolon olarak map edilmesini istemedi�imizi bildirebilmek i�in NotMapped ya da Ignore kullanabiliriz.
#endregion

#region Key - HasKey
//EF Core'da, default convention olarak bir entity'nin i�erisinde Id, ID, EntityId, EntityID vs. �eklinde tan�mlanan t�m proeprtylere varsay�lan olarak primary key constraint uygulan�r.
//Key ya da HasKey yap�lanmalar�yla istedi�inmiz her hangi bir proeprty'e default convention d���nda pk uygulayabiliriz.
//EF Core'da bir entity i�erisinde kesinlikle PK'i temsil edecek olan property bulunmal�d�r. Aksi taktirde EF Core migration olut�urken hata verecektir. E�er ki tablonun PK'i yoksa bunun bildirilmesi gerekir. 
#endregion

#region Timestamp - IsRowVersion
//�leride/sonraki derlerde veri tutarl�l��� ile ilgili bir ders yapaca��z.
//Bu derste bir sat�rdaki verinin b�t�nsel olarak de�i�ikli�ini takip etmemizi sa�layacak olan verisyon mant���n� konu�uyor olaca��z.
//��te bir verinin verisyonunu olu�turmam�z� sa�layan yap�lanma bu konfig�rasyonlard�r.
#endregion

#region Required - IsRequired
//Bir kolonun nullable ya da not null olup olmamas�n� bu konfig�rasyonla belirleyebiliriz.
//EF Core'da bir property default oalrak not null �eklinde tan�mlan�r. E�er ki property'si nullable yapmak istyorsak t�r� �zerinde ?(nullable) operat�r� ile bbildirimde bulunmam�z gerekmektedir.
#endregion

#region MaxLenght | StringLength - HasMaxLength
//Bir kolonun max karakter say�s�n� belirlememizi sa�lar.
#endregion

#region Precision - HasPrecision
//K�s�ratl� say�larda bir kesinlik belirtmemizi ve noktan�n hanesini bildirmemizi sa�layan bir yap�land�rmad�r.
#endregion

#region Unicode - IsUnicode
//Kolon i�erisinde unicode karakterler kullan�lacaksa bu yap�land�rmadan istifade edilebilir.
#endregion

#region Comment - HasComment
//EF Core �zerinden olu�turulmu� olan veritaban� nesneleri �zerinde bir a��kalama/yorum yapmak istiyorsan�z Comment'i kullanblirsiniz.
#endregion

#region ConcurrencyCheck - IsConcurrencyToken
//�leride/sonraki derlerde veri tutarl�l��� ile ilgili bir ders yapaca��z.
//Bu derste bir sat�rdaki verinin b�t�nsel olarak tutarl�l���n� sa�layacak bir concurrency token yap�lanmas�ndan bahsecece�iz.
#endregion

#region InverseProperty
//�ki entity aras�nda birden fazla ili�ki varsa e�er bu ili�kilerin hangi navigation property �zerinden o�laca��n� ayarlamam�z� sa�layan bir konfigrasyondur.
#endregion

#endregion

#region Configurations | Fluent API

#region Composite Key
//Tablolarda birden fazla kolonu k�m�latif olarak primary key yapmak istiyorsak buna composite key denir.
#endregion

#region HasDefaultSchema
//EF Core �zerinden in�a edilen herhangi bir veritaban� nesnesi default olarak dbo �emas�na sahiptir. Bunu �zelle�tirebilmek i�in kullan�lan bir yap�land�rmad�r.
#endregion

#region Property

#region HasDefaultValue
//Tablodaki herhangi bir kolonun de�er g�nderilmedi�i durumlarda default olarak hangi de�eri alaca��n� belirler.
#endregion

#region HasDefaultValueSql
//Tablodaki herhangi bir kolonun de�er g�nderilmedi�i durumlarda default olarak hangi sql c�mleci�inden de�eri alaca��n� belirler.
#endregion

#endregion

#region HasComputedColumnSql
//Tablolarda birden fazla kolondaki veirleri i�leyerek de�erini olu�turan kolonlara Computed Column denmektedir. EF Core �zerinden bu tarz computed column olu�turabilmek i�in kullan�olan bir yap�land�rmad�r.
#endregion

#region HasConstraintName
//EF Core �zerinden olu�turulkan constraint'lere default isim yerine �zelle�tirilmi� bir isim verebilmek i�in kullan�lan yap�land�rmad�r.
#endregion

#region HasData
//Sonraki derslerimizde Seed Data isimli bir konuyu incleyece�iz. Bu konuda migrate s�recinde veritaban�n� in�a ederken bir yandan da yaz�l�m �zerinden haz�r veriler olu�turmak istiyorsak e�er buunun y�ntemini usul�n� inceliyor olaca��z.
//��te HasData konfig�rasyonu bu operasyonun yap�land�rma aya��d�r.
//HasData ile migrate s�recinde olu�turulacak olan verilerin pk olan id kolonlar�na iradeli bir �ekilde de�erlerin girilmesi zorunludur!
#endregion

#region HasDiscriminator
//�leride entityler aras�nda kal�t�msal ili�kilerin oldu�u TPT ve TPH isminde konular� inceliyor olaca��z. ��te bu konularla ilgili yap�land�rmalar�m�z HasDiscriminator ve HasValue fonksiyonlar�d�r.

#region HasValue

#endregion

#endregion

#region HasField
//Backing Field �zelli�ini kullanmam�z� sa�layan bir yap�land�rmad�r.
#endregion

#region HasNoKey
//Normal �artlarda EF Core'da t�m entitylerin bir PK kolonu olmak zorundad�r. E�er ki entity'de pk kolonu olmayacaksa bunun bildirilmesi gerekmektedir! ��te bunun i�in kullanu�lan fonksiyondur.
#endregion

#region HasIndex
//Sonraki derslerimizde EF Core �zerinden Index yap�lanmas�n� detayl�ca inceliyor olaca��z.
//Bu yp�lanmaya dair konfig�rasyonlar�m�z HasIndex ve Index attribute'dur.
#endregion

#region HasQueryFilter
//�leride g�rece�imiz Global QUery Filter ba�l�kl� dersimizin yap�land�rmas�d�r.
//Temeldeki g�revi bir entitye kar��l�k uygulama baz�nda global bir filtre koymakt�r.
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
    //Yaz�l�msal ama�la olu�turdu�um bir property
    //[NotMapped]
    //public string Laylaylom { get; set; }

    [Timestamp]
    //[Comment("Bu �una yaramaktad�r...")]
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
        //        .HasComment("Bu tablo �una yaramaktad�r...")
        //    .Property(p => p.Surname)
        //        .HasComment("Bu kolon �una yaramaktad�r.");
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