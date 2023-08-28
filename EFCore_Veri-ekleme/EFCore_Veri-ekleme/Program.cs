

//Migrate ba�ar�l� diyor ama migrate etmiyor nedenini sor!?


using Microsoft.EntityFrameworkCore;



Console.Read();
ApplicationDbContext context = new();

#region One to One �li�kisel Senaryolarda Veri Ekleme
#region 1. Y�ntem -> Principal Entity �zerinden Dependent Entity Verisi Ekleme
Person person = new();
person.Name = "H�seyin";
person.Address = new() { PersonAddress = "Etimesgut/ANKARA" };

await context.AddAsync(person);
await context.SaveChangesAsync();
#endregion

//E�er ki principal entity �zerinden ekleme ger�ekle�tiriliyorsa dependent entity nesnesi verilmek zorunda de�ildir! Amma velakin, dependent entity �zerinden ekleme i�lemi ger�ekle�tiriliyorsa e�er burada principal entitynin nesnesine ihtiyac�m�z zaruridir.

#region 2. Y�ntem -> Dependent Entity �zerinden Principal Entity Verisi Ekleme
Address address = new()
{
    PersonAddress = "Papaz Deresi/Ankara",
   Person = new() { Name = "�uayip" }
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