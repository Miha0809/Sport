namespace Sport.API.Repositories;

using Microsoft.EntityFrameworkCore;
using Models;
using Interfaces;
using Contexts;

/// <summary>
/// Репозіторі пошуку.
/// </summary>
public sealed class SearchRepository(SportDbContext context) : ISearchRepository
{
    /// <summary>
    /// Користувач з відповідною електронною поштою.
    /// </summary>
    /// <param name="email">Електронна пошта.</param>
    /// <returns>Користувач з відповідною електронною поштою.</returns>
    public async Task<User?> GetUserByEmailAsync(string email)
    {
        var user = await context.Users.FirstOrDefaultAsync(user => user.Email!.Equals(email));

        return user;
    }

    /// <summary>
    /// Користувача по імені та/або фамілії.
    /// </summary>
    /// <param name="firstName">Ім'я.</param>
    /// <param name="lastName">Фамілія.</param>
    /// <param name="currentUserEmail">Електронна пошта поточного користувача.</param>
    /// <returns>Користувачів із однаковими іменами та/або фаміліями.</returns>
    public async Task<List<User>> FindUsersByFullNameAsync(string firstName, string lastName, string currentUserEmail)
    {
        var users = await context.Users
            .Where(user =>
                (user.FirstName != null && user.FirstName.Equals(firstName)) &&
                (user.LastName != null && user.LastName.Equals(lastName)) &&
                !user.Email!.Equals(currentUserEmail))
            .ToListAsync();

        return users;
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