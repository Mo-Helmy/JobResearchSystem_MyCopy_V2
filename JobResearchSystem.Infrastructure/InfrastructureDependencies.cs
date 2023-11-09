using JobResearchSystem.Infrastructure.Repositories;
using JobResearchSystem.Infrastructure.Repositories.Contract;
using JobResearchSystem.Infrastructure.UnitOfWorks;
using JobResearchSystem.Infrastructure.UnitOfWorks.Contract;
using Microsoft.Extensions.DependencyInjection;


namespace JobResearchSystem.Infrastructure
{
    public static class InfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
