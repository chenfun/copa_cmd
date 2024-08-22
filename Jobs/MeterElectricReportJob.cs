using CopaCmd.ViewModel.Config;
using Quartz;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CopaCmd.Adc.Models;
using CopaCmd.Models;
using CopaContext;
using Microsoft.EntityFrameworkCore;
using MeterRecordLog = CopaCmd.Adc.Models.MeterRecordLog;

namespace CopaCmd.Jobs
{
    /// <summary>
    /// 生產秏電計算
    /// </summary>
    [DisallowConcurrentExecution]
    public class MeterElectricReportJob : IJob
    {
        private JobInfo info;
        private Dictionary<string, string> paras;

        public async Task Execute(IJobExecutionContext context)
        {
            Log.Information("=====START_生產秏電計算記錄=====");
            try
            {
                //取出JobInfo
                JobDataMap data = context.JobDetail.JobDataMap;
                info = (JobInfo)data["info"];
                if (info != null)
                {
                    paras = Helpers.JobHelper.ConvertParas(info.Paras);
                    // await Helpers.ProcessHelper.StartProcessAsync(info.FileName);
                    UpdateMeterElectricReport(new copapmsContext(), new CopaAdcContext());
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "生產秏電計算記錄==>發生錯誤!!");
            }

            Log.Information("=====END_生產秏電計算記錄=====");
        }

        private async void UpdateMeterElectricReport(copapmsContext db, CopaAdcContext adcDb)
        {
            var workcommands = db.Workcommands.Where(wc =>
                wc.Status == 1 && wc.Enddate >= DateTime.Now.AddDays(-1));

            foreach (var workcommand in workcommands)
            {
                string machineName = db.MachineTables.First(m => m.MachineId == workcommand.MachineId.Value + "")
                    .MachineName;
                var workcommandDetails =
                    db.WorkcommandDetails.Where(wcd => wcd.WorkcommandId == workcommand.WorkcommandId);

                int totalProductionSec = 0;
                double totalCumulativePower = 0;
                string meterName = "";

                foreach (var workcommandDetail in workcommandDetails)
                {
                    DateTime startTime = workcommandDetail.Startdate.Value;
                    DateTime endTime = workcommandDetail.Enddate.Value;
                    Console.WriteLine(startTime);
                    var meterRecordLogs = adcDb.MeterRecordLogs
                        .Where(meter =>
                            meter.CreateTime >= startTime &&
                            meter.CreateTime <= endTime &&
                            meter.MachineList == machineName);

                    if (meterRecordLogs.ToList().Count() == 0)
                    {
                        continue;
                    }

                    totalProductionSec += (int)endTime.Subtract(startTime).TotalSeconds;

                    string maxCumulativePowerString = meterRecordLogs.Max(e => e.CumulativePower);
                    string minCumulativePowerString = meterRecordLogs.Min(e => e.CumulativePower);
                    totalCumulativePower +=
                        (Double.Parse(maxCumulativePowerString) - Double.Parse(minCumulativePowerString));
                    meterName = meterRecordLogs.First().MeterNo;
                }

                var workOrderPowerinfo =
                    db.CopaWorkOrderPowerinfos.FirstOrDefault(power => power.WorkNo == workcommand.WorkNo);
                if (workOrderPowerinfo == null)
                {
                    workOrderPowerinfo = new CopaWorkOrderPowerinfo();
                    db.CopaWorkOrderPowerinfos.Add(workOrderPowerinfo);
                }

                workOrderPowerinfo.MachineName = machineName;
                workOrderPowerinfo.MeterName = meterName;
                workOrderPowerinfo.WorkNo = workcommand.WorkNo;
                workOrderPowerinfo.ProductName =
                    db.ProductTables.First(p => p.Id == int.Parse(workcommand.ProductId)).ProductName;
                workOrderPowerinfo.StartTime = workcommand.Startdate;
                workOrderPowerinfo.EndTime = workcommand.Enddate;
                workOrderPowerinfo.TotalProductionSecs = totalProductionSec;
                workOrderPowerinfo.TotalCnt = workcommand.Ok.Value;
                workOrderPowerinfo.DetailTotalCnt = workcommand.Ok.Value;
                workOrderPowerinfo.TotalPowerConsumption = totalCumulativePower + "";
                workOrderPowerinfo.Note = "排程寫入";
                workOrderPowerinfo.CreateTime = DateTime.Now;
            }

            await db.SaveChangesAsync();
        }
    }
}