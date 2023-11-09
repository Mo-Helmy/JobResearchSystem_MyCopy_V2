using JobResearchSystem.API.Extensions;
using JobResearchSystem.Application;
using JobResearchSystem.Application.Middleware;
using JobResearchSystem.Domain.Entities.Identity;
using JobResearchSystem.Infrastructure;
using JobResearchSystem.Infrastructure.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace JobResearchSystem.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers().AddJsonOptions(opt =>
            {
                // ignore null values when serializing to json
                opt.JsonSerializerOptions.DefaultIgnoreCondition
                               = JsonIgnoreCondition.WhenWritingNull;
            });

            #region Configure Connection
            builder.Services.AddDbContext<AppDbContext>(optionsBuilder =>
                optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
            #endregion

            // Custom Extension
            builder.Services.AddIdentityServices();
            
            // Custom Extension
            builder.Services
                .AddInfrastructureDependencies()
                .AddApplicationDependencies();

            // Custom Extension
            builder.Services.AddSwaggerServices();

            var app = builder.Build();

            // Custom Extension
            await app.UpdateDatabase();

            app.UseStaticFiles();

            // Custom Extension
            app.UseSwaggerMiddlewares();

            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}