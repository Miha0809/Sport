namespace Sport.API.Services.Interfaces;

using Models;
using Models.DTOs.Requests.Search;

/// <summary>
/// Інтерфейс сервісу пошуку.
/// </summary>
public interface IUserSearchService
{
    /// <summary>
    /// Отримати дані авторизованого користувача.
    /// </summary>
    /// <param name="email">Електронна пошта авторизованого користувача.</param>
    Task<User?> UserByEmailAsync(string email);
    
    /// <summary>
    /// Пошук користувача по електронній пошті.
    /// </summary>
    /// <param name="request">Запит пошуку.</param>
    Task<User?> UserByEmailAsync(SearchByEmailRequest request);
    
    /// <summary>
    /// Пошук користувача по імені та/або фамілії.
    /// </summary>
    /// <param name="user">Авторизований користувач.</param>
    /// <param name="request">Запит пошуку.</param>
    Task<List<User>> UsersByFullNameAsync(User user, SearchByFullNameRequest request);
}