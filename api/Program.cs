using api.Data;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder();
builder.Services.AddFastEndpoints().SwaggerDocument();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();
app.UseFastEndpoints().UseSwaggerGen();
app.Run();
