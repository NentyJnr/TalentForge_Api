using TalentForge.Application.DTOs.Common;
using TalentForge.Application.DTOs.Tasks;

namespace TalentForge.Application.DTOs.Tasks
{
    public class CreateTaskDto : BaseDto, ITaskDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
