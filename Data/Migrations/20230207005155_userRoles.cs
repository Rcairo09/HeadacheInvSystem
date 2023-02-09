using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeadacheInvSystem.Data.Migrations
{
    public partial class userRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8e4ee496-6f4a-44cf-ac6a-9840646be285", "fa6368af-c6c7-4170-9e2d-21516aec897d", "Administrador", "ADMINISTRADOR" },
                    { "a70499f6-f03a-453d-a3ea-1f08c0abe3f9", "a66fc66b-cb61-4039-8075-1f33de6b314f", "Comprador", "COMPRADOR" },
                    { "e13902c3-491c-4f5c-9f98-842c853c6ac7", "25df1093-3a6e-4ab3-af06-778aa8f01a53", "Vendedor", "VENDEDOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "30edbfe1-280c-4179-84d9-c0a2fa5d77e3", 0, "289e49c0-92d7-490a-b7d1-96572ded02d1", "ApplicationUser", "Rcairo09@gmail.com", true, false, null, "RCAIRO09@GMAIL.COM", "RCAIRO09@GMAIL.COM", "AQAAAAEAACcQAAAAEPqIErzdYCagfNLwZygm0sBXlDCnbUow9Tv+rvjIceSafiBle7TJmX2mn+8gERkmjQ==", null, false, "8a1d65f3-9feb-4275-8ba6-2cce3c847001", false, "Rcairo09@gmail.com" },
                    { "4bbd7347-5b0e-4608-9d5b-843d5b7fb180", 0, "20d2a575-a7c9-43ef-a75a-3e35c0064ae6", "ApplicationUser", "My10@gmail.com", true, false, null, "MY10@GMAIL.COM", "MY10@GMAIL.COM", "AQAAAAEAACcQAAAAELJ56PFcD89bb+xyDQTJ3NkOUd473iKyJ7R9az7lXqEre+jjpU9nQzPSSXefOU7Feg==", null, false, "54a2fda2-47d8-4b8b-a0d2-ce91d7441108", false, "My10@gmail.com" },
                    { "df3cf81f-d2d8-4254-bb2c-0f94344cea9d", 0, "1bdc9ecd-b804-418c-947c-f429fe7d3a19", "ApplicationUser", "martinezjohnny324@gmail.com", true, false, null, "MARTINEZJOHNNY324@GMAIL.COM", "MARTINEZJOHNNY324@GMAIL.COM", "AQAAAAEAACcQAAAAELTXVO+FfSmIiPaEJuHiGsWCv6EEozox8zRX5OzgGgaCV0Con8kY89qeW2KOT1z/ZA==", null, false, "92fdd915-b1f0-4f77-92fa-65c3a4cc5382", false, "martinezjohnny324@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a70499f6-f03a-453d-a3ea-1f08c0abe3f9", "30edbfe1-280c-4179-84d9-c0a2fa5d77e3" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8e4ee496-6f4a-44cf-ac6a-9840646be285", "4bbd7347-5b0e-4608-9d5b-843d5b7fb180" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e13902c3-491c-4f5c-9f98-842c853c6ac7", "df3cf81f-d2d8-4254-bb2c-0f94344cea9d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a70499f6-f03a-453d-a3ea-1f08c0abe3f9", "30edbfe1-280c-4179-84d9-c0a2fa5d77e3" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8e4ee496-6f4a-44cf-ac6a-9840646be285", "4bbd7347-5b0e-4608-9d5b-843d5b7fb180" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e13902c3-491c-4f5c-9f98-842c853c6ac7", "df3cf81f-d2d8-4254-bb2c-0f94344cea9d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e4ee496-6f4a-44cf-ac6a-9840646be285");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a70499f6-f03a-453d-a3ea-1f08c0abe3f9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e13902c3-491c-4f5c-9f98-842c853c6ac7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "30edbfe1-280c-4179-84d9-c0a2fa5d77e3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4bbd7347-5b0e-4608-9d5b-843d5b7fb180");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "df3cf81f-d2d8-4254-bb2c-0f94344cea9d");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
