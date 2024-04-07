using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sport.API.Models;

namespace Sport.API.Services;

/// <summary>
/// Контекст БД.
/// </summary>
/// <param name="options">Опція.</param>
public class SportDbContext(DbContextOptions<SportDbContext> options) : IdentityDbContext<User>(options)
{
    /// <summary>
    /// Таблиця зображень у БД.
    /// </summary>
    public required DbSet<Image> Images { get; set; }
}