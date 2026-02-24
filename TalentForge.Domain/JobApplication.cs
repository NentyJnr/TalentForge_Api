using TalentForge.Domain.Common;
using TalentForge.Domain.Enums;

namespace TalentForge.Domain
{
    public class JobApplication : BaseObject
    {
        public Guid JobId { get; set; }
        public decimal MatchScore { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public int YearsOfExperience { get; set; }
        public string CVpath { get; set; } = string.Empty;
        public ApplicationStatus Status { get; set; }
    }
}