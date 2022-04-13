using Models;
using System.Collections;

namespace DataAccess.Services.Interfaces
{
    public interface IApplicationConfigurationRepository
    {
        Task<List<ApplicationConfiguration>> GetAllAsync();
        Task<ApplicationConfiguration> GetByIdAsync(int id);
        Task<ApplicationConfiguration> CreateApplicationConfigurationAsync(ApplicationConfiguration applicationConfiguration);
        Task<ApplicationConfiguration> UpdateApplicationConfigurationAsync(ApplicationConfiguration applicationConfiguration);
        void DeleteApplicationConfigurationAsync(int id);
    }
}
