using Microsoft.EntityFrameworkCore.Migrations;

namespace PCServ.Migrations
{
    public partial class ModifyUsermodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserTechnicianId",
                table: "TicketStatusChange",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserClientId",
                table: "Tickets",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserTechnicianId",
                table: "Tickets",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TicketStatusChange_UserTechnicianId",
                table: "TicketStatusChange",
                column: "UserTechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserClientId",
                table: "Tickets",
                column: "UserClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserTechnicianId",
                table: "Tickets",
                column: "UserTechnicianId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Users_UserClientId",
                table: "Tickets",
                column: "UserClientId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Users_UserTechnicianId",
                table: "Tickets",
                column: "UserTechnicianId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketStatusChange_Users_UserTechnicianId",
                table: "TicketStatusChange",
                column: "UserTechnicianId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Users_UserClientId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Users_UserTechnicianId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketStatusChange_Users_UserTechnicianId",
                table: "TicketStatusChange");

            migrationBuilder.DropIndex(
                name: "IX_TicketStatusChange_UserTechnicianId",
                table: "TicketStatusChange");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_UserClientId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_UserTechnicianId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "UserTechnicianId",
                table: "TicketStatusChange");

            migrationBuilder.DropColumn(
                name: "UserClientId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "UserTechnicianId",
                table: "Tickets");
        }
    }
}
