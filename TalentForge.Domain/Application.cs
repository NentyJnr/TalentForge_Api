using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentForge.Application.Models.Enums;
using static System.Net.Mime.MediaTypeNames;

namespace TalentForge.Domain
{
    public class Application
    {
        public Guid Id { get; set; }

        public Guid JobPostingId { get; set; }
        public Guid CandidateId { get; set; }

        //public ApplicationStatus ApplicationStatus { get; set; }
        public decimal MatchScore { get; set; } // e.g., 92.5 for the AI score
        public DateTime AppliedDate { get; set; }

        public virtual JobPosting JobPosting { get; set; } = null!;
        public virtual Candidate Candidate { get; set; } = null!;
    }
}