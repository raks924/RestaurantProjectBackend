using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RestaurantAppProject.Models
{
    public partial class restaurant_appContext : DbContext
    {
        public restaurant_appContext()
        {
        }

        public restaurant_appContext(DbContextOptions<restaurant_appContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CategoryDish> CategoryDishes { get; set; } = null!;
        public virtual DbSet<CategoryTable> CategoryTables { get; set; } = null!;
        public virtual DbSet<DishTable> DishTables { get; set; } = null!;
        public virtual DbSet<MenuCategory> MenuCategories { get; set; } = null!;
        public virtual DbSet<MenuTable> MenuTables { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=M5387468\\SQLEXPRESS; Initial Catalog=restaurant_app; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryDish>(entity =>
            {
                entity.HasKey(e => e.Cdid)
                    .HasName("PK__Category__A80C18E9CC9CE166");

                entity.ToTable("Category_Dish");

                entity.Property(e => e.Cdid).HasColumnName("CDID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.DishId).HasColumnName("DishID");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.CategoryDishes)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Category___Categ__534D60F1");

                entity.HasOne(d => d.Dish)
                    .WithMany(p => p.CategoryDishes)
                    .HasForeignKey(d => d.DishId)
                    .HasConstraintName("FK__Category___DishI__5441852A");
            });

            modelBuilder.Entity<CategoryTable>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__Category__19093A2BE9C55BF8");

                entity.ToTable("Category_table");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CategoryDescription).HasColumnType("text");

                entity.Property(e => e.CategoryImage)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<DishTable>(entity =>
            {
                entity.HasKey(e => e.DishId)
                    .HasName("PK__Dish_tab__18834F705BB035C9");

                entity.ToTable("Dish_table");

                entity.Property(e => e.DishId).HasColumnName("DishID");

                entity.Property(e => e.DishDescription).HasColumnType("text");

                entity.Property(e => e.DishImage)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DishName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DishPrice).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.Nature)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MenuCategory>(entity =>
            {
                entity.HasKey(e => e.Mcid)
                    .HasName("PK__Menu_Cat__60B364103E9C09B0");

                entity.ToTable("Menu_Category");

                entity.Property(e => e.Mcid).HasColumnName("MCID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.MenuId).HasColumnName("MenuID");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.MenuCategories)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Menu_Cate__Categ__5070F446");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.MenuCategories)
                    .HasForeignKey(d => d.MenuId)
                    .HasConstraintName("FK__Menu_Cate__MenuI__4F7CD00D");
            });

            modelBuilder.Entity<MenuTable>(entity =>
            {
                entity.HasKey(e => e.MenuId)
                    .HasName("PK__Menu_tab__C99ED250861CFB94");

                entity.ToTable("Menu_table");

                entity.Property(e => e.MenuId).HasColumnName("MenuID");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.MenuDescription).HasColumnType("text");

                entity.Property(e => e.MenuImage)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MenuName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
