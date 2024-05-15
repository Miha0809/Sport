namespace Sport.API.Contexts;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;

/// <summary>
/// Контекст БД.
/// </summary>
/// <param name="options">Опція.</param>
public class SportDbContext(DbContextOptions<SportDbContext> options)
    : IdentityDbContext<User>(options)
{
    /// <summary>
    /// Таблиця зображень.
    /// </summary>
    public required DbSet<Image> Images { get; set; }

    /// <summary>
    /// Таблиця активностей.
    /// </summary>
    public required DbSet<Activity> Activities { get; set; }

    /// <summary>
    /// Таблиця типів активностей.
    /// </summary>
    public required DbSet<ActivityType> ActivityTypes { get; set; }

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<User>()
            .HasMany(e => e.Activities)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.UserId)
            .IsRequired();

        modelBuilder
            .Entity<User>()
            .HasMany(e => e.Images)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.UserId)
            .IsRequired();

        modelBuilder
            .Entity<Activity>()
            .HasMany(e => e.Locations)
            .WithOne(e => e.Activity)
            .HasForeignKey(e => e.ActivityId)
            .IsRequired();

        base.OnModelCreating(modelBuilder);
    }
}
