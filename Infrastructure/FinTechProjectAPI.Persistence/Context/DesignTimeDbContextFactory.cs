using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTechProjectAPI.Persistence.Context
{
    internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<FinTechProjectAPIDbContext>
    {
        private readonly IConfiguration _configuration;

        public DesignTimeDbContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public DesignTimeDbContextFactory()
        {
            
        }
        public FinTechProjectAPIDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<FinTechProjectAPIDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer("Server=tcp:fintechproject.database.windows.net,1433;Initial Catalog=FintechProjectDb;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;User ID=fintechprojectroot;Password=6356210tA.;");
            return new FinTechProjectAPIDbContext(dbContextOptionsBuilder.Options, _configuration);

        }
    }
}
