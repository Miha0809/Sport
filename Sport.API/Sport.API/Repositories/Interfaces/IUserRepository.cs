using System.Security.Claims;
using Sport.API.Models;

namespace Sport.API.Repositories.Interfaces;

public interface IUserRepository : IDisposable
{
    Task<User?> GetUserAsync(ClaimsPrincipal claimsPrincipal);
}