using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CopaCmd.Extensions;
using CopaContext;
using System.Data;
using System.Linq;
using CopaCmd.ViewModel.Config;
using Serilog;

namespace CopaCmd.Jobs
{
    /// <summary>
    /// 更新成形機生產總時間(秒)
    /// </summary>
    [DisallowConcurrentExecution]
    public class UpdateProduceTotalTimeJob : IJob
    {
        private JobInfo info;
        private Dictionary<string, string> paras;

        public async Task Execute(IJobExecutionContext context)
        {
            Log.Information("=====START_更新成形機生產總時間=====");
            try
            {
                //取出JobInfo
                JobDataMap data = context.JobDetail.JobDataMap;
                info = (JobInfo)data["info"];
                if (info  != null) paras = Helpers.JobHelper.ConvertParas(info.Paras);
                var machineService = new Services.MachineService();
                await machineService.UpdateProduceTotalTime(paras);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "更新成形機生產總時間==>發生錯誤!!");
            }
            Log.Information("=====END_更新成形機生產總時間=====");
        }
    }
}