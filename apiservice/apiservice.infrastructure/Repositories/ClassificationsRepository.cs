using ApiService.Application.Interfaces;
using ApiService.Domain.Entities;
using ApiService.Infrastructure.Persistence;

using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ApiService.Infrastructure.Repositories;

public class ClassificationRepository : IClassificationRepository
{
     private readonly PostgresDbContext _context;

    public ClassificationRepository(PostgresDbContext context)
    {
        _context = context;
    }

    public async Task CreateClassificationAsync(Classification classification) =>
        await _context.Classifications.AddAsync(classification);

    public async Task SaveChangesAsync() =>
        await _context.SaveChangesAsync();


    public async Task<int> CountClassificationAsync() => 
        await _context.Classifications.CountAsync();
}
