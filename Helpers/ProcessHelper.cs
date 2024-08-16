using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopaCmd.Helpers
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;

    public static class ProcessHelper
    {
        public static async Task StartProcessAsync(string fileName, string paras = "")
        {
            Process process = new Process();
            try
            {
                process.StartInfo.FileName = fileName;
                if (!string.IsNullOrWhiteSpace(paras)) { process.StartInfo.Arguments = paras; }
                process.StartInfo.UseShellExecute = false;
                process.Start();
                await process.WaitForExitAsync();
            }
            finally
            {
                process.Dispose();
            }
        }
    }
}