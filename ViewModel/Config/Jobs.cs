using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopaCmd.ViewModel.Config
{
    public class Job
    {
        public JobInfo Jobinfo { get; set; }
    }

    public class JobInfo
    {
        public string Code { get; set; }
        public string No { get; set; }
        public string Title { get; set; }
        public string CronSchedule { get; set; }
        public string FileName { get; set; }
        public string Paras { get; set; }
        public bool Enable { get; set; }
        public string Note { get; set; }
    }
}