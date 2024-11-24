using Microsoft.EntityFrameworkCore;

public class UserMetaDataContext : DbContext
{

    public readonly IConfiguration _configuration;
    public UserMetaDataContext(DbContextOptions<UserMetaDataContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    public DbSet<UserMetaDataContext> UserMetaData { get; set; }
    public DbSet<UserDataContext> UserData { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
};