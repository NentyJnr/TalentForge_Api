using Microsoft.AspNetCore.Http;

namespace TalentForge.Application.DTOs.JobApplications
{
    public interface IApplicationDto
    {
        public Guid JobId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Location { get; set; }
        public int YearsOfExperience { get; set; }
        public IFormFile CV { get; set; }
    }
}
