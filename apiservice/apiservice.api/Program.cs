using Microsoft.EntityFrameworkCore;
using ApiService.Infrastructure.Persistence;
using ApiService.Application.Interfaces;
using ApiService.Infrastructure.Repositories;
using ApiService.Application.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddDbContext<PostgresDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));
    
builder.Services.AddScoped<ISubmissionRepository, SubmissionRepository>();
builder.Services.AddScoped<IClassificationRepository, ClassificationRepository>();

builder.Services.AddScoped<ISubmissionService, SubmissionService>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("any", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PostgresDbContext>();
    db.Database.Migrate();
}

app.UseCors("any");

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run("http://0.0.0.0:5066");