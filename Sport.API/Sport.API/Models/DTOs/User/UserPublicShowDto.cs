namespace Sport.API.Models.DTOs.User;

/// <summary>
/// DTO для публічної інформація користувача.
/// </summary>
public class UserPublicShowDto
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
    /// Електронна пошта.
    /// </summary>
    public required string Email { get; set; }
    
    /// <summary>
    /// Зображення для профілю користувача.
    /// </summary>
    public List<ImageDto>? Images { get; set; }
}