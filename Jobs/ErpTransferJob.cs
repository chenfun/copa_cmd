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
    /// 從erp取得製令、派工單資訊
    /// </summary>
    [DisallowConcurrentExecution]
    public class ErpTransferJob : IJob
    {
        private JobInfo info;
        private Dictionary<string, string> paras;

        public async Task Execute(IJobExecutionContext context)
        {
            Log.Information("=====START_從ERP取得製令、派工單資訊=====");
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
                Log.Error(ex, "清除LOG記錄==>發生錯誤!!");
            }
            Log.Information("=====END_從ERP取得製令、派工單資訊=====");
        }
    }
}