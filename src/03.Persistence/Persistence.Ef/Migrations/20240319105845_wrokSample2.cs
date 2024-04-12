using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Ef.Migrations
{
    /// <inheritdoc />
    public partial class wrokSample2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkSamples_WorkSampleCategory_CategoryId",
                table: "WorkSamples");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkSampleCategory",
                table: "WorkSampleCategory");

            migrationBuilder.RenameTable(
                name: "WorkSampleCategory",
                newName: "WorkSampleCategories");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "WorkSamples",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkSampleCategories",
                table: "WorkSampleCategories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkSamples_WorkSampleCategories_CategoryId",
                table: "WorkSamples",
                column: "CategoryId",
                principalTable: "WorkSampleCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkSamples_WorkSampleCategories_CategoryId",
                table: "WorkSamples");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkSampleCategories",
                table: "WorkSampleCategories");

            migrationBuilder.RenameTable(
                name: "WorkSampleCategories",
                newName: "WorkSampleCategory");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "WorkSamples",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkSampleCategory",
                table: "WorkSampleCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkSamples_WorkSampleCategory_CategoryId",
                table: "WorkSamples",
                column: "CategoryId",
                principalTable: "WorkSampleCategory",
                principalColumn: "Id");
        }
    }
}
