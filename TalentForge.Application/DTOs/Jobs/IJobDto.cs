using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentForge.Domain.Enums;

namespace TalentForge.Application.DTOs.Jobs
{
    public interface IJobDto
    {
        public string Title { get; set; }
        public string Department { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public EmploymentType EmploymentType { get; set; }
        public JobStatus Status { get; set; }
        public string Skills { get; set; }
        public ExperienceLevel ExperienceLevel { get; set; }
        public JobType Type { get; set; }
        public double PaymentAmount { get; set; }
    }
}
