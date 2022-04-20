using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface ISSISConfigurationRepository : IRepository<SSIS_Config>
    {
        void Update(SSIS_Config obj);
    }
}
