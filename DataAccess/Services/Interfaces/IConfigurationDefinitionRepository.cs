using Models;

namespace DataAccess.Services.Interfaces
{
    public interface IConfigurationDefinitionRepository
    {
        Task<List<ConfigurationDefinition>> GetAllAsync();
        Task<ConfigurationDefinition> GetByIdAsync(int id);
        Task<ConfigurationDefinition> CreateConfigurationDefinitionAsync(ConfigurationDefinition configurationDefinition);
        Task<ConfigurationDefinition> UpdateConfigurationDefinitionAsync(ConfigurationDefinition configurationDefinition);
        void DeleteConfigurationDefinitionAsync(int id);
    }
}
