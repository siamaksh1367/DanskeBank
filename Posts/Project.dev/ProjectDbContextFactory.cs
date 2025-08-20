using Project.dal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Project.dev
{
    //comment
    public class ProjectDbContextFactory : IDesignTimeDbContextFactory<ProjectDB>
    {
        public ProjectDB CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProjectDB>();
            var configuration = new ConfigurationBuilder()
           .AddEnvironmentVariables()
           .AddUserSecrets("368a681a-fad6-423c-83cd-010c88424176")
           .Build();
            optionsBuilder.UseSqlServer(configuration.GetSection("SQLConnectionString").GetSection("ConnectionString").Value, option => option.MigrationsAssembly("Project.dal"));

            return new ProjectDB(optionsBuilder.Options);
        }
    }
}
