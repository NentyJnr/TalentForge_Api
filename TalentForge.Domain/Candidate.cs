using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentForge.Domain
{
    public class Candidate
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public int YearsOfExperience { get; set; }

        // Navigation Property: A candidate can make many applications
        public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

        // Navigation Property: Many-to-Many relationship for skills
        public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();
    }
}
