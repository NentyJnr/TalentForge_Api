using MediatR;
using Microsoft.AspNetCore.Http;
using TalentForge.Application.Contracts.Infrastructure;
using TalentForge.Application.Contracts.Persistence;
using TalentForge.Application.DTOs.JobApplications.Validators;
using TalentForge.Application.DTOs.JobApplications;
using TalentForge.Application.Models;
using TalentForge.Application.Responses;
using FluentValidation.Results;
using Mapster;
using TalentForge.Domain;
using TalentForge.Application.Contracts.Misc;
using TalentForge.Domain.Enums;

namespace TalentForge.Application.Features.Tasks
{
    public class CreateApplication
    {
        public class CreateApplicationCommand : IRequest<ServerResponse<bool>>
        {
            public string UserId { get; set; } = string.Empty;
            public CreateApplicationDto CreateApplicationDto { get; set; } = null!;
        }

        public class CreateApplicationCommandHandler : ResponseBaseService, IRequestHandler<CreateApplicationCommand, ServerResponse<bool>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IFileStorageService _fileService;

            public CreateApplicationCommandHandler(IUnitOfWork unitOfWork, IFileStorageService fileService)
            {
                _unitOfWork = unitOfWork;
                _fileService = fileService;
            }

            public async Task<ServerResponse<bool>> Handle(CreateApplicationCommand command, CancellationToken cancellationToken)
            {
                var response = new ServerResponse<bool>();

                IApplicationDtoValidator validator = new();
                ValidationResult validationResult = await validator.ValidateAsync(command.CreateApplicationDto);
                if (!validationResult.IsValid)
                {
                    return SetError(response, responseDescs.FAIL);
                }

                JobApplication newApplication = command.CreateApplicationDto.Adapt<JobApplication>();

                newApplication.CVpath = await _fileService.SaveDocumentAsync(command.CreateApplicationDto.CV);

                newApplication.CreatedBy = command.UserId;
                newApplication.CreatedDate = DateTime.UtcNow;
                newApplication.IsActive = true;
                newApplication.IsDeleted = false;
                newApplication.Status = ApplicationStatus.Applied;

                await _unitOfWork.ApplicationRepository.AddAsync(newApplication);
                await _unitOfWork.Save();

                return SetSuccess(response, true, responseDescs.SUCCESS);
            }
        }
    }
}
