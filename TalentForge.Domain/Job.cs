using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentForge.Domain.Common;
using TalentForge.Domain.Enums;

namespace TalentForge.Domain
{
    public class Job : BaseObject
    {
        public string Title { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public EmploymentType EmploymentType { get; set; }
        public JobStatus Status { get; set; }
        public string Skills { get; set; } = string.Empty;
        public ExperienceLevel ExperienceLevel { get; set; }
        public JobType Type { get; set; }
        public double PaymentAmount { get; set; }
    }
}
