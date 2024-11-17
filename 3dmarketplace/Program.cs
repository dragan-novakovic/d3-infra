using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Npgsql;


var connString = "Host=192.168.1.11;Username=casaos;Password=casaos;Database=casaos";

await using var conn = new NpgsqlConnection(connString);
await conn.OpenAsync();

var tables = new List<string>();
string query = "SELECT table_name FROM information_schema.tables WHERE table_schema = 'public'";
using (var command = new NpgsqlCommand(query, conn))
{
    using (var reader = command.ExecuteReader()) { while (reader.Read()) { tables.Add(reader.GetString(0)); } }
}
Console.WriteLine("Tables: " + string.Join(", ", tables));


// var builder = WebApplication.CreateBuilder(args);


// builder.Services.AddAuthentication();
// builder.Services.AddControllers();
// builder.Services.AddDbContext<UserDataContext>(options =>
// {
//     options.Usen("Data Source=.;Initial Catalog=Identity;Integrated Security=True");
// });
// builder.Services.AddIdentityApiEndpoints<IdentityUser>().AddEntityFrameworkStores<UserDataContext>();


// var app = builder.Build();


// app.MapIdentityApi<IdentityUser>();
// app.UseAuthorization();
// app.MapControllers();

// app.Run();
