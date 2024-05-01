using Sport.API.Services.Interfaces;

namespace Sport.API.Services;

using System.Text.RegularExpressions;

using Repositories.RepositoriesInterfaces;
using Models.DTOs.Requests.Search;
using ServicesInterfaces;
using Models;

/// <summary>
/// Сервіс пошуку.
/// </summary>
/// <param name="userSearchRepository">Репозіторі пошуку.</param>
public class UserSearchService(IUserSearchRepository userSearchRepository) : IUserSearchService, IValidWithRegex
{
    /// <summary>
    /// Отримати дані авторизованого користувача.
    /// </summary>
    /// <param name="email">Електронна пошта авторизованого користувача.</param>
    public async Task<User?> UserByEmailAsync(string email)
    {
        if (!IsValidCorrectString(email))
        {
            return null;
        }

        var user = await userSearchRepository.UserByEmailAsync(email);

        return user;
    }

    /// <summary>
    /// Пошук користувача по електронній пошті.
    /// </summary>
    /// <param name="request">Запит</param>
    public async Task<User?> UserByEmailAsync(SearchByEmailRequest request)
    {
        if (!IsValidCorrectString(request.Email))
        {
            return null;
        }
        
        var user = await userSearchRepository.UserByEmailAsync(request.Email);

        return user;
    }

    /// <summary>
    /// Перевіряє на валідність електронну пошту.
    /// </summary>
    /// <param name="email">Електронна пошта.</param>
    public bool IsValidCorrectString(string email)
    {
        return Regex.IsMatch(email, @"^\w+@\w{2,}\.\w{2,}$");
    }
    
    /// <summary>
    /// Пошук користувача по імені та/або фамілією.
    /// </summary>
    /// <param name="user">Інформація про авторизованого користувача.</param>
    /// <param name="request">Запит</param>
    public async Task<List<User>> UsersByFullNameAsync(User user, SearchByFullNameRequest request)
    {
        var fullName = request.FullName.Split(' ');
        var firstName = fullName[0];
        var lastName = fullName[1];
        var users = await userSearchRepository.UsersByFullNameAsync(firstName, lastName, user.Email!);

        return users;
    }
}