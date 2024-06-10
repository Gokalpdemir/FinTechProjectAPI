using FinTechProjectAPI.Application.Security.JWT;
using FinTechProjectAPI.Infrastructure.Security.JWT;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTechProjectAPI.Infrastructure.Extensions;

public static class ServiceRegistration
{
    public static void addInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<ITokenHandler,TokenHandler>();
    }
}
