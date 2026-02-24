using Mapster;
using MediatR;
using TalentForge.Application.Contracts.Persistence;
using TalentForge.Application.DTOs.JobApplications;
using TalentForge.Application.Responses;
using TalentForge.Domain;

namespace TalentForge.Application.Features.Tasks
{
    public class GetApplication
    {
        public class GetApplicationQuery : IRequest<ServerResponse<ApplicationModel>>
        {
            public Guid Id { get; set; }
        }

        public class GetApplicationQueryHandler : ResponseBaseService, IRequestHandler<GetApplicationQuery, ServerResponse<ApplicationModel>>
        {
            private readonly IApplicationRepository _applicationRepository;
            public GetApplicationQueryHandler(IApplicationRepository applicationRepository)
            {
                _applicationRepository = applicationRepository;
            }

            public async Task<ServerResponse<ApplicationModel>> Handle(GetApplicationQuery request, CancellationToken cancellationToken)
            {
                var response = new ServerResponse<ApplicationModel>();
                JobApplication task = await _applicationRepository
                    .GetAsync(request.Id)
                    .ConfigureAwait(false);

                if (task == null)
                {
                    return SetError(response, responseDescs.NULL_REFERENCE);
                }

                var data = task.Adapt<ApplicationModel>();

                return SetSuccess(response, data, responseDescs.SUCCESS);
            }
        }
    }
}
