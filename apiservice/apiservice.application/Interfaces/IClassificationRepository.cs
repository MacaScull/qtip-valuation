using ApiService.Domain.Entities;

namespace ApiService.Application.Interfaces;

public interface IClassificationRepository
{
    Task CreateClassificationAsync(Classification classification);
    Task SaveChangesAsync();
    Task<int> CountClassificationAsync();
}
