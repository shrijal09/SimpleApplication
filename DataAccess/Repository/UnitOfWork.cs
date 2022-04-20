using DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            AppConfig = new AppConfigRepository(_db);
            ConfigDefinition = new ConfigDefinitionRepository(_db);
            SSISConfiguration = new SSISConfigurationRepository(_db);
        }
        public IAppConfigRepository AppConfig { get; private set; }
        public IConfigDefinitionRepository ConfigDefinition { get; private set; }
        public ISSISConfigurationRepository SSISConfiguration { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
