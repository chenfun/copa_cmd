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
    /// 客戶查詢系統_更新客戶訂單資料
    /// </summary>
    [DisallowConcurrentExecution]
    public class UpdateCostWorkOrderJob : IJob
    {
        private JobInfo info;
        private Dictionary<string, string> paras;

        public async Task Execute(IJobExecutionContext context)
        {
            Log.Information("=====START_成本分析更新資料=====");
            try
            {
                //取出JobInfo
                JobDataMap data = context.JobDetail.JobDataMap;
                info = (JobInfo)data["info"];
                if (info  != null)
                {
                    paras = Helpers.JobHelper.ConvertParas(info.Paras);
                    string linq_file = Helpers.JobHelper.GetPara(paras, "file", "");
                    if (!string.IsNullOrWhiteSpace(linq_file))
                        await Helpers.ProcessHelper.StartProcessAsync(info.FileName, linq_file);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "成本分析更新資料==>發生錯誤!!");
            }
            Log.Information("=====END_成本分析更新資料=====");
        }
    }
}