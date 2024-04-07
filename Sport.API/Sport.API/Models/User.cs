using Microsoft.AspNetCore.Identity;

namespace Sport.API.Models;

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
}