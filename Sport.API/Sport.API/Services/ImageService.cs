namespace Sport.API.Services;

using System.Text.RegularExpressions;

using Sport.API.Repositories.Interfaces;
using Models;
using Interfaces;

/// <summary>
/// 
/// </summary>
public class ImageService(ISearchRepository searchRepository, IImageRepository imageRepository) : IImageService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    public async Task<List<Image>?> GetImagesAsync(string email)
    {
        var user = await searchRepository.GetUserByEmailAsync(email);

        if (user is null)
        {
            return null;
        }
        
        var userImages = user.Images!;

        return userImages;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="images"></param>
    /// <param name="email"></param>
    /// <returns></returns>
    public async Task<User?> AddAsync(List<Image> images, string email)
    {
        var user = await searchRepository.GetUserByEmailAsync(email);
        var validImages = images.Where(image => IsValidLinkImage(image.Link) && !imageRepository.IsExists(image.Link)).ToList();
        
        if (user is null || validImages.Count == 0)
        {
            return null;
        }

        user.Images!.AddRange(validImages);
        imageRepository.Save();

        user = await searchRepository.GetUserByEmailAsync(email);
        
        return user;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="image"></param>
    /// <param name="oldLink"></param>
    public async Task<Image?> UpdateAsync(Image image, string oldLink)
    {
        var oldImage = await imageRepository.GetByLinkAsync(oldLink);
        var isValidLink = IsValidLinkImage(image.Link);
        
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
    /// 
    /// </summary>
    /// <param name="link"></param>
    /// <returns></returns>
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
    /// <returns></returns>
    private bool IsValidLinkImage(string link)
    {
        return Regex.IsMatch(link, @"\.jpg$|\.jpeg$|\.svg$|\.png$");
    }
}