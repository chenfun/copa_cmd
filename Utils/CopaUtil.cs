using CopaCmd.ViewModel.Config;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopaCmd.Utils
{
    public class CopaUtil
    {
        /// <summary>
        /// 取得派工明細的結束時間
        /// </summary>
        /// <param name="startDate">開始時間</param>
        /// <returns></returns>
        public static DateTime? GetWorkDetailEndDate(DateTime? startDate)
        {
            DateTime? ret = null;
            if (!startDate.HasValue) return ret;
            DateTime d = startDate.Value;
            int h = d.Hour;

            if (0 <= h && h < 7)
            {
                ret = DateTime.Parse($"{d.ToString("yyyy-MM-dd")} 08:00:00");
            }
            if (7 <= h && h < 17)
            {
                ret = DateTime.Parse($"{d.ToString("yyyy-MM-dd")} 17:00:00");
            }
            if (17 <= h && h <= 23)
            {
                ret = DateTime.Parse($"{d.AddDays(1).ToString("yyyy-MM-dd")} 08:00:00");
            }
            return ret;
        }

        /// <summary>
        /// 開始服務
        /// </summary>
        /// <param name="info">資訊</param>
        public static async Task StartService(JobInfo info, string paras = "")
        {
            //取得參數
            var settingParas = Helpers.JobHelper.ConvertParas(info.Paras);
            switch (info.Code)
            {
                case "J01":
                    Log.Information($"===========未實作 {info.Code}===========!");
                    break;

                case "J02":
                    var getMeterService = new Services.MeterService();
                    await getMeterService.GetMeterRecordLog(info.FileName);
                    break;

                case "J03":
                    var upMachineService = new Services.MachineService();
                    await upMachineService.UpdateProduceTotalTime(settingParas);
                    break;

                case "J04":
                    var cmMachineService = new Services.MeterService();
                    await cmMachineService.CalcMeterDayReport(info.FileName, paras);
                    break;

                case "J05":
                    var logService = new Services.LogService();
                    await logService.ClearLogRecord(settingParas);
                    break;

                case "J06":
                    var erpService = new Services.ErpTransferService();
                    string startDate = string.IsNullOrWhiteSpace(paras) ? DateTime.Now.ToString("yyyy-MM-dd") : paras.Split('=')[1];
                    await erpService.Start(startDate);
                    break;

                case "J07":
                    var cmerMachineService = new Services.MeterService();
                    await cmerMachineService.CalcMeterElectricReport(info.FileName, paras);
                    break;

                case "J11":
                    var updateCustomersService = new Services.UpdateCustomersService();
                    await updateCustomersService.Start(info);
                    break;

                case "J12":
                    var updateCustomerOrdersService = new Services.UpdateCustomerOrdersService();
                    await updateCustomerOrdersService.Start(info);
                    break;

                default:
                    Console.WriteLine($"無此Code {info.Code} 編碼");
                    break;
            }
        }
    }
}