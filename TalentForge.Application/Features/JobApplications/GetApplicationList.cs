using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TalentForge.Application.Contracts.Persistence;
using TalentForge.Application.DTOs.JobApplications;
using TalentForge.Application.Responses;
using TalentForge.Domain;

namespace TalentForge.Application.Features.Applications
{
    public class GetApplicationList
    {
        public class GetApplicationListQuery : IRequest<ServerResponse<List<ApplicationModel>>>
        {
            public string UserId { get; set; } = string.Empty;
            public ApplicationDto ApplicationDto { get; set; } = new ApplicationDto();
        }

        public class GetApplicationListQueryHandler : ResponseBaseService,
            IRequestHandler<GetApplicationListQuery, ServerResponse<List<ApplicationModel>>>
        {
            private readonly IApplicationRepository _applicationRepository;
            private readonly IJobRepository _jobRepository;

            public GetApplicationListQueryHandler(
                IApplicationRepository applicationRepository,
                IJobRepository jobRepository)
            {
                _applicationRepository = applicationRepository;
                _jobRepository = jobRepository;
            }

            public async Task<ServerResponse<List<ApplicationModel>>> Handle(
                GetApplicationListQuery request,
                CancellationToken cancellationToken)
            {

                var response = new ServerResponse<List<ApplicationModel>>();

                var pageNumber = Math.Max(request.ApplicationDto.PageNumber, 1);
                var pageSize = Math.Min(Math.Max(request.ApplicationDto.PageSize, 1), 100);

                var recruiterJobIds = (await _jobRepository.GetAllAsync().ConfigureAwait(false))
                    .Where(j => j.CreatedBy == request.UserId && !j.IsDeleted)
                    .Select(j => j.Id)
                    .ToList();

                if (!recruiterJobIds.Any())
                {
                    return SetSuccess(response, new List<ApplicationModel>(), responseDescs.SUCCESS);
                }

                var allApplications = (await _applicationRepository.GetAllAsync().ConfigureAwait(false))
                    .Where(a => !a.IsDeleted && recruiterJobIds.Contains(a.JobId))
                    .ToList();

                var filteredApplications = allApplications.AsEnumerable();

                if (!string.IsNullOrWhiteSpace(request.ApplicationDto.Status))
                {
                    var statusFilter = request.ApplicationDto.Status;
                    filteredApplications = filteredApplications.Where(a =>
                        a.Status.ToString() == statusFilter);
                }

                var applicationsList = filteredApplications.ToList();
                var totalCount = applicationsList.Count;

                var recruiterJobs = (await _jobRepository.GetAllAsync().ConfigureAwait(false))
                    .Where(j => recruiterJobIds.Contains(j.Id))
                    .ToList();

                var jobLookup = recruiterJobs.ToDictionary(j => j.Id, j => j);

                var applicationModels = applicationsList
                    .Select(app => {
                        var model = app.Adapt<ApplicationModel>();

                        model.Status = app.Status.ToString();

                        return model;
                    })
                    .ToList();

                var pagedApplications = applicationModels
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                return SetSuccess(response, pagedApplications, responseDescs.SUCCESS);
            }
        }
    }
}