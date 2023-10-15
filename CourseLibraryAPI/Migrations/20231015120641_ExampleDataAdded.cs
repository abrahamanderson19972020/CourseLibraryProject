using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseLibraryAPI.Migrations
{
    public partial class ExampleDataAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "DateOfBirth", "Firstname", "Lastname", "MainCategory" },
                values: new object[,]
                {
                    { new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"), new DateTime(1957, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arnold", "The Unseen Stafford", "Singing" },
                    { new Guid("2902b665-1190-4c70-9915-b9c2d7680450"), new DateTime(1957, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eli", "Ivory Bones Sweet", "Singing" },
                    { new Guid("2aadd2df-7caf-45ab-9355-7f6332985a87"), new DateTime(1981, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rutherford", "Fearless Cloven", "General debauchery" },
                    { new Guid("2ee49fe3-edf2-4f91-8409-3eb25ce6ca51"), new DateTime(1982, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Atherton", "Crow Ridley", "Rum" },
                    { new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"), new DateTime(1956, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seabury", "Toxic Reyson", "Maps" },
                    { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), new DateTime(1980, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Berry", "Griffin Beak Eldritch", "Ships" },
                    { new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), new DateTime(1978, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nancy", "Swashbuckler Rye", "Rum" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "AuthorId", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("40ff5488-fdab-45b5-bc3a-14302d59869a"), new Guid("2902b665-1190-4c70-9915-b9c2d7680450"), "In this course you'll learn how to sing all-time favourite pirate songs without sounding like you actually know the words or how to hold a note.", "Singalong Pirate Hits" },
                    { new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"), new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "Commandeering a ship in rough waters isn't easy.  Commandeering it without getting caught is even harder.  In this course you'll learn how to sail away and avoid those pesky musketeers.", "Commandeering a Ship Without Getting Caught" },
                    { new Guid("d173e20d-159e-4127-9ce9-b0ac2564ad97"), new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), "Every good pirate loves rum, but it also has a tendency to get you into trouble.  In this course you'll learn how to avoid that.  This new exclusive edition includes an additional chapter on how to run fast without falling while drunk.", "Avoiding Brawls While Drinking as Much Rum as You Desire" },
                    { new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7ee"), new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "In this course, the author provides tips to avoid, or, if needed, overthrow pirate mutiny.", "Overthrowing Mutiny" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("2aadd2df-7caf-45ab-9355-7f6332985a87"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("2ee49fe3-edf2-4f91-8409-3eb25ce6ca51"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("40ff5488-fdab-45b5-bc3a-14302d59869a"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("d173e20d-159e-4127-9ce9-b0ac2564ad97"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7ee"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("2902b665-1190-4c70-9915-b9c2d7680450"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"));
        }
    }
}
