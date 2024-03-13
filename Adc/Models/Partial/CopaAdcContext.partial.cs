using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopaCmd.Adc.Models
{
    public partial class CopaAdcContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(CopaCmd.Helpers.ConfigHelper.BuildConfiguration().GetConnectionString("AdcDB"),
                    ServerVersion.Parse("5.7.10-mysql"),
                    mySqlOptions => mySqlOptions.EnableRetryOnFailure());
            }
        }
    }
}