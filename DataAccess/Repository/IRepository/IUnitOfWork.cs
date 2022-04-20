using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IAppConfigRepository AppConfig { get; }
        IConfigDefinitionRepository ConfigDefinition { get; }
        ISSISConfigurationRepository SSISConfiguration { get; }
        void Save();
    }
}
