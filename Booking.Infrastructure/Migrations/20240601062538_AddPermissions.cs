using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Booking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPermissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "permission_id",
                table: "users",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "permissions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    permission_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_permissions", x => x.id);
                    table.ForeignKey(
                        name: "fk_permissions_permissions_permission_id",
                        column: x => x.permission_id,
                        principalTable: "permissions",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "role_permissions",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "integer", nullable: false),
                    permission_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_role_permissions", x => new { x.role_id, x.permission_id });
                });

            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[] { "id", "name", "permission_id" },
                values: new object[] { 1, "users:read", null });

            migrationBuilder.InsertData(
                table: "role_permissions",
                columns: new[] { "permission_id", "role_id" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "ix_users_permission_id",
                table: "users",
                column: "permission_id");

            migrationBuilder.CreateIndex(
                name: "ix_permissions_permission_id",
                table: "permissions",
                column: "permission_id");

            migrationBuilder.AddForeignKey(
                name: "fk_users_permissions_permission_id",
                table: "users",
                column: "permission_id",
                principalTable: "permissions",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_users_permissions_permission_id",
                table: "users");

            migrationBuilder.DropTable(
                name: "permissions");

            migrationBuilder.DropTable(
                name: "role_permissions");

            migrationBuilder.DropIndex(
                name: "ix_users_permission_id",
                table: "users");

            migrationBuilder.DropColumn(
                name: "permission_id",
                table: "users");
        }
    }
}
