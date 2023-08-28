

//Migrate baþarýlý diyor ama migrate etmiyor nedenini sor!?


using Microsoft.EntityFrameworkCore;



Console.Read();
ApplicationDbContext context = new();

#region One to One Ýliþkisel Senaryolarda Veri Ekleme
#region 1. Yöntem -> Principal Entity Üzerinden Dependent Entity Verisi Ekleme
Person person = new();
person.Name = "Hüseyin";
person.Address = new() { PersonAddress = "Etimesgut/ANKARA" };

await context.AddAsync(person);
await context.SaveChangesAsync();
#endregion

//Eðer ki principal entity üzerinden ekleme gerçekleþtiriliyorsa dependent entity nesnesi verilmek zorunda deðildir! Amma velakin, dependent entity üzerinden ekleme iþlemi gerçekleþtiriliyorsa eðer burada principal entitynin nesnesine ihtiyacýmýz zaruridir.

#region 2. Yöntem -> Dependent Entity Üzerinden Principal Entity Verisi Ekleme
Address address = new()
{
    PersonAddress = "Papaz Deresi/Ankara",
   Person = new() { Name = "Þuayip" }
};

await context.AddAsync(address);
await context.SaveChangesAsync();
#endregion

class Person
{
    public int Id { get; set; }
   public string Name { get; set; }

  public Address Address { get; set; }
}
class Address
{
    public int Id { get; set; }
    public string PersonAddress { get; set; }

   public Person Person { get; set; }
}
class ApplicationDbContext : DbContext
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<Address> Addresses { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Database=ApplicationDb;TrustServerCertificate=True;Encrypt=False;Trusted_Connection=True;Trusted_Connection=True");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>()
           .HasOne(a => a.Person)
           .WithOne(p => p.Address)
           .HasForeignKey<Address>(a => a.Id);
    }
}
#endregion