using CopaCmd.ViewModel.Config;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopaCmd.Services
{
    public class UpdateCustomerOrdersService
    {
        public UpdateCustomerOrdersService()
        {
        }

        public async Task Start(JobInfo info)
        {
            var paras = Helpers.JobHelper.ConvertParas(info.Paras);
            string linq_file = Helpers.JobHelper.GetPara(paras, "file", "");
            if (!string.IsNullOrWhiteSpace(linq_file))
                await Helpers.ProcessHelper.StartProcessAsync(info.FileName, linq_file);
        }
    }
}