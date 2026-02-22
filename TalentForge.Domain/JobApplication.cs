using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentForge.Application.Models.Enums;
using TalentForge.Domain.Common;
using static System.Net.Mime.MediaTypeNames;

namespace TalentForge.Domain
{
    public class JobApplication : BaseObject
    {
        public Guid JobId { get; set; }
        public Guid CandidateId { get; set; }
        public decimal MatchScore { get; set; }
    }
}