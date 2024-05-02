namespace Sport.API.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Локація.
/// </summary>
public class Location
{
    /// <summary>
    /// Ідентифікатор.
    /// </summary>
    [Key]
    public int Id { get; set; }
    
    /// <summary>
    /// Поточний час.
    /// </summary>
    public DateTime DateTime { get; set; }
    
    /// <summary>
    /// Ширина (X).
    /// </summary>
    public double Latitude { get; set; }
    
    /// <summary>
    /// Довжина (Y).
    /// </summary>
    public double Longitude { get; set; }
    
    /// <summary>
    /// Ідентифікатор активності.
    /// </summary>
    public int ActivityId { get; set; }
    
    /// <summary>
    /// Активність, до якої належить локація.
    /// </summary>
    [ForeignKey("ActivityId")]
    public virtual required Activity Activity { get; set; }
}