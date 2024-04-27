namespace Sport.API.Services.Interfaces;

using Models;

/// <summary>
/// 
/// </summary>
public interface IImageService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="email"></param>
    Task<List<Image>?> GetImagesAsync(string email);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="images"></param>
    /// <param name="email"></param>
    /// <returns></returns>
    Task<User?> AddAsync(List<Image> images, string email);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="image"></param>
    /// <param name="oldLink"></param>
    Task<Image?> UpdateAsync(Image image, string oldLink);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="link"></param>
    /// <returns></returns>
    Task<bool?> RemoveAsync(string link);
}