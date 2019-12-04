using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Persitance;

namespace Startup
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

            var connectionString = configuration.GetConnectionString("Sqlserver");
            var sqliteConnString = configuration.GetConnectionString("Sqlite");
            var mySqlConnString = configuration.GetConnectionString("MySql");
            var postgressConnString = configuration.GetConnectionString("Postgress");;
            //builder.UseSqlServer(connectionString);
            builder.UseSqlite(sqliteConnString);
            //builder.UseNpgsql(postgressConnString);
            //builder.UseMySQL(mySqlConnString);            

            return new ApplicationDbContext(builder.Options);
        }
    }
}