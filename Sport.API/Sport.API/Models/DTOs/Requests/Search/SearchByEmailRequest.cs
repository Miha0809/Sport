namespace Sport.API.Models.DTOs.Requests.Search;

/// <summary>
/// Пошук по електронній пошті.
/// </summary>
public class SearchByEmailRequest
{
    /// <summary>
    /// Електронна пошта.
    /// </summary>
    public required string Email { get; set; }
}