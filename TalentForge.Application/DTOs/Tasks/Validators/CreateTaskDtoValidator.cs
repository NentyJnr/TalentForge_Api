using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentForge.Application.DTOs.Tasks.Validators;

namespace TalentForge.Application.DTOs.Tasks.Validators
{
    public class CreateTaskDtoValidator : AbstractValidator<CreateTaskDto>
    {
        public CreateTaskDtoValidator()
        {
            Include(new ITaskDtoValidator());
        }
    }
}
