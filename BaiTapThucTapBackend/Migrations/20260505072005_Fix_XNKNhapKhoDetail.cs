using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaiTapThucTapBackend.Migrations
{
    /// <inheritdoc />
    public partial class Fix_XNKNhapKhoDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_XNKNhapKhoChiTiets_XNKNhapKhos_XNKNhapKhoId",
                table: "XNKNhapKhoChiTiets");

            migrationBuilder.DropIndex(
                name: "IX_XNKNhapKhoChiTiets_XNKNhapKhoId",
                table: "XNKNhapKhoChiTiets");

            migrationBuilder.DropColumn(
                name: "XNKNhapKhoId",
                table: "XNKNhapKhoChiTiets");

            migrationBuilder.CreateIndex(
                name: "IX_XNKNhapKhoChiTiets_XNKNhap_Kho_ID",
                table: "XNKNhapKhoChiTiets",
                column: "XNKNhap_Kho_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_XNKNhapKhoChiTiets_XNKNhapKhos_XNKNhap_Kho_ID",
                table: "XNKNhapKhoChiTiets",
                column: "XNKNhap_Kho_ID",
                principalTable: "XNKNhapKhos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_XNKNhapKhoChiTiets_XNKNhapKhos_XNKNhap_Kho_ID",
                table: "XNKNhapKhoChiTiets");

            migrationBuilder.DropIndex(
                name: "IX_XNKNhapKhoChiTiets_XNKNhap_Kho_ID",
                table: "XNKNhapKhoChiTiets");

            migrationBuilder.AddColumn<int>(
                name: "XNKNhapKhoId",
                table: "XNKNhapKhoChiTiets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_XNKNhapKhoChiTiets_XNKNhapKhoId",
                table: "XNKNhapKhoChiTiets",
                column: "XNKNhapKhoId");

            migrationBuilder.AddForeignKey(
                name: "FK_XNKNhapKhoChiTiets_XNKNhapKhos_XNKNhapKhoId",
                table: "XNKNhapKhoChiTiets",
                column: "XNKNhapKhoId",
                principalTable: "XNKNhapKhos",
                principalColumn: "Id");
        }
    }
}
