using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudHRMS.Migrations
{
    /// <inheritdoc />
    public partial class shift : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shift",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    OutTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    LateAfter = table.Column<TimeSpan>(type: "time", nullable: false),
                    EarlyOutBefore = table.Column<TimeSpan>(type: "time", nullable: false),
                    DailyAttendanceId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsInActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shift", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shift_DailyAttendance_DailyAttendanceId",
                        column: x => x.DailyAttendanceId,
                        principalTable: "DailyAttendance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shift_DailyAttendanceId",
                table: "Shift",
                column: "DailyAttendanceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shift");
        }
    }
}
