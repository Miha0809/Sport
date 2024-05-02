namespace Sport.API.Repositories;

using Microsoft.EntityFrameworkCore;

using Models;
using Contexts;
using Interfaces;

/// <summary>
/// Репозіторі пошуку користувачів.
/// </summary>
/// <param name="context">Контекст БД.</param>
public class UserSearchRepository(SportDbContext context) : IUserSearchRepository
{
    /// <summary>
    /// Користувач з відповідною електронною поштою.
    /// </summary>
    /// <param name="email">Електронна пошта.</param>
    public async Task<User?> UserByEmailAsync(string email)
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
    public async Task<List<User>> UsersByFullNameAsync(string firstName, string lastName, string currentUserEmail)
    {
        var users = await context.Users
            .Where(user =>
                (user.FirstName != null && user.FirstName.Equals(firstName)) &&
                (user.LastName != null && user.LastName.Equals(lastName)) &&
                !user.Email!.Equals(currentUserEmail))
            .ToListAsync();

        return users;
    }
}