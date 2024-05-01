namespace Sport.API.Repositories.Interfaces;

using Models;

/// <summary>
/// Інтерфейс репозіторія зображень.
/// </summary>
public interface IImageRepository : IDisposable, IExists
{
    /// <summary>
    /// Зображення по посиланню.
    /// </summary>
    /// <param name="link">Посилання.</param>
    Task<Image?> GetByLinkAsync(string link);
    
    /// <summary>
    /// Змінити данні зображення.
    /// </summary>
    /// <param name="image">Новий об'єкт зображення.</param>
    void Update(Image image);

    /// <summary>
    /// Видалення зображення.
    /// </summary>
    /// <param name="image">Зображення.</param>
    void Remove(Image image);

    /// <summary>
    /// Видалення зображень.
    /// </summary>
    /// <param name="images">Зображення.</param>
    void RemoveRange(IList<Image> images);
    
    /// <summary>
    /// Збереження змін.
    /// </summary>
    void Save();
}