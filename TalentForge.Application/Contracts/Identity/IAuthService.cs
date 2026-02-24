using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentForge.Application.DTOs.Identity;
using TalentForge.Application.Models.Identity;
using TalentForge.Application.Responses;

namespace TalentForge.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest authRequest);
        Task<RegistrationResponse> Register(RegistrationRequest registrationRequest);
        Task<RegistrationResponse> RegisterAdmin(AdminRegistrationRequest registrationRequest);
        Task<bool> VerifyEmailAsync(string email, string token);
        Task<bool> ForgotPasswordAsync(string email);
        Task<bool> SetPasswordAsync(SetPasswordDto request);
        Task<bool> ResetPasswordAsync(string email, string token, string newPassword);
    }
}
