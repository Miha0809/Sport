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
    /// Добавлення зображення до користувача.
    /// </summary>
    /// <param name="images">Зображення.</param>
    public void Create(List<Image> images)
    {
        context.Images.AddRange(images);
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
    /// Чи інсує сутність.
    /// </summary>
    /// <param name="link">Адрес зображення.</param>
    /// <param name="email">Електронна пошта атворизованого користувача.</param>
    public bool IsExists(string link, string email)
    {
        var image = context.Images.FirstOrDefault(image => image.Link.Equals(link) && image.User.Email!.Equals(email));
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
}