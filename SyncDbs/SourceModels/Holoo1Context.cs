using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SyncDbs.SourceModels;

public partial class Holoo1Context : DbContext
{
    public Holoo1Context()
    {
    }

    public Holoo1Context(DbContextOptions<Holoo1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Article> Articles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server=MOSY\\TNC;Database=Holoo1;User Id=alireza;Password=alireza@123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Arabic_CI_AS");

        modelBuilder.Entity<Article>(entity =>
        {
            entity.HasKey(e => e.ACode);

            entity.ToTable("ARTICLE");

            entity.HasIndex(e => e.AName, "A_N");

            entity.HasIndex(e => e.ACodeC, "ArtCode_C");

            entity.HasIndex(e => new { e.AName, e.Model }, "Name_Model");

            entity.Property(e => e.ACode)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("A_Code");
            entity.Property(e => e.ACodeC)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("A_Code_C");
            entity.Property(e => e.ACountry)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("A_Country");
            entity.Property(e => e.AMax).HasColumnName("A_Max");
            entity.Property(e => e.AMaxReq).HasColumnName("A_MaxReq");
            entity.Property(e => e.AMin).HasColumnName("A_Min");
            entity.Property(e => e.AMinReq).HasColumnName("A_MinReq");
            entity.Property(e => e.AName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("A_Name");
            entity.Property(e => e.AbkariOjrat).HasColumnName("Abkari_Ojrat");
            entity.Property(e => e.AnegativeSel).HasColumnName("ANegative_Sel");
            entity.Property(e => e.ArtForKiosk)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.Attribute)
                .HasMaxLength(4000)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.BuyDollar).HasColumnName("Buy_Dollar");
            entity.Property(e => e.BuyPrice).HasColumnName("Buy_Price");
            entity.Property(e => e.CheckResting).HasColumnName("Check_Resting");
            entity.Property(e => e.Comment2)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.ComputerName).HasMaxLength(50);
            entity.Property(e => e.CreationDate)
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.Diamond)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DiamondPrice)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Emerald)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmeraldPrice)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("emeraldPrice");
            entity.Property(e => e.EndBuyPrice).HasColumnName("EndBuy_Price");
            entity.Property(e => e.Endeditdate).HasColumnType("datetime");
            entity.Property(e => e.ExistMandeh).HasColumnName("Exist_Mandeh");
            entity.Property(e => e.Expdate)
                .HasColumnType("datetime")
                .HasColumnName("EXPDate");
            entity.Property(e => e.FilterGroupId)
                .HasMaxLength(3000)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.FinishDate)
                .HasColumnType("datetime")
                .HasColumnName("Finish_Date");
            entity.Property(e => e.FirstBuyPrice).HasColumnName("FirstBuy_Price");
            entity.Property(e => e.FirstExist).HasColumnName("First_exist");
            entity.Property(e => e.FirstExist2).HasColumnName("First_exist2");
            entity.Property(e => e.FirstWeight).HasColumnName("First_Weight");
            entity.Property(e => e.ForoshOjrat).HasColumnName("Forosh_Ojrat");
            entity.Property(e => e.FromModatDate).HasColumnType("datetime");
            entity.Property(e => e.Gold)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IncField).ValueGeneratedOnAdd();
            entity.Property(e => e.IncludeHazHaml).HasColumnName("Include_HazHaml");
            entity.Property(e => e.IncludeTax).HasColumnName("Include_Tax");
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.JCode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("j_Code");
            entity.Property(e => e.JOjrat).HasColumnName("j_Ojrat");
            entity.Property(e => e.KartonCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Karton_Code");
            entity.Property(e => e.MCode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("M_Code");
            entity.Property(e => e.MOjrat).HasColumnName("M_Ojrat");
            entity.Property(e => e.Model)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.MyBuyPrice).HasColumnName("MyBuy_Price");
            entity.Property(e => e.Other)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Other1).HasMaxLength(4000);
            entity.Property(e => e.Other10)
                .HasMaxLength(4000)
                .IsUnicode(false);
            entity.Property(e => e.Other2).HasMaxLength(4000);
            entity.Property(e => e.Other3).HasMaxLength(4000);
            entity.Property(e => e.Other4).HasMaxLength(4000);
            entity.Property(e => e.Other5).HasMaxLength(4000);
            entity.Property(e => e.Other6).HasMaxLength(4000);
            entity.Property(e => e.Other7)
                .HasMaxLength(4000)
                .IsUnicode(false);
            entity.Property(e => e.Other8)
                .HasMaxLength(4000)
                .IsUnicode(false);
            entity.Property(e => e.Other9)
                .HasMaxLength(4000)
                .IsUnicode(false);
            entity.Property(e => e.OtherPrice)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Pearl)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PearlPrice)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Picture)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PicturePath)
                .HasMaxLength(500)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Place)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Platinum)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Pluno).HasColumnName("PLUNo");
            entity.Property(e => e.ReqRadifForAhan)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.ResArtTypeId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Res_ArtTypeId");
            entity.Property(e => e.Ruby)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RubyPrice)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.SakhtOjrat).HasColumnName("Sakht_Ojrat");
            entity.Property(e => e.Saphire)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SaphirePrice)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Scot).HasColumnName("scot");
            entity.Property(e => e.SelDollar).HasColumnName("Sel_Dollar");
            entity.Property(e => e.SelPrice).HasColumnName("Sel_Price");
            entity.Property(e => e.SelPrice10).HasColumnName("Sel_Price10");
            entity.Property(e => e.SelPrice2).HasColumnName("Sel_Price2");
            entity.Property(e => e.SelPrice3).HasColumnName("Sel_Price3");
            entity.Property(e => e.SelPrice4).HasColumnName("Sel_Price4");
            entity.Property(e => e.SelPrice5).HasColumnName("Sel_Price5");
            entity.Property(e => e.SelPrice6).HasColumnName("Sel_Price6");
            entity.Property(e => e.SelPrice7).HasColumnName("Sel_Price7");
            entity.Property(e => e.SelPrice8).HasColumnName("Sel_Price8");
            entity.Property(e => e.SelPrice9).HasColumnName("Sel_Price9");
            entity.Property(e => e.SigarLevy).HasColumnName("Sigar_Levy");
            entity.Property(e => e.SigarScot).HasColumnName("Sigar_Scot");
            entity.Property(e => e.Silver)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TimeService).HasDefaultValueSql("((30))");
            entity.Property(e => e.ToModatDate).HasColumnType("datetime");
            entity.Property(e => e.TolidNum)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.ToolArz).HasColumnName("Tool_Arz");
            entity.Property(e => e.ToolArzType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Turqouise)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TurqouisePrice)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.TypeAnbarC).HasColumnName("Type_Anbar_C");
            entity.Property(e => e.TypeArt).HasDefaultValueSql("((12))");
            entity.Property(e => e.UseInPortable).HasDefaultValueSql("((1))");
            entity.Property(e => e.UserPrice).HasColumnName("User_Price");
            entity.Property(e => e.VafinoDiscountId)
                .HasDefaultValueSql("((0))")
                .HasColumnName("VafinoDiscountID");
            entity.Property(e => e.Weight).HasColumnName("weight");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
