namespace Sport.API.Repositories;

using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Contexts;
using Models;
using RepositoriesInterfaces;

/// <summary>
/// Репозіторі користувача.
/// </summary>
/// <param name="context">Контекст БД.</param>
/// <param name="userManager">Медеджер користувача.</param>
public sealed class UserRepository(SportDbContext context, UserManager<User> userManager) : IUserRepository
{
    /// <summary>
    /// Авторизований користувач.
    /// </summary>
    /// <param name="claimsPrincipal">Інформація про авторизованого користувача.</param>
    /// <returns>Авторизований користувач</returns>
    public async Task<User?> GetUserAsync(ClaimsPrincipal claimsPrincipal)
    {
        var user = await userManager.GetUserAsync(claimsPrincipal);
        
        return user;
    }
    
    private bool _disposed;

    /// <summary>
    /// Звільнення ресурсів.
    /// </summary>
    /// <param name="disposing">Стан.</param>
    private void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }
        
        _disposed = true;
    }

    /// <summary>
    /// Звільнення ресурсів.
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}