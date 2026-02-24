using FluentValidation;

namespace TalentForge.Application.DTOs.Jobs.Validators
{
    public class UpdateJobDtoValidator : AbstractValidator<UpdateJobDto>
    {
        public UpdateJobDtoValidator()
        {
            Include(new IJobDtoValidator());

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} must be present.");
        }
    }
}
