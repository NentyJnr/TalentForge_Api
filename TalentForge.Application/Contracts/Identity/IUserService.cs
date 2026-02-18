using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentForge.Application.DTOs;
using TalentForge.Application.DTOs.Identity;
using TalentForge.Application.Models.Enums;
using TalentForge.Application.Models.Identity;

namespace TalentForge.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<List<UserDto>> GetUsers();
        Task<UserDto> UpdateUserAsync(UpdateUserDto updateRequest, string userId);
        Task<bool> UploadImage(IFormFile file, string userId, UploadType type);
        Task<IList<string>> GetUserRoles(string id);
        Task<UserDto> GetUserByEmail(string email);
        Task<IdentityResult> ChangePasswordAsync(string userId, string currentPassword, string newPassword);
        Task<IdentityResult> ActivateUserAsync(string userId);
        Task<IdentityResult> DeactivateUserAsync(string userId);
        Task<IdentityResult> DeleteUserAsync(string userId);
        Task<IdentityResult> ConfirmEmailAsync(string userId, string token);
        Task<string> GeneratePasswordResetTokenAsync(string email);
        Task<IdentityResult> ResetPasswordAsync(string email, string token, string newPassword);

    }
}
