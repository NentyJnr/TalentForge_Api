using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentForge.Application.Contracts.Persistence;
using TalentForge.Application.Responses;
using TalentForge.Domain;

namespace TalentForge.Application.Features.Jobs
{
    public class DeleteJob
    {
        public class DeleteJobCommand : IRequest<ServerResponse<bool>>
        {
            public string UserId { get; set; } = string.Empty;
            public Guid Id { get; set; }
        }

        public class DeleteJobCommandHandler : ResponseBaseService, IRequestHandler<DeleteJobCommand, ServerResponse<bool>>
        {
            private readonly IUnitOfWork _unitOfWork;
            public DeleteJobCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<ServerResponse<bool>> Handle(DeleteJobCommand request, CancellationToken cancellationToken)
            {
                var response = new ServerResponse<bool>();

                Job job = await _unitOfWork.JobRepository.GetAsync(request.Id);
                if (job == null)
                {
                    return SetError(response, responseDescs.NULL_REFERENCE);
                }
                ;

                job.IsDeleted = true;
                job.IsActive = false;
                job.DeletedBy = request.UserId;
                job.DeletedDate = DateTime.Now;

                await _unitOfWork.JobRepository.UpdateAsync(job);

                return SetSuccess(response, true, responseDescs.SUCCESS);
            }
        }
    }
}
