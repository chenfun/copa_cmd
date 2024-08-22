using CopaCmd.Models;
using Microsoft.EntityFrameworkCore;

namespace CopaContext
{
    public partial class copapmsContext : DbContext
    {
        public copapmsContext(DbContextOptions<copapmsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdjustMold> AdjustMolds { get; set; } = null!;
        public virtual DbSet<AvailableWorkNoMachine> AvailableWorkNoMachines { get; set; } = null!;
        public virtual DbSet<CopaWorkOrder> CopaWorkOrders { get; set; } = null!;
        public virtual DbSet<CopaWorkOrderPowerinfo> CopaWorkOrderPowerinfos { get; set; } = null!;
        public virtual DbSet<DayPackage> DayPackages { get; set; } = null!;
        public virtual DbSet<DayPro> DayPros { get; set; } = null!;
        public virtual DbSet<DayProduct> DayProducts { get; set; } = null!;
        public virtual DbSet<DetectionRecord> DetectionRecords { get; set; } = null!;
        public virtual DbSet<DetectionRecordSheet> DetectionRecordSheets { get; set; } = null!;
        public virtual DbSet<DetectionStandard> DetectionStandards { get; set; } = null!;
        public virtual DbSet<DetectionStandardSheet> DetectionStandardSheets { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Fixreason> Fixreasons { get; set; } = null!;
        public virtual DbSet<FixreasonCategory1> FixreasonCategory1s { get; set; } = null!;
        public virtual DbSet<FixreasonCategory2> FixreasonCategory2s { get; set; } = null!;
        public virtual DbSet<Handover> Handovers { get; set; } = null!;
        public virtual DbSet<InventoryDetail> InventoryDetails { get; set; } = null!;
        public virtual DbSet<Language> Languages { get; set; } = null!;
        public virtual DbSet<LoginRecord> LoginRecords { get; set; } = null!;
        public virtual DbSet<MachineStatusLog> MachineStatusLogs { get; set; } = null!;
        public virtual DbSet<MachineStatusLogTap> MachineStatusLogTaps { get; set; } = null!;
        public virtual DbSet<MachineTable> MachineTables { get; set; } = null!;
        public virtual DbSet<MachineTableTap> MachineTableTaps { get; set; } = null!;
        public virtual DbSet<MachineTableTapProduct> MachineTableTapProducts { get; set; } = null!;
        public virtual DbSet<MachinesCountLog> MachinesCountLogs { get; set; } = null!;
        public virtual DbSet<MachinesCountLogBackup> MachinesCountLogBackups { get; set; } = null!;
        public virtual DbSet<Machinetype> Machinetypes { get; set; } = null!;
        public virtual DbSet<MeasuringTool> MeasuringTools { get; set; } = null!;
        public virtual DbSet<Mold> Molds { get; set; } = null!;
        public virtual DbSet<MoldCategory> MoldCategories { get; set; } = null!;
        public virtual DbSet<MoldReplaceRecord> MoldReplaceRecords { get; set; } = null!;
        public virtual DbSet<MoldSpecTable> MoldSpecTables { get; set; } = null!;
        public virtual DbSet<MoldSpecTableSheet> MoldSpecTableSheets { get; set; } = null!;
        public virtual DbSet<MoldUseLog> MoldUseLogs { get; set; } = null!;
        public virtual DbSet<MoldUseTotal> MoldUseTotals { get; set; } = null!;
        public virtual DbSet<PackagingDetail> PackagingDetails { get; set; } = null!;
        public virtual DbSet<PackagingRecord> PackagingRecords { get; set; } = null!;
        public virtual DbSet<Precaution> Precautions { get; set; } = null!;
        public virtual DbSet<ProductTable> ProductTables { get; set; } = null!;
        public virtual DbSet<ShiftTable> ShiftTables { get; set; } = null!;
        public virtual DbSet<SystemParameter> SystemParameters { get; set; } = null!;
        public virtual DbSet<UserDevice> UserDevices { get; set; } = null!;
        public virtual DbSet<Vigorplclog> Vigorplclogs { get; set; } = null!;
        public virtual DbSet<Vigorplclog2021> Vigorplclog2021s { get; set; } = null!;
        public virtual DbSet<VigorplclogBackup> VigorplclogBackups { get; set; } = null!;
        public virtual DbSet<VigorplclogTap> VigorplclogTaps { get; set; } = null!;
        public virtual DbSet<WorkOrder> WorkOrders { get; set; } = null!;
        public virtual DbSet<Workcommand> Workcommands { get; set; } = null!;
        public virtual DbSet<WorkcommandDetail> WorkcommandDetails { get; set; } = null!;
        public virtual DbSet<SystemMsg> SystemMsgs { get; set; } = null!;

        public virtual DbSet<WorkcommandDetailsTap> WorkcommandDetailsTaps { get; set; } = null!;
        public virtual DbSet<WorkcommandTap> WorkcommandTaps { get; set; } = null!;
        public virtual DbSet<ZoneTable> ZoneTables { get; set; } = null!;
        public virtual DbSet<ZoneTomachineTable> ZoneTomachineTables { get; set; } = null!;
        public virtual DbSet<MeterDayRecord> MeterDayRecords { get; set; } = null!;
        public virtual DbSet<MeterParameter> MeterParameters { get; set; } = null!;
        public virtual DbSet<MeterRecordLog> MeterRecordLogs { get; set; } = null!;
        public virtual DbSet<MeterTable> MeterTables { get; set; } = null!;
        public virtual DbSet<MeterParameterMa> MeterParameterMas { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8");

            modelBuilder.Entity<AdjustMold>(entity =>
            {
                entity.ToTable("adjust_mold");

                entity.HasComment("機台尺寸調整紀錄表");

                entity.HasIndex(e => new { e.MachineId, e.Isok }, "machine_id_and_isok");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id")
                    .HasComment("ID");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("create_time")
                    .HasComment("建立時間");

                entity.Property(e => e.EmployeeId)
                    .HasColumnType("int(11)")
                    .HasColumnName("employee_id")
                    .HasComment("操作員id");

                entity.Property(e => e.EndCount)
                    .HasColumnType("int(11)")
                    .HasColumnName("end_count")
                    .HasComment("結束時計數器計數");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("end_date")
                    .HasComment("調整結束時間");

                entity.Property(e => e.Isok)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("isok")
                    .HasComment("是否完成");

                entity.Property(e => e.MachineId)
                    .HasColumnType("int(11)")
                    .HasColumnName("machine_id")
                    .HasComment("機台id");

                entity.Property(e => e.MoldCategoryId)
                    .HasColumnType("int(11)")
                    .HasColumnName("mold_category_id")
                    .HasComment("模具大類id");

                entity.Property(e => e.MoldId)
                    .HasColumnType("int(11)")
                    .HasColumnName("mold_id")
                    .HasComment("模具編號id");

                entity.Property(e => e.StartCount)
                    .HasColumnType("int(11)")
                    .HasColumnName("start_count")
                    .HasComment("開始時計數器計數");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("start_date")
                    .HasComment("調整開始時間");
            });

            modelBuilder.Entity<AvailableWorkNoMachine>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("available_work_no_machine");

                entity.Property(e => e.MachineId)
                    .HasColumnType("int(11)")
                    .HasColumnName("machine_id")
                    .HasDefaultValueSql("'0'")
                    .HasComment("id");

                entity.Property(e => e.MachineName)
                    .HasMaxLength(10)
                    .HasColumnName("machine_name")
                    .HasComment("機台名稱");

                entity.Property(e => e.OrderQty)
                    .HasColumnType("int(11)")
                    .HasColumnName("order_qty")
                    .HasComment("訂單數量");

                entity.Property(e => e.ProductId)
                    .HasColumnType("int(11)")
                    .HasColumnName("product_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .HasColumnName("product_name")
                    .HasComment("規格");

                entity.Property(e => e.Total)
                    .HasColumnType("int(11)")
                    .HasColumnName("total")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.WorkNo)
                    .HasMaxLength(30)
                    .HasColumnName("work_no")
                    .HasComment("製令編號");

                entity.Property(e => e.WorkcommandDetailsId)
                    .HasColumnType("int(12) unsigned")
                    .HasColumnName("workcommand_details_id")
                    .HasComment("序號");

                entity.Property(e => e.WorkcommandId)
                    .HasMaxLength(50)
                    .HasColumnName("workcommand_id")
                    .HasComment("工令");
            });

            modelBuilder.Entity<CopaWorkOrder>(entity =>
            {
                entity.ToTable("copa_work_order");

                entity.HasComment("國鵬工單");

                entity.HasIndex(e => e.WorkNo, "work_no");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id")
                    .HasComment("序號");

                entity.Property(e => e.ClosedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("closed_time")
                    .HasComment("結案時間");

                entity.Property(e => e.ClosedUser)
                    .HasMaxLength(50)
                    .HasColumnName("closed_user")
                    .HasComment("結案者");

                entity.Property(e => e.ConfirmDate)
                    .HasColumnType("datetime")
                    .HasColumnName("confirm_date")
                    .HasComment("客戶確認日期");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("create_time")
                    .HasComment("新增時間");

                entity.Property(e => e.Customer)
                    .HasMaxLength(30)
                    .HasColumnName("customer")
                    .HasComment("客戶");

                entity.Property(e => e.CustomerSheet)
                    .HasMaxLength(30)
                    .HasColumnName("customer_sheet")
                    .HasComment("客戶訂單編號");

                entity.Property(e => e.DeliveryDate)
                    .HasColumnName("delivery_date")
                    .HasComment("交貨期限");

                entity.Property(e => e.DeliveryPlace)
                    .HasMaxLength(30)
                    .HasColumnName("delivery_place")
                    .HasComment("交貨地點");

                entity.Property(e => e.ExpectedQty)
                    .HasColumnType("int(11)")
                    .HasColumnName("expected_qty")
                    .HasComment("預計產量");

                entity.Property(e => e.IsClosed)
                    .HasColumnName("is_closed")
                    .HasComment("是否結案");

                entity.Property(e => e.IsClosedTapping)
                    .HasColumnName("is_closed_tapping")
                    .HasComment("是否生產完成_攻牙製程選擇用");

                entity.Property(e => e.Note)
                    .HasMaxLength(50)
                    .HasColumnName("note")
                    .HasComment("備註");

                entity.Property(e => e.OrderNo)
                    .HasMaxLength(30)
                    .HasColumnName("order_no")
                    .HasComment("訂單單號");

                entity.Property(e => e.OrderQty)
                    .HasColumnType("int(11)")
                    .HasColumnName("order_qty")
                    .HasComment("訂單數量");

                entity.Property(e => e.OrderUnit)
                    .HasMaxLength(30)
                    .HasColumnName("order_unit")
                    .HasComment("單位");

                entity.Property(e => e.Packing)
                    .HasMaxLength(30)
                    .HasColumnName("packing")
                    .HasComment("包裝");

                entity.Property(e => e.ProductId)
                    .HasColumnType("int(11)")
                    .HasColumnName("product_id")
                    .HasComment("產品品號");

                entity.Property(e => e.SeqNo)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("seq_no")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.TapClosedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("tap_closed_time")
                    .HasComment("生產完成時間");

                entity.Property(e => e.TapClosedUser)
                    .HasMaxLength(50)
                    .HasColumnName("tap_closed_user")
                    .HasComment("完成者");

                entity.Property(e => e.WorkNo)
                    .HasMaxLength(30)
                    .HasColumnName("work_no")
                    .HasComment("製令編號");

                entity.Property(e => e.WorkNoN)
                    .HasMaxLength(30)
                    .HasColumnName("work_no_n")
                    .HasComment("合併製令編號");
            });

                    modelBuilder.Entity<CopaWorkOrderPowerinfo>(entity =>
            {
                entity.ToTable("copa_work_order_powerinfo");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasComment("序號");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("create_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("建立時間");

                entity.Property(e => e.DetailTotalCnt)
                    .HasColumnType("int(11)")
                    .HasColumnName("detail_total_cnt")
                    .HasComment("明細總生產量");

                entity.Property(e => e.EndTime)
                    .HasColumnType("datetime")
                    .HasColumnName("end_time")
                    .HasComment("結束時間");

                entity.Property(e => e.MachineName)
                    .HasMaxLength(20)
                    .HasColumnName("machine_name")
                    .HasComment("機台名稱");

                entity.Property(e => e.MeterName)
                    .HasMaxLength(20)
                    .HasColumnName("meter_name")
                    .HasComment("電表名稱");

                entity.Property(e => e.Note)
                    .HasMaxLength(50)
                    .HasColumnName("note")
                    .HasComment("備註");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(20)
                    .HasColumnName("product_name")
                    .HasComment("產品品號");

                entity.Property(e => e.StartTime)
                    .HasColumnType("datetime")
                    .HasColumnName("start_time")
                    .HasComment("開始時間");

                entity.Property(e => e.TotalCnt)
                    .HasColumnType("int(11)")
                    .HasColumnName("total_cnt")
                    .HasComment("總生產量");

                entity.Property(e => e.TotalPowerConsumption)
                    .HasMaxLength(20)
                    .HasColumnName("total_power_consumption")
                    .HasComment("總秏電量");

                entity.Property(e => e.TotalProductionSecs)
                    .HasColumnType("int(11)")
                    .HasColumnName("total_production_secs")
                    .HasComment("總生產秒數");

                entity.Property(e => e.WorkNo)
                    .HasMaxLength(20)
                    .HasColumnName("work_no")
                    .HasComment("製令編號");
            });
                    
            modelBuilder.Entity<DayPackage>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("day_package");

                entity.Property(e => e.BatNo)
                    .HasMaxLength(50)
                    .HasColumnName("BAT_NO")
                    .HasComment("箱號");

                entity.Property(e => e.Dep)
                    .HasMaxLength(2)
                    .HasColumnName("DEP")
                    .HasDefaultValueSql("''")
                    .UseCollation("utf8mb4_general_ci")
                    .HasCharSet("utf8mb4");

                entity.Property(e => e.MoNo)
                    .HasMaxLength(30)
                    .HasColumnName("MO_NO")
                    .HasComment("製令編號");

                entity.Property(e => e.PrdNo)
                    .HasMaxLength(50)
                    .HasColumnName("PRD_NO")
                    .HasComment("規格");

                entity.Property(e => e.QtyFin)
                    .HasMaxLength(1)
                    .HasColumnName("QTY_FIN")
                    .HasDefaultValueSql("''")
                    .UseCollation("utf8mb4_general_ci")
                    .HasCharSet("utf8mb4");

                entity.Property(e => e.Rem)
                    .HasMaxLength(50)
                    .HasColumnName("REM")
                    .HasComment("桶數(多數使用，分隔)");

                entity.Property(e => e.Usr)
                    .HasMaxLength(50)
                    .HasColumnName("USR")
                    .HasComment("建立者");

                entity.Property(e => e.WrDd).HasColumnName("WR_DD");

                entity.Property(e => e.WrNo)
                    .HasMaxLength(20)
                    .HasColumnName("WR_NO")
                    .HasComment("包裝編號");

                entity.Property(e => e.ZcNo)
                    .HasMaxLength(1)
                    .HasColumnName("ZC_NO")
                    .HasDefaultValueSql("''")
                    .UseCollation("utf8mb4_general_ci")
                    .HasCharSet("utf8mb4");
            });

            modelBuilder.Entity<DayPro>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("day_pro");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("enddate")
                    .HasComment("結束時間");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(50)
                    .HasColumnName("fullname")
                    .HasComment("姓名");

                entity.Property(e => e.MachineId)
                    .HasMaxLength(10)
                    .HasColumnName("machine_id")
                    .HasComment("機台名稱");

                entity.Property(e => e.MachineName)
                    .HasMaxLength(10)
                    .HasColumnName("machine_name")
                    .HasComment("機台名稱");

                entity.Property(e => e.NgCnt)
                    .HasColumnType("int(11)")
                    .HasColumnName("ng_cnt");

                entity.Property(e => e.OkCnt)
                    .HasColumnType("int(11)")
                    .HasColumnName("ok_cnt");

                entity.Property(e => e.ProcessName)
                    .HasMaxLength(2)
                    .HasColumnName("process_name")
                    .HasDefaultValueSql("''")
                    .UseCollation("utf8mb4_general_ci")
                    .HasCharSet("utf8mb4");

                entity.Property(e => e.ProduceSpeed)
                    .HasMaxLength(10)
                    .HasColumnName("produce_speed")
                    .HasComment("產速");

                entity.Property(e => e.ProductId)
                    .HasMaxLength(50)
                    .HasColumnName("product_id")
                    .HasComment("產品代號");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .HasColumnName("product_name")
                    .HasComment("規格");

                entity.Property(e => e.ProductNo)
                    .HasMaxLength(20)
                    .HasColumnName("product_no")
                    .HasComment("產品料號");

                entity.Property(e => e.Startdate)
                    .HasColumnType("datetime")
                    .HasColumnName("startdate")
                    .HasComment("開始時間");

                entity.Property(e => e.Total)
                    .HasColumnType("bigint(12)")
                    .HasColumnName("total");

                entity.Property(e => e.WorkNo)
                    .HasMaxLength(50)
                    .HasColumnName("work_no")
                    .HasComment("工單");
            });

            modelBuilder.Entity<DayProduct>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("day_product");

                entity.Property(e => e.Dm)
                    .HasPrecision(16)
                    .HasColumnName("dm");

                entity.Property(e => e.Dt)
                    .HasColumnType("bigint(21)")
                    .HasColumnName("dt");

                entity.Property(e => e.Eff).HasColumnName("eff");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("enddate")
                    .HasComment("結束時間");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(50)
                    .HasColumnName("fullname")
                    .HasComment("姓名");

                entity.Property(e => e.MachineId)
                    .HasMaxLength(20)
                    .HasColumnName("machine_id")
                    .HasComment("機台");

                entity.Property(e => e.MachineName)
                    .HasMaxLength(10)
                    .HasColumnName("machine_name")
                    .HasComment("機台名稱");

                entity.Property(e => e.NgCnt)
                    .HasColumnType("int(11)")
                    .HasColumnName("ng_cnt");

                entity.Property(e => e.OkCnt)
                    .HasColumnType("int(11)")
                    .HasColumnName("ok_cnt");

                entity.Property(e => e.ProduceSpeed)
                    .HasMaxLength(10)
                    .HasColumnName("produce_speed")
                    .HasComment("產速");

                entity.Property(e => e.ProductId)
                    .HasMaxLength(50)
                    .HasColumnName("product_id")
                    .HasComment("產品代號");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .HasColumnName("product_name")
                    .HasComment("規格");

                entity.Property(e => e.ProductNo)
                    .HasMaxLength(20)
                    .HasColumnName("product_no")
                    .HasComment("產品料號");

                entity.Property(e => e.Startdate)
                    .HasColumnType("datetime")
                    .HasColumnName("startdate")
                    .HasComment("開始時間");

                entity.Property(e => e.Theoretical).HasColumnName("theoretical");

                entity.Property(e => e.Total)
                    .HasColumnType("bigint(12)")
                    .HasColumnName("total");

                entity.Property(e => e.WorkNo)
                    .HasMaxLength(50)
                    .HasColumnName("work_no")
                    .HasComment("工單");
            });

            modelBuilder.Entity<DetectionRecord>(entity =>
            {
                entity.ToTable("detection_record");

                entity.HasComment("檢測紀錄");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("create_time")
                    .HasComment("建立時間");

                entity.Property(e => e.DetectionStandardId)
                    .HasColumnType("int(11)")
                    .HasColumnName("detection_standard_id")
                    .HasComment("檢測標準id");
            });

            modelBuilder.Entity<DetectionRecordSheet>(entity =>
            {
                entity.ToTable("detection_record_sheet");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.DetectionRecordId)
                    .HasColumnType("int(11)")
                    .HasColumnName("detection_record_id")
                    .HasComment("檢測紀錄主項id");

                entity.Property(e => e.DetectionStandardSheetId)
                    .HasColumnType("int(11)")
                    .HasColumnName("detection_standard_sheet_id")
                    .HasComment("檢測標準細項id");

                entity.Property(e => e.Value)
                    .HasMaxLength(255)
                    .HasColumnName("value")
                    .HasComment("紀錄資料");
            });

            modelBuilder.Entity<DetectionStandard>(entity =>
            {
                entity.ToTable("detection_standard");

                entity.HasComment("成型機檢驗標準對應表");

                entity.HasIndex(e => e.ProductId, "product_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("create_time")
                    .HasComment("新增日期");

                entity.Property(e => e.MachineId)
                    .HasColumnType("int(11)")
                    .HasColumnName("machine_id")
                    .HasComment("車型");

                entity.Property(e => e.MeasuringToolId)
                    .HasColumnType("int(11)")
                    .HasColumnName("measuring_tool_id")
                    .HasComment("量具id");

                entity.Property(e => e.ProductId)
                    .HasColumnType("int(11)")
                    .HasColumnName("product_id")
                    .HasComment("規格");
            });

            modelBuilder.Entity<DetectionStandardSheet>(entity =>
            {
                entity.ToTable("detection_standard_sheet");

                entity.HasComment("成型機檢驗欄位");

                entity.HasIndex(e => e.DetectionStandardId, "detectionId_no_step");

                entity.HasIndex(e => e.DetectionItemName, "key");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.DetectionItemName)
                    .HasMaxLength(30)
                    .HasColumnName("detection_item_name")
                    .HasComment("項目");

                entity.Property(e => e.DetectionStandardId)
                    .HasColumnType("int(11)")
                    .HasColumnName("detection_standard_id")
                    .HasComment("檢驗標準id");

                entity.Property(e => e.LowerLimit)
                    .HasMaxLength(255)
                    .HasColumnName("lower_limit")
                    .HasComment("下限參考值");

                entity.Property(e => e.UpperLimit)
                    .HasMaxLength(255)
                    .HasColumnName("upper_limit")
                    .HasComment("上限參考值");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employees");

                entity.HasComment("員工");

                entity.HasIndex(e => e.Account, "account");

                entity.HasIndex(e => e.Token, "token");

                entity.Property(e => e.Id)
                    .HasColumnType("mediumint(9)")
                    .HasColumnName("id")
                    .HasComment("序號");

                entity.Property(e => e.Account)
                    .HasMaxLength(50)
                    .HasColumnName("account")
                    .HasComment("帳號");

                entity.Property(e => e.Content)
                    .HasColumnType("text")
                    .HasColumnName("content")
                    .HasComment("備註");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(50)
                    .HasColumnName("fullname")
                    .HasComment("姓名");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password")
                    .HasComment("密碼");

                entity.Property(e => e.Postition)
                    .HasColumnType("enum('操作員','技術員','主管')")
                    .HasColumnName("postition")
                    .HasComment("職務");

                entity.Property(e => e.Privilege)
                    .HasMaxLength(255)
                    .HasColumnName("privilege")
                    .HasComment("程式權限");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'Y'")
                    .HasComment("狀態");

                entity.Property(e => e.Token)
                    .HasColumnName("token")
                    .HasComment("登入令牌");
            });

            modelBuilder.Entity<Fixreason>(entity =>
            {
                entity.ToTable("fixreason");

                entity.HasComment("維修原因");

                entity.HasIndex(e => e.Code, "code");

                entity.Property(e => e.Id)
                    .HasColumnType("int(8) unsigned")
                    .HasColumnName("id")
                    .HasComment("ID");

                entity.Property(e => e.Alarm)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("alarm")
                    .HasDefaultValueSql("'0'")
                    .HasComment("是否提醒？預設0不提醒");

                entity.Property(e => e.Code)
                    .HasMaxLength(6)
                    .HasColumnName("code")
                    .HasComment("代碼");

                entity.Property(e => e.FixreasonCategory1Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("fixreason_category1_id")
                    .HasComment("隸屬部位");

                entity.Property(e => e.FixreasonCategory2Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("fixreason_category2_id")
                    .HasComment("造成主因");

                entity.Property(e => e.Message)
                    .HasMaxLength(200)
                    .HasColumnName("message")
                    .HasComment("原因");
            });

            modelBuilder.Entity<FixreasonCategory1>(entity =>
            {
                entity.ToTable("fixreason_category1");

                entity.HasComment("維修原因隸屬部位");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id")
                    .HasComment("ID");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(20)
                    .HasColumnName("category_name")
                    .HasComment("隸屬部位");
            });

            modelBuilder.Entity<FixreasonCategory2>(entity =>
            {
                entity.ToTable("fixreason_category2");

                entity.HasComment("維修原因隸屬部位");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id")
                    .HasComment("ID");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(20)
                    .HasColumnName("category_name")
                    .HasComment("隸屬部位");
            });

            modelBuilder.Entity<Handover>(entity =>
            {
                entity.ToTable("handover");

                entity.HasComment("交接事項");

                entity.HasIndex(e => new { e.MachineId, e.CreateTime }, "machine_id_and_create_time");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id")
                    .HasComment("id");

                entity.Property(e => e.Content)
                    .HasMaxLength(100)
                    .HasColumnName("content")
                    .HasComment("內容");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("create_time")
                    .HasComment("填寫時間");

                entity.Property(e => e.Creator)
                    .HasColumnType("int(11)")
                    .HasColumnName("creator")
                    .HasComment("填寫人員工id");

                entity.Property(e => e.MachineId)
                    .HasMaxLength(20)
                    .HasColumnName("machine_id")
                    .HasComment("車型id");

                entity.Property(e => e.Note)
                    .HasMaxLength(100)
                    .HasColumnName("note")
                    .HasComment("備註");

                entity.Property(e => e.Read)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("read")
                    .HasDefaultValueSql("'0'")
                    .HasComment("看過與否。0未看，1看過");
            });

            modelBuilder.Entity<InventoryDetail>(entity =>
            {
                entity.ToTable("inventory_detail");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id")
                    .HasComment("序號");

                entity.Property(e => e.AdjustQty)
                    .HasColumnType("int(11)")
                    .HasColumnName("adjust_qty")
                    .HasComment("調整數量");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("create_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("建立時間");

                entity.Property(e => e.Creater)
                    .HasMaxLength(50)
                    .HasColumnName("creater")
                    .HasComment("建立者");

                entity.Property(e => e.CreaterId)
                    .HasColumnType("mediumint(9)")
                    .HasColumnName("creater_id")
                    .HasComment("建立者序號");

                entity.Property(e => e.Note)
                    .HasMaxLength(20)
                    .HasColumnName("note")
                    .HasComment("備註");

                entity.Property(e => e.PackagingNo)
                    .HasMaxLength(20)
                    .HasColumnName("packaging_no")
                    .HasComment("包裝編號");

                entity.Property(e => e.ProductNo)
                    .HasMaxLength(20)
                    .HasColumnName("product_no")
                    .HasComment("產品料號");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.HasKey(e => e.Sid)
                    .HasName("PRIMARY");

                entity.ToTable("languages");

                entity.Property(e => e.Sid)
                    .HasColumnType("int(11)")
                    .HasColumnName("sid");

                entity.Property(e => e.Cn)
                    .HasMaxLength(500)
                    .HasColumnName("cn")
                    .HasComment("簡體中文");

                entity.Property(e => e.En)
                    .HasMaxLength(500)
                    .HasColumnName("en")
                    .HasComment("英文");

                entity.Property(e => e.Id)
                    .HasMaxLength(500)
                    .HasColumnName("id")
                    .HasComment("印尼");

                entity.Property(e => e.My)
                    .HasMaxLength(500)
                    .HasColumnName("my")
                    .HasComment("馬來西亞");

                entity.Property(e => e.Th)
                    .HasMaxLength(500)
                    .HasColumnName("th")
                    .HasComment("泰國");

                entity.Property(e => e.Tw)
                    .HasMaxLength(500)
                    .HasColumnName("tw")
                    .HasComment("正體中文");
            });

            modelBuilder.Entity<LoginRecord>(entity =>
            {
                entity.ToTable("login_record");

                entity.HasComment("登入紀錄");

                entity.HasIndex(e => e.LoginTime, "login_time");

                entity.HasIndex(e => new { e.MachineId, e.Position, e.Id }, "machine_id_and_position_and_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id")
                    .HasComment("ID");

                entity.Property(e => e.EmployeesId)
                    .HasColumnType("int(11)")
                    .HasColumnName("employees_id")
                    .HasComment("人員id");

                entity.Property(e => e.LoginTime)
                    .HasColumnType("datetime")
                    .HasColumnName("login_time")
                    .HasComment("上線時間");

                entity.Property(e => e.LogoutTime)
                    .HasColumnType("datetime")
                    .HasColumnName("logout_time")
                    .HasComment("離線時間");

                entity.Property(e => e.MachineId)
                    .HasColumnType("int(11)")
                    .HasColumnName("machine_id")
                    .HasComment("機台id");

                entity.Property(e => e.Position)
                    .HasColumnType("enum('操作員','技術員','主管')")
                    .HasColumnName("position")
                    .HasComment("登入身份");

                entity.Property(e => e.Report)
                    .HasMaxLength(255)
                    .HasColumnName("report")
                    .HasDefaultValueSql("''")
                    .HasComment("任務報告");
            });

            modelBuilder.Entity<MachineStatusLog>(entity =>
            {
                entity.ToTable("machine_status_log");

                entity.HasComment("機台狀態歷史");

                entity.HasIndex(e => new { e.MachineId, e.StartTime, e.Id }, "machine_id_and_startTime_and_id");

                entity.HasIndex(e => new { e.MachineId, e.Status, e.StartTime }, "machine_id_and_status_and_startTime");

                entity.HasIndex(e => new { e.StartTime, e.Id }, "startTime_and_id");

                entity.HasIndex(e => e.Status, "state");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.MachineCount)
                    .HasColumnType("int(11)")
                    .HasColumnName("machine_count")
                    .HasComment("機台計數器計數值");

                entity.Property(e => e.MachineId)
                    .HasColumnType("int(11)")
                    .HasColumnName("machine_id")
                    .HasComment("機台id");

                entity.Property(e => e.Note)
                    .HasColumnType("text")
                    .HasColumnName("note")
                    .HasComment("註記");

                entity.Property(e => e.PlcNumber)
                    .HasColumnType("int(11)")
                    .HasColumnName("plc_number")
                    .HasComment("plc計數值");

                entity.Property(e => e.StartTime)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("startTime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("狀態起始時間");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("機台狀態 關機 閒置 維修 生產");

                entity.Property(e => e.VigorplclogId)
                    .HasColumnType("int(11)")
                    .HasColumnName("vigorplclog_id")
                    .HasComment("計數紀錄id");

                entity.Property(e => e.WcId)
                    .HasMaxLength(20)
                    .HasColumnName("wc_id")
                    .HasComment("紀錄時工令");

                entity.Property(e => e.WcdId)
                    .HasColumnType("int(11)")
                    .HasColumnName("wcd_id")
                    .HasComment("工令細項表id");
            });

            modelBuilder.Entity<MachineStatusLogTap>(entity =>
            {
                entity.ToTable("machine_status_log_tap");

                entity.HasComment("機台狀態歷史");

                entity.HasIndex(e => new { e.MachineId, e.StartTime, e.Id }, "machine_id_and_startTime_and_id");

                entity.HasIndex(e => new { e.MachineId, e.Status, e.StartTime }, "machine_id_and_status_and_startTime");

                entity.HasIndex(e => new { e.StartTime, e.Id }, "startTime_and_id");

                entity.HasIndex(e => e.Status, "state");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.MachineCount)
                    .HasColumnType("int(11)")
                    .HasColumnName("machine_count")
                    .HasComment("機台計數器計數值");

                entity.Property(e => e.MachineId)
                    .HasColumnType("int(11)")
                    .HasColumnName("machine_id")
                    .HasComment("攻牙機台id");

                entity.Property(e => e.Note)
                    .HasColumnType("text")
                    .HasColumnName("note")
                    .HasComment("註記");

                entity.Property(e => e.PlcNumber)
                    .HasColumnType("int(11)")
                    .HasColumnName("plc_number")
                    .HasComment("plc計數值");

                entity.Property(e => e.StartTime)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("startTime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("狀態起始時間");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("機台狀態 關機 閒置 維修 生產");

                entity.Property(e => e.VigorplclogId)
                    .HasColumnType("int(11)")
                    .HasColumnName("vigorplclog_id")
                    .HasComment("計數紀錄id");

                entity.Property(e => e.WcId)
                    .HasMaxLength(20)
                    .HasColumnName("wc_id")
                    .HasComment("紀錄時工令");

                entity.Property(e => e.WcdId)
                    .HasColumnType("int(11)")
                    .HasColumnName("wcd_id")
                    .HasComment("工令細項表id");
            });

            modelBuilder.Entity<MachineTable>(entity =>
            {
                entity.ToTable("machine_table");

                entity.HasComment("機台");

                entity.HasIndex(e => e.MachineId, "machine_id")
                    .IsUnique();

                entity.HasIndex(e => e.MachineOrder, "machine_order");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id")
                    .HasComment("id");

                entity.Property(e => e.AlertClearTime)
                    .HasColumnType("datetime")
                    .HasColumnName("alert_clear_time")
                    .HasComment("清除警示時間");

                entity.Property(e => e.AlertClearUser)
                    .HasMaxLength(50)
                    .HasColumnName("alert_clear_user")
                    .HasComment("清除警示之使用者");

                entity.Property(e => e.AlertEnabled)
                    .HasColumnType("tinyint(1) unsigned zerofill")
                    .HasColumnName("alert_enabled")
                    .HasDefaultValueSql("'1'")
                    .HasComment("是否啟用預警通知");

                entity.Property(e => e.AlertMsg)
                    .HasMaxLength(255)
                    .HasColumnName("alert_msg")
                    .HasComment("預警通知訊息");

                entity.Property(e => e.AlertSec)
                    .HasColumnType("int(11)")
                    .HasColumnName("alert_sec")
                    .HasComment("保養預警秒數");

                entity.Property(e => e.Buyintime)
                    .HasColumnName("buyintime")
                    .HasComment("入廠時間");

                entity.Property(e => e.CalcLastStatusLogId)
                    .HasColumnType("int(11)")
                    .HasColumnName("calc_last_status_log_id")
                    .HasComment("計算生產時間最後編號");

                entity.Property(e => e.Fixtime)
                    .HasColumnName("fixtime")
                    .HasComment("維修時間");

                entity.Property(e => e.LastCnt)
                    .HasMaxLength(20)
                    .HasColumnName("last_cnt")
                    .HasComment("最後計數數字");

                entity.Property(e => e.LastStatusLogId)
                    .HasColumnType("int(11)")
                    .HasColumnName("last_status_log_id")
                    .HasComment("清除生產時間最後編號");

                entity.Property(e => e.LastUpdateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("last_update_time")
                    .HasComment("最後計數更新時間");

                entity.Property(e => e.MachineId)
                    .HasMaxLength(10)
                    .HasColumnName("machine_id")
                    .HasComment("機台代號");

                entity.Property(e => e.MachineName)
                    .HasMaxLength(10)
                    .HasColumnName("machine_name")
                    .HasComment("機台名稱");

                entity.Property(e => e.MachineOrder)
                    .HasColumnType("int(11)")
                    .HasColumnName("machine_order")
                    .HasComment("機台排列順序");

                entity.Property(e => e.Maintainer)
                    .HasMaxLength(10)
                    .HasColumnName("maintainer")
                    .HasComment("維護者");

                entity.Property(e => e.Manufactor)
                    .HasMaxLength(20)
                    .HasColumnName("manufactor")
                    .HasComment("製造廠商");

                entity.Property(e => e.Note)
                    .HasMaxLength(50)
                    .HasColumnName("note")
                    .HasComment("備註");

                entity.Property(e => e.OffTimeEnd)
                    .HasColumnType("datetime")
                    .HasColumnName("off_time_end")
                    .HasComment("機台關機結束");

                entity.Property(e => e.OffTimeStart)
                    .HasColumnType("datetime")
                    .HasColumnName("off_time_start")
                    .HasComment("機台關機開始");

                entity.Property(e => e.PlcCnt)
                    .HasColumnType("int(11)")
                    .HasColumnName("plc_cnt")
                    .HasComment("plc計數值");

                entity.Property(e => e.PlcKey)
                    .HasMaxLength(255)
                    .HasColumnName("plc_key")
                    .HasComment("機台連結的plc名稱");

                entity.Property(e => e.ProduceTotalTime)
                    .HasColumnType("int(11)")
                    .HasColumnName("produce_total_time")
                    .HasComment("生產總時間(秒)");

                entity.Property(e => e.Spec)
                    .HasMaxLength(50)
                    .HasColumnName("spec")
                    .HasComment("規格");

                entity.Property(e => e.Status)
                    .HasColumnType("int(11)")
                    .HasColumnName("status")
                    .HasDefaultValueSql("'1'")
                    .HasComment("機台狀態");

                entity.Property(e => e.Unit)
                    .HasMaxLength(10)
                    .HasColumnName("unit")
                    .HasComment("單位");

                entity.Property(e => e.WorkingWc)
                    .HasMaxLength(20)
                    .HasColumnName("working_wc")
                    .HasComment("最後執行的工令");

                entity.Property(e => e.WorkingWcdid)
                    .HasColumnType("int(11)")
                    .HasColumnName("working_wcdid")
                    .HasComment("正在執行workcommand_details_id");
            });

            modelBuilder.Entity<MachineTableTap>(entity =>
            {
                entity.ToTable("machine_table_tap");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id")
                    .HasComment("id");

                entity.Property(e => e.AlertClearTime)
                    .HasColumnType("datetime")
                    .HasColumnName("alert_clear_time")
                    .HasComment("清除警示時間");

                entity.Property(e => e.AlertClearUser)
                    .HasMaxLength(50)
                    .HasColumnName("alert_clear_user")
                    .HasComment("清除警示之使用者");

                entity.Property(e => e.AlertEnabled)
                    .HasColumnName("alert_enabled")
                    .HasDefaultValueSql("'1'")
                    .HasComment("是否啟用預警通知");

                entity.Property(e => e.AlertMsg)
                    .HasMaxLength(255)
                    .HasColumnName("alert_msg")
                    .HasComment("預警通知訊息");

                entity.Property(e => e.AlertSec)
                    .HasColumnType("int(11)")
                    .HasColumnName("alert_sec")
                    .HasComment("保養預警秒數");

                entity.Property(e => e.Buyintime)
                    .HasColumnName("buyintime")
                    .HasComment("入廠時間");

                entity.Property(e => e.CalcLastStatusLogId)
                    .HasColumnType("int(11)")
                    .HasColumnName("calc_last_status_log_id")
                    .HasComment("計算生產時間最後編號");

                entity.Property(e => e.Fixtime)
                    .HasColumnName("fixtime")
                    .HasComment("維修時間");

                entity.Property(e => e.LastCnt)
                    .HasMaxLength(20)
                    .HasColumnName("last_cnt")
                    .HasComment("最後計數數字");

                entity.Property(e => e.LastStatusLogId)
                    .HasColumnType("int(11)")
                    .HasColumnName("last_status_log_id")
                    .HasComment("清除生產時間最後編號");

                entity.Property(e => e.LastUpdateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("last_update_time")
                    .HasComment("最後計數更新時間");

                entity.Property(e => e.MachineId)
                    .HasMaxLength(10)
                    .HasColumnName("machine_id")
                    .HasComment("機台代號");

                entity.Property(e => e.MachineName)
                    .HasMaxLength(10)
                    .HasColumnName("machine_name")
                    .HasComment("機台名稱");

                entity.Property(e => e.MachineOrder)
                    .HasColumnType("int(11)")
                    .HasColumnName("machine_order")
                    .HasComment("機台排列順序");

                entity.Property(e => e.Machinetype)
                    .HasMaxLength(20)
                    .HasColumnName("machinetype")
                    .HasComment("機台類別");

                entity.Property(e => e.Maintainer)
                    .HasMaxLength(10)
                    .HasColumnName("maintainer")
                    .HasComment("維護者");

                entity.Property(e => e.Manufactor)
                    .HasMaxLength(20)
                    .HasColumnName("manufactor")
                    .HasComment("製造廠商");

                entity.Property(e => e.Note)
                    .HasMaxLength(50)
                    .HasColumnName("note")
                    .HasComment("備註");

                entity.Property(e => e.OffTimeEnd)
                    .HasColumnType("datetime")
                    .HasColumnName("off_time_end")
                    .HasComment("機台關機結束");

                entity.Property(e => e.OffTimeStart)
                    .HasColumnType("datetime")
                    .HasColumnName("off_time_start")
                    .HasComment("機台關機開始");

                entity.Property(e => e.PlcCnt)
                    .HasColumnType("int(11)")
                    .HasColumnName("plc_cnt")
                    .HasComment("plc計數值");

                entity.Property(e => e.PlcKey)
                    .HasMaxLength(255)
                    .HasColumnName("plc_key")
                    .HasComment("機台連結的plc名稱");

                entity.Property(e => e.ProduceTotalTime)
                    .HasColumnType("int(11)")
                    .HasColumnName("produce_total_time")
                    .HasComment("生產總時間(秒)");

                entity.Property(e => e.Spec)
                    .HasMaxLength(50)
                    .HasColumnName("spec")
                    .HasComment("規格");

                entity.Property(e => e.Status)
                    .HasColumnType("int(11)")
                    .HasColumnName("status")
                    .HasDefaultValueSql("'1'")
                    .HasComment("機台狀態");

                entity.Property(e => e.Unit)
                    .HasMaxLength(10)
                    .HasColumnName("unit")
                    .HasComment("單位");

                entity.Property(e => e.WorkingWc)
                    .HasMaxLength(20)
                    .HasColumnName("working_wc")
                    .HasComment("最後執行的工令");

                entity.Property(e => e.WorkingWcdid)
                    .HasColumnType("int(11)")
                    .HasColumnName("working_wcdid")
                    .HasComment("正在執行workcommand_details_id");
            });

            modelBuilder.Entity<MachineTableTapProduct>(entity =>
            {
                entity.ToTable("machine_table_tap_product");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id")
                    .HasComment("序號");

                entity.Property(e => e.MachineId)
                    .HasColumnType("int(11)")
                    .HasColumnName("machine_id")
                    .HasComment("機台序號");

                entity.Property(e => e.ProductId)
                    .HasColumnType("int(11)")
                    .HasColumnName("product_id")
                    .HasComment("產品序號");

                entity.Property(e => e.ProductNo)
                    .HasMaxLength(20)
                    .HasColumnName("product_no")
                    .HasComment("產品料號");
            });

            modelBuilder.Entity<MachinesCountLog>(entity =>
            {
                entity.ToTable("machines_count_log");

                entity.HasComment("機台計數紀錄");

                entity.HasIndex(e => new { e.MachineId, e.MachineCount }, "machine_id_and_machine_count")
                    .IsUnique();

                entity.HasIndex(e => new { e.MachineId, e.Time }, "machine_id_and_time");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.MachineCount)
                    .HasColumnType("int(11)")
                    .HasColumnName("machine_count")
                    .HasComment("機台計數器計數值");

                entity.Property(e => e.MachineId)
                    .HasColumnType("int(11)")
                    .HasColumnName("machine_id")
                    .HasComment("機台id");

                entity.Property(e => e.PlcCount)
                    .HasColumnType("int(11)")
                    .HasColumnName("plc_count")
                    .HasComment("plc計數值");

                entity.Property(e => e.Time)
                    .HasColumnType("datetime")
                    .HasColumnName("time")
                    .HasComment("紀錄時間");
            });

            modelBuilder.Entity<MachinesCountLogBackup>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("machines_count_log_backup");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.MachineCount)
                    .HasColumnType("int(11)")
                    .HasColumnName("machine_count")
                    .HasComment("機台計數器計數值");

                entity.Property(e => e.MachineId)
                    .HasColumnType("int(11)")
                    .HasColumnName("machine_id")
                    .HasComment("機台id");

                entity.Property(e => e.PlcCount)
                    .HasColumnType("int(11)")
                    .HasColumnName("plc_count")
                    .HasComment("plc計數值");

                entity.Property(e => e.Time)
                    .HasColumnType("datetime")
                    .HasColumnName("time")
                    .HasComment("紀錄時間");
            });

            modelBuilder.Entity<Machinetype>(entity =>
            {
                entity.ToTable("machinetype");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Createtime)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("createtime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Ord)
                    .HasMaxLength(10)
                    .HasColumnName("ord");

                entity.Property(e => e.Typename)
                    .HasMaxLength(20)
                    .HasColumnName("typename");
            });

            modelBuilder.Entity<MeasuringTool>(entity =>
            {
                entity.ToTable("measuring_tool");

                entity.HasComment("模具代碼");

                entity.HasIndex(e => e.MeasuringToolNo, "product_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.MeasuringToolNo)
                    .HasMaxLength(20)
                    .HasColumnName("measuring_tool_no")
                    .HasComment("量具編號");
            });

            modelBuilder.Entity<Mold>(entity =>
            {
                entity.ToTable("mold");

                entity.HasComment("模具基本資料");

                entity.HasIndex(e => e.MoldNo, "mold_no");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.BaseCount)
                    .HasColumnType("int(11)")
                    .HasColumnName("base_count")
                    .HasComment("模具基本生產量");

                entity.Property(e => e.MoldNo)
                    .HasMaxLength(20)
                    .HasColumnName("mold_no")
                    .HasComment("模具編號");

                entity.Property(e => e.MoldPrice)
                    .HasColumnType("int(11)")
                    .HasColumnName("mold_price")
                    .HasComment("模具價格");
            });

            modelBuilder.Entity<MoldCategory>(entity =>
            {
                entity.ToTable("mold_category");

                entity.HasComment("模具代碼");

                entity.HasIndex(e => e.MoldCategoryNo, "mold_category_no");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.MoldCategoryNo)
                    .HasMaxLength(20)
                    .HasColumnName("mold_category_no")
                    .HasComment("模具編號");

                entity.Property(e => e.Weight)
                    .HasColumnType("int(11)")
                    .HasColumnName("weight")
                    .HasDefaultValueSql("'-1'")
                    .HasComment("權重 越大排越前面 小於0隱藏");
            });

            modelBuilder.Entity<MoldReplaceRecord>(entity =>
            {
                entity.ToTable("mold_replace_record");

                entity.HasComment("模具更換紀錄");

                entity.HasIndex(e => new { e.Account, e.CreateTime }, "account_and_create_time");

                entity.HasIndex(e => e.CreateTime, "create_time");

                entity.HasIndex(e => new { e.MachineId, e.CreateTime }, "machine_id_and_create_time");

                entity.HasIndex(e => new { e.MoldCategoryId, e.MoldId, e.CreateTime },
                    "mold_category_id_and_mold_id_and_create_time");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id")
                    .HasComment("ID");

                entity.Property(e => e.Account)
                    .HasMaxLength(50)
                    .HasColumnName("account")
                    .HasComment("更換人員");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("create_time")
                    .HasComment("更換時間");

                entity.Property(e => e.FixreasonCategory1Id)
                    .HasColumnType("int(20)")
                    .HasColumnName("fixreason_category1_id")
                    .HasComment("模具部位");

                entity.Property(e => e.FixreasonCategory2Id)
                    .HasColumnType("int(20)")
                    .HasColumnName("fixreason_category2_id")
                    .HasComment("造成主因");

                entity.Property(e => e.FixreasonId)
                    .HasColumnType("int(11)")
                    .HasColumnName("fixreason_id")
                    .HasComment("更換原因");

                entity.Property(e => e.MachineCount)
                    .HasColumnType("int(11)")
                    .HasColumnName("machine_count")
                    .HasComment("機台計數器計數值");

                entity.Property(e => e.MachineId)
                    .HasColumnType("int(11)")
                    .HasColumnName("machine_id")
                    .HasComment("機台id");

                entity.Property(e => e.MoldCategoryId)
                    .HasColumnType("int(11)")
                    .HasColumnName("mold_category_id")
                    .HasComment("模具代碼id");

                entity.Property(e => e.MoldId)
                    .HasColumnType("int(11)")
                    .HasColumnName("mold_id")
                    .HasComment("模具編號");

                entity.Property(e => e.MoldPrice)
                    .HasColumnType("int(11)")
                    .HasColumnName("mold_price")
                    .HasComment("模具價格");

                entity.Property(e => e.Note)
                    .HasMaxLength(100)
                    .HasColumnName("note")
                    .HasComment("備註 自主輸入");

                entity.Property(e => e.Photo1)
                    .HasMaxLength(100)
                    .HasColumnName("photo1")
                    .HasComment("拍照1");

                entity.Property(e => e.Photo2)
                    .HasMaxLength(100)
                    .HasColumnName("photo2")
                    .HasComment("拍照2");

                entity.Property(e => e.Photo3)
                    .HasMaxLength(100)
                    .HasColumnName("photo3")
                    .HasComment("拍照3");

                entity.Property(e => e.WcNo)
                    .HasMaxLength(20)
                    .HasColumnName("wc_no")
                    .HasComment("更換時工令");
            });

            modelBuilder.Entity<MoldSpecTable>(entity =>
            {
                entity.ToTable("mold_spec_table");

                entity.HasComment("成型機模具編號表主項目");

                entity.HasIndex(e => new { e.MachineId, e.ProductId }, "machine_id_and_product_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.BaseEff)
                    .HasColumnName("base_eff")
                    .HasDefaultValueSql("'1'")
                    .HasComment("標準生產效率");

                entity.Property(e => e.CustomerMoldId)
                    .HasMaxLength(20)
                    .HasColumnName("customer_mold_id")
                    .HasComment("客戶主圖號");

                entity.Property(e => e.FormNo)
                    .HasMaxLength(20)
                    .HasColumnName("form_no")
                    .HasComment("表單編號");

                entity.Property(e => e.MachineId)
                    .HasColumnType("int(20)")
                    .HasColumnName("machine_id")
                    .HasComment("車型");

                entity.Property(e => e.Note)
                    .HasColumnType("text")
                    .HasColumnName("note")
                    .HasComment("備註");

                entity.Property(e => e.PhotoNote)
                    .HasMaxLength(20)
                    .HasColumnName("photo_note")
                    .HasComment("印記說明");

                entity.Property(e => e.PhotoSop)
                    .HasMaxLength(50)
                    .HasColumnName("photo_sop")
                    .HasComment("印記jpg");

                entity.Property(e => e.ProductId)
                    .HasMaxLength(20)
                    .HasColumnName("product_id")
                    .HasComment("規格");

                entity.Property(e => e.Rotate)
                    .HasMaxLength(10)
                    .HasColumnName("rotate")
                    .HasDefaultValueSql("'0000000000'")
                    .HasComment("轉運說明");

                entity.Property(e => e.Rpm)
                    .HasColumnType("int(11)")
                    .HasColumnName("rpm")
                    .HasComment("產速 每分鐘生產量");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("update_time")
                    .HasComment("更新日期");
            });

            modelBuilder.Entity<MoldSpecTableSheet>(entity =>
            {
                entity.ToTable("mold_spec_table_sheet");

                entity.HasComment("成型機模具編號對應");

                entity.HasIndex(e => e.MoldSpecTableId, "mold_spec_table_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.ExcelRow)
                    .HasMaxLength(20)
                    .HasColumnName("excel_row")
                    .HasComment("Excel列號");

                entity.Property(e => e.MoldCategoryId)
                    .HasMaxLength(20)
                    .HasColumnName("mold_category_id")
                    .HasComment("模具大分類");

                entity.Property(e => e.MoldId)
                    .HasMaxLength(30)
                    .HasColumnName("mold_id")
                    .HasComment("模具小分類");

                entity.Property(e => e.MoldPartId)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("mold_part_id")
                    .HasComment("模具部位id");

                entity.Property(e => e.MoldSpecTableId)
                    .HasColumnType("int(11)")
                    .HasColumnName("mold_spec_table_id")
                    .HasComment("成型機模具編號表id");

                entity.Property(e => e.Note)
                    .HasMaxLength(100)
                    .HasColumnName("note")
                    .HasComment("備註");
            });

            modelBuilder.Entity<MoldUseLog>(entity =>
            {
                entity.ToTable("mold_use_log");

                entity.HasComment("模具使用紀錄");

                entity.HasIndex(e => e.EndTime, "end_time");

                entity.HasIndex(e => e.MoldCategoryId, "mold_category_id");

                entity.HasIndex(e => new { e.MoldId, e.MoldCategoryId, e.MachineId, e.EndTime },
                    "mold_id_and_mold_category_id_and_machine_id_and_end_time");

                entity.HasIndex(e => e.MoldReplaceRecordId, "mold_replace_record_id");

                entity.HasIndex(e => e.StartTime, "start_time");

                entity.HasIndex(e => e.TotalGroupId, "total_group_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Account)
                    .HasMaxLength(255)
                    .HasColumnName("account")
                    .HasDefaultValueSql("''")
                    .HasComment("使用者帳號");

                entity.Property(e => e.EndCount)
                    .HasColumnType("int(11)")
                    .HasColumnName("end_count")
                    .HasComment("結束時計數值");

                entity.Property(e => e.EndTime)
                    .HasColumnType("datetime")
                    .HasColumnName("end_time")
                    .HasComment("結束時間");

                entity.Property(e => e.MachineId)
                    .HasColumnType("int(11)")
                    .HasColumnName("machine_id")
                    .HasComment("機台id");

                entity.Property(e => e.MoldCategoryId)
                    .HasColumnType("int(11)")
                    .HasColumnName("mold_category_id")
                    .HasComment("模具代碼id");

                entity.Property(e => e.MoldId)
                    .HasColumnType("int(11)")
                    .HasColumnName("mold_id")
                    .HasComment("模具編號id");

                entity.Property(e => e.MoldReplaceRecordId)
                    .HasColumnType("int(11)")
                    .HasColumnName("mold_replace_record_id")
                    .HasComment("模具更換紀錄id");

                entity.Property(e => e.Note)
                    .HasMaxLength(100)
                    .HasColumnName("note")
                    .HasComment("備註");

                entity.Property(e => e.StartCount)
                    .HasColumnType("int(11)")
                    .HasColumnName("start_count")
                    .HasComment("起始時計數值");

                entity.Property(e => e.StartTime)
                    .HasColumnType("datetime")
                    .HasColumnName("start_time")
                    .HasComment("起始時間");

                entity.Property(e => e.TotalGroupId)
                    .HasColumnType("int(11)")
                    .HasColumnName("total_group_id")
                    .HasComment("統計分組 第一筆資料的id");

                entity.Property(e => e.WcNo)
                    .HasMaxLength(20)
                    .HasColumnName("wc_no")
                    .HasComment("使用時工令");
            });

            modelBuilder.Entity<MoldUseTotal>(entity =>
            {
                entity.ToTable("mold_use_total");

                entity.HasComment("模具使用統計");

                entity.HasIndex(e => e.EndTime, "end_time");

                entity.HasIndex(e => e.MoldCategoryId, "mold_category_id");

                entity.HasIndex(e => new { e.MoldId, e.MoldCategoryId, e.MachineId, e.EndTime },
                    "mold_id_and_mold_category_id_and_machine_id_and_end_time");

                entity.HasIndex(e => e.MoldReplaceRecordId, "mold_replace_record_id");

                entity.HasIndex(e => e.StartTime, "start_time");

                entity.HasIndex(e => e.TotalGroupId, "total_group_id")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.EndTime)
                    .HasColumnType("datetime")
                    .HasColumnName("end_time")
                    .HasComment("結束時間");

                entity.Property(e => e.MachineId)
                    .HasColumnType("int(11)")
                    .HasColumnName("machine_id")
                    .HasComment("機台id");

                entity.Property(e => e.MoldCategoryId)
                    .HasColumnType("int(11)")
                    .HasColumnName("mold_category_id")
                    .HasComment("模具代碼id");

                entity.Property(e => e.MoldId)
                    .HasColumnType("int(11)")
                    .HasColumnName("mold_id")
                    .HasComment("模具編號id");

                entity.Property(e => e.MoldReplaceRecordId)
                    .HasColumnType("int(11)")
                    .HasColumnName("mold_replace_record_id")
                    .HasComment("模具更換紀錄id");

                entity.Property(e => e.StartTime)
                    .HasColumnType("datetime")
                    .HasColumnName("start_time")
                    .HasComment("起始時間");

                entity.Property(e => e.TotalGroupId)
                    .HasColumnType("int(11)")
                    .HasColumnName("total_group_id")
                    .HasComment("統計分組");

                entity.Property(e => e.TotalUseCount)
                    .HasColumnType("int(11)")
                    .HasColumnName("total_use_count")
                    .HasComment("總使用計數");

                entity.Property(e => e.TotalUseTime)
                    .HasColumnType("int(11)")
                    .HasColumnName("total_use_time")
                    .HasComment("總使用時間 秒");
            });

            modelBuilder.Entity<PackagingDetail>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.PackagingId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("packaging_detail");

                entity.HasIndex(e => e.PackagingId, "fk");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id")
                    .HasComment("序號");

                entity.Property(e => e.PackagingId)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("packaging_id");

                entity.Property(e => e.BoxNumber)
                    .HasMaxLength(50)
                    .HasColumnName("box_number")
                    .HasComment("箱號");

                entity.Property(e => e.BucketNumbers)
                    .HasMaxLength(50)
                    .HasColumnName("bucket_numbers")
                    .HasComment("桶數(多數使用，分隔)");

                entity.Property(e => e.Note)
                    .HasMaxLength(50)
                    .HasColumnName("note")
                    .HasComment("備註");

                entity.Property(e => e.PackagingNo)
                    .HasMaxLength(20)
                    .HasColumnName("packaging_no")
                    .HasComment("包裝編號");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .HasColumnName("product_name")
                    .HasComment("規格");

                entity.Property(e => e.ProductNo)
                    .HasMaxLength(20)
                    .HasColumnName("product_no")
                    .HasComment("產品料號");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasColumnName("status")
                    .HasComment("狀態");

                entity.Property(e => e.WorkNo)
                    .HasMaxLength(30)
                    .HasColumnName("work_no")
                    .HasComment("製令編號");

                entity.HasOne(d => d.Packaging)
                    .WithMany(p => p.PackagingDetails)
                    .HasForeignKey(d => d.PackagingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk");
            });

            modelBuilder.Entity<PackagingRecord>(entity =>
            {
                entity.ToTable("packaging_record");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id")
                    .HasComment("序號");

                entity.Property(e => e.BoxCnt)
                    .HasColumnType("int(11)")
                    .HasColumnName("box_cnt")
                    .HasComment("箱數");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("create_time")
                    .HasComment("建立時間");

                entity.Property(e => e.Creater)
                    .HasMaxLength(50)
                    .HasColumnName("creater")
                    .HasComment("建立者");

                entity.Property(e => e.CreaterId)
                    .HasColumnType("mediumint(9)")
                    .HasColumnName("creater_id")
                    .HasComment("建立者序號");

                entity.Property(e => e.Note)
                    .HasMaxLength(100)
                    .HasColumnName("note")
                    .HasComment("備註");

                entity.Property(e => e.PackagingNo)
                    .HasMaxLength(20)
                    .HasColumnName("packaging_no")
                    .HasComment("包裝編號");

                entity.Property(e => e.Status)
                    .HasMaxLength(2)
                    .HasColumnName("status")
                    .HasComment("狀態  0-已入庫、1-已入ERP、2-已刪除");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("update_time")
                    .HasComment("更新時間");

                entity.Property(e => e.Updater)
                    .HasMaxLength(50)
                    .HasColumnName("updater")
                    .HasComment("更新者");

                entity.Property(e => e.UpdaterId)
                    .HasColumnType("mediumint(9)")
                    .HasColumnName("updater_id")
                    .HasComment("更新者序號");
            });

            modelBuilder.Entity<Precaution>(entity =>
            {
                entity.ToTable("precautions");

                entity.HasComment("注意事項");

                entity.HasIndex(e => e.DiscontinuedTime, "discontinued_time");

                entity.HasIndex(e => e.MachineId, "machine_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id")
                    .HasComment("id");

                entity.Property(e => e.Content)
                    .HasMaxLength(100)
                    .HasColumnName("content")
                    .HasComment("內容");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("create_time")
                    .HasComment("填寫時間");

                entity.Property(e => e.Creator)
                    .HasColumnType("int(11)")
                    .HasColumnName("creator")
                    .HasComment("填寫人員工id");

                entity.Property(e => e.DiscontinuedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("discontinued_time")
                    .HasComment("下架時間");

                entity.Property(e => e.MachineId)
                    .HasColumnType("int(11)")
                    .HasColumnName("machine_id")
                    .HasComment("針對機台 未設為所有機台");

                entity.Property(e => e.Note)
                    .HasMaxLength(100)
                    .HasColumnName("note")
                    .HasComment("備註");
            });

            modelBuilder.Entity<ProductTable>(entity =>
            {
                entity.ToTable("product_table");

                entity.HasComment("產品資料表");

                entity.HasIndex(e => e.ProductNo, "product_no");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(20)
                    .HasColumnName("customer_name")
                    .HasComment("客戶");

                entity.Property(e => e.HeatTreatment)
                    .HasMaxLength(20)
                    .HasColumnName("heat_treatment")
                    .HasComment("熱處理");

                entity.Property(e => e.MachineType)
                    .HasMaxLength(20)
                    .HasColumnName("machine_type")
                    .HasComment("車型類型");

                entity.Property(e => e.Material)
                    .HasMaxLength(50)
                    .HasColumnName("material")
                    .HasComment("材質");

                entity.Property(e => e.MaterialHeavy)
                    .HasMaxLength(20)
                    .HasColumnName("material_heavy")
                    .HasComment("材料重");

                entity.Property(e => e.NoToothHeavy)
                    .HasMaxLength(20)
                    .HasColumnName("no_tooth_heavy")
                    .HasComment("未攻牙重");

                entity.Property(e => e.Note)
                    .HasMaxLength(100)
                    .HasColumnName("note")
                    .HasComment("備註");

                entity.Property(e => e.OutsourcingProduce)
                    .HasMaxLength(20)
                    .HasColumnName("outsourcing_produce")
                    .HasComment("委外生產");

                entity.Property(e => e.OutsourcingTapping)
                    .HasMaxLength(20)
                    .HasColumnName("outsourcing_tapping")
                    .HasComment("委外攻牙");

                entity.Property(e => e.PressedNylonRing)
                    .HasMaxLength(20)
                    .HasColumnName("pressed_nylon_ring")
                    .HasComment("壓尼龍圈");

                entity.Property(e => e.ProductIso)
                    .HasMaxLength(20)
                    .HasColumnName("product_iso")
                    .HasComment("產品序號");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .HasColumnName("product_name")
                    .HasComment("規格");

                entity.Property(e => e.ProductNo)
                    .HasMaxLength(20)
                    .HasColumnName("product_no")
                    .HasComment("產品料號");

                entity.Property(e => e.ProductSop)
                    .HasMaxLength(50)
                    .HasColumnName("product_sop")
                    .HasComment("客戶主圖號");

                entity.Property(e => e.Radius)
                    .HasMaxLength(20)
                    .HasColumnName("radius")
                    .HasComment("線徑");

                entity.Property(e => e.Ratchet)
                    .HasMaxLength(20)
                    .HasColumnName("ratchet")
                    .HasComment("棘輪");

                entity.Property(e => e.Size)
                    .HasMaxLength(50)
                    .HasColumnName("size")
                    .HasComment("尺寸規格");

                entity.Property(e => e.StockQty)
                    .HasColumnType("int(11)")
                    .HasColumnName("stock_qty")
                    .HasDefaultValueSql("'0'")
                    .HasComment("即時庫存數(箱數)");

                entity.Property(e => e.ToothHeavy)
                    .HasMaxLength(30)
                    .HasColumnName("tooth_heavy")
                    .HasComment("攻牙重");

                entity.Property(e => e.ToothLevel)
                    .HasMaxLength(20)
                    .HasColumnName("tooth_level")
                    .HasComment("牙級");

                entity.Property(e => e.UnitHeavy)
                    .HasMaxLength(20)
                    .HasColumnName("unit_heavy")
                    .HasComment("單位重");
            });

            modelBuilder.Entity<ShiftTable>(entity =>
            {
                entity.ToTable("shift_table");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Time)
                    .HasMaxLength(2)
                    .HasColumnName("time")
                    .IsFixedLength();
            });

            modelBuilder.Entity<SystemParameter>(entity =>
            {
                entity.ToTable("system_parameter");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.ParameterName)
                    .HasMaxLength(50)
                    .HasColumnName("parameter_name")
                    .HasComment("參數中文名");

                entity.Property(e => e.ParameterNo)
                    .HasMaxLength(30)
                    .HasColumnName("parameter_no")
                    .HasComment("參數簡稱");

                entity.Property(e => e.ParameterValue)
                    .HasMaxLength(20)
                    .HasColumnName("parameter_value")
                    .HasComment("參數值");
            });

            modelBuilder.Entity<UserDevice>(entity =>
            {
                entity.ToTable("user_device");

                entity.HasIndex(e => e.MachineId, "account");

                entity.HasIndex(e => e.AppId, "app_id");

                entity.HasIndex(e => e.DeviceId, "device_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.AppId)
                    .HasMaxLength(300)
                    .HasColumnName("app_id")
                    .HasComment("APP推播識別ID");

                entity.Property(e => e.DeviceId)
                    .HasMaxLength(50)
                    .HasColumnName("device_id")
                    .HasComment("裝置");

                entity.Property(e => e.DeviceName)
                    .HasMaxLength(50)
                    .HasColumnName("device_name")
                    .HasComment("裝置名稱");

                entity.Property(e => e.DeviceOs)
                    .HasMaxLength(20)
                    .HasColumnName("device_os");

                entity.Property(e => e.Issend)
                    .HasColumnType("int(11)")
                    .HasColumnName("issend")
                    .HasDefaultValueSql("'1'")
                    .HasComment("是否send訊息");

                entity.Property(e => e.MachineId)
                    .HasColumnType("int(11)")
                    .HasColumnName("machine_id")
                    .HasComment("機台編號");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("update_time")
                    .HasComment("更新時間");
            });

            modelBuilder.Entity<Vigorplclog>(entity =>
            {
                entity.ToTable("vigorplclog");

                entity.HasIndex(e => e.Createtime, "createtime");

                entity.HasIndex(e => new { e.PlcName, e.Createtime }, "plc_name_and_createtime");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Createtime)
                    .HasColumnType("datetime")
                    .HasColumnName("createtime")
                    .HasComment("新增時間");

                entity.Property(e => e.Mc1)
                    .HasMaxLength(10)
                    .HasColumnName("mc1");

                entity.Property(e => e.Mc10)
                    .HasMaxLength(10)
                    .HasColumnName("mc10");

                entity.Property(e => e.Mc11)
                    .HasMaxLength(10)
                    .HasColumnName("mc11");

                entity.Property(e => e.Mc12)
                    .HasMaxLength(10)
                    .HasColumnName("mc12");

                entity.Property(e => e.Mc13)
                    .HasMaxLength(10)
                    .HasColumnName("mc13");

                entity.Property(e => e.Mc14)
                    .HasMaxLength(10)
                    .HasColumnName("mc14");

                entity.Property(e => e.Mc15)
                    .HasMaxLength(10)
                    .HasColumnName("mc15");

                entity.Property(e => e.Mc16)
                    .HasMaxLength(10)
                    .HasColumnName("mc16");

                entity.Property(e => e.Mc17)
                    .HasMaxLength(10)
                    .HasColumnName("mc17");

                entity.Property(e => e.Mc18)
                    .HasMaxLength(10)
                    .HasColumnName("mc18");

                entity.Property(e => e.Mc19)
                    .HasMaxLength(10)
                    .HasColumnName("mc19");

                entity.Property(e => e.Mc2)
                    .HasMaxLength(10)
                    .HasColumnName("mc2");

                entity.Property(e => e.Mc20)
                    .HasMaxLength(10)
                    .HasColumnName("mc20");

                entity.Property(e => e.Mc3)
                    .HasMaxLength(10)
                    .HasColumnName("mc3");

                entity.Property(e => e.Mc4)
                    .HasMaxLength(10)
                    .HasColumnName("mc4");

                entity.Property(e => e.Mc5)
                    .HasMaxLength(10)
                    .HasColumnName("mc5");

                entity.Property(e => e.Mc6)
                    .HasMaxLength(10)
                    .HasColumnName("mc6");

                entity.Property(e => e.Mc7)
                    .HasMaxLength(10)
                    .HasColumnName("mc7");

                entity.Property(e => e.Mc8)
                    .HasMaxLength(10)
                    .HasColumnName("mc8");

                entity.Property(e => e.Mc9)
                    .HasMaxLength(10)
                    .HasColumnName("mc9");

                entity.Property(e => e.PlcName)
                    .HasMaxLength(10)
                    .HasColumnName("plc_name")
                    .HasComment("PLC名稱");
            });

            modelBuilder.Entity<Vigorplclog2021>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("vigorplclog_2021");

                entity.Property(e => e.Createtime)
                    .HasColumnType("datetime")
                    .HasColumnName("createtime")
                    .HasComment("新增時間");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Mc1)
                    .HasMaxLength(10)
                    .HasColumnName("mc1");

                entity.Property(e => e.Mc10)
                    .HasMaxLength(10)
                    .HasColumnName("mc10");

                entity.Property(e => e.Mc11)
                    .HasMaxLength(10)
                    .HasColumnName("mc11");

                entity.Property(e => e.Mc12)
                    .HasMaxLength(10)
                    .HasColumnName("mc12");

                entity.Property(e => e.Mc13)
                    .HasMaxLength(10)
                    .HasColumnName("mc13");

                entity.Property(e => e.Mc14)
                    .HasMaxLength(10)
                    .HasColumnName("mc14");

                entity.Property(e => e.Mc15)
                    .HasMaxLength(10)
                    .HasColumnName("mc15");

                entity.Property(e => e.Mc16)
                    .HasMaxLength(10)
                    .HasColumnName("mc16");

                entity.Property(e => e.Mc17)
                    .HasMaxLength(10)
                    .HasColumnName("mc17");

                entity.Property(e => e.Mc18)
                    .HasMaxLength(10)
                    .HasColumnName("mc18");

                entity.Property(e => e.Mc19)
                    .HasMaxLength(10)
                    .HasColumnName("mc19");

                entity.Property(e => e.Mc2)
                    .HasMaxLength(10)
                    .HasColumnName("mc2");

                entity.Property(e => e.Mc20)
                    .HasMaxLength(10)
                    .HasColumnName("mc20");

                entity.Property(e => e.Mc3)
                    .HasMaxLength(10)
                    .HasColumnName("mc3");

                entity.Property(e => e.Mc4)
                    .HasMaxLength(10)
                    .HasColumnName("mc4");

                entity.Property(e => e.Mc5)
                    .HasMaxLength(10)
                    .HasColumnName("mc5");

                entity.Property(e => e.Mc6)
                    .HasMaxLength(10)
                    .HasColumnName("mc6");

                entity.Property(e => e.Mc7)
                    .HasMaxLength(10)
                    .HasColumnName("mc7");

                entity.Property(e => e.Mc8)
                    .HasMaxLength(10)
                    .HasColumnName("mc8");

                entity.Property(e => e.Mc9)
                    .HasMaxLength(10)
                    .HasColumnName("mc9");

                entity.Property(e => e.PlcName)
                    .HasMaxLength(10)
                    .HasColumnName("plc_name")
                    .HasComment("PLC名稱");
            });

            modelBuilder.Entity<VigorplclogBackup>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("vigorplclog_backup");

                entity.Property(e => e.Createtime)
                    .HasColumnType("datetime")
                    .HasColumnName("createtime")
                    .HasComment("新增時間");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Mc1)
                    .HasMaxLength(10)
                    .HasColumnName("mc1");

                entity.Property(e => e.Mc10)
                    .HasMaxLength(10)
                    .HasColumnName("mc10");

                entity.Property(e => e.Mc11)
                    .HasMaxLength(10)
                    .HasColumnName("mc11");

                entity.Property(e => e.Mc12)
                    .HasMaxLength(10)
                    .HasColumnName("mc12");

                entity.Property(e => e.Mc13)
                    .HasMaxLength(10)
                    .HasColumnName("mc13");

                entity.Property(e => e.Mc14)
                    .HasMaxLength(10)
                    .HasColumnName("mc14");

                entity.Property(e => e.Mc15)
                    .HasMaxLength(10)
                    .HasColumnName("mc15");

                entity.Property(e => e.Mc16)
                    .HasMaxLength(10)
                    .HasColumnName("mc16");

                entity.Property(e => e.Mc17)
                    .HasMaxLength(10)
                    .HasColumnName("mc17");

                entity.Property(e => e.Mc18)
                    .HasMaxLength(10)
                    .HasColumnName("mc18");

                entity.Property(e => e.Mc19)
                    .HasMaxLength(10)
                    .HasColumnName("mc19");

                entity.Property(e => e.Mc2)
                    .HasMaxLength(10)
                    .HasColumnName("mc2");

                entity.Property(e => e.Mc20)
                    .HasMaxLength(10)
                    .HasColumnName("mc20");

                entity.Property(e => e.Mc3)
                    .HasMaxLength(10)
                    .HasColumnName("mc3");

                entity.Property(e => e.Mc4)
                    .HasMaxLength(10)
                    .HasColumnName("mc4");

                entity.Property(e => e.Mc5)
                    .HasMaxLength(10)
                    .HasColumnName("mc5");

                entity.Property(e => e.Mc6)
                    .HasMaxLength(10)
                    .HasColumnName("mc6");

                entity.Property(e => e.Mc7)
                    .HasMaxLength(10)
                    .HasColumnName("mc7");

                entity.Property(e => e.Mc8)
                    .HasMaxLength(10)
                    .HasColumnName("mc8");

                entity.Property(e => e.Mc9)
                    .HasMaxLength(10)
                    .HasColumnName("mc9");

                entity.Property(e => e.PlcName)
                    .HasMaxLength(10)
                    .HasColumnName("plc_name")
                    .HasComment("PLC名稱");
            });

            modelBuilder.Entity<VigorplclogTap>(entity =>
            {
                entity.ToTable("vigorplclog_tap");

                entity.HasIndex(e => e.Createtime, "createtime");

                entity.HasIndex(e => new { e.PlcName, e.Createtime }, "plc_name_and_createtime");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Createtime)
                    .HasColumnType("datetime")
                    .HasColumnName("createtime")
                    .HasComment("新增時間");

                entity.Property(e => e.JsonData)
                    .HasColumnType("json")
                    .HasColumnName("json_data")
                    .HasComment("PLC資料");

                entity.Property(e => e.PlcName)
                    .HasMaxLength(10)
                    .HasColumnName("plc_name")
                    .HasComment("PLC名稱");
            });

            modelBuilder.Entity<WorkOrder>(entity =>
            {
                entity.ToTable("work_order");

                entity.HasComment("工單");

                entity.HasIndex(e => e.WorkNo, "work_no");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id")
                    .HasComment("序號");

                entity.Property(e => e.ConfirmDate)
                    .HasColumnName("confirm_date")
                    .HasComment("確認日期");

                entity.Property(e => e.Createtime)
                    .HasColumnType("datetime")
                    .HasColumnName("createtime")
                    .HasComment("上傳時間");

                entity.Property(e => e.Customer)
                    .HasMaxLength(50)
                    .HasColumnName("customer")
                    .HasComment("客戶簡稱");

                entity.Property(e => e.CustomerSheet)
                    .HasMaxLength(50)
                    .HasColumnName("customer_sheet")
                    .HasComment("客戶單號");

                entity.Property(e => e.DelFlag)
                    .HasMaxLength(1)
                    .HasColumnName("del_flag")
                    .IsFixedLength();

                entity.Property(e => e.DispatchQty)
                    .HasColumnType("int(11)")
                    .HasColumnName("dispatch_qty");

                entity.Property(e => e.EmployerNo)
                    .HasMaxLength(50)
                    .HasColumnName("employer_no")
                    .HasComment("發包單號");

                entity.Property(e => e.ExpectedDate)
                    .HasColumnName("expected_date")
                    .HasComment("預計完工");

                entity.Property(e => e.ExpectedQty)
                    .HasColumnType("int(11)")
                    .HasColumnName("expected_qty")
                    .HasComment("預計產量");

                entity.Property(e => e.GiftQty)
                    .HasColumnType("int(11)")
                    .HasColumnName("gift_qty")
                    .HasComment("贈品量");

                entity.Property(e => e.IsClosed)
                    .HasColumnName("is_closed")
                    .HasComment("是否結案");

                entity.Property(e => e.Material)
                    .HasMaxLength(50)
                    .HasColumnName("material")
                    .HasComment("材質");

                entity.Property(e => e.MoldNo)
                    .HasMaxLength(50)
                    .HasColumnName("mold_no")
                    .HasComment("模具號碼");

                entity.Property(e => e.Note)
                    .HasMaxLength(50)
                    .HasColumnName("note")
                    .HasComment("備註");

                entity.Property(e => e.OrderNo)
                    .HasMaxLength(50)
                    .HasColumnName("order_no")
                    .HasComment("訂單單號");

                entity.Property(e => e.OrderQty)
                    .HasColumnType("int(11)")
                    .HasColumnName("order_qty")
                    .HasComment("訂單數量");

                entity.Property(e => e.OrderUnit)
                    .HasMaxLength(50)
                    .HasColumnName("order_unit")
                    .HasComment("單位");

                entity.Property(e => e.ProductId)
                    .HasMaxLength(50)
                    .HasColumnName("product_id")
                    .HasComment("產品品號");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .HasColumnName("product_name")
                    .HasComment("品名");

                entity.Property(e => e.ProductionQty)
                    .HasColumnType("int(11)")
                    .HasColumnName("production_qty")
                    .HasComment("已生產量");

                entity.Property(e => e.SeqNo)
                    .HasColumnType("int(11)")
                    .HasColumnName("seq_no");

                entity.Property(e => e.Spec)
                    .HasMaxLength(50)
                    .HasColumnName("spec")
                    .HasComment("規格");

                entity.Property(e => e.Vendor)
                    .HasMaxLength(50)
                    .HasColumnName("vendor")
                    .HasComment("廠商名稱");

                entity.Property(e => e.WorkNo)
                    .HasMaxLength(50)
                    .HasColumnName("work_no")
                    .HasComment("製令編號");

                entity.Property(e => e.WorkNoN)
                    .HasMaxLength(50)
                    .HasColumnName("work_no_n")
                    .HasComment("合併製令編號");
            });

            modelBuilder.Entity<Workcommand>(entity =>
            {
                entity.ToTable("workcommand");

                entity.HasComment("工令主檔");

                entity.HasIndex(e => e.Enddate, "enddate");

                entity.HasIndex(e => e.MachineId, "machine_id");

                entity.HasIndex(e => e.Startdate, "startdate");

                entity.HasIndex(e => e.WorkNo, "work_number");

                entity.HasIndex(e => e.WorkcommandId, "workcommand_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id")
                    .HasComment("序號");

                entity.Property(e => e.CalculateNote)
                    .HasMaxLength(100)
                    .HasColumnName("calculate_note")
                    .HasComment("計算過程");

                entity.Property(e => e.Createtime)
                    .HasColumnType("datetime")
                    .HasColumnName("createtime");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("enddate");

                entity.Property(e => e.ExpectedEnddate)
                    .HasColumnType("datetime")
                    .HasColumnName("expected_enddate")
                    .HasComment("預計完工");

                entity.Property(e => e.ExpectedQty)
                    .HasColumnType("int(11)")
                    .HasColumnName("expected_qty")
                    .HasComment("預計產量(M)");

                entity.Property(e => e.ExpectedStartdate)
                    .HasColumnType("datetime")
                    .HasColumnName("expected_startdate")
                    .HasComment("預計開工");

                entity.Property(e => e.MachineId)
                    .HasColumnType("int(11)")
                    .HasColumnName("machine_id")
                    .HasComment("機台代號");

                entity.Property(e => e.MoldCount)
                    .HasColumnType("int(11)")
                    .HasColumnName("mold_count")
                    .HasDefaultValueSql("'0'")
                    .HasComment("模數");

                entity.Property(e => e.MoldNo)
                    .HasMaxLength(50)
                    .HasColumnName("mold_no");

                entity.Property(e => e.Mtime)
                    .HasColumnType("datetime")
                    .HasColumnName("mtime");

                entity.Property(e => e.Ng)
                    .HasColumnType("int(11)")
                    .HasColumnName("ng")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Note)
                    .HasMaxLength(50)
                    .HasColumnName("note")
                    .HasComment("備註");

                entity.Property(e => e.Ok)
                    .HasColumnType("int(11)")
                    .HasColumnName("ok")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.OrderNo)
                    .HasMaxLength(50)
                    .HasColumnName("order_no");

                entity.Property(e => e.PlcId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("plc_id")
                    .HasComment("ADC");

                entity.Property(e => e.PlineId)
                    .HasMaxLength(50)
                    .HasColumnName("pline_id")
                    .HasComment("線別代號");

                entity.Property(e => e.ProduceSpeed)
                    .HasMaxLength(10)
                    .HasColumnName("produce_speed")
                    .HasComment("產速");

                entity.Property(e => e.ProductId)
                    .HasMaxLength(50)
                    .HasColumnName("product_id")
                    .HasComment("產品代號");

                entity.Property(e => e.ProductionQty)
                    .HasColumnType("int(11)")
                    .HasColumnName("production_qty")
                    .HasComment("已生產量(M)");

                entity.Property(e => e.PutIn)
                    .HasColumnType("int(11)")
                    .HasColumnName("put_in")
                    .HasComment("派工量");

                entity.Property(e => e.SampleReceipt)
                    .HasColumnType("int(2)")
                    .HasColumnName("sample_receipt")
                    .HasDefaultValueSql("'0'")
                    .HasComment("0為量產單，1為打樣單");

                entity.Property(e => e.SeqNo)
                    .HasColumnType("int(11)")
                    .HasColumnName("seq_no")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Shift)
                    .HasMaxLength(1)
                    .HasColumnName("shift")
                    .IsFixedLength()
                    .HasComment("班別");

                entity.Property(e => e.Startdate)
                    .HasColumnType("datetime")
                    .HasColumnName("startdate")
                    .HasComment("開工時間");

                entity.Property(e => e.Status)
                    .HasColumnType("int(11)")
                    .HasColumnName("status")
                    .HasDefaultValueSql("'0'")
                    .HasComment("0:未完成, 1:已完成, 2:取消");

                entity.Property(e => e.Total)
                    .HasColumnType("int(11)")
                    .HasColumnName("total")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Units)
                    .HasMaxLength(20)
                    .HasColumnName("units")
                    .HasComment("派工單位(1:雙 2:片 3:模)");

                entity.Property(e => e.WorkNo)
                    .HasMaxLength(50)
                    .HasColumnName("work_no")
                    .HasComment("工單");

                entity.Property(e => e.WorkcommandId)
                    .HasMaxLength(50)
                    .HasColumnName("workcommand_id")
                    .HasComment("工令");

                entity.Property(e => e.ErpTzNo)
                    .HasMaxLength(20)
                    .HasColumnName("erp_tz_no")
                    .HasComment("ERP通知單號");

                entity.Property(e => e.ErpTzDd)
                    .HasColumnType("datetime")
                    .HasColumnName("erp_tz_dd")
                    .HasComment("ERP通知單日期");
            });

            modelBuilder.Entity<WorkcommandDetail>(entity =>
            {
                entity.ToTable("workcommand_details");

                entity.HasComment("工令明細檔");

                entity.HasIndex(e => new { e.Startdate, e.Enddate }, "dates");

                entity.HasIndex(e => e.Enddate, "enddate");

                entity.HasIndex(e => e.NgCnt, "ng_cnt");

                entity.HasIndex(e => e.MachineId, "productionlinesid");

                entity.HasIndex(e => new { e.Status, e.Isok }, "realtime_group_index1");

                entity.HasIndex(e => new { e.WorkcommandId, e.SeqNo, e.PlineId, e.MachineId, e.Startdate }, "uid")
                    .IsUnique();

                entity.HasIndex(e => e.WorkcommandId, "workcommand_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(12) unsigned")
                    .HasColumnName("id")
                    .HasComment("序號");

                entity.Property(e => e.Eid1)
                    .HasMaxLength(20)
                    .HasColumnName("eid1")
                    .HasComment("操作員帳號");

                entity.Property(e => e.Eid2)
                    .HasMaxLength(20)
                    .HasColumnName("eid2");

                entity.Property(e => e.EndCnt)
                    .HasColumnType("int(11)")
                    .HasColumnName("end_cnt")
                    .HasComment("生產總數量");

                entity.Property(e => e.EndNgCnt)
                    .HasColumnType("int(11)")
                    .HasColumnName("end_ng_cnt");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("enddate")
                    .HasComment("結束時間");

                entity.Property(e => e.Isok)
                    .HasColumnType("int(1)")
                    .HasColumnName("isok");

                entity.Property(e => e.MachineId)
                    .HasMaxLength(20)
                    .HasColumnName("machine_id")
                    .HasComment("機台");

                entity.Property(e => e.Ncode)
                    .HasMaxLength(10)
                    .HasColumnName("ncode")
                    .HasComment("未稼動");

                entity.Property(e => e.NgCnt)
                    .HasColumnType("int(11)")
                    .HasColumnName("ng_cnt");

                entity.Property(e => e.OkCnt)
                    .HasColumnType("int(11)")
                    .HasColumnName("ok_cnt");

                entity.Property(e => e.Perno)
                    .HasMaxLength(10)
                    .HasColumnName("perno")
                    .HasComment("員工");

                entity.Property(e => e.PlineId)
                    .HasMaxLength(30)
                    .HasColumnName("pline_id")
                    .HasComment("線別");

                entity.Property(e => e.SeqNo)
                    .HasColumnType("int(11)")
                    .HasColumnName("seq_no");

                entity.Property(e => e.Shift1)
                    .HasMaxLength(1)
                    .HasColumnName("shift1")
                    .IsFixedLength();

                entity.Property(e => e.Shift2)
                    .HasMaxLength(1)
                    .HasColumnName("shift2")
                    .IsFixedLength();

                entity.Property(e => e.StartCnt)
                    .HasColumnType("int(11)")
                    .HasColumnName("start_cnt");

                entity.Property(e => e.StartNgCnt)
                    .HasColumnType("int(11)")
                    .HasColumnName("start_ng_cnt");

                entity.Property(e => e.Startdate)
                    .HasColumnType("datetime")
                    .HasColumnName("startdate")
                    .HasComment("開始時間");

                entity.Property(e => e.Status)
                    .HasMaxLength(2)
                    .HasColumnName("status")
                    .IsFixedLength()
                    .HasComment("狀態");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("update_time")
                    .HasComment("更新時間");

                entity.Property(e => e.WorkcommandId)
                    .HasMaxLength(20)
                    .HasColumnName("workcommand_id")
                    .HasDefaultValueSql("'0'")
                    .HasComment("工令");
            });

            modelBuilder.Entity<WorkcommandDetailsTap>(entity =>
            {
                entity.ToTable("workcommand_details_tap");

                entity.HasComment("工令明細檔");

                entity.HasIndex(e => new { e.Startdate, e.Enddate }, "dates");

                entity.HasIndex(e => e.Enddate, "enddate");

                entity.HasIndex(e => e.NgCnt, "ng_cnt");

                entity.HasIndex(e => e.MachineId, "productionlinesid");

                entity.HasIndex(e => new { e.Status, e.Isok }, "realtime_group_index1");

                entity.HasIndex(e => new { e.WorkcommandId, e.SeqNo, e.PlineId, e.MachineId, e.Startdate }, "uid")
                    .IsUnique();

                entity.HasIndex(e => e.WorkcommandId, "workcommand_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(12) unsigned")
                    .HasColumnName("id")
                    .HasComment("序號");

                entity.Property(e => e.Eid1)
                    .HasMaxLength(20)
                    .HasColumnName("eid1");

                entity.Property(e => e.Eid2)
                    .HasMaxLength(20)
                    .HasColumnName("eid2");

                entity.Property(e => e.EndCnt)
                    .HasColumnType("int(11)")
                    .HasColumnName("end_cnt")
                    .HasComment("生產總數量");

                entity.Property(e => e.EndNgCnt)
                    .HasColumnType("int(11)")
                    .HasColumnName("end_ng_cnt");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("enddate")
                    .HasComment("結束時間");

                entity.Property(e => e.Isok)
                    .HasColumnType("int(1)")
                    .HasColumnName("isok");

                entity.Property(e => e.MachineId)
                    .HasMaxLength(20)
                    .HasColumnName("machine_id")
                    .HasComment("機台");

                entity.Property(e => e.Ncode)
                    .HasMaxLength(10)
                    .HasColumnName("ncode")
                    .HasComment("未稼動");

                entity.Property(e => e.NgCnt)
                    .HasColumnType("int(11)")
                    .HasColumnName("ng_cnt");

                entity.Property(e => e.OkCnt)
                    .HasColumnType("int(11)")
                    .HasColumnName("ok_cnt");

                entity.Property(e => e.Perno)
                    .HasMaxLength(10)
                    .HasColumnName("perno")
                    .HasComment("員工");

                entity.Property(e => e.PlineId)
                    .HasMaxLength(30)
                    .HasColumnName("pline_id")
                    .HasComment("線別");

                entity.Property(e => e.SeqNo)
                    .HasColumnType("int(11)")
                    .HasColumnName("seq_no");

                entity.Property(e => e.Shift1)
                    .HasMaxLength(1)
                    .HasColumnName("shift1")
                    .IsFixedLength();

                entity.Property(e => e.Shift2)
                    .HasMaxLength(1)
                    .HasColumnName("shift2")
                    .IsFixedLength();

                entity.Property(e => e.StartCnt)
                    .HasColumnType("int(11)")
                    .HasColumnName("start_cnt");

                entity.Property(e => e.StartNgCnt)
                    .HasColumnType("int(11)")
                    .HasColumnName("start_ng_cnt");

                entity.Property(e => e.Startdate)
                    .HasColumnType("datetime")
                    .HasColumnName("startdate")
                    .HasComment("開始時間");

                entity.Property(e => e.Status)
                    .HasMaxLength(2)
                    .HasColumnName("status")
                    .IsFixedLength()
                    .HasComment("狀態");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("update_time")
                    .HasComment("更新時間");

                entity.Property(e => e.WorkcommandId)
                    .HasMaxLength(20)
                    .HasColumnName("workcommand_id")
                    .HasDefaultValueSql("'0'")
                    .HasComment("工令");
            });

            modelBuilder.Entity<WorkcommandTap>(entity =>
            {
                entity.ToTable("workcommand_tap");

                entity.HasComment("工令主檔");

                entity.HasIndex(e => e.Enddate, "enddate");

                entity.HasIndex(e => e.MachineId, "machine_id");

                entity.HasIndex(e => e.Startdate, "startdate");

                entity.HasIndex(e => e.WorkNo, "work_number");

                entity.HasIndex(e => e.WorkcommandId, "workcommand_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id")
                    .HasComment("序號");

                entity.Property(e => e.CalculateNote)
                    .HasMaxLength(100)
                    .HasColumnName("calculate_note")
                    .HasComment("計算過程");

                entity.Property(e => e.Createtime)
                    .HasColumnType("datetime")
                    .HasColumnName("createtime");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("enddate");

                entity.Property(e => e.ExpectedEnddate)
                    .HasColumnType("datetime")
                    .HasColumnName("expected_enddate")
                    .HasComment("預計完工");

                entity.Property(e => e.ExpectedQty)
                    .HasColumnType("int(11)")
                    .HasColumnName("expected_qty")
                    .HasComment("預計產量(M)");

                entity.Property(e => e.ExpectedStartdate)
                    .HasColumnType("datetime")
                    .HasColumnName("expected_startdate")
                    .HasComment("預計開工");

                entity.Property(e => e.MachineId)
                    .HasColumnType("int(11)")
                    .HasColumnName("machine_id")
                    .HasComment("機台代號");

                entity.Property(e => e.MoldCount)
                    .HasColumnType("int(11)")
                    .HasColumnName("mold_count")
                    .HasDefaultValueSql("'0'")
                    .HasComment("模數");

                entity.Property(e => e.MoldNo)
                    .HasMaxLength(50)
                    .HasColumnName("mold_no");

                entity.Property(e => e.Mtime)
                    .HasColumnType("datetime")
                    .HasColumnName("mtime");

                entity.Property(e => e.Ng)
                    .HasColumnType("int(11)")
                    .HasColumnName("ng")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Note)
                    .HasMaxLength(50)
                    .HasColumnName("note")
                    .HasComment("備註");

                entity.Property(e => e.Ok)
                    .HasColumnType("int(11)")
                    .HasColumnName("ok")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.OrderNo)
                    .HasMaxLength(50)
                    .HasColumnName("order_no");

                entity.Property(e => e.PlcId)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("plc_id")
                    .HasComment("ADC");

                entity.Property(e => e.PlineId)
                    .HasMaxLength(50)
                    .HasColumnName("pline_id")
                    .HasComment("線別代號");

                entity.Property(e => e.ProduceSpeed)
                    .HasMaxLength(10)
                    .HasColumnName("produce_speed")
                    .HasComment("產速");

                entity.Property(e => e.ProductId)
                    .HasMaxLength(50)
                    .HasColumnName("product_id")
                    .HasComment("產品代號");

                entity.Property(e => e.ProductionQty)
                    .HasColumnType("int(11)")
                    .HasColumnName("production_qty")
                    .HasComment("已生產量(M)");

                entity.Property(e => e.PutIn)
                    .HasColumnType("int(11)")
                    .HasColumnName("put_in")
                    .HasComment("派工量");

                entity.Property(e => e.SampleReceipt)
                    .HasColumnType("int(2)")
                    .HasColumnName("sample_receipt")
                    .HasDefaultValueSql("'0'")
                    .HasComment("0為量產單，1為打樣單");

                entity.Property(e => e.SeqNo)
                    .HasColumnType("int(11)")
                    .HasColumnName("seq_no")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Shift)
                    .HasMaxLength(1)
                    .HasColumnName("shift")
                    .IsFixedLength()
                    .HasComment("班別");

                entity.Property(e => e.Startdate)
                    .HasColumnType("datetime")
                    .HasColumnName("startdate")
                    .HasComment("開工時間");

                entity.Property(e => e.Status)
                    .HasColumnType("int(11)")
                    .HasColumnName("status")
                    .HasDefaultValueSql("'0'")
                    .HasComment("0:未完成, 1:已完成, 2:取消");

                entity.Property(e => e.Total)
                    .HasColumnType("int(11)")
                    .HasColumnName("total")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Units)
                    .HasMaxLength(20)
                    .HasColumnName("units")
                    .HasComment("派工單位(1:雙 2:片 3:模)");

                entity.Property(e => e.WorkNo)
                    .HasMaxLength(50)
                    .HasColumnName("work_no")
                    .HasComment("工單");

                entity.Property(e => e.WorkcommandId)
                    .HasMaxLength(50)
                    .HasColumnName("workcommand_id")
                    .HasComment("工令");
            });

            modelBuilder.Entity<ZoneTable>(entity =>
            {
                entity.ToTable("zone_table");

                entity.HasComment("區域");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id")
                    .HasComment("序號");

                entity.Property(e => e.ProduceProduct)
                    .HasMaxLength(20)
                    .HasColumnName("produce_product")
                    .HasComment("可生產產品代號");

                entity.Property(e => e.ProduceSpecInsideMax)
                    .HasMaxLength(20)
                    .HasColumnName("produce_spec_inside_max")
                    .HasComment("可生產最大內徑");

                entity.Property(e => e.ProduceSpecInsideMin)
                    .HasMaxLength(20)
                    .HasColumnName("produce_spec_inside_min")
                    .HasComment("可生產最小內徑");

                entity.Property(e => e.ProduceSpecOutsideMax)
                    .HasMaxLength(20)
                    .HasColumnName("produce_spec_outside_max")
                    .HasComment("可生產最大外徑");

                entity.Property(e => e.ProduceSpecOutsideMin)
                    .HasMaxLength(20)
                    .HasColumnName("produce_spec_outside_min")
                    .HasComment("可生產最小外徑");

                entity.Property(e => e.ZoneName)
                    .HasMaxLength(100)
                    .HasColumnName("zone_name")
                    .HasComment("區域名稱");

                entity.Property(e => e.ZoneNumber)
                    .HasMaxLength(20)
                    .HasColumnName("zone_number")
                    .HasComment("區域代號");
            });

            modelBuilder.Entity<ZoneTomachineTable>(entity =>
            {
                entity.ToTable("zone_tomachine_table");

                entity.HasComment("區域對應機台");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id")
                    .HasComment("序號");

                entity.Property(e => e.MachineId)
                    .HasMaxLength(50)
                    .HasColumnName("machine_id")
                    .HasComment("機台代號");

                entity.Property(e => e.MachineOrder)
                    .HasColumnType("int(11)")
                    .HasColumnName("machine_order");

                entity.Property(e => e.ZoneId)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("zone_id")
                    .HasComment("產線代號");
            });

            modelBuilder.Entity<SystemMsg>(entity =>
            {
                entity.ToTable("system_msg");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id")
                    .HasComment("序號");

                entity.Property(e => e.Category)
                    .HasMaxLength(50)
                    .HasColumnName("category")
                    .HasComment("類別");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("createTime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("建立時間");

                entity.Property(e => e.Msg)
                    .HasMaxLength(500)
                    .HasColumnName("msg")
                    .HasComment("處理訊息");

                entity.Property(e => e.Note)
                    .HasMaxLength(500)
                    .HasColumnName("note")
                    .HasComment("備註");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .HasColumnName("status")
                    .HasComment("狀態");
            });

            modelBuilder.Entity<MeterParameterMa>(entity =>
            {
                entity.ToTable("meter_parameters_ma");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id")
                    .HasComment("id");

                entity.Property(e => e.MeterNo)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("meter_no")
                    .HasComment("Meter Number");

                entity.Property(e => e.IpAddress)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("ip_address")
                    .HasComment("Meter Ip Address");

                entity.Property(e => e.RegLocation)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("reg_location")
                    .HasComment("Register Location");

                entity.Property(e => e.RegLength)
                    .HasColumnType("int(11)")
                    .HasColumnName("reg_length")
                    .HasComment("Register Length");

                entity.Property(e => e.ParaNo)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("para_no")
                    .HasComment("Parameter Number");

                entity.Property(e => e.ParaName)
                    .HasColumnType("varchar(100)")
                    .HasColumnName("para_name")
                    .HasComment("Parameter Name");

                entity.Property(e => e.ParaFieldName)
                    .HasColumnType("varchar(100)")
                    .HasColumnName("para_field_name")
                    .HasComment("Parameter Field Name");

                entity.Property(e => e.DataType)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("data_type")
                    .HasComment("Data Type");

                entity.Property(e => e.Unit)
                    .HasColumnType("varchar(20)")
                    .HasColumnName("unit")
                    .HasComment("Unit");

                entity.Property(e => e.Sign)
                    .HasColumnType("varchar(5)")
                    .HasColumnName("sign")
                    .HasComment("Sign");

                entity.Property(e => e.Sort)
                    .HasColumnType("varchar(5)")
                    .HasColumnName("sort")
                    .HasComment("Sort Order");

                entity.Property(e => e.IsEnable)
                    .HasColumnType("bool")
                    .HasColumnName("is_enable")
                    .HasComment("Is Enabled");

                entity.Property(e => e.Note)
                    .HasColumnType("text")
                    .HasColumnName("note")
                    .HasComment("Note");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasComment("Creation Date");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasComment("Last Update Date");
            });
            modelBuilder.Entity<MeterDayRecord>(entity =>
            {
                entity.ToTable("meter_day_record");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id")
                    .HasComment("序號");

                entity.Property(e => e.EndDeg)
                    .HasMaxLength(20)
                    .HasColumnName("end_deg")
                    .HasComment("結束度數");

                entity.Property(e => e.MachineList)
                    .HasMaxLength(250)
                    .HasColumnName("machine_list")
                    .HasComment("機台列表編號");

                entity.Property(e => e.MeasureDay)
                    .HasMaxLength(10)
                    .HasColumnName("measure_day")
                    .HasComment("用電日期");

                entity.Property(e => e.MeterNo)
                    .HasMaxLength(20)
                    .HasColumnName("meter_no")
                    .HasComment("電表編號");

                entity.Property(e => e.Note)
                    .HasMaxLength(50)
                    .HasColumnName("note")
                    .HasComment("備註");

                entity.Property(e => e.StartDeg)
                    .HasMaxLength(20)
                    .HasColumnName("start_deg")
                    .HasComment("開始度數");

                entity.Property(e => e.TotalDeg)
                    .HasMaxLength(20)
                    .HasColumnName("total_deg")
                    .HasComment("用電度數");
            });

            modelBuilder.Entity<MeterParameter>(entity =>
            {
                entity.ToTable("meter_parameters");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id")
                    .HasComment("序號");

                entity.Property(e => e.DataType)
                    .HasMaxLength(20)
                    .HasColumnName("data_type")
                    .HasComment("資料類型");

                entity.Property(e => e.IsEnabled)
                    .HasColumnName("is_enabled")
                    .HasComment("啟用");

                entity.Property(e => e.MeterNo)
                    .HasMaxLength(20)
                    .HasColumnName("meter_no")
                    .HasComment("電表編號");

                entity.Property(e => e.Note)
                    .HasMaxLength(50)
                    .HasColumnName("note")
                    .HasComment("備註");

                entity.Property(e => e.ParaFieldName)
                    .HasMaxLength(50)
                    .HasColumnName("para_field_name")
                    .HasComment("參數資料對應欄位");

                entity.Property(e => e.ParaName)
                    .HasMaxLength(20)
                    .HasColumnName("para_name")
                    .HasComment("參數名稱");

                entity.Property(e => e.ParaNo)
                    .HasMaxLength(20)
                    .HasColumnName("para_no")
                    .HasComment("參數編號");

                entity.Property(e => e.PlcNo)
                    .HasMaxLength(10)
                    .HasColumnName("plc_no")
                    .HasComment("Plc對應編號");

                entity.Property(e => e.Sign)
                    .HasMaxLength(10)
                    .HasColumnName("sign")
                    .HasComment("符號");

                entity.Property(e => e.Sort)
                    .HasColumnType("int(11)")
                    .HasColumnName("sort")
                    .HasDefaultValueSql("'999'")
                    .HasComment("排序");

                entity.Property(e => e.Unit)
                    .HasMaxLength(10)
                    .HasColumnName("unit")
                    .HasComment("單位");
            });

            modelBuilder.Entity<MeterRecordLog>(entity =>
            {
                entity.ToTable("meter_record_log");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id")
                    .HasComment("序號");

                entity.Property(e => e.AvgCurrent)
                    .HasMaxLength(20)
                    .HasColumnName("avg_current")
                    .HasComment("平均電流");

                entity.Property(e => e.AvgVoltage)
                    .HasMaxLength(20)
                    .HasColumnName("avg_voltage")
                    .HasComment("平均電壓");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("create_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("建立時間");

                entity.Property(e => e.CumulativePower)
                    .HasMaxLength(20)
                    .HasColumnName("cumulative_power")
                    .HasComment("累積用電量");

                entity.Property(e => e.DailyAccumulatedElectricity)
                    .HasMaxLength(20)
                    .HasColumnName("daily_accumulated_electricity")
                    .HasComment("日累積用電");

                entity.Property(e => e.Electricity)
                    .HasMaxLength(20)
                    .HasColumnName("electricity")
                    .HasComment("秏電量");

                entity.Property(e => e.Frequency)
                    .HasMaxLength(20)
                    .HasColumnName("frequency")
                    .HasComment("頻率");

                entity.Property(e => e.MachineList)
                    .HasMaxLength(250)
                    .HasColumnName("machine_list")
                    .HasComment("機台列表編號");

                entity.Property(e => e.MeterNo)
                    .HasMaxLength(20)
                    .HasColumnName("meter_no")
                    .HasComment("電表編號");

                entity.Property(e => e.Note)
                    .HasMaxLength(20)
                    .HasColumnName("note")
                    .HasComment("備註");

                entity.Property(e => e.PowerFactor)
                    .HasMaxLength(20)
                    .HasColumnName("power_factor")
                    .HasComment("功率因數");
            });

            modelBuilder.Entity<MeterTable>(entity =>
            {
                entity.ToTable("meter_table");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("id")
                    .HasComment("序號");

                entity.Property(e => e.AvgCurrent)
                    .HasMaxLength(20)
                    .HasColumnName("avg_current")
                    .HasComment("平均電流");

                entity.Property(e => e.AvgVoltage)
                    .HasMaxLength(20)
                    .HasColumnName("avg_voltage")
                    .HasComment("平均電壓");

                entity.Property(e => e.CumulativePower)
                    .HasMaxLength(20)
                    .HasColumnName("cumulative_power")
                    .HasComment("累積用電量");

                entity.Property(e => e.DailyAccumulatedElectricity)
                    .HasMaxLength(20)
                    .HasColumnName("daily_accumulated_electricity")
                    .HasComment("日累積用電");

                entity.Property(e => e.Electricity)
                    .HasMaxLength(20)
                    .HasColumnName("electricity")
                    .HasComment("秏電量");

                entity.Property(e => e.Frequency)
                    .HasMaxLength(20)
                    .HasColumnName("frequency")
                    .HasComment("頻率");

                entity.Property(e => e.LastUpdateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("last_update_time")
                    .HasComment("最後更新時間");

                entity.Property(e => e.MachineList)
                    .HasMaxLength(250)
                    .HasColumnName("machine_list")
                    .HasComment("用電機台列表");

                entity.Property(e => e.MeterName)
                    .HasMaxLength(20)
                    .HasColumnName("meter_name")
                    .HasComment("電表名稱");

                entity.Property(e => e.MeterNo)
                    .HasMaxLength(20)
                    .HasColumnName("meter_no")
                    .HasComment("電表編號");

                entity.Property(e => e.PlcName)
                    .HasMaxLength(10)
                    .HasColumnName("plc_name")
                    .HasComment("plc代碼");

                entity.Property(e => e.PowerFactor)
                    .HasMaxLength(20)
                    .HasColumnName("power_factor")
                    .HasComment("功率因數");

                entity.Property(e => e.Sort)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("sort")
                    .HasDefaultValueSql("'99'")
                    .HasComment("排序");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .HasColumnName("status")
                    .HasComment("狀態");
            });
            OnModelCreatingPartial(modelBuilder);
        }

        private void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
        }
    }
}