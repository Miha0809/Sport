namespace Sport.API.Repositories.Interfaces;

using System.Security.Claims;

using Models;


/// <summary>
/// Інтерфейс репозіторія авторизованого користувача.
/// </summary>
public interface IUserRepository : IDisposable
{
    /// <summary>
    /// Авторизований користувач.
    /// </summary>
    /// <param name="claimsPrincipal">Користувач.</param>
    Task<User?> GetUserAsync(ClaimsPrincipal claimsPrincipal);
}