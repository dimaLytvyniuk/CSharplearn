using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityWebStudy
{
    public class StudyDbContext : IdentityDbContext<User, UserRole, Guid>
    {
        public StudyDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserRole>().HasData(
                new UserRole { Id = Guid.NewGuid(), Name = "Admin", NormalizedName = "ADMIN" });
        }
    }
}
