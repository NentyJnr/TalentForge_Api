using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TalentForge.Application.DTOs.JobApplications;
using TalentForge.Application.DTOs.Jobs;
using TalentForge.Application.Responses;
using static TalentForge.Application.Features.Applications.GetApplicationList;
using static TalentForge.Application.Features.Jobs.CreateJob;
using static TalentForge.Application.Features.Jobs.DeleteJob;
using static TalentForge.Application.Features.Jobs.GetJob;
using static TalentForge.Application.Features.Jobs.GetJobList;
using static TalentForge.Application.Features.Jobs.UpdateJob;
using static TalentForge.Application.Features.Tasks.CreateApplication;
using static TalentForge.Application.Features.Tasks.DeleteApplication;
using static TalentForge.Application.Features.Tasks.GetApplication;

namespace TalentForge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : BaseController
    {
        private readonly IMediator _mediator;

        public ApplicationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ApplicationModel>>> Get([FromQuery] ApplicationDto request)
        {
            GetApplicationListQuery query = new GetApplicationListQuery { UserId = GetCurrentUserId(), ApplicationDto = request };
            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationModel>> Get(Guid id)
        {
            GetApplicationQuery query = new GetApplicationQuery { Id = id };
            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServerResponse<bool>>> Create([FromBody] CreateApplicationDto createApplicationDto)
        {
            CreateApplicationCommand command = new CreateApplicationCommand
            {
                UserId = GetCurrentUserId(),
                CreateApplicationDto = createApplicationDto
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServerResponse<bool>>> Delete(Guid id)
        {
            DeleteApplicationCommand command = new DeleteApplicationCommand
            {
                UserId = GetCurrentUserId(),
                Id = id
            };
            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
