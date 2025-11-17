using ApiService.Domain.Entities;
using ApiService.Application.Interfaces;
using ApiService.Application.DTO;
using System.Text.RegularExpressions;

namespace ApiService.Application.Services;

public class SubmissionService : ISubmissionService
{
    private readonly ISubmissionRepository _submissionRepository;
    private readonly IClassificationRepository _classificationRepository;

    public SubmissionService(ISubmissionRepository submissionRepository, IClassificationRepository classificationRepository)
    {
        _submissionRepository = submissionRepository;
        _classificationRepository = classificationRepository;
    }

    private TokenizationSubmissionResult TokenGeneration(string input)
    {
        TokenizationSubmissionResult result = new TokenizationSubmissionResult();

        var pattern = @"\b[\w\.-]+@[\w\.-]+\.\w{2,}\b";

        string updatedText = Regex.Replace(input, pattern, match =>
        {
            var email = match.Value;

            var token = $"{{TKN-{Guid.NewGuid()}}}";

            result.FoundPii.Add(email);
            result.TokenizedPii.Add(token);

            return token;
        });

        result.UpdatedText = updatedText;
        return result;
    }

    public async Task<Submission> CreateSubmissionAsync(string text)
    {
        TokenizationSubmissionResult result = TokenGeneration(text);
        Submission submission = new Submission
        {
            SubmissionText = result.UpdatedText
        };
        await _submissionRepository.CreateSubmissionAsync(submission);
        await _submissionRepository.SaveChangesAsync();

        for (int i = 0; i < result.FoundPii.Count; i++)
        {
            Classification classification = new Classification
            {
              Token = result.TokenizedPii[i],
              OriginalData = result.FoundPii[i],
            };
            classification.Tags.Add("pii.email");

            await _classificationRepository.CreateClassificationAsync(classification);
            await _classificationRepository.SaveChangesAsync();
        }

        return submission;
    }

    public async Task<int> CountSubmissionClassicationsAsync()
    {
        return await _classificationRepository.CountClassificationAsync();
    }
}
