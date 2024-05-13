﻿using FinTechProjectAPI.Application.Abstractions.Services;
using FinTechProjectAPI.Domain.Entities.Identity;
using FinTechProjectAPI.Persistence.Context;
using FinTechProjectAPI.Persistence.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTechProjectAPI.Persistence.Extension
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<FinTechProjectAPIDbContext>(option => option.UseSqlServer(configuration.GetConnectionString("MSSQL")));
            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.Password.RequiredLength = 8;
                opt.User.AllowedUserNameCharacters += "ğĞüÜşŞıİöÖçÇ";
                opt.Password.RequireNonAlphanumeric = true;
                opt.Password.RequireUppercase = true;
                opt.Password.RequireLowercase = true;
                opt.Password.RequireDigit = true;

            }).AddEntityFrameworkStores<FinTechProjectAPIDbContext>()
            .AddDefaultTokenProviders();

            services.AddScoped<IUserService, UserService>();
        }
    }
}
