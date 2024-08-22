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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
