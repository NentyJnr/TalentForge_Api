
using TalentForge.Application.DTOs.Common;
using TalentForge.Application.DTOs.Tasks;
using TalentForge.Domain;

namespace TalentForge.Application.DTOs.Tasks
{
    public class TaskDto
    {
        public string Name { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class TaskModel : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
