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
    public required double Distance { get; set; }
    
    /// <summary>
    /// Поточка швидкість.
    /// </summary>
    public required double Speed { get; set; }

    /// <summary>
    /// Тривалість активності.
    /// </summary>
    public required double Time { get; set; }
    
    /// <summary>
    /// Тип активності.
    /// </summary>
    public required string ActivityType { get; set; }
}