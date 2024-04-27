namespace Sport.API.Services;

using System.Text.RegularExpressions;

using Sport.API.Repositories.Interfaces;
using Models.DTOs.Requests.Search;
using Interfaces;
using Models;

/// <summary>
/// Сервіс пошуку.
/// </summary>
/// <param name="searchRepository">Репозіторі пошуку.</param>
public class SearchService(ISearchRepository searchRepository) : ISearchService
{
    /// <summary>
    /// Пошук користувача по електронній пошті.
    /// </summary>
    /// <param name="request">Запит</param>
    /// <returns>Користувач з відповідною унікальною електронною поштою.</returns>
    public async Task<User?> EmailAsync(SearchByEmailRequest request)
    {
        if (!IsValidEmail(request.Email))
        {
            return null;
        }
        
        var userByEmail = await searchRepository.GetUserByEmailAsync(request.Email);

        return userByEmail;
    }

    private bool IsValidEmail(string email)
    {
        return Regex.IsMatch(email, @"^\w+@\w{2,}\.\w{2,}$");
    }
    
    /// <summary>
    /// Пошук користувача по імені та/або фамілією.
    /// </summary>
    /// <param name="user">Інформація про авторизованого користувача.</param>
    /// <param name="request">Запит</param>
    /// <returns>Всі користувачі з відповідним іменим та/або фамілею.</returns>
    public async Task<List<User>> FullNameAsync(User user, SearchByFullNameRequest request)
    {
        var fullName = request.FullName.Split(' ');
        var firstName = fullName[0];
        var lastName = fullName[1];
        var users = await searchRepository.FindUsersByFullNameAsync(firstName, lastName, user.Email!);

        return users;
    }
}