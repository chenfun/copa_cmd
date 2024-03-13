using CopaCmd.ViewModel.Config;
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
    /// 產生電表日報記錄
    /// </summary>
    [DisallowConcurrentExecution]
    public class MeterDayReportJob : IJob
    {
        private JobInfo info;
        private Dictionary<string, string> paras;

        public async Task Execute(IJobExecutionContext context)
        {
            Log.Information("=====START_產生電表日報記錄=====");
            try
            {
                //取出JobInfo
                JobDataMap data = context.JobDetail.JobDataMap;
                info = (JobInfo)data["info"];
                if (info  != null)
                {
                    paras = Helpers.JobHelper.ConvertParas(info.Paras);
                    await Helpers.ProcessHelper.StartProcessAsync(info.FileName);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "產生電表日報記錄==>發生錯誤!!");
            }
            Log.Information("=====END_產生電表日報記錄=====");
        }
    }
}