using System.ComponentModel.DataAnnotations;

namespace ApiService.Domain.Entities;

public class Submission
{
    public Guid Id { get; set; }
    [Required]
    public string SubmissionText { get; set; }
}
