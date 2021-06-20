using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Units_UnitId",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Users_UserId",
                table: "Recipes");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Recipes",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Recipes",
                type: "bytea",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UnitId",
                table: "Ingredients",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<double>(
                name: "Amount",
                table: "Ingredients",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Units_UnitId",
                table: "Ingredients",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Users_UserId",
                table: "Recipes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Units_UnitId",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Users_UserId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Recipes");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Recipes",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "UnitId",
                table: "Ingredients",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "Ingredients",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Units_UnitId",
                table: "Ingredients",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Users_UserId",
                table: "Recipes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
