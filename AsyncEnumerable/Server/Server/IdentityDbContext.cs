using Microsoft.EntityFrameworkCore;

namespace Server
{
    public class IdentityDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();

        public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
            : base(options)
        {
        }
    }
}
