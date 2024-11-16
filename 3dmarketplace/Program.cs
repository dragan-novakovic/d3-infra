using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAuthentication();
builder.Services.AddControllers();
builder.Services.AddDbContext<UserDataContext>(options =>
{
    options.UseSqlServer("Data Source=.;Initial Catalog=Identity;Integrated Security=True");
});
builder.Services.AddIdentityApiEndpoints<IdentityUser>().AddEntityFrameworkStores<UserDataContext>();


var app = builder.Build();


app.MapIdentityApi<IdentityUser>();
app.UseAuthorization();
app.MapControllers();

app.Run();
