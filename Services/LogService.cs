using CopaCmd.Adc.Models;
using CopaCmd.Extensions;
using CopaContext;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopaCmd.Services
{
    public class LogService
    {
        //預設清除攻牙機log天數
        private int defaultClearTapLogDay = -30;

        //預設清除電表log天數
        private int defaultClearMeterLogDay = -360;

        public LogService()
        {
        }

        /// <summary>
        /// 清除攻牙LOG與電表LOG
        /// </summary>
        public async Task ClearLogRecord(Dictionary<string, string> paras = null)
        {
            int clearTapLogDay = Helpers.JobHelper.GetPara<int>(paras, "clearTapLogDay", defaultClearTapLogDay);
            int clearMeterLogDay = Helpers.JobHelper.GetPara<int>(paras, "clearMeterLogDay", defaultClearMeterLogDay);

            DateTime clearTapLog = DateTime.Now.AddDays(clearTapLogDay);
            DateTime clearMeterLog = DateTime.Now.AddDays(clearMeterLogDay);

            var dbAdc = new CopaAdcContext();

            //清除攻牙LOG
            var tapLogs = dbAdc.VigorplclogTaps.Where(w => w.CreateTime < clearTapLog).ToList();
            dbAdc.RemoveRange(tapLogs);
            Log.Information("清除攻牙LOG記錄時間小於 {0} ，共 {1} 筆記錄 ", clearTapLog.ToDateString(), tapLogs.Count());

            //清除電表LOG
            var meterLogs = dbAdc.MeterRecordLogs.Where(w => w.CreateTime < clearMeterLog).ToList();
            dbAdc.RemoveRange(meterLogs);
            Log.Information("清除電表LOG記錄時間小於 {0} ，共 {1} 筆記錄", clearMeterLog.ToDateString(), meterLogs.Count());

            await dbAdc.SaveChangesAsync();
        }
    }
}