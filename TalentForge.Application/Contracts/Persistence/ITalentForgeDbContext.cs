using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentForge.Domain;

namespace TalentForge.Application.Contracts.Persistence
{
    public interface ITalentForgeDbContext
    {
        public DbSet<Domain.Task> Tasks { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
