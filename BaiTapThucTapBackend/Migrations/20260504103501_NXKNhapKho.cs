using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaiTapThucTapBackend.Migrations
{
    /// <inheritdoc />
    public partial class NXKNhapKho : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "XNKNhapKhos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    So_Phieu_Nhap_Kho = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Kho_ID = table.Column<int>(type: "int", nullable: false),
                    NCC_ID = table.Column<int>(type: "int", nullable: false),
                    Ngay_Nhap_Kho = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ghi_Chu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XNKNhapKhos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_XNKNhapKhos_Khos_Kho_ID",
                        column: x => x.Kho_ID,
                        principalTable: "Khos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_XNKNhapKhos_NhaCungCaps_NCC_ID",
                        column: x => x.NCC_ID,
                        principalTable: "NhaCungCaps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "XNKNhapKhoChiTiets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nhap_Kho_ID = table.Column<int>(type: "int", nullable: false),
                    San_Pham_ID = table.Column<int>(type: "int", nullable: false),
                    SL_Nhap = table.Column<int>(type: "int", nullable: false),
                    Don_Gia_Nhap = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    XNKNhapKhoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XNKNhapKhoChiTiets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_XNKNhapKhoChiTiets_NhapKhos_Nhap_Kho_ID",
                        column: x => x.Nhap_Kho_ID,
                        principalTable: "NhapKhos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_XNKNhapKhoChiTiets_SanPhams_San_Pham_ID",
                        column: x => x.San_Pham_ID,
                        principalTable: "SanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_XNKNhapKhoChiTiets_XNKNhapKhos_XNKNhapKhoId",
                        column: x => x.XNKNhapKhoId,
                        principalTable: "XNKNhapKhos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_XNKNhapKhoChiTiets_Nhap_Kho_ID",
                table: "XNKNhapKhoChiTiets",
                column: "Nhap_Kho_ID");

            migrationBuilder.CreateIndex(
                name: "IX_XNKNhapKhoChiTiets_San_Pham_ID",
                table: "XNKNhapKhoChiTiets",
                column: "San_Pham_ID");

            migrationBuilder.CreateIndex(
                name: "IX_XNKNhapKhoChiTiets_XNKNhapKhoId",
                table: "XNKNhapKhoChiTiets",
                column: "XNKNhapKhoId");

            migrationBuilder.CreateIndex(
                name: "IX_XNKNhapKhos_Kho_ID",
                table: "XNKNhapKhos",
                column: "Kho_ID");

            migrationBuilder.CreateIndex(
                name: "IX_XNKNhapKhos_NCC_ID",
                table: "XNKNhapKhos",
                column: "NCC_ID");

            migrationBuilder.CreateIndex(
                name: "IX_XNKNhapKhos_So_Phieu_Nhap_Kho",
                table: "XNKNhapKhos",
                column: "So_Phieu_Nhap_Kho",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "XNKNhapKhoChiTiets");

            migrationBuilder.DropTable(
                name: "XNKNhapKhos");
        }
    }
}
