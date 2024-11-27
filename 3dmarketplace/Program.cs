using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;



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


builder.Services.AddIdentityApiEndpoints<IdentityUser>().AddEntityFrameworkStores<AplicationContext>();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.MapHealthChecks("/healthz");
app.MapIdentityApi<IdentityUser>();
app.UseAuthorization();
app.UseCors();


app.Run();
