using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.DATA.EF
{
    /// <summary>
    /// Khi Migration thi se tao context
    /// MarvicDbContext la doi tuong context
    /// 
    /// Description:
    /// Some of the EF Core Tools commands (for example, the Migrations commands) 
    /// require a derived DbContext instance to be created at design time in order 
    /// to gather details about the application's entity types and how they map to 
    /// a database schema. In most cases, it is desirable that the DbContext thereby 
    /// created is configured in a similar way to how it would be configured at run time.
    /// </summary>
    public class MarvicDbContextFactory : IDesignTimeDbContextFactory<MarvicDbContext>
    {
        public MarvicDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("MarvicDbConnection");
            var optionsBuilder = new DbContextOptionsBuilder<MarvicDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new MarvicDbContext(optionsBuilder.Options);
        }
    }
}
