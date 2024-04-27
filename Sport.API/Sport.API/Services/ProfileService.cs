namespace Sport.API.Services;

using Sport.API.Repositories.Interfaces;
using Models.DTOs.Response.User;
using Models;
using Interfaces;

/// <summary>
/// Сервіс власного профілю.
/// </summary>
public class ProfileService(IProfileRepository profileRepository, ISearchRepository searchRepository, IImageRepository imageRepository) : IProfileService
{
    /// <summary>
    /// Інформація про профіль.
    /// </summary>
    /// <param name="email">Електронна пошта.</param>
    /// <returns>Авторизованого користувача.</returns>
    public async Task<User> ProfileAsync(string email)
    {
        var user = await searchRepository.GetUserByEmailAsync(email);
        
        return user!;
    }

    /// <summary>
    /// Редагувати профіль.
    /// </summary>
    /// <param name="userUpdateDto">Dto для редагування користувача.</param>
    /// <param name="email">Електронна пошта.</param>
    /// <returns>Оновлений профліь користувача.</returns>
    public async Task<User?> UpdateAsync(UserUpdateDto? userUpdateDto, string email)
    {
        var user = await searchRepository.GetUserByEmailAsync(email);
        
        if (user is null || userUpdateDto is null)
        {
            return null;
        }

        user.FirstName = userUpdateDto.FirstName;
        user.LastName = userUpdateDto.LastName;

        profileRepository.Update(user);
        profileRepository.Save();

        return user;
    }

    /// <summary>
    /// Видалити профіль.
    /// </summary>
    /// <param name="email">Електронна пошта.</param>
    /// <returns>Стан видалення профілю.</returns>
    public async Task<bool?> RemoveAsync(string email)
    {
        var user = await searchRepository.GetUserByEmailAsync(email);
        
        if (user is null)
        {
            return null;
        }

        if (user.Images!.Count > 0)
        {
            imageRepository.RemoveRange(user.Images);
        }
        
        profileRepository.Remove(user);
        profileRepository.Save();

        var isExistsUser = await searchRepository.GetUserByEmailAsync(email) is null;
        
        return isExistsUser;
    }
}