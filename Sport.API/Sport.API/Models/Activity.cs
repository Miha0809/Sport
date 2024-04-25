using System.ComponentModel.DataAnnotations;

namespace Sport.API.Models;

/// <summary>
/// Активність.
/// </summary>
public class Activity
{
    /// <summary>
    /// Ідентифікатор.
    /// </summary>
    [Key]
    public int Id { get; set; }
 
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
    /// Тип активності.
    /// </summary>
    public required string ActivityType { get; set; }

    // TODO: Locations, comments, ?likes
}