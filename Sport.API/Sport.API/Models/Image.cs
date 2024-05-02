namespace Sport.API.Models;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Зображення.
/// </summary>
public class Image
{
    /// <summary>
    /// Ідентифікатор.
    /// </summary>
    [Key]
    public int Id { get; set; }
    
    /// <summary>
    /// Адрес зображення.
    /// </summary>
    public required string Link { get; set; }
    
    /// <summary>
    /// Ідентифікатор активності.
    /// </summary>
    public string? UserId { get; set; }
    
    /// <summary>
    /// Активність, до якої належить локація.
    /// </summary>
    [ForeignKey("UserId")]
    public virtual required User User { get; set; }
}