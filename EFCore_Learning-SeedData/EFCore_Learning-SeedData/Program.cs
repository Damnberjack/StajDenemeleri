using Microsoft.EntityFrameworkCore;

ApplicationDbContext context = new();

class Post
{
    public int Id { get; set; }
    public int BlogId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }

    public Blog Blog { get; set; }
}
class Blog
{
    public int Id { get; set; }
    public string Url { get; set; }

    public ICollection<Post> Posts { get; set; }
}
class ApplicationDbContext : DbContext
{
    public DbSet<Post> Posts { get; set; }
    public DbSet<Blog> Blogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Post>()
            .HasData(
                new Post() { Id = 1, BlogId = 1, Title = "A", Content = "..." },
                new Post() { Id = 2, BlogId = 1, Title = "B", Content = "..." },
                new Post() { Id = 5, BlogId = 2, Title = "B", Content = "..." }
            );

        modelBuilder.Entity<Blog>()
            .HasData(
                new Blog() { Id = 11, Url = "www.gencayyildiz.com/blog" },
                new Blog() { Id = 2, Url = "www.bilmemne.com/blog" }
            );
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Database=ApplicationDb2;TrustServerCertificate=True;Encrypt=False;Trusted_Connection=True;Trusted_Connection=True");
    }
}