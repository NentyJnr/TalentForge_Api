using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentForge.Application.Contracts.Persistence;

namespace TalentForge.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TalentForgeDbContext _context;
        private IInterviewRepository _interviewRepository;
        private IApplicationRepository _applicationRepository;
        private IJobRepository _jobRepository;

        public UnitOfWork(TalentForgeDbContext context)
        {
            _context = context;
        }

        public IInterviewRepository InterviewRepository => 
         _interviewRepository ??= new InterviewRepository(_context);

        public IApplicationRepository ApplicationRepository =>
         _applicationRepository ??= new ApplicationRepository(_context);

        public IJobRepository JobRepository => 
         _jobRepository ??= new JobRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
