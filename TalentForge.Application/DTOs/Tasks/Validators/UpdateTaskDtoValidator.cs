using FluentValidation;
using TalentForge.Application.DTOs.Tasks;
using TalentForge.Application.DTOs.Tasks.Validators;

namespace TalentForge.Application.DTOs.Tasks.Validators
{
    public class UpdateTaskDtoValidator : AbstractValidator<UpdateTaskDto>
    {
        public UpdateTaskDtoValidator()
        {
            Include(new ITaskDtoValidator());

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} must be present.");
        }
    }
}
