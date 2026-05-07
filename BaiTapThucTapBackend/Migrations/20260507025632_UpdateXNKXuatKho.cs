using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaiTapThucTapBackend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateXNKXuatKho : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "XNKXuatKhoId",
                table: "XuatKhoChiTiets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "XNKXuatKhos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Xuat_Kho_ID = table.Column<int>(type: "int", nullable: false),
                    So_Phieu_Xuat_Kho = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kho_ID = table.Column<int>(type: "int", nullable: false),
                    Ngay_Xuat_Kho = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ghi_Chu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsLatest = table.Column<bool>(type: "bit", nullable: false),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XNKXuatKhos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_XNKXuatKhos_Khos_Kho_ID",
                        column: x => x.Kho_ID,
                        principalTable: "Khos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_XNKXuatKhos_XuatKhos_Xuat_Kho_ID",
                        column: x => x.Xuat_Kho_ID,
                        principalTable: "XuatKhos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "XNKXuatKhoChiTiets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    XNKXuat_Kho_ID = table.Column<int>(type: "int", nullable: false),
                    San_Pham_ID = table.Column<int>(type: "int", nullable: false),
                    SL_Xuat = table.Column<int>(type: "int", nullable: false),
                    Don_Gia_Xuat = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XNKXuatKhoChiTiets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_XNKXuatKhoChiTiets_SanPhams_San_Pham_ID",
                        column: x => x.San_Pham_ID,
                        principalTable: "SanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_XNKXuatKhoChiTiets_XNKXuatKhos_XNKXuat_Kho_ID",
                        column: x => x.XNKXuat_Kho_ID,
                        principalTable: "XNKXuatKhos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_XuatKhoChiTiets_XNKXuatKhoId",
                table: "XuatKhoChiTiets",
                column: "XNKXuatKhoId");

            migrationBuilder.CreateIndex(
                name: "IX_XNKXuatKhoChiTiets_San_Pham_ID",
                table: "XNKXuatKhoChiTiets",
                column: "San_Pham_ID");

            migrationBuilder.CreateIndex(
                name: "IX_XNKXuatKhoChiTiets_XNKXuat_Kho_ID",
                table: "XNKXuatKhoChiTiets",
                column: "XNKXuat_Kho_ID");

            migrationBuilder.CreateIndex(
                name: "IX_XNKXuatKhos_Kho_ID",
                table: "XNKXuatKhos",
                column: "Kho_ID");

            migrationBuilder.CreateIndex(
                name: "IX_XNKXuatKhos_Xuat_Kho_ID",
                table: "XNKXuatKhos",
                column: "Xuat_Kho_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_XuatKhoChiTiets_XNKXuatKhos_XNKXuatKhoId",
                table: "XuatKhoChiTiets",
                column: "XNKXuatKhoId",
                principalTable: "XNKXuatKhos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_XuatKhoChiTiets_XNKXuatKhos_XNKXuatKhoId",
                table: "XuatKhoChiTiets");

            migrationBuilder.DropTable(
                name: "XNKXuatKhoChiTiets");

            migrationBuilder.DropTable(
                name: "XNKXuatKhos");

            migrationBuilder.DropIndex(
                name: "IX_XuatKhoChiTiets_XNKXuatKhoId",
                table: "XuatKhoChiTiets");

            migrationBuilder.DropColumn(
                name: "XNKXuatKhoId",
                table: "XuatKhoChiTiets");
        }
    }
}
