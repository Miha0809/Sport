namespace Sport.API.Models.DTOs.Response.Activity;

/// <summary>
/// DTO для створення активності.
/// </summary>
public class ActivityCreateDto
{
    /// <summary>
    /// Тип активності.
    /// </summary>
    /// <example>CYCLING</example>
    public required string ActivityType { get; set; }
}