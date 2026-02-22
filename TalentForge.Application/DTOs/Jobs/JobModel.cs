using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentForge.Application.DTOs.Common;
using TalentForge.Domain.Enums;

namespace TalentForge.Application.DTOs.Jobs
{
    public class JobModel : BaseModel
    {
        public string Title { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string EmploymentType { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Skills { get; set; } = string.Empty;
        public string ExperienceLevel { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public double PaymentAmount { get; set; }
    }

    public class JobListModel
    {
        public string Title { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public double PaymentAmount { get; set; }
        public int ApplicantsNo { get; set; }
    }

    public class JobListItemModel
    {
        public int TotalJobs { get; set; }
        public int Active { get; set; }
        public int TotalApplicants { get; set; }
        public int Draft { get; set; }
        public List<JobListModel> Items { get; set; } = null!;
    }

    public class JobDto
    {
        public string Title { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public JobType Type { get; set; }
        public JobStatus Status { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
