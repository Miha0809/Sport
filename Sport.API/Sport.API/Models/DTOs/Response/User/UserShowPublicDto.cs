namespace Sport.API.Models.DTOs.Response.User;

/// <summary>
/// DTO користувача для приватної оглядання.
/// </summary>
public class UserShowPublicDto
{
    /// <summary>
    /// Ім'я.
    /// </summary>
    public required string FirstName { get; set; }
    /// <summary>
    /// Прізвище.
    /// </summary>
    public required string LastName { get; set; }
    
    /// <summary>
    /// Електрона скринька.
    /// </summary>
    public required string Email { get; set; }
    
    /// <summary>
    /// Багато зображення.
    /// </summary>
    public List<ImageDto>? Images { get; set; }
    
    /// <summary>
    /// Номер мобільного телефону.
    /// </summary>
    public string? PhoneNumber { get; set; }
}