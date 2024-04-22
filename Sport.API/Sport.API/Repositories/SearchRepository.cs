using Microsoft.EntityFrameworkCore;
using Sport.API.Models;
using Sport.API.Repositories.Interfaces;
using Sport.API.Contexts;


namespace Sport.API.Repositories;

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

        if (user is null)
        {
            return null;
        }
        
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
        return await context.Users
            .Where(user =>
                (user.FirstName != null && user.FirstName.Equals(firstName)) &&
                (user.LastName != null && user.LastName.Equals(lastName)) &&
                 !user.Email!.Equals(currentUserEmail))
            .ToListAsync();
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