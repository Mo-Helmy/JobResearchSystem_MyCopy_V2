using FluentValidation;
using JobResearchSystem.Application.Behaviors;
using JobResearchSystem.Application.Services;
using JobResearchSystem.Application.Services.Contract;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace JobResearchSystem.Application
{
    public static class ApplicationDependencies
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {

            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));

            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<IExperienceService, ExperienceService>();
            services.AddScoped<IQualificationService, QualificationService>();
            services.AddScoped<IJobSeekerService, JobSeekerService>();

            //services.AddTransient<IAuthService, AuthService>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            services.AddAutoMapper(Assembly.GetExecutingAssembly());


            // Add Validators
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            // 
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
