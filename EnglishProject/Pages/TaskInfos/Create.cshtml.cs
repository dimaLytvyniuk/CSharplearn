using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EnglishProject.Data;
using EnglishProject.Models;

namespace EnglishProject.Pages.TaskInfos
{
    public class CreateModel : PageModel
    {
        private readonly EnglishProject.Data.EnglishContext _context;

        public CreateModel(EnglishProject.Data.EnglishContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TaskInfo TaskInfo { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TaskInfo.Add(TaskInfo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}