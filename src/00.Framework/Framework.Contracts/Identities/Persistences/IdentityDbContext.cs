using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Framework.Contracts.Identities.Persistences;

public class IdentityDbContext : IdentityDbContext<ApplicationUser
    , ApplicationRole
    , string
    , ApplicationUserClaim
    , ApplicationUserRole
    , ApplicationUserLogin
    , ApplicationRoleClaim
    , ApplicationUserToken>
{
    
}