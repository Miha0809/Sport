namespace Sport.API.Models.DTOs.User;

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
}