namespace Sport.API.Models.DTOs.User;

public class UserShowDto
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    
    public required string Email { get; set; }
    public required bool EmailConfirmed { get; set; }
    
    public string? PhoneNumber { get; set; }
    public required bool PhoneNumberConfirmed { get; set; }
    public required bool TwoFactorEnabled { get; set; }
}