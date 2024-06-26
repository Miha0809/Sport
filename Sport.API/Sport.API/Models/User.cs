namespace Sport.API.Models;

using Microsoft.AspNetCore.Identity;

/// <summary>
/// Користувач.
/// </summary>
public class User : IdentityUser
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
    public virtual List<Image>? Images { get; set; }
    
    /// <summary>
    /// Активності користувача.
    /// </summary>
    public virtual List<Activity>? Activities { get; set; }
}