using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

using _3dmarketplace.src.Interfaces;
using _3dmarketplace.src.Models;
using _3dmarketplace.src.Repository;
using _3dmarketplace.src.Services;
using Microsoft.AspNetCore.Identity;




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
builder.Services.AddAuthentication(IdentityConstants.BearerScheme);
// .AddJwtBearer(options =>
// {
//     options.TokenValidationParameters = new TokenValidationParameters
//     {
//         ValidateIssuer = true,
//         ValidateAudience = true,
//         ValidateLifetime = true,
//         ValidateIssuerSigningKey = false,
//         ValidIssuer = builder.Configuration["Jwt:Issuer"],
//         ValidAudience = builder.Configuration["Jwt:Audience"]
//     };
//     options.IncludeErrorDetails = true;
//     options.Events = new JwtBearerEvents
//     {
//         OnAuthenticationFailed = context =>
//         {

//             context.Request.Headers.TryGetValue("Authorization", out var token);
//             Console.WriteLine(context.Exception.GetType().ToString());
//             if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
//             {
//                 context.Response.Headers.Append("Token-Expired", "true");
//             }
//             return Task.CompletedTask;
//         }
//     };
// });

builder.Services.AddAuthorization();

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


builder.Services.AddIdentityApiEndpoints<UserMetadata>(opt =>
{
    opt.Password.RequireDigit = false;
    opt.Password.RequireLowercase = false;
})
.AddEntityFrameworkStores<AplicationContext>()
.AddDefaultTokenProviders();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors();

app.MapControllers();
app.MapHealthChecks("/healthz");
var auth_endpoints = app.MapIdentityApi<UserMetadata>();




app.Run();


// app.MapPost("/login", async (LoginModel model, UserManager<UserMetadata> userManager, IConfiguration configuration) =>
// {
//     var user = await userManager.FindByNameAsync(model.Username);
//     if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
//     {
//         var claims = new[]
//         {
//             new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
//             new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
//             // Additional claims
//         };

//         var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
//         var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

//         var token = new JwtSecurityToken(
//             issuer: configuration["Jwt:Issuer"],
//             audience: configuration["Jwt:Audience"],
//             claims: claims,
//             expires: DateTime.UtcNow.AddHours(1),
//             signingCredentials: creds);

//         return Results.Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
//     }

//     return Results.Unauthorized();
// });