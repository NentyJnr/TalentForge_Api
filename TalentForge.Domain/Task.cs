using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentForge.Domain.Common;

namespace TalentForge.Domain
{
    public class Task : BaseObject
    {
        public string Name { get; set; } 
        public string Description { get; set; }
    }
}
