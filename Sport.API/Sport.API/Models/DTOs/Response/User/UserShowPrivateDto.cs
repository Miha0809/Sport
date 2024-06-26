namespace Sport.API.Models.DTOs.Response.User;

using Activity;
using Image;

/// <summary>
/// DTO користувача для приватної оглядання.
/// </summary>
public class UserShowPrivateDto
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
    /// Чи підтверджена електрона скринька.
    /// </summary>
    public required bool EmailConfirmed { get; set; }
    
    /// <summary>
    /// Номер мобільного телефону.
    /// </summary>
    public string? PhoneNumber { get; set; }
    
    /// <summary>
    /// Чи підтверджений номер мобільного телефону.
    /// </summary>
    public required bool PhoneNumberConfirmed { get; set; }
    
    /// <summary>
    /// Чи включена двоетапна перевірка.
    /// </summary>
    public required bool TwoFactorEnabled { get; set; }
    
    /// <summary>
    /// Багато зображення.
    /// </summary>
    public List<ImageDto>? Images { get; set; }
    
    /// <summary>
    /// Всі активності користуваача.
    /// </summary>
    public List<ActivityShowPublicDto>? Activities { get; set; }
}