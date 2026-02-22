using FluentValidation;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentForge.Application.Contracts.Persistence;
using TalentForge.Application.DTOs.Jobs;
using TalentForge.Application.DTOs.Jobs.Validators;
using TalentForge.Application.DTOs.Tasks;
using TalentForge.Application.DTOs.Tasks.Validators;
using TalentForge.Application.Responses;
using TalentForge.Domain;

namespace TalentForge.Application.Features.Jobs
{
    public class UpdateJob
    {
        public class UpdateJobCommand : IRequest<ServerResponse<bool>>
        {
            public string UserId { get; set; } = string.Empty;
            public UpdateJobDto UpdateJobDto { get; set; } = null!;
        }

        public class UpdateJobCommandHandler : ResponseBaseService, IRequestHandler<UpdateJobCommand, ServerResponse<bool>>
        {
            private readonly IUnitOfWork _unitOfWork;
            public UpdateJobCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<ServerResponse<bool>> Handle(UpdateJobCommand request, CancellationToken cancellationToken)
            {
                var response = new ServerResponse<bool>();

                IJobDtoValidator validator = new();
                var validationResult = await validator.ValidateAsync(request.UpdateJobDto, cancellationToken);

                if (validationResult.IsValid == false)
                { return SetError(response, responseDescs.FAIL); }

                Job job = await _unitOfWork.JobRepository.GetAsync(request.UpdateJobDto.Id);
                if (job == null)
                { return SetError(response, responseDescs.NULL_REFERENCE); }

                request.Adapt(job);
                job.ModifiedBy = request.UserId;
                job.ModifiedDate = DateTime.UtcNow;

                await _unitOfWork.JobRepository.UpdateAsync(job);
                await _unitOfWork.Save();

                return SetSuccess(response, true, responseDescs.SUCCESS);
            }
        }
    }
}
