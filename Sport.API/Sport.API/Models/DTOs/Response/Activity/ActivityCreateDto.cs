using System.ComponentModel.DataAnnotations;
using Sport.API.Models.DTOs.User;
using Sport.API.Models.Enums;

namespace Sport.API.Models.DTOs.Activity;

/// <summary>
/// 
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
    [EnumDataType(typeof(ActivityType))]
    public ActivityType ActivityType { get; set; }
    
    /// <summary>
    /// Автор активності.
    /// </summary>
    public virtual UserShowPublicDto? User { get; set; }
    
    // TODO: likes
}