namespace Sport.API.Models.DTOs.User;

/// <summary>
/// DTO для приватної інформація користувача.
/// </summary>
public class UserPrivateShowDto
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
    /// Чи підтверджена електронна пошта.
    /// </summary>
    public required bool EmailConfirmed { get; set; }
    
    /// <summary>
    /// Зображення для профілю користувача.
    /// </summary>
    public List<ImageDto>? Images { get; set; }
    
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
}