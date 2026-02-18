using Microsoft.EntityFrameworkCore;
using TalentForge.Application.Contracts.Persistence;
using TalentForge.Application.DTOs.Tasks;
using TalentForge.Domain;

namespace TalentForge.Persistence.Repositories
{
    public class TaskRepository : GenericRepository<Domain.Task>, ITaskRepository
    {
        private readonly TalentForgeDbContext _dbContext;
        public TaskRepository(TalentForgeDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
