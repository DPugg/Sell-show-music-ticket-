using Microsoft.EntityFrameworkCore.Migrations;

namespace Band.Data.Migrations
{
    public partial class increase_MaxLengthLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Youtube",
                table: "NHOMNHAC",
                type: "varchar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Spotify",
                table: "NHOMNHAC",
                type: "varchar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AppleMusic",
                table: "NHOMNHAC",
                type: "varchar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Youtube",
                table: "NHOMNHAC",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Spotify",
                table: "NHOMNHAC",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AppleMusic",
                table: "NHOMNHAC",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldNullable: true);
        }
    }
}
