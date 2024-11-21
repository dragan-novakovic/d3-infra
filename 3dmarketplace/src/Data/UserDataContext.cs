using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

public class UserDataContext : IdentityDbContext<IdentityUser>
{

    public readonly IConfiguration _configuration;
    public UserDataContext(DbContextOptions<UserDataContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }
};