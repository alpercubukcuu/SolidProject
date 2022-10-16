using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class migaddjob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JobId",
                table: "Customers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    JobId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.JobId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_JobId",
                table: "Customers",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Job_JobId",
                table: "Customers",
                column: "JobId",
                principalTable: "Job",
                principalColumn: "JobId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Job_JobId",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropIndex(
                name: "IX_Customers_JobId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "Customers");
        }
    }
}
