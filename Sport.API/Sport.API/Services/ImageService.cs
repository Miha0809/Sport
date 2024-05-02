namespace Sport.API.Services;

using System.Text.RegularExpressions;
using Repositories.Interfaces;
using Models;
using Interfaces;

/// <summary>
/// Сервіс зображень.
/// </summary>
/// <param name="imageRepository">Репозіторі зображень.</param>
/// <param name="imageSearchRepository">Репозіторі пошуку зображень.</param>
/// <param name="userSearchRepository">Репозіторі пошуку користувачів/користувача.</param>
public class ImageService(
    IImageRepository imageRepository,
    IImageSearchRepository imageSearchRepository,
    IUserSearchRepository userSearchRepository) : IImageService
{
    /// <summary>
    /// Всі зображення авторизованого користувача.
    /// </summary>
    /// <param name="email">Елетронна пошта авторизованого користувача.</param>
    public async Task<List<Image>> GetImagesAsync(string email)
    {
        var images = await imageSearchRepository.ImagesAsync(email);

        return images;
    }

    /// <summary>
    /// Добавити зображення для авторизованого користувача.
    /// </summary>
    /// <param name="images">Зображення.</param>
    /// <param name="email">Елетронна пошта авторизованого користувача.</param>
    public async Task<List<Image>> AddAsync(List<Image> images, string email)
    {
        var user = await userSearchRepository.UserByEmailAsync(email);
        var validImages = images.Where(image => IsValidCorrectString(image.Link) && !imageRepository.IsExists(image.Link, email)).ToList();

        if (user is null || validImages.Count == 0)
        {
            return null!;
        }

        validImages.ForEach(image => image.UserId = user.Id);
        validImages.ForEach(image => image.User = user);

        imageRepository.Create(validImages);
        imageRepository.Save();

        return validImages;
    }

    /// <summary>
    /// Редагування зображення.
    /// </summary>
    /// <param name="image">Зображення.</param>
    /// <param name="oldLink">Старий адрес зображженя.</param>
    public async Task<Image> UpdateAsync(Image image, string oldLink)
    {
        var oldImage = await imageSearchRepository.GetByLinkAsync(oldLink);
        var isValidLink = IsValidCorrectString(image.Link);

        if (oldImage is null || !isValidLink)
        {
            throw new ArgumentNullException(nameof(oldImage), "Image is not correct.");
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
            throw new InvalidDataException($"{nameof(link)} is empty or white space.");
        }

        var image = await imageSearchRepository.GetByLinkAsync(link);

        if (image == null)
        {
            throw new ArgumentNullException(nameof(image), "Image is null");
        }

        imageRepository.Remove(image);
        imageRepository.Save();

        var isExistsImage = await imageSearchRepository.GetByLinkAsync(link) is null;

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