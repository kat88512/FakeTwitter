using Api.Extensions;
using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;
using Services.Configuration;
using Services.DataAccess;
using Services.PasswordHasher;

var builder = WebApplication.CreateBuilder();

var jwtOptions = builder.Configuration.GetSection(JwtOptions.SectionName).Get<JwtOptions>();

builder
    .Services.AddAuthenticationJwtBearer(s => s.SigningKey = jwtOptions!.Key)
    .AddAuthorization()
    .AddFastEndpoints()
    .SwaggerDocument();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("Api")
    );
});

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(JwtOptions.SectionName));

builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();

builder.Services.AddRepositories();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

app.UseAuthentication().UseAuthorization().UseFastEndpoints().UseSwaggerGen();

app.Run();
