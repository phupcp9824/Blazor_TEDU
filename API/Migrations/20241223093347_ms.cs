using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class ms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("a5a68a13-f4d5-4404-b421-80b2bb2dc4fc"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("c8d3de47-b4ca-4926-97bc-4fe959fa80eb"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1d30ddce-ad55-4179-886a-5901748344b7"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ec0801ec-b064-4f4e-8091-d11fa4698e13"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("a059b006-776e-47ee-b2de-5edbb7c45a62"), 0, "7c546b83-780f-49e2-98af-ea033b59107c", "john.doe@example.com", false, "John", "Doe", false, null, "JOHN.DOE@EXAMPLE.COM", "JOHN.DOE", "AQAAAAIAAYagAAAAEGNC6m2gF0XyC3udLVIGT4idGZOuDW4UpEhC9XlFRlaQvwBpkwXZ7Y8EafZjr+BoKw==", null, false, "115575c8-3b46-473e-909d-0e3c989fc1e2", false, "john.doe" },
                    { new Guid("ca90d6c6-31d9-4c01-8066-8e3243d8daa4"), 0, "509b1531-d00f-4282-81c7-96475b0c874b", "jane.smith@example.com", false, "Jane", "Smith", false, null, "JANE.SMITH@EXAMPLE.COM", "JANE.SMITH", "AQAAAAIAAYagAAAAEJcQMpvJarpinp24ghy+QeeweLfSdJT8TOdhEeKx5WCRXHUYpM3HKFZkjoJQ73MopQ==", null, false, "10ea5e13-2be8-4322-bd59-639d9e34f54e", false, "jane.smith" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "AssigneeId", "CreatedDate", "Name", "priority", "status" },
                values: new object[,]
                {
                    { new Guid("af7ab367-fef7-41df-83be-4a64c33ddeab"), new Guid("a059b006-776e-47ee-b2de-5edbb7c45a62"), new DateTime(2024, 12, 23, 9, 33, 46, 12, DateTimeKind.Utc).AddTicks(7182), "Complete documentation", 2, 0 },
                    { new Guid("c8a35bff-6ee5-42b7-acd3-b51a0b4da5d0"), new Guid("ca90d6c6-31d9-4c01-8066-8e3243d8daa4"), new DateTime(2024, 12, 23, 9, 33, 46, 12, DateTimeKind.Utc).AddTicks(7189), "Fix bugs in module", 1, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("af7ab367-fef7-41df-83be-4a64c33ddeab"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("c8a35bff-6ee5-42b7-acd3-b51a0b4da5d0"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a059b006-776e-47ee-b2de-5edbb7c45a62"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ca90d6c6-31d9-4c01-8066-8e3243d8daa4"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("1d30ddce-ad55-4179-886a-5901748344b7"), 0, "e5ea24a9-5712-4c05-94cf-581a77527e91", "jane.smith@example.com", false, "Jane", "Smith", false, null, "JANE.SMITH@EXAMPLE.COM", "JANE.SMITH", "AQAAAAIAAYagAAAAEBX8DQMC8Ax+ZHBQJpJw2XxzX0Qdrx4bXVHP0dD2bpgAe5DVdnBDhnG2Y43/62ZWTA==", null, false, "1b104180-a2ca-4b75-a1d5-7c8072e90b78", false, "jane.smith" },
                    { new Guid("ec0801ec-b064-4f4e-8091-d11fa4698e13"), 0, "623341b7-fb47-4cbb-8476-92f2f111baa1", "john.doe@example.com", false, "John", "Doe", false, null, "JOHN.DOE@EXAMPLE.COM", "JOHN.DOE", "AQAAAAIAAYagAAAAECYnetElUVEGjKf+IFk+hrgCmsSGzFWDKZBcXBoGrjLo0+IqqvkKdFVs5XoefeUWiA==", null, false, "2134e206-b31e-4997-905c-1899cf300df1", false, "john.doe" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "AssigneeId", "CreatedDate", "Name", "priority", "status" },
                values: new object[,]
                {
                    { new Guid("a5a68a13-f4d5-4404-b421-80b2bb2dc4fc"), new Guid("ec0801ec-b064-4f4e-8091-d11fa4698e13"), new DateTime(2024, 12, 22, 8, 25, 7, 254, DateTimeKind.Utc).AddTicks(2810), "Complete documentation", 2, 0 },
                    { new Guid("c8d3de47-b4ca-4926-97bc-4fe959fa80eb"), new Guid("1d30ddce-ad55-4179-886a-5901748344b7"), new DateTime(2024, 12, 22, 8, 25, 7, 254, DateTimeKind.Utc).AddTicks(2817), "Fix bugs in module", 1, 5 }
                });
        }
    }
}
