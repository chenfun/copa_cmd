using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopaCmd.Services
{
    public class ErpTransferService
    {
        public ErpTransferService()
        {
        }

        public async Task Start(string fileName)
        {
            Log.Information("=====從ERP取得製令、派工單資訊=====");
            await Helpers.ProcessHelper.StartProcessAsync(fileName);
        }
    }
}