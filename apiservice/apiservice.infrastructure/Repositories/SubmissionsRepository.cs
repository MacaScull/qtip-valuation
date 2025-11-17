using ApiService.Application.Interfaces;
using ApiService.Domain.Entities;
using ApiService.Infrastructure.Persistence;

using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ApiService.Infrastructure.Repositories;

public class SubmissionRepository : ISubmissionRepository
{
     private readonly PostgresDbContext _context;

    public SubmissionRepository(PostgresDbContext context)
    {
        _context = context;
    }

    public async Task CreateSubmissionAsync(Submission Submission) =>
        await _context.Submissions.AddAsync(Submission);

    public async Task SaveChangesAsync() =>
        await _context.SaveChangesAsync();
}
