using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext {
    
    public DbSet<Student> Students { get; set; }
    public DbSet<Course>  Courses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=EfPracticeDb_New;Trusted_Connection=True;TrustServerCertificate=True;");
    }
 

}