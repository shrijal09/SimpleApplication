using DataAccess.Repository.IRepository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class AppConfigRepository : Repository<ApplicationConfiguration>, IAppConfigRepository
    {
        private ApplicationDbContext _db;
        public AppConfigRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ApplicationConfiguration obj)
        {
            _db.ApplicationConfiguration.Update(obj);
        }
    }
}
