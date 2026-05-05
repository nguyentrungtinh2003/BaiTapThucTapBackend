using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaiTapThucTapBackend.Migrations
{
    /// <inheritdoc />
    public partial class Fix_XNKNhapKho_Relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_XNKNhapKhoChiTiets_NhapKhos_Nhap_Kho_ID",
                table: "XNKNhapKhoChiTiets");

            migrationBuilder.DropIndex(
                name: "IX_XNKNhapKhoChiTiets_Nhap_Kho_ID",
                table: "XNKNhapKhoChiTiets");

            migrationBuilder.RenameColumn(
                name: "Nhap_Kho_ID",
                table: "XNKNhapKhoChiTiets",
                newName: "XNKNhap_Kho_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "XNKNhap_Kho_ID",
                table: "XNKNhapKhoChiTiets",
                newName: "Nhap_Kho_ID");

            migrationBuilder.CreateIndex(
                name: "IX_XNKNhapKhoChiTiets_Nhap_Kho_ID",
                table: "XNKNhapKhoChiTiets",
                column: "Nhap_Kho_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_XNKNhapKhoChiTiets_NhapKhos_Nhap_Kho_ID",
                table: "XNKNhapKhoChiTiets",
                column: "Nhap_Kho_ID",
                principalTable: "NhapKhos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
