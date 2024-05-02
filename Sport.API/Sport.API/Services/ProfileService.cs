namespace Sport.API.Services;

using System.Text.RegularExpressions;

using Repositories.Interfaces;
using Models.DTOs.Response.User;
using Models;
using Interfaces;

/// <summary>
/// Сервіс власного профілю.
/// </summary>
/// <param name="userRepository">Репозіторі профілю користувача.</param>
/// <param name="searchRepository">Репозіторі пошуку.</param>
/// <param name="imageRepository">Репозіторі зображень.</param>
public class ProfileService(
    IUserRepository userRepository,
    IUserSearchRepository searchRepository,
    IImageRepository imageRepository) : IProfileService
{
    /// <summary>
    /// Інформація про профіль.
    /// </summary>
    /// <param name="email">Електронна пошта.</param>
    public async Task<User> ProfileAsync(string email)
    {
        var user = await searchRepository.UserByEmailAsync(email);
        
        return user!;
    }

    /// <summary>
    /// Редагувати профіль.
    /// </summary>
    /// <param name="userUpdateDto">Dto для редагування користувача.</param>
    /// <param name="email">Електронна пошта.</param>
    public async Task<User?> UpdateAsync(UserUpdateDto? userUpdateDto, string email)
    {
        var user = await searchRepository.UserByEmailAsync(email);
        
        if (user is null || userUpdateDto is null || (userUpdateDto.PhoneNumber is null || !IsValidCorrectString(userUpdateDto.PhoneNumber!)))
        {
            throw new ArgumentNullException(nameof(userUpdateDto), "Data is null");
        }

        user.FirstName = userUpdateDto.FirstName;
        user.LastName = userUpdateDto.LastName;
        user.PhoneNumber = userUpdateDto.PhoneNumber;

        userRepository.Update(user);
        userRepository.Save();

        return user;
    }

    /// <summary>
    /// Видалити профіль.
    /// </summary>
    /// <param name="email">Електронна пошта.</param>
    public async Task<bool?> RemoveAsync(string email)
    {
        var user = await searchRepository.UserByEmailAsync(email);
        
        if (user is null)
        {
            throw new ArgumentNullException(nameof(user), "User is null");
        }

        if (user.Images!.Count > 0)
        {
            imageRepository.RemoveRange(user.Images);
        }
        
        userRepository.Remove(user);
        userRepository.Save();

        var isExistsUser = await searchRepository.UserByEmailAsync(email) is null;
        
        return isExistsUser;
    }

    /// <summary>
    /// Перевіряє на валідність номер телефону.
    /// </summary>
    /// <param name="number">Номер телефону.</param>
    public bool IsValidCorrectString(string number)
    {
        return Regex.IsMatch(number, @"^\+?\d*$");
    }
}