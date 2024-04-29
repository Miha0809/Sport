namespace Sport.API.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    /// Тип активності.
    /// </summary>
    public required string ActivityType { get; set; }

    /// <summary>
    /// Ідентифікатор автора активності.
    /// </summary>
    public required string UserId { get; set; }
    
    /// <summary>
    /// Автор активності.
    /// </summary>
    [ForeignKey("UserId")]
    public virtual required User User { get; set; }
    
    // TODO: Locations, comments, ?likes
}