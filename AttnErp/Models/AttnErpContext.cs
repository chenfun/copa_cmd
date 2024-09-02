using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace CopaCmd.AttnErp.Models
{
    public partial class AttnErpContext : DbContext
    {
        public AttnErpContext()
        {
        }

        public AttnErpContext(DbContextOptions<AttnErpContext> options)
            : base(options)
        {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    CopaCmd.Helpers.ConfigHelper.BuildConfiguration().GetConnectionString("AttnDB"),
                    sqlServerOptions => sqlServerOptions.EnableRetryOnFailure()
                );
            }
        }

        public virtual DbSet<MfMo> MfMos { get; set; } = null!;
        public virtual DbSet<MfTz> MfTzs { get; set; } = null!;
        public virtual DbSet<Cust> Custs { get; set; } = null!;

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Compatibility_196_404_30001");

            modelBuilder.Entity<MfMo>(entity =>
            {
                entity.HasKey(e => e.MoNo)
                    .HasName("PK__MF_MO");

                entity.ToTable("MF_MO");

                entity.HasIndex(e => new { e.CloseId, e.ChkMan, e.ZtId, e.CfId }, "K_MF_MO_CLOSE_ID");

                entity.HasIndex(e => new { e.SoNo, e.EstItm }, "K_MF_MO_SO_ITM");

                entity.HasIndex(e => new { e.BilNo, e.BilId }, "K_MO_BIL");

                entity.HasIndex(e => e.BjNo, "K_MO_BJ_NO");

                entity.HasIndex(e => new { e.MoDd, e.Dep }, "K_MO_DD");

                entity.HasIndex(e => new { e.MrpNo, e.PrdMark, e.Wh, e.BatNo }, "K_MRP_NO_WH");

                entity.Property(e => e.MoNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MO_NO");

                entity.Property(e => e.AppNameData)
                    .HasMaxLength(30)
                    .HasColumnName("APP_NAME_DATA")
                    .HasDefaultValueSql("(left(app_name(),(30)))");

                entity.Property(e => e.BackId)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("BACK_ID");

                entity.Property(e => e.BatNo)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("BAT_NO");

                entity.Property(e => e.BilId)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("BIL_ID");

                entity.Property(e => e.BilItm).HasColumnName("BIL_ITM");

                entity.Property(e => e.BilMak)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("BIL_MAK");

                entity.Property(e => e.BilNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("BIL_NO");

                entity.Property(e => e.BilType)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("BIL_TYPE");

                entity.Property(e => e.BjNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("BJ_NO");

                entity.Property(e => e.BuildBil)
                    .HasColumnType("text")
                    .HasColumnName("BUILD_BIL");

                entity.Property(e => e.CancelId)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CANCEL_ID");

                entity.Property(e => e.CasNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CAS_NO");

                entity.Property(e => e.CfDd)
                    .HasColumnType("datetime")
                    .HasColumnName("CF_DD");

                entity.Property(e => e.CfId)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CF_ID");

                entity.Property(e => e.ChkMan)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CHK_MAN");

                entity.Property(e => e.CloseId)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CLOSE_ID");

                entity.Property(e => e.ClsDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CLS_DATE");

                entity.Property(e => e.CnttNo)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("CNTT_NO");

                entity.Property(e => e.Contract)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT");

                entity.Property(e => e.Control)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CONTROL");

                entity.Property(e => e.CpySw)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CPY_SW");

                entity.Property(e => e.Cst)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("CST");

                entity.Property(e => e.CstMakMl)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("CST_MAK_ML");

                entity.Property(e => e.CstMake)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("CST_MAKE");

                entity.Property(e => e.CstMan)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("CST_MAN");

                entity.Property(e => e.CstManMl)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("CST_MAN_ML");

                entity.Property(e => e.CstMl)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("CST_ML");

                entity.Property(e => e.CstOut)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("CST_OUT");

                entity.Property(e => e.CstOutMl)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("CST_OUT_ML");

                entity.Property(e => e.CstPrd)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("CST_PRD");

                entity.Property(e => e.CstPrdMl)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("CST_PRD_ML");

                entity.Property(e => e.CuNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CU_NO");

                entity.Property(e => e.CusNo)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CUS_NO");

                entity.Property(e => e.CusOsNo)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CUS_OS_NO");

                entity.Property(e => e.CvId)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CV_ID");

                entity.Property(e => e.DecUn).HasColumnName("DEC_UN");

                entity.Property(e => e.Dep)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("DEP");

                entity.Property(e => e.EndDd)
                    .HasColumnType("datetime")
                    .HasColumnName("END_DD");

                entity.Property(e => e.EstItm).HasColumnName("EST_ITM");

                entity.Property(e => e.FinDd)
                    .HasColumnType("datetime")
                    .HasColumnName("FIN_DD");

                entity.Property(e => e.GrpNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("GRP_NO");

                entity.Property(e => e.IdNo)
                    .HasMaxLength(72)
                    .IsUnicode(false)
                    .HasColumnName("ID_NO");

                entity.Property(e => e.Isfromqd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISFROMQD");

                entity.Property(e => e.Ismatchbil)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISMATCHBIL");

                entity.Property(e => e.Isnormal)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISNORMAL");

                entity.Property(e => e.Issvs)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISSVS");

                entity.Property(e => e.Lock)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("LOCK");

                entity.Property(e => e.LockDate)
                    .HasColumnType("datetime")
                    .HasColumnName("LOCK_DATE");

                entity.Property(e => e.LockMan)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("LOCK_MAN");

                entity.Property(e => e.MdNo)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("MD_NO");

                entity.Property(e => e.MesStatus).HasColumnName("MES_STATUS");

                entity.Property(e => e.MlByMm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ML_BY_MM");

                entity.Property(e => e.MlOk)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ML_OK");

                entity.Property(e => e.MmCurml)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MM_CURML");

                entity.Property(e => e.MoDd)
                    .HasColumnType("datetime")
                    .HasColumnName("MO_DD");

                entity.Property(e => e.MoNoAdd)
                    .HasMaxLength(58)
                    .IsUnicode(false)
                    .HasColumnName("MO_NO_ADD");

                entity.Property(e => e.MobId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MOB_ID");

                entity.Property(e => e.ModifyDd)
                    .HasColumnType("datetime")
                    .HasColumnName("MODIFY_DD");

                entity.Property(e => e.ModifyMan)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("MODIFY_MAN");

                entity.Property(e => e.MrpNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MRP_NO");

                entity.Property(e => e.NeedDd)
                    .HasColumnType("datetime")
                    .HasColumnName("NEED_DD");

                entity.Property(e => e.OldId)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("OLD_ID");

                entity.Property(e => e.OpnDd)
                    .HasColumnType("datetime")
                    .HasColumnName("OPN_DD");

                entity.Property(e => e.OutDdMoj)
                    .HasColumnType("datetime")
                    .HasColumnName("OUT_DD_MOJ");

                entity.Property(e => e.PgId)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PG_ID");

                entity.Property(e => e.PoOk)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PO_OK");

                entity.Property(e => e.PrdMark)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PRD_MARK")
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.PrtDate)
                    .HasColumnType("datetime")
                    .HasColumnName("PRT_DATE");

                entity.Property(e => e.PrtSw)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PRT_SW");

                entity.Property(e => e.PrtUsr)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PRT_USR");

                entity.Property(e => e.Q2Id)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Q2_ID");

                entity.Property(e => e.Q3Id)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Q3_ID");

                entity.Property(e => e.QcYn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("QC_YN");

                entity.Property(e => e.Qcmlflag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("QCMLFLAG");

                entity.Property(e => e.QlId)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("QL_ID");

                entity.Property(e => e.Qty)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("QTY");

                entity.Property(e => e.Qty1)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("QTY1");

                entity.Property(e => e.QtyChk)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("QTY_CHK");

                entity.Property(e => e.QtyChkUnsh)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("QTY_CHK_UNSH");

                entity.Property(e => e.QtyDm)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("QTY_DM");

                entity.Property(e => e.QtyDmUnsh)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("QTY_DM_UNSH");

                entity.Property(e => e.QtyEr)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("QTY_ER");

                entity.Property(e => e.QtyErUnsh)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("QTY_ER_UNSH");

                entity.Property(e => e.QtyFin)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("QTY_FIN")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.QtyFinUnsh)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("QTY_FIN_UNSH")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.QtyLost)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("QTY_LOST");

                entity.Property(e => e.QtyLostUnsh)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("QTY_LOST_UNSH");

                entity.Property(e => e.QtyMl)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("QTY_ML")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.QtyMlUnsh)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("QTY_ML_UNSH")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.QtyPg)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("QTY_PG");

                entity.Property(e => e.QtyPgUnsh)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("QTY_PG_UNSH");

                entity.Property(e => e.QtyQl)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("QTY_QL");

                entity.Property(e => e.QtyQlUnsh)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("QTY_QL_UNSH");

                entity.Property(e => e.QtyQs)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("QTY_QS");

                entity.Property(e => e.QtyQsUnsh)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("QTY_QS_UNSH");

                entity.Property(e => e.QtyRk)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("QTY_RK");

                entity.Property(e => e.QtyRkUnsh)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("QTY_RK_UNSH");

                entity.Property(e => e.Rem)
                    .HasColumnType("text")
                    .HasColumnName("REM");

                entity.Property(e => e.SebNo)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("SEB_NO");

                entity.Property(e => e.SoId)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SO_ID");

                entity.Property(e => e.SoNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SO_NO");

                entity.Property(e => e.StaDd)
                    .HasColumnType("datetime")
                    .HasColumnName("STA_DD");

                entity.Property(e => e.SupPrdMark)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SUP_PRD_MARK");

                entity.Property(e => e.SupPrdNo)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("SUP_PRD_NO");

                entity.Property(e => e.SysDate)
                    .HasColumnType("datetime")
                    .HasColumnName("SYS_DATE");

                entity.Property(e => e.TaskId).HasColumnName("TASK_ID");

                entity.Property(e => e.TimeAj)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("TIME_AJ");

                entity.Property(e => e.TimeCnt)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("TIME_CNT");

                entity.Property(e => e.TsId)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TS_ID");

                entity.Property(e => e.Unit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("UNIT");

                entity.Property(e => e.UsedTime)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("USED_TIME");

                entity.Property(e => e.Usr)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("USR");

                entity.Property(e => e.Wh)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("WH");

                entity.Property(e => e.ZtDd)
                    .HasColumnType("datetime")
                    .HasColumnName("ZT_DD");

                entity.Property(e => e.ZtId)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ZT_ID");
                
                entity.HasMany(e => e.MfTzs)
                    .WithOne(e => e.MfMo)
                    .HasForeignKey(e => e.MoNo)
                    .IsRequired();
            });

            modelBuilder.Entity<MfTz>(entity =>
            {
                entity.HasKey(e => e.TzNo)
                    .HasName("PK__MF_TZ");

                entity.ToTable("MF_TZ");

                entity.HasIndex(e => new { e.MrpNo, e.PrdMark, e.ZcNo, e.IdNo }, "K_PRD_NO_TZ");

                entity.HasIndex(e => new { e.BilNo, e.BilId }, "K_TZ_BIL");

                entity.HasIndex(e => new { e.TzDd, e.Dep }, "K_TZ_DD");

                entity.HasIndex(e => new { e.EndDd, e.StaDd }, "K_TZ_END_DD");

                entity.HasIndex(e => new { e.MoNo, e.ZcNo }, "K_TZ_MO");

                entity.HasIndex(e => new { e.SoNo, e.Dep }, "K_TZ_SO_DEP");

                entity.Property(e => e.TzNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TZ_NO");

                entity.Property(e => e.AppNameData)
                    .HasMaxLength(30)
                    .HasColumnName("APP_NAME_DATA")
                    .HasDefaultValueSql("(left(app_name(),(30)))");

                entity.Property(e => e.BackId)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("BACK_ID");

                entity.Property(e => e.BatNo)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("BAT_NO");

                entity.Property(e => e.BatPgNo)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("BAT_PG_NO");

                entity.Property(e => e.BilId)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("BIL_ID");

                entity.Property(e => e.BilNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("BIL_NO");

                entity.Property(e => e.BilType)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("BIL_TYPE");

                entity.Property(e => e.CancelId)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CANCEL_ID");

                entity.Property(e => e.CasNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CAS_NO");

                entity.Property(e => e.ChkId)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CHK_ID");

                entity.Property(e => e.ChkMan)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CHK_MAN");

                entity.Property(e => e.Chkqcsj)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CHKQCSJ");

                entity.Property(e => e.CloseId)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CLOSE_ID");

                entity.Property(e => e.ClsDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CLS_DATE");

                entity.Property(e => e.CpySw)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CPY_SW");

                entity.Property(e => e.Cst)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("CST");

                entity.Property(e => e.CstMakMl)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("CST_MAK_ML");

                entity.Property(e => e.CstMake)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("CST_MAKE");

                entity.Property(e => e.CstMan)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("CST_MAN");

                entity.Property(e => e.CstManMl)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("CST_MAN_ML");

                entity.Property(e => e.CstMl)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("CST_ML");

                entity.Property(e => e.CstOut)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("CST_OUT");

                entity.Property(e => e.CstOutMl)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("CST_OUT_ML");

                entity.Property(e => e.CstPrd)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("CST_PRD");

                entity.Property(e => e.CstPrdMl)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("CST_PRD_ML");

                entity.Property(e => e.CusOsNo)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CUS_OS_NO");

                entity.Property(e => e.Dep)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("DEP");

                entity.Property(e => e.DepDown)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("DEP_DOWN");

                entity.Property(e => e.DepUp)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("DEP_UP");

                entity.Property(e => e.EndDd)
                    .HasColumnType("datetime")
                    .HasColumnName("END_DD");

                entity.Property(e => e.EstItm).HasColumnName("EST_ITM");

                entity.Property(e => e.FinDd)
                    .HasColumnType("datetime")
                    .HasColumnName("FIN_DD");

                entity.Property(e => e.GrpNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("GRP_NO");

                entity.Property(e => e.IdNo)
                    .HasMaxLength(72)
                    .IsUnicode(false)
                    .HasColumnName("ID_NO");

                entity.Property(e => e.Isfirst)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISFIRST");

                entity.Property(e => e.LbChk)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("LB_CHK");

                entity.Property(e => e.Lock)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("LOCK");

                entity.Property(e => e.LockDate)
                    .HasColumnType("datetime")
                    .HasColumnName("LOCK_DATE");

                entity.Property(e => e.LockMan)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("LOCK_MAN");

                entity.Property(e => e.MdNo)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("MD_NO");

                entity.Property(e => e.MlFin)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ML_FIN");

                entity.Property(e => e.MlOk)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ML_OK");

                entity.Property(e => e.MoNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MO_NO");

                entity.Property(e => e.MobId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MOB_ID");

                entity.Property(e => e.ModifyDd)
                    .HasColumnType("datetime")
                    .HasColumnName("MODIFY_DD");

                entity.Property(e => e.ModifyMan)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("MODIFY_MAN");

                entity.Property(e => e.MrpNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MRP_NO");

                entity.Property(e => e.MvDd)
                    .HasColumnType("datetime")
                    .HasColumnName("MV_DD");

                entity.Property(e => e.MvId)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MV_ID");

                entity.Property(e => e.OpnDd)
                    .HasColumnType("datetime")
                    .HasColumnName("OPN_DD");

                entity.Property(e => e.OutDdMoj)
                    .HasColumnType("datetime")
                    .HasColumnName("OUT_DD_MOJ");

                entity.Property(e => e.PgId)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PG_ID");

                entity.Property(e => e.PrdMark)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PRD_MARK")
                    .HasDefaultValueSql("(space((0)))");

                entity.Property(e => e.PrtDate)
                    .HasColumnType("datetime")
                    .HasColumnName("PRT_DATE");

                entity.Property(e => e.PrtSw)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PRT_SW");

                entity.Property(e => e.PrtUsr)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PRT_USR");

                entity.Property(e => e.QcYn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("QC_YN");

                entity.Property(e => e.Qcmlflag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("QCMLFLAG");

                entity.Property(e => e.Qty)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("QTY");

                entity.Property(e => e.Qty1)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("QTY1");

                entity.Property(e => e.QtyChk)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("QTY_CHK");

                entity.Property(e => e.QtyChkUnsh)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("QTY_CHK_UNSH");

                entity.Property(e => e.QtyDm)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("QTY_DM");

                entity.Property(e => e.QtyDmUnsh)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("QTY_DM_UNSH");

                entity.Property(e => e.QtyFin)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("QTY_FIN");

                entity.Property(e => e.QtyFinUnsh)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("QTY_FIN_UNSH");

                entity.Property(e => e.QtyLost)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("QTY_LOST");

                entity.Property(e => e.QtyLostSzc)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("QTY_LOST_SZC");

                entity.Property(e => e.QtyLostSzcUnsh)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("QTY_LOST_SZC_UNSH");

                entity.Property(e => e.QtyLostUnsh)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("QTY_LOST_UNSH");

                entity.Property(e => e.QtyLostZc)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("QTY_LOST_ZC");

                entity.Property(e => e.QtyLostZcUnsh)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("QTY_LOST_ZC_UNSH");

                entity.Property(e => e.QtyMl)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("QTY_ML");

                entity.Property(e => e.QtyMlUnsh)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("QTY_ML_UNSH");

                entity.Property(e => e.QtyMv)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("QTY_MV");

                entity.Property(e => e.QtyMvUnsh)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("QTY_MV_UNSH");

                entity.Property(e => e.QtyPrc)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("QTY_PRC");

                entity.Property(e => e.QtyQl)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("QTY_QL");

                entity.Property(e => e.QtyQlUnsh)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("QTY_QL_UNSH");

                entity.Property(e => e.QtyQs)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("QTY_QS");

                entity.Property(e => e.QtyQsUnsh)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("QTY_QS_UNSH");

                entity.Property(e => e.QtyRk)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("QTY_RK");

                entity.Property(e => e.QtyRkUnsh)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("QTY_RK_UNSH");

                entity.Property(e => e.QtyWh)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("QTY_WH");

                entity.Property(e => e.Rem)
                    .HasColumnType("text")
                    .HasColumnName("REM");

                entity.Property(e => e.Rrem)
                    .HasColumnType("text")
                    .HasColumnName("RREM");

                entity.Property(e => e.SebNo)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("SEB_NO");

                entity.Property(e => e.SoId)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SO_ID");

                entity.Property(e => e.SoNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SO_NO");

                entity.Property(e => e.StaDd)
                    .HasColumnType("datetime")
                    .HasColumnName("STA_DD");

                entity.Property(e => e.SysDate)
                    .HasColumnType("datetime")
                    .HasColumnName("SYS_DATE");

                entity.Property(e => e.TaskId).HasColumnName("TASK_ID");

                entity.Property(e => e.TimeCnt)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("TIME_CNT");

                entity.Property(e => e.TrNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TR_NO");

                entity.Property(e => e.TsId)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TS_ID");

                entity.Property(e => e.TzDd)
                    .HasColumnType("datetime")
                    .HasColumnName("TZ_DD");

                entity.Property(e => e.Unit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("UNIT");

                entity.Property(e => e.UsedTime)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("USED_TIME");

                entity.Property(e => e.Usr)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("USR");

                entity.Property(e => e.ZcItm).HasColumnName("ZC_ITM");

                entity.Property(e => e.ZcNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ZC_NO");

                entity.Property(e => e.ZcNoDn)
                    .HasMaxLength(440)
                    .IsUnicode(false)
                    .HasColumnName("ZC_NO_DN");

                entity.Property(e => e.ZcNoUp)
                    .HasMaxLength(440)
                    .IsUnicode(false)
                    .HasColumnName("ZC_NO_UP");

                entity.Property(e => e.ZtDd)
                    .HasColumnType("datetime")
                    .HasColumnName("ZT_DD");

                entity.Property(e => e.ZtId)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ZT_ID");
            });
            
                        modelBuilder.Entity<Cust>(entity =>
            {
                entity.HasKey(e => e.CusNo)
                    .HasName("PK__CUST");

                entity.ToTable("CUST");

                entity.HasIndex(e => e.CardNo, "K_CARD_NO");

                entity.HasIndex(e => e.Dep, "K_CUST_DEP");

                entity.HasIndex(e => new { e.Fax, e.ObjId }, "K_FAX");

                entity.HasIndex(e => e.Idx2, "K_IDX2");

                entity.HasIndex(e => new { e.CntMan1, e.ObjId }, "K_MAN");

                entity.HasIndex(e => new { e.Name, e.ObjId }, "K_NAME");

                entity.HasIndex(e => new { e.CusNo, e.ObjId }, "K_NO");

                entity.HasIndex(e => new { e.Snm, e.ObjId }, "K_SNM");

                entity.HasIndex(e => new { e.Tel1, e.ObjId }, "K_TEL");

                entity.HasIndex(e => new { e.UniNo, e.ObjId }, "K_UN_NO");

                entity.HasIndex(e => e.UpDd, "K_UP_DD");

                entity.Property(e => e.CusNo)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CUS_NO");

                entity.Property(e => e.AccMan)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ACC_MAN");

                entity.Property(e => e.AccNoAp)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ACC_NO_AP");

                entity.Property(e => e.AccNoAp2)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ACC_NO_AP2");

                entity.Property(e => e.AccNoAr)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ACC_NO_AR");

                entity.Property(e => e.AccNoAr2)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ACC_NO_AR2");

                entity.Property(e => e.AccNoIp)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ACC_NO_IP");

                entity.Property(e => e.AccNoIr)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ACC_NO_IR");

                entity.Property(e => e.AccNoP0)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ACC_NO_P0");

                entity.Property(e => e.AccNoR0)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ACC_NO_R0");

                entity.Property(e => e.AccNoZp)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ACC_NO_ZP");

                entity.Property(e => e.AddIdNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ADD_ID_NO");

                entity.Property(e => e.Adr1)
                    .HasColumnType("text")
                    .HasColumnName("ADR1");

                entity.Property(e => e.Adr2)
                    .HasColumnType("text")
                    .HasColumnName("ADR2");

                entity.Property(e => e.AdrEng)
                    .HasColumnType("text")
                    .HasColumnName("ADR_ENG");

                entity.Property(e => e.AmtnDj)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("AMTN_DJ");

                entity.Property(e => e.AmtnFl)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("AMTN_FL");

                entity.Property(e => e.AmtnFled)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("AMTN_FLED");

                entity.Property(e => e.AmtnMaxPay)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("AMTN_MAX_PAY");

                entity.Property(e => e.AmtnMinCg)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("AMTN_MIN_CG");

                entity.Property(e => e.AmtnMinXf)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("AMTN_MIN_XF");

                entity.Property(e => e.AmtnQk)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("AMTN_QK");

                entity.Property(e => e.AppNameData)
                    .HasMaxLength(30)
                    .HasColumnName("APP_NAME_DATA")
                    .HasDefaultValueSql("(left(app_name(),(30)))");

                entity.Property(e => e.ApplyDd)
                    .HasColumnType("datetime")
                    .HasColumnName("APPLY_DD");

                entity.Property(e => e.AutoCasnChk)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("AUTO_CASN_CHK");

                entity.Property(e => e.B2btype)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("B2BTYPE");

                entity.Property(e => e.B2cId)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("B2C_ID");

                entity.Property(e => e.BaccNo)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("BACC_NO");

                entity.Property(e => e.BankName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BANK_NAME");

                entity.Property(e => e.BankNo)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("BANK_NO");

                entity.Property(e => e.BbDd)
                    .HasColumnType("datetime")
                    .HasColumnName("BB_DD");

                entity.Property(e => e.BfCntDd)
                    .HasColumnType("datetime")
                    .HasColumnName("BF_CNT_DD");

                entity.Property(e => e.BilMinCg)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BIL_MIN_CG");

                entity.Property(e => e.BilMinXf)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("BIL_MIN_XF");

                entity.Property(e => e.BizDsc)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("BIZ_DSC");

                entity.Property(e => e.BizDsc1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("BIZ_DSC1");

                entity.Property(e => e.BnkName)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("BNK_NAME");

                entity.Property(e => e.BosNm)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("BOS_NM");

                entity.Property(e => e.BrdNo)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("BRD_NO");

                entity.Property(e => e.Broker)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("BROKER");

                entity.Property(e => e.Businote)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BUSINOTE");

                entity.Property(e => e.Busisum)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("BUSISUM");

                entity.Property(e => e.Ca1No)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("CA1_NO");

                entity.Property(e => e.CaNo)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("CA_NO");

                entity.Property(e => e.Capsum)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("CAPSUM");

                entity.Property(e => e.CardNo)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CARD_NO");

                entity.Property(e => e.ChkBarcode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CHK_BARCODE");

                entity.Property(e => e.ChkCk)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CHK_CK");

                entity.Property(e => e.ChkCrd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CHK_CRD");

                entity.Property(e => e.ChkCusIdx)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CHK_CUS_IDX");

                entity.Property(e => e.ChkCx)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CHK_CX");

                entity.Property(e => e.ChkDd).HasColumnName("CHK_DD");

                entity.Property(e => e.ChkDep)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CHK_DEP");

                entity.Property(e => e.ChkDrp1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CHK_DRP1");

                entity.Property(e => e.ChkDrp2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CHK_DRP2");

                entity.Property(e => e.ChkDrp3)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CHK_DRP3");

                entity.Property(e => e.ChkDrp4)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CHK_DRP4");

                entity.Property(e => e.ChkFax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CHK_FAX");

                entity.Property(e => e.ChkFl)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CHK_FL");

                entity.Property(e => e.ChkFullPay)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CHK_FULL_PAY");

                entity.Property(e => e.ChkInclude)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CHK_INCLUDE");

                entity.Property(e => e.ChkIndx1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CHK_INDX1");

                entity.Property(e => e.ChkIrp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CHK_IRP");

                entity.Property(e => e.ChkIrp2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CHK_IRP2");

                entity.Property(e => e.ChkKd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CHK_KD");

                entity.Property(e => e.ChkMall)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CHK_MALL");

                entity.Property(e => e.ChkMan)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CHK_MAN");

                entity.Property(e => e.ChkMinCg)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CHK_MIN_CG");

                entity.Property(e => e.ChkMinXf)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CHK_MIN_XF");

                entity.Property(e => e.ChkO2oFx)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CHK_O2O_FX");

                entity.Property(e => e.ChkPay1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CHK_PAY1");

                entity.Property(e => e.ChkPay2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CHK_PAY2");

                entity.Property(e => e.ChkPay3)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CHK_PAY3");

                entity.Property(e => e.ChkPc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CHK_PC");

                entity.Property(e => e.ChkPrdBt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CHK_PRD_BT");

                entity.Property(e => e.ChkQk)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CHK_QK");

                entity.Property(e => e.ChkSbrto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CHK_SBRTO");

                entity.Property(e => e.ChkShgk)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CHK_SHGK");

                entity.Property(e => e.ChkSkipLim)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CHK_SKIP_LIM");

                entity.Property(e => e.ChkTh)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CHK_TH");

                entity.Property(e => e.ChkTrp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CHK_TRP");

                entity.Property(e => e.ChkTw)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CHK_TW");

                entity.Property(e => e.ChkTypeMincg)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CHK_TYPE_MINCG");

                entity.Property(e => e.ChkTypeMinxf)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CHK_TYPE_MINXF");

                entity.Property(e => e.ChkTzsh)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CHK_TZSH");

                entity.Property(e => e.ChkZhangId2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CHK_ZHANG_ID2");

                entity.Property(e => e.CkUsewh)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CK_USEWH");

                entity.Property(e => e.Cls1)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("CLS1");

                entity.Property(e => e.Cls2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CLS2");

                entity.Property(e => e.ClsDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CLS_DATE");

                entity.Property(e => e.ClsDd).HasColumnName("CLS_DD");

                entity.Property(e => e.ClsMth)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CLS_MTH");

                entity.Property(e => e.CntJob1)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CNT_JOB1");

                entity.Property(e => e.CntJob2)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CNT_JOB2");

                entity.Property(e => e.CntMan1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CNT_MAN1");

                entity.Property(e => e.CntMan2)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CNT_MAN2");

                entity.Property(e => e.CodeName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CODE_NAME");

                entity.Property(e => e.CompDd)
                    .HasColumnType("datetime")
                    .HasColumnName("COMP_DD");

                entity.Property(e => e.Compnet)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("COMPNET");

                entity.Property(e => e.CorpId)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("CORP_ID");

                entity.Property(e => e.CounId).HasColumnName("COUN_ID");

                entity.Property(e => e.Country)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("COUNTRY");

                entity.Property(e => e.CrdId)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CRD_ID");

                entity.Property(e => e.CrdNrNc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CRD_NR_NC");

                entity.Property(e => e.Cur)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("CUR");

                entity.Property(e => e.CusAre)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CUS_ARE");

                entity.Property(e => e.CusFh)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CUS_FH");

                entity.Property(e => e.CusIdx)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CUS_IDX");

                entity.Property(e => e.CusLevel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CUS_LEVEL");

                entity.Property(e => e.CusNoKd)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CUS_NO_KD");

                entity.Property(e => e.CusSrc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CUS_SRC");

                entity.Property(e => e.CustBbTypeId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CUST_BB_TYPE_ID");

                entity.Property(e => e.Cwork).HasColumnName("CWORK");

                entity.Property(e => e.CyId)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CY_ID");

                entity.Property(e => e.DateFqsk)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_FQSK");

                entity.Property(e => e.DateflagFqsk)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DATEFLAG_FQSK");

                entity.Property(e => e.Dep)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("DEP");

                entity.Property(e => e.Dep1)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("DEP1");

                entity.Property(e => e.DepFh)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("DEP_FH");

                entity.Property(e => e.DeproNo)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("DEPRO_NO");

                entity.Property(e => e.DisPort)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("DIS_PORT");

                entity.Property(e => e.DjLc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DJ_LC");

                entity.Property(e => e.DjPay)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DJ_PAY");

                entity.Property(e => e.DjSq)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DJ_SQ");

                entity.Property(e => e.DjYe)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DJ_YE");

                entity.Property(e => e.DrpId)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DRP_ID");

                entity.Property(e => e.EMail)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("E_MAIL");

                entity.Property(e => e.EndDd)
                    .HasColumnType("datetime")
                    .HasColumnName("END_DD");

                entity.Property(e => e.Epaper)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("EPAPER");

                entity.Property(e => e.ExTrdId)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("EX_TRD_ID");

                entity.Property(e => e.Fax)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("FAX");

                entity.Property(e => e.FlagTaxchgI)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FLAG_TAXCHG_I");

                entity.Property(e => e.FlagTaxchgO)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FLAG_TAXCHG_O");

                entity.Property(e => e.FpName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("FP_NAME");

                entity.Property(e => e.FpName2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FP_NAME2");

                entity.Property(e => e.FpType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FP_TYPE");

                entity.Property(e => e.FxLevel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FX_LEVEL");

                entity.Property(e => e.GdzWebdz)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GDZ_WEBDZ");

                entity.Property(e => e.GdzWebflow)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GDZ_WEBFLOW");

                entity.Property(e => e.HmId)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("HM_ID");

                entity.Property(e => e.Id1Tax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ID1_TAX");

                entity.Property(e => e.Id2Tax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ID2_TAX");

                entity.Property(e => e.IdCode)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ID_CODE");

                entity.Property(e => e.Idx2)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("IDX2");

                entity.Property(e => e.ImTrdId)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IM_TRD_ID");

                entity.Property(e => e.IncCheck)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("INC_CHECK");

                entity.Property(e => e.Initnum)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("INITNUM");

                entity.Property(e => e.Interest)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("INTEREST");

                entity.Property(e => e.InvId)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("INV_ID");

                entity.Property(e => e.Iscoop)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCOOP");

                entity.Property(e => e.Iscustkey)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCUSTKEY");

                entity.Property(e => e.JdNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("JD_NO");

                entity.Property(e => e.LangId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LANG_ID");

                entity.Property(e => e.LastCntDd)
                    .HasColumnType("datetime")
                    .HasColumnName("LAST_CNT_DD");

                entity.Property(e => e.LimNc)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("LIM_NC");

                entity.Property(e => e.LimNr)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("LIM_NR");

                entity.Property(e => e.LimNrType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("LIM_NR_TYPE");

                entity.Property(e => e.LoadingPort)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("LOADING_PORT");

                entity.Property(e => e.LocalId)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("LOCAL_ID");

                entity.Property(e => e.Logon)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("LOGON");

                entity.Property(e => e.LostCtype)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("LOST_CTYPE");

                entity.Property(e => e.LostItmes).HasColumnName("LOST_ITMES");

                entity.Property(e => e.LostType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("LOST_TYPE");

                entity.Property(e => e.LsRto)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("LS_RTO");

                entity.Property(e => e.MCust)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("M_CUST");

                entity.Property(e => e.MainPrd)
                    .HasColumnType("text")
                    .HasColumnName("MAIN_PRD");

                entity.Property(e => e.ManuPlace)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("MANU_PLACE");

                entity.Property(e => e.MasCus)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("MAS_CUS");

                entity.Property(e => e.MmEnd).HasColumnName("MM_END");

                entity.Property(e => e.MobId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MOB_ID");

                entity.Property(e => e.ModifyDd)
                    .HasColumnType("datetime")
                    .HasColumnName("MODIFY_DD");

                entity.Property(e => e.ModifyMan)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("MODIFY_MAN");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.NamePy)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("NAME_PY");

                entity.Property(e => e.NbrdNo)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("NBRD_NO");

                entity.Property(e => e.Nca1No)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("NCA1_NO");

                entity.Property(e => e.NcaNo)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("NCA_NO");

                entity.Property(e => e.NmEng)
                    .HasColumnType("text")
                    .HasColumnName("NM_ENG");

                entity.Property(e => e.Notify)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("NOTIFY");

                entity.Property(e => e.NsrCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NSR_CODE");

                entity.Property(e => e.NszgFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("NSZG_FLAG");

                entity.Property(e => e.ObjId)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("OBJ_ID");

                entity.Property(e => e.PayDays).HasColumnName("PAY_DAYS");

                entity.Property(e => e.PayDd).HasColumnName("PAY_DD");

                entity.Property(e => e.PayFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PAY_FLAG");

                entity.Property(e => e.PhotoPic)
                    .HasColumnType("image")
                    .HasColumnName("PHOTO_PIC");

                entity.Property(e => e.PjsqWh)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("PJSQ_WH");

                entity.Property(e => e.PrePsdays).HasColumnName("PRE_PSDAYS");

                entity.Property(e => e.PrtweeksPo).HasColumnName("PRTWEEKS_PO");

                entity.Property(e => e.Pswd)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PSWD");

                entity.Property(e => e.PswdAns)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PSWD_ANS");

                entity.Property(e => e.PswdHit)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("PSWD_HIT");

                entity.Property(e => e.PswdPay)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PSWD_PAY");

                entity.Property(e => e.QsFqsk).HasColumnName("QS_FQSK");

                entity.Property(e => e.RcCntDd)
                    .HasColumnType("datetime")
                    .HasColumnName("RC_CNT_DD");

                entity.Property(e => e.RegistCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("REGIST_CODE");

                entity.Property(e => e.Rem)
                    .HasColumnType("text")
                    .HasColumnName("REM");

                entity.Property(e => e.RemS)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("REM_S");

                entity.Property(e => e.RtnCtrl)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RTN_CTRL");

                entity.Property(e => e.RtoDiscnt)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("RTO_DISCNT");

                entity.Property(e => e.RtoDiscntLevel)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("RTO_DISCNT_LEVEL");

                entity.Property(e => e.RtoFl)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("RTO_FL");

                entity.Property(e => e.RtoFqsk)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("RTO_FQSK");

                entity.Property(e => e.RtoKk)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("RTO_KK");

                entity.Property(e => e.RtoTax)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("RTO_TAX");

                entity.Property(e => e.RtoYl)
                    .HasColumnType("numeric(22, 8)")
                    .HasColumnName("RTO_YL");

                entity.Property(e => e.RuleId).HasColumnName("RULE_ID");

                entity.Property(e => e.SCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("S_CODE");

                entity.Property(e => e.SFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("S_FLAG");

                entity.Property(e => e.Sal)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("SAL");

                entity.Property(e => e.SalNo)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("SAL_NO");

                entity.Property(e => e.Salms).HasColumnName("SALMS");

                entity.Property(e => e.SendMth)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("SEND_MTH");

                entity.Property(e => e.SendWh)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("SEND_WH");

                entity.Property(e => e.ShzqM).HasColumnName("SHZQ_M");

                entity.Property(e => e.SjCntDd)
                    .HasColumnType("datetime")
                    .HasColumnName("SJ_CNT_DD");

                entity.Property(e => e.Snm)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("SNM");

                entity.Property(e => e.SoCrd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SO_CRD");

                entity.Property(e => e.SoDd)
                    .HasColumnType("datetime")
                    .HasColumnName("SO_DD");

                entity.Property(e => e.SoweeksPo).HasColumnName("SOWEEKS_PO");

                entity.Property(e => e.SrvNo)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("SRV_NO");

                entity.Property(e => e.StopOrder)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STOP_ORDER");

                entity.Property(e => e.StrDd)
                    .HasColumnType("datetime")
                    .HasColumnName("STR_DD");

                entity.Property(e => e.SupLevel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SUP_LEVEL");

                entity.Property(e => e.SysDate)
                    .HasColumnType("datetime")
                    .HasColumnName("SYS_DATE");

                entity.Property(e => e.Tel1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TEL1");

                entity.Property(e => e.Tel1Code)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TEL1_CODE");

                entity.Property(e => e.Tel2)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TEL2");

                entity.Property(e => e.Tempflag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TEMPFLAG");

                entity.Property(e => e.TiFrom)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TI_FROM");

                entity.Property(e => e.TiFromId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TI_FROM_ID");

                entity.Property(e => e.TiFromPo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TI_FROM_PO");

                entity.Property(e => e.TiFromTw)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TI_FROM_TW");

                entity.Property(e => e.TranRec)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TRAN_REC");

                entity.Property(e => e.TtTypeSet)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TT_TYPE_SET");

                entity.Property(e => e.TzbhBilId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TZBH_BIL_ID");

                entity.Property(e => e.TzbhDd)
                    .HasColumnType("datetime")
                    .HasColumnName("TZBH_DD");

                entity.Property(e => e.TzfhBilId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TZFH_BIL_ID");

                entity.Property(e => e.TzfhDd)
                    .HasColumnType("datetime")
                    .HasColumnName("TZFH_DD");

                entity.Property(e => e.UniNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UNI_NO");

                entity.Property(e => e.UniNo2)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UNI_NO2");

                entity.Property(e => e.UpDd)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("UP_DD");

                entity.Property(e => e.Upr4Id)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("UPR4_ID");

                entity.Property(e => e.UsewhId)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USEWH_ID");

                entity.Property(e => e.Usr)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("USR");

                entity.Property(e => e.Usr1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("USR1");

                entity.Property(e => e.Vessel)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("VESSEL");

                entity.Property(e => e.VisitLimit).HasColumnName("VISIT_LIMIT");

                entity.Property(e => e.WhFh)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("WH_FH");

                entity.Property(e => e.WhNo)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("WH_NO");

                entity.Property(e => e.WmsShlcPo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("WMS_SHLC_PO");

                entity.Property(e => e.WmsShlcTw)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("WMS_SHLC_TW");

                entity.Property(e => e.Workitm)
                    .HasColumnType("text")
                    .HasColumnName("WORKITM");

                entity.Property(e => e.WsCusNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("WS_CUS_NO");

                entity.Property(e => e.XnNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("XN_NO");

                entity.Property(e => e.YhType)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("YH_TYPE");

                entity.Property(e => e.YhWh1)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("YH_WH1");

                entity.Property(e => e.YhWh2)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("YH_WH2");

                entity.Property(e => e.Zip)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ZIP");

                entity.Property(e => e.ZqBtCtrl)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ZQ_BT_CTRL");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
