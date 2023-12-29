using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IronMaidenRegistry.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Instruments",
                columns: new[] { "InstrumentId", "InstrumentName" },
                values: new object[,]
                {
                    { new Guid("09449193-e9aa-4107-b92f-b1cfc027ebea"), "Keyboard" },
                    { new Guid("2c11b548-e70d-4b0d-9a1c-31daa5c9928a"), "Vocals" },
                    { new Guid("84a3b081-db74-4d81-8222-f0216ecb9d5a"), "Drum" },
                    { new Guid("9686af26-782e-41f7-9daa-5f79abc5b2c4"), "Guitar" },
                    { new Guid("d2d4d6b0-dace-47bb-86bd-418d9eec8698"), "Bass" }
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "SongId", "AverageScore", "DurationInMinutes", "SongName" },
                values: new object[,]
                {
                    { new Guid("0b40c8f5-44d6-48e0-9448-83dbed39ea3c"), (byte)5, (byte)4, "The Trooper" },
                    { new Guid("74959ea2-f8ff-4204-979e-bd0ce3fb392a"), (byte)4, (byte)7, "Fear of the Dark" },
                    { new Guid("a1331b45-f0a8-4bb3-9915-6d44f95e4f0b"), (byte)4, (byte)9, "For the Greater Good of God" },
                    { new Guid("a91ec616-14d5-4712-8255-3e3d00d89f53"), (byte)5, (byte)4, "Prowler" }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "BirthDate", "FullName", "InstrumentId" },
                values: new object[,]
                {
                    { new Guid("0cba1ca5-7d18-46d3-ad99-1fdfa040359f"), new DateOnly(1957, 2, 27), "Adrian Smith", new Guid("9686af26-782e-41f7-9daa-5f79abc5b2c4") },
                    { new Guid("1f5af4a7-b538-4dd4-af0d-38287047e70a"), new DateOnly(1952, 9, 27), "Denis Stratton", new Guid("9686af26-782e-41f7-9daa-5f79abc5b2c4") },
                    { new Guid("21665fb0-1264-4c90-85b9-b2c16d8b80c7"), new DateOnly(1958, 8, 7), "Bruce Dickson", new Guid("2c11b548-e70d-4b0d-9a1c-31daa5c9928a") },
                    { new Guid("3ffac757-df7b-450b-a978-2b0c9d049826"), new DateOnly(1957, 3, 7), "Clive Burr", new Guid("84a3b081-db74-4d81-8222-f0216ecb9d5a") },
                    { new Guid("6a259e55-d4b1-4709-af90-e6e80f756b6f"), new DateOnly(1958, 5, 17), "Paul Di'Anno", new Guid("2c11b548-e70d-4b0d-9a1c-31daa5c9928a") },
                    { new Guid("914b1048-f961-4169-b4dc-5b2ace57e9d8"), new DateOnly(1956, 3, 12), "Steve Harris", new Guid("d2d4d6b0-dace-47bb-86bd-418d9eec8698") },
                    { new Guid("9b9a8d08-c432-40f2-bc1f-dc7196bc2b1e"), new DateOnly(1957, 1, 27), "Janick Gers", new Guid("9686af26-782e-41f7-9daa-5f79abc5b2c4") },
                    { new Guid("9c451aba-c010-4b11-97ee-dc802855cd8b"), new DateOnly(1956, 12, 23), "Dave Murray", new Guid("9686af26-782e-41f7-9daa-5f79abc5b2c4") },
                    { new Guid("bb582f22-30a1-444d-928e-db64916d01b1"), new DateOnly(1952, 6, 5), "Nicko McBrain", new Guid("84a3b081-db74-4d81-8222-f0216ecb9d5a") },
                    { new Guid("ebc53600-98d8-49d7-bba3-8581f840efbb"), new DateOnly(1963, 5, 29), "Blaze Bayley", new Guid("2c11b548-e70d-4b0d-9a1c-31daa5c9928a") }
                });

            migrationBuilder.InsertData(
                table: "MembersSongs",
                columns: new[] { "MemberId", "SongId" },
                values: new object[] { new Guid("21665fb0-1264-4c90-85b9-b2c16d8b80c7"), new Guid("74959ea2-f8ff-4204-979e-bd0ce3fb392a") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Instruments",
                keyColumn: "InstrumentId",
                keyValue: new Guid("09449193-e9aa-4107-b92f-b1cfc027ebea"));

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: new Guid("0cba1ca5-7d18-46d3-ad99-1fdfa040359f"));

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: new Guid("1f5af4a7-b538-4dd4-af0d-38287047e70a"));

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: new Guid("3ffac757-df7b-450b-a978-2b0c9d049826"));

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: new Guid("6a259e55-d4b1-4709-af90-e6e80f756b6f"));

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: new Guid("914b1048-f961-4169-b4dc-5b2ace57e9d8"));

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: new Guid("9b9a8d08-c432-40f2-bc1f-dc7196bc2b1e"));

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: new Guid("9c451aba-c010-4b11-97ee-dc802855cd8b"));

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: new Guid("bb582f22-30a1-444d-928e-db64916d01b1"));

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: new Guid("ebc53600-98d8-49d7-bba3-8581f840efbb"));

            migrationBuilder.DeleteData(
                table: "MembersSongs",
                keyColumns: new[] { "MemberId", "SongId" },
                keyValues: new object[] { new Guid("21665fb0-1264-4c90-85b9-b2c16d8b80c7"), new Guid("74959ea2-f8ff-4204-979e-bd0ce3fb392a") });

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "SongId",
                keyValue: new Guid("0b40c8f5-44d6-48e0-9448-83dbed39ea3c"));

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "SongId",
                keyValue: new Guid("a1331b45-f0a8-4bb3-9915-6d44f95e4f0b"));

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "SongId",
                keyValue: new Guid("a91ec616-14d5-4712-8255-3e3d00d89f53"));

            migrationBuilder.DeleteData(
                table: "Instruments",
                keyColumn: "InstrumentId",
                keyValue: new Guid("84a3b081-db74-4d81-8222-f0216ecb9d5a"));

            migrationBuilder.DeleteData(
                table: "Instruments",
                keyColumn: "InstrumentId",
                keyValue: new Guid("9686af26-782e-41f7-9daa-5f79abc5b2c4"));

            migrationBuilder.DeleteData(
                table: "Instruments",
                keyColumn: "InstrumentId",
                keyValue: new Guid("d2d4d6b0-dace-47bb-86bd-418d9eec8698"));

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: new Guid("21665fb0-1264-4c90-85b9-b2c16d8b80c7"));

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "SongId",
                keyValue: new Guid("74959ea2-f8ff-4204-979e-bd0ce3fb392a"));

            migrationBuilder.DeleteData(
                table: "Instruments",
                keyColumn: "InstrumentId",
                keyValue: new Guid("2c11b548-e70d-4b0d-9a1c-31daa5c9928a"));
        }
    }
}
