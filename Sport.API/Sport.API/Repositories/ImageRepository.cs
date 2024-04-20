using Sport.API.Models;
using Sport.API.Repositories.Interfaces;
using Sport.API.Services;

namespace Sport.API.Repositories;

/// <summary>
/// Репозіторі зображень.
/// </summary>
/// <param name="context">Контекст БД.</param>
public class ImageRepository(SportDbContext context) : IImageRepository
{
    /// <summary>
    /// Змінити данні зображення.
    /// </summary>
    /// <param name="image">Новий об'єкт зображення.</param>
    public void Update(Image image)
    {
        context.Images.Update(image);
    }

    /// <summary>
    /// Видалення зображення.
    /// </summary>
    /// <param name="image">Зображення.</param>
    public void Remove(Image image)
    {
        context.Images.Remove(image);
    }

    /// <summary>
    /// Збереження змін.
    /// </summary>
    public void Save()
    {
        context.SaveChanges();
    }
    
    private bool _disposed;
    
    /// <summary>
    /// Звільнення ресурсів.
    /// </summary>
    /// <param name="disposing">Стан.</param>
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }
        
        _disposed = true;
    }

    /// <summary>
    /// Звільнення ресурсів.
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}