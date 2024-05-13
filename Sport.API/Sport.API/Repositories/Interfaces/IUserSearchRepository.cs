namespace Sport.API.Repositories.Interfaces;

using Models;

/// <summary>
/// Інтерфейс репозіторія пошуку.
/// </summary>
public interface IUserSearchRepository
{
    /// <summary>
    /// Користувач по електронній пошті.
    /// </summary>
    /// <param name="email">Електронна пошта.</param>
    Task<User?> UserByEmailAsync(string email);

    /// <summary>
    /// Користувача по імені та/або фамілії.
    /// </summary>
    /// <param name="firstName">Ім'я користувача.</param>
    /// <param name="lastName">Фамілія користувача.</param>
    Task<List<User>> UsersByFullNameAsync(string firstName, string lastName);
}
