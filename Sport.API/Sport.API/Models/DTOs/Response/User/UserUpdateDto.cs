namespace Sport.API.Models.DTOs.Response.User;

/// <summary>
/// DTO користувача для редагування.
/// </summary>
public class UserUpdateDto
{
    /// <summary>
    /// Ім'я.
    /// </summary>
    /// <example>Mark</example>
    public required string FirstName { get; set; }
    
    /// <summary>
    /// Прізвище.
    /// </summary>
    /// <example>Full</example>
    public required string LastName { get; set; }
    
    /// <summary>
    /// Номер телефону.
    /// </summary>
    /// <example>+123456789</example>
    public string? PhoneNumber { get; set; }
}