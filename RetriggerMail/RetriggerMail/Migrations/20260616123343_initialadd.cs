using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RetriggerMail.Migrations
{
    /// <inheritdoc />
    public partial class initialadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommunicationLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipientEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipientMobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TemplateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessageBody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSuccess = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunicationLogs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CommunicationLogs",
                columns: new[] { "Id", "ClaimNumber", "IsSuccess", "MessageBody", "RecipientEmail", "RecipientMobile", "SentDate", "TemplateName" },
                values: new object[,]
                {
                    { 1, "CLM123", false, "Your claim CLM123 is under review.", "customer1@test.com", "9876543210", new DateTime(2026, 6, 15, 18, 3, 43, 263, DateTimeKind.Local).AddTicks(3932), "Claim Update Email" },
                    { 2, "CLM123", true, "Claim CLM123 status updated.", "customer1@test.com", "9876543210", new DateTime(2026, 6, 15, 18, 3, 43, 263, DateTimeKind.Local).AddTicks(3952), "Claim Update SMS" },
                    { 3, "CLM456", true, "Your claim CLM456 has been approved.", "customer2@test.com", "9123456789", new DateTime(2026, 6, 14, 18, 3, 43, 263, DateTimeKind.Local).AddTicks(3954), "Claim Approved Email" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommunicationLogs");
        }
    }
}
