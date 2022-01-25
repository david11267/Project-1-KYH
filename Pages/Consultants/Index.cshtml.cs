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
    public class IndexModel : PageModel
    {
        private readonly Project_1_KYH.Data.ApplicationDbContext _context;

        public IndexModel(Project_1_KYH.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Consultant> Consultant { get;set; }

        public async Task OnGetAsync()
        {
            Consultant = await _context.Consultants.ToListAsync();
        }
    }
}
