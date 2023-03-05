using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concretes.EntityFramework;

public class PostgreSqlContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Database=ReCapProject;Username=postgres;Password=15082001");
    }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Brand> Brand { get; set; }
}