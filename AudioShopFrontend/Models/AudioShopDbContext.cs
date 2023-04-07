using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AudioShopFrontend.Models;

public partial class AudioShopDbContext : DbContext
{
    public AudioShopDbContext()
    {
    }

    public AudioShopDbContext(DbContextOptions<AudioShopDbContext> options)
        : base(options)
    {
    }
    public virtual DbSet<Blog> Blogs { get; set; }

    public virtual DbSet<BlogCategory> BlogCategories { get; set; }

    public virtual DbSet<BlogComment> BlogComments { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Favorite> Favorites { get; set; }

    public virtual DbSet<File> Files { get; set; }

    public virtual DbSet<Link> Links { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Setting> Settings { get; set; }

    public virtual DbSet<Ship> Ships { get; set; }

    public virtual DbSet<ShipPrice> ShipPrices { get; set; }

    public virtual DbSet<Type> Types { get; set; }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<State> States { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
.AddJsonFile("appsettings.json")
.Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>(entity =>
        {
            entity.HasKey(e => e.NidBlog);

            entity.Property(e => e.NidBlog).ValueGeneratedNever();
            entity.Property(e => e.Contents).HasColumnType("ntext");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.PersianCreateDate)
                .HasMaxLength(30);
            //.HasComputedColumnSql("([dbo].[GeorgianDateToPersianDate]([CreateDate]))", false);
            entity.Property(e => e.PersianLastModified)
                .HasMaxLength(30);
            //.HasComputedColumnSql("([dbo].[GeorgianDateToPersianDate]([LastModified]))", false);
            entity.Property(e => e.Title).HasMaxLength(1000);

            entity.HasOne(d => d.Category).WithMany(p => p.Blogs)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Blogs_BlogCategories");

            entity.HasOne(d => d.User).WithMany(p => p.Blogs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Blogs_Users");
        });

        modelBuilder.Entity<BlogCategory>(entity =>
        {
            entity.HasKey(e => e.NidCategory).HasName("PK_BolgCategories");

            entity.Property(e => e.NidCategory).ValueGeneratedNever();
            entity.Property(e => e.CategoryName).HasMaxLength(500);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.PersianCreateDate)
                .HasMaxLength(30);
            //.HasComputedColumnSql("([dbo].[GeorgianDateToPersianDate]([CreateDate]))", false);
            entity.Property(e => e.PersianLastModified)
                .HasMaxLength(30);
            //.HasComputedColumnSql("([dbo].[GeorgianDateToPersianDate]([LastModified]))", false);
        });

        modelBuilder.Entity<BlogComment>(entity =>
        {
            entity.HasKey(e => e.NidComment);

            entity.Property(e => e.NidComment).ValueGeneratedNever();
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.PersianCreateDate)
                .HasMaxLength(30);
            //.HasComputedColumnSql("([dbo].[GeorgianDateToPersianDate]([CreateDate]))", false);

            entity.HasOne(d => d.Blog).WithMany(p => p.BlogComments)
                .HasForeignKey(d => d.BlogId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BlogComments_Blogs");

            entity.HasOne(d => d.User).WithMany(p => p.BlogComments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BlogComments_Users");
        });

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.NidBrand);

            entity.Property(e => e.NidBrand).ValueGeneratedNever();
            entity.Property(e => e.BrandName).HasMaxLength(500);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.PersianCreateDate)
                .HasMaxLength(30);
            //.HasComputedColumnSql("([dbo].[GeorgianDateToPersianDate]([CreateDate]))", false);
            entity.Property(e => e.PersianLastModified)
                .HasMaxLength(30);
            //.HasComputedColumnSql("([dbo].[GeorgianDateToPersianDate]([LastModified]))", false);

            entity.HasOne(d => d.Category).WithMany(p => p.Brands)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Brands_Categories");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.NidCart);

            entity.Property(e => e.NidCart).ValueGeneratedNever();
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.PersianCreateDate)
                .HasMaxLength(30);
            //.HasComputedColumnSql("([dbo].[GeorgianDateToPersianDate]([CreateDate]))", false);
            entity.Property(e => e.PersianLastModified)
                .HasMaxLength(30);
            //.HasComputedColumnSql("([dbo].[GeorgianDateToPersianDate]([LastModified]))", false);
            entity.Property(e => e.Quantity).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.Product).WithMany(p => p.Carts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Carts_Products");

            entity.HasOne(d => d.User).WithMany(p => p.Carts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Carts_Users");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.NidCategory);

            entity.Property(e => e.NidCategory).ValueGeneratedNever();
            entity.Property(e => e.CategoryName).HasMaxLength(500);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.PersianCreateDate)
                .HasMaxLength(30);
            //.HasComputedColumnSql("([dbo].[GeorgianDateToPersianDate]([CreateDate]))", false);
            entity.Property(e => e.PersianLastModified)
                .HasMaxLength(30);
            //.HasComputedColumnSql("([dbo].[GeorgianDateToPersianDate]([LastModified]))", false);
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.NidComment);

            entity.Property(e => e.NidComment).ValueGeneratedNever();
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.PersianCreateDate)
                .HasMaxLength(30);
            //.HasComputedColumnSql("([dbo].[GeorgianDateToPersianDate]([CreateDate]))", false);

            entity.HasOne(d => d.Product).WithMany(p => p.Comments)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comments_Products");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comments_Users");
        });

        modelBuilder.Entity<Favorite>(entity =>
        {
            entity.HasKey(e => e.NidFav);

            entity.Property(e => e.NidFav).ValueGeneratedNever();
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.PersianCreateDate)
                .HasMaxLength(30);
            //.HasComputedColumnSql("([dbo].[GeorgianDateToPersianDate]([CreateDate]))", false);

            entity.HasOne(d => d.Product).WithMany(p => p.Favorites)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Favorites_Products");

            entity.HasOne(d => d.User).WithMany(p => p.Favorites)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Favorites_Users");
        });

        modelBuilder.Entity<File>(entity =>
        {
            entity.HasKey(e => e.NidFile);

            entity.Property(e => e.NidFile).ValueGeneratedNever();
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.FileExtension).HasMaxLength(10);
            entity.Property(e => e.FileName).HasMaxLength(150);
            entity.Property(e => e.PersianCreateDate)
                .HasMaxLength(30);
            //.HasComputedColumnSql("([dbo].[GeorgianDateToPersianDate]([CreateDate]))", false);
        });

        modelBuilder.Entity<Link>(entity =>
        {
            entity.HasKey(e => e.NidLink);

            entity.Property(e => e.NidLink).ValueGeneratedNever();

            entity.HasOne(d => d.Relate).WithMany(p => p.Links)
                .HasForeignKey(d => d.RelateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Links_Products");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.NidOrder);

            entity.Property(e => e.NidOrder).ValueGeneratedNever();
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.MelliCode).HasColumnType("decimal(12, 0)");
            entity.Property(e => e.PersianCreateDate)
                .HasMaxLength(30);
            //.HasComputedColumnSql("([dbo].[GeorgianDateToPersianDate]([CreateDate]))", false);
            entity.Property(e => e.PersianLastModified)
                .HasMaxLength(30);
            //.HasComputedColumnSql("([dbo].[GeorgianDateToPersianDate]([LastModified]))", false);
            entity.Property(e => e.Tel).HasMaxLength(25);
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(12, 0)");
            entity.Property(e => e.ZipCode).HasColumnType("decimal(12, 0)");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Users");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.NidDetail);

            entity.Property(e => e.NidDetail).ValueGeneratedNever();
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.PersianCreateDate)
                .HasMaxLength(30);
            //.HasComputedColumnSql("([dbo].[GeorgianDateToPersianDate]([CreateDate]))", false);
            entity.Property(e => e.PersianLastModified)
                .HasMaxLength(30);
            //.HasComputedColumnSql("([dbo].[GeorgianDateToPersianDate]([LastModified]))", false);
            entity.Property(e => e.Quantity).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetails_Orders");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetails_Products");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.NidProduct);

            entity.Property(e => e.NidProduct).ValueGeneratedNever();
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.PersianCreateDate)
                .HasMaxLength(30);
            //.HasComputedColumnSql("([dbo].[GeorgianDateToPersianDate]([CreateDate]))", false);
            entity.Property(e => e.PersianLastModified)
                .HasMaxLength(30);
            //.HasComputedColumnSql("([dbo].[GeorgianDateToPersianDate]([LastModified]))", false);
            entity.Property(e => e.Price).HasColumnType("decimal(12, 0)");
            entity.Property(e => e.PriceWithoutOff).HasColumnType("decimal(12, 0)");
            entity.Property(e => e.ProductName).HasMaxLength(1000);
            entity.Property(e => e.Rating).HasDefaultValueSql("((3))");
            entity.Property(e => e.Weight).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.Brand).WithMany(p => p.Products)
                .HasForeignKey(d => d.BrandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Brands");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Categories");

            entity.HasOne(d => d.Type).WithMany(p => p.Products)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Types");

            entity.HasOne(d => d.User).WithMany(p => p.Products)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Users");
        });

        modelBuilder.Entity<Setting>(entity =>
        {
            entity.HasKey(e => e.NidSetting);

            entity.Property(e => e.NidSetting).ValueGeneratedNever();
        });

        modelBuilder.Entity<Ship>(entity =>
        {
            entity.HasKey(e => e.NidShip);

            entity.Property(e => e.NidShip).ValueGeneratedNever();
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.DueDate).HasColumnType("datetime");
            entity.Property(e => e.PersianCreateDate)
                .HasMaxLength(30);
            //.HasComputedColumnSql("([dbo].[GeorgianDateToPersianDate]([CreateDate]))", false);
            entity.Property(e => e.PersianDueDate)
                .HasMaxLength(30);
            //.HasComputedColumnSql("([dbo].[GeorgianDateToPersianDate]([DueDate]))", false);
            entity.Property(e => e.ShipPrice).HasColumnType("decimal(12, 0)");
            entity.Property(e => e.ZipCode).HasColumnType("decimal(12, 0)");

            entity.HasOne(d => d.Order).WithMany(p => p.Ships)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ships_Orders");
        });

        modelBuilder.Entity<ShipPrice>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.InnerState).HasColumnType("decimal(12, 0)");
            entity.Property(e => e.NeighborState).HasColumnType("decimal(12, 0)");
            entity.Property(e => e.OtherState).HasColumnType("decimal(12, 0)");
        });

        modelBuilder.Entity<Type>(entity =>
        {
            entity.HasKey(e => e.NidType);

            entity.Property(e => e.NidType).ValueGeneratedNever();
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.PersianCreateDate)
                .HasMaxLength(30);
            //.HasComputedColumnSql("([dbo].[GeorgianDateToPersianDate]([CreateDate]))", false);
            entity.Property(e => e.PersianLastModified)
                .HasMaxLength(30);
            //.HasComputedColumnSql("([dbo].[GeorgianDateToPersianDate]([LastModified]))", false);
            entity.Property(e => e.TypeName).HasMaxLength(500);

            entity.HasOne(d => d.Category).WithMany(p => p.Types)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Types_Categories");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.NidUser);

            entity.Property(e => e.NidUser).ValueGeneratedNever();
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastLoginDate).HasColumnType("datetime");
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.PersianCreateDate)
                .HasMaxLength(30);
            //.HasComputedColumnSql("([dbo].[GeorgianDateToPersianDate]([CreateDate]))", false);
            entity.Property(e => e.PersianLastLoginDate)
                .HasMaxLength(30);
            //.HasComputedColumnSql("([dbo].[GeorgianDateToPersianDate]([LastLoginDate]))", false);
            entity.Property(e => e.Tel).HasMaxLength(25);
            entity.Property(e => e.Username).HasMaxLength(100);
            entity.Property(e => e.ZipCode).HasColumnType("decimal(12, 0)");
        });
        modelBuilder.Entity<Brand>().Property(e => e.PersianCreateDate).Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
        modelBuilder.Entity<Brand>().Property(e => e.PersianLastModified).Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
        modelBuilder.Entity<Category>().Property(e => e.PersianCreateDate).Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
        modelBuilder.Entity<Category>().Property(e => e.PersianLastModified).Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
        modelBuilder.Entity<Comment>().Property(e => e.PersianCreateDate).Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
        modelBuilder.Entity<File>().Property(e => e.PersianCreateDate).Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
        modelBuilder.Entity<Order>().Property(e => e.PersianCreateDate).Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
        modelBuilder.Entity<Order>().Property(e => e.PersianLastModified).Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
        modelBuilder.Entity<OrderDetail>().Property(e => e.PersianCreateDate).Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
        modelBuilder.Entity<OrderDetail>().Property(e => e.PersianLastModified).Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
        modelBuilder.Entity<Product>().Property(e => e.PersianCreateDate).Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
        modelBuilder.Entity<Product>().Property(e => e.PersianLastModified).Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
        modelBuilder.Entity<Ship>().Property(e => e.PersianCreateDate).Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
        modelBuilder.Entity<Ship>().Property(e => e.PersianDueDate).Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
        modelBuilder.Entity<Type>().Property(e => e.PersianCreateDate).Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
        modelBuilder.Entity<Type>().Property(e => e.PersianLastModified).Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
        modelBuilder.Entity<User>().Property(e => e.PersianCreateDate).Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
        modelBuilder.Entity<User>().Property(e => e.PersianLastLoginDate).Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
        modelBuilder.Entity<Cart>().Property(e => e.PersianCreateDate).Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
        modelBuilder.Entity<Cart>().Property(e => e.PersianLastModified).Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
        modelBuilder.Entity<Favorite>().Property(e => e.PersianCreateDate).Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
        modelBuilder.Entity<BlogCategory>().Property(e => e.PersianCreateDate).Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
        modelBuilder.Entity<BlogCategory>().Property(e => e.PersianLastModified).Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
        modelBuilder.Entity<BlogComment>().Property(e => e.PersianCreateDate).Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
        modelBuilder.Entity<Blog>().Property(e => e.PersianCreateDate).Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
        modelBuilder.Entity<Blog>().Property(e => e.PersianLastModified).Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
        modelBuilder.Entity<City>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(500);

            entity.HasOne(d => d.State).WithMany(p => p.Cities)
                .HasForeignKey(d => d.StateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cities_States");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(500);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
