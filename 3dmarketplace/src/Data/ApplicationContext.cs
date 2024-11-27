using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using _3dmarketplace.src.Models;

public class AplicationContext : IdentityDbContext<UserMetadata>
{

    public readonly IConfiguration _configuration;
    public AplicationContext(DbContextOptions<AplicationContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserMetadata>()
                .HasMany(u => u.Products)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);
    }
};