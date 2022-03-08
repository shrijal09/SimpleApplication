using Microsoft.EntityFrameworkCore;
using SimpleApplication.Models;

namespace SimpleApplication.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Configuration> Configurations { get; set; }
    }
}
