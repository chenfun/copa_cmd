using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CopaCmd.Adc.Models
{
    public partial class CopaAdcContext : DbContext
    {
        public CopaAdcContext()
        {
        }

        public CopaAdcContext(DbContextOptions<CopaAdcContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MeterRecordLog> MeterRecordLogs { get; set; } = null!;
        public virtual DbSet<VigorplclogTap> VigorplclogTaps { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8");

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

            modelBuilder.Entity<VigorplclogTap>(entity =>
            {
                entity.ToTable("vigorplclog_tap");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Category)
                    .HasMaxLength(50)
                    .HasColumnName("category");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("create_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Desc)
                    .HasMaxLength(50)
                    .HasColumnName("desc");

                entity.Property(e => e.JsonData)
                    .HasColumnType("json")
                    .HasColumnName("json_data");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        private void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
        }
    }
}