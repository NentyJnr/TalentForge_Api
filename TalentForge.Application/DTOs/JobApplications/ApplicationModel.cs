
using TalentForge.Application.DTOs.Common;
using TalentForge.Application.DTOs.JobApplications;
using TalentForge.Domain;
using TalentForge.Domain.Enums;

namespace TalentForge.Application.DTOs.JobApplications
{
    public class ApplicationDto
    {
        public string? Status { get; set; } = string.Empty;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class ApplicationModel : BaseModel
    {
        public Guid JobId { get; set; }
        public decimal MatchScore { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public int YearsOfExperience { get; set; }
        public string CVpath { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
