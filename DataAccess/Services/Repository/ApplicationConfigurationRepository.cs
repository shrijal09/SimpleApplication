using DataAccess;
using DataAccess.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections;

namespace DataAccess.Services.Repository
{
    public class ApplicationConfigurationRepository : IApplicationConfigurationRepository
    {
        private readonly ApplicationDbContext _context;
        public ApplicationConfigurationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ApplicationConfiguration> CreateApplicationConfigurationAsync(ApplicationConfiguration applicationConfiguration)
        {
            _context.Add(applicationConfiguration);
            await _context.SaveChangesAsync();
            return applicationConfiguration;
        }

        public void DeleteApplicationConfigurationAsync(int id)
        {
            ApplicationConfiguration applicationConfiguration = _context.ApplicationConfiguration.Find(id);
            _context.ApplicationConfiguration.Remove(applicationConfiguration);
            _context.SaveChanges();
        }

        public async Task<List<ApplicationConfiguration>> GetAllAsync()
        {
            return await _context.ApplicationConfiguration.ToListAsync();
        }

        public async Task<ApplicationConfiguration> GetByIdAsync(int id)
        {
           return await _context.ApplicationConfiguration.FindAsync(id);
        }

        public async Task<ApplicationConfiguration> UpdateApplicationConfigurationAsync(ApplicationConfiguration applicationConfiguration)
        {
            _context.Update(applicationConfiguration);
            await _context.SaveChangesAsync();
            return applicationConfiguration;
        }
    }
}
