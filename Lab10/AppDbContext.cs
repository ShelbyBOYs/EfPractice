using Microsoft.EntityFrameworkCore;

public class LibraryDbContext : DbContext
{
    public DbSet<Reader> Readers { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Borrow> Borrows { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=EfPracticeDb_Lab10;Trusted_Connection=True;TrustServerCertificate=True;");
    }

}
