using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EnglishProject.Data;
using EnglishProject.Models;

namespace EnglishProject.Pages.TaskInfos
{
    public class DeleteModel : PageModel
    {
        private readonly EnglishProject.Data.EnglishContext _context;

        public DeleteModel(EnglishProject.Data.EnglishContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TaskInfo TaskInfo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TaskInfo = await _context.TaskInfo.SingleOrDefaultAsync(m => m.ID == id);

            if (TaskInfo == null)
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

            TaskInfo = await _context.TaskInfo.FindAsync(id);

            if (TaskInfo != null)
            {
                _context.TaskInfo.Remove(TaskInfo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
