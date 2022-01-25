﻿using System;
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
    public class DeleteModel : PageModel
    {
        private readonly Project_1_KYH.Data.ApplicationDbContext _context;

        public DeleteModel(Project_1_KYH.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Company Company { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Company = await _context.Companies.FirstOrDefaultAsync(m => m.ID == id);

            if (Company == null)
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

            Company = await _context.Companies.FindAsync(id);

            if (Company != null)
            {
                _context.Companies.Remove(Company);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
