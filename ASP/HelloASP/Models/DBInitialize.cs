using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace HelloASP.Models
{
    public static class DBInitialize
    {
        public static void EnsureCreated(IServiceProvider serviceProvider)
        {
            var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>());
            context.Database.EnsureCreated();
        }
    }
}