using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Sport.API.Services;

public class SportDbContext(DbContextOptions<SportDbContext> options) : IdentityDbContext(options)
{
}