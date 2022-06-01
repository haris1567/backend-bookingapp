using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bookingapp_backend.Migrations
{
    public partial class addedseeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Labs",
                columns: new[] { "Id", "DateAdded", "DateUpdated", "Details", "LabId", "Name" },
                values: new object[] { 1, new DateTime(2022, 6, 2, 1, 18, 16, 91, DateTimeKind.Local).AddTicks(8090), new DateTime(2022, 6, 2, 1, 18, 16, 93, DateTimeKind.Local).AddTicks(2231), "CCNA Lab Remote", "ccna", "CCNA" });

            migrationBuilder.InsertData(
                table: "Labs",
                columns: new[] { "Id", "DateAdded", "DateUpdated", "Details", "LabId", "Name" },
                values: new object[] { 2, new DateTime(2022, 6, 2, 1, 18, 16, 93, DateTimeKind.Local).AddTicks(2854), new DateTime(2022, 6, 2, 1, 18, 16, 93, DateTimeKind.Local).AddTicks(2873), "CISCO Official Lab", "cisco", "CISCO" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Labs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Labs",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
