namespace Sport.API.Models.DTOs.Requests.Search;

/// <summary>
/// Пошук по імені та/або прізвищі.
/// </summary>
public class SearchByFullNameRequest
{
    /// <summary>
    /// Ім'я та/або прізвище.
    /// </summary>
    /// <example>Mark Full</example>
    public required string FullName { get; set; }
}