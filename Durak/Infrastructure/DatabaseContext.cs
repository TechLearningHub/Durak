using Microsoft.EntityFrameworkCore;

namespace Durak.Infrastructure;

public sealed class DatabaseContext : DbContext
{
    public DbSet<Card> Cards { get; set; }
    public DbSet<Player> Players { get; set; }

    public DatabaseContext()
    {
        // Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> contextOptions) : base(contextOptions)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Host=localhost;Port=5433;Database=userdb;Username=postgres;Password=alisher05";
        optionsBuilder.UseNpgsql(connectionString);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Player>().HasKey(d => d.Id);
        modelBuilder.Entity<Card>().HasKey(d => d.Id);
    }
}