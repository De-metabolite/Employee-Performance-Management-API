
using Employee_Performance_Management_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Employee_Performance_Management_API.Data
{
    public class ApplicationDbContext:IdentityDbContext<AppUser>
    {
       public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options) { }
        public DbSet<Employee>Employees   { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<PerformanceReview> PerformanceReviews { get; set; }

    }
}
