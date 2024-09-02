using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CopaCmd.AttnErp.Models;
using CopaCmd.Models;
using CopaContext;

namespace CopaCmd.Services
{
    public class ErpTransferService
    {
        public ErpTransferService()
        {
        }

        public async Task Start(string startDate)
        {
            Log.Information("=====從ERP取得製令、派工單資訊=====");
            Log.Information($"取得{startDate}製令、派工單資訊");
            var today = DateTime.Parse(startDate);
            //string endDate = Helpers.JobHelper.GetPara(paras, "endDate", DateTime.Now.AddDays(-2).ToString());

            var db = new copapmsContext();
            var attnDb = new AttnErpContext();

            var erpDatas = attnDb.MfMos.Where(m =>
                m.MoDd.Date == today ||
                (m.ModifyDd.HasValue && m.ModifyDd.Value.Date == today));

            foreach (var erpData in erpDatas)
            {
                if (!db.ProductTables.Any(product => product.ProductName == erpData.MrpNo))
                {
                    SystemMsg systemMsg = new SystemMsg()
                    {
                        Category = "erp.product",
                        Msg = $"製令匯入錯誤，MES資料庫找不到該產品，產品名稱：{erpData.MrpNo}",
                        Status = "0",
                        Note = $"製令匯入錯誤，MES資料庫找不到該產品，產品名稱：{erpData.MrpNo}",
                    };
                    db.SystemMsgs.Add(systemMsg);
                    continue;
                }

                CopaWorkOrder workOrder = db.CopaWorkOrders.FirstOrDefault(w => w.WorkNo == erpData.MoNo);
                if (workOrder == null)
                {
                    workOrder = new CopaWorkOrder();
                    db.CopaWorkOrders.Add(workOrder);
                }

                var cust = attnDb.Custs.FirstOrDefault(c => c.CusNo == erpData.CusNo);
                string snm = string.Empty;
                if (cust == null)
                {
                    snm = erpData.CusNo;
                }
                else
                {
                    snm = cust.Snm;
                }

                workOrder.WorkNo = erpData.MoNo;
                workOrder.SeqNo = 0;
                workOrder.OrderNo = erpData.CasNo;
                workOrder.ConfirmDate = erpData.MoDd;
                workOrder.Customer = snm;
                // workOrder.IsClosed = erpData.CloseId == "T";
                // workOrder.IsClosedTapping = erpData.CloseId == "T";

                workOrder.CustomerSheet = erpData.CusOsNo;
                workOrder.ProductId =
                    db.ProductTables.First(product => product.ProductName == erpData.MrpNo).Id;
                workOrder.OrderQty = (int)(erpData.Qty * 1000 ?? 0);
                workOrder.Note = "預開工日: " + erpData.StaDd;
                workOrder.DeliveryDate = DateOnly.FromDateTime(erpData.NeedDd);
                workOrder.DeliveryPlace = "";
                workOrder.Packing = "";
                workOrder.CreateTime = DateTime.Now;
            }

            await db.SaveChangesAsync();

            var erpTzDatas = attnDb.MfTzs
                .Where(m => m.TzDd.Date == today ||
                            (m.ModifyDd.HasValue && m.ModifyDd.Value.Date == today))
                .Where(m => m.ZcNo == "A");
            foreach (var wcErpData in erpTzDatas)
            {
                var productModel =
                    db.ProductTables.FirstOrDefault(product => product.ProductName == wcErpData.MrpNo);
                if (productModel == null)
                {
                    SystemMsg systemMsg = new SystemMsg()
                    {
                        Category = "erp.product",
                        Msg = $"派工匯入錯誤，MES資料庫找不到該產品，產品名稱：{wcErpData.MrpNo}",
                        Status = "0",
                        Note = $"派工匯入錯誤，MES資料庫找不到該產品，產品名稱：{wcErpData.MrpNo}",
                    };
                    db.SystemMsgs.Add(systemMsg);
                    continue;
                }

                var workOrderModel = db.CopaWorkOrders.FirstOrDefault(workno => workno.WorkNo == wcErpData.MoNo);
                if (workOrderModel == null)
                {
                    SystemMsg systemMsg = new SystemMsg()
                    {
                        Category = "erp.product",
                        Msg = $"派工匯入錯誤，MES資料庫找不到該製令，製令名稱：{wcErpData.MoNo}",
                        Status = "0",
                        Note = $"派工匯入錯誤，MES資料庫找不到該製令，製令名稱：{wcErpData.MoNo}",
                    };
                    db.SystemMsgs.Add(systemMsg);
                    continue;
                }

                var machineModel = db.MachineTables.FirstOrDefault(machine => machine.MachineName == wcErpData.Dep);
                if (machineModel == null)
                {
                    SystemMsg systemMsg = new SystemMsg()
                    {
                        Category = "erp.product",
                        Msg = $"派工匯入錯誤，MES資料庫找不到該機台，機台名稱：{wcErpData.Dep}",
                        Status = "0",
                        Note = $"派工匯入錯誤，MES資料庫找不到該機台，機台名稱：{wcErpData.Dep}",
                    };
                    db.SystemMsgs.Add(systemMsg);
                    continue;
                }

                var moldModel = db.MoldSpecTables.FirstOrDefault(mold =>
                    mold.MachineId == machineModel.Id && mold.ProductId == productModel.Id + "");
                var rpmString = moldModel == null ? 0 : moldModel.Rpm;

                Workcommand workcommand = db.Workcommands.FirstOrDefault(w => w.ErpTzNo == wcErpData.TzNo);
                if (workcommand == null)
                {
                    workcommand = new Workcommand();
                    db.Workcommands.Add(workcommand);
                }

                workcommand.ErpTzDd = wcErpData.TzDd;
                workcommand.ErpTzNo = wcErpData.TzNo;
                workcommand.WorkNo = wcErpData.MoNo;
                workcommand.OrderNo = workOrderModel.OrderNo;
                workcommand.ProductId = productModel.Id + "";
                workcommand.SeqNo = 0;
                workcommand.ProduceSpeed = rpmString + "";
                workcommand.PlineId = "1";
                workcommand.PutIn = (int)(wcErpData.Qty * 1000 ?? 0);
                workcommand.ExpectedStartdate = wcErpData.StaDd;
                workcommand.ExpectedEnddate = wcErpData.EndDd;
                workcommand.MachineId = machineModel.MachineId == null ? 0 : machineModel.Id;
                workcommand.WorkcommandId =
                    string.IsNullOrEmpty(workcommand.WorkcommandId) ? "" : workcommand.WorkcommandId;
                workcommand.ExpectedStartdate = wcErpData.StaDd;
                workcommand.ExpectedEnddate = wcErpData.EndDd;
                workcommand.Createtime = wcErpData.TzDd;

                await db.SaveChangesAsync();
                if (string.IsNullOrEmpty(workcommand.WorkcommandId))
                {
                    Workcommand w = db.Workcommands.First(w => w.ErpTzNo == wcErpData.TzNo);
                    w.WorkcommandId = w.Id.ToString().PadLeft(8, '0');
                }
            }

            await db.SaveChangesAsync();
        }
    }
}