using ApiService.Domain.Entities;

namespace ApiService.Application.Interfaces;

public interface ISubmissionRepository
{
    Task CreateSubmissionAsync(Submission Submission);
    Task SaveChangesAsync();
}
