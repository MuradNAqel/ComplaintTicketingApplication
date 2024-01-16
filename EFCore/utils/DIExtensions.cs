using Application.AutoMapperConfig;
using Application.Services;
using Domain.Contracts;
using Domain.IServices;
using EFCore.Auth;
using EFCore.DbContext;
using EFCore.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.utils
{
    public static class DIExtensions
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentityApiEndpoints<AppUser>(
                 options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.SignIn.RequireConfirmedEmail = false;
                    options.SignIn.RequireConfirmedAccount = false;

                    // Password settings.
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = 6;
                    options.Password.RequiredUniqueChars = 1;

                    // Lockout settings.
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                    options.Lockout.MaxFailedAccessAttempts = 5;
                    options.Lockout.AllowedForNewUsers = true;

                    // User settings.
                    options.User.AllowedUserNameCharacters =
                        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                    options.User.RequireUniqueEmail = false;
                }
                ).AddRoles<UserRole>()
                .AddEntityFrameworkStores<AppDbContext>();
        }
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IComplaintsService, ComplaintsServices>();
            services.AddTransient<IDemandsService, DemandsServices>();
            services.AddTransient<IManageFileService, ManageFileService>();
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
        }
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IComplaintRepo,ComplaintRepo>();
            services.AddScoped<IDemandRepo,DemandRepo>();
        }
    }
}
