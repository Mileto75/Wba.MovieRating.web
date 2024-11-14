using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Wba.MovieRating.Web.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DirectorMovie_Director_DirectorsId",
                table: "DirectorMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieActor_Actor_ActorId",
                table: "MovieActor");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieActor_Movies_MovieId",
                table: "MovieActor");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Company_CompanyId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Movies_MovieId",
                table: "Rating");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Users_UserId",
                table: "Rating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rating",
                table: "Rating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieActor",
                table: "MovieActor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Director",
                table: "Director");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                table: "Company");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Actor",
                table: "Actor");

            migrationBuilder.RenameTable(
                name: "Rating",
                newName: "Ratings");

            migrationBuilder.RenameTable(
                name: "MovieActor",
                newName: "MovieActors");

            migrationBuilder.RenameTable(
                name: "Director",
                newName: "Directors");

            migrationBuilder.RenameTable(
                name: "Company",
                newName: "Companies");

            migrationBuilder.RenameTable(
                name: "Actor",
                newName: "Actors");

            migrationBuilder.RenameIndex(
                name: "IX_Rating_UserId",
                table: "Ratings",
                newName: "IX_Ratings_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Rating_MovieId",
                table: "Ratings",
                newName: "IX_Ratings_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieActor_MovieId",
                table: "MovieActors",
                newName: "IX_MovieActors_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieActors",
                table: "MovieActors",
                columns: new[] { "ActorId", "MovieId", "Character" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Directors",
                table: "Directors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Actors",
                table: "Actors",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Created", "Deleted", "Firstname", "Lastname", "Updated" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 14, 10, 40, 4, 367, DateTimeKind.Local).AddTicks(1103), null, "Al", "Pacino", null },
                    { 2, new DateTime(2024, 11, 14, 10, 40, 4, 367, DateTimeKind.Local).AddTicks(1104), null, "Robert", "De Niro", null },
                    { 3, new DateTime(2024, 11, 14, 10, 40, 4, 367, DateTimeKind.Local).AddTicks(1106), null, "Kate", "Winslet", null }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Created", "Deleted", "Name", "Updated" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 14, 10, 40, 4, 367, DateTimeKind.Local).AddTicks(1039), null, "Miramax", null },
                    { 2, new DateTime(2024, 11, 14, 10, 40, 4, 367, DateTimeKind.Local).AddTicks(1095), null, "Weinstein", null }
                });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "Created", "Deleted", "Firstname", "Lastname", "Updated" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 14, 10, 40, 4, 367, DateTimeKind.Local).AddTicks(1099), null, "Bob", "Saget", null },
                    { 2, new DateTime(2024, 11, 14, 10, 40, 4, 367, DateTimeKind.Local).AddTicks(1101), null, "Walter", "Capiau", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Created", "Deleted", "Firstname", "Lastname", "Updated", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 14, 10, 40, 4, 367, DateTimeKind.Local).AddTicks(1108), null, "Bart", "Soete", null, null },
                    { 2, new DateTime(2024, 11, 14, 10, 40, 4, 367, DateTimeKind.Local).AddTicks(1110), null, "Tibo", "Van Craenenbroeck", null, null },
                    { 3, new DateTime(2024, 11, 14, 10, 40, 4, 367, DateTimeKind.Local).AddTicks(1111), null, "Tine", "Baelde", null, null }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "CompanyId", "Created", "Deleted", "ReleaseDate", "Title", "Updated" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 11, 14, 10, 40, 4, 367, DateTimeKind.Local).AddTicks(1114), null, new DateTime(2018, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deadpool", null },
                    { 2, 1, new DateTime(2024, 11, 14, 10, 40, 4, 367, DateTimeKind.Local).AddTicks(1204), null, new DateTime(2018, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Suicide squad", null },
                    { 3, 2, new DateTime(2024, 11, 14, 10, 40, 4, 367, DateTimeKind.Local).AddTicks(1210), null, new DateTime(2020, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Venom", null },
                    { 4, 2, new DateTime(2024, 11, 14, 10, 40, 4, 367, DateTimeKind.Local).AddTicks(1215), null, new DateTime(1999, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Titanic", null }
                });

            migrationBuilder.InsertData(
                table: "DirectorMovie",
                columns: new[] { "DirectorsId", "MoviesId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 2, 2 },
                    { 2, 4 }
                });

            migrationBuilder.InsertData(
                table: "MovieActors",
                columns: new[] { "ActorId", "Character", "MovieId" },
                values: new object[,]
                {
                    { 1, "Deadpool", 1 },
                    { 1, "The weasel", 2 },
                    { 1, "The cop", 3 },
                    { 1, "Dien blonten", 4 },
                    { 2, "Venom", 3 },
                    { 2, "Die snelle", 4 },
                    { 3, "Colossus", 1 },
                    { 3, "TDK", 2 }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "Created", "Deleted", "MovieId", "Review", "Score", "Updated", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 14, 10, 40, 4, 367, DateTimeKind.Local).AddTicks(1243), null, 1, "Great movie!", 4, null, 1 },
                    { 2, new DateTime(2024, 11, 14, 10, 40, 4, 367, DateTimeKind.Local).AddTicks(1245), null, 2, "Top!!", 5, null, 1 },
                    { 3, new DateTime(2024, 11, 14, 10, 40, 4, 367, DateTimeKind.Local).AddTicks(1247), null, 3, "Suckt ongelooflijk!", 2, null, 1 },
                    { 4, new DateTime(2024, 11, 14, 10, 40, 4, 367, DateTimeKind.Local).AddTicks(1248), null, 4, "Machtig!!", 2, null, 1 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_DirectorMovie_Directors_DirectorsId",
                table: "DirectorMovie",
                column: "DirectorsId",
                principalTable: "Directors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieActors_Actors_ActorId",
                table: "MovieActors",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieActors_Movies_MovieId",
                table: "MovieActors",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Companies_CompanyId",
                table: "Movies",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Movies_MovieId",
                table: "Ratings",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Users_UserId",
                table: "Ratings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DirectorMovie_Directors_DirectorsId",
                table: "DirectorMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieActors_Actors_ActorId",
                table: "MovieActors");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieActors_Movies_MovieId",
                table: "MovieActors");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Companies_CompanyId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Movies_MovieId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Users_UserId",
                table: "Ratings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieActors",
                table: "MovieActors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Directors",
                table: "Directors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Actors",
                table: "Actors");

            migrationBuilder.DeleteData(
                table: "DirectorMovie",
                keyColumns: new[] { "DirectorsId", "MoviesId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "DirectorMovie",
                keyColumns: new[] { "DirectorsId", "MoviesId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "DirectorMovie",
                keyColumns: new[] { "DirectorsId", "MoviesId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "DirectorMovie",
                keyColumns: new[] { "DirectorsId", "MoviesId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumns: new[] { "ActorId", "Character", "MovieId" },
                keyValues: new object[] { 1, "Deadpool", 1 });

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumns: new[] { "ActorId", "Character", "MovieId" },
                keyValues: new object[] { 1, "The weasel", 2 });

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumns: new[] { "ActorId", "Character", "MovieId" },
                keyValues: new object[] { 1, "The cop", 3 });

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumns: new[] { "ActorId", "Character", "MovieId" },
                keyValues: new object[] { 1, "Dien blonten", 4 });

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumns: new[] { "ActorId", "Character", "MovieId" },
                keyValues: new object[] { 2, "Venom", 3 });

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumns: new[] { "ActorId", "Character", "MovieId" },
                keyValues: new object[] { 2, "Die snelle", 4 });

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumns: new[] { "ActorId", "Character", "MovieId" },
                keyValues: new object[] { 3, "Colossus", 1 });

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumns: new[] { "ActorId", "Character", "MovieId" },
                keyValues: new object[] { 3, "TDK", 2 });

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameTable(
                name: "Ratings",
                newName: "Rating");

            migrationBuilder.RenameTable(
                name: "MovieActors",
                newName: "MovieActor");

            migrationBuilder.RenameTable(
                name: "Directors",
                newName: "Director");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "Company");

            migrationBuilder.RenameTable(
                name: "Actors",
                newName: "Actor");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_UserId",
                table: "Rating",
                newName: "IX_Rating_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_MovieId",
                table: "Rating",
                newName: "IX_Rating_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieActors_MovieId",
                table: "MovieActor",
                newName: "IX_MovieActor_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rating",
                table: "Rating",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieActor",
                table: "MovieActor",
                columns: new[] { "ActorId", "MovieId", "Character" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Director",
                table: "Director",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company",
                table: "Company",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Actor",
                table: "Actor",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DirectorMovie_Director_DirectorsId",
                table: "DirectorMovie",
                column: "DirectorsId",
                principalTable: "Director",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieActor_Actor_ActorId",
                table: "MovieActor",
                column: "ActorId",
                principalTable: "Actor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieActor_Movies_MovieId",
                table: "MovieActor",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Company_CompanyId",
                table: "Movies",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Movies_MovieId",
                table: "Rating",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Users_UserId",
                table: "Rating",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
