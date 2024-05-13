namespace Sport.API.Repositories;

using Contexts;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;

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
    public async Task<List<User>> UsersByFullNameAsync(string firstName, string lastName)
    {
        var users = await context
            .Users.Where(user =>
                (user.FirstName != null && user.FirstName.Equals(firstName))
                && (user.LastName != null && user.LastName.Equals(lastName))
            )
            .ToListAsync();

        return users;
    }
}
