using DataAccess;
using DataAccess.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess.Services.Repository
{
    public class ConfigurationDefinitionRepository : IConfigurationDefinitionRepository
    {
        private readonly ApplicationDbContext _context;
        public ConfigurationDefinitionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ConfigurationDefinition> CreateConfigurationDefinitionAsync(ConfigurationDefinition configurationDefinition)
        {
            _context.Add(configurationDefinition);
            await _context.SaveChangesAsync();
            return configurationDefinition;
        }

        public void DeleteConfigurationDefinitionAsync(int id)
        {
            ConfigurationDefinition configurationDefinition = _context.ConfigurationDefinition.Find(id);
            _context.ConfigurationDefinition.Remove(configurationDefinition);
            _context.SaveChanges();
        }

        public async Task<List<ConfigurationDefinition>> GetAllAsync()
        {
            return await _context.ConfigurationDefinition.ToListAsync();
        }

        public async Task<ConfigurationDefinition> GetByIdAsync(int id)
        {
            return await _context.ConfigurationDefinition.FindAsync(id);
        }

        public async Task<ConfigurationDefinition> UpdateConfigurationDefinitionAsync(ConfigurationDefinition configurationDefinition)
        {
            _context.Update(configurationDefinition);
            await _context.SaveChangesAsync();
            return configurationDefinition;
        }
    }
}
