using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bbsm_Garage_Son.Migrations
{
    /// <inheritdoc />
    public partial class Düzeltme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "UserEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "username",
                table: "UserEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Aciklama",
                table: "StokEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Adet",
                table: "StokEntity",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "StokEntity",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StokAdi",
                table: "StokEntity",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "UserEntity");

            migrationBuilder.DropColumn(
                name: "username",
                table: "UserEntity");

            migrationBuilder.DropColumn(
                name: "Aciklama",
                table: "StokEntity");

            migrationBuilder.DropColumn(
                name: "Adet",
                table: "StokEntity");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "StokEntity");

            migrationBuilder.DropColumn(
                name: "StokAdi",
                table: "StokEntity");
        }
    }
}
