using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ApplicationConfiguration> ApplicationConfiguration { get; set; }
        public DbSet<ConfigurationDefinition> ConfigurationDefinition { get; set; }
        public DbSet<SSIS_Config> SSIS_Config { get; set; }
    }
}
