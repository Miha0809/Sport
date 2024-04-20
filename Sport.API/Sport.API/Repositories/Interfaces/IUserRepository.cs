using System.Security.Claims;
using Sport.API.Models;

namespace Sport.API.Repositories.Interfaces;

/// <summary>
/// Інтерфейс репозіторія авторизованого користувача.
/// </summary>
public interface IUserRepository : IDisposable
{
    /// <summary>
    /// Авторизований користувач.
    /// </summary>
    /// <param name="claimsPrincipal">Користувач.</param>
    /// <returns></returns>
    Task<User?> GetUserAsync(ClaimsPrincipal claimsPrincipal);
}