using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wba.MovieRating.Web.Migrations
{
    /// <inheritdoc />
    public partial class addImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 23, 8, 21, 58, 725, DateTimeKind.Local).AddTicks(4393));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 23, 8, 21, 58, 725, DateTimeKind.Local).AddTicks(4395));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 11, 23, 8, 21, 58, 725, DateTimeKind.Local).AddTicks(4397));

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 23, 8, 21, 58, 725, DateTimeKind.Local).AddTicks(4334));

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 23, 8, 21, 58, 725, DateTimeKind.Local).AddTicks(4382));

            migrationBuilder.UpdateData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 23, 8, 21, 58, 725, DateTimeKind.Local).AddTicks(4386));

            migrationBuilder.UpdateData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 23, 8, 21, 58, 725, DateTimeKind.Local).AddTicks(4388));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Image" },
                values: new object[] { new DateTime(2024, 11, 23, 8, 21, 58, 725, DateTimeKind.Local).AddTicks(4413), null });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Image" },
                values: new object[] { new DateTime(2024, 11, 23, 8, 21, 58, 725, DateTimeKind.Local).AddTicks(4503), null });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Image" },
                values: new object[] { new DateTime(2024, 11, 23, 8, 21, 58, 725, DateTimeKind.Local).AddTicks(4510), null });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Image" },
                values: new object[] { new DateTime(2024, 11, 23, 8, 21, 58, 725, DateTimeKind.Local).AddTicks(4515), null });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 23, 8, 21, 58, 725, DateTimeKind.Local).AddTicks(4530));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 23, 8, 21, 58, 725, DateTimeKind.Local).AddTicks(4533));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 11, 23, 8, 21, 58, 725, DateTimeKind.Local).AddTicks(4535));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 11, 23, 8, 21, 58, 725, DateTimeKind.Local).AddTicks(4537));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 23, 8, 21, 58, 725, DateTimeKind.Local).AddTicks(4400));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 23, 8, 21, 58, 725, DateTimeKind.Local).AddTicks(4402));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 11, 23, 8, 21, 58, 725, DateTimeKind.Local).AddTicks(4404));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Movies");

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 14, 10, 40, 4, 367, DateTimeKind.Local).AddTicks(1103));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 14, 10, 40, 4, 367, DateTimeKind.Local).AddTicks(1104));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 11, 14, 10, 40, 4, 367, DateTimeKind.Local).AddTicks(1106));

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 14, 10, 40, 4, 367, DateTimeKind.Local).AddTicks(1039));

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 14, 10, 40, 4, 367, DateTimeKind.Local).AddTicks(1095));

            migrationBuilder.UpdateData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 14, 10, 40, 4, 367, DateTimeKind.Local).AddTicks(1099));

            migrationBuilder.UpdateData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 14, 10, 40, 4, 367, DateTimeKind.Local).AddTicks(1101));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 14, 10, 40, 4, 367, DateTimeKind.Local).AddTicks(1114));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 14, 10, 40, 4, 367, DateTimeKind.Local).AddTicks(1204));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 11, 14, 10, 40, 4, 367, DateTimeKind.Local).AddTicks(1210));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 11, 14, 10, 40, 4, 367, DateTimeKind.Local).AddTicks(1215));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 14, 10, 40, 4, 367, DateTimeKind.Local).AddTicks(1243));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 14, 10, 40, 4, 367, DateTimeKind.Local).AddTicks(1245));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 11, 14, 10, 40, 4, 367, DateTimeKind.Local).AddTicks(1247));

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2024, 11, 14, 10, 40, 4, 367, DateTimeKind.Local).AddTicks(1248));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 14, 10, 40, 4, 367, DateTimeKind.Local).AddTicks(1108));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 14, 10, 40, 4, 367, DateTimeKind.Local).AddTicks(1110));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2024, 11, 14, 10, 40, 4, 367, DateTimeKind.Local).AddTicks(1111));
        }
    }
}
