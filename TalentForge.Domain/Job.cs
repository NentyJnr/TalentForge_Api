using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentForge.Domain.Common;

namespace TalentForge.Domain
{
    public class Job : BaseObject
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public string Skills { get; set; }
        public ExperienceLevel ExperienceLevel { get; set; }
        public string Location { get; set; }
        public JobType Type { get; set; }
        public double PaymentAmount { get; set; }
        public double PaymentDuration { get; set; }
    }
}
