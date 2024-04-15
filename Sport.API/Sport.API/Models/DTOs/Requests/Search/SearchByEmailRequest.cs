namespace Sport.API.Models.DTOs.Requests.Search;

/// <summary>
/// Пошук по електронній пошті.
/// </summary>
public class SearchByEmailRequest
{
    /// <summary>
    /// Електронна пошта.
    /// </summary>
    /// <example>admin@gmail.com</example>
    public required string Email { get; set; }
}