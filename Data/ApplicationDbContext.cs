using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project_1_KYH.Models;

namespace Project_1_KYH.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<Company> Companies { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Consultant> Consultants { get; set; }
    }
}