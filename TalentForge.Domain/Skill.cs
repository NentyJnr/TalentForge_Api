using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentForge.Domain.Common;

namespace TalentForge.Domain
{
    public class Skill : BaseObject
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // Navigation Property: Many-to-Many relationship back to candidates
        public virtual ICollection<Candidate> Candidates { get; set; } = new List<Candidate>();
    }
}
