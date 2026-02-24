using Microsoft.EntityFrameworkCore;
using TalentForge.Application.Contracts.Persistence;
using TalentForge.Domain;

namespace TalentForge.Persistence.Repositories
{
    public class InterviewRepository : GenericRepository<Interview>, IInterviewRepository
    {
        private readonly TalentForgeDbContext _dbContext;
        public InterviewRepository(TalentForgeDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
