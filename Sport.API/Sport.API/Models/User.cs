namespace Sport.API.Models;

using Microsoft.AspNetCore.Identity;

/// <summary>
/// Користувач.
/// </summary>
public sealed class User : IdentityUser
{
    /// <summary>
    /// Ім'я.
    /// </summary>
    public string? FirstName { get; set; }    
    /// <summary>
    /// Прізвище.
    /// </summary>
    public string? LastName { get; set; }
    
    /// <summary>
    /// Багато зображень.
    /// </summary>
    public List<Image>? Images { get; set; }
    
    /// <summary>
    /// Активності користувача.
    /// </summary>
    public List<Activity>? Activities { get; set; }
}