using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection;



Console.WriteLine();


class Order
{
    public int OrderId { get; set; }
    public string Description { get; set; }
    public DateTime OrderDate { get; set; }
}

class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.OrderId);
        builder.Property(p => p.Description)
            .HasMaxLength(13);
        builder.Property(p => p.OrderDate)
            .HasDefaultValueSql("GETDATE()");
    }
}

class ApplicationDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.ApplyConfiguration(new OrderConfiguration());      
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Database=EticaretDb;TrustServerCertificate=True;Encrypt=False;Trusted_Connection=True;Trusted_Connection=True");
    }
}
