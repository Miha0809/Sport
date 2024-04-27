using System.ComponentModel.DataAnnotations;

namespace Sport.API.Models;

/// <summary>
/// Тип активності.
/// </summary>
public class ActivityType
{
    /// <summary>
    /// Ідентифікатор.
    /// </summary>
    [Key]
    public int Id { get; set; }
    
    /// <summary>
    /// Назва типу активності.
    /// </summary>
    public required string Name { get; set; } 
}