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
        private ITaskRepository _taskRepository;

        public UnitOfWork(TalentForgeDbContext context)
        {
            _context = context;
        }

        public ITaskRepository TaskRepository => 
         _taskRepository ??= new TaskRepository(_context);

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
