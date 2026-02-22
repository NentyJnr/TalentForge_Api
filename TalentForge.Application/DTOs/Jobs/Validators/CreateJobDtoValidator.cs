using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentForge.Application.DTOs.Tasks;
using TalentForge.Application.DTOs.Tasks.Validators;

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
