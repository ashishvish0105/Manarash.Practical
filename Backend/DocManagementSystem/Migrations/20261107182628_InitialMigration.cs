using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DocManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GeneratedReferenceNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DockId = table.Column<int>(type: "int", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LicensePlate = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DirectionId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                });

            migrationBuilder.CreateTable(
                name: "Docks",
                columns: table => new
                {
                    DockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docks", x => x.DockId);
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "BookingId", "CompanyName", "CreatedAt", "DirectionId", "DockId", "EndTime", "GeneratedReferenceNumber", "LastUpdatedAt", "LicensePlate", "StartTime", "StatusId" },
                values: new object[,]
                {
                    { 1, "DHL Express", new DateTime(2026, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, new DateTime(2026, 11, 6, 20, 0, 0, 0, DateTimeKind.Unspecified), "BKG-2026-001", new DateTime(2026, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "GJ-01-AA-1234", new DateTime(2026, 11, 6, 18, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, "FedEx Ground", new DateTime(2026, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, new DateTime(2026, 11, 6, 22, 0, 0, 0, DateTimeKind.Unspecified), "BKG-2026-002", new DateTime(2026, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "MH-02-BB-5678", new DateTime(2026, 11, 6, 20, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, "Amazon Logistics", new DateTime(2026, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, new DateTime(2026, 11, 7, 1, 0, 0, 0, DateTimeKind.Unspecified), "BKG-2026-003", new DateTime(2026, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "DL-03-CC-9012", new DateTime(2026, 11, 6, 23, 15, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, "BlueDart Cargo", new DateTime(2026, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, new DateTime(2026, 11, 7, 2, 0, 0, 0, DateTimeKind.Unspecified), "BKG-2026-004", new DateTime(2026, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "KA-04-DD-3456", new DateTime(2026, 11, 6, 23, 45, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 5, "Flipkart Fulfilment", new DateTime(2026, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, new DateTime(2026, 11, 7, 3, 0, 0, 0, DateTimeKind.Unspecified), "BKG-2026-005", new DateTime(2026, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "HR-05-EE-7890", new DateTime(2026, 11, 7, 0, 10, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 6, "Maersk Supply", new DateTime(2026, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, new DateTime(2026, 11, 7, 2, 0, 0, 0, DateTimeKind.Unspecified), "BKG-2026-006", new DateTime(2026, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "UP-16-FF-4321", new DateTime(2026, 11, 7, 0, 30, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 7, "Delhivery Ltd", new DateTime(2026, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, new DateTime(2026, 11, 7, 5, 0, 0, 0, DateTimeKind.Unspecified), "BKG-2026-007", new DateTime(2026, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "TS-07-GG-8765", new DateTime(2026, 11, 7, 3, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 8, "Safexpress", new DateTime(2026, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, new DateTime(2026, 11, 7, 7, 0, 0, 0, DateTimeKind.Unspecified), "BKG-2026-008", new DateTime(2026, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "WB-08-HH-2109", new DateTime(2026, 11, 7, 5, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 9, "Gati Cargo", new DateTime(2026, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, new DateTime(2026, 11, 8, 2, 0, 0, 0, DateTimeKind.Unspecified), "BKG-2026-009", new DateTime(2026, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "TN-09-JJ-6543", new DateTime(2026, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 10, "VRL Logistics", new DateTime(2026, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, new DateTime(2026, 11, 8, 5, 0, 0, 0, DateTimeKind.Unspecified), "BKG-2026-010", new DateTime(2026, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "KA-25-KK-0011", new DateTime(2026, 11, 8, 3, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "Docks",
                columns: new[] { "DockId", "CreatedAt", "IsActive", "LastUpdatedAt", "Name", "TypeId" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2026, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "North Dock A", 1 },
                    { 2, new DateTime(2026, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2026, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "South Dock B", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Docks");
        }
    }
}
