using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CopaContext
{
    public partial class copapmsContext : DbContext
    {
        //private IConfiguration configuration;

        public copapmsContext()
        {
            //configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(CopaCmd.Helpers.ConfigHelper.BuildConfiguration().GetConnectionString("MyDB"),
                    ServerVersion.Parse("5.7.10-mysql"),
                    mySqlOptions => mySqlOptions.EnableRetryOnFailure());
            }
        }
    }
}