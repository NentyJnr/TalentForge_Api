using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TalentForge.Application.Contracts.Persistence;
using TalentForge.Application.Misc;
using TalentForge.Application.Responses;
using static TalentForge.Application.Features.Tasks.DeleteApplication;

namespace TalentForge.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));


            return services;
        }
    }
}
