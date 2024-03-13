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
        public static async Task StartProcessAsync(string fileName)
        {
            Process process = new Process();
            try
            {
                process.StartInfo.FileName = fileName;
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