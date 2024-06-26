namespace Sport.API.Services.Interfaces;

using Sport.API.Interfaces.Services;
using Models;
using Models.DTOs.Response.User;

/// <summary>
/// Інтерфейс сервісу профілю авторизованого користувача.
/// </summary>
public interface IProfileService : IValidWithRegex
{
    /// <summary>
    /// Інформація про профіль.
    /// </summary>
    /// <param name="email">Електронна пошта.</param>
    Task<User> ProfileAsync(string email);
    
    /// <summary>
    /// Редагувати профіль.
    /// </summary>
    /// <param name="userUpdateDto">Dto для редагування користувача.</param>
    /// <param name="email">Електронна пошта.</param>
    Task<User?> UpdateAsync(UserUpdateDto? userUpdateDto, string email);

    /// <summary>
    /// Видалити профіль.
    /// </summary>
    /// <param name="email">Електронна пошта.</param>
    Task<bool?> RemoveAsync(string email);
}