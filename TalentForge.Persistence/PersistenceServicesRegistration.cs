using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TalentForge.Application.Contracts.Persistence;
using TalentForge.Persistence.Repositories;

namespace TalentForge.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TalentForgeDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("TalentForgeConnectionString")));


            services.AddTransient<ITaskRepository, TaskRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }
    }
}
