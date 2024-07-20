using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudHRMS.Migrations
{
    /// <inheritdoc />
    public partial class editshift : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shift_DailyAttendance_DailyAttendanceId",
                table: "Shift");

            migrationBuilder.RenameColumn(
                name: "DailyAttendanceId",
                table: "Shift",
                newName: "AttendancePolicyId");

            migrationBuilder.RenameIndex(
                name: "IX_Shift_DailyAttendanceId",
                table: "Shift",
                newName: "IX_Shift_AttendancePolicyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shift_AttendancePolicy_AttendancePolicyId",
                table: "Shift",
                column: "AttendancePolicyId",
                principalTable: "AttendancePolicy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shift_AttendancePolicy_AttendancePolicyId",
                table: "Shift");

            migrationBuilder.RenameColumn(
                name: "AttendancePolicyId",
                table: "Shift",
                newName: "DailyAttendanceId");

            migrationBuilder.RenameIndex(
                name: "IX_Shift_AttendancePolicyId",
                table: "Shift",
                newName: "IX_Shift_DailyAttendanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shift_DailyAttendance_DailyAttendanceId",
                table: "Shift",
                column: "DailyAttendanceId",
                principalTable: "DailyAttendance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
