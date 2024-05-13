namespace Sport.API.Services;

using System.Text.RegularExpressions;
using Interfaces;
using Models;
using Repositories.Interfaces;

/// <summary>
/// Сервіс пошуку.
/// </summary>
/// <param name="userSearchRepository">Репозіторі пошуку.</param>
public class UserSearchService(IUserSearchRepository userSearchRepository) : IUserSearchService
{
    /// <summary>
    /// Отримати дані авторизованого користувача.
    /// </summary>
    /// <param name="email">Електронна пошта авторизованого користувача.</param>
    public async Task<User> UserByEmailAsync(string email)
    {
        if (!IsValidCorrectString(email))
        {
            throw new ArgumentNullException(nameof(email), "Emails is not valid.");
        }

        var user = await userSearchRepository.UserByEmailAsync(email);

        return user!;
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
    /// Пошук користувача по імені та/або фамілії.
    /// </summary>
    /// <param name="firstName">Ім'я користувача.</param>
    /// <param name="lastName">Фамілія користувача.</param>
    public async Task<List<User>> UsersByFullNameAsync(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
        {
            throw new ArgumentNullException(
                $"{nameof(firstName)} | {nameof(lastName)}",
                "firstName or lastName is null"
            );
        }

        var users = await userSearchRepository.UsersByFullNameAsync(firstName!, lastName!);

        return users;
    }
}
