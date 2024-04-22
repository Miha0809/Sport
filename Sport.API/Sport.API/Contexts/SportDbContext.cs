using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sport.API.Models;

namespace Sport.API.Contexts;

/// <summary>
/// Контекст БД.
/// </summary>
/// <param name="options">Опція.</param>
public class SportDbContext(DbContextOptions<SportDbContext> options) : IdentityDbContext<User>(options)
{
    /// <summary>
    /// Таблиця зображень.
    /// </summary>
    public required DbSet<Image> Images { get; set; }
    
    /// <summary>
    /// Таблиця активностей.
    /// </summary>
    public required DbSet<Activity> Activities { get; set; }
}