using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Bbsm_Garage_Son.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CardEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AdSoyad = table.Column<string>(type: "text", nullable: true),
                    TelNo = table.Column<string>(type: "text", nullable: true),
                    MarkaModel = table.Column<string>(type: "text", nullable: true),
                    GirisTarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Plaka = table.Column<string>(type: "text", nullable: true),
                    Km = table.Column<int>(type: "integer", nullable: false),
                    Sasi = table.Column<string>(type: "text", nullable: true),
                    ModelYili = table.Column<string>(type: "text", nullable: true),
                    Renk = table.Column<string>(type: "text", nullable: true),
                    Adres = table.Column<string>(type: "text", nullable: true),
                    Notlar = table.Column<string>(type: "text", nullable: true),
                    UserEntityId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardEntity_UserEntity_UserEntityId",
                        column: x => x.UserEntityId,
                        principalTable: "UserEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StokEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserEntityId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StokEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StokEntity_UserEntity_UserEntityId",
                        column: x => x.UserEntityId,
                        principalTable: "UserEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardTwoStageEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    birimAdedi = table.Column<int>(type: "integer", nullable: true),
                    parcaAdi = table.Column<string>(type: "text", nullable: true),
                    birimFiyati = table.Column<int>(type: "integer", nullable: true),
                    CardEntityId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardTwoStageEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardTwoStageEntity_CardEntity_CardEntityId",
                        column: x => x.CardEntityId,
                        principalTable: "CardEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardEntity_UserEntityId",
                table: "CardEntity",
                column: "UserEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CardTwoStageEntity_CardEntityId",
                table: "CardTwoStageEntity",
                column: "CardEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_StokEntity_UserEntityId",
                table: "StokEntity",
                column: "UserEntityId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardTwoStageEntity");

            migrationBuilder.DropTable(
                name: "StokEntity");

            migrationBuilder.DropTable(
                name: "CardEntity");

            migrationBuilder.DropTable(
                name: "UserEntity");
        }
    }
}
