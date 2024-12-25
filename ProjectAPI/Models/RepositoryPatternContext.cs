using Microsoft.EntityFrameworkCore;

namespace ProjectAPI.Models;

public class RepositoryPatternContext : DbContext
{
    public RepositoryPatternContext(DbContextOptions<RepositoryPatternContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }
}