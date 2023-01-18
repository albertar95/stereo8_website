using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AudioShopBackend.Models.RepDbModel;

public partial class HoloRepDbContext : DbContext
{
    public HoloRepDbContext()
    {
    }

    public HoloRepDbContext(DbContextOptions<HoloRepDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Article> Articles { get; set; }

    public virtual DbSet<Articlebackup> Articlebackups { get; set; }

    public virtual DbSet<RepLog> RepLogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("HolooConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>(entity =>
        {
            entity.HasKey(e => e.ACode);

            entity.ToTable("ARTICLE");

            entity.Property(e => e.ACode)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("A_Code");
            entity.Property(e => e.AName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("A_Name");
            entity.Property(e => e.ExistMandeh).HasColumnName("Exist_Mandeh");
            entity.Property(e => e.SelPrice).HasColumnName("Sel_Price");
            entity.Property(e => e.Weight).HasColumnName("weight");
        });

        modelBuilder.Entity<Articlebackup>(entity =>
        {
            entity.HasKey(e => e.ACode);

            entity.ToTable("ARTICLEBackup");

            entity.Property(e => e.ACode)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("A_Code");
            entity.Property(e => e.AName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("A_Name");
            entity.Property(e => e.ExistMandeh).HasColumnName("Exist_Mandeh");
            entity.Property(e => e.SelPrice).HasColumnName("Sel_Price");
            entity.Property(e => e.Weight).HasColumnName("weight");
        });

        modelBuilder.Entity<RepLog>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ReplicationDate).HasColumnType("datetime");
            entity.Property(e => e.ResultStatus).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
