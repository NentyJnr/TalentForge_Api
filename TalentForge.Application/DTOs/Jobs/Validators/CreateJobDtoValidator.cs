using FluentValidation;

namespace TalentForge.Application.DTOs.Jobs.Validators
{
    public class CreateJobDtoValidator : AbstractValidator<CreateJobDto>
    {
        public CreateJobDtoValidator()
        {
            Include(new IJobDtoValidator());
        }
    }
}
