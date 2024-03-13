using CopaCmd.Adc.Models;
using CopaCmd.Extensions;
using CopaCmd.ViewModel.Config;
using CopaContext;
using Quartz;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopaCmd.Jobs
{
    /// <summary>
    /// 清除Log記錄
    /// </summary>
    [DisallowConcurrentExecution]
    public class ClearLogJob : IJob
    {
        private JobInfo info;
        private Dictionary<string, string> paras;

        public async Task Execute(IJobExecutionContext context)
        {
            Log.Information("=====START_清除LOG記錄=====");
            try
            {
                //取出JobInfo
                JobDataMap data = context.JobDetail.JobDataMap;
                info = (JobInfo)data["info"];
                if (info != null) paras = Helpers.JobHelper.ConvertParas(info.Paras);
                var logService = new Services.LogService();
                await logService.ClearLogRecord(paras);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "清除LOG記錄==>發生錯誤!!");
            }
            Log.Information("=====END_清除LOG記錄=====");
        }
    }
}