using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentForge.Domain.Common;

namespace TalentForge.Domain
{
    public class Interview : BaseObject
    {
        public string Tile { get; set; } = string.Empty;
        public Guid ApplicationId { get; set; }
        public string InterviewerId { get; set; } = string.Empty;
        public string CandidateName { get; set; } = string.Empty;
        public DateTime ScheduledTime { get; set; }
    }
}
