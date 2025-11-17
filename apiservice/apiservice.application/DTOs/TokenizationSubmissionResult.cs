namespace ApiService.Application.DTO;
public class TokenizationSubmissionResult
{
    public string UpdatedText { get; set; } = string.Empty;
    public List<string> FoundPii { get; set; } = new();
    public List<string> TokenizedPii { get; set; } = new();
}
