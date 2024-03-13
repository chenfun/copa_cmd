using Quartz.Impl;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopaCmd.Schedule
{
    public class Scheduler
    {
        private static IScheduler _instance;

        private Scheduler()
        {
        }

        public static IScheduler GetIntance()
        {
            if (_instance == null)
            {
                ISchedulerFactory schedFact = new StdSchedulerFactory();
                _instance = schedFact.GetScheduler().Result;
            }
            return _instance;
        }

        public static void SetScheduler(IScheduler scheduler)
        {
            _instance = scheduler;
        }
    }
}