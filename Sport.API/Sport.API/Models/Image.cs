namespace Sport.API.Models;

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
}