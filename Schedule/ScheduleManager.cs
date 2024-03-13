using Quartz.Impl;
using Quartz;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopaCmd.Schedule
{
    public class ScheduleManager
    {
        public static async Task<IScheduler> BuildScheduler()
        {
            var schedulerFactory = new StdSchedulerFactory();
            IScheduler _scheduler = await schedulerFactory.GetScheduler();
            Schedule.Scheduler.SetScheduler(_scheduler);
            return Schedule.Scheduler.GetIntance();
        }
    }
}