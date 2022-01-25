using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project_1_KYH.Data;
using Project_1_KYH.Models;

namespace Project_1_KYH.Pages.Companies
{
    public class DetailsModel : PageModel
    {
        private readonly Project_1_KYH.Data.ApplicationDbContext _context;

        public DetailsModel(Project_1_KYH.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Company Company { get; set; }
        [BindProperty]
        public List<Project> Projects { get; set; }
        [BindProperty]
        public string ProjectAmmount { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Projects = await _context.Projects.ToListAsync();          
            Company = await _context.Companies
               .FirstOrDefaultAsync(m => m.ID == id);
            
            ProjectAmmount = Projects
                .Where(p => p.Company != null)
                .Select(p =>p.Company.ID == Company.ID).Count().ToString();

            if (Company == null)
            {
                return NotFound();
            }
            return Page();
        }
        
    }
}
