namespace Sport.API.Models.DTOs.Response.Activity;

/// <summary>
/// DTO для створення активності.
/// </summary>
public class ActivityCreateDto
{
    /// <summary>
    /// Початок активності.
    /// </summary>
    public required DateTime Start { get; set; }
    
    /// <summary>
    /// Кінець активності.
    /// </summary>
    public required DateTime End { get; set; }
    
    /// <summary>
    /// Дистанція у метрах.
    /// </summary>
    /// <example>1234</example>
    public required double Distance { get; set; }
    
    /// <summary>
    /// Поточка швидкість.
    /// </summary>
    /// <example>7.4</example>
    public required double Speed { get; set; }

    /// <summary>
    /// Тип активності.
    /// </summary>
    /// <example>CYCLING</example>
    public required string ActivityType { get; set; }
}