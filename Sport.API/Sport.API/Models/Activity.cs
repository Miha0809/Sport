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
    public required DateTime Start { get; set; } = DateTime.UtcNow;
    
    /// <summary>
    /// Кінець активності.
    /// </summary>
    public required DateTime End { get; set; } = DateTime.UtcNow;
    
    /// <summary>
    /// Загальний час активності.
    /// </summary>
    public TimeSpan Time { get; set; }
    
    /// <summary>
    /// Дистанція у метрах.
    /// </summary>
    public required double Distance { get; set; }
    
    /// <summary>
    /// Поточка швидкість.
    /// </summary>
    public double Speed { get; set; }
    
    /// <summary>
    /// Тип активності.
    /// </summary>
    public required string ActivityType { get; set; }

    /// <summary>
    /// Ідентифікатор автора активності.
    /// </summary>
    public string? UserId { get; set; }
    
    /// <summary>
    /// Автор активності.
    /// </summary>
    [ForeignKey("UserId")]
    public virtual required User User { get; set; }
    
    /// <summary>
    /// Історія точний локацій активності.
    /// </summary>
    public virtual required List<Location> Locations { get; set; }
}