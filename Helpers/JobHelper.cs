using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;
using CopaCmd.Schedule;
using CopaCmd.ViewModel.Config;
using System.Linq.Expressions;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace CopaCmd.Helpers
{
    public class JobHelper
    {
        #region 命名前缀(可以自行設置)

        /// <summary>
        ///     作業前缀
        /// </summary>
        public static string JobPerfix = "Jb_";

        /// <summary>
        ///     作業分组前缀
        /// </summary>
        public static string GroupPerfix = "Gp_";

        /// <summary>
        ///     作業觸發器前缀
        /// </summary>
        public static string TriggerPerfix = "Trig_";

        #endregion 命名前缀(可以自行設置)

        #region 初始化

        /// <summary>
        ///    初始化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static JobKey GetJobKey<T>()
        {
            string name = typeof(T).FullName;
            return new JobKey(JobPerfix+name, GroupPerfix+name);
        }

        /// <summary>
        ///  初始化
        /// </summary>
        /// <param name="name"></typeparam>
        /// <returns></returns>
        public static JobKey GetJobKey(string name)
        {
            return new JobKey(JobPerfix+name, GroupPerfix+name);
        }

        #endregion 初始化

        #region 開啟作業

        /// <summary>
        /// 開始作業
        /// </summary>
        /// <param name="expression">表達式
        /// <returns></returns>
        public static bool StartJob<T>(string expression) where T : IJob
        {
            string name = typeof(T).FullName;
            IJobDetail job = Scheduler.GetIntance().GetJobDetail(GetJobKey<T>()).Result;
            if (job != null &&!Scheduler.GetIntance().IsJobGroupPaused(GroupPerfix+name).Result)
            {
                return true;
            }
            if (!Scheduler.GetIntance().IsStarted)
            {
                Scheduler.GetIntance().Start();
            }
            if (job != null)
            {
                Scheduler.GetIntance().ResumeJob(GetJobKey<T>());
            }
            else
            {
                IJobDetail detail = JobBuilder.Create<T>().WithIdentity(JobPerfix+name, GroupPerfix+name).Build();
                ITrigger trigger = TriggerBuilder.Create()
                                                 .WithIdentity(TriggerPerfix+name)
                                                 .StartNow()
                                                 .WithCronSchedule(expression).ForJob(detail)
                                                 .Build();
                Scheduler.GetIntance().ScheduleJob(detail, trigger);
                return true;
            }

            return false;
        }

        /// <summary>
        /// 開始作業
        /// </summary>
        /// <param name="name">作業物件名稱(全名) 如：CopaCmd.Jobs.GetTapValueInfo</param>
        /// <param name="expression"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static bool StartJob(string name, string expression)
        {
            Type type = Type.GetType(name);
            if (type == null || !typeof(IJob).IsAssignableFrom(type))
            {
                // 如果class字串無效或不實作IJob介面，則拋出例外
                throw new ArgumentException($"{name} Invalid class name or not an IJob");
            }
            IJobDetail job = Scheduler.GetIntance().GetJobDetail(GetJobKey(name)).Result;
            if (job != null && !Scheduler.GetIntance().IsJobGroupPaused(GroupPerfix + name).Result)
            {
                return true;
            }
            if (!Scheduler.GetIntance().IsStarted)
            {
                Scheduler.GetIntance().Start();
            }
            if (job != null)
            {
                Scheduler.GetIntance().ResumeJob(GetJobKey(name));
            }
            else
            {
                JobBuilder builder = JobBuilder.Create();
                builder.OfType(type);
                IJobDetail detail = builder.WithIdentity(JobPerfix+name, GroupPerfix+name).Build();
                ITrigger trigger = TriggerBuilder.Create()
                                                 .WithIdentity(TriggerPerfix + name)
                                                 .StartNow()
                                                 .WithCronSchedule(expression).ForJob(detail)
                                                 .Build();
                Scheduler.GetIntance().ScheduleJob(detail, trigger);
                return true;
            }

            return false;
        }

        public static bool StartJob(JobInfo info)
        {
            string name = info.No;
            string expression = info.CronSchedule;
            Type type = Type.GetType(name);
            if (type == null || !typeof(IJob).IsAssignableFrom(type))
            {
                // 如果class字串無效或不實作IJob介面，則拋出例外
                throw new ArgumentException($"{name} Invalid class name or not an IJob");
            }
            IJobDetail job = Scheduler.GetIntance().GetJobDetail(GetJobKey(name)).Result;
            if (job != null && !Scheduler.GetIntance().IsJobGroupPaused(GroupPerfix + name).Result)
            {
                return true;
            }
            if (!Scheduler.GetIntance().IsStarted)
            {
                Scheduler.GetIntance().Start();
            }
            if (job != null)
            {
                Scheduler.GetIntance().ResumeJob(GetJobKey(name));
            }
            else
            {
                JobBuilder builder = JobBuilder.Create();
                builder.OfType(type);
                JobDataMap jobDataMap = new JobDataMap();
                jobDataMap.Put("info", info);
                IJobDetail detail = builder.WithIdentity(JobPerfix+name, GroupPerfix+name).UsingJobData(jobDataMap).Build();
                ITrigger trigger = TriggerBuilder.Create()
                                                 .WithIdentity(TriggerPerfix + name)
                                                 .StartNow()
                                                 .WithCronSchedule(expression).ForJob(detail)
                                                 .Build();

                Scheduler.GetIntance().ScheduleJob(detail, trigger);
                return true;
            }
            return false;
        }

        public static async Task<bool> StartJobAsync(JobInfo info)
        {
            string name = info.No;
            //修改是否為多個觸發器
            List<string> expressions = info.CronSchedule.Split("||").ToList();

            Type type = Type.GetType(name);

            if (type == null || !typeof(IJob).IsAssignableFrom(type))
            {
                // 如果class字串無效或不實作IJob介面，則拋出例外
                throw new ArgumentException($"{name} Invalid class name or not an IJob");
            }

            JobBuilder builder = JobBuilder.Create();
            builder.OfType(type);
            JobDataMap jobDataMap = new JobDataMap();
            jobDataMap.Put("info", info);
            IJobDetail detail = builder.WithIdentity(JobPerfix + name, GroupPerfix + name)
                                       .UsingJobData(jobDataMap)
                                       .Build();

            bool hasJob = false;
            foreach (var exp in expressions)
            {
                ITrigger trigger = TriggerBuilder.Create()
                                            .WithIdentity(TriggerPerfix + name + new Random().Next(1, 999))
                                            .StartNow()
                                            .WithCronSchedule(exp).ForJob(detail)
                                            .Build();

                if (!hasJob)
                {
                    await Scheduler.GetIntance().ScheduleJob(detail, trigger);
                }
                else
                {
                    //因為已經加過Job了，不能再使用ScheduleJob(detail, trigger)
                    await Scheduler.GetIntance().ScheduleJob(trigger);
                }
                hasJob = true;
            }
            return true;
        }

        public static bool StartNowJob(JobInfo info)
        {
            string name = info.No;
            string expression = info.CronSchedule;
            Type type = Type.GetType(name);

            if (type == null || !typeof(IJob).IsAssignableFrom(type))
            {
                // 如果class字串無效或不實作IJob介面，則拋出例外
                throw new ArgumentException($"{name} Invalid class name or not an IJob");
            }

            JobBuilder builder = JobBuilder.Create();
            builder.OfType(type);
            JobDataMap jobDataMap = new JobDataMap();
            jobDataMap.Put("info", info);
            IJobDetail detail = builder.WithIdentity(JobPerfix + name, GroupPerfix + name)
                                       .UsingJobData(jobDataMap)
                                       .Build();

            ITrigger trigger = TriggerBuilder.Create()
                                              .WithIdentity(TriggerPerfix + name)
                                              .ForJob(detail)
                                              .StartNow()
                                              .WithSimpleSchedule(x => x.WithRepeatCount(0))
                                              .Build();

            Scheduler.GetIntance().ScheduleJob(detail, trigger);
            return true;
        }

        #endregion 開啟作業

        #region 停止作業

        /// <summary>
        ///     停止作業
        /// </summary>
        /// <returns></returns>
        public static bool StopJob<T>()
        {
            string name = typeof(T).FullName;
            IJobDetail detail = Scheduler.GetIntance().GetJobDetail(GetJobKey<T>()).Result;
            if (detail != null &&!Scheduler.GetIntance().IsJobGroupPaused(GroupPerfix + name).Result)
            {
                Scheduler.GetIntance().PauseJob(GetJobKey<T>());
                return true;
            }
            return false;
        }

        #endregion 停止作業

        #region 删除作業

        /// <summary>
        ///     删除作業
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool DelJob<T>()
        {
            string name = typeof(T).FullName;
            IJobDetail detail = Scheduler.GetIntance().GetJobDetail(GetJobKey<T>()).Result;
            if (detail != null&&!Scheduler.GetIntance().IsJobGroupPaused(GroupPerfix + name).Result)
            {
                Scheduler.GetIntance().PauseJob(GetJobKey<T>());
                Scheduler.GetIntance().DeleteJob(GetJobKey<T>());
                return true;
            }
            return false;
        }

        #endregion 删除作業

        #region 取得作業運行狀態

        /// <summary>
        ///     取得作業運行狀態 true 正在運行，false 未運行
        /// </summary>
        /// <returns></returns>
        public static bool GetJobStatus<T>()
        {
            string name = typeof(T).FullName;
            IJobDetail detail = Scheduler.GetIntance().GetJobDetail(GetJobKey<T>()).Result;
            if (detail != null && !Scheduler.GetIntance().IsJobGroupPaused(GroupPerfix + name).Result)
            {
                return true;
            }
            return false;
        }

        public static bool GetJobStatus(string jobName)
        {
            string className = jobName.Substring(JobPerfix.Length);
            IJobDetail detail = Schedule.Scheduler.GetIntance().GetJobDetail(new JobKey(jobName, GroupPerfix+className)).Result;
            if (detail != null &&!Scheduler.GetIntance().IsJobGroupPaused(GroupPerfix + className).Result)
            {
                return true;
            }
            return false;
        }

        #endregion 取得作業運行狀態

        #region "常用工具"

        /// <summary>
        /// 將參數字串轉為字典
        /// </summary>
        /// <param name="paraString">參數字串</param>
        /// <returns></returns>
        public static Dictionary<string, string> ConvertParas(string paraString)
        {
            Dictionary<string, string> datas = new Dictionary<string, string>();
            if (string.IsNullOrWhiteSpace(paraString)) { return datas; }
            var paras = paraString.Split(",").ToList();
            foreach (var pa in paras)
            {
                datas.Add(pa.Split("=")[0].Trim(), pa.Split("=")[1].Trim());
            }
            return datas;
        }

        /// <summary>
        /// 取得參數資料
        /// </summary>
        /// <param name="paras">參數列表</param>
        /// <param name="paraName">參數名稱</param>
        /// <param name="defaultValue">預設值</param>
        /// <returns></returns>
        public static string GetPara(Dictionary<string, string> paras, string paraName, string defaultValue)
        {
            if (paras == null) return defaultValue;
            if (paras.ContainsKey(paraName)) return paras[paraName];
            return defaultValue;
        }

        /// <summary>
        /// 取得參數資料
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="paras">參數列表</param>
        /// <param name="paraName">參數名稱</param>
        /// <param name="defaultValue">預設值</param>
        /// <returns></returns>
        public static T GetPara<T>(Dictionary<string, string> paras, string paraName, T defaultValue)
        {
            if (paras == null) return defaultValue;
            if (paras.TryGetValue(paraName, out string value))
            {
                // 使用 Convert.ChangeType 轉換字串值為目標型別 T
                try
                {
                    return (T)Convert.ChangeType(value, typeof(T));
                }
                catch (InvalidCastException)
                {
                    // 轉換失敗，回傳預設值
                    return defaultValue;
                }
            }
            return defaultValue;
        }

        #endregion "常用工具"
    }
}