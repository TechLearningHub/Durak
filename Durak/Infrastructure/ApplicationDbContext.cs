using Durak.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Durak.Infrastructure;

public sealed class ApplicationDbContext : DbContext
{
    public DbSet<CardEntity> Cards { get; set; }

    public DbSet<PlayerEntity> Players { get; set; }
    
    public DbSet<DeskEntity> Desks { get; set; }

    public DbSet<HandEntity> Hands { get; set; }

    public DbSet<MoveHistoryEntity> MoveHistories { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> contextOptions)
        : base(contextOptions)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Player
        modelBuilder.Entity<PlayerEntity>()
            .Property(d => d.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<PlayerEntity>()
            .HasKey(d => d.Id);
        

        modelBuilder.Entity<PlayerEntity>()
            .Property(e => e.NickName)
            .HasMaxLength(40);
        
        // Card
        modelBuilder.Entity<CardEntity>()
            .HasKey(d => d.Id);
        
        modelBuilder.Entity<CardEntity>()
            .Property(d => d.Id)
            .ValueGeneratedOnAdd();
        
        // Desk
        modelBuilder.Entity<DeskEntity>()
            .HasKey(e => e.Id);
        
        modelBuilder.Entity<DeskEntity>()
            .Property(e => e.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<DeskEntity>()
            .HasMany(e => e.Hands)
            .WithOne()
            .HasForeignKey(e => e.DeskId);
        
        modelBuilder.Entity<DeskEntity>()
            .Property(e => e.Winner)
            .HasMaxLength(40);
        
        // Hand
        modelBuilder.Entity<HandEntity>()
            .HasKey(e => e.Id);
        
        modelBuilder.Entity<HandEntity>()
            .Property(e => e.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<HandEntity>()
            .HasOne(e => e.Player)
            .WithMany()
            .HasForeignKey(e => e.PlayerId);
    }
}