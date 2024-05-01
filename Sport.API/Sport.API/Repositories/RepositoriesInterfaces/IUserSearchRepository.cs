namespace Sport.API.Repositories.RepositoriesInterfaces;

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
    /// <param name="firstName">Ім'я.</param>
    /// <param name="lastName">Фамілія.</param>
    /// <param name="currentUserEmail">Електронна пошта поточного користувача.</param>
    Task<List<User>> UsersByFullNameAsync(string firstName, string lastName, string currentUserEmail);
}