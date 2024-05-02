using Sport.API.Interfaces.Services;

namespace Sport.API.Services;

using System.Text.RegularExpressions;
using Repositories.Interfaces;
using Models;
using Interfaces;

/// <summary>
/// Сервіс зображень.
/// </summary>
/// <param name="imageRepository">Репозіторі зображень.</param>
/// <param name="searchRepository">Репозіторі пошуку.</param>
public class ImageService(IImageRepository imageRepository, IUserSearchRepository searchRepository) : IImageService, IValidWithRegex
{
    /// <summary>
    /// Всі зображення авторизованого користувача.
    /// </summary>
    /// <param name="email">Елетронна пошта авторизованого користувача.</param>
    public async Task<List<Image>?> GetImagesAsync(string email)
    {
        var user = await searchRepository.UserByEmailAsync(email);

        if (user is null)
        {
            return null;
        }
        
        var userImages = user.Images!;

        return userImages;
    }

    /// <summary>
    /// Добавити зображення для авторизованого користувача.
    /// </summary>
    /// <param name="images">Зображення.</param>
    /// <param name="email">Елетронна пошта авторизованого користувача.</param>
    public async Task<List<Image>> AddAsync(List<Image> images, string email)
    {
        var user = await searchRepository.UserByEmailAsync(email);
        var validImages = images.Where(image => IsValidCorrectString(image.Link) && !imageRepository.IsExists(image.Link, email)).ToList();
        
        if (user is null || validImages.Count == 0)
        {
            return null!;
        }

        validImages.ForEach(image => image.UserId = user.Id);
        validImages.ForEach(image => image.User = user);

        imageRepository.Create(validImages, email);
        imageRepository.Save();

        return validImages;
    }

    /// <summary>
    /// Редагування зображення.
    /// </summary>
    /// <param name="image">Зображення.</param>
    /// <param name="oldLink">Старий адрес зображженя.</param>
    public async Task<Image?> UpdateAsync(Image image, string oldLink)
    {
        var oldImage = await imageRepository.GetByLinkAsync(oldLink);
        var isValidLink = IsValidCorrectString(image.Link);
        
        if (oldImage is null || !isValidLink)
        {
            return null;
        }

        oldImage.Link = image.Link;
        
        imageRepository.Update(oldImage);
        imageRepository.Save();

        return oldImage;
    }

    /// <summary>
    /// Видалення зображженя.
    /// </summary>
    /// <param name="link">Адрес зображення.</param>
    public async Task<bool?> RemoveAsync(string link)
    {
        if (string.IsNullOrWhiteSpace(link))
        {
            return null;
        }

        var image = await imageRepository.GetByLinkAsync(link);

        if (image == null)
        {
            return null;
        }

        imageRepository.Remove(image);
        imageRepository.Save();

        var isExistsImage = await imageRepository.GetByLinkAsync(link) is null;
        
        return isExistsImage;
    }

    /// <summary>
    /// Перевіряє чи адресс є зображенням.
    /// </summary>
    /// <param name="link">Адрес зображення.</param>
    public bool IsValidCorrectString(string link)
    {
        return Regex.IsMatch(link, @"\.jpg$|\.jpeg$|\.svg$|\.png$");
    }
}