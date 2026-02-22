using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentForge.Domain;

namespace TalentForge.Application.Contracts.Persistence
{
    public interface IApplicationRepository : IGenericRepository<JobApplication>
    {
        Task<int> GetApplicationCountByJobIdAsync(Guid jobId, CancellationToken cancellationToken);
        Task<Dictionary<Guid, int>> GetApplicationCountsByJobIdsAsync(
          List<Guid> jobIds,
          CancellationToken cancellationToken);
    }
}
