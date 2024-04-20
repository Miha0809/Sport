using Sport.API.Models;

namespace Sport.API.Repositories.Interfaces;

/// <summary>
/// Інтерфейс репозіторія зображень.
/// </summary>
public interface IImageRepository : IDisposable
{
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
    /// Збереження змін.
    /// </summary>
    void Save();
}