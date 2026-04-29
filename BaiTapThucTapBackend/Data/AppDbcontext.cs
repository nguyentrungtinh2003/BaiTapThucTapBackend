using BaiTapThucTapBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace BaiTapThucTapBackend.Data
{
    public class AppDbcontext : DbContext
    {
        public AppDbcontext(DbContextOptions<AppDbcontext> options) : base(options) { }

        public DbSet<DonViTinh> DonViTinhs { get; set; }
        public DbSet<LoaiSanPham> LoaiSanPhams { get; set; }

        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<NhaCungCap> NhaCungCaps { get; set; }

        public DbSet<Kho> Khos { get; set; }

        public DbSet<KhoUser> KhoUsers { get; set; }

        public DbSet<NhapKho> NhapKhos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonViTinh>()
                .HasIndex(x => x.Ten_Don_Vi_Tinh)
                .IsUnique();

            modelBuilder.Entity<LoaiSanPham>()
                .HasIndex(x => x.Ma_LSP)
                .IsUnique();

            modelBuilder.Entity<LoaiSanPham>()
                .HasIndex(x => x.Ten_LSP)
                .IsUnique();

            modelBuilder.Entity<SanPham>()
                .HasIndex(x => x.Ma_San_Pham)
                .IsUnique();

            modelBuilder.Entity<SanPham>()
                .HasOne(x => x.LoaiSanPham)
                .WithMany()
                .HasForeignKey(x => x.Loai_San_Pham_ID);

            modelBuilder.Entity<SanPham>()
                .HasOne(x => x.DonViTinh)
                .WithMany()
                .HasForeignKey(x => x.Don_Vi_Tinh_ID);

            modelBuilder.Entity<NhaCungCap>()
              .HasIndex(x => x.Ma_NCC)
              .IsUnique();

            modelBuilder.Entity<NhaCungCap>()
             .HasIndex(x => x.Ten_NCC)
             .IsUnique();

            modelBuilder.Entity<Kho>()
                .HasIndex(x => x.Ten_Kho)
                .IsUnique();

            modelBuilder.Entity<NhapKho>()
                .HasIndex(x => x.So_Phieu_Nhap_Kho)
                .IsUnique();

            // 🔥 Key kép (tránh trùng)
            modelBuilder.Entity<KhoUser>()
                .HasKey(x => new { x.User_ID, x.Kho_ID });

            // FK -> User
            modelBuilder.Entity<KhoUser>()
                .HasOne(x => x.User)
                .WithMany(u => u.KhoUsers)
                .HasForeignKey(x => x.User_ID);

            // FK -> Kho
            modelBuilder.Entity<KhoUser>()
                .HasOne(x => x.Kho)
                .WithMany(k => k.KhoUsers)
                .HasForeignKey(x => x.Kho_ID);
        }
    }
}
