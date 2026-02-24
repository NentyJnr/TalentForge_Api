using Microsoft.AspNetCore.Http;
using TalentForge.Application.DTOs.Common;
using TalentForge.Application.DTOs.JobApplications;

namespace TalentForge.Application.DTOs.JobApplications
{
    public class CreateApplicationDto : IApplicationDto
    {
        public Guid JobId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public int YearsOfExperience { get; set; }
        public IFormFile CV { get; set; }
    }
}
