namespace Sport.API.Services.ServicesInterfaces;

using Models;

/// <summary>
/// Інтерфейс сервісу зображень.
/// </summary>
public interface IImageService
{
    /// <summary>
    /// Всі зображення авторизованого користувача.
    /// </summary>
    /// <param name="email">Елетронна пошта авторизованого користувача.</param>
    Task<List<Image>?> GetImagesAsync(string email);

    /// <summary>
    /// Добавити зображення для авторизованого користувача.
    /// </summary>
    /// <param name="images">Зображення.</param>
    /// <param name="email">Елетронна пошта авторизованого користувача.</param>
    Task<User?> AddAsync(List<Image> images, string email);

    /// <summary>
    /// Редагування зображення.
    /// </summary>
    /// <param name="image">Зображення.</param>
    /// <param name="oldLink">Старий адрес зображженя.</param>
    Task<Image?> UpdateAsync(Image image, string oldLink);

    /// <summary>
    /// Видалення зображженя.
    /// </summary>
    /// <param name="link">Адрес зображення.</param>
    Task<bool?> RemoveAsync(string link);
}