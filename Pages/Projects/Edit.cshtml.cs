using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project_1_KYH.Data;
using Project_1_KYH.Models;

namespace Project_1_KYH.Pages.Projects
{
    public class EditModel : PageModel
    {
        private readonly Project_1_KYH.Data.ApplicationDbContext _context;

        public EditModel(Project_1_KYH.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Project Project { get; set; }
        public IEnumerable<Consultant> Consultants { get; set; }
        [BindProperty]
        public List<int> SelectedConsultants { get; set; } = new List<int>();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Project = await _context.Projects
                .Include(c => c.Company).Include(c=>c.Consultants).FirstOrDefaultAsync(m => m.id == id);

            Consultants = await _context.Consultants.ToListAsync();
            Project.Consultants.ForEach(c => SelectedConsultants.Add(c.id));

            ViewData["Consult"] = new MultiSelectList(_context.Consultants.ToList(), "id", "name");

            if (Project == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Project).State = EntityState.Modified;

            foreach (var item in SelectedConsultants)
            {
                Project.Consultants.Add(_context.Consultants
                    .Find(item));
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(Project.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.id == id);
        }
    }
}
