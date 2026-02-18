using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentForge.Application.Models.Enums;
using TalentForge.Domain.Common;

namespace TalentForge.Domain
{
    public class Job : BaseObject
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public string Skills { get; set; }
        //public ExperienceLevel ExperienceLevel { get; set; }
        public string Location { get; set; }
        //public JobType Type { get; set; }
        public double PaymentAmount { get; set; }
        public double PaymentDuration { get; set; }
    }

    public class JobPosting
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public EmploymentType EmploymentType { get; set; }
        public decimal MinimumSalary { get; set; }
        public decimal MaximumSalary { get; set; }
        public JobStatus Status { get; set; }
        public DateTime DatePosted { get; set; }

        // Navigation Property: A job can have many applications
        public virtual ICollection<Application> Applications { get; set; } = new List<Application>();
    }
}
