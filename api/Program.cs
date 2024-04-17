using api.Data;
using api.Interfaces;
using api.Models;
using api.Repositories;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder();
builder.Services.AddFastEndpoints().SwaggerDocument();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IRepository<Post, Guid>, PostRepository>();

var app = builder.Build();
app.UseFastEndpoints().UseSwaggerGen();
app.Run();
