using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

public class UserDataContext : IdentityDbContext<IdentityUser>
{
    public UserDataContext(DbContextOptions<UserDataContext> options) : base(options)
    {
    }
};