﻿#pragma warning disable CS1591
// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Jellyfin.Server.Implementations.Migrations
{
    public partial class AddCustomDisplayPreferences : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MaxActiveSessions",
                schema: "jellyfin",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "CustomItemDisplayPreferences",
                schema: "jellyfin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Client = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false),
                    Key = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomItemDisplayPreferences", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomItemDisplayPreferences_UserId",
                schema: "jellyfin",
                table: "CustomItemDisplayPreferences",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomItemDisplayPreferences_UserId_Client_Key",
                schema: "jellyfin",
                table: "CustomItemDisplayPreferences",
                columns: new[] { "UserId", "Client", "Key" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomItemDisplayPreferences",
                schema: "jellyfin");

            migrationBuilder.AlterColumn<int>(
                name: "MaxActiveSessions",
                schema: "jellyfin",
                table: "Users",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }
    }
}
