namespace Sport.API.Models.DTOs.Response.Activity;

/// <summary>
/// DTO для створення активності.
/// </summary>
public class ActivityCreateDto
{
    /// <summary>
    /// Початок активності.
    /// </summary>
    public DateTime Start { get; set; }
    
    /// <summary>
    /// Кінець активності.
    /// </summary>
    public DateTime End { get; set; }
    
    /// <summary>
    /// Дистанція у метрах.
    /// </summary>
    public double Distance { get; set; }
    
    /// <summary>
    /// Поточка швидкість.
    /// </summary>
    public double Speed { get; set; }
    
    /// <summary>
    /// Тривалість активності.
    /// </summary>
    public double Time { get; set; }
    
    /// <summary>
    /// Тип активності.
    /// </summary>
    public required string ActivityType { get; set; }
}