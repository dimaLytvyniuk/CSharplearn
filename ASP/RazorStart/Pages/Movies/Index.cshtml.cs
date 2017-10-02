using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorStart.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RazorStart.PagesMovies
{
    public class IndexModel : PageModel
    {
        private readonly RazorStart.Models.MovieContext _context;

        public IndexModel(RazorStart.Models.MovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }
        public SelectList Genres;
        public string MovieGenre { get; set; }


        public async Task OnGetAsync(string movieGenre, string searchString)
        {
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;
                                            
            var movies = from m in _context.Movie
                        select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => (s.Title.Contains(searchString) || s.Genre.Contains(searchString)));
            }

            if (!String.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.Genre == movieGenre);
            }
            Movie = await movies.ToListAsync();
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
        }
    }
}
