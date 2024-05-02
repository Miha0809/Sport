namespace Sport.API.Models.DTOs.Response.Location;

/// <summary>
/// DTO локації для оновлення активності.
/// </summary>
public class LocationUpdateDto
{
    /// <summary>
    /// Ширина (X).
    /// </summary>
    public double Latitude { get; set; }
    
    /// <summary>
    /// Довжина (Y).
    /// </summary>
    public double Longitude { get; set; }
}