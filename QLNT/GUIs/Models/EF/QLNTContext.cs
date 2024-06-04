using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace GUIs.Models.EF
{
    public partial class QLNTContext : DbContext
    {
        public QLNTContext()
        {
        }

        public QLNTContext(DbContextOptions<QLNTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<AnhMoPhan> AnhMoPhans { get; set; }
        public virtual DbSet<AnhNghiaTrang> AnhNghiaTrangs { get; set; }
        public virtual DbSet<DiaChi> DiaChis { get; set; }
        public virtual DbSet<LietSy> LietSies { get; set; }
        public virtual DbSet<NghiaTrang> NghiaTrangs { get; set; }
        public virtual DbSet<NghiaTrangUser> NghiaTrangUsers { get; set; }
        public virtual DbSet<QuanLy> QuanLies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-CPTPR8L;Initial Catalog=QLNT;Persist Security Info=True;User ID=sa;Password=1; TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Sdt)
                    .HasMaxLength(50)
                    .HasColumnName("SDT");

                entity.Property(e => e.Ten).HasMaxLength(255);

                entity.Property(e => e.TrangThai).HasMaxLength(50);

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<AnhMoPhan>(entity =>
            {
                entity.HasKey(e => e.AnhId)
                    .HasName("PK__AnhMoPha__13C3343EA732F71B");

                entity.ToTable("AnhMoPhan");

                entity.Property(e => e.AnhId).HasColumnName("AnhID");

                entity.Property(e => e.Img).HasMaxLength(255);

                entity.Property(e => e.LietSyId).HasColumnName("LietSyID");

                entity.Property(e => e.MoTa).HasMaxLength(255);

                entity.Property(e => e.TrangThai).HasMaxLength(50);

                entity.HasOne(d => d.LietSy)
                    .WithMany(p => p.AnhMoPhans)
                    .HasForeignKey(d => d.LietSyId)
                    .HasConstraintName("FK__AnhMoPhan__LietS__37A5467C");
            });

            modelBuilder.Entity<AnhNghiaTrang>(entity =>
            {
                entity.HasKey(e => e.AnhId)
                    .HasName("PK__AnhNghia__13C3343E99BAAD66");

                entity.ToTable("AnhNghiaTrang");

                entity.Property(e => e.AnhId).HasColumnName("AnhID");

                entity.Property(e => e.Img).HasMaxLength(255);

                entity.Property(e => e.MoTa).HasMaxLength(255);

                entity.Property(e => e.NghiaTrangId).HasColumnName("NghiaTrangID");

                entity.Property(e => e.TrangThai).HasMaxLength(50);

                entity.HasOne(d => d.NghiaTrang)
                    .WithMany(p => p.AnhNghiaTrangs)
                    .HasForeignKey(d => d.NghiaTrangId)
                    .HasConstraintName("FK__AnhNghiaT__Nghia__2A4B4B5E");
            });

            modelBuilder.Entity<DiaChi>(entity =>
            {
                entity.ToTable("DiaChi");

                entity.Property(e => e.DiaChiId).HasColumnName("DiaChiID");

                entity.Property(e => e.Cap).HasMaxLength(50);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.Ten).HasMaxLength(255);

                entity.Property(e => e.TrangThai).HasMaxLength(50);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK__DiaChi__ParentID__24927208");
            });

            modelBuilder.Entity<LietSy>(entity =>
            {
                entity.ToTable("LietSy");

                entity.Property(e => e.LietSyId).HasColumnName("LietSyID");

                entity.Property(e => e.CapBac).HasMaxLength(50);

                entity.Property(e => e.DiaChiId).HasColumnName("DiaChiID");

                entity.Property(e => e.DonVi).HasMaxLength(255);

                entity.Property(e => e.HoTen).HasMaxLength(255);

                entity.Property(e => e.NgayMat).HasColumnType("date");

                entity.Property(e => e.NgaySinh).HasColumnType("date");

                entity.Property(e => e.NghiaTrangId).HasColumnName("NghiaTrangID");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(50)
                    .HasColumnName("SDT");

                entity.Property(e => e.TinhTrang).HasMaxLength(50);

                entity.Property(e => e.TrangThai).HasMaxLength(50);

                entity.HasOne(d => d.DiaChi)
                    .WithMany(p => p.LietSies)
                    .HasForeignKey(d => d.DiaChiId)
                    .HasConstraintName("FK__LietSy__DiaChiID__34C8D9D1");

                entity.HasOne(d => d.NghiaTrang)
                    .WithMany(p => p.LietSies)
                    .HasForeignKey(d => d.NghiaTrangId)
                    .HasConstraintName("FK__LietSy__NghiaTra__33D4B598");
            });

            modelBuilder.Entity<NghiaTrang>(entity =>
            {
                entity.ToTable("NghiaTrang");

                entity.Property(e => e.NghiaTrangId).HasColumnName("NghiaTrangID");

                entity.Property(e => e.DiaChi).HasMaxLength(255);

                entity.Property(e => e.DiaChiId).HasColumnName("DiaChiID");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Sdt)
                    .HasMaxLength(50)
                    .HasColumnName("SDT");

                entity.Property(e => e.Ten).HasMaxLength(255);

                entity.Property(e => e.TrangThai).HasMaxLength(50);

                entity.HasOne(d => d.DiaChiNavigation)
                    .WithMany(p => p.NghiaTrangs)
                    .HasForeignKey(d => d.DiaChiId)
                    .HasConstraintName("FK__NghiaTran__DiaCh__276EDEB3");
            });

            modelBuilder.Entity<NghiaTrangUser>(entity =>
            {
                entity.ToTable("NghiaTrang_User");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LastUpdateTime).HasColumnType("datetime");

                entity.Property(e => e.NghiaTrangId).HasColumnName("NghiaTrangID");

                entity.Property(e => e.TrangThai).HasMaxLength(50);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.NghiaTrang)
                    .WithMany(p => p.NghiaTrangUsers)
                    .HasForeignKey(d => d.NghiaTrangId)
                    .HasConstraintName("FK__NghiaTran__Nghia__30F848ED");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.NghiaTrangUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__NghiaTran__UserI__300424B4");
            });

            modelBuilder.Entity<QuanLy>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__QuanLy__1788CCACE49E9AF4");

                entity.ToTable("QuanLy");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.DiaChi).HasMaxLength(255);

                entity.Property(e => e.DiaChiId).HasColumnName("DiaChiID");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Sdt)
                    .HasMaxLength(50)
                    .HasColumnName("SDT");

                entity.Property(e => e.Ten).HasMaxLength(255);

                entity.Property(e => e.TrangThai).HasMaxLength(50);

                entity.Property(e => e.Username).HasMaxLength(50);

                entity.HasOne(d => d.DiaChiNavigation)
                    .WithMany(p => p.QuanLies)
                    .HasForeignKey(d => d.DiaChiId)
                    .HasConstraintName("FK__QuanLy__DiaChiID__2D27B809");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
