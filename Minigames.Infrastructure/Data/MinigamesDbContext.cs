using Microsoft.EntityFrameworkCore;
using Minigames.Domain.Entities;

namespace Minigames.Infrastructure.Data;

public class MinigamesDbContext : DbContext
{
    public MinigamesDbContext(DbContextOptions<MinigamesDbContext> options) : base(options)
    {
    }

    public DbSet<Player> Players => Set<Player>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Player>(player =>
        {
            player.HasKey(p => p.Id);

            player.Property(p => p.PlayerName)
                  .IsRequired();

            player.OwnsOne(p => p.GameSummary, summary =>
            {
                summary.OwnsOne(s => s.HangmanGameResult);
                summary.OwnsOne(s => s.FormulaGameResult);
            });
        });
    }
}