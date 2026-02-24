using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentForge.Application.Contracts.Infrastructure;
using TalentForge.Application.Contracts.Misc;
using TalentForge.Application.Models;

namespace TalentForge.Misc
{
    public static class MiscServicesRegistration
    {
        public static IServiceCollection ConfigureMiscServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IFileStorageService, FileStorageService>();
            services.AddTransient<PasswordGenerator>();

            return services;
        }
    }
}
