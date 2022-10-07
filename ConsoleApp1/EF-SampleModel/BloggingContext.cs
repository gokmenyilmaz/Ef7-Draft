using Microsoft.EntityFrameworkCore;

namespace EFSaving.Disconnected;

public class BloggingContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Server=localhost,1501;user Id=sa;password=Ankara!06;database=db1")
            .EnableSensitiveDataLogging();


   



    }
}
