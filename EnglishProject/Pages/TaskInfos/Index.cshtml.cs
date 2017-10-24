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
    public class IndexModel : PageModel
    {
        private readonly EnglishProject.Data.EnglishContext _context;

        public IndexModel(EnglishProject.Data.EnglishContext context)
        {
            _context = context;
        }

        public IList<TaskInfo> TaskInfo { get;set; }

        public async Task OnGetAsync()
        {
            TaskInfo = await _context.TaskInfo.ToListAsync();
        }
    }
}
