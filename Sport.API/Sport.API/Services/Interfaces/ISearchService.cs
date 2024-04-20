using System.Security.Claims;
using Sport.API.Models;
using Sport.API.Models.DTOs.Requests.Search;

namespace Sport.API.Services.Interfaces;

/// <summary>
/// Інтерфейс сервісу пошуку.
/// </summary>
public interface ISearchService
{
    /// <summary>
    /// Пошук користувача по електронній пошті.
    /// </summary>
    /// <param name="request">Запит пошуку.</param>
    Task<User?> Email(SearchByEmailRequest request);
    
    /// <summary>
    /// Пошук користувача по імені та/або фамілії.
    /// </summary>
    /// <param name="user">Авторизований користувач.</param>
    /// <param name="request">Запит пошуку.</param>
    Task<List<User>> FullName(User user, SearchByFullNameRequest request);
}