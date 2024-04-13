namespace Sport.API.Models.DTOs.Requests;

/// <summary>
/// Пошук по імені та/або прізвищі.
/// </summary>
public class SearchByFullNameRequset
{
    /// <summary>
    /// Ім'я та/або прізвище.
    /// </summary>
    public required string FullName { get; set; }
}