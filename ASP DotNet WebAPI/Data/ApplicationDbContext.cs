using ASP_DotNet_WebAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASP_DotNet_WebAPI.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet <Employee> Employees{ get; set; }
    }
}
