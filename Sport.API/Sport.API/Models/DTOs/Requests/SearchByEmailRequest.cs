namespace Sport.API.Models.DTOs.Requests;

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