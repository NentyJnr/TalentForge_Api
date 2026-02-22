using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentForge.Application.Contracts.Persistence;
using TalentForge.Domain;

namespace TalentForge.Persistence.Repositories
{
    // TalentForge.Persistence.Repositories/ApplicationRepository.cs

    public class ApplicationRepository : GenericRepository<Job>, IApplicationRepository
    {
        private readonly TalentForgeDbContext _dbContext;
        public ApplicationRepository(TalentForgeDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Dictionary<Guid, int>> GetApplicationCountsByJobIdsAsync(
          List<Guid> jobIds,
          CancellationToken cancellationToken)
        {
            if (jobIds == null || !jobIds.Any())
                return new Dictionary<Guid, int>();

            return await _dbContext.Applications
                .Where(a => jobIds.Contains(a.JobId) && a.IsDeleted == false)
                .GroupBy(a => a.JobId)
                .Select(g => new { JobId = g.Key, Count = g.Count() })
                .ToDictionaryAsync(x => x.JobId, x => x.Count, cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<int> GetApplicationCountByJobIdAsync(Guid jobId, CancellationToken cancellationToken)
        {
            return await _dbContext.Applications
                .CountAsync(a => a.JobId == jobId && a.IsDeleted == false, cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
