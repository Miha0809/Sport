namespace Sport.API.Models.DTOs.Response.Image;

/// <summary>
/// DTO зображення.
/// </summary>
public class ImageDto
{
    /// <summary>
    /// Адрес зображення.
    /// </summary>
    /// <example>https://img.freepik.com/free-photo/painting-mountain-lake-with-mountain-background_188544-9126.jpg</example>
    public required string Link { get; set; }
}