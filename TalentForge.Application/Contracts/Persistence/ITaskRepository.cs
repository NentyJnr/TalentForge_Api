
using TalentForge.Application.Contracts.Persistence;
using Task = TalentForge.Domain.Task;

namespace TalentForge.Application.Contracts.Persistence
{
    public interface ITaskRepository : IGenericRepository<Task>
    {
    }
}
