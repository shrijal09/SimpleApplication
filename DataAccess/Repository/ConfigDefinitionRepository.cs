using DataAccess.Repository.IRepository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ConfigDefinitionRepository : Repository<ConfigurationDefinition>, IConfigDefinitionRepository
    {
        private ApplicationDbContext _db;
        public ConfigDefinitionRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ConfigurationDefinition obj)
        {
            _db.ConfigurationDefinition.Update(obj);
        }
    }
}
