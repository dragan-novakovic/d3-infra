using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var connString = "Host=192.168.1.11;Username=casaos;Password=casaos;Database=casaos";


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAuthentication();
builder.Services.AddControllers();
builder.Services.AddDbContext<UserDataContext>(options =>
{
    options.UseNpgsql(connString);
});
builder.Services.AddIdentityApiEndpoints<IdentityUser>().AddEntityFrameworkStores<UserDataContext>();


var app = builder.Build();


app.MapIdentityApi<IdentityUser>();
app.UseAuthorization();
app.MapControllers();

app.Run();
