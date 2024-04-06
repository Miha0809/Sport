using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sport.API.Models;

namespace Sport.API.Services;

public class SportDbContext(DbContextOptions<SportDbContext> options) : IdentityDbContext<User>(options)
{
    public DbSet<Image>? Images { get; set; }
}