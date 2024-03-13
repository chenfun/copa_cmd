using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CopaCmd.Helpers
{
    public class ConfigHelper
    {
        private static IConfiguration configuration { get; set; }

        public static IConfiguration BuildConfiguration()
        {
            if (configuration == null)
            {
                configuration =  new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            }
            return configuration;
        }

        public static ViewModel.Config.Settings GetSettings
        {
            get
            {
                return BuildConfiguration().GetSection("Settings").Get<ViewModel.Config.Settings>();
            }
        }

        public static ViewModel.Config.Job[] GetJobsSection
        {
            get
            {
                return BuildConfiguration().GetSection("Jobs").Get<ViewModel.Config.Job[]>();
            }
        }

        public static T GetConfig<T>()
        {
            string name = typeof(T).FullName;
            return BuildConfiguration().GetSection(name).Get<T>();
        }
    }
}