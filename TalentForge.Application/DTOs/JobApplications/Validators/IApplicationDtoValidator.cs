using FluentValidation;

namespace TalentForge.Application.DTOs.JobApplications.Validators
{
    public class IApplicationDtoValidator : AbstractValidator<IApplicationDto>
    {
        public IApplicationDtoValidator()
        {
            RuleFor(x => x.JobId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(x => x.Email)
                  .NotEmpty().WithMessage("{PropertyName} is required.")
                  .NotNull();

            RuleFor(x => x.PhoneNumber)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();

            RuleFor(x => x.Location)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();

            RuleFor(x => x.CV)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();

            RuleFor(x => x.YearsOfExperience)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();
        }
    }
}
