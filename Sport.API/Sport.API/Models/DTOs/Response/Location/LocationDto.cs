namespace Sport.API.Models.DTOs.Response.Location;

/// <summary>
/// DTO локації.
/// </summary>
public class LocationDto
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