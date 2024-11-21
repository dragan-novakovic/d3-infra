using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);


builder.Configuration.SetBasePath($"{Directory.GetCurrentDirectory()}/Settings")
                     .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                     .AddEnvironmentVariables();


builder.Services.AddAuthentication();
builder.Services.AddControllers();


builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddDbContext<UserDataContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresLocal"));
});


builder.Services.AddIdentityApiEndpoints<IdentityUser>().AddEntityFrameworkStores<UserDataContext>();


var app = builder.Build();

app.MapIdentityApi<IdentityUser>();
app.UseAuthorization();
app.MapControllers();

app.Run();
