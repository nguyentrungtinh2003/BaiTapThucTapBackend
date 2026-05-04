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

        public DbSet<XNKNhapKho> XNKNhapKhos { get; set; }
        public DbSet<NhapKhoDetail> NhapKhoChiTiets { get; set; }

        public DbSet<XuatKho> XuatKhos { get; set; }

        public DbSet<XNKNhapKhoDetail> XNKNhapKhoChiTiets { get; set; }
        public DbSet<XuatKhoDetail> XuatKhoChiTiets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Unique
            modelBuilder.Entity<DonViTinh>()
                .HasIndex(x => x.Ten_Don_Vi_Tinh).IsUnique();

            modelBuilder.Entity<LoaiSanPham>()
                .HasIndex(x => x.Ma_LSP).IsUnique();

            modelBuilder.Entity<LoaiSanPham>()
                .HasIndex(x => x.Ten_LSP).IsUnique();

            modelBuilder.Entity<SanPham>()
                .HasIndex(x => x.Ma_San_Pham).IsUnique();

            modelBuilder.Entity<NhaCungCap>()
                .HasIndex(x => x.Ten_NCC).IsUnique();

            modelBuilder.Entity<Kho>()
                .HasIndex(x => x.Ten_Kho).IsUnique();

            modelBuilder.Entity<NhapKho>()
                .HasIndex(x => x.So_Phieu_Nhap_Kho).IsUnique();

            modelBuilder.Entity<XNKNhapKho>().HasIndex(x => x.So_Phieu_Nhap_Kho).IsUnique();

            modelBuilder.Entity<XuatKho>()
                .HasIndex(x => x.So_Phieu_Xuat_Kho).IsUnique();

            // Composite key
            modelBuilder.Entity<KhoUser>()
                .HasIndex(x => new { x.Ma_Dang_Nhap, x.Kho_ID })
                .IsUnique();
        }
    }
}
