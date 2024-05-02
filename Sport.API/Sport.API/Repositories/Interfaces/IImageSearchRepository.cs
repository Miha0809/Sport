namespace Sport.API.Repositories.Interfaces;

using Models;

/// <summary>
/// Інтерфейс репозіторія пошуку зображень.
/// </summary>
public interface IImageSearchRepository
{
    /// <summary>
    /// Зображення авторизованого користувача.
    /// </summary>
    /// <param name="email">Електронна пошта авторизованого користувача.</param>
    Task<List<Image>> ImagesAsync(string email);
    
    /// <summary>
    /// Зображення по посиланню.
    /// </summary>
    /// <param name="link">Посилання.</param>
    Task<Image?> GetByLinkAsync(string link);
}