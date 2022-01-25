using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project_1_KYH.Data;
using Project_1_KYH.Models;

namespace Project_1_KYH.Pages.Consultants
{
    public class DeleteModel : PageModel
    {
        private readonly Project_1_KYH.Data.ApplicationDbContext _context;

        public DeleteModel(Project_1_KYH.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Consultant Consultant { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Consultant = await _context.Consultants.FirstOrDefaultAsync(m => m.id == id);

            if (Consultant == null)
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

            Consultant = await _context.Consultants.FindAsync(id);

            if (Consultant != null)
            {
                _context.Consultants.Remove(Consultant);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
