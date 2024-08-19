using CopaCmd.Jobs;
using CopaCmd.ViewModel.Config;
using CopaContext;
using Microsoft.Extensions.Configuration;
using Quartz;
using Quartz.Impl;
using System.Collections.Specialized;
using System.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Humanizer.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using static System.Net.Mime.MediaTypeNames;
using CommandLine;
using Microsoft.Extensions.Options;
using System.Runtime;
using System.Xml.Linq;
using static Quartz.Logging.OperationName;
using CopaCmd.Schedule;

namespace CopaCmd
{
    internal class Program
    {
        //dotnet ef dbcontext scaffold "server=192.168.100.253;Port=3306;Database=copapms;User=sa;Password=htit;Charset=utf8;" Pomelo.EntityFrameworkCore.MySql -o ./Models -c CopaContext -f --no-onconfiguring
        //dotnet ef dbcontext scaffold "server=192.168.100.253;Port=3306;Database=copa_adc;User=sa;Password=htit;Charset=utf8;" Pomelo.EntityFrameworkCore.MySql -o ./Adc/Models -c CopaAdcContext -f --no-onconfiguring
        private static async Task Main(string[] args)
        {
            try
            {
                //連結appsettings檔案
                var configuration = Helpers.ConfigHelper.BuildConfiguration();

                // 設定 Serilog，使用 appsettings.json 中的配置
                Log.Logger = new LoggerConfiguration()
                    .ReadFrom.Configuration(configuration)
                    .CreateLogger();

                var jobs = Helpers.ConfigHelper.GetJobsSection;

                if (args.Length > 0)
                {
                    Log.Information("=====國鵬程式啟動=====!");

                    //有參數
                    Parser.Default.ParseArguments<CommandOptions>(args)
                   .WithParsed(async options =>
                   {
                       string code = options.Code;
                       string paras = options.Paras;

                       if (!string.IsNullOrWhiteSpace(code))
                       {
                           Log.Information($"=====執行Code=> {code}=====!");

                           var jb = jobs.FirstOrDefault(w => w.Jobinfo.Code == options.Code);
                           if (jb !=null)
                           {
                               Log.Information($"=====執行 {jb.Jobinfo.Title}=====!");
                               //若參數不是空值，則設定輸入之參數
                               if (!string.IsNullOrWhiteSpace(paras)) jb.Jobinfo.Paras = paras;
                               //目前未實作
                               Task t = Utils.CopaUtil.StartService(jb.Jobinfo);
                               // 調整等待時間關閉
                               t.Wait();
                               // 自動關閉控制台應用程序
                               Environment.Exit(0);
                           }
                           else
                           {
                               Log.Information($"=====無此排程代碼 {code}=====!");
                           }
                       }
                   });
                }
                else
                {
                    bool createNew;
                    //已執行的程式不能再次執行
                    using (Mutex mutex = new Mutex(true, "Copacmd", out createNew))
                    {
                        if (createNew)
                        {
                            Log.Information("===========國鵬常註排程啟動===========!");

                            var scheduler = await Schedule.ScheduleManager.BuildScheduler();
                            await scheduler.Start();

                            foreach (var job in jobs)
                            {
                                var jobinfo = job.Jobinfo;
                                if (jobinfo.Enable) await Helpers.JobHelper.StartJobAsync(jobinfo);
                            }
                            Console.ReadLine();
                        }
                        else
                        {
                            Log.Information("===========國鵬常註排程已運作，請勿重復執行。===========!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Main==>發生錯誤!!");
            }
            finally
            {
            }
        }
    }

    public class CommandOptions
    {
        [Option('c', "Code", Required = true, HelpText = "排程代碼")]
        public string Code { get; set; }

        [Option('p', "Paras", Required = false, HelpText = "參數內容")]
        public string Paras { get; set; }
    }
}