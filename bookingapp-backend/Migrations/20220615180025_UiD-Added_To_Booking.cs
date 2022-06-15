using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bookingapp_backend.Migrations
{
    public partial class UiDAdded_To_Booking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Uid",
                table: "Bookings",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Labs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateAdded", "DateUpdated" },
                values: new object[] { new DateTime(2022, 6, 15, 23, 0, 24, 583, DateTimeKind.Local).AddTicks(3524), new DateTime(2022, 6, 15, 23, 0, 24, 584, DateTimeKind.Local).AddTicks(232) });

            migrationBuilder.UpdateData(
                table: "Labs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateAdded", "DateUpdated" },
                values: new object[] { new DateTime(2022, 6, 15, 23, 0, 24, 584, DateTimeKind.Local).AddTicks(597), new DateTime(2022, 6, 15, 23, 0, 24, 584, DateTimeKind.Local).AddTicks(608) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Uid",
                table: "Bookings");

            migrationBuilder.UpdateData(
                table: "Labs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateAdded", "DateUpdated" },
                values: new object[] { new DateTime(2022, 6, 2, 1, 18, 16, 91, DateTimeKind.Local).AddTicks(8090), new DateTime(2022, 6, 2, 1, 18, 16, 93, DateTimeKind.Local).AddTicks(2231) });

            migrationBuilder.UpdateData(
                table: "Labs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateAdded", "DateUpdated" },
                values: new object[] { new DateTime(2022, 6, 2, 1, 18, 16, 93, DateTimeKind.Local).AddTicks(2854), new DateTime(2022, 6, 2, 1, 18, 16, 93, DateTimeKind.Local).AddTicks(2873) });
        }
    }
}
