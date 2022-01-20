using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project_1_KYH.Data;
using Project_1_KYH.Models;

namespace Project_1_KYH.Pages.Projects
{
    public class DeleteModel : PageModel
    {
        private readonly Project_1_KYH.Data.ApplicationDbContext _context;

        public DeleteModel(Project_1_KYH.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Project Project { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Project = await _context.Projects.FirstOrDefaultAsync(m => m.id == id);

            if (Project == null)
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

            Project = await _context.Projects.FindAsync(id);

            if (Project != null)
            {
                _context.Projects.Remove(Project);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
