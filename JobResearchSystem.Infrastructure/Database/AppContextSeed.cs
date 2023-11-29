using JobResearchSystem.Domain.Entities;
using JobResearchSystem.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JobResearchSystem.Infrastructure.Database
{
    public class AppContextSeed
    {
        public static async Task SeedAsync(AppDbContext dbContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!dbContext.UserTypes.Any())
            {
                var stringData = File.ReadAllText("../JobResearchSystem.Infrastructure/Database/DataSeed/UserType.json");
                var data = JsonSerializer.Deserialize<IEnumerable<UserType>>(stringData);

                if (data?.Count() > 0)
                {
                    foreach (var item in data)
                    {
                        await dbContext.UserTypes.AddAsync(item);
                    }
                    await dbContext.SaveChangesAsync();
                }
            }

            if (!roleManager.Roles.Any())
            {
                //await _roleManager.CreateAsync(new IdentityRole("USER"));
                await roleManager.CreateAsync(new IdentityRole("JOBSEEKER"));
                await roleManager.CreateAsync(new IdentityRole("COMPANY"));
                await roleManager.CreateAsync(new IdentityRole("ADMIN"));
                await roleManager.CreateAsync(new IdentityRole("SUPERADMIN"));

                //await dbContext.SaveChangesAsync();
            }

            if (!dbContext.Users.Any())
            {
                var users = new List<ApplicationUser>()
                {
                    new ApplicationUser() {Id = "jobseeker1", Email="jobseeker1@example.com", UserName = "jobseeker1", UserTypeId = 1, DateCreated = DateTime.Now, IsDeleted = false},
                    new ApplicationUser() {Id = "jobseeker2", Email="jobseeker2@example.com", UserName = "jobseeker2", UserTypeId = 1, DateCreated = DateTime.Now, IsDeleted = false},
                    new ApplicationUser() {Id = "jobseeker3", Email="jobseeker3@example.com", UserName = "jobseeker3", UserTypeId = 1, DateCreated = DateTime.Now, IsDeleted = false},
                    new ApplicationUser() {Id = "jobseeker4", Email="jobseeker4@example.com", UserName = "jobseeker4", UserTypeId = 1, DateCreated = DateTime.Now, IsDeleted = false},
                    new ApplicationUser() {Id = "jobseeker5", Email="jobseeker5@example.com", UserName = "jobseeker5", UserTypeId = 1, DateCreated = DateTime.Now, IsDeleted = false},
                    new ApplicationUser() {Id = "jobseeker6", Email="jobseeker6@example.com", UserName = "jobseeker6", UserTypeId = 1, DateCreated = DateTime.Now, IsDeleted = false},
                    new ApplicationUser() {Id = "jobseeker7", Email="jobseeker7@example.com", UserName = "jobseeker7", UserTypeId = 1, DateCreated = DateTime.Now, IsDeleted = false},
                    new ApplicationUser() {Id = "jobseeker8", Email="jobseeker8@example.com", UserName = "jobseeker8", UserTypeId = 1, DateCreated = DateTime.Now, IsDeleted = false},
                    new ApplicationUser() {Id = "jobseeker9", Email="jobseeker9@example.com", UserName = "jobseeker9", UserTypeId = 1, DateCreated = DateTime.Now, IsDeleted = false},
                    new ApplicationUser() {Id = "company1", Email="company1@example.com", UserName = "company1", UserTypeId = 2, DateCreated = DateTime.Now, IsDeleted = false},
                    new ApplicationUser() {Id = "company2", Email="company2@example.com", UserName = "company2", UserTypeId = 2, DateCreated = DateTime.Now, IsDeleted = false},
                    new ApplicationUser() {Id = "company3", Email="company3@example.com", UserName = "company3", UserTypeId = 2, DateCreated = DateTime.Now, IsDeleted = false},
                    new ApplicationUser() {Id = "company4", Email="company4@example.com", UserName = "company4", UserTypeId = 2, DateCreated = DateTime.Now, IsDeleted = false},
                    new ApplicationUser() {Id = "company5", Email="company5@example.com", UserName = "company5", UserTypeId = 2, DateCreated = DateTime.Now, IsDeleted = false},
                    new ApplicationUser() {Id = "company6", Email="company6@example.com", UserName = "company6", UserTypeId = 2, DateCreated = DateTime.Now, IsDeleted = false},
                    new ApplicationUser() {Id = "company7", Email="company7@example.com", UserName = "company7", UserTypeId = 2, DateCreated = DateTime.Now, IsDeleted = false},
                    new ApplicationUser() {Id = "company8", Email="company8@example.com", UserName = "company8", UserTypeId = 2, DateCreated = DateTime.Now, IsDeleted = false},
                    new ApplicationUser() {Id = "company9", Email="company9@example.com", UserName = "company9", UserTypeId = 2, DateCreated = DateTime.Now, IsDeleted = false},
                    new ApplicationUser() {Id = "admin1", Email="admin1@example.com", UserName = "admin1",UserTypeId = 3, DateCreated = DateTime.Now, IsDeleted = false},
                    new ApplicationUser() {Id = "admin2", Email="admin2@example.com", UserName = "admin2", UserTypeId = 3, DateCreated = DateTime.Now, IsDeleted = false},
                    new ApplicationUser() {Id = "admin3", Email="admin3@example.com", UserName = "admin3", UserTypeId = 3, DateCreated = DateTime.Now, IsDeleted = false},
                    new ApplicationUser() {Id = "superadmin1", Email="superadmin1@example.com", UserName = "superadmin1", UserTypeId = 3, DateCreated = DateTime.Now, IsDeleted = false},
                };


                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "string123");

                    if (user.UserTypeId == 1)
                    {
                        await userManager.AddToRoleAsync(user, "JOBSEEKER");
                    }
                    else if (user.UserTypeId == 2)
                    {
                        await userManager.AddToRoleAsync(user, "COMPANY");
                    }
                    else if (user.UserTypeId == 3 && user.Id.Contains("superadmin"))
                    {
                        await userManager.AddToRoleAsync(user, "SUPERADMIN");
                    }
                    else if (user.UserTypeId == 3)
                    {
                        await userManager.AddToRoleAsync(user, "ADMIN");
                    }
                }

            }

            if (!dbContext.JobStatuses.Any())
            {
                var stringData = File.ReadAllText("../JobResearchSystem.Infrastructure/Database/DataSeed/JobStatus.json");
                var data = JsonSerializer.Deserialize<IEnumerable<JobStatus>>(stringData);

                if (data?.Count() > 0)
                {
                    foreach (var item in data)
                    {
                        await dbContext.JobStatuses.AddAsync(item);
                    }
                    await dbContext.SaveChangesAsync();
                }
            }

            if (!dbContext.Categories.Any())
            {
                var stringData = File.ReadAllText("../JobResearchSystem.Infrastructure/Database/DataSeed/Category.json");
                var data = JsonSerializer.Deserialize<IEnumerable<Category>>(stringData);

                if (data?.Count() > 0)
                {
                    foreach (var item in data)
                    {
                        await dbContext.Categories.AddAsync(item);
                    }
                    await dbContext.SaveChangesAsync();
                }
            }

            if (!dbContext.ApplicantStatuses.Any())
            {
                var stringData = File.ReadAllText("../JobResearchSystem.Infrastructure/Database/DataSeed/ApplicantStatus.json");
                var data = JsonSerializer.Deserialize<IEnumerable<ApplicantStatus>>(stringData);

                if (data?.Count() > 0)
                {
                    foreach (var item in data)
                    {
                        await dbContext.ApplicantStatuses.AddAsync(item);
                    }
                    await dbContext.SaveChangesAsync();
                }
            }

            if (!dbContext.Skills.Any())
            {
                var stringData = File.ReadAllText("../JobResearchSystem.Infrastructure/Database/DataSeed/Skill.json");
                var data = JsonSerializer.Deserialize<IEnumerable<Skill>>(stringData);

                if (data?.Count() > 0)
                {
                    foreach (var item in data)
                    {
                        await dbContext.Skills.AddAsync(item);
                    }
                    await dbContext.SaveChangesAsync();
                }
            }

            if (!dbContext.JobSeekers.Any())
            {
                var stringData = File.ReadAllText("../JobResearchSystem.Infrastructure/Database/DataSeed/JobSeeker.json");
                var data = JsonSerializer.Deserialize<IEnumerable<JobSeeker>>(stringData);

                if (data?.Count() > 0)
                {
                    foreach (var item in data)
                    {
                        await dbContext.JobSeekers.AddAsync(item);
                    }
                    await dbContext.SaveChangesAsync();
                }
            }

            if (!dbContext.Qualifications.Any())
            {
                var stringData = File.ReadAllText("../JobResearchSystem.Infrastructure/Database/DataSeed/Qualification.json");
                var data = JsonSerializer.Deserialize<IEnumerable<Qualification>>(stringData);

                if (data?.Count() > 0)
                {
                    foreach (var item in data)
                    {
                        await dbContext.Qualifications.AddAsync(item);
                    }
                    await dbContext.SaveChangesAsync();
                }
            }

            if (!dbContext.Companies.Any())
            {
                var stringData = File.ReadAllText("../JobResearchSystem.Infrastructure/Database/DataSeed/Company.json");
                var data = JsonSerializer.Deserialize<IEnumerable<Company>>(stringData);

                if (data?.Count() > 0)
                {
                    foreach (var item in data)
                    {
                        await dbContext.Companies.AddAsync(item);
                    }
                    await dbContext.SaveChangesAsync();
                }
            }

            if (!dbContext.Jobs.Any())
            {
                var stringData = File.ReadAllText("../JobResearchSystem.Infrastructure/Database/DataSeed/Job.json");
                var data = JsonSerializer.Deserialize<IEnumerable<Job>>(stringData);

                if (data?.Count() > 0)
                {
                    foreach (var item in data)
                    {
                        await dbContext.Jobs.AddAsync(item);
                    }
                    await dbContext.SaveChangesAsync();
                }
            }

            if (!dbContext.Experiences.Any())
            {
                var stringData = File.ReadAllText("../JobResearchSystem.Infrastructure/Database/DataSeed/Experience.json");
                var data = JsonSerializer.Deserialize<IEnumerable<Experience>>(stringData);

                if (data?.Count() > 0)
                {
                    foreach (var item in data)
                    {
                        await dbContext.Experiences.AddAsync(item);
                    }
                    await dbContext.SaveChangesAsync();
                }
            }

            if (!dbContext.Applicants.Any())
            {
                var stringData = File.ReadAllText("../JobResearchSystem.Infrastructure/Database/DataSeed/Applicant.json");
                var data = JsonSerializer.Deserialize<IEnumerable<Applicant>>(stringData);

                if (data?.Count() > 0)
                {
                    foreach (var item in data)
                    {
                        await dbContext.Applicants.AddAsync(item);
                    }
                    await dbContext.SaveChangesAsync();
                }
            }
        }
    }
}

