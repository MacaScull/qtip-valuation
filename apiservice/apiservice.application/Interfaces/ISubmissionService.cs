using ApiService.Domain.Entities;

namespace ApiService.Application.Interfaces;

public interface ISubmissionService
{
    Task<Submission> CreateSubmissionAsync(string text);
    Task<int> CountSubmissionClassicationsAsync();
}
