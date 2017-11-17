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
    public class DeleteModel : PageModel
    {
        private readonly EnglishProject.Data.EnglishContext _context;

        public DeleteModel(EnglishProject.Data.EnglishContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EnglishTask = await _context.EnglishTask.FindAsync(id);

            if (EnglishTask != null)
            {
                _context.EnglishTask.Remove(EnglishTask);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
