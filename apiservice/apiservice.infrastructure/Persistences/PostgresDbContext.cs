using ApiService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ApiService.Infrastructure.Persistence;

public class PostgresDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    public PostgresDbContext(DbContextOptions<PostgresDbContext> options, IConfiguration configuration)
        : base(options) 
    { 
        _configuration = configuration;
    }

    public DbSet<Submission> Submissions { get; set; }
    public DbSet<Classification> Classifications { get; set; }
}
