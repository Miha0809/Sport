namespace Sport.API.Models.DTOs.Response.Location;

/// <summary>
/// DTO локації для показу.
/// </summary>
public class LocationShowDto
{
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
}