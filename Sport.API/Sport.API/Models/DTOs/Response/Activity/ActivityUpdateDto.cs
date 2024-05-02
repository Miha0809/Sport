namespace Sport.API.Models.DTOs.Response.Activity;

using Location;

/// <summary>
/// DTO редагування активності
/// </summary>
public class ActivityUpdateDto
{
    /// <summary>
    /// Ідентифікатор.
    /// </summary>
    public required int Id { get; set; }
    
    /// <summary>
    /// Дистанція у метрах.
    /// </summary>
    public required double Distance { get; set; }
    
    /// <summary>
    /// Точна локація активності.
    /// </summary>
    public virtual required LocationDto Location { get; set; }
}