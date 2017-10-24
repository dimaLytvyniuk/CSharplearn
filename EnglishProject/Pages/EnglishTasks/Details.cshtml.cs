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
    public class DetailsModel : PageModel
    {
        private readonly EnglishProject.Data.EnglishContext _context;

        public DetailsModel(EnglishProject.Data.EnglishContext context)
        {
            _context = context;
        }

        public EnglishTask EnglishTask { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EnglishTask = await _context.EnglishTask.SingleOrDefaultAsync(m => m.ID == id);

            if (EnglishTask == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
