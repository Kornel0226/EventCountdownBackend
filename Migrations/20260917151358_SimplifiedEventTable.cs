using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventCountdownBackend.Migrations
{
    /// <inheritdoc />
    public partial class SimplifiedEventTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Event_PhysicalLocationRequired",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "FormattedAddress",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "PlaceId",
                table: "Events",
                newName: "Address");

            migrationBuilder.AddColumn<int>(
                name: "ZipCode",
                table: "Events",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Event_PhysicalLocationRequired",
                table: "Events",
                sql: "([IsOnline] = 1) OR ([City] IS NOT NULL AND [Address] IS NOT NULL AND [Country] IS NOT NULL AND [ZipCode] IS NOT NULL)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Event_PhysicalLocationRequired",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Events",
                newName: "PlaceId");

            migrationBuilder.AddColumn<string>(
                name: "FormattedAddress",
                table: "Events",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Events",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Events",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Event_PhysicalLocationRequired",
                table: "Events",
                sql: "([IsOnline] = 1) OR ([Latitude] IS NOT NULL AND [Longitude] IS NOT NULL AND [FormattedAddress] IS NOT NULL)");
        }
    }
}
