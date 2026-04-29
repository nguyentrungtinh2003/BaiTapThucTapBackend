using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaiTapThucTapBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NhapKhoDetail_NhapKhos_NhapKhoId",
                table: "NhapKhoDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_NhapKhoDetail_SanPhams_SanPhamId",
                table: "NhapKhoDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_NhapKhos_Khos_KhoId",
                table: "NhapKhos");

            migrationBuilder.DropForeignKey(
                name: "FK_NhapKhos_NhaCungCaps_NhaCungCapId",
                table: "NhapKhos");

            migrationBuilder.DropIndex(
                name: "IX_NhapKhos_KhoId",
                table: "NhapKhos");

            migrationBuilder.DropIndex(
                name: "IX_NhapKhos_NhaCungCapId",
                table: "NhapKhos");

            migrationBuilder.DropIndex(
                name: "IX_NhapKhos_So_Phieu_Nhap_Kho",
                table: "NhapKhos");

            migrationBuilder.DropIndex(
                name: "IX_NhapKhoDetail_NhapKhoId",
                table: "NhapKhoDetail");

            migrationBuilder.DropIndex(
                name: "IX_NhapKhoDetail_SanPhamId",
                table: "NhapKhoDetail");

            migrationBuilder.DropIndex(
                name: "IX_NhaCungCaps_Ma_NCC",
                table: "NhaCungCaps");

            migrationBuilder.DropIndex(
                name: "IX_NhaCungCaps_Ten_NCC",
                table: "NhaCungCaps");

            migrationBuilder.DropIndex(
                name: "IX_LoaiSanPhams_Ma_LSP",
                table: "LoaiSanPhams");

            migrationBuilder.DropIndex(
                name: "IX_LoaiSanPhams_Ten_LSP",
                table: "LoaiSanPhams");

            migrationBuilder.DropIndex(
                name: "IX_KhoUsers_Kho_ID",
                table: "KhoUsers");

            migrationBuilder.DropIndex(
                name: "IX_KhoUsers_User_ID",
                table: "KhoUsers");

            migrationBuilder.DropColumn(
                name: "KhoId",
                table: "NhapKhos");

            migrationBuilder.DropColumn(
                name: "NhaCungCapId",
                table: "NhapKhos");

            migrationBuilder.DropColumn(
                name: "NhapKhoId",
                table: "NhapKhoDetail");

            migrationBuilder.DropColumn(
                name: "SanPhamId",
                table: "NhapKhoDetail");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Mat_Khau",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Ma_Dang_Nhap",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "So_Phieu_Nhap_Kho",
                table: "NhapKhos",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "NhaCungCap_ID",
                table: "NhapKhos",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ten_NCC",
                table: "NhaCungCaps",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Ma_NCC",
                table: "NhaCungCaps",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Ghi_Chu",
                table: "NhaCungCaps",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Ten_LSP",
                table: "LoaiSanPhams",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Ma_LSP",
                table: "LoaiSanPhams",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Ghi_Chu",
                table: "Khos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Ghi_Chu",
                table: "DonViTinhs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_NhapKhos_Kho_ID",
                table: "NhapKhos",
                column: "Kho_ID");

            migrationBuilder.CreateIndex(
                name: "IX_NhapKhos_NhaCungCap_ID",
                table: "NhapKhos",
                column: "NhaCungCap_ID");

            migrationBuilder.CreateIndex(
                name: "IX_NhapKhos_So_Phieu_Nhap_Kho",
                table: "NhapKhos",
                column: "So_Phieu_Nhap_Kho",
                unique: true,
                filter: "[So_Phieu_Nhap_Kho] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_NhapKhoDetail_Nhap_Kho_ID",
                table: "NhapKhoDetail",
                column: "Nhap_Kho_ID");

            migrationBuilder.CreateIndex(
                name: "IX_NhapKhoDetail_San_Pham_ID",
                table: "NhapKhoDetail",
                column: "San_Pham_ID");

            migrationBuilder.CreateIndex(
                name: "IX_NhaCungCaps_Ma_NCC",
                table: "NhaCungCaps",
                column: "Ma_NCC",
                unique: true,
                filter: "[Ma_NCC] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_NhaCungCaps_Ten_NCC",
                table: "NhaCungCaps",
                column: "Ten_NCC",
                unique: true,
                filter: "[Ten_NCC] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiSanPhams_Ma_LSP",
                table: "LoaiSanPhams",
                column: "Ma_LSP",
                unique: true,
                filter: "[Ma_LSP] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiSanPhams_Ten_LSP",
                table: "LoaiSanPhams",
                column: "Ten_LSP",
                unique: true,
                filter: "[Ten_LSP] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_KhoUsers_Kho_ID",
                table: "KhoUsers",
                column: "Kho_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_NhapKhoDetail_NhapKhos_Nhap_Kho_ID",
                table: "NhapKhoDetail",
                column: "Nhap_Kho_ID",
                principalTable: "NhapKhos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NhapKhoDetail_SanPhams_San_Pham_ID",
                table: "NhapKhoDetail",
                column: "San_Pham_ID",
                principalTable: "SanPhams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NhapKhos_Khos_Kho_ID",
                table: "NhapKhos",
                column: "Kho_ID",
                principalTable: "Khos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NhapKhos_NhaCungCaps_NhaCungCap_ID",
                table: "NhapKhos",
                column: "NhaCungCap_ID",
                principalTable: "NhaCungCaps",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NhapKhoDetail_NhapKhos_Nhap_Kho_ID",
                table: "NhapKhoDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_NhapKhoDetail_SanPhams_San_Pham_ID",
                table: "NhapKhoDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_NhapKhos_Khos_Kho_ID",
                table: "NhapKhos");

            migrationBuilder.DropForeignKey(
                name: "FK_NhapKhos_NhaCungCaps_NhaCungCap_ID",
                table: "NhapKhos");

            migrationBuilder.DropIndex(
                name: "IX_NhapKhos_Kho_ID",
                table: "NhapKhos");

            migrationBuilder.DropIndex(
                name: "IX_NhapKhos_NhaCungCap_ID",
                table: "NhapKhos");

            migrationBuilder.DropIndex(
                name: "IX_NhapKhos_So_Phieu_Nhap_Kho",
                table: "NhapKhos");

            migrationBuilder.DropIndex(
                name: "IX_NhapKhoDetail_Nhap_Kho_ID",
                table: "NhapKhoDetail");

            migrationBuilder.DropIndex(
                name: "IX_NhapKhoDetail_San_Pham_ID",
                table: "NhapKhoDetail");

            migrationBuilder.DropIndex(
                name: "IX_NhaCungCaps_Ma_NCC",
                table: "NhaCungCaps");

            migrationBuilder.DropIndex(
                name: "IX_NhaCungCaps_Ten_NCC",
                table: "NhaCungCaps");

            migrationBuilder.DropIndex(
                name: "IX_LoaiSanPhams_Ma_LSP",
                table: "LoaiSanPhams");

            migrationBuilder.DropIndex(
                name: "IX_LoaiSanPhams_Ten_LSP",
                table: "LoaiSanPhams");

            migrationBuilder.DropIndex(
                name: "IX_KhoUsers_Kho_ID",
                table: "KhoUsers");

            migrationBuilder.DropColumn(
                name: "NhaCungCap_ID",
                table: "NhapKhos");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Mat_Khau",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ma_Dang_Nhap",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "So_Phieu_Nhap_Kho",
                table: "NhapKhos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KhoId",
                table: "NhapKhos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NhaCungCapId",
                table: "NhapKhos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NhapKhoId",
                table: "NhapKhoDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SanPhamId",
                table: "NhapKhoDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Ten_NCC",
                table: "NhaCungCaps",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ma_NCC",
                table: "NhaCungCaps",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ghi_Chu",
                table: "NhaCungCaps",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ten_LSP",
                table: "LoaiSanPhams",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ma_LSP",
                table: "LoaiSanPhams",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ghi_Chu",
                table: "Khos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ghi_Chu",
                table: "DonViTinhs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
                name: "IX_NhapKhoDetail_NhapKhoId",
                table: "NhapKhoDetail",
                column: "NhapKhoId");

            migrationBuilder.CreateIndex(
                name: "IX_NhapKhoDetail_SanPhamId",
                table: "NhapKhoDetail",
                column: "SanPhamId");

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
                name: "IX_KhoUsers_Kho_ID",
                table: "KhoUsers",
                column: "Kho_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KhoUsers_User_ID",
                table: "KhoUsers",
                column: "User_ID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_NhapKhoDetail_NhapKhos_NhapKhoId",
                table: "NhapKhoDetail",
                column: "NhapKhoId",
                principalTable: "NhapKhos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NhapKhoDetail_SanPhams_SanPhamId",
                table: "NhapKhoDetail",
                column: "SanPhamId",
                principalTable: "SanPhams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NhapKhos_Khos_KhoId",
                table: "NhapKhos",
                column: "KhoId",
                principalTable: "Khos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NhapKhos_NhaCungCaps_NhaCungCapId",
                table: "NhapKhos",
                column: "NhaCungCapId",
                principalTable: "NhaCungCaps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
