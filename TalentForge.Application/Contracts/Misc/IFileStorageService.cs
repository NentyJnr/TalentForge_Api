using Microsoft.AspNetCore.Http;
using TalentForge.Application.Models.Enums;

namespace TalentForge.Application.Contracts.Misc
{
    public interface IFileStorageService
    {
        Task<string> SaveImageAsync(IFormFile imageFile, UploadType uploadType);
        Task<string> SaveDocumentAsync(IFormFile documentFile);
    }
}
