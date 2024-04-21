using Sport.API.Models;
using Sport.API.Models.DTOs.Response.User;

namespace Sport.API.Services.Interfaces;

/// <summary>
/// 
/// </summary>
public interface IProfileService
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