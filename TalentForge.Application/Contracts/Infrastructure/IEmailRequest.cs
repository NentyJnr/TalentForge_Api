using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentForge.Application.DTOs;
using TalentForge.Application.DTOs.Identity;
using TalentForge.Application.Models;

namespace TalentForge.Application.Contracts.Infrastructure
{
    public interface IEmailRequest
    {
        Task<bool> SendVerificationEmail(UserDto user, string token);
        Task<bool> SendPasswordEmail(UserDto user, string password);
        Task<bool> SendPasswordResetTokenEmail(UserDto user, string token);
    }
}
 