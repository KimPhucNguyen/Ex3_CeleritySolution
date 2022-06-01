using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CeleritySolution.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpirationDate",
                table: "Agreements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 24, 10, 36, 21, 366, DateTimeKind.Local).AddTicks(8465),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 5, 22, 17, 49, 12, 347, DateTimeKind.Local).AddTicks(2120));

            migrationBuilder.AlterColumn<DateTime>(
                name: "EffectiveDate",
                table: "Agreements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 24, 10, 36, 21, 366, DateTimeKind.Local).AddTicks(8104),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 5, 22, 17, 49, 12, 347, DateTimeKind.Local).AddTicks(1748));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Agreements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 24, 10, 36, 21, 366, DateTimeKind.Local).AddTicks(8764),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 5, 22, 17, 49, 12, 347, DateTimeKind.Local).AddTicks(2953));

            migrationBuilder.InsertData(
                table: "Distributors",
                columns: new[] { "Id", "DistributorName" },
                values: new object[] { 1, "Werner" });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "Id", "AgreementName", "AgreementType", "CreatedDate", "DaysUntilExplation", "DistributorId", "EffectiveDate", "ExpirationDate", "QuoteNumber", "Status" },
                values: new object[] { 1, "HP PACK AIR INC", "SPA", new DateTime(2022, 5, 24, 10, 36, 21, 367, DateTimeKind.Local).AddTicks(643), 1, 1, new DateTime(2022, 5, 24, 10, 36, 21, 367, DateTimeKind.Local).AddTicks(639), new DateTime(2022, 5, 24, 10, 36, 21, 367, DateTimeKind.Local).AddTicks(643), "02776A3", "Invalid" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agreements",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpirationDate",
                table: "Agreements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 22, 17, 49, 12, 347, DateTimeKind.Local).AddTicks(2120),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 5, 24, 10, 36, 21, 366, DateTimeKind.Local).AddTicks(8465));

            migrationBuilder.AlterColumn<DateTime>(
                name: "EffectiveDate",
                table: "Agreements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 22, 17, 49, 12, 347, DateTimeKind.Local).AddTicks(1748),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 5, 24, 10, 36, 21, 366, DateTimeKind.Local).AddTicks(8104));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Agreements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 22, 17, 49, 12, 347, DateTimeKind.Local).AddTicks(2953),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 5, 24, 10, 36, 21, 366, DateTimeKind.Local).AddTicks(8764));
        }
    }
}
