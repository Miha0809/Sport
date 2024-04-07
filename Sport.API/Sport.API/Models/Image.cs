using System.ComponentModel.DataAnnotations;

namespace Sport.API.Models;

public class Image
{
    [Key]
    public int Id { get; set; }
    
    public required string Link { get; set; }
}