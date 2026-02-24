using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentForge.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IInterviewRepository InterviewRepository { get; }
        IApplicationRepository ApplicationRepository { get; }
        IJobRepository JobRepository { get; }
        Task Save();
    }
}
