using FluentValidation.Results;
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
    public class CreateJob
    {
        public class CreateJobCommand : IRequest<ServerResponse<bool>>
        {
            public string UserId { get; set; } = string.Empty;
            public CreateJobDto CreateJobDto { get; set; } = null!;
        }

        public class CreateJobCommandHandler : ResponseBaseService, IRequestHandler<CreateJobCommand, ServerResponse<bool>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public CreateJobCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<ServerResponse<bool>> Handle(CreateJobCommand command, CancellationToken cancellationToken)
            {
                var response = new ServerResponse<bool>();

                IJobDtoValidator validator = new();
                ValidationResult validationResult = await validator.ValidateAsync(command.CreateJobDto);
                if (!validationResult.IsValid)
                {
                    return SetError(response, responseDescs.FAIL);
                }

                Job newJob = command.CreateJobDto.Adapt<Job>();

                newJob.CreatedBy = command.UserId;
                newJob.CreatedDate = DateTime.UtcNow;
                newJob.IsActive = true;
                newJob.IsDeleted = false;

                await _unitOfWork.JobRepository.AddAsync(newJob);
                await _unitOfWork.Save();

                return SetSuccess(response, true, responseDescs.SUCCESS);
            }
        }
    }
}
