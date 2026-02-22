using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TalentForge.Application.DTOs.Jobs;
using TalentForge.Application.DTOs.Tasks;
using TalentForge.Application.Responses;
using static TalentForge.Application.Features.Jobs.CreateJob;
using static TalentForge.Application.Features.Jobs.DeleteJob;
using static TalentForge.Application.Features.Jobs.GetJob;
using static TalentForge.Application.Features.Jobs.GetJobList;
using static TalentForge.Application.Features.Jobs.UpdateJob;

namespace TalentForge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : BaseController
    {
        private readonly IMediator _mediator;

        public JobController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<JobListItemModel>> Get([FromQuery] JobDto request)
        {
            GetJobListQuery query = new GetJobListQuery { UserId = GetCurrentUserId(), JobDto = request };
            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JobModel>> Get(Guid id)
        {
            GetJobQuery query = new GetJobQuery { Id = id };
            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServerResponse<bool>>> Create([FromBody] CreateJobDto createJobDto)
        {
            CreateJobCommand command = new CreateJobCommand
            {
                UserId = GetCurrentUserId(),
                CreateJobDto = createJobDto
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServerResponse<bool>>> Update([FromBody] UpdateJobDto updateJobDto)
        {
            UpdateJobCommand command = new UpdateJobCommand
            {
                UserId = GetCurrentUserId(),
                UpdateJobDto = updateJobDto
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServerResponse<bool>>> Delete(Guid id)
        {
            DeleteJobCommand command = new DeleteJobCommand
            {
                UserId = GetCurrentUserId(),
                Id = id
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
