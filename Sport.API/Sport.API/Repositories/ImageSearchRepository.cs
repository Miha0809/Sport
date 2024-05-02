namespace Sport.API.Repositories;

using Microsoft.EntityFrameworkCore;

using Contexts;
using Models;
using Interfaces;

/// <summary>
/// Інтерфейс репозіторія пошуку зображень.
/// </summary>
public class ImageSearchRepository(SportDbContext context) : IImageSearchRepository
{
    /// <summary>
    /// Зображення авторизованого користувача.
    /// </summary>
    /// <param name="email">Електронна пошта авторизованого користувача.</param>
    public async Task<List<Image>> ImagesAsync(string email)
    {
        var images = await context.Images.Where(image => image.User.Email!.Equals(email)).ToListAsync();
        
        return images;
    }

    /// <summary>
    /// Зображення по посиланню.
    /// </summary>
    /// <param name="link">Посилання.</param>
    public async Task<Image?> GetByLinkAsync(string link)
    {
        var image = await context.Images.FirstOrDefaultAsync(image => image.Link.Equals(link));
        
        return image;
    }
}