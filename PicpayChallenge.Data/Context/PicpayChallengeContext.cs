using Microsoft.EntityFrameworkCore;
using PicpayChallenge.Data.Entities;

namespace PicpayChallenge.Data.Context;

public class PicpayChallengeContext: DbContext
{
    public PicpayChallengeContext(DbContextOptions<PicpayChallengeContext> options) : base(options) { }
    public PicpayChallengeContext() { }

    public DbSet<User> Users { get; set; }
    public DbSet<Wallet> Wallets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasOne(u => u.Wallet)
            .WithOne(w => w.User)
            .HasForeignKey<Wallet>(w => w.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Wallet>()
            .Property(w => w.Balance)
            .HasColumnType("decimal(18,2)")
            .IsRequired();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer("Server=localhost;Database=PicPayDb;Trusted_Connection=True;TrustServerCertificate=True;");
    }

}
