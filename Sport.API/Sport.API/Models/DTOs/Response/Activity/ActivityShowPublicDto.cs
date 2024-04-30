using Sport.API.Models.DTOs.Response.User;

namespace Sport.API.Models.DTOs.Response.Activity;

/// <summary>
/// DTO активності для публічного оглядання.
/// </summary>
public class ActivityShowPublicDto
{
    /// <summary>
    /// Ідентифікатор.
    /// </summary>
    public required int Id { get; set; }
    
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
    
    /// <summary>
    /// Автор активності.
    /// </summary>
    public required UserShowPublicDto User { get; set; }
}