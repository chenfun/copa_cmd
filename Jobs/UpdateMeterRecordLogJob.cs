using Quartz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using CopaCmd.ViewModel.Config;

namespace CopaCmd.Jobs
{
    /// <summary>
    /// 取得智慧電表設備資料
    /// </summary>
    [DisallowConcurrentExecution]
    public class UpdateMeterRecordLogJob : IJob
    {
        private JobInfo info;
        private Dictionary<string, string> paras;

        public async Task Execute(IJobExecutionContext context)
        {
            Log.Information("=====START_取得智慧電表設備資料=====");
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
                Log.Error(ex, "取得智慧電表設備資料==>發生錯誤!!");
            }
            Log.Information("=====END_取得智慧電表設備資料=====");
        }
    }
}