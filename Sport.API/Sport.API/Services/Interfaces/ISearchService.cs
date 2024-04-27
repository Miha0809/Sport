namespace Sport.API.Services.Interfaces;

using Models;
using Models.DTOs.Requests.Search;


/// <summary>
/// Інтерфейс сервісу пошуку.
/// </summary>
public interface ISearchService
{
    /// <summary>
    /// Пошук користувача по електронній пошті.
    /// </summary>
    /// <param name="request">Запит пошуку.</param>
    Task<User?> EmailAsync(SearchByEmailRequest request);
    
    /// <summary>
    /// Пошук користувача по імені та/або фамілії.
    /// </summary>
    /// <param name="user">Авторизований користувач.</param>
    /// <param name="request">Запит пошуку.</param>
    Task<List<User>> FullNameAsync(User user, SearchByFullNameRequest request);
}