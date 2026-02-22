using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentForge.Application.Contracts.Persistence;
using TalentForge.Domain;

namespace TalentForge.Persistence.Repositories
{
    public class JobRepository : GenericRepository<Job>, IJobRepository
    {
        private readonly TalentForgeDbContext _dbContext;
        public JobRepository(TalentForgeDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
