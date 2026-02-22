using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentForge.Application.DTOs.Tasks;

namespace TalentForge.Application.DTOs.Jobs.Validators
{
    public class IJobDtoValidator : AbstractValidator<IJobDto>
    {
        public IJobDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(x => x.Department)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();

            RuleFor(x => x.Location)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();

            RuleFor(x => x.ExperienceLevel)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();

            RuleFor(x => x.EmploymentType)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();

            RuleFor(x => x.Skills)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();

            RuleFor(x => x.PaymentAmount)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();

            RuleFor(x => x.Status)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();

            RuleFor(x => x.Type)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();
        }
    }
}
