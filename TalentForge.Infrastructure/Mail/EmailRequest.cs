using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentForge.Application.Contracts.Infrastructure;
using TalentForge.Application.DTOs;
using TalentForge.Application.DTOs.Identity;
using TalentForge.Application.Models;
using TalentForge.Identity.Models;

namespace TalentForge.Infrastructure.Mail
{
    public class EmailRequest : IEmailRequest
    {
        private readonly IEmailSender _emailSender;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EmailRequest(IEmailSender emailSender, IHttpContextAccessor httpContextAccessor)
        {
            _emailSender = emailSender;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> SendPasswordEmail(UserDto user, string password)
        {
            var baseUrl = GetBaseUrl();
            var verificationUrl = $"{baseUrl.TrimEnd('/')}/api/account/set-password-email?email={user.Email}";

            var templatePath = Path.Combine(Directory.GetCurrentDirectory(), "EmailTalentForges", "SetPassword.html");
            var templateContent = await File.ReadAllTextAsync(templatePath);

            var emailBody = templateContent
                .Replace("{{Password}}", password)
                .Replace("{{PasswordUrl}}", verificationUrl)
                .Replace("{{Email}}", user.Email)
                .Replace("{{Initials}}", GetUserInitials(user.FirstName, user.LastName))
                .Replace("{{FirstName}}", user.FirstName)
                .Replace("{{LastName}}", user.LastName ?? "")
                .Replace("{{CurrentYear}}", DateTime.Now.Year.ToString())
                .Replace("{{SignupDate}}", user.DateCreated.ToString("dd MMM, yyyy"))
                .Replace("{{ExpirationHours}}", "24");

            var email = new Email
            {
                To = user.Email,
                Subject = "Set new password",
                Body = emailBody
            };

            var result = await _emailSender.SendEmail(email);
            if (!result) { return false; }
            return true;
        }

        public async Task<bool> SendVerificationEmail(UserDto user, string token)
        {
            var encodedToken = Uri.EscapeDataString(token);
            var baseUrl = GetBaseUrl();
            var verificationUrl = $"{baseUrl.TrimEnd('/')}/api/account/verify-email?email={user.Email}&token={encodedToken}";

            var templatePath = Path.Combine(Directory.GetCurrentDirectory(), "EmailTalentForges", "EmailVerification.html");
            var templateContent = await File.ReadAllTextAsync(templatePath);

            var emailBody = templateContent
                .Replace("{{VerificationUrl}}", verificationUrl)
                .Replace("{{Email}}", user.Email)
                .Replace("{{Initials}}", GetUserInitials(user.FirstName, user.LastName))
                .Replace("{{FirstName}}", user.FirstName)
                .Replace("{{LastName}}", user.LastName ?? "")
                .Replace("{{CurrentYear}}", DateTime.Now.Year.ToString())
                .Replace("{{SignupDate}}", user.DateCreated.ToString("dd MMM, yyyy"))
                .Replace("{{ExpirationHours}}", "24");

            var email = new Email
            {
                To = user.Email,
                Subject = "Verify your TalentForge account",
                Body = emailBody
            };

            var result = await _emailSender.SendEmail(email);
            if (!result) { return false; }
            return true;
        }

        public async Task<bool> SendPasswordResetTokenEmail(UserDto user, string token)
        {
            var encodedToken = Uri.EscapeDataString(token);

            var baseUrl = GetBaseUrl();
            var resetUrl = $"{baseUrl.TrimEnd('/')}/api/account/reset-password?email={user.Email}&token={encodedToken}";

            var templatePath = Path.Combine(Directory.GetCurrentDirectory(), "EmailTalentForges", "PasswordResetEmail.html");
            var templateContent = await File.ReadAllTextAsync(templatePath);

            var emailBody = templateContent
                .Replace("{{ResetUrl}}", resetUrl)
                .Replace("{{FirstName}}", user.FirstName)
                .Replace("{{CurrentYear}}", DateTime.Now.Year.ToString());

            var email = new Email
            {
                To = user.Email,
                Subject = "Reset your TalentForge password",
                Body = emailBody
            };

            var result = await _emailSender.SendEmail(email);
            if (!result) { return false; }
            return true;
        }

        // Helper method for initials
        private string GetUserInitials(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
                return "PL";

            var firstInitial = !string.IsNullOrEmpty(firstName) ? firstName[0].ToString().ToUpper() : "";
            var lastInitial = !string.IsNullOrEmpty(lastName) ? lastName[0].ToString().ToUpper() : "";

            return $"{firstInitial}{lastInitial}";
        }

        private string GetBaseUrl()
        {
            var request = _httpContextAccessor.HttpContext?.Request;
            if (request == null)
            {
                return "https://paylink.com";
            }

            var scheme = request.Scheme;
            var host = request.Host.ToUriComponent();

            return $"{scheme}://{host}";
        }
    }
}
