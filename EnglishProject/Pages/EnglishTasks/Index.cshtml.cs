using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EnglishProject.Data;
using EnglishProject.Models;

namespace EnglishProject.Pages.EnglishTasks
{
    public class IndexModel : PageModel
    {
        private readonly EnglishProject.Data.EnglishContext _context;

        public IndexModel(EnglishProject.Data.EnglishContext context)
        {
            _context = context;
        }

        public IList<EnglishTask> EnglishTask { get;set; }

        public async Task OnGetAsync()
        {
            EnglishTask = await _context.EnglishTask.ToListAsync();
        }
    }
}
