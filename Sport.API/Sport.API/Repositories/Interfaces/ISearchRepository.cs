using Sport.API.Models;

namespace Sport.API.Repositories.Interfaces;

/// <summary>
/// Інтерфейс репозіторія пошуку.
/// </summary>
public interface ISearchRepository : IDisposable
{
    /// <summary>
    /// Користувач по електронній пошті.
    /// </summary>
    /// <param name="email">Електронна пошта.</param>
    /// <returns></returns>
    Task<User?> GetUserByEmailAsync(string email);
    
    /// <summary>
    /// Користувача по імені та/або фамілії.
    /// </summary>
    /// <param name="firstName">Ім'я.</param>
    /// <param name="lastName">Фамілія.</param>
    /// <param name="currentUserEmail">Електронна пошта поточного користувача.</param>
    /// <returns>Користувачів із однаковими іменами та/або фаміліями.</returns>
    Task<List<User>> FindUsersByFullNameAsync(string firstName, string lastName, string currentUserEmail);
}