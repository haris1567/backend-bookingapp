using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace bookingapp_backend.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Body = table.Column<string>(nullable: true),
                    ReceiverEmail = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    SentTime = table.Column<DateTime>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Labs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    LabId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Details = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Uid = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Role = table.Column<int>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    Uid = table.Column<string>(nullable: true),
                    LabId = table.Column<int>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Labs_LabId",
                        column: x => x.LabId,
                        principalTable: "Labs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Labs",
                columns: new[] { "Id", "DateAdded", "DateUpdated", "Details", "LabId", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 6, 25, 6, 59, 6, 457, DateTimeKind.Local).AddTicks(3871), new DateTime(2022, 6, 25, 6, 59, 6, 458, DateTimeKind.Local).AddTicks(1272), "CCNA Lab Remote", "ccna", "CCNA" },
                    { 2, new DateTime(2022, 6, 25, 6, 59, 6, 458, DateTimeKind.Local).AddTicks(1630), new DateTime(2022, 6, 25, 6, 59, 6, 458, DateTimeKind.Local).AddTicks(1640), "CISCO Official Lab", "cisco", "CISCO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateAdded", "DateUpdated", "Email", "Name", "Role", "Uid", "Password" },
                values: new object[] { 4, new DateTime(2022, 6, 25, 6, 59, 6, 459, DateTimeKind.Local).AddTicks(4411), new DateTime(2022, 6, 25, 6, 59, 6, 459, DateTimeKind.Local).AddTicks(4416), "harisali808+instructor@hotmail.com", "Haris Ali", 1, "admin", "NFPXWx9MXvRwj/lDmsGQUNL65bQ8tbsRdVgFzNPJTAM=" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateAdded", "DateUpdated", "Email", "Name", "Role", "Uid" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 6, 25, 6, 59, 6, 459, DateTimeKind.Local).AddTicks(3015), new DateTime(2022, 6, 25, 6, 59, 6, 459, DateTimeKind.Local).AddTicks(3275), "18895045@student.curtin.edu.au", "Haris", 0, "18895045" },
                    { 2, new DateTime(2022, 6, 25, 6, 59, 6, 459, DateTimeKind.Local).AddTicks(3570), new DateTime(2022, 6, 25, 6, 59, 6, 459, DateTimeKind.Local).AddTicks(3579), "harisali808@hotmail.com", "Ali", 0, "12345678" },
                    { 3, new DateTime(2022, 6, 25, 6, 59, 6, 459, DateTimeKind.Local).AddTicks(3589), new DateTime(2022, 6, 25, 6, 59, 6, 459, DateTimeKind.Local).AddTicks(3590), "harisali808@gmail.com", "Muhammad", 0, "87654321" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_LabId",
                table: "Bookings",
                column: "LabId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Emails");

            migrationBuilder.DropTable(
                name: "Labs");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
