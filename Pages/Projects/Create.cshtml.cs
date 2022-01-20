﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project_1_KYH.Data;
using Project_1_KYH.Models;

namespace Project_1_KYH.Pages.Projects
{
    public class CreateModel : PageModel
    {
        private readonly Project_1_KYH.Data.ApplicationDbContext _context;

        public CreateModel(Project_1_KYH.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Project Project { get; set; }

        [BindProperty]
        public Company Company { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var found = _context.Companies.FirstOrDefault(c => c.Name.ToLower() == Company.Name.ToLower());
            if (found is null)
            {
                Project.Company = Company;
            }
            else
            {
                Project.Company = found;
            }

            _context.Projects.Add(Project);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
