namespace Sport.API.Services.Interfaces;

using Models;
using Sport.API.Interfaces.Services;

/// <summary>
/// Інтерфейс сервісу пошуку.
/// </summary>
public interface IUserSearchService : IValidWithRegex
{
    /// <summary>
    /// Отримати дані авторизованого користувача.
    /// </summary>
    /// <param name="email">Електронна пошта авторизованого користувача.</param>
    Task<User> UserByEmailAsync(string email);

    /// <summary>
    /// Пошук користувача по імені та/або фамілії.
    /// </summary>
    /// <param name="firstName">Ім'я користувача.</param>
    /// <param name="lastName">Фамілія користувача.</param>
    Task<List<User>> UsersByFullNameAsync(string firstName, string lastName);
}
