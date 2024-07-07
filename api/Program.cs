global using FluentValidation;
using api.Configuration.Options;
using api.Database;
using api.Features.Posts;
using api.Features.Users;
using api.Models;
using api.Services.PasswordHasher;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder();
builder.Services.AddFastEndpoints().SwaggerDocument();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(JwtOptions.SectionName));

builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IRepository<Post, Guid>, PostRepository>();
builder.Services.AddScoped<IRepository<User, Guid>, UserRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();
app.UseFastEndpoints().UseSwaggerGen();

app.Run();
