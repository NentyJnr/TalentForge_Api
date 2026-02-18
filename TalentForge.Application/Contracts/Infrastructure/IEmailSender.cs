using TalentForge.Application.Models;
using TalentForge.Application.Models.Enums;

namespace TalentForge.Application.Contracts.Infrastructure
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(Email email);
    }
}
