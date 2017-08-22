using Microsoft.EntityFrameworkCore;

namespace HelloASP.Models
{
    public class MvcMovieContext : DbContext 
    {
        public MvcMovieContext (DbContextOptions<MvcMovieContext> options) : base(options)
        {
        }

        public DbSet<HelloASP.Models.Movie> Movie { get; set; }
    }
}