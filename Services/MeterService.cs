using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopaCmd.Services
{
    public class MeterService
    {
        public MeterService()
        {
        }

        /// <summary>
        /// 計算電表每日用電記錄
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public async Task CalcMeterDayReport(string fileName)
        {
            Log.Information("=====START_產生電表日報記錄=====");
            await Helpers.ProcessHelper.StartProcessAsync(fileName);
        }

        /// <summary>
        /// 計算生產秏電記錄
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public async Task CalcMeterElectricReport(string fileName)
        {
            Log.Information("=====START_生產秏電計算記錄=====");
            await Helpers.ProcessHelper.StartProcessAsync(fileName);
        }

        /// <summary>
        /// 取得智慧電表資料
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public async Task GetMeterRecordLog(string fileName)
        {
            Log.Information("=====START_取得智慧電表設備資料=====");
            await Helpers.ProcessHelper.StartProcessAsync(fileName);
        }
    }
}