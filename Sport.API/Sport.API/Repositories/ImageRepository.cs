namespace Sport.API.Repositories;

using Microsoft.EntityFrameworkCore;

using Models;
using Interfaces;
using Contexts;

/// <summary>
/// Репозіторі зображень.
/// </summary>
/// <param name="context">Контекст БД.</param>
public sealed class ImageRepository(SportDbContext context) : IImageRepository
{
    /// <summary>
    /// Зображення по посиланню.
    /// </summary>
    /// <param name="link">Посилання.</param>
    /// <returns>Зображення по посиланню.</returns>
    public async Task<Image?> GetByLinkAsync(string link)
    {
        return await context.Images.FirstOrDefaultAsync(image => image.Link.Equals(link));
    }

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
    /// Видалення зображень.
    /// </summary>
    /// <param name="images">Зображення.</param>
    public void RemoveRange(IList<Image> images)
    {
        context.Images.RemoveRange(images);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="link"></param>
    /// <returns></returns>
    public bool IsExists(string link)
    {
        var image = context.Images.FirstOrDefault(image => image.Link.Equals(link));
        var isExists = image is not null;
        
        return isExists;
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
    private void Dispose(bool disposing)
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