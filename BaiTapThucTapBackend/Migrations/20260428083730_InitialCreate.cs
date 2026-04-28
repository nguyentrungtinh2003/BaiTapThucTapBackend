using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaiTapThucTapBackend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DonViTinhs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten_Don_Vi_Tinh = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ghi_Chu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonViTinhs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Khos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten_Kho = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ghi_Chu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiSanPhams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ma_LSP = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ten_LSP = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ghi_Chu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiSanPhams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NhaCungCaps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ma_NCC = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ten_NCC = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ghi_Chu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhaCungCaps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ma_Dang_Nhap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mat_Khau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SanPhams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ma_San_Pham = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ten_San_Pham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Loai_San_Pham_ID = table.Column<int>(type: "int", nullable: false),
                    Don_Vi_Tinh_ID = table.Column<int>(type: "int", nullable: false),
                    Ghi_Chu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SanPhams_DonViTinhs_Don_Vi_Tinh_ID",
                        column: x => x.Don_Vi_Tinh_ID,
                        principalTable: "DonViTinhs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SanPhams_LoaiSanPhams_Loai_San_Pham_ID",
                        column: x => x.Loai_San_Pham_ID,
                        principalTable: "LoaiSanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NhapKhos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    So_Phieu_Nhap_Kho = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Kho_ID = table.Column<int>(type: "int", nullable: false),
                    NCC_ID = table.Column<int>(type: "int", nullable: false),
                    Ngay_Nhap_Kho = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ghi_Chu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KhoId = table.Column<int>(type: "int", nullable: false),
                    NhaCungCapId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhapKhos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NhapKhos_Khos_KhoId",
                        column: x => x.KhoId,
                        principalTable: "Khos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NhapKhos_NhaCungCaps_NhaCungCapId",
                        column: x => x.NhaCungCapId,
                        principalTable: "NhaCungCaps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KhoUsers",
                columns: table => new
                {
                    User_ID = table.Column<int>(type: "int", nullable: false),
                    Kho_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhoUsers", x => new { x.User_ID, x.Kho_ID });
                    table.ForeignKey(
                        name: "FK_KhoUsers_Khos_Kho_ID",
                        column: x => x.Kho_ID,
                        principalTable: "Khos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KhoUsers_User_User_ID",
                        column: x => x.User_ID,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NhapKhoDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nhap_Kho_ID = table.Column<int>(type: "int", nullable: false),
                    San_Pham_ID = table.Column<int>(type: "int", nullable: false),
                    SL_Nhap = table.Column<int>(type: "int", nullable: false),
                    Don_Gia_Nhap = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NhapKhoId = table.Column<int>(type: "int", nullable: false),
                    SanPhamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhapKhoDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NhapKhoDetail_NhapKhos_NhapKhoId",
                        column: x => x.NhapKhoId,
                        principalTable: "NhapKhos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NhapKhoDetail_SanPhams_SanPhamId",
                        column: x => x.SanPhamId,
                        principalTable: "SanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DonViTinhs_Ten_Don_Vi_Tinh",
                table: "DonViTinhs",
                column: "Ten_Don_Vi_Tinh",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Khos_Ten_Kho",
                table: "Khos",
                column: "Ten_Kho",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KhoUsers_Kho_ID",
                table: "KhoUsers",
                column: "Kho_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KhoUsers_User_ID",
                table: "KhoUsers",
                column: "User_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoaiSanPhams_Ma_LSP",
                table: "LoaiSanPhams",
                column: "Ma_LSP",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoaiSanPhams_Ten_LSP",
                table: "LoaiSanPhams",
                column: "Ten_LSP",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NhaCungCaps_Ma_NCC",
                table: "NhaCungCaps",
                column: "Ma_NCC",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NhaCungCaps_Ten_NCC",
                table: "NhaCungCaps",
                column: "Ten_NCC",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NhapKhoDetail_NhapKhoId",
                table: "NhapKhoDetail",
                column: "NhapKhoId");

            migrationBuilder.CreateIndex(
                name: "IX_NhapKhoDetail_SanPhamId",
                table: "NhapKhoDetail",
                column: "SanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_NhapKhos_KhoId",
                table: "NhapKhos",
                column: "KhoId");

            migrationBuilder.CreateIndex(
                name: "IX_NhapKhos_NhaCungCapId",
                table: "NhapKhos",
                column: "NhaCungCapId");

            migrationBuilder.CreateIndex(
                name: "IX_NhapKhos_So_Phieu_Nhap_Kho",
                table: "NhapKhos",
                column: "So_Phieu_Nhap_Kho",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_Don_Vi_Tinh_ID",
                table: "SanPhams",
                column: "Don_Vi_Tinh_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_Loai_San_Pham_ID",
                table: "SanPhams",
                column: "Loai_San_Pham_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_Ma_San_Pham",
                table: "SanPhams",
                column: "Ma_San_Pham",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KhoUsers");

            migrationBuilder.DropTable(
                name: "NhapKhoDetail");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "NhapKhos");

            migrationBuilder.DropTable(
                name: "SanPhams");

            migrationBuilder.DropTable(
                name: "Khos");

            migrationBuilder.DropTable(
                name: "NhaCungCaps");

            migrationBuilder.DropTable(
                name: "DonViTinhs");

            migrationBuilder.DropTable(
                name: "LoaiSanPhams");
        }
    }
}
