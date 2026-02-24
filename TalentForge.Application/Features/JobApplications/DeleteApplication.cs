using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentForge.Application.Contracts.Persistence;
using TalentForge.Application.Exceptions;
using TalentForge.Application.Responses;
using TalentForge.Domain;
using static TalentForge.Application.Features.Tasks.CreateApplication;

namespace TalentForge.Application.Features.Tasks
{
    public class DeleteApplication
    {
        public class DeleteApplicationCommand : IRequest<ServerResponse<bool>>
        {
            public string UserId { get; set; } = string.Empty;
            public Guid Id { get; set; }
        }

        public class DeleteApplicationCommandHandler : ResponseBaseService, IRequestHandler<DeleteApplicationCommand, ServerResponse<bool>>
        {
            private readonly IUnitOfWork _unitOfWork;
            public DeleteApplicationCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<ServerResponse<bool>> Handle(DeleteApplicationCommand request, CancellationToken cancellationToken)
            {
                var response = new ServerResponse<bool>();

                JobApplication application = await _unitOfWork.ApplicationRepository.GetAsync(request.Id);
                if (application == null)
                {
                    return SetError(response, responseDescs.NULL_REFERENCE);
                };

                application.IsDeleted = true;
                application.IsActive = false;
                application.DeletedBy = request.UserId;
                application.DeletedDate = DateTime.Now;

                await _unitOfWork.ApplicationRepository.UpdateAsync(application);

                return SetSuccess(response, true, responseDescs.SUCCESS);
            }
        }
    }
}
