using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentForge.Application.Contracts.Persistence;
using TalentForge.Application.DTOs.Jobs;
using TalentForge.Application.DTOs.Tasks;
using TalentForge.Application.Responses;
using TalentForge.Domain;

namespace TalentForge.Application.Features.Jobs
{
    public class GetJob
    {
        public class GetJobQuery : IRequest<ServerResponse<JobModel>>
        {
            public Guid Id { get; set; }
        }

        public class GetJobQueryHandler : ResponseBaseService, IRequestHandler<GetJobQuery, ServerResponse<JobModel>>
        {
            private readonly IJobRepository _jobRepository;
            public GetJobQueryHandler(IJobRepository jobRepository)
            {
                _jobRepository = jobRepository;
            }

            public async Task<ServerResponse<JobModel>> Handle(GetJobQuery request, CancellationToken cancellationToken)
            {
                var response = new ServerResponse<JobModel>();
                Job task = await _jobRepository
                    .GetAsync(request.Id)
                    .ConfigureAwait(false);

                if (task == null)
                {
                    return SetError(response, responseDescs.NULL_REFERENCE);
                }

                var data = task.Adapt<JobModel>();
                data.ExperienceLevel = task.ExperienceLevel.ToString();
                data.EmploymentType = task.EmploymentType.ToString();
                data.Status = task.Status.ToString();
                data.Type = task.Type.ToString();

                return SetSuccess(response, data, responseDescs.SUCCESS);
            }
        }
    }
}
