using Mapster;
using MediatR;
using TalentForge.Application.Contracts.Persistence;
using TalentForge.Application.DTOs.Jobs;
using TalentForge.Application.Responses;
using TalentForge.Domain.Enums;

namespace TalentForge.Application.Features.Jobs
{
    public class GetJobList
    {
        public class GetJobListQuery : IRequest<ServerResponse<JobListItemModel>>
        {
            public string UserId { get; set; } = string.Empty;
            public JobDto JobDto { get; set; } = new JobDto();
        }

        public class GetJobListQueryHandler : ResponseBaseService, IRequestHandler<GetJobListQuery, ServerResponse<JobListItemModel>>
        {
            private readonly IJobRepository _jobRepository;
            private readonly IApplicationRepository _applicationRepository; // ✅ Added for application counts

            public GetJobListQueryHandler(
                IJobRepository jobRepository,
                IApplicationRepository applicationRepository)
            {
                _jobRepository = jobRepository;
                _applicationRepository = applicationRepository;
            }

            public async Task<ServerResponse<JobListItemModel>> Handle(
                GetJobListQuery request,
                CancellationToken cancellationToken)
            {
                var pageNumber = Math.Max(request.JobDto.PageNumber, 1);
                var pageSize = Math.Min(Math.Max(request.JobDto.PageSize, 1), 100);

                var allJobs = (await _jobRepository.GetAllAsync().ConfigureAwait(false))
                    .Where(j => j.IsDeleted == false)
                    .ToList();

                var filteredJobs = allJobs
                    .Where(j => j.CreatedBy == request.UserId)
                    .AsEnumerable();

                if (!string.IsNullOrWhiteSpace(request.JobDto.Title))
                {
                    var titleFilter = request.JobDto.Title.Trim().ToLower();
                    filteredJobs = filteredJobs.Where(j =>
                        j.Title != null && j.Title.ToLower().Contains(titleFilter));
                }

                if (!string.IsNullOrWhiteSpace(request.JobDto.Department))
                {
                    var deptFilter = request.JobDto.Department.Trim().ToLower();
                    filteredJobs = filteredJobs.Where(j =>
                        j.Department != null && j.Department.ToLower().Contains(deptFilter));
                }

                if (request.JobDto.Status.HasValue)
                {
                    var statusFilter = request.JobDto.Status;
                    filteredJobs = filteredJobs.Where(j =>
                        j.Status == statusFilter);
                }

                if (request.JobDto.Type.HasValue)
                {
                    var typeFilter = request.JobDto.Type;
                    filteredJobs = filteredJobs.Where(j =>
                        j.Type == typeFilter);
                }

                var jobsList = filteredJobs.ToList();

                var totalJobs = jobsList.Count;
                var active = jobsList.Count(j => j.Status == JobStatus.Active);
                var draft = jobsList.Count(j => j.Status == JobStatus.Draft);

                var jobIds = jobsList.Select(j => j.Id).ToList();
                var applicationCounts = jobIds.Any()
                    ? await _applicationRepository.GetApplicationCountsByJobIdsAsync(jobIds, cancellationToken)
                    : new Dictionary<Guid, int>();

                var totalApplicants = applicationCounts.Values.Sum();

                var jobListModels = jobsList
                    .Select(job => {
                        var model = job.Adapt<JobListModel>();

                        model.ApplicantsNo = applicationCounts.TryGetValue(job.Id, out var count) ? count : 0;

                        model.Status = job.Status.ToString();
                        model.Type = job.Type.ToString();

                        return model;
                    })
                    .ToList();

                var pagedItems = jobListModels
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                var responseModel = new JobListItemModel
                {
                    TotalJobs = totalJobs,
                    Active = active,
                    TotalApplicants = totalApplicants,
                    Draft = draft,
                    Items = pagedItems
                };

                var response = new ServerResponse<JobListItemModel>();
                return SetSuccess(response, responseModel, responseDescs.SUCCESS);
            }
        }
    }
}