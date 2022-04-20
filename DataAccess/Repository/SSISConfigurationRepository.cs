using DataAccess.Repository.IRepository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class SSISConfigurationRepository : Repository<SSIS_Config>, ISSISConfigurationRepository
    {
        private ApplicationDbContext _db;
        public SSISConfigurationRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(SSIS_Config obj)
        {
            _db.SSIS_Config.Update(obj);
        }
    }
}
