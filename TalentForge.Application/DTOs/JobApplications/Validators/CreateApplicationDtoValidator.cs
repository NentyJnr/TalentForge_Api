using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentForge.Application.DTOs.JobApplications.Validators;

namespace TalentForge.Application.DTOs.JobApplications.Validators
{
    public class CreateApplicationDtoValidator : AbstractValidator<CreateApplicationDto>
    {
        public CreateApplicationDtoValidator()
        {
            Include(new IApplicationDtoValidator());
        }
    }
}
