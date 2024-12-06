using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using _3dmarketplace.src.Interfaces;
using _3dmarketplace.src.Models;
using _3dmarketplace.src.Repository;
using _3dmarketplace.src.Services;




var builder = WebApplication.CreateBuilder(args);


builder.Configuration.SetBasePath($"{Directory.GetCurrentDirectory()}/Settings")
                     .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                     .AddEnvironmentVariables();


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});
builder.Services.AddAuthentication();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks().AddCheck<DatabaseHealthCheck>("database_health_check", Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Unhealthy);
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);


builder.Services.AddDbContext<AplicationContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresLocal"));
});
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<UserService>();


builder.Services.AddIdentityApiEndpoints<UserMetadata>().AddEntityFrameworkStores<AplicationContext>();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? throw new InvalidOperationException("JWT Key is not configured")))
    };
});
app.MapControllers();
app.MapHealthChecks("/healthz");
app.MapIdentityApi<UserMetadata>();
app.UseRouting();

app.UseCors();


app.Run();
