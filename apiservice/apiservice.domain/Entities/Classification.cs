using System.ComponentModel.DataAnnotations;

namespace ApiService.Domain.Entities;

public class Classification
{
    [Key]
    public string Token { get; set; }
    [Required]
    public string OriginalData { get; set; }
    [Required]
    public List<string> Tags { get; set; } = new List<string>();
}
