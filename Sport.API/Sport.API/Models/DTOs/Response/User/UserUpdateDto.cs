namespace Sport.API.Models.DTOs.Response.User;

/// <summary>
/// DTO користувача для редагування.
/// </summary>
public class UserUpdateDto
{
    /// <summary>
    /// Ім'я.
    /// </summary>
    public required string FirstName { get; set; }
    
    /// <summary>
    /// Прізвище.
    /// </summary>
    public required string LastName { get; set; }
}