using Framework.Contracts.Identities.Core.Entities;

namespace Persistence.Ef;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser
    , ApplicationRole
    , string
    , ApplicationUserClaim
    , ApplicationUserRole
    , ApplicationUserLogin
    , ApplicationRoleClaim
    , ApplicationUserToken>
{
    
    public ApplicationDbContext(string dbConnectionStrings)
        : this(new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer(dbConnectionStrings).Options)
    {
    }

    public ApplicationDbContext
        (DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(ApplicationDbContext).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(ApplicationUser).Assembly);
    }
}