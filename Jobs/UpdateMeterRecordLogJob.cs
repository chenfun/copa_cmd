using Quartz;

using System.Net.Sockets;
using CopaCmd.Adc.Models;
using CopaCmd.Models;
using Serilog;
using CopaCmd.ViewModel.Config;
using CopaContext;
using NModbus;
using MeterRecordLog = CopaCmd.Adc.Models.MeterRecordLog;

namespace CopaCmd.Jobs
{
    /// <summary>
    /// 取得智慧電表設備資料
    /// </summary>
    [DisallowConcurrentExecution]
    public class UpdateMeterRecordLogJob : IJob
    {
        private JobInfo info;
        private Dictionary<string, string> paras;

        public async Task Execute(IJobExecutionContext context)
        {
            Log.Information("=====START_取得智慧電表設備資料=====");
            try
            {
                //取出JobInfo
                JobDataMap data = context.JobDetail.JobDataMap;
                info = (JobInfo)data["info"];
                if (info != null)
                {
                    paras = Helpers.JobHelper.ConvertParas(info.Paras);
                    Task meterProcess = Helpers.ProcessHelper.StartProcessAsync(info.FileName);
                    Task meterMa = UpdateMaMeterRecord(new copapmsContext(),new CopaAdcContext());
                    await meterProcess;
                    await meterMa;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "取得智慧電表設備資料==>發生錯誤!!");
            }

            Log.Information("=====END_取得智慧電表設備資料=====");
        }

        private async Task UpdateMaMeterRecord(copapmsContext db,CopaAdcContext adcDb)
        {
            IList<MeterTable> allMeters = db.MeterTables.ToList();

            foreach (var meter in allMeters)
            {
                try
                {
                    MeterParameterMa meterParameterMa =
                        db.MeterParameterMas.FirstOrDefault(m => m.MeterNo == meter.MeterNo);
                    if (meterParameterMa != null)
                    {
                        var parameterMas = db.MeterParameterMas.Where(m => m.MeterNo == meter.MeterNo);
                        MeterRecordLog meterRecordLog = new MeterRecordLog();
                        foreach (var parameterMa in parameterMas)
                        {
                            string[] meterIp = parameterMa.IpAddress.Split(':');

                            using (TcpClient client = new TcpClient(meterIp[0], int.Parse(meterIp[1])))
                            {
                                var factory = new ModbusFactory();
                                IModbusMaster master = factory.CreateMaster(client);


                                byte slaveId = 1;
                                ushort startAddress = ushort.Parse(parameterMa.RegLocation);
                                ushort numInputs = 2;

                                ushort[] registers = master.ReadHoldingRegisters(slaveId, startAddress, numInputs);



                                var firstByte = BitConverter.GetBytes(registers[0]);
                                var secondByte = BitConverter.GetBytes(registers[1]);

                                var value = BitConverter.ToSingle(firstByte.Concat(secondByte).ToArray(), 0);


                                switch (parameterMa.ParaFieldName)
                                {
                                    case "voltage":
                                        meter.AvgVoltage = value + "";
                                        meterRecordLog.AvgVoltage = value + "";
                                        break;
                                    case "kw":
                                        meter.Electricity = value + "";
                                        meterRecordLog.Electricity = value + "";
                                        break;
                                    case "current":
                                        meter.AvgCurrent = value + "";
                                        meterRecordLog.AvgCurrent = value + "";
                                        break;
                                    case "power_factor":
                                        meter.PowerFactor = value + "";
                                        meterRecordLog.PowerFactor = value + "";
                                        break;
                                    case "kwh":
                                        meter.CumulativePower = value + "";
                                        meterRecordLog.CumulativePower = value + "";
                                        break;
                                    default:
                                        break;
                                }

                                meterRecordLog.MeterNo = meter.MeterNo;
                                meterRecordLog.MachineList = meter.MachineList;
                                meterRecordLog.Note = "鴻格電錶排程";
                            }
                        }

                        adcDb.MeterRecordLogs.Add(meterRecordLog);
                        meter.LastUpdateTime = DateTime.Now;
                    }
                }catch (Exception ex)
                {
                    Log.Error(ex, "取得智慧電表設備資料==>發生錯誤!!");
                    continue;
                }

                db.SaveChanges();
                adcDb.SaveChanges();
            }
        }
    }
}